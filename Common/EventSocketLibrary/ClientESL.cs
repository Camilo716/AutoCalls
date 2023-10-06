﻿using System.Net.Sockets;
using System.Text;
using EventSocketLibrary.Util;
using EventSocketLibrary.Util.Util;

namespace EventSocketLibrary.ClientESL;

public class ClientESL
{
    private Socket _socket;
    private string HOST;
    private int PORT;

    public ClientESL(string host, int port)
    {
        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        HOST = host;
        PORT = port;
    }

    public void Connect()
    {
        _socket.Connect(HOST, PORT);
    }

    public void CloseConnection()
    {
        _socket.Close();
    }

    public string Authenticate(string password)
    {
        string authRequest = RecolectHeaderResponse(); 

        SendData($"auth {password}");

        string authResponse = RecolectHeaderResponse(); 

        string responseValue = DpuParser.GetLineValueFromKey(authResponse, "Reply-Text");
        return responseValue;
    }

    public string ApiCommand(string args)
    {
        SendData($"api {args}");

        string headerResponse = RecolectHeaderResponse();
        string bodyResponse = RecolectBodyResponse(headerResponse);
        
        return bodyResponse;
    }

    private void SendData(string data)
    {
        byte[] msg = Encoding.ASCII.GetBytes($"{data}\n\n");
        _socket.Send(msg);
    }

    private string RecolectBodyResponse(string headerDpu)
    {
        int contentLenght = int.Parse(DpuParser.GetLineValueFromKey(headerDpu, "Content-Length"));
        
        string contentBuffer = "";

        while (contentBuffer.Length < contentLenght)
        {
            contentBuffer += ReceiveData();
        }
        
        return contentBuffer;
    }

    private string RecolectHeaderResponse()
    {
        string dataBuffer = "";

        while (!dataBuffer.EndsWith("\n\n"))
        {
            dataBuffer += ReceiveData();
        }

        return dataBuffer;
    }

    private string ReceiveData()
    {
        byte[] buffer = new byte[10000];
        int bytesReceived = _socket.Receive(buffer);
        
        string data = Encoding.ASCII.GetString(buffer, 0, bytesReceived);

        return data;
    }

}
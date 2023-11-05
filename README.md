# AutoCalls
AutoCalls is a project that provides functionality for saving phone numbers and audio files in a database, and then conducting mass phone calls to multiple numbers while playing an audio message.

## Features
- Phone Number Management: Easily store and manage phone numbers in a database.

- Audio Storage: Store audio byte stream in a database for playback during phone calls.

- Mass Calling: Initiate mass phone calls to a list of numbers and deliver a predefined audio message. (WIP)

## Technologies Used
- ASP.NET
- PostgreSQL
- Entity Framework
- FreeSWITCH
- XUnit

For a better understanding of the project see https://www.youtube.com/watch?v=bnjbOyq8L8U 😹


## Run Tests
```
dotnet test
```
## Set Database
1. Configure connection in appsettings.json or appsettings.development.json
2. Create schema
```
cd ./AutoCallsApi
dotnet ef migrations add MigrationName
dotnet ef database update
```
## Run the API
```
cd ./AutoCallsApi
dotnet run
```

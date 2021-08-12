# MovieRatings Application

## Setup
- Navigate to your target directory. You don't need to create a project folder
- Run `dotnet new sln -o MovieRatings`
- This creates a new solution file inside a directory. Navigate inside the folder
- Create the separate projects inside the solution
    - dotnet new classlib -o MovieRatingsLib
    - dotnet new xunit -o MovieRatingsTests
    - dotnet new console -o MovieRatingsConsole
    - dotnet new classlib -o MovieRatingsListDB
    - dotnet new webapi -o MovieRatingsWeb

- Add all the projects to the solution
    - dotnet sln add ./MovieRatingsLib/MovieRatingsLib.csproj
    - dotnet sln add ./MovieRatingsConsole/MovieRatingsConsole.csproj
    - dotnet sln add ./MovieRatingsTests/MovieRatingsTests.csproj
    - dotnet sln add ./MovieRatingsListDB/MovieRatingsListDB.csproj
    - dotnet sln add ./MovieRatingsWeb/MovieRatingsWeb.csproj

- Add the proper dependencies:
    - Console: Lib, ListDB
    - WebApi: Lib, ListDB
    - Tests: Lib
    - ListDB: Lib
    - Lib: Nothing
    -  e.g. `dotnet add ./MovieRatingsConsole/MovieRatingsConsole.csproj reference ./MovieRatingsLib/MovieRatingsLib.csproj`


## Projects

### Lib

### Console

### WebApi

### Tests

### ListDB

## Setup Debugging
- Run > Start Debugging > .NET core. This creates a launch.json file
- Add in details of what we want to debug
    - Add in the framework and appropriate console exe 
    - Change the folder to point to adjust to the new project structure 
    - change console to integratedTerminal
- Start Debugging > .NET Core. Creates tasks.json as well
- Now we can debug. Add breakpoints to step through the code

## Running
- To run an executable project: `dotnet run --project ./MovieRatingsConsole/MovieRatingsConsole.csproj`


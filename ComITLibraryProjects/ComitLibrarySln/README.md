## Instructions for integrating your engine into a WebApi project

1. Create the solution file in a new folder
- Navigate to your target directory
- Make a new directory for your entire solution: `mkdir MyProjectSln`
- Change into the directory: `cd MyProjectSln`
- Create the sln file: `dotnet new sln`
- This should create a single .sln file in your folder

2. Create a new WebApi project
- Make sure you are still in the MyProjectSln folder
- Create the project, with a custom name: `dotnet new webapi -o MyProjectWebApi`
- Add the project to the solution: `dotnet sln add MyProjectWebApi`
- The .sln file should now reference MyProjectWebApi

3. Add in your existing engine
- Move or copy your engine project folder into the solution folder
- Delete the .git folder inside the copied project folder
- Add your proejct to the solution: `dotnet sln add MyProject`
- The .sln file should now reference your engine project
- At this point your solution folder should have the following three components: .sln file, WebApi project, engine project

4. Connect the engine to the WebApi
- Navigate into the WebApi project: `cd MyProjectWebApi`
- Add the reference: `dotnet add reference ../MyProject`
- The .csproj file in the WebApi project should now reference your engine project

5. Run the project
- You can either run your WebApi project from the root solution folder, or from the WebApi projecct folder
- If you are in the solution folder: `dotnet run --project MyProjectWebApi`
- If you are in the WebApi project folder: `dotnet run`

Ensure that the project builds and runs. Try calling the default `/WeatherForecast` endpoint. Once you have that working, then you can start adding your own controllers and endpoints. Test these with Postman. You can then also add a gitignore file and push your code to github.



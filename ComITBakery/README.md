## ComIT Bakery 

This is a .NET MVC application that provides a simple management system for a bakery. The user can create inventory items and batches corresponding to each item.

This project emphasizes the following concepts:
- MVC app with more than one controller
- Entity Framework showing a one-to-many relationship
- Interfaces and dependency injection
- Auth and identity
- Configuring, publishing, and deploying an applicaiton

Deployment steps:
- Sign up for Azure
- Create an App Service in Azure (.NET Core 3.1, Windows, free tier)
- Download the Azure App Service VS Code extension
- Set up separate environments (dbs and appSettings.json files) for dev and prod
- Run the cli command: `dotnet publish --configuration Release -o publish`
- Right-click on the generated publish folder and deploy to your app service 

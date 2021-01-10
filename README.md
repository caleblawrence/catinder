# catinder-api
This is an API that provides an endpoint for getting a list of cats in a certain city. It uses https://www.adoptapet.com/ for it's data.

https://catinder-api.azurewebsites.net/swagger/index.html

### running it locally

When you clone it you can cd into the actual solution and run this to start it locally.
```
 dotnet run watch
```

Navigate to `http://localhost:5000/swagger/index.html` to get to the Swagger endpoint for this API. If you are unsure what Swagger is take a look at this (it's pretty cool): https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-5.0

### Deploy to Azure (free)
Run this command after creating an Azure account (and installing the azure commandline tools and run `az login`) and it'll put this app into azure for free. Run the same command to update the app after you have made some changes.
```
az webapp up --sku F1 --name catinder-api --os-type linux
```

If your app uses a database (which it needs for authentication) you'll need to host the db somewhere and setup the connection string in the appsettings files. See below for free postgres hosting.


### Database commands reference
When you setup your database, update the connection strings you should be able to run this command which will run the db migrations against your database and create all the tables needed (for auth etc):
Run migrations: `dotnet ef database update`

### Free postgres db: https://api.elephantsql.com

# ASP.NET Core Empty

command: dotnet new web -o mywebapplication

Initial Files:
Program.cs
Startup.cs

The Startup.cs file has two default methods:

public void ConfigureServices(IServiceCollection services): 
this method is responsible for instantiating new services (MVC, Authentication, Logging, etc). Basically it is a "Get everything ready, load the stuff I gonna need". Prepare environment.


public void Configure(IApplicationBuilder app, IHostingEnvironment env):
This is the "Configure the stuff you loaded" method. Do specific things to set the environment up.
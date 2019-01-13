# ASP.NET Core Empty

command: dotnet new web -o mywebapplication

Initial Files:
Program.cs
Startup.cs

The Startup.cs file has two default methods:

![configureServices](https://github.com/GSoster/ASP.NETCore-Lab/blob/master/images/aspnet-startup-configureServices.PNG)  

this method is responsible for instantiating new services (MVC, Authentication, Logging, etc). Basically it is a "Get everything ready, load the stuff I gonna need". Prepare environment.

![configure](https://github.com/GSoster/ASP.NETCore-Lab/blob/master/images/aspnet-startup-configure.PNG)  

public void Configure(IApplicationBuilder app, IHostingEnvironment env):
This is the "Configure the stuff you loaded" method. Do specific things to set the environment up.

---------

# Implementing an ASP.NET Core app from Empty Template 
1. First thing is to add MVC. 
On *Startup.cs* add the below line to *ConfigureServices* method:
```CS
services.AddMvc()
```
Then add the next line to the *Configure* method:
```CS
app.UseMvc();
```
2. Add a new folder named *Pages* to the project root directory.
3. Add a new Razor Page file (index.cshtml) and start it with the *directive* **@page**. Then add some HTML code to it like 
```HTML
<h1>Hello GSoster from the HEADER OF A RAZOR PAGE</h1>
```
Now run the *dotnet* *run* command on terminal.  
4. Add a new file to the root directory: appsettings.json. It can hold anything that is "application specific". Example: 
```JS
{
    "Message": "Here is a message from the config file!",
    "website": "gsoster.com",
    "NumberOfPostsOnHomePage": 10,
    "ShowAdsOnPage": false,
    "PageSize": 10
    }
```
On the *Startup.cs* file add a constructor that accepts an IConfiguration parameter.
```CS
using Microsoft.Extensions.Configuration;//add the reference
public IConfiguration Configuration { get; set; }//add a property to the class
public Startup(IConfiguration config){//add the constructor
    Configuration = config;
}
```
Now on the Razor Page lets add a reference to the IConfiguration type, inject our Configuration and call a member of it:
```HTML
@using Microsoft.Extensions.Configuration;//add reference
@inject IConfiguration Configuration;//inject
//use it as a normal var inside HTML
<h2> @Configuration["Message"] </h2>
```

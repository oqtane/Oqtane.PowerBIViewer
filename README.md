# Oqtane.PowerBIViewer

![image](https://user-images.githubusercontent.com/1857799/235460849-69919df2-04cf-4b57-833e-06b233bbd18b.png)

## Set-up


![image](https://user-images.githubusercontent.com/1857799/235461514-3dc07498-6927-435a-abf8-e1a0d7e192f3.png)

![image](https://user-images.githubusercontent.com/1857799/235461452-d39ba744-1ef3-4510-884d-5f4f9cd1bf3a.png)




### Links - Microsoft
* [Tutorial: Embed a Power BI report in an application for your customers](https://learn.microsoft.com/en-us/power-bi/developer/embedded/embed-customer-app)
* [Embed Power BI content with service principal and an application secret](https://learn.microsoft.com/en-us/power-bi/developer/embedded/embed-service-principal)
### Links - BlazorHelpWebsite
* [Embedding Power BI in Blazor](https://blazorhelpwebsite.com/ViewBlogPost/5)
# Install (into Oqtane)

In a running version of **Oqtane**, log in as the **Administrator**, and open the **Module Management** in **Admin Dashboard**. On **Download** tab find **Survey** in list of modules. Click on its **Download** button. After it downloads click the **Install** button.

# Install Source
In order to deploy/install a module you should modify the folder path in the debug.cmd and release.cmd files to match the location on your system where the Oqtane framework is installed. Then when you execute this file it will create a Nuget package and copy it to the specified location where the framework will automatically install it upon startup.

# About Oqtane
![Oqtane](https://github.com/oqtane/framework/blob/master/oqtane.png?raw=true "Oqtane")

[Oqtane](https://github.com/oqtane/oqtane.framework) is a Modular Application Framework. It leverages Blazor, an open source and cross-platform web UI framework for building single-page apps using .NET and C# instead of JavaScript. Blazor apps are composed of reusable web UI components implemented using C#, HTML, and CSS. Both client and server code is written in C#, allowing you to share code and libraries.

Oqtane is being developed based on some fundamental principles which are outlined in the [Oqtane Philosophy](https://www.oqtane.org/Resources/Blog/PostId/538/oqtane-philosophy).

Please note that this project is owned by the .NET Foundation and is governed by the **[.NET Foundation Contributor Covenant Code of Conduct](https://dotnetfoundation.org/code-of-conduct)**

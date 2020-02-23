# DotNetTools.Adapter

Use the HttpClientAdapter in your client application to do CRUD operations on the WebAPIs/RestAPIs. 

## Getting Started

### Dependencies

* - Newtonsoft.Json (12.0.3)

Package Manager: ```Install-Package Newtonsoft.Json -Version 12.0.3```

.NET CLI: ```dotnet add package Newtonsoft.Json --version 12.0.3```

### Installing

* Download and add the project to your solution
* Or create Dll file using the project and add it as a reference

### Example Usage

* Add reference to your file
```
using DotNetTools.Adapter;
```
* Use the adapter as required
```
var content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");

await HttpClientAdapter.Post("https://localhost:5001/api/user", HttpContent);
```

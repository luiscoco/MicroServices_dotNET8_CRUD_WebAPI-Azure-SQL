# How to create .NET8 WebAPI Azure SQL MicroService

## 1. Create Azure SQL 




## 2. Create .NET8 WebAPI CRUD Microservice

### 2.1. appsettings.json

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=tcp:mysqlserver1974luiscoco.database.windows.net,1433;Initial Catalog=mysqldatabasename;Persist Security Info=False;User ID=myadminlogin;Password=Luiscoco123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  }
}
```

### 2.2. Program.cs

```csharp
using Microsoft.EntityFrameworkCore;
using AzureSQLWebAPIMicroservice.Data;
using AzureSQLWebAPIMicroservice.Services;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ExampleDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ExampleModelService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
```

### 2.3. Models (ExampleModel.cs)




### 2.4. Service (ExampleModelService.cs)




### 2.5. Data (ExampleDbContext.cs)






### 2.6. Controllers (ExampleModelsController.cs)










**IMPORTANT**: 

In the AzureSQLWebAPIMicroservice.csproj set **InvariantGlobalization** to **false**

```xml
<InvariantGlobalization>false</InvariantGlobalization>
```

This is the whole **AzureSQLWebAPIMicroservice.csproj**

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
    <InvariantGlobalization>false</InvariantGlobalization>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.1" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.1">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.1" />
    <PackageReference Include="Swashbuckle.AspNetCore" Version="6.4.0" />
  </ItemGroup>

</Project>
```

## 3. Add First Migration

Add the package **Microsoft.EntityFrameworkCore.Design**

Add/create first migration with this command:

```
dotnet ef migrations add InitialCreate
```

Also update the database with this command

```
dotnet ef database update
```

## 4. Verify application











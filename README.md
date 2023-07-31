# 4Create - Backend Implementation
### Technologies Used
- C# 10
- .NET 6
- Azure SQL Database (MySQL)
- Docker
- Swagger
- AutoMapper
- Clean Architecture
- Onion Architecture 
- Hexagonal Architecture

### Prerequisites

- .NET 6 SDK
- Docker
- C# 10
- Azure SQL Database

Configure the database connection string in appsettings.json for using MySQL.

```cmd
"FourCreateConnectionString": "Server=tcp:4create-server.database.windows.net,1433;Initial Catalog=4create;Persist Security Info=False;User ID=filipzdelar;Password=Q2zxcvb!bvcQ2zxcvb!bvc;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
```

The other way is to provide IP address so I can add you to pass Azure's firewall.
Azure SQL Database has a firewall that restricts access to specific IP addresse.

```cmd
nslookup myip.opendns.com resolver1.opendns.com
```

In root of directory; run the following commands to set up and run the application:
bash:

Copy code
## Set up the database (using Docker container)
docker-compose up -d

## Build the application
dotnet build

## Run the application
dotnet run --project _4Create

The application will start, and you can access the API documentation using Swagger at https://localhost:5001/swagger/index.html.

# Could have been done better

- Title is integer but should have been a string. 
- Nested 1 is for developer 
- Nested 2 is for manager
- Nested 3 is for tester
- Should have more validation
- Should have more error response
- Should more internal logs
- Should have MS Unite Tests
- Frontend not done
- The CreateSystemLog function should be generic. Adding new property this way does not require changing original.

Example:

```csharp
using System.Reflection;
Type type = obj.GetType();
PropertyInfo[] properties = type.GetProperties();
// Iterate properties
```

Instead of:

```csharp
private SystemLog CreateSystemLog(ResourceType resourceType, long resourceId, string @event, object resourceAttributes, string comment)
    {
        return new SystemLog
        {
            ResourceType = resourceType,
            ResourceId = resourceId,
            CreatedAt = DateTime.Now,
            Event = @event,
            ResourceAttributes = System.Text.Json.JsonSerializer.Serialize(resourceAttributes),
            Comment = comment
        };
    }
```




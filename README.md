
# Tavern System

## Overview

## Configuration: `appsettings.json`
The `appsettings.json` file is a critical configuration file required to successfully launch the application. Below are the default settings and their purposes:

### Default Configuration:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### Explanation:
- **Logging**: Controls the logging level for the application.
  - `Default`: General logging level for the application.
  - `Microsoft.AspNetCore`: Specifies logging level for ASP.NET Core framework.
- **AllowedHosts**: Specifies which hosts are allowed to access the application. The `*` indicates that all hosts are allowed.

### Customizing `appsettings.json`
To successfully run the application, you may need to customize the file to include additional parameters based on your environment. For example:
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
    "DefaultConnection": "YourDatabaseConnectionStringHere"
  },
  "AppSettings": {
    "SomeCustomSetting": "ValueHere"
  }
}
```

Ensure you replace placeholders (e.g., `YourDatabaseConnectionStringHere`) with actual values relevant to your environment.

## Installation Instructions
1. Clone the repository:
   ```bash
   git clone https://github.com/Docentdd/TavernSystem.git
   ```
2. Navigate to the project directory.
3. Configure the `appsettings.json` file as described above.
4. Build and run the application using your preferred IDE or CLI.

# GitHub Codespaces ❤️ .NET

Welcome to your development environment in GitHub Codespaces! This repository is set up to streamline .NET web development with a ready-to-use backend and frontend setup.

## Overview
This project includes:
- A **Weather API** implementation
- **OpenAPI integration** for testing with **Scalar**
- A **Blazor web application** for displaying data

## Getting Started
Everything you do here remains within this Codespace. If you want to commit your work to a GitHub repository, follow these steps:
1. Click on `Source Control` in the left sidebar.
2. Connect to a GitHub repository.
3. Commit and push your changes.

## Dependencies
The project is built using:
- **msal**: `1.31.2b1`
- **azure-mgmt-resource**: `23.1.1`
- **Python**: `3.12.8`

## Azure Deployment
To deploy the application to Azure App Service, follow these steps:

### 1. Set Up Azure CLI (if not installed)
```bash
curl -sL https://aka.ms/InstallAzureCLIDeb | sudo bash
```

### 2. Login to Azure
```bash
az login
```

### 3. Set Required Variables
```bash
RESOURCE_GROUP="MyResourceGroup"
APP_NAME="my-dotnet-app"
PLAN_NAME="MyAppServicePlan"
REGION="eastus"
```

### 4. Create Resources & Deploy
```bash
az group create --name $RESOURCE_GROUP --location $REGION
az appservice plan create --name $PLAN_NAME --resource-group $RESOURCE_GROUP --sku F1
az webapp create --name $APP_NAME --resource-group $RESOURCE_GROUP --plan $PLAN_NAME --runtime "DOTNET:8"
```

## Custom Domain & DNS Setup
If you're setting up a custom domain like **XXXXXXXXXX**, configure the following DNS records:
- **CNAME Record**: Points to the Azure Web App's default domain.
- **TXT Record**: Used for domain verification.
- **NS Record**: If you're migrating domain hosting.

Ensure these changes are reflected in your domain provider settings.

## Contributing
Feel free to edit and improve the project. Contributions are welcome!

## License
This project is open-source and available under the **MIT License**.

---
Happy Coding! 🚀


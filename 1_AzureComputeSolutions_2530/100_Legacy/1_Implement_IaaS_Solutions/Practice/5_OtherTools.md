## Powershell

- Az powershell is a module of the general powershell 
- Powershell gives the features off : Command line shell, scripting language, configuration framework .
- Powershell can run on : Linux, Windows and macOS
- Powershell has the ability to work with .NET objects
- $PSVersionTable > Version of powershell

# Powershell on Azure

- Set the execution Policy
  Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser

- Azure powershell module
  Install-Module -Name Az -Scope CurrentUser -Repository PSGallery -Force -AllowClobber

- It's possible to create an azure app service directly from Powershell (ScriptOne.ps1)
  
- We can also Get source code from Github and push it to our App service
  - You just need to Add Github at : companyapp10001987(App Service) | Deployment Center
  
- PS can be used also to create a staging Solt and do the switch between Production and staging


# Azure CLI

- Seems possible to create an App service based on an image on our container registry
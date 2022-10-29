- Service Plan D1 : Shared infrastructure 1 GB in Memory . 240 minutes/day compute

- To get a live trail of the logs, we need to use the “az webapp log tail” command

- To connect to ACR it's not allow you to assign role-based access control or even allow for headless authentication . 
    - You need to do as follow : az acr login --name <acrName>
    - TODO https://docs.microsoft.com/en-us/azure/container-registry/container-registry-authentication
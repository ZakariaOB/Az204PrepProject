
# Containers

- Problems that containers could solve 
  - Isolation issue 
    - We could have a virtual machine where we have installed our app1 that needs env1 , but after installing 
      env2 needed by another app2 application the app1 will encounter a problem . Containers solve this issue .
    - Containers helps to package the application along with libraries, frameworks and dependencies that are required .
    - So you can package an app and deployed on the same virtual machine .
    - Containers are useful when you have to share the dependencies of an application
    - Containers are isolated and lightweight environnement for hosting your application

- Docker runtime is the bridge between your container and the machine resources : CPU, Memory and Network

- You can try to install those simple containers
  - [Nginx](./Docker_Cmd_1.txt)
  - [Mysql](./0_Scripts/1_Commands/1_SimpleImages/mysql.txt)

# Installing docker on Linux VM

- A way to create a linux VM with docker installed on it 
  - https://github.com/MichaelSL/terraform-azure-linux-vm-

- Create a virtual VM using terraform : [VmCreation](./0_Scripts/0_Terraform/0_LinuxVmCreation/main.tf) 

- To connect to the VM a SSH client will be needed => **Putty** : https://www.putty.org/

- Steps to install docker on the created VM
  - https://docs.docker.com/engine/install/ubuntu/

- sudo docker version : to check for the docker version installed . sudo is used to run with administrative or superuser privileges

# First example : Running nginx container on the newly created VM

- We will need to add an inbound port rule to allow traffic on port 80 with http
  - This could be done manually using azure portal => VM > Networking > Add the rule
  - This is also added to the terraform template

- Run an nginx container based on nginx image : 
- sudo docker run --name appnginx -p 80:80 -d nginx 
- [Click for command details](./Docker_Cmd_1.md)
- Check imgaes using : docker images
- If you access the public image IP address you will see nginx running
- Feel free to destroy the VM : 
     - [VmCreation](./0_Scripts/0_Terraform/0_LinuxVmCreation/main.tf)
     - Open terminal
     - terraform destroy : To be executed without issues make sure to close all clients/apss
       using your VM .


# Containerize a .NET application

- Please refer to the app : [ContainersApp](./1_Apps/ContainersApp/ContainersApp/Program.cs)
- In **appSettings** make sure to have *UseDataBase* to "false*. We don't need Db access for this stage .
   ```json
   "GlobalSettings": {
    "UseDataBase": "false"
  }
  ```
- Check the file [BuildContainersAppDocker.txt](./0_Scripts/1_Commands/0_BuildContainersAppDocker.txt) to build a custom image and run it .
- To open a directory using Windows store terminal : wt -d .
- Issue with calling nuget inside the docker file
  https://stackoverflow.com/questions/50039331/unable-to-load-the-service-index-for-source-https-api-nuget-org-v3-index-json/52313999#52313999
- If the issue is fixed after changing dns and restarting the machine make sure that 
  the generated Dockerfile is present at solution level
- **Important : -p 80:80:** This flag maps the port 80 of the host machine to the port 80 of the container. It means that any traffic sent to port 80 of the host will be forwarded to port 80 of the running container. This is typically done to expose a web server running inside the container to the outside world to use another port you can try : **-p 9999:80**
- You can always publish the application and run a simplified docker file directly on the publish folder 
  - [publish folder](./1_Apps/ContainersApp/ContainersApp/bin/Release/net6.0/publish/)
  - [Simplified Docker File](./1_Apps/ContainersApp/ContainersApp/bin/Release/net6.0/publish/Dockerfile)
  - Windows : use Docker desktop
  - Linux : 
     - Create a linux VM 
     - Install docker on it 
     - Create an image and a container as described [here](./0_Scripts/1_Commands/BuildContainersAppDocker.md)


# Azure container registry {#create_container_registry}

- Azure Container Registry is a cloud-based service provided by Microsoft Azure that allows you to store and manage container images for your applications, making them easily accessible for deployment in Azure or other container platforms.
- You can use terrform to create/destroy an azure registry [Create Azure registry](./0_Scripts/0_Terraform/1_ContainerRegistry/main.tf)
- You can push the created windows image using
  az acr login --name containerregistrysqliaz204.azurecr.io --username containerRegistrysqliaz204 --password iqFyHXWX5AneKOuk8UTmy08VgXBKyA61xndn4QO3eN+ACRAaEtLO
- docker tag containers-app containerregistrysqliaz204.azurecr.io/containers-app:latest
- docker push containerregistrysqliaz204.azurecr.io/containers-app:latest
- By default the tag will be latest in this case
- To create a different Tag
  - docker tag containers-app containerregistrysqliaz204.azurecr.io/containers-app:tagnew
  - docker push containerregistrysqliaz204.azurecr.io/containers-app:tagnew
- [More Info about Tags](./0_Scripts/1_Commands/1_TagImages.md)

# Azure container instance

- You can create a container instance based on your registry (If allow admin is enabled)
- Once done if you go to the public IP address of your instance you will find your app published .
- One of the benefits of the container instance is the managed storage .
- Terraform template to create a container instance 
    - When you apply the execution plan, Terraform outputs the public IP address. To display the IP address again, run: **terraform output -raw container_ipv4_address**
    - [Create container instance](./0_Scripts/0_Terraform/2_ContainerInstance/main.tf)


# Multi staged Build

- This is designed to reduce the size of the image build process
- With each instruction docker can create layer inside our Docker image
- Consider a layer (As build): FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
- **Once the stage is complete the layer will be deleted**


# Azure container groups

## Creating a Mysql container

- [Creating a Mysql container](./0_Scripts/1_Commands/2_MYSQL/)
- Build image              : docker build -t appsqlimage .
  - This will need to switch to Linux containers .
- Run container            : docker run -d -p 3306:3306 --name appsql appsqlimage
- Connect to the container : docker exec -it appsql bash
- mysql -uroot -p
  - Run some commands for testing
    - *show databases;* (Use semicolon terminator)
    - *use appdb;* 
    - *show tables;*


## Push the mysql image to container registry

- [Recreate the container registry](#create_container_registry)
- Push the previous mysql image
  - docker login containerregistrysqliaz204.azurecr.io -u containerRegistrysqliaz204 -p bNYj+aMjp6ys5e1URIgsfbt3wM+G+85Ky96HlRQmOx+ACRCYYp/Y
  - docker tag appsqlimage containerregistrysqliaz204.azurecr.io/appsqlimage:tagone
  - docker push containerregistrysqliaz204.azurecr.io/appsqlimage:tagone

## Push the containers app image to the registry

- [Go To ContainersApp](./1_Apps/ContainersApp/)
- In **appSettings** make sure to have *UseDataBase* to "true* and *UseContainerDatabase* to *true* : 
   ```json
   "GlobalSettings": {
    "UseDataBase": "true",
    "UseContainerDatabase" : "true"
  }
  ``` 
- Create an image and a container as described [here](./0_Scripts/1_Commands/0_BuildContainersAppDocker.md)
- Push the created containers app image (Use the registry login details)
  - az acr login --name containerregistrysqliaz204.azurecr.io --username containerRegistrysqliaz204 --password bNYj+aMjp6ys5e1URIgsfbt3wM+G+85Ky96HlRQmOx+ACRCYYp/Y
  - docker tag containers-app containerregistrysqliaz204.azurecr.io/containers-app:latest
  - docker push containerregistrysqliaz204.azurecr.io/containers-app:latest

- After pushing the images let us deploy the container group using 
  [Go to deployment.yml](./0_Scripts/0_Terraform/4_DeployContainerGroup/deployment.yml)
  TODO : deploy using terraform and dynamically read content from deployment.yml
- Run this in the azure command shell
  - az container create --resource-group rg_acr204_resources --file deployment.yml
- For any change you need to delete and recreate the container group




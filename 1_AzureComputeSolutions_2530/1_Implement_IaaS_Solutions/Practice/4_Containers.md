# General 

- Containers are useful when you have to share the dependencies of an application

- Installing docker on a Linux virtual machine (Choose the ubunto distribution)
   - Create a Linux Vm first
   - https://docs.docker.com/engine/install/ubuntu/

- Images repositories can give the possiblity to get an image on any other machine
  and just use it to run a container based on it .

- Image repository examples : Docker Hub

- sudo docker imgaes > check available images

- Run a docker container on the linux VM based on Nginx
    - Open port 80 on the VM to expose it for HTTP
    - Run this command on PUTTY
         sudo docker run --name appnginx -p 80:80 -d nginx
         This will download the image (nginx) on docker hub 
         80:80 : Map Vm port to container port
    - sudo docker images : In order to check

# Containerize a .NET application

- Create a new Sql db/server 
    appuser
    ZakariaAz@20152015
- Use sqlapp and replace the connection strings right there
- Publish the app locally and copy the publish folder to the linux machine
- Copy also the docker file to be able to build the image
- Build image : sudo docker build -t sqlapp .
- sudo docker ps : Check running containers
- stop nginx to run our new container on port 80 : 
    sudo docker stop 7ad94bc7a8da
- Run the new container based on the new image : 
  sudo docker run --name sqlapp-1 -p 80:80 -d sqlapp
- After that you application will be running using the public IP address

# In case of a mistake

- Remove the container : sudo docker rm d90 
- Remove the image : sudo docker image rm sqlapp
- Republish the app and rebuild a new image

# Azure container rgistry

- Afer creating the registry enable admin user in order to be able to publish to 
  repository .
- Installing azure Cli on a linux machine 
   https://docs.microsoft.com/en-us/cli/azure/install-azure-cli-linux?pivots=apt
- Login to the registry 
  sudo az acr login --name registryazakaria204 --username registryazakaria204 --password fIq1p84/AV08x4JD7qajlWAB2pSGo1EJ
- Tag the image (Is it mandatory ?) : 
  sudo docker tag sqlapp registryazakaria204.azurecr.io/sqlapp
- Push the image 
  sudo docker push registryazakaria204.azurecr.io/sqlapp
- Then the image will be shown at repositories level for our registry


# Azure container instance

- You can create a container instance based on your registry (If allow admin is enabled)
- Once done if you go to the public IP address of your instance you will find your app published !!

# Multi staged Build (Need to check more about this)

- This is designed to reduce the size of the image build process
- With each instruction docker can create layer inside our Docker image
- Consider a layer (As build): FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
- **Once the stage is complete the layer will be deleted**
- We will need to copy the source code inside the linux VM
- Then copy the new Dockerfile and use it to build the new image
- Let us build a new image
  sudo docker build -t sqlapp-new .
- sudo docker run --name sqlapp-2 -p 80:80 -d sqlapp-new
- TODO check more about mutli stage builds
  
# Azure container groups

- Deployment of the container instances
- The ACG could deal with multiple container groups
- ACG could be managed using ARM templates or YAML Files
- Create a custom MYSQL image with intialization
  - Copy CustomeMysqlFoder to the Linux VM
  - Build image              : sudo docker build -t appsqlimage .
  - Run container            : sudo docker run -d -p 3306:3306 --name appsql appsqlimage
  - Connect to the container : sudo docker exec -it appsql bash
  - mysql -uroot -p
- We can eventually connect to our app

# Deploying the custom MySQL container

- sudo docker login companyregistry.azurecr.io -u companyregistry -p u0K36bwuW4E85jUFQL6l6d/jEtf7wA71
- sudo docker tag appsqlimage registryazakaria204.azurecr.io/appsqlimage
- sudo docker push registryazakaria204.azurecr.io/appsqlimage
- Let us create another container instance 
- We can connect to the mysql container instance also
- For some reason I was not able to connect here (to the new created container instance)!!

# Azure container Group

- At container group level you can refer to the machine by localhost
- The app and db server will be running on the same machine
- First we need to use 'localhost' to make the app able to connect to the server 
- We need to rebuild our new images and republish it
- Remove the previous images : sudo docker image remove sqlapp
- Let us republish our new images
    - sudo az acr login --name registryazakaria204 --username registryazakaria204 --password fIq1p84/AV08x4JD7qajlWAB2pSGo1EJ
    - sudo docker build -t sqlapp .
    - sudo docker tag sqlapp registryazakaria204.azurecr.io/sqlapp
    - sudo docker push registryazakaria204.azurecr.io/sqlapp
    - sudo docker build -t appsqlimage .
    - sudo docker tag appsqlimage registryazakaria204.azurecr.io/appsqlimage
    - sudo docker push registryazakaria204.azurecr.io/appsqlimage
- Now we will use deployment.yml file to deploy our group
- We will use the azure cloud shell
- az container create --resource-group Az-204-grp --file deployment.yml
- After that if you go to overview at container instances level (The new created one) you can see your application
- TODO : Understand why the opened application will be the web one at container group
         and not db app .
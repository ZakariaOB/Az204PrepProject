# Building Linux VM

- Choose ubunto server image

- Credentials
    Zakaria
    ZakariaAz@20152015


# Deploying the .NET app on our VM

- Linux VM
   Credentials 
      Zakaria
      ZakariaAz@20152015
  - We will need to install PuTTy in order to connect to our Linux VM
  - You can also run the application on the Kestrel webserver
  - It's bundled on the ASP.NET web core framework
  - We need to publish first our app to a folder
  - We will need a free tool to copy our folder content to Linux VM
       WinSCP is a free SFTP, SCP, S3, WebDAV, and FTP client for Windows.
  - Publish our project binaries to : bin\Release\net6.0\publish\
  - Use WinSCP to connext to your Linux VM
  - Once OK : Right > Your local directory / Left > Your Linux VM
  - Installation of .NET 6 on Ubunto machine commands 
           https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu#1804
  - cd publish 
      dotnet Az204SecondApp.dll


# Using Nginx on the Linux VM

  - Browse the WebApp
     Let us use Nginx to redirect the requests to Kestrel 5000
     Let us use Nginx
        sudo apt-get install nginx
        sudo service nginx stop
        sudo chmod 777 default => Give permissions on default folder
        sudo service nginx start
  - We need to configure nginx to redirect to our application to be served using Kestrel
    - We go /etc/nginx/sites-available
    - cd /etc
    - cd nginx
    - cd sites-available
    - sudo chmod 777 default (Give permissions on default folder , 777 is the code of the permission)
      > Once able to change nginx file we will have to redirect from it to our Website
         proxy_pass http://localhost:5000;
         proxy_http_version 1.1;
         proxy_set_header Upgrade $http_upgrade;
         proxy_set_header Connection keep-alive;
         proxy_set_header Host $host;
         proxy_cache_bypass $http_upgrade;

      - sudo service nginx start
      - sudo chmod 644 default
      - cd /home/Zakaria
      - dir
      - cd publish
      - dir
      - dotnet Az204FirstApp.dll
      - !IMPORTANT! To refresh the app content you will probably need to stop the app before republishing
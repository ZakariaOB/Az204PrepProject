## Build the windows VM

- First VM
   Zakaria
   ZakariaAz@20152015

- You can use Standard_Edbds_v5 - 2vcpus

## Connecting to the VM

- Use RDP to connect 

## Host an App on azure VM

- Many resources are created automatically with the virtual machine
    - Public ip address
    - Network security group
    - Network interface
    - Disk
    - Notwork watcher : Network diagnostics  

- Let us try to host Az204FirstApp to the new created VM

- We need to add a web server on the VM to make our app accessible

- We need also to allow traffic using the NSG

- Installing IIS
    - Start Menu > Server Manager > Server Manager Dashboard
    - Add roles and features
    - Go to 'Server Roles' and install Web server IIS
    - Go to IIS manager
    - If you try to access the public IP address it will give nothing 
    - You need to add a security group to allow traffic to port 80

- Publish the project directly
    - Steps
        - Assign a DNS name to the VM : Overview > DNS name
            - Users are more familiar with Names than IPs
        - Assign a static IP address to the VM
        - Add rule for port 8172 to the Network security group => Inboud custom port number
        - Add the role to the management service on the VM
           - This will allow the server to be managed remotly using IIS server
        - IIS Management service > Enable remote connections on port 8172 (This is why we allowed traffic on this port to the VM)
        - Go to Local server > IE enhanced security service  > allow download on the VM 
        - Install the .NET core hosting bundle . This allow the .NET core app to be hosted on IIS
        - Install the Web deploy v3.6 tool
        - Web deploy is responsible at destination machine of taking care of your app 
          and deploy it going from Visual studio
            Possible issues 
               : https://stackoverflow.com/questions/11796838/web-deployment-task-failed-could-not-connect-server-did-not-respond

        - Website link : http://az204dns.southeastasia.cloudapp.azure.com/Az204SecondApp


Questions 
   > How can I host multiple apps to the same web server

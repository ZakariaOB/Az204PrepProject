
- Azure resource manager templates are basically tools that enables creating resources based on coded templates

- In vs code we will need to install ARM tools

- The shcema attribute loading basic schema in order to define ARM templates

- ARM templates use name value pairs

- It's possible to deploy an arm template directly from Vs code
   - New-AzResourceGroupDeployment -ResourceGroupName Az-204-grp -TemplateFile 'C:\Users\zboukhris\Desktop\ZLearn\Azure\AZ-204\Az204PrepProject\1_AzureComputeSolutions_2530\1_Implement_IaaS_Solutions\0_Resources\3_ARMS\newtmp_copy.json'

- We can also deploy the template directly from azure portal 
    - You will need to go and search for 'Template'


- copy property at arm template level will help on copy the resource created

- But the copy will need some logic backed 'concat' and 'copyIndex()' functions 
  - Check the file : newtmp_copy.json

- For Vms you can actually use : Template deployment
  - You can define dependencies using : dependsOn
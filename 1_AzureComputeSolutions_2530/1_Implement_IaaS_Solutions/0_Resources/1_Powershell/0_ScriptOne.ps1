$ResourceGroupName = "powsershell-grp";
$Location = "North Europe";
$AppServicePlanName = "companyPlan";
$WebAppName = "companyapp10001987";

Connect-AzAccount

New-AzResourceGroup -Name $ResourceGroupName -Location $Location

# We first need to create an App Service Plan

New-AzAppServicePlan -ResourceGroupName $ResourceGroupName `
-Location $Location -Tier "B1" -NumberofWorkers 1 -Name $AppServicePlanName

# Then we can create the Azure Web App

New-AzWebApp -ResourceGroupName $ResourceGroupName -Name $WebAppName `
-Location $Location -AppServicePlan $AppServicePlanName

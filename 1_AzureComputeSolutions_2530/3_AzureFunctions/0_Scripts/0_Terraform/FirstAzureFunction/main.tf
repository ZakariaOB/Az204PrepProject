resource "azurerm_resource_group" "rg204Functions" {
  name     = "rg204Functions"
  location = "West Europe"
}

resource "azurerm_storage_account" "rg204Functions" {
  name                     = "rg204functionsstore"
  resource_group_name      = azurerm_resource_group.rg204Functions.name
  location                 = azurerm_resource_group.rg204Functions.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_app_service_plan" "rg204Functions" {
  name                = "rg204functionsplan"
  location            = azurerm_resource_group.rg204Functions.location
  resource_group_name = azurerm_resource_group.rg204Functions.name
  kind                = "FunctionApp"

  sku {
    tier = "Dynamic"
    size = "Y1"
  }
}

resource "azurerm_function_app" "rg204Functions" {
  name                       = "Az204FunctionApp240523"
  location                   = azurerm_resource_group.rg204Functions.location
  resource_group_name        = azurerm_resource_group.rg204Functions.name
  app_service_plan_id        = azurerm_app_service_plan.rg204Functions.id
  storage_account_name       = azurerm_storage_account.rg204Functions.name
  storage_account_access_key = azurerm_storage_account.rg204Functions.primary_access_key
}
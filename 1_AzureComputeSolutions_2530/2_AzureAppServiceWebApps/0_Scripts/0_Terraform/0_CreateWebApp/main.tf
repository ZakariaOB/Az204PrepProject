resource "azurerm_resource_group" "rg-204-webapp" {
  name     = "rg-204-webapp-resources"
  location = "West Europe"
}

resource "azurerm_service_plan" "rg-204-webapp" {
  name                = "rg-204-webapp"
  resource_group_name = azurerm_resource_group.rg-204-webapp.name
  location            = azurerm_resource_group.rg-204-webapp.location
  sku_name            = "P1v2"
  os_type             = "Windows"
}

resource "azurerm_windows_web_app" "az204webapp" {
  name                = "az204webapp-14052023"
  resource_group_name = azurerm_resource_group.rg-204-webapp.name
  location            = azurerm_service_plan.rg-204-webapp.location
  service_plan_id     = azurerm_service_plan.rg-204-webapp.id

  site_config {}
}
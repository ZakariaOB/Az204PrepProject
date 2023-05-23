resource "azurerm_resource_group" "rg_acr204" {
  name     = "rg_acr204_resources"
  location = "West Europe"
}

resource "azurerm_container_registry" "acr" {
  name                = "containerRegistrysqliaz204"
  resource_group_name = azurerm_resource_group.rg_acr204.name
  location            = azurerm_resource_group.rg_acr204.location
  sku                 = "Premium"
  admin_enabled       = false
  georeplications {
    location                = "East US"
    zone_redundancy_enabled = true
    tags                    = {}
  }
  georeplications {
    location                = "North Europe"
    zone_redundancy_enabled = true
    tags                    = {}
  }
}
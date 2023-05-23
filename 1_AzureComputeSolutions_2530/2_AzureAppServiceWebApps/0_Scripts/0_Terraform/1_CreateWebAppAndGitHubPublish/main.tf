resource "azurerm_resource_group" "rg204az170523" {
  name     = "rg204az170523"
  location = "West Europe"
}

resource "azurerm_service_plan" "app_plan1000204" {
  name                = "app_plan1000204"
  location            = azurerm_resource_group.rg204az170523.location
  resource_group_name = azurerm_resource_group.rg204az170523.name
  sku_name            = "P1v2"
  os_type             = "Windows"
}

resource "azurerm_windows_web_app" "webapp" {
  name                = "webapp20416052023"
  location            = azurerm_resource_group.rg204az170523.location
  resource_group_name = azurerm_resource_group.rg204az170523.name
  service_plan_id     = azurerm_service_plan.app_plan1000204.id
  site_config {

  }
  connection_string {
    name  = "SQLConnection"
    type  = "SQLAzure"
    value = "Server=tcp:server204170523.database.windows.net,1433;Initial Catalog=products;Persist Security Info=False;User ID=adminlogin204;Password=adminlogin@@_2044170523;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  }
}
/*
resource "azurerm_app_service_source_control" "source_control" {
  app_id   = azurerm_windows_web_app.webapp.id
  repo_url = "https://github.com/ZakariaOB/AppServiceApp204.git"
  branch   = "master"
}

resource "azurerm_source_control_token" "token" {
  // Add source control token configuration
  token     = "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"
  type     = "GitHub"
  depends_on = [
    azurerm_app_service_source_control.source_control
 ]
}*/

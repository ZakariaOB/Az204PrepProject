locals {
  resource_group = "rg204webapp-resources"
  location       = "West Europe"
}


resource "azurerm_resource_group" "rg-204-grp" {
  name     = local.resource_group
  location = local.location
}

resource "azurerm_service_plan" "app_plan1000204" {
  name                = "app_plan1000204"
  location            = azurerm_resource_group.rg-204-grp.location
  resource_group_name = azurerm_resource_group.rg-204-grp.name
  sku_name            = "P1v2"
  os_type             = "Windows"
}

resource "azurerm_windows_web_app" "webapp" {
  name                = "webapp20416052023"
  location            = azurerm_resource_group.rg-204-grp.location
  resource_group_name = azurerm_resource_group.rg-204-grp.name
  service_plan_id     = azurerm_service_plan.app_plan1000204.id
  site_config {

  }
  connection_string {
    name  = "SQLConnection"
    type  = "SQLAzure"
    value = "Data Source=tcp:${azurerm_mssql_server.server204170523.fully_qualified_domain_name},1433;Initial Catalog=${azurerm_mssql_database.products.name};User Id=${azurerm_mssql_server.server204170523.administrator_login};Password='${azurerm_mssql_server.server204170523.administrator_login_password}';"
  }
}

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
}

## DB

resource "azurerm_storage_account" "store204170523" {
  name                     = "store204170523"
  resource_group_name      = azurerm_resource_group.rg-204-grp.name
  location                 = azurerm_resource_group.rg-204-grp.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_mssql_server" "server204170523" {
  name                         = "server204170523"
  resource_group_name          = azurerm_resource_group.rg-204-grp.name
  location                     = azurerm_resource_group.rg-204-grp.location
  version                      = "12.0"
  administrator_login          = "adminlogin204"
  administrator_login_password = "adminlogin@@_2044170523"
}

resource "azurerm_mssql_database" "products" {
  name           = "products"
  server_id      = azurerm_mssql_server.server204170523.id
  collation      = "SQL_Latin1_General_CP1_CI_AS"
  license_type   = "LicenseIncluded"
  max_size_gb    = 1
  read_scale     = false
  sku_name       = "S0"
  zone_redundant = false
  depends_on = [
    azurerm_mssql_server.server204170523
  ]
}

resource "azurerm_mssql_firewall_rule" "firewall" {
  name             = "app-server-firewall-rule"
  server_id        = azurerm_mssql_server.server204170523.id
  start_ip_address = "102.78.161.73"
  end_ip_address   = "102.78.161.73"
  depends_on = [
    azurerm_mssql_server.server204170523
  ]
}

resource "null_resource" "database_setup" {
  provisioner "local-exec" {
      command = "sqlcmd -S ${azurerm_mssql_server.server204170523.fully_qualified_domain_name} -U ${azurerm_mssql_server.server204170523.administrator_login} -P ${azurerm_mssql_server.server204170523.administrator_login_password} -d products -i 01.sql"
  }
  depends_on=[
    azurerm_mssql_database.products,
    azurerm_mssql_firewall_rule.firewall
  ]
}
resource "azurerm_resource_group" "rg204az170523" {
  name     = "rg204az170523"
  location = "West Europe"
}

resource "azurerm_storage_account" "store204170523" {
  name                     = "store204170523"
  resource_group_name      = azurerm_resource_group.rg204az170523.name
  location                 = azurerm_resource_group.rg204az170523.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_mssql_server" "server204170523" {
  name                         = "server204170523"
  resource_group_name          = azurerm_resource_group.rg204az170523.name
  location                     = azurerm_resource_group.rg204az170523.location
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
/*
resource "azurerm_mssql_firewall_rule" "firewall" {
  name             = "app-server-firewall-rule"
  server_id        = azurerm_mssql_server.server204170523.id
  start_ip_address = "102.78.161.73"
  end_ip_address   = "102.78.161.73"
  depends_on = [
    azurerm_mssql_server.server204170523
  ]
}
*/
resource "null_resource" "database_setup" {
  provisioner "local-exec" {
      command = "sqlcmd -S ${azurerm_mssql_server.server204170523.fully_qualified_domain_name} -U ${azurerm_mssql_server.server204170523.administrator_login} -P ${azurerm_mssql_server.server204170523.administrator_login_password} -d products -i init.sql"
  }
  depends_on=[
    azurerm_storage_account.store204170523,
    azurerm_mssql_database.products
  ]
}
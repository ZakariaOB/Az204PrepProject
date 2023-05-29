provider "azurerm" {
  subscription_id = "fbecb028-2ef6-422c-acb8-06d3fe64064f"
  client_id       = "a5f48996-9bf0-4d1f-8dd7-22ba0a6f11fe"
  client_secret   = "12o8Q~aCqEWYgLP~uFz4JvnI4Qo-MKQnRG1AEbU1"
  tenant_id       = "20f62116-4d0c-44ac-8a45-390ca2765601"
  features {}
}

terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "3.55.0"
    }
  }
}
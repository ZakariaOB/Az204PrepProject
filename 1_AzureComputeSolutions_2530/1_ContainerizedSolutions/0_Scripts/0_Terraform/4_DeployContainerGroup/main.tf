locals {
  deployment_content = yamldecode(file("deployment.yml"))
}

resource "azurerm_container_group" "rg" {
  name                = "container-group-204"
  location            = "eastus"
  resource_group_name = "rg_acr204_resources"
  ip_address_type     = "public"
  dns_name_label      = "container-group-204"
  os_type             = "Linux"

  container {
    name = "db"

    properties {
      image = local.deployment_content.containers[0].properties.image

      resources {
        requests {
          cpu    = local.deployment_content.containers[0].properties.resources.requests.cpu
          memory = local.deployment_content.containers[0].properties.resources.requests.memoryInGb
        }
      }

      ports {
        port     = local.deployment_content.containers[0].properties.ports[0].port
        protocol = "TCP"
      }
    }
  }

  container {
    name = "web"

    properties {
      image = local.deployment_content.containers[1].properties.image

      resources {
        requests {
          cpu    = local.deployment_content.containers[1].properties.resources.requests.cpu
          memory = local.deployment_content.containers[1].properties.resources.requests.memoryInGb
        }
      }

      ports {
        port     = local.deployment_content.containers[1].properties.ports[0].port
        protocol = "TCP"
      }
    }
  }
}

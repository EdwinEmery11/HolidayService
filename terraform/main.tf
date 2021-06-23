#terraform block - with required providers (Azure)
terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 2.46.0"
    }
  }
}

#provider 
provider "azurerm" {
  features {}
  /*subscription_id = "3eba6e29-3983-495b-a539-c3c4b43fb90c"
  tenant_id       = "396f232e-9a84-46de-be7d-cf76b93f59d1"
  */
}

#variables can have blocks input variables | default names (if not supplied give these default values)
variable "services" {
  description = "Holiday app services "
  type        = map(any)
  default = {
    frontend = {
      name = "edwin-holidaysservice-frontend"
    },
    serviceone = {
      name = "edwin-holidaysservice-service1"
    },
    servicetwo = {
      name = "edwin-holidaysservice-service2"
    },
    servicethree = {
      name = "edwin-holidaysservice-service3"
    },
  }
}

#creates the resource group
resource "azurerm_resource_group" "rg" {
  name     = "edwine-SFIAproject-2"
  location = "uksouth"
}
#create app service plan 
resource "azurerm_app_service_plan" "app-service-Holidays" {
  name                = "holidayService-SFIAproject-2"
  resource_group_name = azurerm_resource_group.rg.name
  location            = azurerm_resource_group.rg.location
  kind                = "Linux"
  reserved            = true
  
  #pricing tier
  sku {
    tier = "Basic"
    size = "B1"
  }
}

#creates the services 
resource "azurerm_app_service" "holidayservice" {
  for_each            = var.services
  name                = each.value.name
  resource_group_name = azurerm_resource_group.rg.name
  location            = azurerm_resource_group.rg.location
  app_service_plan_id = azurerm_app_service_plan.app-service-Holidays.id

  app_settings = {

    "CitiesServiceURL" = "https://edwin-holidaysservice-service2.azurewebsites.net"

    "DestinationServiceURL" = "https://edwin-holidaysservice-service2.azurewebsites.netyes/"

    "mergedServiceURL" = "https://edwin-holidaysservice-service3.azurewebsites.net/"

  }
  site_config {
    dotnet_framework_version = "v5.0"
    scm_type                 = "None"

  }

}

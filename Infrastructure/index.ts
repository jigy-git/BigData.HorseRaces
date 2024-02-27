
import * as azure from "@pulumi/azure-native";
import { CreateHorseRacesAPI } from "./createapi";

const resourceGroupName = "rghorsesrace"
// Creating an Azure Resource Group
const resourceGroup = new azure.resources.ResourceGroup(resourceGroupName, {
    resourceGroupName: resourceGroupName,
});

CreateHorseRacesAPI(resourceGroup)


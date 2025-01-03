using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;
using System;
using Azure;
using Azure.Core;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        //string subscriptionId = "1e98557a-07ee-422f-84d7-a7d09c017daa";
        string resourceGroupName = "my-sdk-rg";
        string storageAccountName = "newstorageaccount12";
        string location = "WestUS2"; // You can choose your desired Azure region
        //AzureLocation location = AzureLocation.WestUS2;
        

        // Authenticate using DefaultAzureCredential
        var credential = new DefaultAzureCredential();
        var client = new ArmClient(credential);
        SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
        ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
        ResourceGroupData resourceGroupData = new ResourceGroupData(location);
        ArmOperation<ResourceGroupResource> operation = await resourceGroups.CreateOrUpdateAsync(WaitUntil.Completed, resourceGroupName, resourceGroupData);


        // Create the resource group if it doesn't exist
        //var subscription = client.GetDefaultSubscription();
       // var resourceGroup = await subscription.GetResourceGroups().CreateOrUpdateAsync(resourceGroupName, new ResourceGroupData(location));

        Console.WriteLine($"Resource Group '{resourceGroupName}' created in '{location}'");

        // Create a new Storage Account in the resource group
      

       // var storageAccount = await resourceGroup.Value.GetStorageAccounts().CreateOrUpdateAsync(storageAccountName, storageAccountData);

        Console.WriteLine($"Storage Account '{storageAccountName}' created successfully.");
    }
}

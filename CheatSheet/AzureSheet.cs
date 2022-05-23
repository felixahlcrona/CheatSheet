namespace CheatSheet
{
    internal class AzureSheet
    {

        public static void RetriveLocalSettingsJsonCLI()
        {
            // Download Azure CLI
            // https://hackernoon.com/how-to-use-azure-functions-core-tools-to-create-a-localsettingsjson-file-and-run-functions-locally

            //az login
            //az account set - s "<subscription-name-or-id>"
            //func azure functionapp fetch-app - settings '<function-name>'--output - file local.settings.json
            //func settings decrypt

            //az login
            //az account set - s "test"
            //func azure functionapp fetch-app - settings 'VO-Communication'--output - file local.settings.json
            //func settings decrypt
        }


        // % tecken för att läsa en enviormentvariabel i en azure function

        //[FunctionName("StoreDeviceOrganisationFunc")]
        //public async Task StoreDeviceOrganisation(
        //[ServiceBusTrigger("%ServiceBus:DeviceAddedTopic%", "%ServiceBus:DeviceAddedSubscription%", Connection = "ServiceBus:ConnectionString")] DeviceAddedEvent deviceAddedEvent,
        //ILogger logger)
        //{

        //}
    }
}

// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using AnimalInCubators.Contracts.AnimalIncubators_prc1;
using AnimalInCubators.Contracts.AnimalIncubators_prc1.ContractDefinition;
using AnimalInCubators.Contracts.AnimalFeeding;
using AnimalInCubators.Contracts.AnimalFeeding.ContractDefinition;
using AnimalInCubators.Contracts.AnimalHelper;
using AnimalInCubators.Contracts.AnimalHelper.ContractDefinition;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace AnimalInCubatorsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("##################Starting Experiment 5.1##################");
            // Console.WriteLine("");
            // Experiment1().Wait();
            // Console.WriteLine("");
            
            // Console.WriteLine("##################Starting Experiment 5.2##################");
            // Console.WriteLine("");
            // Experiment2().Wait();
            // Console.WriteLine("");

            Console.WriteLine("##################Starting Experiment 5.3##################");
            Console.WriteLine("");
            Experiment3().Wait();
            Console.WriteLine("");
        }

        static async Task Experiment1()
        {
            try
            {
                // Setup using the Nethereum public test chain
                var url = "http://testchain.nethereum.com:8545";
                var privateKey = "0x7580e7fb49df1c861f0050fae31c2224c6aba908e116b8da44ee8cd927b990b0";
                var account = new Account(privateKey);
                var web3 = new Web3(account, url);

                Console.WriteLine("Deploying...");
                var deployment = new AnimalincubatorsPrc1Deployment();
                var receipt = await AnimalincubatorsPrc1Service.DeployContractAndWaitForReceiptAsync(web3, deployment);
                var service = new AnimalincubatorsPrc1Service(web3, receipt.ContractAddress);
                Console.WriteLine($"Contract Deployment Tx Status: {receipt.Status.Value}");
                Console.WriteLine($"Contract Address: {service.ContractHandler.ContractAddress}");
                Console.WriteLine("");

                Console.WriteLine("Sending a transaction to the function createRandomAnimal() (creating animal \"Drogon\", \"Rheagal\", \"Viserion\") ...");
                var receiptForCreateRandomAnimalFunctionCall = await service.CreateRandomAnimalRequestAndWaitForReceiptAsync(new AnimalInCubators.Contracts.AnimalIncubators_prc1.ContractDefinition.CreateRandomAnimalFunction() { Name = "Drogon", Gas = 400000 });
                Console.WriteLine($"Finished storing an animal named \"Drogon\": Tx Hash: {receiptForCreateRandomAnimalFunctionCall.TransactionHash}");
                Console.WriteLine($"Finished storing an animal named \"Drogon\": Tx Status: {receiptForCreateRandomAnimalFunctionCall.Status.Value}");
                Console.WriteLine("");
                receiptForCreateRandomAnimalFunctionCall = await service.CreateRandomAnimalRequestAndWaitForReceiptAsync(new AnimalInCubators.Contracts.AnimalIncubators_prc1.ContractDefinition.CreateRandomAnimalFunction() { Name = "Rheagal", Gas = 400000 });
                Console.WriteLine($"Finished storing an animal named \"Rheagal\": Tx Hash: {receiptForCreateRandomAnimalFunctionCall.TransactionHash}");
                Console.WriteLine($"Finished storing an animal named \"Rheagal\": Tx Status: {receiptForCreateRandomAnimalFunctionCall.Status.Value}");
                Console.WriteLine("");
                receiptForCreateRandomAnimalFunctionCall = await service.CreateRandomAnimalRequestAndWaitForReceiptAsync(new AnimalInCubators.Contracts.AnimalIncubators_prc1.ContractDefinition.CreateRandomAnimalFunction() { Name = "Viserion", Gas = 400000 });
                Console.WriteLine($"Finished storing an animal named \"Viserion\": Tx Hash: {receiptForCreateRandomAnimalFunctionCall.TransactionHash}");
                Console.WriteLine($"Finished storing an animal named \"Viserion\": Tx Status: {receiptForCreateRandomAnimalFunctionCall.Status.Value}");
                Console.WriteLine("");

                Console.WriteLine("Calling the function showAnimalByIndex() (retrieving animal \"Drogon\", \"Rheagal\", \"Viserion\") ...");
                var ValueFromShowAnimalByIndexFunctionCall = await service.ShowAnimalByIndexQueryAsync(new AnimalInCubators.Contracts.AnimalIncubators_prc1.ContractDefinition.ShowAnimalByIndexFunction() { Index = 0, Gas = 400000 });
                Console.WriteLine($"Animal Name: {ValueFromShowAnimalByIndexFunctionCall.ReturnValue1}");
                Console.WriteLine($"Animal Dna: {ValueFromShowAnimalByIndexFunctionCall.ReturnValue2}");
                Console.WriteLine("");
                ValueFromShowAnimalByIndexFunctionCall = await service.ShowAnimalByIndexQueryAsync(new AnimalInCubators.Contracts.AnimalIncubators_prc1.ContractDefinition.ShowAnimalByIndexFunction() { Index = 1, Gas = 400000 });
                Console.WriteLine($"Animal Name: {ValueFromShowAnimalByIndexFunctionCall.ReturnValue1}");
                Console.WriteLine($"Animal Dna: {ValueFromShowAnimalByIndexFunctionCall.ReturnValue2}");
                Console.WriteLine("");
                ValueFromShowAnimalByIndexFunctionCall = await service.ShowAnimalByIndexQueryAsync(new AnimalInCubators.Contracts.AnimalIncubators_prc1.ContractDefinition.ShowAnimalByIndexFunction() { Index = 2, Gas = 400000 });
                Console.WriteLine($"Animal Name: {ValueFromShowAnimalByIndexFunctionCall.ReturnValue1}");
                Console.WriteLine($"Animal Dna: {ValueFromShowAnimalByIndexFunctionCall.ReturnValue2}");

                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Finished current experiment.");
            Console.ReadLine();
        }

        static async Task Experiment2()
        {
            try
            {
                // Setup using the Nethereum public test chain
                var url = "http://testchain.nethereum.com:8545";
                // var privateKey_1 = "0x" + convertBytesToString(Nethereum.Signer.EthECKey.GenerateKey().GetPrivateKeyAsBytes());
                // var privateKey_2 = "0x" + convertBytesToString(Nethereum.Signer.EthECKey.GenerateKey().GetPrivateKeyAsBytes());
                // var privateKey_3 = "0x" + convertBytesToString(Nethereum.Signer.EthECKey.GenerateKey().GetPrivateKeyAsBytes());
                var privateKey_1 = "0x7580e7fb49df1c861f0050fae31c2224c6aba908e116b8da44ee8cd927b990b0";
                var privateKey_2 = "0xd7325de5c2c1cf0009fac77d3d04a9c004b038883446b065871bc3e831dcd098";
                var privateKey_3 = "0x348ce564d427a3311b6536bbcff9390d69395b06ed6c486954e971d960fe8709";
                var account_1 = new Account(privateKey_1);
                var web3_1 = new Web3(account_1, url);
                var account_2 = new Account(privateKey_2);
                var web3_2 = new Web3(account_2, url);
                var account_3 = new Account(privateKey_3);
                var web3_3 = new Web3(account_3, url);
                var transferTo_2 = web3_1.Eth.GetEtherTransferService();
                var transferTo_3 = web3_1.Eth.GetEtherTransferService();
                var receiptForTransfer = await transferTo_2.TransferEtherAsync(account_2.Address, 13903104);
                receiptForTransfer = await transferTo_3.TransferEtherAsync(account_3.Address, 13903104);
                var balance_1 = await web3_1.Eth.GetBalance.SendRequestAsync(account_1.Address);
                var balance_2 = await web3_2.Eth.GetBalance.SendRequestAsync(account_2.Address);
                var balance_3 = await web3_3.Eth.GetBalance.SendRequestAsync(account_3.Address);
                

                Console.WriteLine("Deploying and getting service for 3 different accounts...");
                var deployment_1 = new AnimalFeedingDeployment();
                var receipt_1 = await AnimalFeedingService.DeployContractAndWaitForReceiptAsync(web3_1, deployment_1);
                var service_1 = new AnimalFeedingService(web3_1, receipt_1.ContractAddress);
                Console.WriteLine($"Address of account 1: {account_1.Address}");
                Console.WriteLine($"Contract Deployment Tx Status of account 1: {receipt_1.Status.Value}");
                Console.WriteLine($"Contract Address of account 1: {service_1.ContractHandler.ContractAddress}");
                Console.WriteLine("");
                var deployment_2 = new AnimalFeedingDeployment();
                var receipt_2 = await AnimalFeedingService.DeployContractAndWaitForReceiptAsync(web3_2, deployment_2);
                var service_2 = new AnimalFeedingService(web3_2, receipt_2.ContractAddress);
                Console.WriteLine($"Address of account 2: {account_2.Address}");
                Console.WriteLine($"Contract Deployment Tx Status of account 2: {receipt_2.Status.Value}");
                Console.WriteLine($"Contract Address of account 2: {service_2.ContractHandler.ContractAddress}");
                Console.WriteLine("");
                var deployment_3 = new AnimalFeedingDeployment();
                var receipt_3 = await AnimalFeedingService.DeployContractAndWaitForReceiptAsync(web3_3, deployment_3);
                var service_3 = new AnimalFeedingService(web3_3, receipt_3.ContractAddress);
                Console.WriteLine($"Address of account 3: {account_3.Address}");
                Console.WriteLine($"Contract Deployment Tx Status of account 3: {receipt_3.Status.Value}");
                Console.WriteLine($"Contract Address of account 3: {service_3.ContractHandler.ContractAddress}");
                Console.WriteLine("");


                Console.WriteLine("Creating animal \"Drogon\", \"Rheagal\", \"Viserion\"...");
                var receiptForCreateRandomAnimalFunctionCall = await service_1.CreateRandomAnimalRequestAndWaitForReceiptAsync(new AnimalInCubators.Contracts.AnimalFeeding.ContractDefinition.CreateRandomAnimalFunction() { Name = "Drogon", Gas = 400000 });
                Console.WriteLine($"Finished storing an animal named \"Drogon\" for account 1: Tx Hash: {receiptForCreateRandomAnimalFunctionCall.TransactionHash}");
                Console.WriteLine($"Finished storing an animal named \"Drogon\" for account 1: Tx Status: {receiptForCreateRandomAnimalFunctionCall.Status.Value}");
                Console.WriteLine("");
                receiptForCreateRandomAnimalFunctionCall = await service_2.CreateRandomAnimalRequestAndWaitForReceiptAsync(new AnimalInCubators.Contracts.AnimalFeeding.ContractDefinition.CreateRandomAnimalFunction() { Name = "Rheagal", Gas = 400000 });
                Console.WriteLine($"Finished storing an animal named \"Rheagal\" for account 2: Tx Hash: {receiptForCreateRandomAnimalFunctionCall.TransactionHash}");
                Console.WriteLine($"Finished storing an animal named \"Rheagal\" for account 2: Tx Status: {receiptForCreateRandomAnimalFunctionCall.Status.Value}");
                Console.WriteLine("");
                receiptForCreateRandomAnimalFunctionCall = await service_3.CreateRandomAnimalRequestAndWaitForReceiptAsync(new AnimalInCubators.Contracts.AnimalFeeding.ContractDefinition.CreateRandomAnimalFunction() { Name = "Viserion", Gas = 400000 });
                Console.WriteLine($"Finished storing an animal named \"Viserion\" for account 3: Tx Hash: {receiptForCreateRandomAnimalFunctionCall.TransactionHash}");
                Console.WriteLine($"Finished storing an animal named \"Viserion\" for account 3: Tx Status: {receiptForCreateRandomAnimalFunctionCall.Status.Value}");
                Console.WriteLine("");


                Console.WriteLine("Feeding animal named \"Drogon\" for account 1 and showing its updated infomation...");
                var ValueFromShowAnimalByIndexFunctionCall = await service_1.ShowAnimalByIndexQueryAsync(new AnimalInCubators.Contracts.AnimalFeeding.ContractDefinition.ShowAnimalByIndexFunction() { Index = 0, Gas = 400000 });
                Console.WriteLine($"Dna of \"Drogon\" before feeding: {ValueFromShowAnimalByIndexFunctionCall.ReturnValue2}");
                Console.WriteLine($"Owner address of \"Drogon\" before feeding: {ValueFromShowAnimalByIndexFunctionCall.ReturnValue3}");
                var receiptForFeedOnFoodFunctionCall = await service_1.FeedOnFoodRequestAndWaitForReceiptAsync(new AnimalInCubators.Contracts.AnimalFeeding.ContractDefinition.FeedOnFoodFunction() { AnimalId = 0, FoodName = "apple", Gas = 400000 } );
                Console.WriteLine($"Finished feeding an animal named \"Drogon\" with food named \"apple\" for account 1: Tx Hash: {receiptForCreateRandomAnimalFunctionCall.TransactionHash}");
                Console.WriteLine($"Finished feeding an animal named \"Drogon\" with food named \"apple\" for account 1: Tx Status: {receiptForCreateRandomAnimalFunctionCall.Status.Value}");
                ValueFromShowAnimalByIndexFunctionCall = await service_1.ShowAnimalByIndexQueryAsync(new AnimalInCubators.Contracts.AnimalFeeding.ContractDefinition.ShowAnimalByIndexFunction() { Index = 1, Gas = 400000 });
                Console.WriteLine($"New name of \"Drogon\" after feeding: {ValueFromShowAnimalByIndexFunctionCall.ReturnValue1}");
                Console.WriteLine($"Dna of \"Drogon\" after feeding: {ValueFromShowAnimalByIndexFunctionCall.ReturnValue2}");
                Console.WriteLine($"Owner address of \"Drogon\" after feeding: {ValueFromShowAnimalByIndexFunctionCall.ReturnValue3}");
                Console.WriteLine("");


                Console.WriteLine("The other two animals' information:");
                ValueFromShowAnimalByIndexFunctionCall = await service_2.ShowAnimalByIndexQueryAsync(new AnimalInCubators.Contracts.AnimalFeeding.ContractDefinition.ShowAnimalByIndexFunction() { Index = 0, Gas = 400000 });
                Console.WriteLine($"Name: {ValueFromShowAnimalByIndexFunctionCall.ReturnValue1}");
                Console.WriteLine($"Dna: {ValueFromShowAnimalByIndexFunctionCall.ReturnValue2}");
                Console.WriteLine($"Owner: {ValueFromShowAnimalByIndexFunctionCall.ReturnValue3}");
                Console.WriteLine("");
                ValueFromShowAnimalByIndexFunctionCall = await service_3.ShowAnimalByIndexQueryAsync(new AnimalInCubators.Contracts.AnimalFeeding.ContractDefinition.ShowAnimalByIndexFunction() { Index = 0, Gas = 400000 });
                Console.WriteLine($"Name: {ValueFromShowAnimalByIndexFunctionCall.ReturnValue1}");
                Console.WriteLine($"Dna: {ValueFromShowAnimalByIndexFunctionCall.ReturnValue2}");
                Console.WriteLine($"Owner: {ValueFromShowAnimalByIndexFunctionCall.ReturnValue3}");
                Console.WriteLine("");
                
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Finished current experiment.");
            Console.ReadLine();
        }

        static async Task Experiment3()
        {
            try
            {
                var url = "http://testchain.nethereum.com:8545";
                var privateKey = "0x7580e7fb49df1c861f0050fae31c2224c6aba908e116b8da44ee8cd927b990b0";
                var account = new Account(privateKey);
                var web3 = new Web3(account, url);

                Console.WriteLine("Deploying...");
                var deployment = new AnimalHelperDeployment();
                var receipt = await AnimalHelperService.DeployContractAndWaitForReceiptAsync(web3, deployment);
                var service = new AnimalHelperService(web3, receipt.ContractAddress);
                Console.WriteLine($"Contract Deployment Tx Status: {receipt.Status.Value}");
                Console.WriteLine($"Contract Address: {service.ContractHandler.ContractAddress}");
                Console.WriteLine("");


                Console.WriteLine("Showing Food cooldown time...");
                Console.WriteLine("Creating animal \"Drogon\" and feeding...");

                Console.WriteLine($"At time: {DateTime.Now}");
                var receiptForCreateRandomAnimalFunctionCall = await service.CreateRandomAnimalRequestAndWaitForReceiptAsync(new AnimalInCubators.Contracts.AnimalHelper.ContractDefinition.CreateRandomAnimalFunction() { Name = "Drogon", Gas = 400000 });
                Console.WriteLine($"Finished storing an animal named \"Drogon\": Tx Hash: {receiptForCreateRandomAnimalFunctionCall.TransactionHash}");
                Console.WriteLine($"Finished storing an animal named \"Drogon\": Tx Status: {receiptForCreateRandomAnimalFunctionCall.Status.Value}");
                Console.WriteLine("");
                
                Console.WriteLine($"Feeding for the first time at time: {DateTime.Now}");
                var receiptForFeedOnFoodFunctionCall = await service.FeedOnFoodRequestAndWaitForReceiptAsync(new AnimalInCubators.Contracts.AnimalHelper.ContractDefinition.FeedOnFoodFunction() { AnimalId = 0, FoodName = "apple", Gas = 400000 } );
                Console.WriteLine($"Finished feeding an animal named \"Drogon\" with food named \"apple\": Tx Hash: {receiptForFeedOnFoodFunctionCall.TransactionHash}");
                Console.WriteLine($"Finished feeding an animal named \"Drogon\" with food named \"apple\": Tx Status: {receiptForFeedOnFoodFunctionCall.Status.Value}");
                Console.WriteLine("");

                Console.WriteLine($"Feeding for the second time at time: {DateTime.Now}");
                receiptForFeedOnFoodFunctionCall = await service.FeedOnFoodRequestAndWaitForReceiptAsync(new AnimalInCubators.Contracts.AnimalHelper.ContractDefinition.FeedOnFoodFunction() { AnimalId = 0, FoodName = "banana", Gas = 400000 } );
                Console.WriteLine($"Finished feeding an animal named \"Drogon\" with food named \"banana\": Tx Hash: {receiptForFeedOnFoodFunctionCall.TransactionHash}");
                Console.WriteLine($"Finished feeding an animal named \"Drogon\" with food named \"banana\": Tx Status: {receiptForFeedOnFoodFunctionCall.Status.Value}");
                Console.WriteLine("");

                Console.WriteLine($"Feeding for the third time at time: {DateTime.Now}");
                receiptForFeedOnFoodFunctionCall = await service.FeedOnFoodRequestAndWaitForReceiptAsync(new AnimalInCubators.Contracts.AnimalHelper.ContractDefinition.FeedOnFoodFunction() { AnimalId = 0, FoodName = "banana", Gas = 400000 } );
                Console.WriteLine($"Finished feeding an animal named \"Drogon\" with food named \"banana\": Tx Hash: {receiptForFeedOnFoodFunctionCall.TransactionHash}");
                Console.WriteLine($"Finished feeding an animal named \"Drogon\" with food named \"banana\": Tx Status: {receiptForFeedOnFoodFunctionCall.Status.Value}");
                Console.WriteLine("");

                Console.WriteLine($"Feeding for the fourth time at time: {DateTime.Now}");
                receiptForFeedOnFoodFunctionCall = await service.FeedOnFoodRequestAndWaitForReceiptAsync(new AnimalInCubators.Contracts.AnimalHelper.ContractDefinition.FeedOnFoodFunction() { AnimalId = 0, FoodName = "banana", Gas = 400000 } );
                Console.WriteLine($"Finished feeding an animal named \"Drogon\" with food named \"banana\": Tx Hash: {receiptForFeedOnFoodFunctionCall.TransactionHash}");
                Console.WriteLine($"Finished feeding an animal named \"Drogon\" with food named \"banana\": Tx Status: {receiptForFeedOnFoodFunctionCall.Status.Value}");
                Console.WriteLine("");

                Console.WriteLine($"Trying creating another animal for the current account...");
                receiptForCreateRandomAnimalFunctionCall = await service.CreateRandomAnimalRequestAndWaitForReceiptAsync(new AnimalInCubators.Contracts.AnimalHelper.ContractDefinition.CreateRandomAnimalFunction() { Name = "Drogon", Gas = 400000 });
                Console.WriteLine($"Finished storing an animal named \"ddd\": Tx Hash: {receiptForCreateRandomAnimalFunctionCall.TransactionHash}");
                Console.WriteLine($"Finished storing an animal named \"ddd\": Tx Status: {receiptForCreateRandomAnimalFunctionCall.Status.Value}");
                Console.WriteLine("");
                
                Console.WriteLine("Traversing the animals of current account...");
                var receiptForGetAnimalByOwnerFunctionCall = await service.GetAnimalsByOwnerQueryAsync(new GetAnimalsByOwnerFunction() { Owner = account.Address, Gas = 400000 } );
                var count = 1;
                foreach (var AnimalId in receiptForGetAnimalByOwnerFunctionCall) {
                    Console.WriteLine($"Id of the {count}-th animal of current account is {AnimalId}");
                    count ++;
                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Finished current experiment.");
            Console.ReadLine();
        }

        // static string convertBytesToString(byte[] bytes)
        // {
        //    StringBuilder builder = new();
        //     for (int i = 0; i < bytes.Length; i++)
        //     {
        //         builder.Append(bytes[i].ToString("x2"));
        //     } 
        //     return builder.ToString();
        // }
    }
}

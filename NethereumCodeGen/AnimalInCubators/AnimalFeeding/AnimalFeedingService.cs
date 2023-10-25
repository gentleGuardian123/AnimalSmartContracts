using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using AnimalInCubators.Contracts.AnimalFeeding.ContractDefinition;

namespace AnimalInCubators.Contracts.AnimalFeeding
{
    public partial class AnimalFeedingService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, AnimalFeedingDeployment animalFeedingDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<AnimalFeedingDeployment>().SendRequestAndWaitForReceiptAsync(animalFeedingDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, AnimalFeedingDeployment animalFeedingDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<AnimalFeedingDeployment>().SendRequestAsync(animalFeedingDeployment);
        }

        public static async Task<AnimalFeedingService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, AnimalFeedingDeployment animalFeedingDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, animalFeedingDeployment, cancellationTokenSource);
            return new AnimalFeedingService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public AnimalFeedingService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public AnimalFeedingService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> FeedAndGrowRequestAsync(FeedAndGrowFunction feedAndGrowFunction)
        {
             return ContractHandler.SendRequestAsync(feedAndGrowFunction);
        }

        public Task<TransactionReceipt> FeedAndGrowRequestAndWaitForReceiptAsync(FeedAndGrowFunction feedAndGrowFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(feedAndGrowFunction, cancellationToken);
        }

        public Task<string> FeedAndGrowRequestAsync(BigInteger animalId, BigInteger targetDna)
        {
            var feedAndGrowFunction = new FeedAndGrowFunction();
                feedAndGrowFunction.AnimalId = animalId;
                feedAndGrowFunction.TargetDna = targetDna;
            
             return ContractHandler.SendRequestAsync(feedAndGrowFunction);
        }

        public Task<TransactionReceipt> FeedAndGrowRequestAndWaitForReceiptAsync(BigInteger animalId, BigInteger targetDna, CancellationTokenSource cancellationToken = null)
        {
            var feedAndGrowFunction = new FeedAndGrowFunction();
                feedAndGrowFunction.AnimalId = animalId;
                feedAndGrowFunction.TargetDna = targetDna;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(feedAndGrowFunction, cancellationToken);
        }

        public Task<string> FeedOnFoodRequestAsync(FeedOnFoodFunction feedOnFoodFunction)
        {
             return ContractHandler.SendRequestAsync(feedOnFoodFunction);
        }

        public Task<TransactionReceipt> FeedOnFoodRequestAndWaitForReceiptAsync(FeedOnFoodFunction feedOnFoodFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(feedOnFoodFunction, cancellationToken);
        }

        public Task<string> FeedOnFoodRequestAsync(BigInteger animalId, string foodName)
        {
            var feedOnFoodFunction = new FeedOnFoodFunction();
                feedOnFoodFunction.AnimalId = animalId;
                feedOnFoodFunction.FoodName = foodName;
            
             return ContractHandler.SendRequestAsync(feedOnFoodFunction);
        }

        public Task<TransactionReceipt> FeedOnFoodRequestAndWaitForReceiptAsync(BigInteger animalId, string foodName, CancellationTokenSource cancellationToken = null)
        {
            var feedOnFoodFunction = new FeedOnFoodFunction();
                feedOnFoodFunction.AnimalId = animalId;
                feedOnFoodFunction.FoodName = foodName;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(feedOnFoodFunction, cancellationToken);
        }

        public Task<AnimalsOutputDTO> AnimalsQueryAsync(AnimalsFunction animalsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<AnimalsFunction, AnimalsOutputDTO>(animalsFunction, blockParameter);
        }

        public Task<AnimalsOutputDTO> AnimalsQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var animalsFunction = new AnimalsFunction();
                animalsFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryDeserializingToObjectAsync<AnimalsFunction, AnimalsOutputDTO>(animalsFunction, blockParameter);
        }

        public Task<string> CreateRandomAnimalRequestAsync(CreateRandomAnimalFunction createRandomAnimalFunction)
        {
             return ContractHandler.SendRequestAsync(createRandomAnimalFunction);
        }

        public Task<TransactionReceipt> CreateRandomAnimalRequestAndWaitForReceiptAsync(CreateRandomAnimalFunction createRandomAnimalFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createRandomAnimalFunction, cancellationToken);
        }

        public Task<string> CreateRandomAnimalRequestAsync(string name)
        {
            var createRandomAnimalFunction = new CreateRandomAnimalFunction();
                createRandomAnimalFunction.Name = name;
            
             return ContractHandler.SendRequestAsync(createRandomAnimalFunction);
        }

        public Task<TransactionReceipt> CreateRandomAnimalRequestAndWaitForReceiptAsync(string name, CancellationTokenSource cancellationToken = null)
        {
            var createRandomAnimalFunction = new CreateRandomAnimalFunction();
                createRandomAnimalFunction.Name = name;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createRandomAnimalFunction, cancellationToken);
        }

        public Task<ShowAnimalByIndexOutputDTO> ShowAnimalByIndexQueryAsync(ShowAnimalByIndexFunction showAnimalByIndexFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ShowAnimalByIndexFunction, ShowAnimalByIndexOutputDTO>(showAnimalByIndexFunction, blockParameter);
        }

        public Task<ShowAnimalByIndexOutputDTO> ShowAnimalByIndexQueryAsync(BigInteger index, BlockParameter blockParameter = null)
        {
            var showAnimalByIndexFunction = new ShowAnimalByIndexFunction();
                showAnimalByIndexFunction.Index = index;
            
            return ContractHandler.QueryDeserializingToObjectAsync<ShowAnimalByIndexFunction, ShowAnimalByIndexOutputDTO>(showAnimalByIndexFunction, blockParameter);
        }

        public Task<string> AnimalToOwnerQueryAsync(AnimalToOwnerFunction animalToOwnerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AnimalToOwnerFunction, string>(animalToOwnerFunction, blockParameter);
        }

        
        public Task<string> AnimalToOwnerQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var animalToOwnerFunction = new AnimalToOwnerFunction();
                animalToOwnerFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<AnimalToOwnerFunction, string>(animalToOwnerFunction, blockParameter);
        }
    }
}

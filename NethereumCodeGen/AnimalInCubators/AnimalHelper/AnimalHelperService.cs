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
using AnimalInCubators.Contracts.AnimalHelper.ContractDefinition;

namespace AnimalInCubators.Contracts.AnimalHelper
{
    public partial class AnimalHelperService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, AnimalHelperDeployment animalHelperDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<AnimalHelperDeployment>().SendRequestAndWaitForReceiptAsync(animalHelperDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, AnimalHelperDeployment animalHelperDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<AnimalHelperDeployment>().SendRequestAsync(animalHelperDeployment);
        }

        public static async Task<AnimalHelperService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, AnimalHelperDeployment animalHelperDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, animalHelperDeployment, cancellationTokenSource);
            return new AnimalHelperService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public AnimalHelperService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public AnimalHelperService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
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

        public Task<string> ChangeDnaRequestAsync(ChangeDnaFunction changeDnaFunction)
        {
             return ContractHandler.SendRequestAsync(changeDnaFunction);
        }

        public Task<TransactionReceipt> ChangeDnaRequestAndWaitForReceiptAsync(ChangeDnaFunction changeDnaFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(changeDnaFunction, cancellationToken);
        }

        public Task<string> ChangeDnaRequestAsync(BigInteger animalId, BigInteger newDna)
        {
            var changeDnaFunction = new ChangeDnaFunction();
                changeDnaFunction.AnimalId = animalId;
                changeDnaFunction.NewDna = newDna;
            
             return ContractHandler.SendRequestAsync(changeDnaFunction);
        }

        public Task<TransactionReceipt> ChangeDnaRequestAndWaitForReceiptAsync(BigInteger animalId, BigInteger newDna, CancellationTokenSource cancellationToken = null)
        {
            var changeDnaFunction = new ChangeDnaFunction();
                changeDnaFunction.AnimalId = animalId;
                changeDnaFunction.NewDna = newDna;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(changeDnaFunction, cancellationToken);
        }

        public Task<List<BigInteger>> GetAnimalsByOwnerQueryAsync(GetAnimalsByOwnerFunction getAnimalsByOwnerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetAnimalsByOwnerFunction, List<BigInteger>>(getAnimalsByOwnerFunction, blockParameter);
        }

        
        public Task<List<BigInteger>> GetAnimalsByOwnerQueryAsync(string owner, BlockParameter blockParameter = null)
        {
            var getAnimalsByOwnerFunction = new GetAnimalsByOwnerFunction();
                getAnimalsByOwnerFunction.Owner = owner;
            
            return ContractHandler.QueryAsync<GetAnimalsByOwnerFunction, List<BigInteger>>(getAnimalsByOwnerFunction, blockParameter);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
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

        public Task<string> ChangeNameRequestAsync(ChangeNameFunction changeNameFunction)
        {
             return ContractHandler.SendRequestAsync(changeNameFunction);
        }

        public Task<TransactionReceipt> ChangeNameRequestAndWaitForReceiptAsync(ChangeNameFunction changeNameFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(changeNameFunction, cancellationToken);
        }

        public Task<string> ChangeNameRequestAsync(BigInteger animalId, string newName)
        {
            var changeNameFunction = new ChangeNameFunction();
                changeNameFunction.AnimalId = animalId;
                changeNameFunction.NewName = newName;
            
             return ContractHandler.SendRequestAsync(changeNameFunction);
        }

        public Task<TransactionReceipt> ChangeNameRequestAndWaitForReceiptAsync(BigInteger animalId, string newName, CancellationTokenSource cancellationToken = null)
        {
            var changeNameFunction = new ChangeNameFunction();
                changeNameFunction.AnimalId = animalId;
                changeNameFunction.NewName = newName;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(changeNameFunction, cancellationToken);
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

        public Task<string> TransferOwnershipRequestAsync(TransferOwnershipFunction transferOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(TransferOwnershipFunction transferOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<string> TransferOwnershipRequestAsync(string newOwner)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(string newOwner, CancellationTokenSource cancellationToken = null)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }
    }
}

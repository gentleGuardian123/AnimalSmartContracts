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
using AnimalInCubators.Contracts.AnimalIncubators_prc1.ContractDefinition;

namespace AnimalInCubators.Contracts.AnimalIncubators_prc1
{
    public partial class AnimalincubatorsPrc1Service
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, AnimalincubatorsPrc1Deployment animalincubatorsPrc1Deployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<AnimalincubatorsPrc1Deployment>().SendRequestAndWaitForReceiptAsync(animalincubatorsPrc1Deployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, AnimalincubatorsPrc1Deployment animalincubatorsPrc1Deployment)
        {
            return web3.Eth.GetContractDeploymentHandler<AnimalincubatorsPrc1Deployment>().SendRequestAsync(animalincubatorsPrc1Deployment);
        }

        public static async Task<AnimalincubatorsPrc1Service> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, AnimalincubatorsPrc1Deployment animalincubatorsPrc1Deployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, animalincubatorsPrc1Deployment, cancellationTokenSource);
            return new AnimalincubatorsPrc1Service(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public AnimalincubatorsPrc1Service(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public AnimalincubatorsPrc1Service(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
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
    }
}

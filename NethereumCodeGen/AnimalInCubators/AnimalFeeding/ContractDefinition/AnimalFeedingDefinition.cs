using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace AnimalInCubators.Contracts.AnimalFeeding.ContractDefinition
{


    public partial class AnimalFeedingDeployment : AnimalFeedingDeploymentBase
    {
        public AnimalFeedingDeployment() : base(BYTECODE) { }
        public AnimalFeedingDeployment(string byteCode) : base(byteCode) { }
    }

    public class AnimalFeedingDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60806040526010600055662386f26fc1000060015534801561002057600080fd5b506109c8806100306000396000f3006080604052600436106100775763ffffffff7c01000000000000000000000000000000000000000000000000000000006000350416630ed6722d811461007c5780632f1303a314610099578063998dd3ca146100f75780639abfb23e1461018e578063a767d7af146101e7578063d81c513a146102b1575b600080fd5b34801561008857600080fd5b506100976004356024356102f2565b005b3480156100a557600080fd5b5060408051602060046024803582810135601f81018590048502860185019096528585526100979583359536956044949193909101919081908401838280828437509497506103b79650505050505050565b34801561010357600080fd5b5061010f6004356103d3565b6040518080602001838152602001828103825284818151815260200191508051906020019080838360005b8381101561015257818101518382015260200161013a565b50505050905090810190601f16801561017f5780820380516001836020036101000a031916815260200191505b50935050505060405180910390f35b34801561019a57600080fd5b506040805160206004803580820135601f81018490048402850184019095528484526100979436949293602493928401919081908401838280828437509497506104879650505050505050565b3480156101f357600080fd5b506101ff6004356104ba565b60405180806020018481526020018373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001828103825285818151815260200191508051906020019080838360005b8381101561027457818101518382015260200161025c565b50505050905090810190601f1680156102a15780820380516001836020036101000a031916815260200191505b5094505050505060405180910390f35b3480156102bd57600080fd5b506102c96004356105c1565b6040805173ffffffffffffffffffffffffffffffffffffffff9092168252519081900360200190f35b600082815260036020526040812054819073ffffffffffffffffffffffffffffffffffffffff16331461032457600080fd5b600280548590811061033257fe5b906000526020600020906002020191506001548381151561034f57fe5b06925060028383600101540181151561036457fe5b04905060648106810360630190506103b16040805190810160405280600681526020017f4e6f2d6f6e650000000000000000000000000000000000000000000000000000815250826105e9565b50505050565b60006103c282610754565b90506103ce83826102f2565b505050565b60028054829081106103e157fe5b60009182526020918290206002918202018054604080516001831615610100026000190190921693909304601f8101859004850282018501909352828152909350918391908301828280156104775780601f1061044c57610100808354040283529160200191610477565b820191906000526020600020905b81548152906001019060200180831161045a57829003601f168201915b5050505050908060010154905082565b33600090815260046020526040812054156104a157600080fd5b6104aa82610820565b90506104b682826105e9565b5050565b60606000806002848154811015156104ce57fe5b90600052602060002090600202016000016002858154811015156104ee57fe5b600091825260208083206002928302016001908101548985526003835260409485902054865486516101009482161594909402600019011694909404601f81018490048402830184019095528482529373ffffffffffffffffffffffffffffffffffffffff9093169290918591908301828280156105ad5780601f10610582576101008083540402835291602001916105ad565b820191906000526020600020905b81548152906001019060200180831161059057829003601f168201915b505050505092509250925092509193909250565b60036020526000908152604090205473ffffffffffffffffffffffffffffffffffffffff1681565b60408051808201909152828152602080820183905260028054600181810180845560008481528651805191979396929593949093027f405787fa12a823e0f2b7631cc41b3ba8828b3321ca811111fa75cd3aa3bb5ace019261064f928492910190610901565b50602091820151600191820155929091036000818152600383526040808220805473ffffffffffffffffffffffffffffffffffffffff19163390811790915582526004845280822080549095019094558351828152938401869052606084840181815288519186019190915287519295507f07be46eb2dba0b4dd932cd8c8cf7a4471478b8e52413bb8e9e88580596866431948694899489949293926080850192870191908190849084905b838110156107135781810151838201526020016106fb565b50505050905090810190601f1680156107405780820380516001836020036101000a031916815260200191505b5094505050505060405180910390a1505050565b600080826040516020018082805190602001908083835b6020831061078a5780518252601f19909201916020918201910161076b565b6001836020036101000a0380198251168184511680821785525050505050509050019150506040516020818303038152906040526040518082805190602001908083835b602083106107ed5780518252601f1990920191602091820191016107ce565b5181516020939093036101000a600019018019909116921691909117905260405192018290039091209695505050505050565b600080826040516020018082805190602001908083835b602083106108565780518252601f199092019160209182019101610837565b6001836020036101000a0380198251168184511680821785525050505050509050019150506040516020818303038152906040526040518082805190602001908083835b602083106108b95780518252601f19909201916020918201910161089a565b6001836020036101000a0380198251168184511680821785525050505050509050019150506040518091039020600190049050600154818115156108f957fe5b069392505050565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f1061094257805160ff191683800117855561096f565b8280016001018555821561096f579182015b8281111561096f578251825591602001919060010190610954565b5061097b92915061097f565b5090565b61099991905b8082111561097b5760008155600101610985565b905600a165627a7a72305820ed141e4be4348c82b1a0f31514d247d2e92753b850c08f03558f3aa4509f74c60029";
        public AnimalFeedingDeploymentBase() : base(BYTECODE) { }
        public AnimalFeedingDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class FeedAndGrowFunction : FeedAndGrowFunctionBase { }

    [Function("feedAndGrow")]
    public class FeedAndGrowFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_animalId", 1)]
        public virtual BigInteger AnimalId { get; set; }
        [Parameter("uint256", "_targetDna", 2)]
        public virtual BigInteger TargetDna { get; set; }
    }

    public partial class FeedOnFoodFunction : FeedOnFoodFunctionBase { }

    [Function("feedOnFood")]
    public class FeedOnFoodFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_animalId", 1)]
        public virtual BigInteger AnimalId { get; set; }
        [Parameter("string", "_foodName", 2)]
        public virtual string FoodName { get; set; }
    }

    public partial class AnimalsFunction : AnimalsFunctionBase { }

    [Function("animals", typeof(AnimalsOutputDTO))]
    public class AnimalsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class CreateRandomAnimalFunction : CreateRandomAnimalFunctionBase { }

    [Function("createRandomAnimal")]
    public class CreateRandomAnimalFunctionBase : FunctionMessage
    {
        [Parameter("string", "_name", 1)]
        public virtual string Name { get; set; }
    }

    public partial class ShowAnimalByIndexFunction : ShowAnimalByIndexFunctionBase { }

    [Function("showAnimalByIndex", typeof(ShowAnimalByIndexOutputDTO))]
    public class ShowAnimalByIndexFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_index", 1)]
        public virtual BigInteger Index { get; set; }
    }

    public partial class AnimalToOwnerFunction : AnimalToOwnerFunctionBase { }

    [Function("animalToOwner", "address")]
    public class AnimalToOwnerFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class NewAnimalEventDTO : NewAnimalEventDTOBase { }

    [Event("NewAnimal")]
    public class NewAnimalEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "animalId", 1, false )]
        public virtual BigInteger AnimalId { get; set; }
        [Parameter("string", "name", 2, false )]
        public virtual string Name { get; set; }
        [Parameter("uint256", "dna", 3, false )]
        public virtual BigInteger Dna { get; set; }
    }





    public partial class AnimalsOutputDTO : AnimalsOutputDTOBase { }

    [FunctionOutput]
    public class AnimalsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "name", 1)]
        public virtual string Name { get; set; }
        [Parameter("uint256", "dna", 2)]
        public virtual BigInteger Dna { get; set; }
    }



    public partial class ShowAnimalByIndexOutputDTO : ShowAnimalByIndexOutputDTOBase { }

    [FunctionOutput]
    public class ShowAnimalByIndexOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
        [Parameter("uint256", "", 2)]
        public virtual BigInteger ReturnValue2 { get; set; }
        [Parameter("address", "", 3)]
        public virtual string ReturnValue3 { get; set; }
    }

    public partial class AnimalToOwnerOutputDTO : AnimalToOwnerOutputDTOBase { }

    [FunctionOutput]
    public class AnimalToOwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }
}
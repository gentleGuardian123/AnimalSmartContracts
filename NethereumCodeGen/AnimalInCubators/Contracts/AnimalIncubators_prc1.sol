pragma solidity ^0.4.26;

contract AnimalIncubators_prc1 {
    uint dnaDigits = 16;
    uint dnaLength = 10 ** dnaDigits;
    
    struct Animal {
        string name;
        uint dna; 
    }
    
    Animal[] public animals;
    
    event NewAnimal(uint animalId, string name, uint dna);
    
    function _createAnimal(string _name, uint _dna) private {
        uint id = animals.push(Animal(_name, _dna)) - 1;
        emit NewAnimal(id, _name, _dna);
    }
    
    function _generateRandomDna(string _str) private view returns (uint) {
        uint rand = uint(keccak256(abi.encodePacked(_str)));
        return rand % dnaLength;
    }
    
    function createRandomAnimal(string _name) public {
        uint randDna = _generateRandomDna(_name);
        _createAnimal(_name, randDna);
    } 

    function showAnimalByIndex(uint _index) public view returns (string, uint){
        return (animals[_index].name, animals[_index].dna);
    }
    
}
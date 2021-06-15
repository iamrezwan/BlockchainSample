using System;
using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;

namespace NethereumSample
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAccountBalance().Wait();
            Console.ReadLine();

            //Transact("privateKey", 110, "0x1231212");
        }

        static async Task GetAccountBalance()
        {

            var web3 = new Web3("http://127.0.0.1:8545");
            var balance = await web3.Eth.GetBalance.SendRequestAsync("0x8D56237abb20f5BCD59602E2fe596690024bd017");
            Console.WriteLine($"Balance in Wei: {balance.Value}");
            var abi = @"[{ ""inputs"": [{ ""internalType"": ""uint256"", ""name"": ""num"", ""type"": ""uint256"" }], ""name"": ""store"", ""outputs"": [], ""stateMutability"": ""nonpayable"", ""type"": ""function"" }, { ""inputs"": [], ""name"": ""retrieve"", ""outputs"": [{ ""internalType"": ""uint256"", ""name"": """", ""type"": ""uint256"" }], ""stateMutability"": ""view"", ""type"": ""function"", ""constant"": true } ]";
            var contract = web3.Eth.GetContract(abi, "0x23c66CACC44fE5C4B7ac2b09c3603f5630E95847");
            var storeFunction = contract.GetFunction("store");
            var retrieveFunction = contract.GetFunction("retrieve");

            int input = 19;
            var result = await storeFunction.SendTransactionAsync("0x8D56237abb20f5BCD59602E2fe596690024bd017", new HexBigInteger(3000000), new HexBigInteger(0), input);

            var retrive = await retrieveFunction.CallAsync<int>();


            var etherAmount = Web3.Convert.FromWei(balance.Value);
            Console.WriteLine($"Balance in Ether: {etherAmount}");

            Console.WriteLine($"Sent input: {input}");
            Console.WriteLine($"Tx Hash: {result}");
            Console.WriteLine($"Retrived data: {retrive}");
        }
        static void Transact(string privateKey, int value, string smartContractPublicAddress)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Threading.Tasks;
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
       
            var web3 = new Web3("https://goerli.infura.io/v3/f0b160aa80f6480f9dde1d0b87d606d3");
            var balance = await web3.Eth.GetBalance.SendRequestAsync("0x6A3b1c554f2C585f255c90c54A6FdB7cE4eA6c03");
            Console.WriteLine($"Balance in Wei: {balance.Value}");

            var etherAmount = Web3.Convert.FromWei(balance.Value);
            Console.WriteLine($"Balance in Ether: {etherAmount}");
        }
        static void Transact(string privateKey, int value, string smartContractPublicAddress)
        {
            throw new NotImplementedException();
        }
    }
}
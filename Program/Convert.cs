using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Nethereum.Contracts.Standards.ERC1155.ContractDefinition;
using System.Net.Security;
using Org.BouncyCastle.Bcpg;
using BitcoinLib.Responses;
using Org.BouncyCastle.Asn1.Mozilla;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace Seed_Checker
{
    class CryptoCompare
    {
        class Network
        {
            public static string GetConvert(string url)
            {
                var client = new RestClient(url);
                var request = new RestRequest("/", Method.Get);
                try
                {
                    var response = client.Execute(request);

                    if (response.IsSuccessful) { return response.Content; }
                    else { return "Error: " + response.ErrorMessage; }
                }
                catch (Exception ex) { return "Earrror: " + ex.Message; }
            }
        }

        public string GetConvertBitcoinUSDT() => Network.GetConvert("https://min-api.cryptocompare.com/data/price?fsym=BTC&tsyms=USDT");
        public string GetConvertEthernumUSDT() => Network.GetConvert("https://min-api.cryptocompare.com/data/price?fsym=ETH&tsyms=USDT");
        public string GetConvertLitecoinUSDT() => Network.GetConvert("https://min-api.cryptocompare.com/data/price?fsym=LTC&tsyms=USDT");
    }
    class USDT
    { 
        public int Money { get; set; }
    }
    class Convert : CryptoCompare
    {
        private float _valueBitcoinUSDT;
        private float _valueLitecoinUSDT;
        private float _valueEthernumUSDT;
        public Convert()
        {
            _valueBitcoinUSDT = ConvertJson(GetConvertBitcoinUSDT());
            _valueLitecoinUSDT = ConvertJson(GetConvertEthernumUSDT());
            _valueEthernumUSDT = ConvertJson(GetConvertLitecoinUSDT());
        }

        private float ConvertJson(string jsonResponse) => JsonConvert.DeserializeObject<USDT>(jsonResponse).Money;

        public float ConvertBitcoinOnUSDT(float balance) => _valueBitcoinUSDT * balance;
        public float ConvertLitecoinOnUSDT(float balance) => _valueLitecoinUSDT * balance;
        public float ConvertEthernumOnUSDT(float balance) => _valueEthernumUSDT * balance;
    }
}


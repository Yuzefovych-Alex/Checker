using BitcoinLib.Responses.SharedComponents;
using NBitcoin.Secp256k1;
using Nethereum.Contracts.Standards.ENS.ETHRegistrarController.ContractDefinition;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Program;
using RestSharp;
using System.Drawing.Printing;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Security.Policy;
using static NBitcoin.Scripting.OutputDescriptor;
//using static Seed_Checker.Checker.Coin;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Text;
using Nethereum.JsonRpc.Client;

namespace Seed_Checker
{
    public class Blockstream
    {
        class Network
        {
            public static string GetBalance(string url, string walletAddress)
            {
                string apiUrl = $"https://blockstream.info/api/address/{walletAddress}";
                var client = new RestClient(apiUrl);
                var request = new RestRequest("/", Method.Get);
                try
                {
                    var response = client.Execute(request);

                    if (response.IsSuccessful) { return response.Content; }
                    else { return "Error: " + response.ErrorMessage; }
                }
                catch (Exception ex) { return "Error: " + ex.Message; }
            }
        }
        public class Mainnet : IBitcoin, ITrustWallet, IExodus, IIamtoken
        {
            private string _url = "https://blockstream.info/api/address/";
            public string GetBalance(string walletAddress) => Network.GetBalance(_url, walletAddress);
        }
        public class Testnet : IBitcoin
        {
            private string _url = "https://blockstream.info/testnet/api/address/";
            public string GetBalance(string walletAddress) => Network.GetBalance(_url, walletAddress);
        }
    }
    public class Blockchair
    {
        class Network
        {
            public static string GetBalance(string url, string walletAddress)
            {
                var client = new RestClient(url + walletAddress);
                var request = new RestRequest("/", Method.Get);
                try
                {
                    var response = client.Execute(request);

                    if (response.IsSuccessful) { return response.Content; }
                    else { return "Error: " + response.ErrorMessage; }
                }
                catch (Exception ex) { return "Error: " + ex.Message; }
            }
        }
        public class Dashboards : IBitcoin
        {
            private string _url = "https://api.blockchair.com/bitcoin/dashboards/address/";
            public string GetBalance(string walletAddress) => Network.GetBalance(_url, walletAddress);
        }
    }
    class Blockchain
    {
        class Network
        {
            public static string GetBalance(string walletAddress)
            {
                string baseUrl = "https://blockchain.info";
                string apiUrl = $"/balance?active={walletAddress}";
                var client = new RestClient(baseUrl);
                var request = new RestRequest(apiUrl);

                try
                {
                    var response = client.Execute(request);

                    if (response.IsSuccessful) { return response.Content; }
                    else { return "Error: " + response.ErrorMessage; }
                }
                catch (Exception ex) { return "Error: " + ex.Message; }
            }
        }
        public class Testnet : IBitcoin
        {
            private string _url = "https://blockchain.info";
            public string GetBalance(string walletAddress) => Network.GetBalance(walletAddress);
        }
    }
    public class Solana : ISolana
    {
        private const string _url = "https://api.devnet.solana.com";
        public string GetBalance(string walletAddress)
        {
            var client = new RestClient(_url);
            var request = new RestRequest("/", Method.Post);

            var jsonRpcPayload = new
            {
                jsonrpc = "2.0",
                id = 1,
                method = "getBalance",
                @params = new[] { walletAddress }
            };

            request.AddBody(jsonRpcPayload);
            request.AddHeader("Content-Type", "application/json");

            try
            {
                var response = client.Execute(request);

                if (response.IsSuccessful) { return response.Content; }
                else { return "Error: " + response.ErrorMessage; }
            }
            catch (Exception ex) { return "Error: " + ex.Message; }
        }
    }
    public class Chainz
    {
        private static string _nameCoin;
        public Chainz(string nameCoin) => _nameCoin = nameCoin;
        class Network
        {
            private const string _apiKey = "";
            private const string _urlGetBlance = "/balance?context=yourExampleString";
            private const string _urlWebsite = "https://rest.cryptoapis.io/blockchain-data/";

            public static string GetBalance(string urlNetwork, string walletAddress)
            {
                var client = new RestClient(_urlWebsite + _nameCoin + "/" + urlNetwork + "/addresses/" + walletAddress + _urlGetBlance);
                var request = new RestRequest("/", Method.Get);
                request.AddHeader("content-type", "application/json");
                request.AddHeader("x-api-key", _apiKey);
                try
                {
                    var response = client.Execute(request);

                    if (response.IsSuccessful) { return response.Content; }
                    else { return "Error Server: " + response.ErrorMessage; }
                }
                catch (Exception ex) { return "Error: " + ex.Message; }
            }
        }

        public class Mainnet : IBitcoin, IEthernum, ILitecoin
        {
            public string GetBalance(string walletAddress) => Network.GetBalance("mainnet", walletAddress);
        }
        public class Testnet : IBitcoin, IEthernum, ILitecoin
        {
            public string GetBalance(string walletAddress) => Network.GetBalance("testnet", walletAddress);
        }
        public class Mordor : IBitcoin, IEthernum, ILitecoin
        {
            public string GetBalance(string walletAddress) => Network.GetBalance("mordor", walletAddress);
        }
        public class Nile : IBitcoin, IEthernum, ILitecoin
        {
            public string GetBalance(string walletAddress) => Network.GetBalance("nile", walletAddress);
        }
        public class Ghostnet : IBitcoin, IEthernum, ILitecoin
        {
            public string GetBalance(string walletAddress) => Network.GetBalance("ghostnet", walletAddress);
        }
        public class Sepolia : IBitcoin, IEthernum, ILitecoin
        {
            public string GetBalance(string walletAddress) => Network.GetBalance("sepolia", walletAddress);
        }
        public class Amoy : IBitcoin, IEthernum, ILitecoin
        {
            public string GetBalance(string walletAddress) => Network.GetBalance("amoy", walletAddress);
        }
        public class Fuji : IBitcoin, IEthernum, ILitecoin
        {
            public string GetBalance(string walletAddress) => Network.GetBalance("fuji", walletAddress);
        }
    }
    class Etherscan
    {
        class Network
        {
            private const string _apiKey = "1J2DBZR67EDR7YT93159KBCHPQW7NK4TP8";
            public static string GetBalance(string urlNetwork, string walletAddress)
            {
                RestClient client = new RestClient(urlNetwork);
                RestRequest request = new RestRequest("/", Method.Get);
                request.AddParameter("module", "account");
                request.AddParameter("action", "balance");
                request.AddParameter("address", walletAddress);
                request.AddParameter("tag", "latest");
                request.AddParameter("apikey", _apiKey);

                try
                {
                    var response = client.Execute(request);

                    if (response.IsSuccessful) { return response.Content; }
                    else { return "Error: " + response.ErrorMessage; }
                }
                catch (Exception ex) { return "Earrror: " + ex.Message; }
            }
        }
        public class Mainnet : IEthernum, IExodus, IIamtoken
        {
            public string GetBalance(string walletAddress) => Network.GetBalance("https://api.etherscan.io/api", walletAddress);
        }
        public class Goerli : IEthernum
        {
            public string GetBalance(string walletAddress) => Network.GetBalance("https://api-sepolia.etherscan.io/api", walletAddress);
        }
        public class Sepolia : IEthernum
        {
            public string GetBalance(string walletAddress) => Network.GetBalance("https://api-holesky.etherscan.io/api", walletAddress);
        }
        public class Optimistic : IEthernum, IMetamask
        {
            public string GetBalance(string walletAddress) => Network.GetBalance("https://api-optimistic.etherscan.io/api", walletAddress);
        }
    }
    class ADM
    {
        // Avalanche
        // Dogechain
        // Mainnet
        class Network
        {
            public static string GetBalance(string url, string id, string walletAddress)
            {

                var client = new RestClient(url);
                var request = new RestRequest("/", Method.Post);

                var jsonRcpPlayoad = new
                {
                    jsonrcp = "2.0",
                    id = id,
                    method = "eth_getBalance",
                    @params = new[] { walletAddress, "latest" }
                };
                request.AddBody(jsonRcpPlayoad);
                request.AddHeader("Content-Type", "application/json");
                try
                {
                    var responce = client.Execute(request);
                    if (responce.IsSuccessful) { return responce.Content; }
                    else { return responce.ErrorMessage; }
                }
                catch (Exception ex) { return ex.Message; }
            }
        }
        public class Avalanche : ILitecoin, IIamtoken, IMetamask
        {
            public string GetBalance(string walletAddress) => Network.GetBalance("https://ava-mainnet.public.blastapi.io/ext/bc/C/rpc", "0", walletAddress);
        }
        public class Mainnet : IEthernum, ITrustWallet, IMetamask
        {
            public string GetBalance(string walletAddress) => Network.GetBalance("https://mainnet.infura.io/v3/d9e95759e16240838802e86a86a7a84b", "1", walletAddress);
        }
    }
    class Arbitrium : IEthernum, IMetamask
    {
        private string _apiKey = "UUGUWWZNGP7YG1581NKNM4X56I1DK1Q4HJ";

        public string GetBalance(string walletAddress)
        {
            var client = new RestClient($"https://api.arbiscan.io/api?module=account&action=balance&address={walletAddress}&tag=latest&apikey={_apiKey}");
            var request = new RestRequest("/", Method.Get);
            try
            {
                var responce = client.Execute(request);
                if (responce.IsSuccessful) { return responce.Content; }
                else { return responce.ErrorMessage; }
            }
            catch (Exception ex) { return ex.Message; }
        }
    }
    class PFC
    {
        // Polygonscan
        // Ftmscan
        // Cronoscan

        class Network
        {
            public static string GetBalance(string apiKey, string url, string walletAddress)
            {
                var client = new RestClient(url);
                var request = new RestRequest("/", Method.Get);

                request.AddParameter("module", "account");
                request.AddParameter("action", "balance");
                request.AddParameter("address", walletAddress);
                request.AddParameter("tag", "latest");
                request.AddParameter("apikey", apiKey);

                try
                {
                    var responce = client.Execute(request);
                    if (responce.IsSuccessful) { return responce.Content; }
                    else { return responce.ErrorMessage; }
                }
                catch (Exception ex) { return ex.Message; }
            }
        }
        public class Polygonscan : IEthernum, ITrustWallet, IMetamask
        {
            private const string _apiKey = "5ARYAP1PMAH7P4RD3U6HPECQEUNIVJX3AU";
            private const string _url = "https://api.polygonscan.com/api";
            public string GetBalance(string walletAddress) => Network.GetBalance(_apiKey, _url, walletAddress);
        }

        public class Ftmscan : ILitecoin, IMetamask
        {
            private const string _url = "https://api.ftmscan.com/api";
            private const string _apiKey = "5XV29741RTRR7VKWWBYQYZW4UEIZM6XHBG";
            public string GetBalance(string walletAddress) => Network.GetBalance(_apiKey, _url, walletAddress);
        }
        public class Cronoscan : ILitecoin, IMetamask
        {
            private const string _url = "https://api.cronoscan.com/api";
            private const string _apiKey = "32KAA8WGXX49U76DUMUGSI3N1DDIBX4ARJ";
            public string GetBalance(string walletAddress) => Network.GetBalance(_apiKey, _url, walletAddress);

        }
    }
    static class Networks
    {
        public static string GetBalance(Func<RestRequest, RestRequest> func, string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest("/", Method.Get);
            try
            {
                var responce = client.Execute(func(request));
                if (responce.IsSuccessful) { return responce.Content; }
                else { return responce.ErrorMessage; }
            }
            catch (Exception ex) { return ex.Message; }
        }

        class Riple : IXRP
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                var jsonBody = new
                {
                    method = "account_info",
                    @params = new[]
                    {
                        new
                        {
                            account = walletAddress,
                            ledger_index = "validated"
                        }
                    }
                };
                request.AddBody(jsonBody);
                request.AddHeader("Content-Type", "application/json");
                return request;
            }, "https://s1.ripple.com:51234");
        }
        class Dogecoin : IDOGE
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://dogechain.info/api/v1/address/balance/{walletAddress}");
        }
        class Thorchain : IRUNE
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://midgard.thorchain.info/v2/accounts/{walletAddress}");
        }
        class Polkadot : IDOT
        {
            private string apiKey = "";
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                request.AddHeader("Authorization", $"Bearer {apiKey}");
                var json = new { address = walletAddress };
                request.AddBody(json);
                request.AddHeader("Content-Type", "application/json");
                return request;
            }, "https://polkadot.api.subscan.io/api/scan/account/tokens");
        }
        class Zcash : IZEC
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.zcha.in/v2/mainnet/accounts/{walletAddress}");
        }
        class Dash : IDASH
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://insight.dash.org/insight-api-dash/addr/{walletAddress}");
        }
        class TRON : ITRX
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://apilist.tronscan.org/api/account?address={walletAddress}");
        }
        class Tezos : IXTZ
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.tzkt.io/v1/accounts/{walletAddress}");
        }
        class Cosmos : IATOM
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://lcd-cosmoshub.blockapsis.com/cosmos/bank/v1beta1/balances/{walletAddress}");
        }
        class Stellar : IXLM
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://horizon.stellar.org/accounts/{walletAddress}");
        }
        class BitcoinCash : IBCH
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.blockchair.com/bitcoin-cash/dashboards/address/{walletAddress}");
        }
        class Filecoin : IFIL
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.filscan.io:8700/v0/account/balance?address={walletAddress}");
        }
        class FLUX : IFLUX
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://explorer.runonflux.io/api/addr/{walletAddress}");
        }
        class Fio : IFIO // Error
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                var json = new 
                {
                    
                
                };

                return request;
            }, "https://fio.eosn.io/v1/chain/get_currency_balance");
        }
        class Elrond : IEGLD
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.elrond.com/accounts/{walletAddress}");
        }
        class Nano : INANO
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                var json = new
                { 
                    accounts = walletAddress
                };
                request.AddBody(json);
                request.AddHeader("Accept", "application/json");
                return request;
            }, "http://localhost:7076/api/accounts_balances");
        }
        class Terra : ILUNA
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://fcd.terra.dev/v1/bank/balances/{walletAddress}");
        }
        class XDai : IXDai
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.blockscout.com/api?module=account&action=balance&address={walletAddress}");
        }
        class EcoChain : IHT // Error
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, "");
        }
        class Zelcash : IZEL // Error
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                var json = new
                { 
                    jsonrpc = "1.0",
                    id = "curltest",
                    method = "getaddressbalance",
                    @params = new[] { walletAddress }
                };
                request.AddBody(json);
                request.AddHeader("Accept", "application/json");
                return request;
            }, "");
        }
        class GoChain : IGO
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.gochain.io/v1/address/{walletAddress}");
        }
        class POANetwork : IPOA
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://blockscout.com/poa/core/api?module=account&action=balance&address={walletAddress}");
        }
        class VeChain : IVET
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.vechain.com/v1/accounts/{walletAddress}");
        }
        class Wanchain : IWAN
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://explorer.wanchain.org/api/v1/address/{walletAddress}");
        }
        class Callisto : ICLO
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.callisto.network/v1/addr/{walletAddress}/balance");
        }
        class Osmosis : IOSMO
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.osmosis.zone/v1beta1/balances/{walletAddress}");
        }
        class Kava : IKAVA
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.kava.io/v1/balances/{walletAddress}");
        }
        class ICON : IICX
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.icon.foundation/v3/address/{walletAddress}");
        }
        class TomoChain : ITOMO
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.tomochain.com/v1/address/{walletAddress}/balance");
        }
        class Firo : IFIRO // Error
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, "");
        }
        class Kin : IKIN
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://horizon.kin.org/accounts/{walletAddress}");
        }
        class Nimiq : INIM
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.nimiq.com/v1/addresses/{walletAddress}");
        }
        class ThunderToken : ITT // Error
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, "");
        }
        class Aion : IAION
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.aion.network/api/v1/address/{walletAddress}");
        }
        class Theta : ITHETA
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.thetatoken.org/v1/address/{walletAddress}");
        }
        class Ontology : IONT
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.ont.io/v1/address/{walletAddress}");
        }
        class Groestlcoin : IGRS // Error
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, "");
        }
        class Qtum : IQTUM 
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, "");
        }
        class Viacoin : IVIA
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.viacoin.org/v1/addresses/{walletAddress}");
        }
        class IoTeX : IIOTX
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.iotex.io/v1/address/{walletAddress}/balance");
        }
        class Ravencoin : IRVN
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, "");
        }
        class Zilliqa : IZIL
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.zilliqa.com/v1/address/balance?address={walletAddress}");
        }
        class Waves : IWAVES
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.wavesplatform.com/v0/addresses/{walletAddress}/balance");
        }
        class Aeternity : IAE
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://sdk.aeternity.com/v1/accounts/{walletAddress}");
        }
        class Nebulas : INAS
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.nebulas.io/v1/user?address={walletAddress}");
        }
        class Decred : IDCR
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.dcrdata.org/v2/address/{walletAddress}");
        }
        class Algorand : IALGO
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.algoexplorer.io/v2/accounts/{walletAddress}");
        }
        class Near : INEAR
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.near.org/v1/view/account/{walletAddress}");
        }
        class Digibyte : IDGB
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.digiexplorer.info/v1/address/{walletAddress}");
        }
        class Harmony : IONE
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.harmony.one/v1/address/{walletAddress}");
        }
        class Ronin : IRON // Error
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, "");
        }
        class Aptos : IAPT
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://fullnode.aptoslabs.com/v1/accounts/{walletAddress}");
        }
        class Sui : ISUI
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://fullnode.sui.io/v1/accounts/{walletAddress}");
        }
        class ONG : IONG
        {
            public string GetBalance(string walletAddress) => Networks.GetBalance(delegate (RestRequest request)
            {
                return request;
            }, $"https://api.ont.io/v1/balance?address={walletAddress}");
        }
    }
}
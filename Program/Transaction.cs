using Org.BouncyCastle.Asn1.Mozilla;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Seed_Checker
{
    class Transaction
    {
        class Network
        {
            public static string CheckTransaction(string url)
            {
                var client = new RestClient(url);
                var request = new RestRequest("/", Method.Get);
                var response = client.Execute(request);
                //return response.Content == "[]" ? true : false;
                return response.Content.ToString();
            }
        }
        //bitcoin
        public string CheckTransactionBlockstream(string walletAddress) => Network.CheckTransaction($"https://blockstream.info/api/address/{walletAddress}/txs");
        //bitcoin
        public string CheckTransactionBlockchain(string walletAddress) => Network.CheckTransaction($"https://blockchain.info/rawaddr/{walletAddress}");
        //ethernum
        public string CheckTransactionEtherscan(string walletAddress) => Network.CheckTransaction($"https://api.etherscan.io/api?module=account&action=txlist&address={walletAddress}&startblock=0&endblock=99999999&sort=asc&apikey=1J2DBZR67EDR7YT93159KBCHPQW7NK4TP8");
        //ethernum
        public string CheckTransactionArbitrium(string walletAddress) => Network.CheckTransaction($"https://api.arbiscan.io/api?module=account&action=txlist&address={walletAddress}&startblock=0&endblock=latest&sort=asc&apikey=UUGUWWZNGP7YG1581NKNM4X56I1DK1Q4HJ");
        //ethernum
        public string CheckTransactionPolygonscan(string walletAddress) => Network.CheckTransaction($"https://api.polygonscan.com/api?module=account&action=txlist&address={walletAddress}&startblock=0&endblock=latest&sort=asc&apikey=5ARYAP1PMAH7P4RD3U6HPECQEUNIVJX3AU");
        //litecoin
        public string CheckTransactionFtmscan(string walletAddress) => Network.CheckTransaction($"https://api.ftmscan.com/api?module=account&action=txlist&address={walletAddress}&startblock=0&endblock=latest&sort=asc&apikey=5XV29741RTRR7VKWWBYQYZW4UEIZM6XHBG");
        //litecoin
        public string CheckTransactionCronoscan(string walletAddress) => Network.CheckTransaction($"https://api.cronoscan.com/api?module=account&action=txlist&address={walletAddress}&startblock=0&endblock=latest&sort=asc&apikey=32KAA8WGXX49U76DUMUGSI3N1DDIBX4ARJ");

    }
}

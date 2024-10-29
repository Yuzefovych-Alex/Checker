using Nethereum.RPC;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json_Chainz
{
    class ConfirmedBalance
    {
        public string Amount { get; set; }
        public string Unit { get; set; }
    }
    class Item
    {
        public ConfirmedBalance ConfirmedBalance {get; set;}
    }
    class Data
    { 
        public Item Item { get; set; }
    }
    class ApiResponseChainz
    {
        public string ApiVersion { get; set; }
        public string RequestId { get; set; }
        public string Context { get; set; }
        public Data Data { get; set; }
    }
}

namespace Json_Etherscan
{
    class ApiResponseEtherscan
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
    }
}

namespace Json_Metamask
{
    class ApiResponseMetamask
    {
        public string Jsonrpc;
        public string Id;
        public string Result;
    }
}


namespace Json_MempoolSpace
{
    class ChainStats
    { 
        public string FundedTxoCount { get; set; }
        public string FundedTxoSum { get; set; }
        public string SpentTxoCount { get; set; }
        public string TxCount { get; set; }
    }
    class MempoolStats
    { 
        public string FundedTxoCount { get; set; }
        public string FundedTxoSum { get; set; }
        public string SpentTxoCount { get; set; }
        public string TxCount { get; set; }
    }
    class ApiResponseMempoolSpace
    { 
        public string Address { get; set; }
        public ChainStats ChainStats { get; set; }
        public MempoolStats MempoolStats { get; set; }
    }

}
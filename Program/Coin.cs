using BitcoinLib.Responses.SharedComponents;
using NBitcoin.Secp256k1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static NBitcoin.Scripting.OutputDescriptor;
//using static Seed_Checker.Checker.Coin;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Seed_Checker
{
    public interface IBitcoin { public string GetBalance(string walletAddress); }
    public interface IEthernum { public string GetBalance(string walletAddress); }
    public interface ILitecoin { public string GetBalance(string walletAddress); }
    public interface IXRP { public string GetBalance(string walletAddress); }
    public interface ISolana { public string GetBalance(string walletAddress); }
    public interface IDOGE { public string GetBalance(string walletAddress); }
    public interface IRUNE { public string GetBalance(string walletAddress); }
    public interface IDOT { public string GetBalance(string walletAddress); }
    public interface IZEC { public string GetBalance(string walletAddress); }
    public interface IBNB { public string GetBalance(string walletAddress); }
    public interface IDASH { public string GetBalance(string walletAddress); }
    public interface ITRX { public string GetBalance(string walletAddress); }
    public interface IXTZ { public string GetBalance(string walletAddress); }
    public interface IATOM { public string GetBalance(string walletAddress); }
    public interface IXLM { public string GetBalance(string walletAddress); }
    public interface IBCH { public string GetBalance(string walletAddress); }
    public interface IFIL { public string GetBalance(string walletAddress); }
    public interface IFLUX { public string GetBalance(string walletAddress); }
    public interface IFIO { public string GetBalance(string walletAddress); }
    public interface IEGLD { public string GetBalance(string walletAddress); }
    public interface INANO { public string GetBalance(string walletAddress); }
    public interface IFTM { public string GetBalance(string walletAddress); }
    public interface IARETH { public string GetBalance(string walletAddress); }
    public interface IOETH { public string GetBalance(string walletAddress); }
    public interface ILUNA { public string GetBalance(string walletAddress); }
    public interface ILUNC { public string GetBalance(string walletAddress); }
    public interface IAVAX { public string GetBalance(string walletAddress); }
    public interface IXDai { public string GetBalance(string walletAddress); }
    public interface IHT { public string GetBalance(string walletAddress); }
    public interface IZEL { public string GetBalance(string walletAddress); }
    public interface IGO { public string GetBalance(string walletAddress); }
    public interface IPOA { public string GetBalance(string walletAddress); }
    public interface IVET { public string GetBalance(string walletAddress); }
    public interface IWAN { public string GetBalance(string walletAddress); }
    public interface ICLO { public string GetBalance(string walletAddress); }
    public interface IOSMO { public string GetBalance(string walletAddress); }
    public interface IKAVA { public string GetBalance(string walletAddress); }
    public interface IICX { public string GetBalance(string walletAddress); }
    public interface ITOMO { public string GetBalance(string walletAddress); }
    public interface IFIRO { public string GetBalance(string walletAddress); }
    public interface IKIN { public string GetBalance(string walletAddress); }
    public interface INIM { public string GetBalance(string walletAddress); }
    public interface ITT { public string GetBalance(string walletAddress); }
    public interface IAION { public string GetBalance(string walletAddress); }
    public interface ITHETA { public string GetBalance(string walletAddress); }
    public interface IONT { public string GetBalance(string walletAddress); }
    public interface IGRS { public string GetBalance(string walletAddress); }
    public interface IQTUM { public string GetBalance(string walletAddress); }
    public interface IVIA { public string GetBalance(string walletAddress); }
    public interface IIOTX { public string GetBalance(string walletAddress); }
    public interface IRVN { public string GetBalance(string walletAddress); }
    public interface IZIL { public string GetBalance(string walletAddress); }
    public interface IWAVES { public string GetBalance(string walletAddress); }
    public interface IAE { public string GetBalance(string walletAddress); }
    public interface INAS { public string GetBalance(string walletAddress); }
    public interface IDCR { public string GetBalance(string walletAddress); }
    public interface IALGO { public string GetBalance(string walletAddress); }
    public interface INEAR { public string GetBalance(string walletAddress); }
    public interface IDGB { public string GetBalance(string walletAddress); }
    public interface IONE { public string GetBalance(string walletAddress); }
    public interface IRON { public string GetBalance(string walletAddress); }
    public interface IAPT { public string GetBalance(string walletAddress); }
    public interface ISUI { public string GetBalance(string walletAddress); }
    public interface IONG { public string GetBalance(string walletAddress); }



    //class BitcoinNetwork
    //{
    //    public IBitcoin BlockstreamMainnet = new Blockstream.Mainnet();
    //    public IBitcoin BlockstreamTestnet = new Blockstream.Testnet();
    //    public IBitcoin BlockchainTestnet = new Blockchain.Testnet();
    //    public IBitcoin BlockchairDashboards = new Blockchair.Dashboards();
    //}
    //class EthernumNetwork
    //{ 
    //    public IEthernum EtherscanMainnet = new Etherscan.Mainnet();
    //    public IEthernum EtherscanGoerli = new Etherscan.Goerli();
    //    public IEthernum EtherscanSepolia = new Etherscan.Sepolia();
    //    public IEthernum EtherscanOptimistic = new Etherscan.Optimistic();
    //    public IEthernum Polygonscan = new PFC.Polygonscan();
    //    public IEthernum ADMMainnet = new ADM.Mainnet();
    //}
    //class LitecoinNetwork
    //{
    //    public ILitecoin Avalanche = new ADM.Avalanche();
    //    public ILitecoin Fantom = new PFC.Ftmscan();
    //    public ILitecoin Cronos = new PFC.Cronoscan();
    //}
    

}

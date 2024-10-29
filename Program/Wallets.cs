using Seed_Checker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Seed_Checker.ADM;

namespace Program
{
    public interface IExodus { }
    public interface IMetamask { }
    public interface ITrolink { }
    public interface ITrustWallet { }
    public interface IIamtoken { }

    class TrustWallet
    {
        public ITrustWallet BTCMainnet = new Blockstream.Mainnet();
        public ITrustWallet ETHMainnet = new ADM.Mainnet();
        public ITrustWallet ETHPolygon = new PFC.Polygonscan();
    }
    class Metamask
    {
        public IMetamask ETHMainnet = new ADM.Mainnet();
        public IMetamask ETHOptimism = new Etherscan.Optimistic();
        public IMetamask ETHPolygon = new PFC.Polygonscan();
        public IMetamask ETHArbitrum = new Arbitrium();
        public IMetamask LTCAvalanche = new ADM.Avalanche();
        public IMetamask LTCFantom = new PFC.Ftmscan();
        public IMetamask LTCCronos = new PFC.Cronoscan();
    }
    class Exodus
    { 
        public IExodus ETHMainnet = new Etherscan.Mainnet();
        public IExodus BTCMainnet = new Blockstream.Mainnet();
    }
    class IamToken
    {
        public IIamtoken ETHMainnet = new Etherscan.Mainnet();
        public IIamtoken BTCMainnet = new Blockstream.Mainnet();
        public IMetamask ETHArbitrum = new Arbitrium();
    }
    class Tronlink
    { 
        
    }
}

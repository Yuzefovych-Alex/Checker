using NBitcoin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Nethereum.HdWallet;
using NBitcoin.Protocol;
using Nethereum.Web3;
using static System.Net.WebRequestMethods;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using Org.BouncyCastle.Asn1;

namespace Seed_Checker
{


    class Checker 
    {
        class SeedPhrase
        { 
            public static bool CheckSeedPhrase(string seedPhrase)
            {
                try
                {
                    Mnemonic mnemonic = new Mnemonic(seedPhrase, Wordlist.English);
                    return true;
                }
                catch (FormatException)
                {
                    return false;
                }
            }
        }
        class TransactionWallet
        { 
            
            
        }
        class CheckPrivateKey
        { 
        
        }
    }







    

    //public interface IBIP32
    //{
    //    public string GenerateAddress32(string seedPhrase, ref string privateKey);
    //}
    //public interface IBIP44
    //{
    //    public string GenerateAddress44(string seedPhrase, ref string privateKey);
    //}
    //public interface IBIP49
    //{
    //    public string GenerateAddress49(string seedPhrase, ref string privateKey);
    //}
    //public interface IBIP86
    //{
    //    public string GenerateAddress86(string seedPhrase, ref string privateKey);
    //}
    //public interface IBIP84
    //{
    //    public string GenerateAddress84(string seedPhrase, ref string privateKey);
    //}
    //public class Checker
    //{ 
    //    public class Coin
    //    {
    //        class BIP
    //        { 
    //            public static string GenerateAddress(string seedPhrase, string hd, ref string privateKey)
    //            {
    //                try
    //                {
    //                    var mnemonic = new Mnemonic(seedPhrase, Wordlist.English);
    //                    var masterKey = mnemonic.DeriveExtKey();
    //                    var walletKey = masterKey.Derive(new KeyPath(hd));
                        
    //                    var bitcoinAddress = walletKey.PrivateKey.PubKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main);
    //                    return bitcoinAddress.ToString();
    //                }
    //                catch (Exception ex) { return $"Error: {ex.Message}"; }
    //            }
    //        }

    //        public class Bitcoin : IBIP32, IBIP44, IBIP49, IBIP84, IBIP86
    //        { 
    //            public string GenerateAddress32(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/0'/0'/0'", ref privateKey);
    //            public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/0'/0'/0/0", ref privateKey);
    //            public string GenerateAddress49(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/49'/0'/0'/0/0", ref privateKey);
    //            public string GenerateAddress84(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/84'/0'/0'/0/0", ref privateKey);
    //            public string GenerateAddress86(string seddPhrase, ref string privateKey) => BIP.GenerateAddress(seddPhrase, "m/86'/0'/0'/0/0", ref privateKey);
    //        }
    //        public class Litecoin : IBIP32, IBIP44, IBIP84
    //        {
    //            public string GenerateAddress32(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/0'/2'/0'", ref privateKey);
    //            public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/2'/0'/0/0", ref privateKey);
    //            public string GenerateAddress84(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/84'/2'/0'/0/0", ref privateKey);
    //        }
    //        public class Ethernum : IBIP32, IBIP44
    //        {
    //            public string GenerateAddress32(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/60'/0'/0'/0", ref privateKey);
    //            public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/60'/0'/0/0", ref privateKey);
    //        }
    //    }
    //    public bool CheckSeedPhrase(string seedPhrase)
    //    {
    //        try
    //        {
    //            Mnemonic mnemonic = new Mnemonic(seedPhrase, Wordlist.English);
    //            return true;
    //        }
    //        catch (FormatException)
    //        {
    //            return false;
    //        }
    //    }



        /*

        public static string GenerateWalletAddressBitcoin39BIP(string seedPhrase)
        {
            try
            {
                var mnemonic = new Mnemonic(seedPhrase, Wordlist.English);
                var masterKey = mnemonic.DeriveExtKey();
                var walletKey = masterKey.Derive(new KeyPath("m/32'/0'/0'/0/0"));
                var bitcoinAddress = walletKey.PrivateKey.PubKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main);
                return bitcoinAddress.ToString();
            }
            catch (Exception ex) { return $"Error: {ex.Message}"; }
        }
        public static string GenerateWalletAddressBitcoin(string seedPhrase)
        {
            try
            {
                var mnemonic = new Mnemonic(seedPhrase, Wordlist.English);
                var masterKey = mnemonic.DeriveExtKey();
                var walletKey = masterKey.Derive(new KeyPath("m/44'/0'/0'/0/0"));
                var bitcoinAddress = walletKey.PrivateKey.PubKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main);
                return bitcoinAddress.ToString();
            }
            catch (Exception ex) { return $"Error: {ex.Message}"; }
        }
        public static string GenerateWalletAddressEthereum(string seedPhrase)
        {
            try
            {
                Wallet wallet = new Wallet(seedPhrase, null);
                var account = wallet.GetAccount(0);
                return account.Address.ToString();
            }
            catch (Exception ex) { return $"Error {ex.Message}"; }
        }
        public static string GenerateWalletAddressLitecoin(string seedPhrase)
        {
            try
            {
                var mnemonic = new Mnemonic(seedPhrase, Wordlist.English);
                var masterKey = mnemonic.DeriveExtKey();
                var walletKey = masterKey.Derive(new KeyPath($"m/44'/2'/0'/0/0"));
                var litecoinAddress = walletKey.PrivateKey.PubKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main);
                return litecoinAddress.ToString();
            }
            catch (Exception ex) { return $"Error: {ex.Message}"; }
        }*/
    
}

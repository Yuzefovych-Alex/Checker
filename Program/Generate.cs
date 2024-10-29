using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using NBitcoin;
using System.Threading.Tasks;
using BitcoinLib.Responses.SharedComponents;
using System.Security.Policy;

namespace Seed_Checker
{

    public interface IBIP32
    {
        public string GenerateAddress32(string seedPhrase, ref string privateKey);
    }
    public interface IBIP44
    {
        public string GenerateAddress44(string seedPhrase, ref string privateKey);
    }
    public interface IBIP49
    {
        public string GenerateAddress49(string seedPhrase, ref string privateKey);
    }
    public interface IBIP86
    {
        public string GenerateAddress86(string seedPhrase, ref string privateKey);
    }
    public interface IBIP84
    {
        public string GenerateAddress84(string seedPhrase, ref string privateKey);
    }

    static class Generate
    {
        class SeedPhrase
        {
            public static string GetGenerateSeed(int size)
            {
                Wordslist wordslist = new Wordslist();
                Random random = new Random();
                string seed = "";

                for (int i = 0; i < size; i++)
                {
                    seed += wordslist.Get_Wordslist()[random.Next(0, wordslist.Words_List_Size())];
                    if (i != (size - 1)) { seed += " "; }
                }
                return seed;
            }
        }

        class Wallet
        {
            public class Coin
            {
                class BIP
                {
                    public static string GenerateAddress(string seedPhrase, string hd, ref string privateKey)
                    {
                        try
                        {
                            var mnemonic = new Mnemonic(seedPhrase, Wordlist.English);
                            var masterKey = mnemonic.DeriveExtKey();
                            var walletKey = masterKey.Derive(new KeyPath(hd));

                            var bitcoinAddress = walletKey.PrivateKey.PubKey.GetAddress(ScriptPubKeyType.Legacy, Network.Main);
                            return bitcoinAddress.ToString();
                        }
                        catch (Exception ex) { return $"Error: {ex.Message}"; }
                    }
                }
                public class Bitcoin : IBIP32, IBIP44, IBIP49, IBIP84, IBIP86
                {
                    public string GenerateAddress32(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/0'/0'/0'", ref privateKey);
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/0'/0'/0/0", ref privateKey);
                    public string GenerateAddress49(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/49'/0'/0'/0/0", ref privateKey);
                    public string GenerateAddress84(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/84'/0'/0'/0/0", ref privateKey);
                    public string GenerateAddress86(string seddPhrase, ref string privateKey) => BIP.GenerateAddress(seddPhrase, "m/86'/0'/0'/0/0", ref privateKey);
                }
                public class Litecoin : IBIP32, IBIP44, IBIP84
                {
                    public string GenerateAddress32(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/0'/2'/0'", ref privateKey);
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/2'/0'/0/0", ref privateKey);
                    public string GenerateAddress84(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/84'/2'/0'/0/0", ref privateKey);
                }
                public class Ethernum : IBIP32, IBIP44
                {
                    public string GenerateAddress32(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/60'/0'/0'/0", ref privateKey);
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/60'/0'/0/0", ref privateKey);
                }
                public class XRP : IBIP44 
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/144'/0'/0/0", ref privateKey);
                }
                public class DOGE : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/3'/0'/0/0", ref privateKey);
                }
                public class SOL : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/501'/0'/0/0", ref privateKey);
                }
                public class MATIC : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/966'/0'/0/0", ref privateKey);
                }
                public class RUNE : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/931'/0'/0/0", ref privateKey);
                }
                public class DOT : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/354'/0'/0/0", ref privateKey);
                }
                public class ZEC : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/133'/0'/0/0", ref privateKey);
                }
                public class DASH : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/5'/0'/0/0", ref privateKey);
                }
                public class TRX : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/195'/0'/0/0", ref privateKey);
                }
                public class XTZ : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/1729'/0'/0/0", ref privateKey);
                }
                public class ATOM : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/118'/0'/0/0", ref privateKey);
                }
                public class XLS : IBIP44 // Error
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/2'/0'/0/0", ref privateKey);
                }
                public class BCH : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/145'/0'/0/0", ref privateKey);
                }
                public class FIL : IBIP44 // Error
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/'/0'/0/0", ref privateKey);
                }
                public class FLUX : IBIP44 // Error
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/2'/0'/0/0", ref privateKey);
                }
                public class FIO : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/235'/0'/0/0", ref privateKey);
                }
                public class EGLD : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/508'/0'/0/0", ref privateKey);
                }
                public class NANO : IBIP44 // Error
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/2'/0'/0/0", ref privateKey);
                }
                public class FTM : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/1007'/0'/0/0", ref privateKey);
                }
                public class ARETH : IBIP44 //Error
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/2'/0'/0/0", ref privateKey);
                }
                public class OETH : IBIP44 // Error
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/2'/0'/0/0", ref privateKey);
                }
                public class LUNA : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/330'/0'/0/0", ref privateKey);
                }
                public class AVAX : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/9000'/0'/0/0", ref privateKey);
                }
                public class XDAI : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/700'/0'/0/0", ref privateKey);
                }
                public class HT : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/1010'/0'/0/0", ref privateKey);
                }
                public class ZEL : IBIP44 // Error
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/2'/0'/0/0", ref privateKey);
                }
                public class GO : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/6060'/0'/0/0", ref privateKey);
                }
                public class POA : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/178'/0'/0/0", ref privateKey);
                }
                public class VET : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/818'/0'/0/0", ref privateKey);
                }
                public class WAN : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/5718350'/0'/0/0", ref privateKey);
                }
                public class CLO : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/820'/0'/0/0", ref privateKey);
                }
                public class OSMO : IBIP44 // Error
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/2'/0'/0/0", ref privateKey);
                }
                public class KAVA : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/459'/0'/0/0", ref privateKey);
                }
                public class ICX : IBIP44 // Error
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/2'/0'/0/0", ref privateKey);
                }
                public class TOMO : IBIP44 
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/889'/0'/0/0", ref privateKey);
                }
                public class FIRO : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/2'/0'/0/0", ref privateKey);
                }
                public class KIN : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/2017'/0'/0/0", ref privateKey);
                }
                public class NIM : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/242'/0'/0/0", ref privateKey);
                }
                public class TT : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/1001'/0'/0/0", ref privateKey);
                }
                public class AVION : IBIP44 // Error
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/2'/0'/0/0", ref privateKey);
                }
                public class THETA : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/500'/0'/0/0", ref privateKey);
                }
                public class ONT : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/1024'/0'/0/0", ref privateKey);
                }
                public class GRS : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/17'/0'/0/0", ref privateKey);
                }
                public class QTUM : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/2301'/0'/0/0", ref privateKey);
                }
                public class VIA : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/14'/0'/0/0", ref privateKey);
                }
                public class IOTX : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/304'/0'/0/0", ref privateKey);
                }
                public class RVN : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/175'/0'/0/0", ref privateKey);
                }
                public class ZIL : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/313'/0'/0/0", ref privateKey);
                }
                public class WAVES : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/5741564'/0'/0/0", ref privateKey);
                }
                public class AE : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/457'/0'/0/0", ref privateKey);
                }
                public class NAS : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/2718'/0'/0/0", ref privateKey);
                }
                public class DCR : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/42'/0'/0/0", ref privateKey);
                }
                public class ALGO : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/283'/0'/0/0", ref privateKey);
                }
                public class NEAR : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/397'/0'/0/0", ref privateKey);
                }
                public class DNG : IBIP44 // Error
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/2'/0'/0/0", ref privateKey);
                }
                public class ONE : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/270'/0'/0/0", ref privateKey);
                }
                public class RON : IBIP44 /// Error
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/'/0'/0/0", ref privateKey);
                }
                public class APT : IBIP44 // Error
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/2'/0'/0/0", ref privateKey);
                }
                public class SUI : IBIP44
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/784'/0'/0/0", ref privateKey);
                }
                public class ONG : IBIP44 // Error
                {
                    public string GenerateAddress44(string seedPhrase, ref string privateKey) => BIP.GenerateAddress(seedPhrase, "m/44'/2'/0'/0/0", ref privateKey);
                }
            }
        }
    }
}

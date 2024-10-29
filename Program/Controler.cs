using NBitcoin;
using Nethereum.Contracts.Standards.ERC20.TokenList;
using Nethereum.Signer;
using Seed_Checker;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static Seed_Checker.Blockchair;
using static Seed_Checker.Etherscan;

namespace Program
{
    class Coins
    {
        public string Bitcoin { get; set; }
        public string Litecoin { get; set; }
        public string Ethernum { get; set; }
    }
    class Table
    {
        private int _id = 0;
        private DataGridView _dataGridView = new DataGridView();
        public Table(DataGridView dataGridView) 
        {
            this._dataGridView = dataGridView;
            var colomn0 = Colomn("id", "ID");
            var colomn1 = Colomn("seed", "SEED");
            var colomn2 = Colomn("privateKey", "PRIVATE_KEY");
            var colomn3 = Colomn("btc", "BTC");
            var colomn4 = Colomn("eth", "ETH");
            var colomn5 = Colomn("ltc", "LTC");
            var colomn6 = Colomn("coins", "USDT");

            dataGridView.Columns.AddRange(colomn0, colomn1, colomn2, colomn3, colomn4, colomn5, colomn6);
        }

        private DataGridViewTextBoxColumn Colomn(string name, string headerText)
        {
            DataGridViewTextBoxColumn colomn = new DataGridViewTextBoxColumn();
            colomn.Name = name;
            colomn.HeaderText = headerText;
            return colomn;
        }

        public DataGridViewRow AddBlockTable(string seed, string privateKey,Coins coins, string usdt)
        {
            DataGridViewRow row = new DataGridViewRow();
            DataGridViewCell Id = new DataGridViewTextBoxCell();
            DataGridViewCell Seed = new DataGridViewTextBoxCell();
            DataGridViewCell PrivateKey = new DataGridViewTextBoxCell();
            DataGridViewCell BTC = new DataGridViewTextBoxCell();
            DataGridViewCell ETH = new DataGridViewTextBoxCell();
            DataGridViewCell LTC = new DataGridViewTextBoxCell();
            DataGridViewCell Usdt = new DataGridViewTextBoxCell();
            Id.Value = this._id++;
            Seed.Value = seed;
            PrivateKey.Value = privateKey;
            BTC.Value = coins.Bitcoin;
            ETH.Value = coins.Ethernum;
            LTC.Value = coins.Litecoin;
            Usdt.Value = usdt;
            row.Cells.AddRange(Id, Seed, PrivateKey, BTC, ETH, LTC, Usdt);
            _dataGridView.Rows.Add(row);
            return row;
        }
        public Coins SetCoins(string bitcoin, string ethernum, string litecoin)
        { 
            Coins coins = new Coins();
            coins.Bitcoin = bitcoin;
            coins.Ethernum = ethernum;
            coins.Litecoin = litecoin;
            return coins;
        }
    }

    class Controler
    {
        public Label DatabaseSize { get; set; }
        public Label NumberOfCheckedSeed { get; set; }
        public Label NumberOfValid { get; set; }
        public Label NumberOfInvalids { get; set; }
        public Label NumberOfEmptyWallets { get; set; }
        public Label NumberOfEmptyWalletsWithTrsnsactions { get; set; }
        public Label QuantityWithBalance { get; set; }

        public void SetDatabadseSize(int number) => DatabaseSize.Text = number.ToString();
        public void SetNumberOfCheckedSeed(int number) => NumberOfCheckedSeed.Text = number.ToString();
        public void SetNumberOfValid(int number) => NumberOfValid.Text = number.ToString();
        public void SetNumberOfInvalids(int number) => NumberOfInvalids.Text = number.ToString();
        public void SetNumberOfEmptyWallets(int number) => NumberOfEmptyWallets.Text = number.ToString();
        public void SetNumberOfEmptyWalletsWithTrsnsactions(int number) => NumberOfEmptyWalletsWithTrsnsactions.Text = number.ToString();
        public void SetQuantityWithBalance(int number) => QuantityWithBalance.Text = number.ToString();

        class Network
        {
            public CheckedListBox checkedListBox { get; set; }

            public Network(string name)
            {

                switch (name)
                {
                    case "Mainnet":
                        break;
                    case "Testnet":
                        break;
                    case "Dashboards":
                        break;
                    case "Solana":
                        break;
                    case "Goerli":
                        break;
                    case "Sepolia":
                        break;
                    case "Optimism":
                        break;
                    case "Avalanche":
                        break;
                    case "Polygon":
                        break;
                    case "Fantom":
                        break;
                    case "Cronos":
                        break;
                    case "Ripple":
                        break;
                    case "Dogecoin":
                        break;
                    case "Thorchain":
                        break;
                    case "Polkadot":
                        break;
                    case "Zcash":
                        break;
                    case "Smartchain":
                        break;
                    case "Dash":
                        break;
                    case "TRON":
                        break;
                    case "Tezos":
                        break;
                    case "Cosmos":
                        break;
                    case "Stellar":
                        break;
                    case "Filecoin":
                        break;
                    case "FLUX":
                        break;
                    case "Fio":
                        break;
                    case "Elrond":
                        break;
                    case "Nano":
                        break;
                    case "Terra":
                        break;
                    case "xDai":
                        break;
                    case "Eco Chain":
                        break;
                    case "Zelcash":
                        break;
                    case "GoChain":
                        break;
                    case "POA Network":
                        break;
                    case "VeChain":
                        break;
                    case "Wanchain":
                        break;
                    case "Callisto":
                        break;
                    case "Osmosis":
                        break;
                    case "Kava":
                        break;
                    case "ICON":
                        break;
                    case "TomoChain":
                        break;
                    case "Firo":
                        break;
                    case "Kin":
                        break;
                    case "Nimiq":
                        break;
                    case "Thunder Token":
                        break;
                    case "Aion":
                        break;
                    case "Theta":
                        break;
                    case "Ontology":
                        break;
                    case "Groestlcoin":
                        break;
                    case "Qtum":
                        break;
                    case "Viacoin":
                        break;
                    case "IoTeX":
                        break;
                    case "Ravencoin":
                        break;
                    case "Zilliqa":
                        break;
                    case "Waves":
                        break;
                    case "Aeternity":
                        break;
                    case "Nebulas":
                        break;
                    case "Decred":
                        break;
                    case "Algorand":
                        break;
                    case "Near":
                        break;
                    case "Digibyte":
                        break;
                    case "Harmony":
                        break;
                    case "Ronin":
                        break;
                    case "Aptos":
                        break;
                    case "Sui":
                        break;
                    case "ONG":
                        break;
                }
            }
        }
    }
}

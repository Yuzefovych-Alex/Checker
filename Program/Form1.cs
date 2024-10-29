using System.CodeDom;
using System.Net.Security;

namespace Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Table table = new Table(dataGridView1);

            table.AddBlockTable("adsf", "asd", table.SetCoins("asdf", "sad", "asd"), "ds");
            table.AddBlockTable("adsf", "asd", table.SetCoins("asdf", "sad", "asd"), "ds");
            table.AddBlockTable("adsf", "asd", table.SetCoins("asdf", "sad", "asd"), "ds");
            table.AddBlockTable("adsf", "asd", table.SetCoins("asdf", "sad", "asd"), "ds");
            table.AddBlockTable("adsf", "asd", table.SetCoins("asdf", "sad", "asd"), "ds");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }


        private Controler ControlLable()
        {
            Controler controler = new Controler();
            controler.DatabaseSize = label15;
            controler.NumberOfCheckedSeed = label16;
            controler.NumberOfValid = label18;
            controler.NumberOfInvalids = label17;
            controler.NumberOfEmptyWallets = label19;
            controler.NumberOfEmptyWalletsWithTrsnsactions = label20;
            controler.QuantityWithBalance = label21;
            return controler;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ControlLable().SetDatabadseSize(10000);
            ControlLable().SetNumberOfCheckedSeed(1000);
            ControlLable().SetNumberOfValid(100);
            ControlLable().SetNumberOfInvalids(10);

            foreach (object Item in checkedListBox1.CheckedItems)
            {
                
            }
        }




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            string readFile = File.ReadAllText(filename);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}

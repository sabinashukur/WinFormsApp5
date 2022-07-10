using Newtonsoft.Json;

namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Deserializer();
        }
        public double enteredMoney = 0;
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            if (sender is Guna.UI2.WinForms.Guna2CircleButton btn)
            {
                switch (btn.Tag)
                {
                    case "10":
                        enteredMoney += 0.1;
                        break;
                    case "20":
                        enteredMoney += 0.2;
                        break;
                    case "50":
                        enteredMoney += 0.5;
                        break;
                    case "1":
                        enteredMoney += 1;
                        break;
                    case "5":
                        enteredMoney += 5;
                        break;
                    case "10Azn":
                        enteredMoney += 10;
                        break;

                }
                tbox_EnteredMoney.Text = enteredMoney.ToString();
                lbl_EnteredMoney.Text = enteredMoney.ToString();
                while (tbox_EnteredMoney.Text.Length > 4)
                {
                    tbox_EnteredMoney.Text = tbox_EnteredMoney.Text.Remove(tbox_EnteredMoney.Text.Length - 1);
                }

            }
        }
        List<string> list = new List<string>();
        private void Serialize()
        {
            foreach (var item in Controls)
            {
                if (item is UC_Product product)
                    if (product.Checked)
                    {
                        if ((Convert.ToDouble(product.checkBox1.Text) - 1) == 0) { list.Add("No product"); }
                        else list.Add((Convert.ToDouble(product.checkBox1.Text) - 1).ToString());
                    }
                    else list.Add(product.checkBox1.Text);
            }
        }
        double CalculatePrice()
        {
            double price = 0;
            list.Clear();
            foreach (var item in Controls)
                if (item is UC_Product product && product.Checked == true) price += Convert.ToDouble(product.Price);
            return price;
        }
        private void btn_Buy_Click(object sender, EventArgs e)
        {
            double price = CalculatePrice();
            if (price == 0 && lbl_EnteredMoney.Text.Length != 0)
            {
                MessageBox.Show("You doesn't buy anything");
            }
            else if (lbl_EnteredMoney.Text.Length != 0 && Convert.ToDouble(lbl_EnteredMoney.Text) - price >= 0)
            {

                if (Convert.ToDouble(lbl_EnteredMoney.Text) - price != 0)
                {
                    label4.Visible = true;
                    lbl_RemainingMoney.Visible = true;
                    lbl_RemainingMoney.Text = (Convert.ToDouble(tbox_EnteredMoney.Text) - price).ToString();
                    MessageBox.Show($"Remaining money: {lbl_RemainingMoney.Text}, Thanks for shopping");
                }
                else
                {
                    MessageBox.Show("Thanks, goodbye");

                }
                Serializer();

            }
            else
            {
                MessageBox.Show("No enough money");
            }
            Close();

        }
        void Deserializer()
        {
            if (File.Exists("info.json"))
            {
                List<string> newList = new List<string>();
                {

                    var stringData = File.ReadAllText("info.json");
                    newList = JsonConvert.DeserializeObject<List<string>>(stringData);
                }
                int num = 0;
                foreach (var item in Controls)
                {
                    if (item is UC_Product product)
                    {
                        product.checkBox1.Text = newList[num++];
                        if (product.checkBox1.Text == "No product") product.Visible = false;

                    }
                }
            }
        }
        void Serializer()
        {
            Serialize();
            var json = System.Text.Json.JsonSerializer.Serialize(list);
            File.WriteAllText("info.json", json);
        }
    }
}
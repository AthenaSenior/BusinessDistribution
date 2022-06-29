using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Athena_Browser_by_AthenaApps_v2._0
{
    public partial class Form1 : Form
    {
        Form x;
        string queryLed = "Select name from [Table] Where led = 'true'";
        string queryGenel = "Select name from [Table]";
        string queryRadyo = "Select name from [Table] Where radyoizmir = 'true'";
        string queryReji = "Select name from [Table] Where reji = 'true'";
        string queryMuhasebe = "Select name from [Table] Where muhasebe = 'true'";

        string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =E:\Users\Win7\source\repos\Athena Browser by AthenaApps v2.0\Athena Browser by AthenaApps v2.0\Properties\JobDatabase.mdf; Integrated Security = True; Connect Timeout = 30";

        string ledQuery = "Select * from [Table] Where worktype = 'Led'  and tamam = 'false'";
        string radyoQuery = "Select * from [Table] Where worktype = 'Radyo' and tamam = 'false'";
        string rejiQuery = "Select * from [Table] Where worktype = 'Reji' and tamam = 'false'";
        string muhasebeQuery = "Select * from [Table] Where worktype = 'Muhasebe' and tamam = 'false'";
        public string genelQuery = "Select * from [Table] Where tamam = 'false' and worktype <> 'Muhasebe'";


        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Users\Win7\source\repos\Athena Browser by AthenaApps v2.0\Athena Browser by AthenaApps v2.0\Properties\LoginDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        SqlConnection sqlcon2 = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =E:\Users\Win7\source\repos\Athena Browser by AthenaApps v2.0\Athena Browser by AthenaApps v2.0\Properties\JobDatabase.mdf; Integrated Security = True; Connect Timeout = 30");
        public Form1()
        { 
           InitializeComponent();
           sqlcon.Open();
           sqlcon2.Open();
        }

        public Form1(Form parentform)
        {
            InitializeComponent();
            x = parentform;
            sqlcon.Open();
            sqlcon2.Open();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Properties.Form6 form = new Properties.Form6(this);
            form.Owner = this;
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Properties.Form3 form = new Properties.Form3(this);
            form.Owner = this;
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Properties.Form7 form = new Properties.Form7(this);
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        // Bussiness Planning Application

        private void Form1_Load(object sender, EventArgs e)
        {

        } 

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Properties.Form4 form = new Properties.Form4(this);
            form.Owner = this;
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 NewForm = new Form1();
            NewForm.Show();
            this.Dispose(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Tamamlanacak bir iş seçin.");
            }
            else
            {
                string item = listBox1.SelectedItem.ToString();
                int pFrom = item.IndexOf("]- ") + "]- ".Length;
                int pTo = item.LastIndexOf(" - ");
                string result = item.Substring(pFrom, pTo - pFrom);
                string change = "UPDATE [Table] SET tamam = @tamam Where workdesc = '" + result + "'";
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(change, cnn);
                    cmd.Parameters.AddWithValue("@tamam", true);

                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                MessageBox.Show("İş tamamlandı.");
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Properties.Form3 form = new Properties.Form3(this);
            form.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            MessageBox.Show("Başarılı");
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlCommand command2 = new SqlCommand(ledQuery, sqlcon2);
            using (SqlDataReader reader = command2.ExecuteReader())
            {
                while (reader.Read())
                {
                    listBox1.Items.Add(String.Format("{0}", Convert.ToDateTime(reader["tarih"]).ToString("dd/MM/yyyy")) + " - [" + String.Format("{0}", reader["worktype"]) + "]- " + String.Format("{0}", reader["workdesc"]) + " - " + String.Format("{0}", reader["fiyat"]) + "TL");
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlCommand command2 = new SqlCommand(radyoQuery, sqlcon2);
            using (SqlDataReader reader = command2.ExecuteReader())
            {
                while (reader.Read())
                {
                    listBox1.Items.Add(String.Format("{0}", Convert.ToDateTime(reader["tarih"]).ToString("dd/MM/yyyy")) + " - [" + String.Format("{0}", reader["worktype"]) + "]- " + String.Format("{0}", reader["workdesc"]) + " - " + String.Format("{0}", reader["fiyat"]) + "TL");
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlCommand command2 = new SqlCommand(rejiQuery, sqlcon2);
            using (SqlDataReader reader = command2.ExecuteReader())
            {
                while (reader.Read())
                {
                    listBox1.Items.Add(String.Format("{0}", Convert.ToDateTime(reader["tarih"]).ToString("dd/MM/yyyy")) + " - [" + String.Format("{0}", reader["worktype"]) + "]- " + String.Format("{0}", reader["workdesc"]) + " - " + String.Format("{0}", reader["fiyat"]) + "TL");
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlCommand command2 = new SqlCommand(muhasebeQuery, sqlcon2);
            using (SqlDataReader reader = command2.ExecuteReader())
            {
                while (reader.Read())
                {
                    listBox1.Items.Add(String.Format("{0}", Convert.ToDateTime(reader["tarih"]).ToString("dd/MM/yyyy")) + " - [" + String.Format("{0}", reader["worktype"]) + "]- " + String.Format("{0}", reader["workdesc"]) + " - " + String.Format("{0}", reader["fiyat"]) + "TL");
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlCommand command2 = new SqlCommand(genelQuery, sqlcon2);
            using (SqlDataReader reader = command2.ExecuteReader())
            {
                while (reader.Read())
                {
                    listBox1.Items.Add(String.Format("{0}", Convert.ToDateTime(reader["tarih"]).ToString("dd/MM/yyyy")) + " - [" + String.Format("{0}", reader["worktype"]) + "]- " + String.Format("{0}", reader["workdesc"]) + " - " + String.Format("{0}", reader["fiyat"]) + "TL");
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            SqlCommand command = new SqlCommand(queryGenel, sqlcon);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    listBox2.Items.Add(String.Format("{0}", reader["name"]));
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            SqlCommand command = new SqlCommand(queryMuhasebe, sqlcon);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    listBox2.Items.Add(String.Format("{0}", reader["name"]));
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            SqlCommand command = new SqlCommand(queryReji, sqlcon);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    listBox2.Items.Add(String.Format("{0}", reader["name"]));
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            SqlCommand command = new SqlCommand(queryRadyo, sqlcon);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    listBox2.Items.Add(String.Format("{0}", reader["name"]));
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            SqlCommand command = new SqlCommand(queryLed, sqlcon);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    listBox2.Items.Add(String.Format("{0}", reader["name"]));
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Properties.Form5 form = new Properties.Form5(this);
            form.Owner = this;
            form.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Properties.Form8 form = new Properties.Form8(this);
            form.Owner = this;
            form.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Bir iş seçin.");
            }
            else
            {
                string item = listBox1.SelectedItem.ToString();
                int pFrom = item.IndexOf("]- ") + "]- ".Length;
                int pTo = item.LastIndexOf(" - ");
                string result = item.Substring(pFrom, pTo - pFrom);
                string change = "UPDATE [Table] SET odendi = @odendi Where workdesc = '" + result + "'";
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(change, cnn);
                    cmd.Parameters.AddWithValue("@odendi", true);

                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                MessageBox.Show("İş ödemesi alındı. Ciroya yansıtıldı.");
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (listBox4.SelectedItem == null)
            {
                MessageBox.Show("Bir iş seçin.");
            }
            else
            {
                string item = listBox4.SelectedItem.ToString();
                int pFrom = item.IndexOf("]- ") + "]- ".Length;
                int pTo = item.LastIndexOf(" - ");
                string result = item.Substring(pFrom, pTo - pFrom);
                string change = "UPDATE [Table] SET odendi = @odendi Where workdesc = '" + result + "'";
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(change, cnn);
                    cmd.Parameters.AddWithValue("@odendi", true);
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                MessageBox.Show("Gider ödendi kaydı girildi.");
                listBox4.Items.Remove(listBox4.SelectedItem);
            }
        }
    }
}

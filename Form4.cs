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

namespace Athena_Browser_by_AthenaApps_v2._0.Properties
{
    public partial class Form4 : Form
    {

        Form parentform;
        public Form4()
        {
            InitializeComponent();

        }

        public Form4(Form x)
        {
            InitializeComponent();
            parentform = x;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Led");
            comboBox1.Items.Add("Reji");
            comboBox1.Items.Add("Radyo");
            comboBox1.Items.Add("Muhasebe");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if((comboBox1.SelectedIndex!=0 && comboBox1.SelectedIndex != 1 && comboBox1.SelectedIndex != 2 && comboBox1.SelectedIndex != 3 && comboBox1.SelectedIndex != 4))
            {
                MessageBox.Show("Lütfen işin kime gönderileceğini seçin.");
            }
            else if(textBox1.Text == "")
            {
                MessageBox.Show("Lütfen iş bilgisi girin.");
            }
            else
            {
                string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =E:\Users\Win7\source\repos\Athena Browser by AthenaApps v2.0\Athena Browser by AthenaApps v2.0\Properties\JobDatabase.mdf; Integrated Security = True; Connect Timeout = 30";
                string insert = "INSERT INTO [Table] (worktype, workdesc, fiyat, tarih, tamam, odendi) VALUES (@worktype, @workdesc, @fiyat, @tarih, @tamam, @odendi)";
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(insert, cnn);
                    cmd.Parameters.AddWithValue("@worktype", comboBox1.SelectedItem);
                    cmd.Parameters.AddWithValue("@workdesc", textBox1.Text);
                    cmd.Parameters.AddWithValue("@fiyat", textBox2.Text);
                    cmd.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);
                    if(comboBox1.SelectedItem.ToString() == "Muhasebe")
                    cmd.Parameters.AddWithValue("@tamam", true);
                    else
                    cmd.Parameters.AddWithValue("@tamam", false);
                    cmd.Parameters.AddWithValue("@odendi", false);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("İş gönderildi.");
                (this.Owner as Form1).listBox1.Items.Add(Convert.ToDateTime(dateTimePicker1.Value).ToString("dd/MM/yyyy") + " - [" + comboBox1.SelectedItem + "]- " + textBox1.Text + " - " + textBox2.Text + "TL");
                this.Close();
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

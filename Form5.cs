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
    public partial class Form5 : Form
    {
        Form x;
        string genelQuery = "Select name from [Table]";
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Users\Win7\source\repos\Athena Browser by AthenaApps v2.0\Athena Browser by AthenaApps v2.0\Properties\LoginDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Users\Win7\source\repos\Athena Browser by AthenaApps v2.0\Athena Browser by AthenaApps v2.0\Properties\LoginDatabase.mdf;Integrated Security=True;Connect Timeout=30";
        string insert = "INSERT INTO [Table] (kullanıcıadi, sifre, name, admin, led, radyoIzmir, muhasebe, reji) VALUES (@kullanıcıadi, @sifre, @name, @admin, @led, @radyoIzmir, @muhasebe, @reji)";
        public Form5()
        {
            InitializeComponent();
        }
        public Form5(Form parentform)
        {
            InitializeComponent();
            x = parentform;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(genelQuery, sqlcon);
            sqlcon.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    listBox1.Items.Add(String.Format("{0}", reader["name"]));
                    listBox2.Items.Add(String.Format("{0}", reader["name"]));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
            }
            else { 
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(insert, cnn);
                cmd.Parameters.AddWithValue("@kullanıcıadi", textBox2.Text);
                cmd.Parameters.AddWithValue("@sifre", textBox3.Text);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@admin", false);
                if (checkBox6.Checked)
                    cmd.Parameters.AddWithValue("@led", true);
                else
                    cmd.Parameters.AddWithValue("@led", false);
                if (checkBox10.Checked)
                    cmd.Parameters.AddWithValue("@radyoIzmir", true);
                else
                    cmd.Parameters.AddWithValue("@radyoIzmir", false);
                if (checkBox8.Checked)
                    cmd.Parameters.AddWithValue("@muhasebe", true);
                else
                    cmd.Parameters.AddWithValue("@muhasebe", false);
                if (checkBox7.Checked)
                    cmd.Parameters.AddWithValue("@reji", true);
                else
                    cmd.Parameters.AddWithValue("@reji", false);

                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Üye başarıyla eklendi. Artık bu üye admin tarafından görülebilir ve sisteme giriş yapıp işlerini görebilir.");
            (this.Owner as Form1).listBox2.Items.Add(textBox1.Text);
            listBox1.Items.Add(textBox1.Text);
            listBox2.Items.Add(textBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string delete = "DELETE FROM [Table] Where name = '" + listBox1.SelectedItem + "'";
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen çıkarılacak üye seçin.");
            }
            else
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(delete, cnn);
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                MessageBox.Show("Üye başarıyla çıkarıldı. Bu üye artık sisteme erişemez.");
                (this.Owner as Form1).listBox2.Items.Remove(listBox1.SelectedItem);
                listBox1.Items.Remove(listBox1.SelectedItem);
                listBox2.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string change = "UPDATE [Table] SET led = @led, radyoIzmir = @radyoIzmir, muhasebe = @muhasebe, reji = @reji Where name = '" + listBox2.SelectedItem + "'";
            if (listBox2.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir üye seçin.");
            }
            else
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(change, cnn);
                    if (checkBox1.Checked)
                        cmd.Parameters.AddWithValue("@led", true);
                    else
                        cmd.Parameters.AddWithValue("@led", false);
                    if (checkBox3.Checked)
                        cmd.Parameters.AddWithValue("@radyoIzmir", true);
                    else
                        cmd.Parameters.AddWithValue("@radyoIzmir", false);
                    if (checkBox2.Checked)
                        cmd.Parameters.AddWithValue("@muhasebe", true);
                    else
                        cmd.Parameters.AddWithValue("@muhasebe", false);
                    if (checkBox4.Checked)
                        cmd.Parameters.AddWithValue("@reji", true);
                    else
                        cmd.Parameters.AddWithValue("@reji", false);

                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                MessageBox.Show("Üye rolü başarıyla değiştirildi.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

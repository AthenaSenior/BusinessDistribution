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
    public partial class Form6 : Form
    {

        Form parentform;
        string a;
        bool led, radyoizmir, muhasebe, reji, admin, tamam, odendi;
        public Form6()
        {
            InitializeComponent();
        }
        public Form6(Form x)
        {
            InitializeComponent();
            parentform = x;
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            (this.Owner as Form1).listBox2.Items.Clear();
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Users\Win7\source\repos\Athena Browser by AthenaApps v2.0\Athena Browser by AthenaApps v2.0\Properties\LoginDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            string search = "Select * from [Table] Where KullanıcıAdi = '" + textBox1.Text.Trim() + "' and Sifre = '" + textBox2.Text.Trim() + "'";
            string name = "Select name from [Table] Where KullanıcıAdi = '" + textBox1.Text.Trim() + "'";
            string names = "Select name from [Table]";
            string ledQuery = "Select * from [Table] Where worktype = 'Led'  and tamam = 'false'";
            string radyoQuery = "Select * from [Table] Where worktype = 'Radyo'  and tamam = 'false'";
            string rejiQuery = "Select * from [Table] Where worktype = 'Reji'  and tamam = 'false'";
            string muhasebeQuery = "Select * from [Table] Where worktype = 'Muhasebe' and tamam = 'false'";
            string genelQuery = "Select * from [Table] Where tamam = 'false' and worktype <> 'Muhasebe'";
            string genelQueryforMuhasebe = "Select * from [Table]";
            string queryAdmin = "Select admin from [Table] Where KullanıcıAdi = '" + textBox1.Text.Trim() + "'";
            string queryLed = "Select led from [Table] Where KullanıcıAdi = '" + textBox1.Text.Trim() + "'";
            string queryRadyo = "Select radyoizmir from [Table] Where KullanıcıAdi = '" + textBox1.Text.Trim() + "'";
            string queryMuhasebe = "Select muhasebe from [Table] Where KullanıcıAdi = '" + textBox1.Text.Trim() + "'";
            string queryReji = "Select reji from [Table] Where KullanıcıAdi = '" + textBox1.Text.Trim() + "'";
            string queryOdemeBekleyen = "Select * from [Table] Where tamam = 'true' and odendi = 'false' and worktype <> 'Muhasebe'";
            string queryOdemeYapilacak = "Select * from [Table] Where odendi = 'false' and worktype = 'Muhasebe'";
            SqlDataAdapter sda = new SqlDataAdapter(search, sqlcon);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            sqlcon.Open();
            SqlCommand command = new SqlCommand(name,sqlcon);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    a = String.Format("{0}", reader["name"]);
                }
            }
            command = new SqlCommand(names, sqlcon);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while ((reader.Read()))
                {
                    (this.Owner as Form1).listBox2.Items.Add(String.Format("{0}", reader["name"]));
                }
            }
            command = new SqlCommand(queryAdmin, sqlcon);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    admin = reader.GetBoolean(reader.GetOrdinal("admin"));
                }
            }
            command = new SqlCommand(queryLed, sqlcon);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    led = reader.GetBoolean(reader.GetOrdinal("led"));
                }
            }
            command = new SqlCommand(queryRadyo, sqlcon);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    radyoizmir = reader.GetBoolean(reader.GetOrdinal("radyoizmir"));
                }
            }
            command = new SqlCommand(queryMuhasebe, sqlcon);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    muhasebe = reader.GetBoolean(reader.GetOrdinal("muhasebe"));
                }
            }
            command = new SqlCommand(queryReji, sqlcon);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    reji = reader.GetBoolean(reader.GetOrdinal("reji"));
                }
            }
            sqlcon.Close();


            SqlConnection sqlcon2 = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =E:\Users\Win7\source\repos\Athena Browser by AthenaApps v2.0\Athena Browser by AthenaApps v2.0\Properties\JobDatabase.mdf; Integrated Security = True; Connect Timeout = 30");
            SqlCommand command2 = new SqlCommand(genelQuery, sqlcon2);

            if (dataTable.Rows.Count == 1)
            {
                sqlcon2.Open();
                (this.Owner as Form1).button4.Visible = false;
                (this.Owner as Form1).button5.Visible = false;
                (this.Owner as Form1).button2.Visible = true;
                (this.Owner as Form1).button6.Visible = false;
                (this.Owner as Form1).button9.Visible = false;
                (this.Owner as Form1).label1.Visible = true;
                (this.Owner as Form1).label1.Text = a;

                if (admin)
                {
                    (this.Owner as Form1).button1.Visible = true;
                    (this.Owner as Form1).button3.Visible = true;
                    (this.Owner as Form1).button7.Visible = true;
                    (this.Owner as Form1).button8.Visible = true;
                    (this.Owner as Form1).button10.Visible = true;
                    (this.Owner as Form1).button11.Visible = true;
                    (this.Owner as Form1).button12.Visible = true;
                    (this.Owner as Form1).button13.Visible = true;
                    (this.Owner as Form1).button14.Visible = true;
                    (this.Owner as Form1).button15.Visible = true;
                    (this.Owner as Form1).button16.Visible = true;
                    (this.Owner as Form1).button17.Visible = true;
                    (this.Owner as Form1).button18.Visible = true;
                    (this.Owner as Form1).button19.Visible = true;
                    (this.Owner as Form1).button20.Visible = true;
                    (this.Owner as Form1).listBox1.Visible = true;
                    (this.Owner as Form1).listBox2.Visible = true;
                    (this.Owner as Form1).button21.Visible = true;
                    (this.Owner as Form1).button8.Visible = true;
                    (this.Owner as Form1).label5.Visible = true;
                    (this.Owner as Form1).label6.Visible = true;
                    (this.Owner as Form1).label7.Visible = true;
                    (this.Owner as Form1).richTextBox1.Visible = true;
                    using (SqlDataReader reader = command2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            (this.Owner as Form1).listBox1.Items.Add(String.Format("{0}", Convert.ToDateTime(reader["tarih"]).ToString("dd/MM/yyyy")) + " - [" + String.Format("{0}", reader["worktype"]) + "]- " + String.Format("{0}", reader["workdesc"]) + " - " + String.Format("{0}", reader["fiyat"]) + "TL");
                        }
                    }
                }

                if(led)
                {
                    (this.Owner as Form1).label5.Visible = true;
                    (this.Owner as Form1).label5.Text = "İşlerim";
                    (this.Owner as Form1).listBox1.Visible = true;
                    command2 = new SqlCommand(ledQuery, sqlcon2);
                    using (SqlDataReader reader = command2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            (this.Owner as Form1).listBox1.Items.Add(String.Format("{0}", Convert.ToDateTime(reader["tarih"]).ToString("dd/MM/yyyy")) + "[LED SES IŞIK] - " + String.Format("{0}", reader["workdesc"]));
                        }
                    }
                }
                if(reji)
                {
                    (this.Owner as Form1).label5.Visible = true;
                    (this.Owner as Form1).label5.Text = "İşlerim";
                    (this.Owner as Form1).listBox1.Visible = true;
                    command2 = new SqlCommand(rejiQuery, sqlcon2);
                    using (SqlDataReader reader = command2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            (this.Owner as Form1).listBox1.Items.Add(String.Format("{0}", Convert.ToDateTime(reader["tarih"]).ToString("dd/MM/yyyy")) + "[REJI] - " + String.Format("{0}", reader["workdesc"]));
                        }
                    }
                }
                if(radyoizmir)
                {
                    (this.Owner as Form1).label5.Visible = true;
                    (this.Owner as Form1).label5.Text = "İşlerim";
                    (this.Owner as Form1).listBox1.Visible = true;
                    command2 = new SqlCommand(radyoQuery, sqlcon2);
                    using (SqlDataReader reader = command2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            (this.Owner as Form1).listBox1.Items.Add(String.Format("{0}", Convert.ToDateTime(reader["tarih"]).ToString("dd/MM/yyyy")) + "[RADYO] - " + String.Format("{0}", reader["workdesc"]));
                        }
                    }
                }
                if(muhasebe)
                {
                    float sum = 0, sum2 = 0;
                    (this.Owner as Form1).label5.Visible = true;
                    (this.Owner as Form1).label5.Text = "Ödeme bekleyen tamamlanmış işler";
                    (this.Owner as Form1).listBox1.Visible = true;
                    (this.Owner as Form1).listBox4.Visible = true;
                    (this.Owner as Form1).label6.Visible = true;
                    (this.Owner as Form1).label6.Text = "Giderler";
                    (this.Owner as Form1).button23.Visible = true;
                    (this.Owner as Form1).button22.Visible = true;
                    command2 = new SqlCommand(queryOdemeBekleyen, sqlcon2);
                    using (SqlDataReader reader = command2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            (this.Owner as Form1).listBox1.Items.Add(String.Format("{0}", Convert.ToDateTime(reader["tarih"]).ToString("dd/MM/yyyy")) + " - [" + String.Format("{0}", reader["worktype"]) + "]- " + String.Format("{0}", reader["workdesc"]) + " - " + String.Format("{0}", reader["fiyat"]) + "TL");
                        }
                    }
                    command2 = new SqlCommand(queryOdemeYapilacak, sqlcon2);
                    using (SqlDataReader reader = command2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            (this.Owner as Form1).listBox4.Items.Add(String.Format("{0}", Convert.ToDateTime(reader["tarih"]).ToString("dd/MM/yyyy")) + " - [" + String.Format("{0}", reader["worktype"]) + "]- " + String.Format("{0}", reader["workdesc"]) + " - " + String.Format("{0}", reader["fiyat"]) + "TL");
                        }
                    }
                    (this.Owner as Form1).button21.Visible = true;
                    (this.Owner as Form1).button21.Location = new Point(730, 492);
                }

                this.Close();
            }
            else
               MessageBox.Show("Bilgiler yanlış");
        }
    }
}

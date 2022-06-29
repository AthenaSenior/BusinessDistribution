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
    public partial class Form8 : Form
    {

        int uyeSayisi = 0, counter = 0, yilCounter = 0, ayCounter = 0;
        float counter2 = 0, yilCounter2=0, ayCounter2 = 0, counter3 = 0, yilCounter3 = 0, ayCounter3 = 0;
        Form x;
        string queryLed = "Select name from [Table] Where led = 'true'";
        static string queryGenel = "Select name from [Table]";
        string queryRadyo = "Select name from [Table] Where radyoizmir = 'true'";
        string queryReji = "Select name from [Table] Where reji = 'true'";
        string queryMuhasebe = "Select name from [Table] Where muhasebe = 'true'";


        string ledQuery = "Select * from [Table] Where worktype = 'Led'";
        string radyoQuery = "Select * from [Table] Where worktype = 'Radyo'";
        string rejiQuery = "Select * from [Table] Where worktype = 'Reji'";
        static string muhasebeQuery = "Select * from [Table] Where worktype = 'Muhasebe' and odendi = 'true'";
        static string queryTamam = "Select * from [Table] Where tamam = 'true' and worktype <> 'Muhasebe'";
        static string queryOdendi = "Select * from [Table] Where odendi = 'true' and worktype <> 'Muhasebe'";
        static SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Users\Win7\source\repos\Athena Browser by AthenaApps v2.0\Athena Browser by AthenaApps v2.0\Properties\LoginDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        static SqlConnection sqlcon2 = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =E:\Users\Win7\source\repos\Athena Browser by AthenaApps v2.0\Athena Browser by AthenaApps v2.0\Properties\JobDatabase.mdf; Integrated Security = True; Connect Timeout = 30");
        SqlCommand command = new SqlCommand(queryGenel, sqlcon);

        private void label28_Click(object sender, EventArgs e)
        {

        }

        SqlCommand command2 = new SqlCommand(queryTamam, sqlcon2);
        SqlCommand command3 = new SqlCommand(queryOdendi, sqlcon2);
        SqlCommand command4 = new SqlCommand(muhasebeQuery, sqlcon2);
        public Form8(Form x)
        {
            InitializeComponent();
            this.x = x;
            sqlcon.Open();
            sqlcon2.Open();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    uyeSayisi++;
                }
            }
            label27.Text = uyeSayisi.ToString();

            using (SqlDataReader reader = command2.ExecuteReader())
            {
                DateTime dt2 = DateTime.Parse(String.Format("{0}", Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy")));
                while (reader.Read())
                {
                    DateTime dt1 = DateTime.Parse(String.Format("{0}", Convert.ToDateTime(reader["tarih"]).ToString("dd/MM/yyyy")));
                    if (dt1 == dt2)
                        counter++;
                    if (dt1.Month == dt2.Month)
                        ayCounter++;
                    if (dt1.Year == dt2.Year)
                        yilCounter++;
                }
            }
            label18.Text = counter.ToString();
            label19.Text = ayCounter.ToString();
            label20.Text = yilCounter.ToString();
            using (SqlDataReader reader = command3.ExecuteReader())
            {
                DateTime dt2 = DateTime.Parse(String.Format("{0}", Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy")));
                while (reader.Read())
                {
                    DateTime dt1 = DateTime.Parse(String.Format("{0}", Convert.ToDateTime(reader["tarih"]).ToString("dd/MM/yyyy")));
                    if (dt1 == dt2)
                        counter2 += (float)reader.GetDouble(2);
                    if (dt1.Month == dt2.Month)
                        ayCounter2 += (float)reader.GetDouble(2);
                    if (dt1.Year == dt2.Year)
                        yilCounter2 += (float)reader.GetDouble(2);
                }
            }
            label21.Text = counter2.ToString() +" TL";
            label22.Text = ayCounter2.ToString() + " TL";
            label23.Text = yilCounter2.ToString() + " TL";
            using (SqlDataReader reader = command4.ExecuteReader())
            {
                DateTime dt2 = DateTime.Parse(String.Format("{0}", Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy")));
                while (reader.Read())
                {
                    DateTime dt1 = DateTime.Parse(String.Format("{0}", Convert.ToDateTime(reader["tarih"]).ToString("dd/MM/yyyy")));
                    if (dt1 == dt2)
                        counter3 += (float)reader.GetDouble(2);
                    if (dt1.Month == dt2.Month)
                        ayCounter3 += (float)reader.GetDouble(2);
                    if (dt1.Year == dt2.Year)
                        yilCounter3 += (float)reader.GetDouble(2);
                }
            }
            label24.Text = counter3.ToString() + " TL";
            label25.Text = ayCounter3.ToString() + " TL";
            label26.Text = yilCounter3.ToString() + " TL";
            label28.Text = (yilCounter2 - yilCounter3).ToString() + " TL";
            sqlcon.Close();
            sqlcon2.Close();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}

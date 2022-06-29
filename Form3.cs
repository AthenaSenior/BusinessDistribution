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
    public partial class Form3 : Form
    {

        Form x;
        string genelQuery = "Select * from [Table] where worktype <> 'Muhasebe'";
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(Form parentForm)
        {
            InitializeComponent();
            x = parentForm;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SqlConnection sqlcon2 = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =E:\Users\Win7\source\repos\Athena Browser by AthenaApps v2.0\Athena Browser by AthenaApps v2.0\Properties\JobDatabase.mdf; Integrated Security = True; Connect Timeout = 30");
            SqlCommand command2 = new SqlCommand(genelQuery, sqlcon2);
            sqlcon2.Open();
            using (SqlDataReader reader = command2.ExecuteReader())
            {

                DateTime dt2 = DateTime.Parse(String.Format("{0}", monthCalendar1.SelectionStart.ToString("dd/MM/yyyy")));
                while (reader.Read())
                {
                    DateTime dt1 = DateTime.Parse(String.Format("{0}", Convert.ToDateTime(reader["tarih"]).ToString("dd/MM/yyyy")));
                    if (dt1 == dt2)
                    {
                       listBox1.Items.Add(String.Format("{0}", Convert.ToDateTime(reader["tarih"]).ToString("dd/MM/yyyy")) + " - [" + String.Format("{0}", reader["worktype"]) + "]- " + String.Format("{0}", reader["workdesc"]));
                    }
                    }
            }
            label5.Text = monthCalendar1.SelectionStart.ToString("d");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void isGunleri()
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

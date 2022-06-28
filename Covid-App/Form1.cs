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

namespace Covid_App
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=sqlserver.dynamicdna.co.za;Initial Catalog=Covid-App-Lerato;User ID=BBD;Password=123");
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (fname.Text.Length > 0 && idnum.Text.Length > 0 && pnumber.Text.Length > 0 && addr.Text.Length > 0)
            {

                try
                {
                    con.Open();
                    var mm = fname;
                    SqlCommand com = new SqlCommand("INSERT INTO Patient VALUES ('"+ fname.Text +"', '"+ idnum.Text +"', '"+ gender.SelectedItem +"', '"+ pnumber.Text +"', '"+ addr.Text +"')", con);
                    try
                    {
                        com.ExecuteNonQuery();
                        MessageBox.Show("Patient Registered!");
                        fname.Clear();
                        idnum.Clear();
                        gender.SelectedIndex = -1;
                        pnumber.Clear();
                        addr.Clear();
                    }
                    catch (Exception x)
                    {

                        MessageBox.Show("Failed to register patient" + x); ;
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to connect to database" + ex);


                }

            }
            else
            {
                MessageBox.Show("Fill in all fields!");
                fname.Clear();
                idnum.Clear();
                gender.SelectedIndex = -1;
                pnumber.Clear();
                addr.Clear();
                fname.Focus();
            }
            
          
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fname.Clear();
            idnum.Clear();
            gender.SelectedIndex = -1;
            pnumber.Clear();
            addr.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

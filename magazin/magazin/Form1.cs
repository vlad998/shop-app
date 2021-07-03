using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace magazin
{
    public partial class Form1 : Form
    {
        public string utilizatori;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//logare
        {
            int ok = 0;
            string connstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                "magazin.accdb"+ ";Persist Security Info=False";
            OleDbConnection conn = new OleDbConnection(connstring);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from utilizator", conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                if (textBox1.Text == dr[0].ToString())
                {
                    if (textBox2.Text == dr[2].ToString())//logare
                    {
                        utilizatori = dr[0].ToString();
                        vanzari frm2 = new vanzari(utilizatori);////////////////////////
                        frm2.Show();
                        ok = 1;
                        return;
                    }
                }
            }
            if (ok == 0)
            {
                MessageBox.Show("reintrodu datele");
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
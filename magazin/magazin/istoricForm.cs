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
    public partial class istoricForm : Form
    {
        int i = 0;
        public istoricForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)//listbox
        {
            int j = dataGridView1.Rows.Count - 1;
            int suma = 0;
            while (j > 0)
            {
                dataGridView1.Rows.Remove(dataGridView1.Rows[j - 1]);//sterge datele vechi
                j--;
            }

            string selectat = listBox1.SelectedItem.ToString();
            if (selectat == null)
                return;
            string connstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='istoric vanzari1.accdb';Persist Security Info=False";
            OleDbConnection conn = new OleDbConnection(connstring);
            conn.Open();
            OleDbCommand cmd3 = new OleDbCommand("SELECT *  FROM istoric", conn);
            OleDbDataReader dr = cmd3.ExecuteReader();
            i = 0;
            while (dr.Read())
            {
                if (dr[4].ToString() == selectat)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr[0].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = dr[1].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = dr[2].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = dr[3].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = dr[4].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = dr[5].ToString();

                    suma +=int.Parse(dr[3].ToString());
                                   
                    i++;
                }
            }
            dr.Close();
            conn.Close();
            textBox1.Text ="Valoare Factura:"+ suma.ToString()+" LEI";
        }

        private void istoricForm_Load(object sender, EventArgs e)//load
        {
           
            string connstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='istoric vanzari1.accdb';Persist Security Info=False";
            OleDbConnection conn = new OleDbConnection(connstring);
            conn.Open();
            OleDbCommand cmd3 = new OleDbCommand("SELECT DISTINCT id_factura FROM istoric", conn);
            OleDbDataReader dr = cmd3.ExecuteReader();

           
            while(dr.Read())
            {
                    listBox1.Items.Add (dr[0].ToString());   
   
            }
            dr.Close();
            conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rapoarte r = new rapoarte();
            r.Show();
        }
    }
}

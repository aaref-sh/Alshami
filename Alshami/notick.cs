using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alshami
{
    public partial class notick : Form
    {
        public notick()
        {
            InitializeComponent();
        }
        private SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Muhammad\source\repos\Alshami\Alshami\maindb.mdf;Integrated Security = True");

        private void Btnsearchnotick_Click(object sender, EventArgs e)
        {

            lvnotick.Items.Clear();
            if (tbnamenotick.Text != "")
            {
                string query = "select * from main inner join models on main.type = id where name like N'" + tbnamenotick.Text + "%'";
                
                SqlDataAdapter ada = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    ListViewItem listitem = new ListViewItem(dr["num"].ToString());
                    listitem.SubItems.Add(dr["name"].ToString());
                    listitem.SubItems.Add(dr["typename"].ToString());
                    listitem.SubItems.Add(Convert.ToDateTime(dr["date"]).ToString("yyyy/MM/dd  hh:mm tt"));
                    string s = "✔";
                    if (dr["done"].ToString() == "") s = "❌";
                    listitem.SubItems.Add(s);
                    lvnotick.Items.Add(listitem);
                }
            }
        }

        private void Lvnotick_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = "";
            if (lvnotick.SelectedItems.Count != 0)
                s = lvnotick.Items[lvnotick.FocusedItem.Index].SubItems[0].Text;
            tbticknotick.Text = s;
        }

        private void Btndonenotick_Click(object sender, EventArgs e)
        {
            if (tbname2notick.Text != "" && tbticknotick.Text!="")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update main set done = cast(@date as datetime) where num = " + tbticknotick.Text, conn);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.ExecuteNonQuery();
                conn.Close();
                conn.Open();
                cmd = new SqlCommand("INSERT into em (num , name , ident) values ('"+tbticknotick.Text+"',N'"+tbname2notick.Text+"','"+tbidnotick.Text+"')",conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("تم التسليم الى: " + tbname2notick.Text);
            }
        }
    }
}

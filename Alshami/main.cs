using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Alshami
{
    public partial class main : Form
    {
        private SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Muhammad\source\repos\Alshami\Alshami\maindb.mdf;Integrated Security = True");
        public static string tic;
        tick t = new tick();
        private PrintDocument printDocument1 = new PrintDocument();


        #region mover
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion
        public main()
        {
            InitializeComponent();
            // this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        #region sizer
        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;
        int Mx;
        int My;
        int Sw;
        int Sh;

        bool mov;
        void SizerMouseDown(object sender, MouseEventArgs e)
        {
            mov = true;
            My = MousePosition.Y;
            Mx = MousePosition.X;
            Sw = Width;
            Sh = Height;
        }

        void SizerMouseMove(object sender, MouseEventArgs e)
        {
            if (mov == true)
            {
                Width = MousePosition.X - Mx + Sw;
                Height = MousePosition.Y - My + Sh;
            }
        }

        private void sizermousemoveh(object sender, MouseEventArgs e)
        {
            if (mov == true)
                Height = MousePosition.Y - My + Sh;
        }

        private void sizermousemovew(object sender, MouseEventArgs e)
        {
            if (mov == true)
                Width = MousePosition.X - Mx + Sw;
        }
        private void Panel9_MouseEnter(object sender, EventArgs e)
        {
            panel9.Cursor = Cursors.SizeNS;
        }

        private void Label20_MouseEnter(object sender, EventArgs e)
        {
            label20.Cursor = Cursors.SizeWE;
        }
        void SizerMouseUp(object sender, MouseEventArgs e)
        {
            mov = false;
        }
        #endregion

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lock_Click(object sender, EventArgs e)
        {
            this.Hide();
            login l = new login();
            l.ShowDialog();
            this.Close();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            lticknum.Text = "";
            int x = 0;
            if (cbglass.Checked) x = 1;
            if (tbname.Text != "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO main (name, phone,type,date,glass,done) VALUES (@name, @phone,@type,@date,@glass,NULL)", conn);
                cmd.Parameters.AddWithValue("@name", tbname.Text);
                cmd.Parameters.AddWithValue("@phone", tbphone.Text);
                cmd.Parameters.AddWithValue("@type", cbtype.SelectedIndex + 1);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@glass", x);
                cmd.ExecuteNonQuery();
                conn.Close();
                tbname.Text = tbphone.Text = "";
                cbglass.CheckState = CheckState.Unchecked;
                SqlDataAdapter ada = new SqlDataAdapter("select * from main", conn);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                mainDataGridView.DataSource = dt;
                DataRow dr = dt.Rows[dt.Rows.Count - 1];
                tic = dr["num"].ToString();
                lticknum.Text = tic;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'maindbDataSet.models' table. You can move, or remove it, as needed.
            this.modelsTableAdapter.Fill(this.maindbDataSet.models);
            // TODO: This line of code loads data into the 'maindbDataSet.main' table. You can move, or remove it, as needed.
            this.mainTableAdapter.Fill(this.maindbDataSet.main);

            Timer t = new Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();

        }
        private void t_Tick(object sender, EventArgs e)
        {
            ltime.Text = DateTime.Now.ToString("hh:mm tt");
        }
        void huh()
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbtnum.Text, "[^0-9]"))
            {
                tbtnum.Text = tbtnum.Text.Remove(tbtnum.Text.Length - 1);
            }
            string num = tbtnum.Text;
            lglass.Visible = false;
            ldelivered.Visible = false;
            tbgetnam.Text = tbgettype.Text = tbgetdate.Text = tbgettime.Text = "";

            string selectSql = "select * from main INNER JOIN models ON main.type = models.id where num =" + num;
            if (num == "") selectSql = "select * from main where num = 0";
            SqlCommand com = new SqlCommand(selectSql, conn);

            try
            {
                conn.Open();

                using (SqlDataReader read = com.ExecuteReader())
                {
                    while (read.Read())
                    {
                        tbgetnam.Text = (read["name"].ToString());
                        int type = Int32.Parse(read["type"].ToString());
                        tbgettype.Text = read["typename"].ToString();
                        tbgetdate.Text = (Convert.ToDateTime(read["date"]).ToString("yyyy/MM/dd"));
                        tbgettime.Text = (Convert.ToDateTime(read["date"]).ToString("hh:mm tt"));
                        if (read["done"].ToString() != "") ldelivered.Visible = true;
                        if (read["glass"].ToString() == "True") lglass.Visible = true;
                    }
                }
            }
            finally
            {
                conn.Close();
            }

        }
        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            huh();
        }

        private void Tbphone_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbphone.Text, "[^0-9]"))
            {
                tbphone.Text = tbphone.Text.Remove(tbphone.Text.Length - 1);
            }
        }
        void doit_bitch()
        {
            lvdate.Items.Clear();
            lrecords.Text = "0";
            string st = dtpstart.Value.ToString("yyyy/MM/dd"), en = dtpend.Value.ToString("yyyy/MM/dd"), t = "date";
            if (rbddate.Checked) t = "done";
            string query = "select * from main inner join models on main.type = id where " + t + " between '" + st + "' and '" + en + "'";
            if (cbthistypeonly.Checked) query += " and type = '" + (cbtypeonly.SelectedIndex + 1) + "'";
            if (rbdel.Checked) query += " and done is not null";
            else if (rbnot.Checked) query += " and done is null";
            SqlDataAdapter ada = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            int j = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["num"].ToString());
                listitem.SubItems.Add(dr["name"].ToString());
                listitem.SubItems.Add(dr["phone"].ToString());
                listitem.SubItems.Add(dr["typename"].ToString());
                listitem.SubItems.Add(Convert.ToDateTime(dr["date"]).ToString("yyyy/MM/dd  hh:mm tt"));
                string s = "تم التسليم";
                if (dr["done"].ToString() == "") s = "لم تسلّم";
                listitem.SubItems.Add(s);
                lvdate.Items.Add(listitem);
                j++;
                lrecords.Text = j.ToString();
            }
            foreach (ListViewItem l in lvdate.Items)
            {
                l.SubItems[0].ForeColor = Color.Blue;
                l.SubItems[5].ForeColor = Color.Green;
                if (l.SubItems[5].Text[0] == 'ل') l.SubItems[5].ForeColor = Color.Red;
                l.UseItemStyleForSubItems = false;
            }
        }
        private void Btnview_Click(object sender, EventArgs e)
        {
            doit_bitch();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbthistypeonly.Checked) cbtypeonly.Enabled = true;
            else cbtypeonly.Enabled = false;
        }

        void tbh()
        {
            lvtype.Items.Clear();
            ltyperecord.Text = "0";
            string query = "select * from main inner join models on main.type = id where type = '" + (cmboxtype1.SelectedIndex + 1) + "'";
            if (cboxadd.Checked) query += " or type = '" + (cmboxtype2.SelectedIndex + 1) + "'";
            if (rbnottype.Checked) query += " and done is null";
            else if (rbdonetype.Checked) query += " and done is not null";
            SqlDataAdapter ada = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            int j = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["num"].ToString());
                listitem.SubItems.Add(dr["name"].ToString());
                listitem.SubItems.Add(dr["phone"].ToString());
                listitem.SubItems.Add(dr["typename"].ToString());

                listitem.SubItems.Add(Convert.ToDateTime(dr["date"]).ToString("yyyy/MM/dd  hh:mm tt"));
                string s = "تم التسليم";
                if (dr["done"].ToString() == "") s = "لم تسلّم";
                listitem.SubItems.Add(s);
                lvtype.Items.Add(listitem);
                j++;
                ltyperecord.Text = j.ToString();
            }
            foreach (ListViewItem l in lvtype.Items)
            {
                l.SubItems[0].ForeColor = Color.Blue;
                l.SubItems[5].ForeColor = Color.Green;
                if (l.SubItems[5].Text[0] == 'ل') l.SubItems[5].ForeColor = Color.Red;
                l.UseItemStyleForSubItems = false;
            }
        }
        private void Cboxadd_CheckedChanged(object sender, EventArgs e)
        {
            if (cmboxtype2.Enabled) cmboxtype2.Enabled = false;
            else cmboxtype2.Enabled = true;
            tbh();

        }

        private void Cmboxtype1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbh();
        }

        private void Cmboxtype2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbh();
        }

        private void Btnquery_Click(object sender, EventArgs e)
        {
            try
            {
                string query = tbquery.Text;
                SqlDataAdapter ada = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                dgvquery.DataSource = dt;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "there is an error you motherfucker ");
            }
        }

        private void CaptureScreen()
        {
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("80 x 80 mm", 415, 415);
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
        }

        private void printDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(t.pictureBox1.Image, new Point(0, 0));
            using (Font font1 = new Font("Comic Sans MS", 75, GraphicsUnit.Point))
            {
                Rectangle rect1 = new Rectangle(20, 100, 400, 150);
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(tic, font1, Brushes.Black, rect1, stringFormat);
            }
            e.Graphics.DrawString(DateTime.Now.ToString("yyyy/MM/dd - hh:mm tt"), new Font("Comic Sans MS", 14), new SolidBrush(Color.Black), 110, 260);
        }

        private void Tbclname_TextChanged(object sender, EventArgs e)
        {
            lvname.Items.Clear();
            lnamerecord.Text = "0";
            if (tbclname.Text != "")
            {
                string query = "select * from main inner join models on main.type = id where name like N'" + tbclname.Text + "%'";
                if (rbnotname.Checked) query += " and done is null";
                else if (rbdonename.Checked) query += " and done is not null";
                SqlDataAdapter ada = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                int j = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    ListViewItem listitem = new ListViewItem(dr["num"].ToString());
                    listitem.SubItems.Add(dr["name"].ToString());
                    listitem.SubItems.Add(dr["phone"].ToString());
                    listitem.SubItems.Add(dr["typename"].ToString());

                    listitem.SubItems.Add(Convert.ToDateTime(dr["date"]).ToString("yyyy/MM/dd hh:mm tt"));
                    string s = "تم التسليم";
                    if (dr["done"].ToString() == "") s = "لم تسلّم";
                    listitem.SubItems.Add(s);
                    lvname.Items.Add(listitem);
                    j++;
                    lnamerecord.Text = j.ToString();
                }
                foreach (ListViewItem l in lvname.Items)
                {
                    l.SubItems[0].ForeColor = Color.Blue;
                    l.SubItems[5].ForeColor = Color.Green;
                    if (l.SubItems[5].Text[0] == 'ل') l.SubItems[5].ForeColor = Color.Red;
                    l.UseItemStyleForSubItems = false;
                }
            }
        }

        private void Rbbothname_CheckedChanged(object sender, EventArgs e)
        {
            Tbclname_TextChanged(sender, e);
        }
        private void Rbdonename_CheckedChanged(object sender, EventArgs e)
        {
            Tbclname_TextChanged(sender, e);
        }

        private void Rbnotname_CheckedChanged(object sender, EventArgs e)
        {
            Tbclname_TextChanged(sender, e);
        }

        private void Rbbothtype_CheckedChanged(object sender, EventArgs e)
        {
            tbh();
        }

        private void Rbdonetype_CheckedChanged(object sender, EventArgs e)
        {
            tbh();
        }

        private void Rbnottype_CheckedChanged(object sender, EventArgs e)
        {
            tbh();
        }

        private void PictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxrezize.Cursor = Cursors.SizeNWSE;
        }

        private void PictureBoxrezize_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Size = new Size(936, 533);
        }

        private void MainBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.mainBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.maindbDataSet);

        }

        private void del_Click(object sender, EventArgs e)
        {
            if (tbgetnam.Text != "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update main set done = cast(@date as datetime) where num = " + tbtnum.Text, conn);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.ExecuteNonQuery();
                conn.Close();

                ldelivered.Visible = true;
            }
        }

        private void Lvname_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lvname.SelectedItems.Count != 0)
            {
                string s = lvname.Items[lvname.FocusedItem.Index].SubItems[5].Text;
                if (s[0] == 'ت')
                {
                    string num = lvname.Items[lvname.FocusedItem.Index].SubItems[0].Text;
                    SqlCommand command = new SqlCommand("select done from main where num = " + num);
                    command.Connection = conn;
                    conn.Open();
                    DateTime dt = Convert.ToDateTime(command.ExecuteScalar());
                    conn.Close();
                    lvname.Items[lvname.FocusedItem.Index].SubItems[5].Text = dt.ToString("yyyy/MM/dd hh:mm tt");
                }
            }
        }

        private void Lvtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvtype.SelectedItems.Count != 0)
            {
                string s = lvtype.Items[lvtype.FocusedItem.Index].SubItems[5].Text;
                if (s[0] == 'ت')
                {
                    string num = lvtype.Items[lvtype.FocusedItem.Index].SubItems[0].Text;
                    SqlCommand command = new SqlCommand("select done from main where num = " + num);
                    command.Connection = conn;
                    conn.Open();
                    DateTime dt = Convert.ToDateTime(command.ExecuteScalar());
                    conn.Close();
                    lvtype.Items[lvtype.FocusedItem.Index].SubItems[5].Text = dt.ToString("yyyy/MM/dd hh:mm tt");
                }
            }
        }

        private void Lvdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvdate.SelectedItems.Count != 0)
            {
                string s = lvdate.Items[lvdate.FocusedItem.Index].SubItems[5].Text;
                if (s[0] == 'ت')
                {
                    string num = lvdate.Items[lvdate.FocusedItem.Index].SubItems[0].Text;
                    SqlCommand command = new SqlCommand("select done from main where num = " + num);
                    command.Connection = conn;
                    conn.Open();
                    DateTime dt = Convert.ToDateTime(command.ExecuteScalar());
                    conn.Close();
                    lvdate.Items[lvdate.FocusedItem.Index].SubItems[5].Text = dt.ToString("yyyy/MM/dd hh:mm tt");
                }
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbcphone.Text, "[^0-9]"))
            {
                tbcphone.Text = tbcphone.Text.Remove(tbcphone.Text.Length - 1);
            }
        }

        private void Btnsearchname_Click(object sender, EventArgs e)
        {
            if (tbphone.Text != "")
            {
                SqlCommand command = new SqlCommand("select name from main where phone = " + tbcphone.Text, conn);
                conn.Open();
                tbcname.Text = (string)command.ExecuteScalar();
                conn.Close();
            }
        }

        private void Btncphonesearch_Click(object sender, EventArgs e)
        {
            SqlDataAdapter ada = new SqlDataAdapter("select name , phone from main where name like N'" + tbcnamesearch.Text + "%'", conn);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem listitem = new ListViewItem(dr["name"].ToString());
                listitem.SubItems.Add(dr["phone"].ToString());
                lvphone.Items.Add(listitem);
            }
        }

        private void Rbddate_CheckedChanged(object sender, EventArgs e)
        {
            rbdel.Checked = true;
        }

        private void Rbrdate_CheckedChanged(object sender, EventArgs e)
        {
            rbboth.Checked = true;
        }

        private void Button2_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons == MouseButtons.Right)
            {
                notick f = new notick();
                f.Show();
            }
        }

        private void Btnsearchnotick_Click(object sender, EventArgs e)
        {
            ptick.Visible = false;
            tbnotickname.Text = tbnotickident.Text = tbnotickname2.Text = tbnoticktype.Text = tbnotickdate.Text = tbnotickdone.Text = "";
            tbnametick.Text = tbtypetick.Text = tbdatetick.Text = tbtimetick.Text = tbdone1tick.Text = tbdone2tick.Text = "";
            lnotdone.Visible = false;
            if (tbnotickticknum.Text != "")
            {
                SqlCommand cmd = new SqlCommand("select * from em inner join (select * from main inner join models on type = id) as ds on ds.num = em.num where em.num = " + tbnotickticknum.Text, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        tbnotickname.Text = dr[4].ToString();
                        tbnotickident.Text = dr[2].ToString();
                        tbnotickname2.Text = dr[1].ToString();
                        tbnoticktype.Text = dr[11].ToString();
                        tbnotickdate.Text = Convert.ToDateTime(dr[7]).ToString("yyyy/MM/dd - hh:mm tt");
                        tbnotickdone.Text = Convert.ToDateTime(dr[9]).ToString("yyyy/MM/dd - hh:mm tt");


                    }
                }
                conn.Close();


                if (tbnotickname.Text == "")
                {
                    cmd = new SqlCommand("select * from main inner join models on type = id where num = " + tbnotickticknum.Text, conn);
                    conn.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            if (dr["done"].ToString() != "")
                            {
                                tbnametick.Text = dr["name"].ToString();
                                tbtypetick.Text = dr["typename"].ToString();
                                tbdatetick.Text = Convert.ToDateTime(dr["date"]).ToString("yyyy/MM/dd");
                                tbtimetick.Text = Convert.ToDateTime(dr["date"]).ToString("hh:mm tt");
                                tbdone1tick.Text = Convert.ToDateTime(dr["done"]).ToString("yyyy/MM/dd");
                                tbdone2tick.Text = Convert.ToDateTime(dr["done"]).ToString("hh:mm tt");
                                ptick.Visible = true;
                            }
                            else lnotdone.Visible = true;
                        }
                    }
                    conn.Close();
                }
            }
        }

        private void Tbnotickticknum_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(tb.Text, "[^0-9]"))
            {
                tb.Text = tb.Text.Remove(tb.Text.Length - 1);
            }
        }

        private void Lticknum_Click(object sender, EventArgs e)
        {
            lticknum.Text = "";
        }

        private void PictureBox1_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox) sender;
            pb.BackColor = Color.FromArgb(75, 120, 255);
        }

        private void PictureBox1_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox) sender;
            pb.BackColor = Color.Transparent;
        }

        private void picture_box_clic_minimize(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}

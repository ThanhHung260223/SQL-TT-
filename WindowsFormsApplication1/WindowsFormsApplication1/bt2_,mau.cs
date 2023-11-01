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

namespace WindowsFormsApplication1
{
    public partial class bt2__mau : Form
    {
        private SqlConnection connect;

        string _connectectionString = "server=.; database=QL_SINHVIEN;integrated security=true";
        public bt2__mau()
        {
            InitializeComponent();
        }
        private void comboBox1_()
        {
            connect = new SqlConnection(_connectectionString);
            connect.Open();
            string selectString = "select * from KHOA";
            SqlCommand cmd = new SqlCommand(selectString, connect);
            SqlDataReader rd = cmd.ExecuteReader();
            while(rd.Read())
            {
                comboBox1.Items.Add(rd["MAKHOA"].ToString());
            }
            rd.Close();
            connect.Close();
        }

        private void bt2__mau_Load(object sender, EventArgs e)
        {
            comboBox1_();
        }

        public bool KT_KhoaChinh(string pMa)
        {
            connect.Open();
            string selectString = "select * from LOP where MALOP = '" + pMa + "'";
            SqlCommand cmd = new SqlCommand(selectString, connect);
            SqlDataReader rd = cmd.ExecuteReader();
            if(rd.HasRows)
            {
                rd.Close();
                connect.Close();
                return false;
            }
            else
            {
                rd.Close();
                connect.Close();
                return true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            connect = new SqlConnection(_connectectionString);
            try
            {
                if (textBox2.Text == string.Empty)
                {
                    MessageBox.Show("Bạn phải nhập mã lớp");
                    textBox2.Focus();
                    return;
                }
                if (KT_KhoaChinh(textBox2.Text) == true)
                {
                    connect.Open();
                    string insertString;
                    insertString = "insert into LOP values('" + textBox2.Text + "', '" + textBox3.Text + "', '" + comboBox1.SelectedItem.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(insertString, connect);
                    cmd.ExecuteNonQuery();
                    connect.Close();
                    MessageBox.Show("Thành Công!");
                }
                else
                { MessageBox.Show("Thất bại!"); }
            }
            catch (Exception ex)
            { MessageBox.Show("Thất bại!"); }
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                String deleteString;
                deleteString = "delete Lop where MaLop='" + textBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(deleteString, connect);
                cmd.ExecuteNonQuery();
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
                MessageBox.Show("Thành Công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại");
            }
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                string updateString;
                updateString = "update Lop set TenLop='" + textBox2.Text + "' where MaLop='" + textBox2.Text + "'" + "update Lop set MaKhoa='" + comboBox1.Text + "' where MaLop='" + textBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(updateString, connect);
                cmd.ExecuteNonQuery();
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
                MessageBox.Show("Thành Công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại");
            }
            textBox2.Clear();
            textBox3.Clear();
        }


    }
}

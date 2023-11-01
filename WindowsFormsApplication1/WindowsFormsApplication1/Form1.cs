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
    
    public partial class Form1 : Form
    {
        private SqlConnection connect;

        string _connectectionString = "server=.; database=QL_SINHVIEN;integrated security=true";

        public Form1()
        {
            InitializeComponent();
        }

        bool KT_MaKhoa(string ma)
        {
            connect = new SqlConnection(_connectectionString);
            try
            {
                connect.Open();
                string selectString = "select count(*) from KHOA where MAKHOA = '" + ma + "'";
                SqlCommand cmd = new SqlCommand(selectString, connect);
                int count = (int)cmd.ExecuteScalar();
                connect.Close();
                if (count >= 1)
                    return false;
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (KT_MaKhoa(textBox1.Text) == true)
                {
                    if (connect.State == ConnectionState.Closed)
                    {
                        connect.Open();
                    }
                    string insertString;
                    insertString = "insert into Khoa values('" + textBox1.Text + "',N'" + textBox2.Text + "')";
                    SqlCommand cmd = new SqlCommand(insertString, connect);
                    cmd.ExecuteNonQuery();
                    if (connect.State == ConnectionState.Open)
                    {
                        connect.Close();
                    }
                    MessageBox.Show("Thành Công");
                }
                else
                    MessageBox.Show("Thất bại");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại");
            }
            textBox1.Clear();
            textBox2.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            connect = new SqlConnection(_connectectionString);
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                String deleteString;
                deleteString = "delete Khoa where MaKhoa='" + textBox1.Text + "'";
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
            textBox1.Clear();
            textBox2.Clear();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            connect = new SqlConnection(_connectectionString);
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                String updateString;
                updateString = "update Khoa set TenKhoa='" + textBox2.Text + "' where MaKhoa='" + textBox1.Text + "'";
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
            textBox1.Clear();
            textBox2.Clear();
        }

        

        
    }
}

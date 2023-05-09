using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace takip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void listele()
        {

            String conString = "Data Source=SSQ.db;version=3";
            SQLiteConnection conn = new SQLiteConnection(conString);
            conn.Open();
            SQLiteDataAdapter ad = new SQLiteDataAdapter("SELECT*FROM dataa", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "dataa");
            dataGridView1.DataSource = ds.Tables["dataa"];
            conn.Close();
        }


        

        private void button1_Click(object sender, EventArgs e)
        {
            String conString = "Data Source=SSQ.db;version=3";
            SQLiteConnection conn = new SQLiteConnection(conString);
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.CommandText = "DELETE FROM dataa WHERE barkodno='" + textBox1.Text + "'";
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            conn.Close();
            listele();
            textBox1.Clear();
        }



        private void button2_Click(object sender, EventArgs e)
        {
           



            String conString = "Data Source=SSQ.db;version=3";
            SQLiteConnection conn = new SQLiteConnection(conString);
            try
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandText = "INSERT INTO dataa VALUES('" + textBox2.Text + "','"+textBox11.Text+"','" + textBox3.Text + "','" + textBox4.Text + "','"+textBox12.Text+"')";
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                listele();
            }
            catch (Exception ex) { MessageBox.Show($"hata  :{ex.Message}"); }
            textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox11.Clear();textBox12.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String BUL = dataGridView1.SelectedCells[0].Value.ToString();
            String conString = "Data Source=SSQ.db;version=3";
            SQLiteConnection conn = new SQLiteConnection(conString);
            try
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandText = "SELECT * FROM dataa WHERE barkodno='" + BUL + "'";
                cmd.Connection = conn;
                SQLiteDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows == true)
                {
                    textBox2.Text = reader["barkodno"].ToString();
                    textBox3.Text = reader["ürürn"].ToString();
                    textBox4.Text = reader["stok"].ToString();
                   
                   

                    reader.Close();
                    conn.Close();
                }

            }
            catch (Exception ex) { MessageBox.Show($"hata:  {ex.Message}"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String BUL = dataGridView1.SelectedCells[0].Value.ToString();
            String conString = "Data Source=SSQ.db;version=3";
            SQLiteConnection conn = new SQLiteConnection(conString);
            try
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandText = "SELECT * FROM dataa WHERE barkodno='" + textBox6.Text + "'";
                cmd.Connection = conn;
                SQLiteDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows == true)
                {
                    label5.Visible = true;
                    label6.Visible=true;
                    label11.Visible=true;
                    label24.Visible=true;
                    label25.Visible=true;

                    label12.Text = reader["barkodno"].ToString();
                    label13.Text = reader["ürün"].ToString();
                    label14.Text = reader["stok"].ToString();
                    label27.Text = reader["marka"].ToString();
                    label26.Text = reader["fiyat"].ToString();
                    
                    
                    reader.Close();
                    conn.Close();
                }
                textBox6.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"hata:  {ex.Message}");
            }
            {
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            String conString = "Data Source=SSQ.db;version=3";
            SQLiteConnection conn = new SQLiteConnection(conString);
            try
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandText = "UPDATE dataa SET marka=@K,ürün=@A,stok=@S,fiyat=@B WHERE barkodno=@N" ;
                cmd.Parameters.AddWithValue("@A", textBox7.Text);
                cmd.Parameters.AddWithValue("@k", textBox13.Text);
                cmd.Parameters.AddWithValue("@S", textBox8.Text);
                cmd.Parameters.AddWithValue("@N", textBox5.Text);
                cmd.Parameters.AddWithValue("@B", textBox14.Text);
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                conn.Close();
                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"hata:  {ex.Message}");
            }
            textBox5.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox13.Clear();
            textBox14.Clear();
          



        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            listele();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            String conString = "Data Source=SSQ.db;version=3";
            SQLiteConnection conn = new SQLiteConnection(conString);
            try
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandText = "UPDATE dataa SET stok=stok+@s WHERE barkodno=@N";
                
                cmd.Parameters.AddWithValue("@S", textBox10.Text);
                cmd.Parameters.AddWithValue("@N", textBox9.Text);
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                conn.Close();
                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"hata:  {ex.Message}");
            }
            
            textBox10.Clear();
            textBox9.Clear();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            String conString = "Data Source=SSQ.db;version=3";
            SQLiteConnection conn = new SQLiteConnection(conString);
            try
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandText = "UPDATE dataa SET stok=stok-@s WHERE barkodno=@N";

                cmd.Parameters.AddWithValue("@S", textBox10.Text);
                cmd.Parameters.AddWithValue("@N", textBox9.Text);
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                conn.Close();
                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"hata:  {ex.Message}");
            }
            
            textBox10.Clear();
            textBox9.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String conString = "Data Source=SSQ.db;version=3";
            SQLiteConnection conn = new SQLiteConnection(conString);
            try
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandText = "UPDATE dataa SET fiyat=@s WHERE barkodno=@N";

                cmd.Parameters.AddWithValue("@S", textBox16.Text);
                cmd.Parameters.AddWithValue("@N", textBox15.Text);
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                conn.Close();
                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"hata:  {ex.Message}");
            } 
            textBox16.Clear();
            textBox15.Clear();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label2.Visible = true; label3.Visible=true;    label4.Visible=true; label23.Visible=true;label22.Visible=true;label7.Visible=true;
            textBox2.Visible= true; textBox3.Visible = true; textBox4.Visible = true;textBox11.Visible=true;textBox12.Visible=true;
            button2.Visible=true;
            button8.Visible=false;button9.Visible=false;button10.Visible=false;button11.Visible=false;button12.Visible=false;button13.Visible=false;button14.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button8.Visible = false; button9.Visible = false; button10.Visible = false; button11.Visible = false; button12.Visible = false; button13.Visible = false; button14.Visible = true;
            label15.Visible = true;label16.Visible = true; label17.Visible = true; label18.Visible = true; label29.Visible = true; label28.Visible = true;
            textBox5.Visible = true; textBox7.Visible=true;textBox8.Visible = true;textBox13.Visible=true;textBox14.Visible= true;
            button5.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button8.Visible = false; button9.Visible = false; button10.Visible = false; button11.Visible = false; button12.Visible = false; button13.Visible = false; button14.Visible = true;
            label1.Visible = true;label8.Visible = true; textBox1.Visible=true; button1.Visible = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            button8.Visible = false; button9.Visible = false; button10.Visible = false; button11.Visible = false; button12.Visible = false; button13.Visible = false; button14.Visible = true;
            label19.Visible = true;label20.Visible = true; label21.Visible = true;
            textBox10.Visible= true; textBox9.Visible = true;button3.Visible=true;button6.Visible=true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            button8.Visible = false; button9.Visible = false; button10.Visible = false; button11.Visible = false; button12.Visible = false; button13.Visible = false; button14.Visible = true;
            label30.Visible= true;label31.Visible=true;label32.Visible = true;
            textBox16.Visible = true;textBox15.Visible=true;button7.Visible=true;
        }
        
        private void button10_Click(object sender, EventArgs e)
        {
            button8.Visible = false; button9.Visible = false; button10.Visible = false; button11.Visible = false; button12.Visible = false; button13.Visible = false; button14.Visible = true;
            label5.Visible=true;label6.Visible= true;label10.Visible= true;label9.Visible= true; label24.Visible=true; label11.Visible= true;label25.Visible    = true;
            label26.Visible= true;label14.Visible= true;label13.Visible= true;label14.Visible= true;label27.Visible= true;label12.Visible= true; textBox6.Visible= true;button4.Visible = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            button8.Visible = true; button9.Visible = true; button10.Visible = true; button11.Visible = true; button12.Visible = true; button13.Visible = true; button14.Visible = false;
            label5.Visible = false; label6.Visible = false; label10.Visible = false; label9.Visible = false; label24.Visible = false; label11.Visible = false; label25.Visible = false;
            label30.Visible = false; label31.Visible = false; label32.Visible = false;
            textBox16.Visible = false; textBox15.Visible = false; button7.Visible = false;
            label19.Visible = false; label20.Visible = false; label21.Visible = false;
            textBox10.Visible = false; textBox9.Visible = false; button3.Visible = false; button6.Visible = false;
            label26.Visible = false; label14.Visible = false; label13.Visible = false; label14.Visible = false; label27.Visible = false; label12.Visible = false; textBox6.Visible = false; button4.Visible = false;
            label1.Visible = false; label8.Visible = false; textBox1.Visible = false; button1.Visible = false;
            label15.Visible = false; label16.Visible = false; label17.Visible = false; label18.Visible = false; label29.Visible = false; label28.Visible = false;
            textBox5.Visible = false; textBox7.Visible = false; textBox8.Visible = false; textBox13.Visible = false; textBox14.Visible = false;
            button5.Visible = false;
            label2.Visible = false; label3.Visible = false; label4.Visible = false; label23.Visible = false; label22.Visible = false; label7.Visible = false;
            textBox2.Visible = false; textBox3.Visible = false; textBox4.Visible = false; textBox11.Visible = false; textBox12.Visible = false;
            button2.Visible = false;
            textBox1.Clear();textBox2.Clear();textBox3.Clear();textBox4.Clear();textBox5.Clear();textBox6.Clear();textBox7.Clear();textBox8.Clear();
            textBox9.Clear();textBox10.Clear();textBox11.Clear();textBox12.Clear();textBox13.Clear();textBox14.Clear();textBox15.Clear();textBox16.Clear();
            label12.Text = "";label13.Text = "";label14.Text = "";label27.Text = "";label26.Text = "";

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }
    }
}
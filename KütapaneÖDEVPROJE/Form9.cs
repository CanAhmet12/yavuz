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

namespace KütapaneÖDEVPROJE
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kütüphane.rezervasyon( Kütüphane.rezervasyonID,  textBox1.Text, textBox3.Text);
            MessageBox.Show("Rezervasyon Başaralı", "BAŞARILI");
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            Bilgiler(textBox6.Text, textBox5.Text, textBox4.Text);
        }
        private void Bilgiler(string KitapAdı , String BarkodNo , string Yazar)
        {

            SqlConnection con = new SqlConnection(Kütüphane.constr);
            SqlCommand com = new SqlCommand("select * from Book where KitapAdı=@KitapAdı AND BarkodNo=@BarkodNo AND Yazar=@Yazar ", con);
            com.Parameters.AddWithValue("@KitapAdı" , KitapAdı);
            com.Parameters.AddWithValue("BarkodNo", BarkodNo);
            com.Parameters.AddWithValue("Yazar", Yazar);

            try
            {
                con.Open();
                SqlDataReader da = com.ExecuteReader();
                if (da.Read())
                {
                    textBox6.Text = da["Kitap Adı"].ToString();
                    textBox5.Text = da["Barkod No"].ToString();
                    textBox4.Text = da["Yazar"].ToString();

                }
                else
                {
                    MessageBox.Show("KAYIT BULUNMADI");
                }

                da.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);

            }
            finally
            {
                con.Close();

            }


        }
    }
}

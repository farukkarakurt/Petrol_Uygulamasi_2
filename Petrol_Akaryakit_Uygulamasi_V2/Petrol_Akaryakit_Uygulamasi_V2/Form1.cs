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

namespace Petrol_Akaryakit_Uygulamasi_V2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=FARUK\\SQLEXPRESS;Initial Catalog=AkaryakıtProjesi;Integrated Security=True;");


        void listele()
        {
            //Kurşunsuz 95
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from TBLBENZIN where PETROLTUR='Kurşunsuz 95'", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lbl_kursun95.Text = dr[3].ToString();
                progressBar1.Value = int.Parse(dr[4].ToString());
                label15.Text = dr[4].ToString();
            }
            conn.Close();

            //Motorin
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("Select * from TBLBENZIN where PETROLTUR='Motorin'", conn);
            SqlDataReader dr2 = cmd2.ExecuteReader();

            while (dr2.Read())
            {
                lbl_motorin.Text = dr2[3].ToString();
                progressBar2.Value = int.Parse(dr2[4].ToString());
                label16.Text = dr2[4].ToString();
            }
            conn.Close();


            //Gazyağı
            conn.Open();
            SqlCommand cmd3 = new SqlCommand("Select * from TBLBENZIN where PETROLTUR='Gazyağı'", conn);
            SqlDataReader dr3 = cmd3.ExecuteReader();

            while (dr3.Read())
            {
                lbl_gazyagi.Text = dr3[3].ToString();
                progressBar3.Value = int.Parse(dr3[4].ToString());
                label17.Text = dr3[4].ToString();
            }
            conn.Close();

            //Fuel Oil
            conn.Open();
            SqlCommand cmd4 = new SqlCommand("Select * from TBLBENZIN where PETROLTUR='Fuel Oil'", conn);
            SqlDataReader dr4 = cmd4.ExecuteReader();

            while (dr4.Read())
            {
                lbl_fueloil.Text = dr4[3].ToString();
                progressBar4.Value = int.Parse(dr4[4].ToString());
                label18.Text = dr4[4].ToString();
            }
            conn.Close();

            conn.Open();
            SqlCommand cmd5 = new SqlCommand("select * from TBLKASA", conn);
            SqlDataReader dr5 = cmd5.ExecuteReader();
            while (dr5.Read())
            {
                lbl_kasa.Text = dr5[0].ToString();
            }


            conn.Close();


        }




        private void Form1_Load(object sender, EventArgs e)
        {
            listele();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz95, litre, tutar;

            kursunsuz95 = Convert.ToDouble(lbl_kursun95.Text);
            litre = Convert.ToDouble(numericUpDown1.Value.ToString());
            tutar = kursunsuz95 * litre;
            txt_kursunsuz95.Text = tutar.ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            double motorin, litre, tutar;

            motorin = Convert.ToDouble(lbl_motorin.Text);
            litre = Convert.ToDouble(numericUpDown2.Value.ToString());
            tutar = motorin * litre;
            txt_motorin.Text = tutar.ToString();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            double gazyagi, litre, tutar;

            gazyagi = Convert.ToDouble(lbl_gazyagi.Text);
            litre = Convert.ToDouble(numericUpDown3.Value.ToString());
            tutar = gazyagi * litre;
            txt_gazyagı.Text = tutar.ToString();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            double fueloil, litre, tutar;

            fueloil = Convert.ToDouble(lbl_fueloil.Text);
            litre = Convert.ToDouble(numericUpDown4.Value.ToString());
            tutar = fueloil * litre;
            txt_fueloil.Text = tutar.ToString();

        }

        private void btn_depodoldur_Click(object sender, EventArgs e)
        {

            if (numericUpDown1.Value != 0)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into TBLHAREKET (PLAKA,BENZINTURU,LITRE,FIYAT) values (@P1,@P2,@P3,@P4)", conn);
                cmd.Parameters.AddWithValue("@P1", txt_Plaka.Text);
                cmd.Parameters.AddWithValue("@P2", "Kurşunsuz 95");
                cmd.Parameters.AddWithValue("@P3", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@P4", decimal.Parse(txt_kursunsuz95.Text));
                cmd.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                SqlCommand cmd2 = new SqlCommand("update TBLKASA set MIKTAR=MIKTAR+@P1", conn);
                cmd2.Parameters.AddWithValue("@P1", decimal.Parse(txt_kursunsuz95.Text));
                cmd2.ExecuteNonQuery();
                conn.Close();


                conn.Open();
                SqlCommand cmd3 = new SqlCommand("update TBLBENZIN set STOK=STOK-@P1 where PETROLTUR='Kurşunsuz 95'", conn);
                cmd3.Parameters.AddWithValue("@P1", numericUpDown1.Value);
                cmd3.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("SATIŞ YAPILDI");
                listele();


                conn.Open();
            }

            if (numericUpDown2.Value != 0)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into TBLHAREKET (PLAKA,BENZINTURU,LITRE,FIYAT) values (@P1,@P2,@P3,@P4)", conn);
                cmd.Parameters.AddWithValue("@P1", txt_Plaka.Text);
                cmd.Parameters.AddWithValue("@P2", "Motorin");
                cmd.Parameters.AddWithValue("@P3", numericUpDown2.Value);
                cmd.Parameters.AddWithValue("@P4", decimal.Parse(txt_motorin.Text));
                cmd.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                SqlCommand cmd2 = new SqlCommand("update TBLKASA set MIKTAR=MIKTAR+@P1", conn);
                cmd2.Parameters.AddWithValue("@P1", decimal.Parse(txt_motorin.Text));
                cmd2.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                SqlCommand cmd3 = new SqlCommand("update TBLBENZIN set STOK=STOK-@P1 where PETROLTUR='Motorin'", conn);
                cmd3.Parameters.AddWithValue("@P1", numericUpDown2.Value);
                cmd3.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("SATIŞ YAPILDI");
                listele();
            }

            if (numericUpDown3.Value != 0)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into TBLHAREKET (PLAKA,BENZINTURU,LITRE,FIYAT) values (@P1,@P2,@P3,@P4)", conn);
                cmd.Parameters.AddWithValue("@P1", txt_Plaka.Text);
                cmd.Parameters.AddWithValue("@P2", "Gazyağı");
                cmd.Parameters.AddWithValue("@P3", numericUpDown3.Value);
                cmd.Parameters.AddWithValue("@P4", decimal.Parse(txt_gazyagı.Text));
                cmd.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                SqlCommand cmd2 = new SqlCommand("update TBLKASA set MIKTAR=MIKTAR+@P1", conn);
                cmd2.Parameters.AddWithValue("@P1", decimal.Parse(txt_gazyagı.Text));
                cmd2.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                SqlCommand cmd3 = new SqlCommand("update TBLBENZIN set STOK=STOK-@P1 where PETROLTUR='Gazyağı'", conn);
                cmd3.Parameters.AddWithValue("@P1", numericUpDown3.Value);
                cmd3.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("SATIŞ YAPILDI");
                listele();

            }

            if (numericUpDown4.Value != 0)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into TBLHAREKET (PLAKA,BENZINTURU,LITRE,FIYAT) values (@P1,@P2,@P3,@P4)", conn);
                cmd.Parameters.AddWithValue("@P1", txt_Plaka.Text);
                cmd.Parameters.AddWithValue("@P2", "Fuel Oil");
                cmd.Parameters.AddWithValue("@P3", numericUpDown4.Value);
                cmd.Parameters.AddWithValue("@P4", decimal.Parse(txt_fueloil.Text));
                cmd.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                SqlCommand cmd2 = new SqlCommand("update TBLKASA set MIKTAR=MIKTAR+@P1", conn);
                cmd2.Parameters.AddWithValue("@P1", decimal.Parse(txt_fueloil.Text));
                cmd2.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                SqlCommand cmd3 = new SqlCommand("update TBLBENZIN set STOK=STOK-@P1 where PETROLTUR='Fuel Oil'", conn);
                cmd3.Parameters.AddWithValue("@P1", numericUpDown4.Value);
                cmd3.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("SATIŞ YAPILDI");
                listele();
            }
        }
        // burda depo doldurma tuşuna basmadan önce alınan değerleri ve plakayı girmeliyiz.
        // progress barlarda girilen petrol türü bakımından azalır




        // Yapılacaklar 
        //** Azalan petrol depoları tekrar doldurmak ve kasaya ona göre para giriş çıkışını yazmak. 
    }
}

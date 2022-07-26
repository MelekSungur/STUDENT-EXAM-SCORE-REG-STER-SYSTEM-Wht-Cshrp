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

namespace STUDENT_EXAM_SCORE_REGİSTER_SYSTEM_Wht_Cshrp
{
    public partial class FrmOgretmenDetay : Form
    {
        public FrmOgretmenDetay()
        {
            InitializeComponent();
        }

        private void FrmOgretmenDetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBNotKayitDataSet.TBLDERS' table. You can move, or remove it, as needed.
            
            this.tBLDERSTableAdapter.Fill(this.dBNotKayitDataSet.TBLDERS);

           
            

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-D0LP1EG;Initial Catalog=DBNotKayit;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kaydet = new SqlCommand("insert into TBLDERS (OGRNUMARA,OGRAD,OGRSOYAD) values (@p1,@p2,@p3) ",baglanti);
            kaydet.Parameters.AddWithValue("@p1", MskNumara.Text);
            kaydet.Parameters.AddWithValue("@p2", TxtAd.Text);
            kaydet.Parameters.AddWithValue("@p3",TxtSoyad.Text);
            kaydet.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Sisteme Eklendi");
            this.tBLDERSTableAdapter.Fill(this.dBNotKayitDataSet.TBLDERS);


        }
        public string durum;
        int sayac = 0;

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            
            int sayac = 0;
            double ortalama, s1, s2, s3;
            
         
            s1 = Convert.ToDouble(TxtSinav1.Text);
            s2= Convert.ToDouble(TxtSinav2.Text);
            s3 = Convert.ToDouble(TxtSinav3.Text);
            ortalama = (s1 + s2 + s3) / 3;
            LblOrt.Text = ortalama.ToString();
            
            if (ortalama>=50)
            {
                durum = "True";
               
                
            }
            else
            {
                durum = "False";
                
            }
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update TBLDERS set OGRS1=@p1,OGRS2=@p2,OGRS3=@p3,ORTALAMA=@P4,DURUM=@p5 where OGRNUMARA=@p6", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtSinav1.Text);
            komut.Parameters.AddWithValue("@p2", TxtSinav2.Text);
            komut.Parameters.AddWithValue("@p3", TxtSinav3.Text);
            komut.Parameters.AddWithValue("@p4", decimal.Parse(LblOrt.Text));
            komut.Parameters.AddWithValue("@p6", MskNumara.Text);
            komut.Parameters.AddWithValue("@p5", durum);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Güncellendi");

            baglanti.Open();
            SqlCommand say = new SqlCommand("select * From TBLDERS where DURUM=@p1", baglanti);
            say.Parameters.AddWithValue("@p1", durum);
            SqlDataReader dr = say.ExecuteReader();
            while (dr.Read())
            {
                if (durum == "True")
                {
                    sayac = sayac + 1;
                    LblGecenSayisi.Text = sayac.ToString();
                }
            }
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            MskNumara.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtAd.Text=dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TxtSinav1.Text=dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtSinav2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtSinav3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            
        }
    }
}

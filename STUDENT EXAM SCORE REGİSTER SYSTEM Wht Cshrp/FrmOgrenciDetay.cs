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
    public partial class FrmOgrenciDetay : Form
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }

       
        public void Listele()
        {
            
            
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-D0LP1EG;Initial Catalog=DBNotKayit;Integrated Security=True");
        string durum1;
        public string numara;
        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
         
            LblNumara.Text = numara;
            baglanti.Open();
            SqlCommand Komut1 = new SqlCommand("select * From TBLDERS where OGRNUMARA=@p1", baglanti);
            Komut1.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = Komut1.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[2].ToString() + " " + dr[3].ToString();
                LblSinav1.Text = dr[4].ToString();
                LblSinav2.Text = dr[5].ToString();
                LblSinav3.Text = dr[6].ToString();
                LblOrtalama.Text = dr[7].ToString();
                durum1 = dr[8].ToString();
            }
            if (durum1 == "True")
            {
                LblDurum.Text = "Geçti";
            }
            else
            {
                LblDurum.Text = "Kaldı";
            }

        }
    }
}

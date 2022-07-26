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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
       
        
        private void BtnGiris_Click(object sender, EventArgs e)
        {
            FrmOgrenciDetay frm = new FrmOgrenciDetay();
            frm.numara = Mskogrno.Text;
            frm.Show();
           
        }
       
        public void FrmGiris_Load(object sender, EventArgs e)
        {
            
        }

        private void Mskogrno_TextChanged(object sender, EventArgs e)
        {
            if( Mskogrno.Text=="1111")
            {
                FrmOgretmenDetay frm = new FrmOgretmenDetay();
                frm.Show();
            }
        }
    }
}

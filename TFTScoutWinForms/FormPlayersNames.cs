using System;
using System.Windows.Forms;

namespace TFTScoutWinForms
{
    public partial class FormPlayersNames : Form
    {
        public static string strPlayer1;
        public static string strPlayer2;
        public static string strPlayer3;
        public static string strPlayer4;
        public static string strPlayer5;
        public static string strPlayer6;
        public static string strPlayer7;
        public static string strPlayer8;

        public FormPlayersNames()
        {
            InitializeComponent();
            this.TopMost = true;
            txtNamePlayer1.Select();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNamePlayer1.Text = txtNamePlayer2.Text = txtNamePlayer3.Text = txtNamePlayer4.Text = 
                txtNamePlayer5.Text = txtNamePlayer6.Text = txtNamePlayer7.Text = txtNamePlayer8.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            strPlayer1 = txtNamePlayer1.Text;
            strPlayer2 = txtNamePlayer2.Text;
            strPlayer3 = txtNamePlayer3.Text;
            strPlayer4 = txtNamePlayer4.Text;
            strPlayer5 = txtNamePlayer5.Text;
            strPlayer6 = txtNamePlayer6.Text;
            strPlayer7 = txtNamePlayer7.Text;
            strPlayer8 = txtNamePlayer8.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

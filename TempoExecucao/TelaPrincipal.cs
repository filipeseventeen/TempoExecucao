using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace TempoExecucao
{
    public partial class TelaPrincipal : Form
    {
        string pasta_images = "";

        int min_exec;
        int seg_exec;
        int tempo_exec;

        int min_desc;
        int seg_desc;
        int tempo_desc;

        int quant_series;

        int n = 3;

        Image img_exercitando;
        Image img_descansando;
        Image img_esperando;

        WindowsMediaPlayer som;

        public TelaPrincipal()
        {
            InitializeComponent();
            pasta_images = Application.StartupPath + @"\images\";

            img_exercitando = Image.FromFile(pasta_images + "img_exercitando.png");
            img_esperando = Image.FromFile(pasta_images + "img_esperando.png");
            img_descansando = Image.FromFile(pasta_images + "img_descansando.png");
        }

        private void TempoSecMin()
        {
            if (tempo_exec > 60)
            {
                min_exec = tempo_exec / 60;
                seg_exec = tempo_exec % 60;
            }
            else
            {
                seg_exec = tempo_exec;
                min_exec = 0;
            }

            if (tempo_desc > 60)
            {
                min_desc = tempo_desc / 60;
                seg_desc = tempo_desc % 60;
            }
            else
            {
                seg_desc = tempo_desc;
                min_desc = 0;
            }
        }

        private void ThreeTwoOne()
        {
            ptbPrincipal.Visible = false;
            timer3.Enabled = true;
            timer1.Enabled = false;
        }

        private void Stop()
        {
            if (tempo_exec == 0 && tempo_desc == 0 && quant_series == 0)
            {
                ptbPrincipal.BackgroundImage = img_esperando;
                txtDescanso.Enabled = true;
                txtSeries.Enabled = true;
                txtTempo.Enabled = true;
            }
        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {
            lbl321.Text = "Prepare-se";
            ptbPrincipal.BackgroundImage = img_esperando;
            ptbPrincipal.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validando os campos
            if (txtTempo.Text == String.Empty)
            {
                MessageBox.Show("Campo TEMPO é obrigatório.", "Erro de preenchimento");
            }
            else if (txtDescanso.Text == String.Empty)
            {
                MessageBox.Show("Campo DESCANSO é obrigatório.", "Erro de preenchimento");
            }
            else if (txtSeries.Text == String.Empty)
            {
                MessageBox.Show("Campo SÉRIES é obrigatório.", "Erro de preenchimento");
            }
            else
            {
                ThreeTwoOne();

                tempo_exec = Convert.ToInt16(txtTempo.Text);
                tempo_desc = Convert.ToInt16(txtDescanso.Text);
                quant_series = Convert.ToInt16(txtSeries.Text);

                TempoSecMin();

                lblTempo.Text = "0" + min_exec + ":" + seg_exec;

                lblDescanso.Text = "0" + min_desc + ":" + seg_desc;

                lblSeries.Text = quant_series.ToString();

                timer3.Enabled = true;

                txtTempo.Enabled = false;
                txtDescanso.Enabled = false;
                txtSeries.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ptbPrincipal.BackgroundImage = img_exercitando;
            if (timer1.Enabled == true)
            {
                //TOCAR SOM
            }
            else
            {
                //PARAR SOM
            }


            if (seg_exec > 0)
            {
                seg_exec--;
                if (seg_exec == 0 && min_exec > 0)
                {
                    min_exec--;
                    seg_exec = 60;
                }
                else if (seg_exec == 0 && min_exec == 0 && quant_series >= 1)
                {
                    TempoSecMin();
                    timer1.Enabled = false;
                    timer2.Enabled = true;
                }
            }
            lblTempo.Text = "0" + min_exec + ":" + seg_exec;
            lblDescanso.Text = "0" + min_desc + ":" + seg_desc;

            //STOP
            if (tempo_exec == 0 && tempo_desc == 0 && quant_series == 0)
            {
                ptbPrincipal.BackgroundImage = img_esperando;
                txtDescanso.Enabled = true;
                txtSeries.Enabled = true;
                txtTempo.Enabled = true;
            }

            Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            ptbPrincipal.BackgroundImage = img_descansando;
            if (timer2.Enabled == true)
            {
                //TOCAR SOM
            }
            else
            {
                //PARAR SOM
            }


            if (seg_desc > 0)
            {
                seg_desc--;
                if (seg_desc == 0 && min_desc > 0)
                {
                    min_desc--;
                    seg_desc = 60;
                }
                else if (seg_desc == 0 && min_desc == 0 && quant_series >= 1)
                {
                    timer2.Enabled = false;
                    timer1.Enabled = true;
                    quant_series--;
                }
            }
            lblDescanso.Text = "0" + min_desc + ":" + seg_desc;
            lblSeries.Text = quant_series.ToString();
        }

        private void btnEncerrar_Click(object sender, EventArgs e)
        {
            txtTempo.Enabled = true;
            txtDescanso.Enabled = true;
            txtSeries.Enabled = true;

            txtTempo.Text = "";
            txtDescanso.Text = "";
            txtSeries.Text = "";

            timer1.Enabled = false;
            timer2.Enabled = false;

            lblTempo.Text = "00:00";
            lblDescanso.Text = "00:00";
            lblSeries.Text = "0";

            ptbPrincipal.BackgroundImage = img_esperando;

        }

        private void timer3_Tick(object sender, EventArgs e)
        {

            if (n > 0)
            {
                lbl321.Left = 400;
                lbl321.Top = 100;
                lbl321.Font = new Font(lbl321.Font.FontFamily, 72);
                lbl321.Text = n.ToString();
                n--;
            }
            else
            {
                ptbPrincipal.Visible = true;
                ptbPrincipal.BackgroundImage = img_exercitando;
                timer3.Enabled = false;
                timer1.Enabled = true;
            }

        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl321_Click(object sender, EventArgs e)
        {

        }

        private void lbl321_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ptbPrincipal_Click(object sender, EventArgs e)
        {

        }

        private void timer4_Tick(object sender, EventArgs e)
        {

        }
    }
}

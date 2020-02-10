using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TempoExecucao
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        int min_exec;
        int seg_exec;
        int tempo_exec;

        int min_desc;
        int seg_desc;
        int tempo_desc;

        int quant_series;

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validando os campos
            if(txtTempo.Text == String.Empty)
            {
                MessageBox.Show("Campo TEMPO é obrigatório.", "Erro de preenchimento");
            }else if(txtDescanso.Text == String.Empty)
            {
                MessageBox.Show("Campo DESCANSO é obrigatório.", "Erro de preenchimento");
            }else if(txtSeries.Text == String.Empty)
            {
                MessageBox.Show("Campo SÉRIES é obrigatório.", "Erro de preenchimento");
            }
            else
            {
                tempo_exec = Convert.ToInt16(txtTempo.Text);
                tempo_desc = Convert.ToInt16(txtDescanso.Text);
                quant_series = Convert.ToInt16(txtSeries.Text);

                TempoSecMin();

                lblTempo.Text = "0" + min_exec + ":" + seg_exec;

                lblDescanso.Text = "0" + min_desc + ":" + seg_desc;

                lblSeries.Text = quant_series.ToString();

                timer1.Enabled = true;

                txtTempo.Enabled = false;
                txtDescanso.Enabled = false;
                txtSeries.Enabled = false;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(seg_exec > 0)
            {
                seg_exec--;
                if(seg_exec == 0 && min_exec > 0)
                {
                    min_exec--;
                    seg_exec = 60;
                }
                else if(seg_exec == 0 && min_exec == 0 && quant_series >= 1)
                {
                    TempoSecMin();
                    timer1.Enabled = false;
                    timer2.Enabled = true;
                }
            }
            lblTempo.Text = "0" + min_exec + ":" + seg_exec;
            lblDescanso.Text = "0" + min_desc + ":" + seg_desc;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(seg_desc > 0)
            {
                seg_desc--;
                if(seg_desc == 0 && min_desc > 0)
                {
                    min_desc--;
                    seg_desc = 60;
                }else if(seg_desc == 0 && min_desc == 0 && quant_series >= 1)
                {
                    timer2.Enabled = false;
                    timer1.Enabled = true;
                    quant_series--;
                }
            }
            lblDescanso.Text = "0" + min_desc + ":" + seg_desc;
            lblSeries.Text = quant_series.ToString();
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

        }
    }
}

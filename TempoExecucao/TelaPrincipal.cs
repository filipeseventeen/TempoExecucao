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

                if(tempo_exec > 60)
                {
                    min_exec = tempo_exec / 60;
                    seg_exec = tempo_exec % 60;
                }
                else
                {
                    seg_exec = tempo_exec;
                    min_exec = 0;
                }
                lblTempo.Text = "0" + min_exec + ":" + seg_exec;

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
                lblDescanso.Text = "0" + min_desc + ":" + seg_desc;

                lblSeries.Text = quant_series.ToString();

            }
        }
    }
}

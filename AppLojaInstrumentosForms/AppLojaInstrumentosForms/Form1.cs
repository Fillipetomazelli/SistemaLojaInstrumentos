using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppLojaInstrumentosForms.Formularios;

namespace AppLojaInstrumentosForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btCadastrarLoja_Click(object sender, EventArgs e)
        {
            CadastroDeLoja form = new CadastroDeLoja();
            form.ShowDialog();
        }

        private void btCadastrarInstrumentos_Click(object sender, EventArgs e)
        {
            CadastroDeInstrumentos form = new CadastroDeInstrumentos();
            form.ShowDialog();
        }

        private void btConsultarInstrumentos_Click(object sender, EventArgs e)
        {
            ConsultaDeInstrumentos form = new ConsultaDeInstrumentos();
            form.ShowDialog();
        }
    }
}

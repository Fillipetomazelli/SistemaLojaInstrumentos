using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppLojaInstrumentosForms.Models;
using AppLojaInstrumentosForms.Contexto;
using AppLojaInstrumentosForms.Formularios;

namespace AppLojaInstrumentosForms.Formularios
{
   
    public partial class CadastroDeLoja : Form
    {
        public Loja Lojas = new Loja();
        public List<Instrumentos> listaInstrumentos = new List<Instrumentos>();
        static private int IdLojas = 1;
        public CadastroDeLoja()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            Loja loja = new Loja();
            loja.Id = IdLojas;
            IdLojas++;
            loja.Cnpj = txtCnpj.Text;
            loja.DonoDaLoja = txtDono.Text;
            loja.Nome = txtNome.Text;

            Context.Listalojas.Add(loja);

            MessageBox.Show("SALVO COM SUCESSO", "FILLIPE REIS TOMAZELLI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNome.Clear(); txtDono.Clear(); txtCnpj.Clear(); txtNome.Select();
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear(); txtDono.Clear(); txtCnpj.Clear(); txtNome.Select();
        }
    }
}

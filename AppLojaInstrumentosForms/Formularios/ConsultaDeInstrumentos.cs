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

namespace AppLojaInstrumentosForms.Formularios
{
    public partial class ConsultaDeInstrumentos : Form
    {
        int cont = 1;
        List<Loja> listaLojas = new List<Loja>();
        List<Instrumentos> listaInstrumentos = new List<Instrumentos>();
        int IdInstrumento = 1;
        int IdLojas = 1;
        public ConsultaDeInstrumentos()
        {
            InitializeComponent();
            InstrumentosContext Context = new InstrumentosContext();
            listaInstrumentos = Context.ListarInstrumentos();
            LojaContext context = new LojaContext();
            listaLojas = context.ListarLojas();
            cbPesquisa.DataSource = listaLojas.ToList();
            cbPesquisa.DisplayMember = "Nome";
            cbPesquisa.SelectedIndex = -1;
        }

        private void cbPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int linhaselec = cbPesquisa.SelectedIndex;
            if (linhaselec > -1 && cont > 1)
            {
                var loja = listaLojas[linhaselec];

                txtNomeLoja.Text = loja.Nome.ToString();
                txtDono.Text = loja.DonoDaLoja.ToString();
                txtCnpj.Text = loja.Cnpj.ToString();

                IdLojas = loja.Id;

                var listaInst = listaInstrumentos.Where(a => a.Loja_Id == loja.Id).ToList();
                dtTabela.DataSource = listaInst;
            }
            cont++;
        }
    }
}

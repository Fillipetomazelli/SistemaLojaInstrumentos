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
    public partial class CadastroDeInstrumentos : Form
    {
        int cont = 1;
        List<Loja> listaLojas = new List<Loja>();
        List<Instrumentos> listaInstrumentos = new List<Instrumentos>();
        int IdInstrumento = 1;
        int IdLojas = 1;
        public CadastroDeInstrumentos()
        {
            InitializeComponent();
            listaLojas = Context.Listalojas.ToList();
            cbPesquisa.DataSource = listaLojas;
            cbPesquisa.DisplayMember = "Nome";
            cbPesquisa.SelectedIndex = -1;
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            Context.ListaInstrumentos.AddRange(listaInstrumentos);
            MessageBox.Show("SALVO COM SUCESSO", "FILLIPE REIS TOMAZELLI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNome.Clear(); txtValor.Clear(); txtDescricao.Clear(); txtGenero.Clear(); txtModelo.Clear(); txtNome.Select();
            listaInstrumentos.Clear();
            dtTabela.DataSource = new List<Instrumentos>();
            

        }

        private void cbPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int linhaselec = cbPesquisa.SelectedIndex;
            if(linhaselec > -1 && cont > 1)
            {
                var loja = listaLojas[linhaselec];
                txtNomeLoja.Text = loja.Nome.ToString();
                txtDono.Text = loja.DonoDaLoja.ToString();
                txtCnpj.Text = loja.Cnpj.ToString();

                IdLojas = loja.Id;
            }
            cont++;

        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Instrumentos instrumento = new Instrumentos();
            Loja loja = listaLojas[cbPesquisa.SelectedIndex];
            instrumento.Id = IdInstrumento;
            instrumento.IdLoja = loja.Id;
            instrumento.Nome = txtNome.Text;
            instrumento.Valor = Convert.ToDouble(txtValor.Text);
            instrumento.Descricao = txtDescricao.Text;
            instrumento.Genero = txtGenero.Text;
            instrumento.Modelo = txtModelo.Text;
            listaInstrumentos.Add(instrumento);
            IdInstrumento++;
            dtTabela.DataSource = listaInstrumentos.ToList();
            txtNome.Clear(); txtValor.Clear(); txtDescricao.Clear(); txtGenero.Clear(); txtModelo.Clear(); txtNome.Select();

        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear(); txtValor.Clear(); txtDescricao.Clear(); txtGenero.Clear(); txtModelo.Clear(); txtNome.Select();
        }

        private void CadastroDeInstrumentos_Load(object sender, EventArgs e)
        {

        }
    }
}

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
        int Id_Loja;
        static int IdInstrumento = 1;
        List<Loja> listaLojas = new List<Loja>();
        List<Instrumentos> listaInstrumentosTemp = new List<Instrumentos>();


        public CadastroDeInstrumentos()
        {
            InitializeComponent();
           
            LojaContext context = new LojaContext();
            listaLojas = context.ListarLojas();
            cbPesquisa.DataSource = listaLojas.ToList();
            cbPesquisa.DisplayMember = "Nome";
            cbPesquisa.SelectedIndex = -1;
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            foreach(var instrumento in listaInstrumentosTemp)
            {
                InstrumentosContext context = new InstrumentosContext();
                context.InserirInstrumentos(instrumento);
            }
            MessageBox.Show("SALVO COM SUCESSO", "FILLIPE REIS TOMAZELLI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNome.Clear(); txtValor.Clear(); txtDescricao.Clear(); txtGenero.Clear(); txtModelo.Clear(); txtNome.Select();
            listaInstrumentosTemp.Clear();
            dtTabela.DataSource = new List<Clientes>();
            

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
                Id_Loja = loja.Id;
            }
            cont++;

        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Instrumentos instrumento = new Instrumentos();
            instrumento.Id = IdInstrumento;
            instrumento.Loja_Id = Id_Loja;
            instrumento.Nome = txtNome.Text;
            instrumento.Valor = Convert.ToDouble(txtValor.Text);
            instrumento.Descricao = txtDescricao.Text;
            instrumento.Genero = txtGenero.Text;
            instrumento.Modelo = txtModelo.Text;
            listaInstrumentosTemp.Add(instrumento);
            IdInstrumento++;
            dtTabela.DataSource = listaInstrumentosTemp.ToList();
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

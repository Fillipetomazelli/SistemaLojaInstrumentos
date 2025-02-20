using AppLojaInstrumentosForms.Models;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.Remoting.Contexts;

namespace AppLojaInstrumentosForms.Formularios
{
    public partial class ConsultaInstrumentos : Form
    {
        int contExe = 1;
        int cont = 1;
        int Id_Loja;
        static int IdInstrumento;
        List<Loja> listaLojas = new List<Loja>();
        List<Instrumentos> listaInstrumentosTemp = new List<Instrumentos>();


        public ConsultaInstrumentos()
        {
            InitializeComponent();
            LojaContext context = new LojaContext();
            listaLojas = context.ListarLojas();
            InstrumentosContext contexto = new InstrumentosContext();
            listaInstrumentosTemp = contexto.ListarInstrumentos();
            cbPesquisa.DataSource = listaInstrumentosTemp.ToList();
            cbPesquisa.DisplayMember = "Nome";
            cbPesquisa.SelectedIndex = -1;
           
        }

        private void cbPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int linhaselec = cbPesquisa.SelectedIndex;
            if (linhaselec > -1 && cont > 1)
            {
                var instrumentos = listaInstrumentosTemp[linhaselec];
                txtNomeC.Text = instrumentos.Nome.ToString();
                txtDescricao.Text = instrumentos.Descricao.ToString();
                txtValor.Text = Convert.ToInt32(instrumentos.Valor).ToString();
                txtModelo.Text = instrumentos.Modelo.ToString();
                txtGenero.Text = instrumentos.Genero.ToString();
                Id_Loja = instrumentos.Loja_Id;
                IdInstrumento = instrumentos.Id;
            }
            cont++;

           
        }


        private void btUPDATE_Click(object sender, EventArgs e)
        {
            var linhaSelec = cbPesquisa.SelectedIndex;
            if (linhaSelec > -1 && contExe > 0)
            {
                var InstrumentoSelec = listaInstrumentosTemp[linhaSelec];
                InstrumentoSelec.Nome = txtNomeC.Text;
                InstrumentoSelec.Descricao = txtDescricao.Text;
                InstrumentoSelec.Valor = Convert.ToInt32(txtValor.Text);
                InstrumentoSelec.Modelo = txtModelo.Text;
                InstrumentoSelec.Genero = txtGenero.Text;

                InstrumentosContext context = new InstrumentosContext();
                context.AtualizarInstrumento(InstrumentoSelec);
                MessageBox.Show("ID: " + InstrumentoSelec.Id + "ATUALIZADO COM SUCESSO!", "2° A INF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNomeC.Clear(); txtDescricao.Clear(); txtValor.Clear(); txtModelo.Clear(); txtGenero.Clear();
                txtNomeC.Select();
                contExe = 0;
                listaInstrumentosTemp = context.ListarInstrumentos();
                cbPesquisa.DataSource = listaInstrumentosTemp.ToList();
                cbPesquisa.SelectedIndex = -1;


            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            var linhaSelec = cbPesquisa.SelectedIndex;
            if (linhaSelec > -1 && contExe > 0)
            {
                var InstrumentoSelec = listaInstrumentosTemp[linhaSelec];
                InstrumentoSelec.Nome = txtNomeC.Text;
                InstrumentoSelec.Descricao = txtDescricao.Text;
                InstrumentoSelec.Valor = Convert.ToInt32(txtValor.Text);
                InstrumentoSelec.Modelo = txtModelo.Text;
                InstrumentoSelec.Genero = txtGenero.Text;

                InstrumentosContext context = new InstrumentosContext();
                context.DeleteInstrumento(InstrumentoSelec);
                MessageBox.Show("ID: " + InstrumentoSelec.Id + "ATUALIZADO COM SUCESSO!", "2° A INF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNomeC.Clear(); txtDescricao.Clear(); txtValor.Clear(); txtModelo.Clear(); txtGenero.Clear();
                txtNomeC.Select();
                contExe = 0;
                listaInstrumentosTemp = context.ListarInstrumentos();
                cbPesquisa.DataSource = listaInstrumentosTemp.ToList();
                cbPesquisa.SelectedIndex = -1;


            }
        }
    }
}

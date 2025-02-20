using AppLojaInstrumentosForms.Contexto;
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

namespace AppLojaInstrumentosForms.Formularios
{
    public partial class CadastraCliente : Form
    {
        int cont = 1;
        int Id_Loja;
        static int IdClientes = 1;
        List<Loja> listaLojas = new List<Loja>();
        List<Clientes> listaClientesTemp = new List<Clientes>();
        public CadastraCliente()
        {
            InitializeComponent();
            LojaContext context = new LojaContext();
            listaLojas = context.ListarLojas();
            cbPesquisa.DataSource = listaLojas.ToList();
            cbPesquisa.DisplayMember = "Nome";
            cbPesquisa.SelectedIndex = -1;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            foreach(var cliente in listaClientesTemp)
            {
                ClientesContext context = new ClientesContext();
                context.InserirPessoa(cliente);
            }
            MessageBox.Show("SALVO COM SUCESSO", "FILLIPE REIS TOMAZELLI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNomeC.Clear(); txtCpf.Clear(); txtSexo.Clear(); txtIdade.Clear(); txtNome.Select();
            listaClientesTemp.Clear();
            dtTabela.DataSource = new List<Clientes>();
            
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            txtNomeC.Clear(); txtCpf.Clear(); txtSexo.Clear(); txtIdade.Clear(); txtNome.Select();
            listaClientesTemp.Clear();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();
            cliente.Id = IdClientes;
            cliente.Loja_Id = Id_Loja;
            cliente.Nome = txtNomeC.Text;
            cliente.Cpf = txtCpf.Text;
            cliente.Sexo = txtSexo.Text;
            cliente.Idade = txtIdade.Text;
 
            listaClientesTemp.Add(cliente);
            IdClientes++;
            dtTabela.DataSource = listaClientesTemp.ToList();
            txtNomeC.Clear(); txtCpf.Clear(); txtSexo.Clear(); txtIdade.Clear(); txtNomeC.Select();
        }

        private void cbPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int linhaselec = cbPesquisa.SelectedIndex;
            if (linhaselec > -1 && cont > 1)
            {
                var loja = listaLojas[linhaselec];
                txtNome.Text = loja.Nome.ToString();
                txtDono.Text = loja.DonoDaLoja.ToString();
                txtCnpj.Text = loja.Cnpj.ToString();
                Id_Loja = loja.Id;
            }
            cont++;
        }
    }
}

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

namespace AppLojaInstrumentosForms.Formularios
{
    public partial class ConsultaClientes : Form
    {
        int contExe = 1;
        int cont = 1;
        static int IdClientes;
        List<Clientes> listaClientesTemp = new List<Clientes>();

        public ConsultaClientes()
        {
            InitializeComponent();

            ClientesContext contexto = new ClientesContext();
            listaClientesTemp = contexto.ListarClientes();
            cbPesquisa.DataSource = listaClientesTemp.ToList();
            cbPesquisa.DisplayMember = "Nome";
            cbPesquisa.SelectedIndex = -1;
        }

        

        private void btUPDATE_Click(object sender, EventArgs e)
        {
            var linhaSelec = cbPesquisa.SelectedIndex;
            if (linhaSelec > -1 && contExe > 0)
            {
                var ClienteSelec = listaClientesTemp[linhaSelec];
                ClienteSelec.Nome = txtNomeC.Text;
                ClienteSelec.Cpf = txtCpf.Text;
                ClienteSelec.Sexo = txtSexo.Text;
                ClienteSelec.Idade = txtIdade.Text;

                ClientesContext context = new ClientesContext();
                context.AtualizarCliente(ClienteSelec);
                MessageBox.Show("ID: " + ClienteSelec.Id + "ATUALIZADO COM SUCESSO!", "2° A INF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNomeC.Clear(); txtCpf.Clear(); txtSexo.Clear(); txtIdade.Clear();
                txtNomeC.Select();
                contExe = 0;
                listaClientesTemp = context.ListarClientes();
                cbPesquisa.DataSource = listaClientesTemp.ToList();
                cbPesquisa.SelectedIndex = -1;


            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            var linhaSelec = cbPesquisa.SelectedIndex;
            if (linhaSelec > -1 && contExe > 0)
            {
                var ClienteSelec = listaClientesTemp[linhaSelec];
                ClienteSelec.Nome = txtNomeC.Text;
                ClienteSelec.Cpf = txtCpf.Text;
                ClienteSelec.Sexo = txtSexo.Text;
                ClienteSelec.Idade = txtIdade.Text;

                ClientesContext context = new ClientesContext();
                context.DeleteCliente(ClienteSelec);
                MessageBox.Show("ID: " + ClienteSelec.Id + "ATUALIZADO COM SUCESSO!", "2° A INF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNomeC.Clear(); txtCpf.Clear(); txtSexo.Clear(); txtIdade.Clear();
                txtNomeC.Select();
                contExe = 0;
                listaClientesTemp = context.ListarClientes();
                cbPesquisa.DataSource = listaClientesTemp.ToList();
                cbPesquisa.SelectedIndex = -1;


            }
        }

        private void cbPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int linhaselec = cbPesquisa.SelectedIndex;
            if (linhaselec > -1 && cont > 1)
            {
                var clientes = listaClientesTemp[linhaselec];
                txtNomeC.Text = clientes.Nome.ToString();
                txtCpf.Text = clientes.Cpf.ToString();
                txtSexo.Text = clientes.Sexo.ToString();
                txtIdade.Text = clientes.Idade.ToString();
                IdClientes = clientes.Id;
            }
            cont++;
        }
    }
}

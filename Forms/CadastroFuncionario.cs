using Helpdesk.ConnectioDB;
using Helpdesk.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helpdesk.Forms
{
    public partial class CadastroFuncionario : Form
    {
        public CadastroFuncionario()
        {
            InitializeComponent();
        }

        private void Btn_salvar_Click(object sender, EventArgs e)
        {
            if (txb_nome.TextLength < 3)
            {
                MessageBox.Show("Erro: O nome precisa ter mais de 3 caracteres");
            }
            else if (txb_login.TextLength < 4)
            {
                MessageBox.Show("Erro: O Login precisa ter mais de 4 caracteres");
            }
            else if (txb_senha.TextLength < 8)
            {
                MessageBox.Show("Erro: A senha deve possuir ao menos 8 caracteres");
            }
            else
            {
                Funcionario funcionario = new Funcionario();
                FuncionarioDAO dao = new FuncionarioDAO();

                funcionario.nome = txb_nome.Text;
                funcionario.login = txb_login.Text;
                funcionario.senha = txb_senha.Text;

                try
                {
                    dao.create(funcionario);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                this.Dispose();
                MessageBox.Show("Funcionario criado com sucesso!");
            }
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

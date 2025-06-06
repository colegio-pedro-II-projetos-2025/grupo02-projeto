using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabCastor
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {

            TelaCadastro registro = new TelaCadastro();
            
           var dialog =  registro.ShowDialog();
                      

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            TelaLogin login = new TelaLogin();
            var dialog = login.ShowDialog();
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {

        }
    }
}

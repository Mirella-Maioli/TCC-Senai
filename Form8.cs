using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AgenciaViagens.Form1;

namespace AgenciaViagens
{
    public partial class Form8 : Form
    {
        bool Volta = InfoCompartilhada.Volta;
         
        public Form8()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Pagamento efetuado ");
            this.Close();

            Form9 bilheteIda = new Form9();
            bilheteIda.Show();

            if (Volta == true)
            {
                Form10 bilheteVolta = new Form10();
                bilheteVolta.Show();
            }

        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }
    }
}

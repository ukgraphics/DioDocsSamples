using DDClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDWinFormCoreApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DDExcel.Create(".NET Core WinForms App");

            DDPdf.Create(".NET Core WinForms App");
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

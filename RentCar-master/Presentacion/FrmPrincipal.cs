using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void gestionDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmClientes frm = FrmClientes.GetInstancia();
            
            //frm.MdiParent = this;
            //frm.StartPosition = FormStartPosition.CenterScreen;
            //frm.BringToFront();
            //frm.Show();
            AbrirFormularios(new FrmClientes());
        }

        private void gestionDeVehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmVehiculos frm = FrmVehiculos.GetInstancia();
            //frm.MdiParent = this;
            //frm.StartPosition = FormStartPosition.CenterScreen;
            //frm.BringToFront();
            //frm.Show();
            AbrirFormularios(new FrmVehiculos());
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gestionAlquilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FmrAlquiler frm = FmrAlquiler.GetInstancia();

            //frm.MdiParent = this;
            //frm.StartPosition = FormStartPosition.CenterScreen;
            //frm.BringToFront();
            //frm.Show();
            AbrirFormularios(new FmrAlquiler());

        }

        private void AbrirFormularios(object formulario)
        {
            if (this.panelContenedor.Controls.Count > 0)
            {
                this.panelContenedor.Controls.RemoveAt(0);
            }

            Form form = formulario as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(form);
            this.panelContenedor.Tag = form;
            form.Show();
        }
    }
}

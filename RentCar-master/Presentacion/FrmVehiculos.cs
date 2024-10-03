using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Entidades;
using Logica;

namespace Presentacion
{
    public partial class FrmVehiculos : Form
    {
        private static FrmVehiculos instacia = null;
        public FrmVehiculos()
        {
            InitializeComponent();
        }

        public static FrmVehiculos GetInstancia()
        {
            if (instacia == null || instacia.IsDisposed)
            {
                instacia = new FrmVehiculos();
            }
            return instacia;
        }

        private void FrmVehiculos_Load(object sender, EventArgs e)
        {
            CargarLista("");
            CargarGrillaVehiculos("");
        }


        void CargarLista(string condicion)
        {
            var lista = new ServicioVehiculo().Todos(condicion);
            listaVehiculos.DataSource = lista;
            listaVehiculos.DisplayMember = "Marca";
            listaVehiculos.ValueMember = "PlacaVehiculo";
            if (listaVehiculos.Items.Count >= 0)
            {
                listaVehiculos.SelectedIndex = 0;
                listaVehiculos.Select();
            }
        }
        void CargarGrillaVehiculos(string condicion)
        {
            GrillaVehiculos.DataSource = new ServicioVehiculo().TodosFiltro(condicion);

        }

        
        void Buscar(string id)
        {

            try
            {
                var vehiculo = new ServicioVehiculo().BuscarID(id);
                ver(vehiculo);
            }
            catch (Exception)
            {


            }


        }
        void ver(Entidades.Vehiculo vehiculo)
        {
            if (vehiculo == null)
            {
                return;
            }
            txtPlaca.Text = vehiculo.PlacaVehiculo;
            txtMarca.Text = vehiculo.Marca;
            txtKMactual.Text = vehiculo.KilometrajeActual.ToString();
            
        }

        

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var vehiculo = new Entidades.Vehiculo(txtPlaca.Text , txtMarca.Text,int.Parse(txtKMactual.Text));
            Guardar(vehiculo);
            CargarLista("");
            GrillaVehiculos.Refresh();
        }
        void Guardar(Entidades.Vehiculo vehiculo)
        {
           MessageBox.Show(new ServicioVehiculo().Insertar(vehiculo));
        }

            
       

        private void listaVehiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = listaVehiculos.SelectedValue.ToString();
            Buscar(id);
        }

        

        private void GrillaVehiculos_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string id = GrillaVehiculos.Rows[e.RowIndex].Cells[0].Value.ToString();
            Buscar(id);
            listaVehiculos.SelectedIndex = e.RowIndex;
            this.tabControl1.TabPages[0].Show();
        }

        private void txtCondicionVh_TextChanged(object sender, EventArgs e)
        {
            string condicion = txtCondicionVh.Text.Trim();
            CargarGrillaVehiculos(condicion);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo(false);
        }

        void Nuevo(bool soloLectura)
        {
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Clear();
                    ((TextBox)item).ReadOnly = soloLectura;
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar(txtPlaca.Text.Trim());
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var vehiculo = new Vehiculo(txtPlaca.Text, txtMarca.Text,int.Parse(txtKMactual.Text));
            Actualizar(vehiculo);
            CargarLista("");
            GrillaVehiculos.Refresh();
        }
        void Actualizar(Vehiculo vehiculo)
        {
            MessageBox.Show(new ServicioVehiculo().Actualizar(vehiculo));
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtPlaca.Text.Length == 0)
            {
                return;
            }
            Eliminar(new ServicioVehiculo().BuscarID(txtPlaca.Text));
            CargarLista("");
            GrillaVehiculos.Refresh();
        }

        void Eliminar(Vehiculo vehiculo)
        {

            MessageBox.Show(new ServicioVehiculo().Eliminar(vehiculo));
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

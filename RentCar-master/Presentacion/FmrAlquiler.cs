using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Logica;

namespace Presentacion
{
    public partial class FmrAlquiler : Form
    {
        private static FmrAlquiler instacia = null;
        private Cliente Cliente;
        private Vehiculo Vehiculo;
        private Alquiler Alquiler;
        public FmrAlquiler()
        {
            InitializeComponent();
            
           
        }

        public static FmrAlquiler GetInstancia()
        {
            if (instacia == null || instacia.IsDisposed)
            {
                instacia = new FmrAlquiler();
            }
            return instacia;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void FmrAlquiler_Load(object sender, EventArgs e)
        {
            CargarLista("");
            CargarListaVehiculos("");
            CargarTodos();
        }

        void CargarTodos()
        {
            grillaClientes.DataSource = new ServicioAlquiler().Todos("");
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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var alquiler = new Alquiler(txtIdCliente.Text, txtPlaca.Text, DateTime.Now, Vehiculo.KilometrajeActual, double.Parse(txtValorKm.Text))
            {
                Descuento = (Cliente.TipoCliente.Equals("Contrato  ")) ? 15 : 0,
            };
            Insertar(alquiler);
        }


        void Insertar(Alquiler alquiler)
        {
            MessageBox.Show(new ServicioAlquiler().Insertar(alquiler));
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        void CargarLista(string condicion)
        {
            listaClientes.DataSource = new ServicioCliente().Todos(condicion);
            listaClientes.DisplayMember = "Nombre";
            listaClientes.ValueMember = "IDC";
            if (listaClientes.Items.Count >= 0)
            {
                listaClientes.SelectedIndex = 0;
                listaClientes.Select();
            }
        }

        private void listaClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = listaClientes.SelectedValue.ToString();
            Buscar(id);

            ;
        }
        void Buscar(string id)
        {

            try
            {
                var cliente = new ServicioCliente().BuscarID(id);
                 ver(cliente);
            }
            catch (Exception)
            {
                

            }


        }
        void ver(Entidades.Cliente cliente)
        {
            if (cliente != null)
            {
                Cliente = cliente;
                txtIdCliente.Text = cliente.IDC;
            }
            
        }



        private void listaClientes_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string id = listaClientes.SelectedValue.ToString();
            Buscar(id);
        }

        void CargarListaVehiculos(string condicion)
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


        void BuscarVehiculo(string id)
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
            if (vehiculo != null)
            {
                Vehiculo = vehiculo;
                txtPlaca.Text = vehiculo.PlacaVehiculo;
                txtKmRecepcion.Text = vehiculo.KilometrajeActual.ToString();
            }
            

        }

        private void listaVehiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = listaVehiculos.SelectedValue.ToString();
            BuscarVehiculo(id);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            BuscarAlquiler(textAlquiler.Text);

        }

        void Update(Alquiler alquiler)
        {
            MessageBox.Show(new ServicioAlquiler().Actualizar(alquiler));
        }

        void UpdateVehiculo(Vehiculo vehiculo)
        {
            MessageBox.Show(new ServicioVehiculo().Actualizar(vehiculo));
        }
        private void Actualizar(string placa, int kilometraje )
        {
            try
            {
                var vehiculo = new ServicioVehiculo().BuscarID(placa);
                vehiculo.KilometrajeActual = kilometraje;
                UpdateVehiculo(vehiculo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        void BuscarAlquiler(string id)
        {

            try
            {
                var alquiler = new ServicioAlquiler().BuscarID(id);
                verAlquiler(alquiler);
            }
            catch (Exception)
            {


            }


        }
        void verAlquiler(Entidades.Alquiler alquiler)
        {
            if (alquiler != null)
            {
                alquiler.FechaDeEntrega = dateTimePicker1.Value;
                alquiler.KmEntrega = Convert.ToDouble(txtKmEntrega.Text);
                alquiler.GetRecorrido();
                alquiler.CalcularAlquiler();
                Update(alquiler);
                Actualizar(alquiler.PlacaVehiculo,(int)alquiler.KmEntrega);
            }


        }
    }
}

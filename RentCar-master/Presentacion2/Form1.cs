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

namespace Presentacion2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var cliente = new Cliente(txtIdCliente.Text, txtNombre.Text, cmbTipo.SelectedValue.ToString(), cmbDepartamento.SelectedValue.ToString(), cmbMunicipio.SelectedValue.ToString());
            Insertar(cliente);
        }

        void Insertar(Cliente cliente)
        {
            MessageBox.Show(new ServicioCliente().Insertar(cliente));
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtIdCliente.Text.Length == 0)
            {
                return;
            }
            Eliminar(new ServicioCliente().BuscarID(txtIdCliente.Text));
        }

        void Eliminar(Cliente cliente)
        {

            MessageBox.Show(new ServicioCliente().Eliminar(cliente));
        }

        private void txtIdCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {


                
                var cliente= new ServicioCliente().BuscarID(txtIdCliente.Text);
                if (cliente != null)
                {
                    VerCliente(cliente);
                }
                else
                {
                    MessageBox.Show($"Cliente {txtIdCliente.Text} no existe");
                    txtIdCliente.Text = "";
                }

            }
        }

        public void VerCliente(Cliente cliente)
        {
            txtIdCliente.Text = cliente.IDC;
            txtNombre.Text = cliente.Nombre;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarComboTipo("");
            CargarComboDpto("");
            CargarComboMuni("");

        }

        void CargarComboTipo(string condicion)
        {
            cmbTipo.DataSource = new ServicioTipoCliente().Todos(condicion);
            cmbTipo.DisplayMember = "Tipo";
            cmbTipo.ValueMember = "IdCliente";
            if (cmbTipo.Items.Count >= 0)
            {
                cmbTipo.SelectedIndex = 0;
                cmbTipo.Select();
            }
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = cmbTipo.SelectedValue.ToString();
            BuscarIdTipo(id);
        }

        void BuscarIdTipo(string id)
        {

            try
            {
                var cliente = new ServicioTipoCliente().BuscarID(id);
                verTipo(cliente);
            }
            catch (Exception)
            {


            }


        }
        void verTipo(Entidades.TipoCliente tipoCliente)
        {
            if (tipoCliente == null)
            {
                return;
            }
            
            cmbTipo.Text =tipoCliente.Tipo;
        }

        void CargarComboDpto(string condicion)
        {
            cmbDepartamento.DataSource = new ServicioDepartamento().Todos(condicion);
            cmbDepartamento.DisplayMember = "Nombre_Departamento";
            //cmbTipo.ValueMember = "Codigo_Dpto";
            if (cmbDepartamento.Items.Count >= 0)
            {
                cmbDepartamento.SelectedIndex = 0;
                cmbDepartamento.Select();
            }
        }

        

        void BuscarIdDpto(string id)
        {

            try
            {
                var dpto = new ServicioDepartamento().BuscarID(id);
                verDpto(dpto);
            }
            catch (Exception)
            {


            }


        }
        void verDpto(Entidades.Departamento departamento)
        {
            if (departamento == null)
            {
                return;
            }

            cmbDepartamento.Text = departamento.Nombre_Departamento;
        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = cmbDepartamento.SelectedValue.ToString();
            BuscarIdDpto(id);
        }

        private void cmbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string id = cmbMunicipio.SelectedValue.ToString();
            
            BuscarIdMuni(id);
        }

        void BuscarIdMuni(string id)
        {

            try
            {
                var dpto = new ServicioMunicipio().BuscarID(id);
                verMuni(dpto);
            }
            catch (Exception)
            {


            }


        }

        void verMuni(Entidades.Municipio muni)
        {
            if (muni == null)
            {
                return;
            }
            
            cmbMunicipio.Text = muni.Nombre_Municipio;
        }

        void CargarComboMuni(string condicion)
        {
            cmbMunicipio.DataSource = new ServicioMunicipio().Todos(condicion);
            cmbMunicipio.DisplayMember = "Nombre_Municipio";
            //cmbTipo.ValueMember = "Codigo_Municipio";
            if (cmbMunicipio.Items.Count >= 0)
            {
                cmbMunicipio.SelectedIndex = 0;
                cmbMunicipio.Select();
            }
        }
    }
}



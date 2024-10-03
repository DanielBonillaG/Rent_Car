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
    public partial class FrmClientes : Form
    {
        private static FrmClientes instacia = null;
        public FrmClientes()
        {
            InitializeComponent();
            

        }
        public static FrmClientes GetInstancia()
        {
            if (instacia == null || instacia.IsDisposed)
            {
                instacia = new FrmClientes();
            }
            return instacia;
        }

        void AutoCompletar()
        {
            AutoCompleteStringCollection listaTipoClientes = new AutoCompleteStringCollection();
            listaTipoClientes.Add("Contrato"); // esto se puede obtener de la base de datos a traves de la logica de una tabla llamada tipoclintes
            listaTipoClientes.Add("Ocasional");
            txtTipo.AutoCompleteCustomSource = listaTipoClientes;
            txtTipo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtTipo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                               
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CargarLista("");
            CargarGrillaClientes("");
            AutoCompletar();
        }
        void CargarLista(string condicion)
        {
            listaClientes.DataSource = new ServicioCliente().Todos(condicion);
            listaClientes.DisplayMember = "Nombre";
            listaClientes.ValueMember = "IDC";
            if (listaClientes.Items.Count>=0)
            {
               listaClientes.SelectedIndex = 0;
                listaClientes.Select();
            }
        }
        void CargarGrillaClientes(string condicion)
        {
            grillaClientes.DataSource = new ServicioCliente().TodosFiltro(condicion);
           
        }

        private void listaClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = listaClientes.SelectedValue.ToString();
            Buscar(id);
            
;        }
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
            if (cliente== null)
            {
                return;
            }
            txtIdCliente.Text = cliente.IDC;
            txtNombre.Text = cliente.Nombre;
            txtTipo.Text = cliente.TipoCliente;
        }

        private void grillaClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = grillaClientes.Rows[e.RowIndex].Cells[0].Value.ToString();
            Buscar(id);
            listaClientes.SelectedIndex = e.RowIndex;
            this.tabControl1.TabPages[0].Show();
        }

        private void txtCondicion_TextChanged(object sender, EventArgs e)
        {
            string condicion = txtCondicion.Text.Trim();
            CargarGrillaClientes(condicion);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtIdCliente.Text.Length==0)
            {
                return;
            }
            Eliminar(new ServicioCliente().BuscarID(txtIdCliente.Text));
            CargarLista("");
            grillaClientes.Refresh();
        }
        void Eliminar(Cliente cliente) 
        {

           MessageBox.Show( new ServicioCliente().Eliminar(cliente));
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
          Buscar(txtIdCliente.Text.Trim());

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var cliente = new Cliente(txtIdCliente.Text, txtNombre.Text, txtTipo.Text);
            Actualizar(cliente);
            CargarLista("");
            grillaClientes.Refresh();
        }
        void Actualizar(Cliente cliente)
        {
            MessageBox.Show(new ServicioCliente().Actualizar(cliente));
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
                    ((TextBox)item).ReadOnly=soloLectura;
                }
            }
        }

        

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var cliente = new Cliente(txtIdCliente.Text, txtNombre.Text, txtTipo.Text);
            Insertar(cliente);
            CargarLista("");
            grillaClientes.Refresh();
        }

        void Insertar (Cliente cliente)
        {
            MessageBox.Show(new ServicioCliente().Insertar(cliente));
        }

        
    }
}

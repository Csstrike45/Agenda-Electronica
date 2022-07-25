using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using Capa_Presentacion;
using CapaDatos;

namespace Capa_Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool edit = false;
        private string id;

        C_Entidad c_Entidad = new C_Entidad();
        C_Negocio c_Negocio = new C_Negocio();

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarTabla("");
        }
        public void MostrarTabla(string buscar)
        {
            C_Negocio c_Negocio = new C_Negocio();
            dataGridView1.DataSource = c_Negocio.Listar(buscar);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            MostrarTabla(txtBuscar.Text);
        }

        private void vaciarCaja()
        {
            edit = false;
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            cbxGenero.Text = "";
            cbxEstadoCivil.Text = "";
            mtbMovil.Text = "";
            mtbTelefono.Text = "";
            txtCorreo.Text = "";
            txtNombre.Focus();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                edit = true;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtDireccion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                cbxGenero.SelectedItem = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                cbxEstadoCivil.SelectedItem = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                mtbMovil.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                mtbTelefono.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                txtCorreo.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            }
            else
            {
                MessageBox.Show("elija la fila que quiera editar");
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (edit == false)
            {
                try
                {
                    c_Entidad.Nombre = txtNombre.Text;
                    c_Entidad.Apellido = txtApellido.Text;
                    c_Entidad.Direccion = txtDireccion.Text;
                    c_Entidad.FechaNacimiento = dateTimePicker1.Value;
                    c_Entidad.Genero = cbxGenero.SelectedItem.ToString();
                    c_Entidad.EstadoCivil = cbxEstadoCivil.SelectedItem.ToString();
                    c_Entidad.Movil = mtbMovil.Text;
                    c_Entidad.Telefono = mtbTelefono.Text;
                    c_Entidad.Correo = txtCorreo.Text;

                    c_Negocio.InsertContacto(c_Entidad);
                    MessageBox.Show("Contacto Guardado");
                    MostrarTabla("");
                    vaciarCaja();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se guardó el contacto " + ex);
                }
            }
            if (edit == true)
            {
                try
                {
                    c_Entidad.ID = Convert.ToInt32(id);
                    c_Entidad.Nombre = txtNombre.Text;
                    c_Entidad.Apellido = txtApellido.Text;
                    c_Entidad.Direccion = txtDireccion.Text;
                    c_Entidad.FechaNacimiento = dateTimePicker1.Value;
                    c_Entidad.Genero = cbxGenero.Text.ToString();
                    c_Entidad.EstadoCivil = cbxEstadoCivil.Text.ToString();
                    c_Entidad.Movil = mtbMovil.Text;
                    c_Entidad.Telefono = mtbTelefono.Text;
                    c_Entidad.Correo = txtCorreo.Text;

                    c_Negocio.EditContacto(c_Entidad);
                    MessageBox.Show("Contacto Editado!");
                    MostrarTabla("");
                    vaciarCaja();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No fue posible editar el contacto seleccionado" + ex);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            vaciarCaja();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                c_Entidad.ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                c_Negocio.DeleteContacto(c_Entidad);

                MessageBox.Show("Se eliminó el contacto exitosamente!");
                MostrarTabla("");
            }
            else
            {
                MessageBox.Show("Selecciona el contacto que desea eliminar");
            }
        }
    }
}

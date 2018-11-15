using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using frmPrincipal.Models;

namespace frmPrincipal
{
    public partial class frmEliminar : Form
    {
        public frmEliminar()
        {
            InitializeComponent();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Instanciamos un objeto de tipo Cancion
            Cancion laCancion = new Cancion();
            // Verificamos si se selecciono
            if (lstCanciones.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un item");
            }
            else
            {
                laCancion.nombre = lstCanciones.SelectedItem.ToString();

                if (Cancion.eliminarCancion(laCancion))
                {
                    MessageBox.Show("Cancion Eliminado", "Informacion");
                }
                else
                {
                    MessageBox.Show("Hubo un error", "Informacion");
                }
            }
        }

        private void frmEliminar_Load(object sender, EventArgs e)
        {
            
            // Creamos un objeto de Tipo Cancion
            Cancion lacancion = new Cancion();

            // Almacenamos todos los clientes existentes
            List<Cancion> lista = Cancion.LeerTodos();

            // Si hay algun elemento en la lista
            // Lo agregaremos al listbox
            if (lista.Any())
            {
                listaArtistas.ForEach(artist => lstArtistas.Items.Add(artist.nombre.ToString()));
            }
            else
            {
                lstArtistas.Items.Add("No hay Artistas Disponibles");
            }
        }
    }
}


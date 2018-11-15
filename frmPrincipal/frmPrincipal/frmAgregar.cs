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
    public partial class frmAgregar : Form
    {
        public frmAgregar()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmAgregar_Load(object sender, EventArgs e)
        {
            // Listar ARTISTAS
            // Creamos un objeto de Tipo Artista
            Artista elArtista = new Artista();

            // Almacenamos todos los clientes existentes
            List<Artista> listaArtistas = Artista.LeerTodos();

            // Si hay algun elemento en la lista
            // Lo agregaremos al listbox
            if (listaArtistas.Any())
            {
                listaArtistas.ForEach(artist => lstArtistas.Items.Add(artist.nombre.ToString()));
            }
            else
            {
                lstArtistas.Items.Add("No hay Artistas Disponibles");
            }

            //LISTAR ALBUM
            // Creamos un objeto de Tipo Album
            Album elAlbum= new Album();

            // Almacenamos todos los clientes existentes
            List<Album> listaAlbum = Album.LeerTodos();

            // Si hay algun elemento en la lista
            // Lo agregaremos al listbox
            if (listaAlbum.Any())
            {
                listaAlbum.ForEach(albums => lstAlbum.Items.Add(albums.nombre.ToString()));
            }
            else
            {
                lstAlbum.Items.Add("No hay Albums Disponibles");
            }



        }

        private void lstArtistas_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Instanciamos la Clase Cancion
            Cancion nueva = new Cancion();
            nueva.nombre = txtNombre.Text;
            nueva.nombreArtista = lstArtistas.SelectedItem.ToString();
            nueva.nombreAlbum = lstAlbum.SelectedItem.ToString();
            nueva.genero = txtGenero.Text;
            nueva.genero = txtAnio.Text;

            if (Cancion.InsertarCancion(nueva))
            {
                MessageBox.Show("Agregado");
               
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}

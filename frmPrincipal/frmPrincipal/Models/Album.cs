using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Escribimos los NameSpaces necesarios
using System.Data;
using System.Data.SqlClient;

namespace frmPrincipal.Models
{
    class Album
    {
        // Propiedades
        public int id { get; set; }
        public string nombre { get; set; }
        public int artista { get; set; }

        /// <summary>
        /// Metodo para Leer todos los Album
        /// </summary>
        /// <returns></returns>
        public static List<Album> LeerTodos()
        {
            // instanciamos la clase conexion
            Conexion conexion = new Conexion(@"(local)", "BulletProofRecords");

            // Lista de un tipo de Album
            List<Album> resultados = new List<Album>();

            // creamos el query
            string sql = @"SELECT id, Nombre, Artista 
                            FROM Music.Album";

            SqlCommand cmd = conexion.EjecutarComando(sql);

            try
            {
                // Establecemos la conexions
                conexion.EstablecerConexion();
                // Ejecutamos el query vía un ExecuteReader
                SqlDataReader rdr = cmd.ExecuteReader();

                // Recorremos los elementos del Reader y los almacenamos
                // en la lista de Tipo Album

                while (rdr.Read())
                {
                    Album elAlbum = new Album();
                    // Asignamos los valor de Reader al objeto 
                    elAlbum.id = Convert.ToInt16(rdr[0]);
                    elAlbum.nombre = rdr.GetString(1);

                    // Agregamos el Artista a la lista
                    resultados.Add(elAlbum);
                }
                // retornamos la lista de los artistas
                return resultados;
            }
            catch (SqlException)
            {

                return resultados;
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }


    }
}

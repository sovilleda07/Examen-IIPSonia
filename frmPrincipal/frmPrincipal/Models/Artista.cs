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
    class Artista
    {
        // Propiedades
        public int id { get; set; }
        public string nombre { get; set; }
        public int Estado { get; set; }

        /// <summary>
        /// Metodo que lee todos los artistas disponibles
        /// </summary>
        /// <returns></returns>
        public static List<Artista> LeerTodos()
        {
            // instanciamos la clase conexion
            Conexion conexion = new Conexion(@"(local)", "BulletProofRecords");

            // Lista de un tipo de Artista
            List<Artista> resultados = new List<Artista>();

            // creamos el query
            string sql = @"SELECT id, Nombre 
                            FROM Music.Artista
                            WHERE Estado = 1";

            SqlCommand cmd = conexion.EjecutarComando(sql);

            try
            {
                // Establecemos la conexions
                conexion.EstablecerConexion();
                // Ejecutamos el query vía un ExecuteReader
                SqlDataReader rdr = cmd.ExecuteReader();

                // Recorremos los elementos del Reader y los almacenamos
                // en la lista de Tipo Artista

                while (rdr.Read())
                {
                    Artista elArtista = new Artista();
                    // Asignamos los valor de Reader al objeto Artista
                    elArtista.id = Convert.ToInt16(rdr[0]);
                    elArtista.nombre = rdr.GetString(1);

                    // Agregamos el Artista a la lista
                    resultados.Add(elArtista);
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

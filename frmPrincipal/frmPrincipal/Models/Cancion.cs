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
    class Cancion
    {

        // Propiedades
        public int id { get; set; }
        public string nombre { get; set; }
        public int artista { get; set; }
        public int album { get; set; }
        public string genero { get; set; }
        public string anio { get; set; }

        public string nombreArtista { get; set; }
        public string nombreAlbum { get; set; }

        /// <summary>
        /// Metodo para insertar una Nueva cancion
        /// </summary>
        /// <param name="nuevoCliente"></param>
        /// <returns></returns>
        public static bool InsertarCancion(Cancion nuevaCancion)
        {
            // instanciamos la conexion
            Conexion conexion = new Conexion(@"(local)", "BulletProofRecords");

            // enviamos el comando a ejecutar
            SqlCommand cmd = conexion.EjecutarComando("sp_InsertarCancion");

            // Establecer el comando como un Stored Procedure
            cmd.CommandType = CommandType.StoredProcedure;


            // Parámetros del Stored Procedure
            cmd.Parameters.Add(new SqlParameter("@NombreCancion", SqlDbType.NVarChar, 200));
            cmd.Parameters["@NombreCancion"].Value = nuevaCancion.nombre;
            cmd.Parameters.Add(new SqlParameter("@NombreArtista", SqlDbType.NVarChar, 200));
            cmd.Parameters["@NombreArtista"].Value = nuevaCancion.nombreArtista;
            cmd.Parameters.Add(new SqlParameter("@NombreAlbum", SqlDbType.NVarChar, 200));
            cmd.Parameters["@NombreAlbum"].Value = nuevaCancion.nombreAlbum;
            cmd.Parameters.Add(new SqlParameter("@Genero", SqlDbType.NVarChar, 200));
            cmd.Parameters["@Genero"].Value = nuevaCancion.genero;
            cmd.Parameters.Add(new SqlParameter("@AñoCreacion", SqlDbType.NVarChar, 4));
            cmd.Parameters["@AñoCreacion"].Value = nuevaCancion.anio;

            // intentamos ejecutar el procedimiento
            try
            {
                conexion.EstablecerConexion();

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException ex)
            {

                return false;
            }
            finally
            {
                conexion.CerrarConexion();
            }

        }

        public static bool eliminarCancion(Cancion laCancion)
        {
            // Instanciamos la conexion
            Conexion conexion = new Conexion(@"(local)", "BulletProofRecords");

            // Enviamos el comando a ejecutar
            SqlCommand cmd = conexion.EjecutarComando("sp_EliminarCancion");

            // Definimos que tipo de comando es
            cmd.CommandType = CommandType.StoredProcedure;

            // Definimos los parametros del Stored Procedure
            cmd.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar, 100));
            cmd.Parameters["@nombre"].Value = laCancion.nombre;

            try
            {
                // Establecemos la conexion
                conexion.EstablecerConexion();

                // Ejecutamos el query de eliminacion
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                conexion.CerrarConexion();
            }

        }

        public static List<Cancion> LeerTodos()
        {
            // instanciamos la clase conexion
            Conexion conexion = new Conexion(@"(local)", "BulletProofRecords");

            // Lista de un tipo de A
            List<Cancion> resultados = new List<Cancion>();

            // creamos el query
            string sql = @"SELECT * FROM Music.Cancion";

            SqlCommand cmd = conexion.EjecutarComando(sql);

            try
            {
                // Establecemos la conexions
                conexion.EstablecerConexion();
                // Ejecutamos el query vía un ExecuteReader
                SqlDataReader rdr = cmd.ExecuteReader();

                // Recorremos los elementos del Reader y los almacenamos
                // en la lista 

                while (rdr.Read())
                {
                    Cancion laCancion = new Cancion();
                    // Asignamos los valor de Reader al objeto
                    laCancion.nombre = rdr.GetString(0);

                    // Agregamos el Artista a la lista
                    resultados.Add(laCancion);
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

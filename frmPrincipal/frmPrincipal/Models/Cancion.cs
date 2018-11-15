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


    }
}

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
    }
}

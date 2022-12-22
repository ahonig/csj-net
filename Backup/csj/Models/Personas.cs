using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace csj.Models
{

    public class Personas
    {
        public int persona_id { get; set; }
        public int documento_tipo_id { get; set; }
        public string documento_nro { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string sexo { get; set; }
        public DateTime nacimiento { get; set; }
    }
}

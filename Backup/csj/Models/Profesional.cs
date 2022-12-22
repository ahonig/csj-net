using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace csj.Models
{
    public class Profesional
    {
        public int persona_id { get; set; }
        public int profesional_tipo_id { get; set; }
        public string matricula_nro { get; set; }
        public DateTime matricula_fecha_expedicion { get; set; }
        public int juramento_acta_nro { get; set; }
        public DateTime juramento_fecha { get; set; }
        public bool habilitado { get; set; }
        public string universidad { get; set; }
        public int egreso_anyo { get; set; }
        public string antecedente_penal { get; set; }
    }
}

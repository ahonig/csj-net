using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace csj.Models
{
    public class Carnet
    {
        public string carnet_qr { get; set; }
        public int persona_id { get; set; }
        public string profesional_tipo_id { get; set; }
        public bool impreso { get; set; }
        public int turno_id { get; set; }
        public DateTime fecha_expedicion { get; set; }
        public DateTime fecha_vencimiento { get; set; }
        public string liquidacion_nro { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;


namespace csj.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        [Authorize]
        public ActionResult Carnet(string id)
        {
             if (id != null
                && !string.IsNullOrEmpty(Request.Params["tipo"])
                && !string.IsNullOrEmpty(Request.Params["cedula"])
                && !string.IsNullOrEmpty(Request.Params["liquidacion"]))
            {
                int tipoProfesional = Int16.Parse(Request.Params["tipo"]);
                string cedula = Request.Params["cedula"];
                string nroLiquidacion = Request.Params["liquidacion"];
                csj.csjEntityProfesional pr = new csj.csjEntityProfesional();
                csj.csjEntityPersona pe = new csj.csjEntityPersona();
                csj.csjEntityProfesionalTipo pt = new csj.csjEntityProfesionalTipo();
                csj.csjEntityDomicilio dom = new csj.csjEntityDomicilio();

                ViewData["persona"] = null;
                ViewData["profesional"] = null;
                ViewData["profesionalTipo"] = null;
                var profesional = pr.profesional.FirstOrDefault(p => p.matricula_nro == id);

                if (profesional == null)
                {
                    System.Net.WebClient client = new System.Net.WebClient();
                    client.Headers.Add("content-type", "application/json");
                    string jsonResponse = client.DownloadString("http://190.211.242.210:555/profesional/"+tipoProfesional+"/" + id);
                    if (jsonResponse != "[]")
                    {
                        Root root = JsonConvert.DeserializeObject<Root>(jsonResponse);
                        ViewData["resultadoPersona"] = insertarRoot(root);
                        if (    (ViewData["resultadoPersona"] != null && !ViewData["resultadoPersona"].ToString().Contains("Error"))) {
                            
                            ViewData["resultadoProfesional"] = insertProfesional(root, tipoProfesional);
                            if (root.Domicilios != null)
                            {
                                List<Domicilio> domiciliosList = root.Domicilios;
                                ViewData["resultadoDomicilios"] = insertDomicilio(root, domiciliosList, tipoProfesional);
                            }
                            profesional = pr.profesional.FirstOrDefault(p => p.matricula_nro == id);

                        }
                        
                    }
                }

                if (profesional != null)
                {

                    var persona = pe.persona.FirstOrDefault(a => a.persona_id == profesional.persona_id);
                    if (persona.documento_nro != Request.Params["cedula"])
                    {
                        ViewData["resultadoPersona"] = "Error. La cedula no esta relacionada a la matricula";
                        return View();
                    }
                    var profesionalTipo = pt.profesional_tipo.FirstOrDefault(t => t.id == profesional.profesional_tipo_id);
                    var domicilios = dom.domicilio.Where(d => d.persona_id == profesional.persona_id);

                    ViewData["profesional"] = profesional;
                    ViewData["persona"] = persona;
                    ViewData["profesionalTipo"] = profesionalTipo;
                    ViewData["domicilios"] = domicilios;
                }
                else {
                    ViewData["resultadoPersona"] = "Error. No se ha encontrado la persona";
                }
            }
            return View();
        }

        [Authorize]
        public ActionResult Imprimir(string id)
        {
            csj.csjEntityPersona pe = new csj.csjEntityPersona();
            csj.csjEntityCarnet ca = new csj.csjEntityCarnet();
            csj.csjEntityProfesional pr = new csj.csjEntityProfesional();
            csj.csjEntityProfesionalTipo pt = new csj.csjEntityProfesionalTipo();

            ViewData["carnet"] = null;
            ViewData["persona"] = null;
            ViewData["profesional"] = null;
            ViewData["profesionalTipo"] = null;

            var carnet = ca.carnet.FirstOrDefault(c => c.carnet_qr == id);
            if (carnet != null)
            {
                var persona = pe.persona.FirstOrDefault(a => a.persona_id == carnet.persona_id);
                var profesional = pr.profesional.FirstOrDefault(p => p.persona_id == carnet.persona_id && p.profesional_tipo_id == carnet.profesional_tipo_id);
                var profesionalTipo = pt.profesional_tipo.FirstOrDefault(t => t.id == carnet.profesional_tipo_id);
                ViewData["persona"] = persona;
                ViewData["carnet"] = carnet;
                ViewData["profesional"] = profesional;
                ViewData["profesionalTipo"] = profesionalTipo;
            }

            return View();
        }

        [Authorize]
        [HttpPost] 
        public JsonResult GuardarCarnet(CarnetData carnet)
        {
            var vlMessage = "";
            var vlResult = "Ok";
            SqlConnectionStringBuilder myBuilder = new SqlConnectionStringBuilder();
		    myBuilder.UserID = "csj";
		    myBuilder.Password = "CSJ_148";
		    myBuilder.InitialCatalog = "csj";
		    myBuilder.DataSource = "tcp:127.0.0.1";
		    myBuilder.ConnectTimeout = 30;

            //Obtener carnet_id
            try { 
                using (SqlConnection conn = new SqlConnection(myBuilder.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("dbo.generar_codigo_carnet", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@carnet_qr", SqlDbType.VarChar, 12).Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    vlMessage = Convert.ToString(cmd.Parameters["@carnet_qr"].Value);
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                vlResult = "error";
                vlMessage = "Error al obtener el codigo de carnet: "+e.Message;
            }

            //Insertar
            if (vlResult != "error")
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(myBuilder.ConnectionString))
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.carnet (carnet_qr, persona_id, profesional_tipo_id, impreso, fecha_expedicion, fecha_vencimiento, liquidacion_nro) VALUES (@carnet_qr, @persona_id, @profesional_tipo_id, @impreso, @fecha_expedicion, @fecha_vencimiento, @liquidacion_nro)", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@carnet_qr", SqlDbType.VarChar, 12).Value = vlMessage;
                        cmd.Parameters.Add("@persona_id", SqlDbType.Int, 11).Value = carnet.persona_id;
                        cmd.Parameters.Add("@profesional_tipo_id", SqlDbType.SmallInt, 6).Value = carnet.profesional_tipo_id;
                        cmd.Parameters.Add("@impreso", SqlDbType.Bit, 12).Value = true;
                        //cmd.Parameters.Add("@turno_id", SqlDbType.VarChar, 12).Value = "";
                        cmd.Parameters.Add("@fecha_expedicion", SqlDbType.DateTime, 12).Value = DateTime.Now;
                        cmd.Parameters.Add("@fecha_vencimiento", SqlDbType.DateTime, 12).Value = DateTime.Now.AddDays(5);
                        cmd.Parameters.Add("@liquidacion_nro", SqlDbType.VarChar, 10).Value = carnet.liquidacion_nro;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                catch (Exception e)
                {
                    vlResult = "error";
                    vlMessage = "Error al insertar el carnet nuevo: " + e.Message;
                }
            }

            //Guardar Imagen
            if (vlResult != "error")
            {
                try
                {

                    System.IO.File.WriteAllBytes(@"c:\public_cjs\Content\" + vlMessage + ".png", Convert.FromBase64String(carnet.foto));


                }
                catch (Exception e)
                {
                    vlResult = "error";
                    vlMessage = "Error al guardar la imagen en disco: " + e.Message;
                }
            }
            //Objeto respuesta
            var respuesta = new
            {
                result = vlResult,
                message = vlMessage
            };



            return Json(respuesta);
        }

        [Authorize(Users="ADMIN, AGOMEZ")]
        public ActionResult List() {
            csj.csjJoinCarnetsEntities ca = new csj.csjJoinCarnetsEntities();
            var carnets = ca.ListaCarnets.Where(p => p.carnet_qr != null);
            ViewData["carnets"] = carnets;
            return View();
        }

        [Authorize(Users = "ADMIN, AGOMEZ")]
        [HttpPost]
        public JsonResult GetData()
        {
            // Initialization.   
            JsonResult result = new JsonResult();
            try
            {
                // Initialization.   
                string search = Request.Form.GetValues("search[value]")[0];
                string draw = Request.Form.GetValues("draw")[0];
                string order = Request.Form.GetValues("order[0][column]")[0];
                string orderDir = Request.Form.GetValues("order[0][dir]")[0];
                int startRec = Convert.ToInt32(Request.Form.GetValues("start")[0]);
                int pageSize = Convert.ToInt32(Request.Form.GetValues("length")[0]);
                // Loading.   
                csj.csjJoinCarnetsEntities ca = new csj.csjJoinCarnetsEntities();
                List<ListaCarnets> data = ca.ListaCarnets.Where(p => p.carnet_qr != null).ToList();
                // Total record count.   
                int totalRecords = data.Count;
                // Verification.   
                if (!string.IsNullOrEmpty(search))
                {
                    // Apply search   
                    data = data.Where(p => p.carnet_qr.ToLower().Contains(search.ToLower()) ||
                        p.documento_nro.ToLower().Contains(search.ToLower()) ||
                        p.nombres.ToString().ToLower().Contains(search.ToLower()) ||
                        p.apellidos.ToLower().Contains(search.ToLower()) ||
                        p.descripcion.ToLower().Contains(search.ToLower()) ||
                        p.fecha_expedicion.ToString().ToLower().Contains(search.ToLower()) ||
                        p.fecha_vencimiento.ToString().ToLower().Contains(search.ToLower()) ||
                        p.liquidacion_nro.ToString().ToLower().Contains(search.ToLower())).ToList();
                }
                // Sorting.   
                data = this.SortByColumnWithOrder(order, orderDir, data);
                // Filter record count.   
                int recFilter = data.Count;
                // Apply pagination.   
                data = data.Skip(startRec).Take(pageSize).ToList();
                // Loading drop down lists.   
                result = this.Json(new
                {
                    draw = Convert.ToInt32(draw),
                    recordsTotal = totalRecords,
                    recordsFiltered = recFilter,
                    data = data
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // Info   
                Console.Write(ex);
            }
            // Return info.   
            return result;
        }

        private List<ListaCarnets> SortByColumnWithOrder(string order, string orderDir, List<ListaCarnets> data)
        {
            // Initialization.   
            List<ListaCarnets> lst = new List<ListaCarnets>();
            try
            {
                // Sorting   
                switch (order)
                {
                    case "0":
                        // Setting.   
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.carnet_qr).ToList() : data.OrderBy(p => p.carnet_qr).ToList();
                        break;
                    case "1":
                        // Setting.   
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.documento_nro).ToList() : data.OrderBy(p => p.documento_nro).ToList();
                        break;
                    case "2":
                        // Setting.   
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.nombres).ToList() : data.OrderBy(p => p.nombres).ToList();
                        break;
                    case "3":
                        // Setting.   
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.apellidos).ToList() : data.OrderBy(p => p.apellidos).ToList();
                        break;
                    case "4":
                        // Setting.   
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.descripcion).ToList() : data.OrderBy(p => p.descripcion).ToList();
                        break;
                    case "5":
                        // Setting.   
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.fecha_expedicion).ToList() : data.OrderBy(p => p.fecha_expedicion).ToList();
                        break;
                    case "6":
                        // Setting.   
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.fecha_vencimiento).ToList() : data.OrderBy(p => p.fecha_vencimiento).ToList();
                        break;
                    case "7":
                        // Setting.   
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.liquidacion_nro).ToList() : data.OrderBy(p => p.liquidacion_nro).ToList();
                        break;
                    default:
                        // Setting.   
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.carnet_qr).ToList() : data.OrderBy(p => p.carnet_qr).ToList();
                        break;
                }
            }
            catch (Exception ex)
            {
                // info.   
                Console.Write(ex);
            }
            // info.   
            return lst;
        }

        public class CarnetData {
            public string carnet_qr { get; set; }
            public int persona_id { get; set; }
            public int profesional_tipo_id { get; set; }
            public int impreso { get; set; }
            public int turno_id { get; set; }
            public string fecha_expedicion { get; set; }
            public string fecha_vencimiento { get; set; }
            public string liquidacion_nro { get; set; }
            public string foto { get; set; }
        }

        private Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        private ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        public class Domicilio
        {
            public string CodigoDomicilio { get; set; }
            public string TipoDomicilio { get; set; }
            public string LocalidadDomicilio { get; set; }
            public string CodigoLocalidad { get; set; }
            public string CalleDomicilio { get; set; }
            public string Telefono1 { get; set; }
            public string Telefono2 { get; set; }
            public string CorreoElectronico { get; set; }
        }

        public class Root
        {
            public string CodigoPersona { get; set; }
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public string TipoDocumento { get; set; }
            public string DescripcionTipoDocumento { get; set; }
            public string NroDocumento { get; set; }
            public string Sexo { get; set; }
            public string FechaNacimiento { get; set; }
            public string Matricula { get; set; }
            public string FechaExpedicionMatricula { get; set; }
            public string FechaJuramento { get; set; }
            public string NroActaJuramento { get; set; }
            public string Habilitado { get; set; }
            public string Universidad { get; set; }
            public string AnoEgreso { get; set; }
            public string AntecedentesPenales { get; set; }
            public List<Domicilio> Domicilios { get; set; }
            public List<object> Sanciones { get; set; }
            public List<object> Especialidades { get; set; }
        }

        private String insertarRoot(Root root) {
            var vlResult = "Ok";
            try
            {
                using (SqlConnection conn = new SqlConnection(obtenerConexion()))
                using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.persona (persona_id, documento_tipo_id, documento_nro, nombres, apellidos, sexo, nacimiento) values (@persona_id, @documento_tipo_id, @documento_nro, @nombres, @apellidos, @sexo, @nacimiento)", conn))
                {

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@persona_id", SqlDbType.Int, 11).Value = root.CodigoPersona;
                    cmd.Parameters.Add("@documento_tipo_id", SqlDbType.Int, 11).Value = 1;
                    cmd.Parameters.Add("@documento_nro", SqlDbType.VarChar, 8).Value = root.NroDocumento;
                    cmd.Parameters.Add("@nombres", SqlDbType.VarChar, 64).Value = root.Nombres;
                    cmd.Parameters.Add("@apellidos", SqlDbType.VarChar, 64).Value = root.Apellidos;
                    cmd.Parameters.Add("@sexo", SqlDbType.VarChar, 1).Value = root.Sexo;
                    cmd.Parameters.Add("@nacimiento", SqlDbType.DateTime, 12).Value = root.FechaNacimiento;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                vlResult = "Error al insertar el carnet nuevo: " + e.Message;
            }
            return vlResult;
        }
   
        private String insertProfesional(Root root, int tipo_profesional) {
            var vlResult = "Ok";
            
            try
            {
                using (SqlConnection conn = new SqlConnection(obtenerConexion()))
                using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.profesional (persona_id,profesional_tipo_id, matricula_nro, matricula_fecha_expedicion, juramento_acta_nro, juramento_fecha, habilitado, universidad, egreso_anyo, antecedente_penal) values (@persona_id, @profesional_tipo_id, @matricula_nro, @matricula_fecha_expedicion, @juramento_acta_nro, @juramento_fecha, @habilitado, @universidad, @egreso_anyo, @antecedente_penal)", conn))
                {

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@persona_id", SqlDbType.Int, 11).Value = root.CodigoPersona;
                    cmd.Parameters.Add("@profesional_tipo_id", SqlDbType.Int, 11).Value = tipo_profesional;
                    cmd.Parameters.Add("@matricula_nro", SqlDbType.VarChar, 8).Value = root.Matricula;
                    cmd.Parameters.Add("@matricula_fecha_expedicion", SqlDbType.DateTime, 12).Value = root.FechaExpedicionMatricula;
                    cmd.Parameters.Add("@juramento_acta_nro", SqlDbType.Int, 11).Value = root.NroActaJuramento;
                    cmd.Parameters.Add("@juramento_fecha", SqlDbType.DateTime, 12).Value = root.FechaJuramento;
                    cmd.Parameters.Add("@habilitado", SqlDbType.Bit, 1).Value = true;
                    cmd.Parameters.Add("@universidad", SqlDbType.VarChar, 255).Value = root.Universidad;
                    cmd.Parameters.Add("@egreso_anyo", SqlDbType.Int, 4).Value = root.AnoEgreso;
                    cmd.Parameters.Add("@antecedente_penal", SqlDbType.VarChar, 255).Value = root.AntecedentesPenales;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                vlResult = "Error al insertar el profesional nuevo: " + e.Message;
            }
            return vlResult;
        
        }

        private String insertDomicilio(Root root, List<Domicilio> domicilios, int tipo_profesional)
        {
            
            var vlResult = "Ok";

            try
            {
                using (SqlConnection conn = new SqlConnection(obtenerConexion()))
                using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.domicilio (domicilio_id, persona_id, profesional_tipo_id, domicilio_tipo, localidad, calle, telefono1, telefono2, correo_electronico, localidad_codigo) values (@domicilio_id, @persona_id, @profesional_tipo_id, @domicilio_tipo, @localidad, @calle, @telefono1, @telefono2, @correo_electronico, @localidad_codigo)", conn))
                {
                    conn.Open();
                    foreach(Domicilio domicilio in domicilios) {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@domicilio_id", SqlDbType.Int, 11).Value = domicilio.CodigoDomicilio;
                        cmd.Parameters.Add("@persona_id", SqlDbType.Int, 11).Value = root.CodigoPersona;
                        cmd.Parameters.Add("@profesional_tipo_id", SqlDbType.Int, 11).Value = tipo_profesional;
                        cmd.Parameters.Add("@domicilio_tipo", SqlDbType.VarChar, 16).Value = domicilio.TipoDomicilio;
                        cmd.Parameters.Add("@localidad", SqlDbType.VarChar, 255).Value = domicilio.LocalidadDomicilio;
                        cmd.Parameters.Add("@calle", SqlDbType.VarChar, 255).Value = domicilio.CalleDomicilio;
                        cmd.Parameters.Add("@telefono1", SqlDbType.VarChar, 64).Value = domicilio.Telefono1;
                        cmd.Parameters.Add("@telefono2", SqlDbType.VarChar, 64).Value = domicilio.Telefono2;
                        cmd.Parameters.Add("@correo_electronico", SqlDbType.VarChar, 128).Value = domicilio.CorreoElectronico;
                        cmd.Parameters.Add("@localidad_codigo", SqlDbType.Int, 11).Value = domicilio.CodigoLocalidad;
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                vlResult = "Error al insertar el profesional nuevo: " + e.Message;
            }
            return vlResult;

        }

        private String obtenerConexion()
        {
            SqlConnectionStringBuilder myBuilder = new SqlConnectionStringBuilder();
            myBuilder.UserID = "csj";
            myBuilder.Password = "CSJ_148";
            myBuilder.InitialCatalog = "csj";
            myBuilder.DataSource = "tcp:127.0.0.1";
            myBuilder.ConnectTimeout = 30;
            return myBuilder.ConnectionString;
        }
    }
}

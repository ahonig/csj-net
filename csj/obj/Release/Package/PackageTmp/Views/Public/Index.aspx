<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" Debug="true" %>
<% var pers = (@csj.persona) ViewData["persona"]; %>
<% var carn = (@csj.carnet) ViewData["carnet"]; %>
<% var prof = (@csj.profesional) ViewData["profesional"]; %>
<% var tipo = (@csj.profesional_tipo) ViewData["profesionalTipo"]; %>

<% 
   if (@carn == null) {
       //Response.Redirect("/");
   } 
%> 
<!DOCTYPE html>
<html lang="es">
  <head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="<%=ResolveClientUrl("~/Content/bootstrap.min.css") %>">
    <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="<%=ResolveClientUrl("~/Content/corte.css?v=1.0") %>">
    <title>Corte Suprema de Justicia</title>
  </head>
  <body>
    <div class="container-fluid  ">
      <div class="row card_container align-items-center justify-content-center ">
        <div class="col justify-content-center">
          <div class="card ">
            <div class="card-body m-0">
              <div class="row align-items-center rowinsidecard">
                <div class="col colinfo">
                  <div class="row">
                    <div class="col-12">
                      <img src="<%=ResolveClientUrl("~/Content/corte_suprema.png") %>" class="img-fluid logocorte" />
                      <div class="row visible_vertical justify-content-center">
                        <div class="col-6 mb-3">
                          <img src="<%=ResolveClientUrl("~/Content/carnet/"+(@carn != null ? @carn.carnet_qr : "")+".png") %>" class="img-fluid" />
                        </div>
                        <!-- col -->
                      </div>
                      <!-- row -->
                      <h6 class="card-subtitle text-muted">APELLIDOS</h6>
                      <h5 class="card-title"><%= (@pers != null ? @pers.apellidos : "")%> </h5>
                      <h6 class="card-subtitle text-muted">NOMBRES</h6>
                      <h5 class="card-title"><%= (@pers != null ? @pers.nombres : "") %> </h5>
                      <h6 class="card-subtitle text-muted">CÉDULA DE IDENTIDAD</h6>
                      <h5 class="card-title"><%= (@pers != null ? String.Format("{0:#.##}", @pers.documento_nro) : "")%> </h5>
                      <h6 class="card-subtitle text-muted">PROFESIONAL</h6>
                      <h5 class="card-title"><%= (@tipo != null ? @tipo.descripcion : "")%></h5>
                      <div class="row visible_vertical">
                        <div class="col-6">
                          <h6 class="card-subtitle text-muted">MATRÍCULA</h6>
                          <h5 class="card-title"><%= (@prof != null ? @prof.matricula_nro : "")%></h5>
                        </div>
                        <!-- col -->
                        <div class="col-6">
                          <h6 class="card-subtitle text-muted">VENCIMIENTO</h6>
                          <h5 class="card-title"><%= (@carn != null ? @carn.fecha_vencimiento.ToString() : "")%></h5>
                        </div>
                        <!-- col -->
                      </div>
                      <!-- row -->
                    </div>
                    <!-- col -->
                  </div>
                  <!-- row -->  
                  <div class="row cajabotones no-gutters">
                    <div class="col-12">
                      <a href="javascript:void(0)" id="masinfo" class="btn btn-primary d-inline">Ver más</a>
                    </div>
                    <!-- col -->
                  </div>
                  <!-- row -->
                </div>
                <!-- colinfo -->
                <div class="col colfoto visible_horizontal">
                  <div class="row ">
                    <div class="col-12">
                      <img src="<%=ResolveClientUrl("~/Content/carnet/"+(@carn != null ? @carn.carnet_qr : "")+".png") %>" class="img-fluid" />
                    </div>
                    <!-- col -->
                  </div>
                  <!-- row -->
                  <div class="row">
                    <div class="col-12">
                      <div class="col_matricula">
                        <h6 class="card-subtitle text-muted">MATRÍCULA</h6>
                        <h5 class="card-title"><%= (@prof != null ? @prof.matricula_nro : "")%></h5>
                      </div>
                      <!-- col_matricula -->
                      <div class="col_vencimiento">
                        <h6 class="card-subtitle text-muted">VENCIMIENTO</h6>
                        <h5 class="card-title"><%= (@carn != null ? @carn.fecha_vencimiento.ToString().Substring(0, 10) : "")%></h5>
                      </div>
                      <!-- col_vencimiento -->
                    </div>
                    <!-- col -->
                  </div>
                  <!-- row -->
                </div>
                <!-- col -->
              </div>
              <!-- rowinsidecard -->
            </div>
          </div>
          <!-- col -12 -->
        </div>
      </div>
      <!-- row -->
    </div>
    <!-- container -->
    <div class="container tablainfo mb-5">
      <div class="row">
        <div class="col-12">
          <h3>Información</h3>
        </div>
        <!-- col -->
      </div>
      <!-- row -->
      <div class="row w-100 info_fila">
        <div class="col">Fecha de Nac.</div>
        <div class="col"><%= (@pers != null ? @pers.nacimiento.ToString().Substring(0,10): "") %></div>
      </div>
      <div class="row w-100 info_fila">
        <div class="col">Sexo</div>
        <div class="col"><%= (@pers != null ? (@pers.sexo == "F" ? "Femenino" : "Masculino") : "") %> </div>
      </div>
      <div class="row w-100 info_fila">
        <div class="col">Fecha Exp. Matric.</div>
        <div class="col"><%= (@prof != null ? @prof.matricula_fecha_expedicion.ToString().Substring(0, 10) : "")%></div>
      </div>
      <div class="row w-100 info_fila">
        <div class="col">Fecha de Juramento</div>
        <div class="col"><%= (@prof != null ? @prof.juramento_fecha.ToString().Substring(0,10): "") %></div>
      </div>
      <div class="row w-100 info_fila">
        <div class="col">N&deg; de Acta de Juramento</div>
        <div class="col"><%= (@prof != null ? @prof.juramento_acta_nro.ToString(): "") %></div>
      </div>
      <div class="row w-100 info_fila">
        <div class="col">Habilitado</div>
        <div class="col"><%= (@prof != null ? (@prof.habilitado == true ? "S&iacute;" : "No"): "") %></div>
      </div>
      <div class="row w-100 info_fila">
        <div class="col">Universidad</div>
        <div class="col"><%= (@prof != null ? @prof.universidad: "") %></div>
      </div>
      <div class="row w-100 info_fila">
        <div class="col">Año de Egreso</div>
        <div class="col"><%= (@prof != null ? @prof.egreso_anyo.ToString(): "") %></div>
      </div>
      <div class="row w-100 info_fila">
        <div class="col">Antecedente penal</div>
        <div class="col"><%= (@prof != null ? @prof.antecedente_penal: "") %></div>
      </div>
       


    </div>
    <!-- col  -->

    <% if (@prof != null && @prof.legajo_archivo_nombre != null) { %>
    <div class="container">
      <div class="row card_container" style="min-height: initial">
        <div class="col-12 text-center cajabotones mb-5">
          <a class="btn btn-primary" href="<%=ResolveClientUrl("~/Content/legajo/"+(@prof != null ? @prof.legajo_archivo_nombre: "")) %>" target="_blank">Ver legajo</a>
        </div>
        <!-- col -->
      </div>
      <!-- row -->
    </div>
    <!-- col  -->
    <% } %>


       
    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
    <script>
        $(function() {
            $('#masinfo').on('click', function() {
                $('html,body').animate({
                    scrollTop: $('.tablainfo').offset().top
                }, 1000);
                return false;
            });
        });
    </script>
  </body>
</html>
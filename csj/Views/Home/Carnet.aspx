<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" Debug="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Carnet
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<% var pers = (@csj.persona) ViewData["persona"];                  %>
<% var prof = (@csj.profesional) ViewData["profesional"];          %>
<% var tipo = (@csj.profesional_tipo) ViewData["profesionalTipo"]; %>
<% var resultadoPersona = (string) ViewData["resultadoPersona"]; %>
<% var resultadoProfesional = (string)ViewData["resultadoProfesional"]; %>
<% var domi = (IEnumerable<@csj.domicilio>) ViewData["domicilios"]; %>

<% if (prof == null)
   { %>
       
    <div class="content" style="margin-top: 20px;">
         
        <div class="container-fluid">
            <% if (    (resultadoPersona != null && resultadoPersona.Contains("Error"))
            || (resultadoProfesional != null && resultadoProfesional.Contains("Error")))
               {
                   var mensajeError = resultadoPersona + "  " + resultadoProfesional;
                   %>
             <div class="row">
                <div class="card">
                 
                     <div class="alert alert-danger">
	                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
	                    <i class="material-icons">close</i>
	                    </button>
	                    <span>
	                    <b> Error - </b> <%= mensajeError %> </span>
	                 </div>
	             
	            </div>
	         </div>
             
            <% }  %>
            <div class="row">
	            <div class="col-md-12">
		            <form id="formularioBuscar" onSubmit="return buscarCarnet(event);" autocomplete="off">
			            <div class="card ">
            				
				            <div class="card-header card-header-icon card-header-info">

					            <div class="card-icon">
						            <i class="material-icons">portrait</i>
					            </div>

					            <h4 class="card-title">Carnet de identificación</h4>

				            </div>

                            <div class="card-body ">
                                <div class="row">
                                    <div class="form-group bmd-form-group col-md-3">
                                        <select id="tipoProfesional" class="selectpicker" data-style="select-with-transition" name="tipoProfesional" required="true" title="Seleccione un tipo de profesional" data-size="10">
                                          <option value="" selected="selected">Seleccione tipo</option>
                                          <option value="1">Abogado</option>
                                          <option value="2">Oficial de Justicia</option>
                                          <option value="3">Perito</option>
                                          <option value="4">Traductor</option>
                                          <option value="5">Escribano</option>
                                          <option value="6">Procurador</option> 
                                          <option value="7">Mediador</option>
                                          <option value="8">Rematador</option>
                                        </select>
                                    </div>
						            <div class="form-group bmd-form-group col-md-3">
                                        <label for="matricula" class="bmd-label-floating"> Nro. Matr&iacute;cula *</label>
                                        <input type="number" class="form-control" id="matricula" name="matricula" required="true" title="La matricula es obligatoria" aria-required="true" maxlength="5">
                                    </div>
                                    <div class="form-group bmd-form-group col-md-3">
                                        <label for="cedula" class="bmd-label-floating"> Cédula *</label>
                                        <input type="text" class="form-control" id="cedula" name="cedula" required="true" title="La cedula es obligatoria" aria-required="true" maxlength="8">
                                    </div>
                                    <div class="form-group bmd-form-group col-md-3">
                                        <label for="liquidacion" class="bmd-label-floating"> Nro. de Liquidaci&oacute;n *</label>
                                        <input type="text" class="form-control" id="liquidacion" name="liquidacion" required="true" title="El Nro. de Liquidacion es obligatorio" aria-required="true" maxlength="10">
                                    </div>
                                    <div class="category form-category">* Campos requeridos</div>
                                </div>
					        </div>
                            
                            <div class="card-footer text-right">
                                <button type="submit" class="btn btn-info">Buscar</button>
                            </div>
                        </div>
		            </form>
                </div>
            </div>
        </div>
    </div>
<% }
   else
{ %>
<div class="content" style="margin-top: 20px;">
        <div class="container-fluid">
            <div class="row">
	            <div class="col-md-12">
		            <form id="generarCarnet" target="_self" onSubmit="return guardarCarnet(event);">
			            <div class="card ">
            				
				            <div class="card-header card-header-icon card-header-info">

					            <div class="card-icon">
						            <i class="material-icons">portrait</i>
					            </div>

					            <h4 class="card-title">Carnet de identificación</h4>

				            </div>

                            <div class="card-body ">
                                <div class="row">
						            <div class="col-md-8">
								        <dl class="row">
									        <div class="col-md-6">

										        <h4 class="card-title text-info">Datos personales</h4>
										        <div class="row">
											        <div class="col-md-6">
												        <div class="row">
													        <dt class="col-sm-12 ">Nombres</dt>
													        <dd class="col-sm-12"><%= (@pers != null ? @pers.nombres : "")%></dd>
												        </div>
											        </div>
											        <div class="col-md-6">
												        <div class="row">
													        <dt class="col-sm-12 ">Apellidos</dt>
													        <dd class="col-sm-12"><%= (@pers != null ? @pers.apellidos : "")%></dd>
												        </div>
											        </div>
										        </div>

										        <div class="row">
											        <div class="col-md-6">
												        <div class="row">
													        <dt class="col-sm-12">Sexo</dt>
													        <dd class="col-sm-12"><%= (@pers != null ? (@pers.sexo == "F" ? "Femenino" : "Masculino") : "") %></dd>
												        </div>
											        </div>
											        <div class="col-md-6">
												        <div class="row">
													        <dt class="col-sm-12">Fecha nacimiento</dt>
													        <dd class="col-sm-12"><%= (@pers != null ? @pers.nacimiento.ToString().Substring(0,10): "") %></dd>
												        </div>
											        </div>
										        </div>

										        <div class="row">
											        <dt class="col-sm-12 ">Cédula</dt>
											        <dd class="col-sm-12"><%= (@pers != null ? String.Format("{0:#.##}", @pers.documento_nro) : "")%></dd>
										        </div>

									        </div>



									        <div class="col-md-6">

										        <h4 class="card-title text-info">Datos profesionales</h4>

										        <div class="row">
											        <div class="col-md-6">
												        <div class="row">
													        <dt class="col-sm-12">Acta de juramento</dt>
													        <dd class="col-sm-12"><%= (@prof != null ? @prof.juramento_acta_nro.ToString(): "") %></dd>
												        </div>
											        </div>
											        <div class="col-md-6">
												        <div class="row">
													        <dt class="col-sm-12 ">Fecha de juramento</dt>
													        <dd class="col-sm-12"><%= (@prof != null ? @prof.juramento_fecha.ToString().Substring(0,10): "") %></dd>
												        </div>
											        </div>
										        </div>
										        <div class="row">
											        <div class="col-md-6">
												        <div class="row">
													        <dt class="col-sm-12 ">Universidad</dt>
													        <dd class="col-sm-12"><%= (@prof != null ? @prof.universidad: "") %></dd>
												        </div>
											        </div>
											        <div class="col-md-6">
												        <div class="row">
													        <dt class="col-sm-12 ">Año egreso</dt>
													        <dd class="col-sm-12"><%= (@prof != null ? @prof.egreso_anyo.ToString(): "") %></dd>
												        </div>
											        </div>
										        </div>
										        <div class="row">
											        <div class="col-md-6">
												        <div class="row">
													        <dt class="col-sm-12 ">Matrícula</dt>
													        <dd class="col-sm-12"><%= (@prof != null ? @prof.matricula_nro : "")%></dd>
												        </div>
											        </div>
											        <div class="col-md-6">
												        <div class="row">
													        <dt class="col-sm-12 ">Fecha expedición</dt>
													        <dd class="col-sm-12"><%= (@prof != null ? @prof.matricula_fecha_expedicion.ToString().Substring(0, 10) : "")%></dd>
												        </div>
											        </div>
										        </div>
        										
        									

									        </div>

								        </dl>
        								
								        <h4 class="card-title text-info">Datos de contacto</h4>
								        <div class="row">
									        <div class="col-md-12">
										        <table class="table table-sm">
											        <thead>
												        <tr>
													        <th>Tipo</th>
													        <th>Localidad</th>
													        <th>Dirección</th>
													        <th>Teléfono 1</th>
													        <th>Teléfono 2</th>
													        <th>Email</th>
												        </tr>
											        </thead>
											        <tbody>
                                                    <%  
                                                     if (@domi != null) { 
                                                        foreach(var dom in domi) {
                                                           %>
                                                           <tr>
													            <td><%= dom.domicilio_tipo %></td>
													            <td><%= dom.localidad %></td>
													            <td><%= dom.calle %></td>
													            <td><%= dom.telefono1 %></td>
													            <td><%= dom.telefono2 %></td>
													            <td><%= dom.correo_electronico %></td>
												            </tr>
                                                           <% 
                                                        }
                                                     } 
                                                    %>
											        </tbody>
										        </table>
									        </div>
								        </div>

								        <div class="card-header" style="padding-left: 0px;">
									        <h4 class="card-title text-info">Antecedentes penales</h4>
								        </div>
								        <div class="row">
									        <div class="col-md-12">
										        <p><%= (@prof != null ? @prof.antecedente_penal: "") %></p>
									        </div>
								        </div>

								        <div class="card-header" style="padding-left: 0px;">
									        <h4 class="card-title text-info">Sanciones</h4>
								        </div>
								        <div class="row">
									        <div class="col-md-12">
										        <p>No poseee sanciones</p>
									        </div>
								        </div>

							        </div>
							        <div class="col-md-4 text-center">
                                        <div id="camera-sector">
                                            <div class="camera-portrait">
									            <div id="camara" style="display: none;"></div>
									            <img id="imagen" name="imagen" style="display: none;width: 100%" />
											    <img id="avatar" src="<%=ResolveClientUrl("~/Content/img/bussines-avatar-3x4.jpg") %>" alt="..." style="width: 80%" />
								            </div>
								            <div class="row justify-content-center">
								                <a href="javascript: void(0);" class="btn btn-default" id="arriba" style="display: none;"> <i class="material-icons">keyboard_double_arrow_up</i> </a>
								            </div>
								            <div class="row justify-content-center">
    								        
								                <a href="javascript: void(0);" class="btn btn-default" id="izquierda" style="display: none;"> <i class="material-icons">keyboard_double_arrow_left</i> </a>
								                <a href="javascript: void(0);" class="btn btn-default" id="btn-tomar-foto"><i class="material-icons">camera</i> Tomar fotografía</a>
								                <a href="javascript: void(0);" class="btn btn-default" id="derecha" style="display: none;"> <i class="material-icons">keyboard_double_arrow_right</i> </a>
    								            
								            </div>
								            <div class="row justify-content-center">
								                <a href="javascript: void(0);" class="btn btn-default" id="abajo" style="display: none;">  <i class="material-icons">keyboard_double_arrow_down</i></a>
								            </div>
    					        
								            <canvas id="temp_canvas" width="360" height="480" style="display:none;"></canvas>
								        </div>
                                        
                                        <iframe class="preview-pane" type="application/pdf" width="100%" height="100%" frameborder="0" style="position:relative;z-index:999; display: none;"></iframe>
                                    </div>
                                    
                                </div>
					        </div>
                            <div class="card-footer text-right">
                                <button type="submit" class="btn btn-info" id="confirmar" style="display:none;">Confirmar</button>
                                <a onClick="javascript:finalizarCarnet()" id="finalizar" class="btn btn-fill btn-default" style="display:none">Finalizar<div class="ripple-container"></div></a>
                                <a class="btn btn-fill btn-danger pull-right" id="cancelar" onClick="javascript:cancelarCarnet();">Cancelar<div class="ripple-container"></div></a>
                            </div>
                        </div>
		            </form>
                </div>
            </div>
        </div>
    </div>
 <% } %>
 
<style>

    .camera-portrait {
	    overflow: hidden;
	    display: inline-block;
	    width: 360px;
	    height: 480px;
	     -webkit-box-shadow: 0 10px 30px -12px rgba(0, 0, 0, 0.42), 0 4px 25px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 0, 0, 0.2);
              box-shadow: 0 10px 30px -12px rgba(0, 0, 0, 0.42), 0 4px 25px 0px rgba(0, 0, 0, 0.12), 0 8px 10px -5px rgba(0, 0, 0, 0.2);
    }
    
    

</style>



<script>
    window.jsPDF = window.jspdf.jsPDF;
    
    function setFormValidation(id) {
      $(id).validate({
        highlight: function(element) {
          $(element).closest('.form-group').removeClass('has-success').addClass('has-danger');
          $(element).closest('.form-check').removeClass('has-success').addClass('has-danger');
        },
        success: function(element) {
          $(element).closest('.form-group').removeClass('has-danger').addClass('has-success');
          $(element).closest('.form-check').removeClass('has-danger').addClass('has-success');
        },
        errorPlacement: function(error, element) {
          $(element).closest('.form-group').append(error);
        },
      });
    }
    
    $(document).ready(function() {
      setFormValidation('#formularioBuscar');
          Webcam.set({
		    width: 360,
		    height: 480,
		    crop_x: 0,
		    crop_y: 0,
		    crop_width: 360,
		    crop_height: 480,
		    image_format: 'jpeg',
		    jpeg_quality: 100
	    });
      
      $("#matricula").focus();
      
      
      $("#btn-tomar-foto").click(function(){
        if ($(this).hasClass("btn-default")){
            $(this).removeClass("btn-default");
            $(this).addClass("btn-primary");
            $("#avatar").hide();
            $("#imagen").hide();
            $("#camara").show();
            Webcam.attach( '#camara' );
            $("#camara video").attr("style","margin-left:0px;margin-top:0px;");
            $("#camara video").attr("tabindex","0");
            $("#izquierda").show();
            $("#derecha").show();
            $("#arriba").show();
            $("#abajo").show();
            $("#confirmar").hide();
        } else {
            $(this).removeClass("btn-primary");
            $(this).addClass("btn-default");
            $("#avatar").hide();
            $("#camara").hide();
            $("#izquierda").hide();
            $("#derecha").hide();
            $("#arriba").hide();
            $("#abajo").hide();
            take_snapshot();
            Webcam.reset( '#camara' );
        }
      });
      
      $("#izquierda").click(function(){
        var ml = video_ml();
        ml -=10;
        $("#camara video").css("margin-left",ml.toString()+"px");
      });
      
      $("#derecha").click(function(){
        var ml = video_ml();
        ml +=10;
        $("#camara video").css("margin-left",ml.toString()+"px");
      });
      
      $("#arriba").click(function(){
        var mt = video_mt();
        mt -=10;
        $("#camara video").css("margin-top",mt.toString()+"px");
      });
      
      $("#abajo").click(function(){
        var mt = video_mt();
        mt +=10;
        $("#camara video").css("margin-top",mt.toString()+"px");
      });
      
      
      
      
    });
    
    function video_ml(){
        var $video = $("#camara video");
        var ml = $video.css("margin-left");
        ml = ml.replace("px","");
        ml = Number(ml);
        return ml;
    }
    
    function video_mt(){
        var $video = $("#camara video");
        var mt = $video.css("margin-top");
        mt = mt.replace("px","");
        mt = Number(mt);
        return mt;
    }
    
    function take_snapshot() {
        /*
        No funcionó adecuadamente el de la librería
        Webcam.params.crop_x = Math.abs(video_ml());
        Webcam.params.crop_y = Math.abs(video_ml());
        
        Webcam.snap( function(data_uri) {
           $("#imagen").attr("src",data_uri);
           $("#imagen").show();
        } );
        */
        const video   = document.querySelector("video");
        const canvas  = document.querySelector("canvas");
        const context = canvas.getContext('2d');
        
        context.drawImage(video, Math.abs(video_ml()), Math.abs(video_mt()), 360, 480, 0, 0, 360, 480);
        $("#imagen").attr("src",canvas.toDataURL("image/png"));
        $("#imagen").show();
        $("#confirmar").show();
        
    }
    
    function buscarCarnet(e){
        e.preventDefault;
        if ( $("#formularioBuscar").valid() ){
            //No funciono .val(), por lo que obtenego el text() y busco su id
            //var tipoProfesional=fnObtenerCodigo($("button.dropdown-toggle").prop("title"));
            var tipoProfesional = $("#tipoProfesional").val();
            var matricula  =$("#matricula").val();
            var cedula     =$("#cedula").val();
            var liquidacion=$("#liquidacion").val();
            window.open("<%= Url.Action("Carnet","Home") %>/"+matricula+"?tipo="+tipoProfesional+"&cedula="+cedula+"&liquidacion="+liquidacion,"_self");
        }
        return false;
    }
    
    function fnObtenerCodigo(pTexto) {
        console.log("tipoProfesional.val: ",$("#tipoProfesional").val());
        $("#tipoProfesional").each(function(){
            console.log("tipoProfesional: ",$(this).text() );
            if ( $(this).text() == pTexto ){
                return $(this).val();
            }
        });
        return "";
    }
    function guardarCarnet(e){
        e.preventDefault;
        
        $("#confirmar").attr("disabled",true);
        $("#confirmar").text("Procesando...");
        $("#confirmar").removeClass("btn-info").addClass("btn-default").addClass("disabled");
        
        var data = { 
            carnet_qr: null,
            persona_id : <%= (@prof != null ? @prof.persona_id  : 0) %>,
            profesional_tipo_id : <%= (@prof != null ? @prof.profesional_tipo_id  : 0) %>,
            turno_id : null,
            fecha_expedicion : "",
            fecha_vencimiento : "",
            liquidacion_nro : getUrlParameter("liquidacion"),
            foto : $("#imagen").attr("src").replace("data:image/png;base64,","")
        };
        
        $.post('<%= Url.Action("GuardarCarnet","Home") %>',data).done(function (resp){
            console.log("Resp: ", resp);
            if ( resp.result == "Ok" ){
                generarPdf(resp.message);
            } else {
                alert("Error: "+resp.message );
            }
        });
        
        return false;
    }
    
    function cancelarCarnet(){
        if ( confirm("¿Está seguro que desea cancelar?")){
            window.open("<%= Url.Action("Index", "Home")%>","_self");        
        }
    }

    function finalizarCarnet(){
       
        window.open("<%= Url.Action("Index", "Home")%>","_self");        
        
    }
    
    var getUrlParameter = function getUrlParameter(sParam) {
        var sPageURL = window.location.search.substring(1),
            sURLVariables = sPageURL.split('&'),
            sParameterName,
            i;

        for (i = 0; i < sURLVariables.length; i++) {
            sParameterName = sURLVariables[i].split('=');

            if (sParameterName[0] === sParam) {
                return sParameterName[1] === undefined ? true : decodeURIComponent(sParameterName[1]);
            }
        }
        return false;
    };
    
    function generarPdf(pCarnetID){
        
        $(".preview-pane").attr("src","<%= Url.Action("Imprimir","Home") %>/"+pCarnetID);
        $("#confirmar").hide();
        $("#cancelar").hide();
        $("#finalizar").show();
        $("#camera-sector").hide();
        $(".preview-pane").show();
    
    }
        
    
</script>
</asp:Content>

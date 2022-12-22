<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<csj.Models.RegisterModel>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Registrar
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="content" style="margin-top: 20px;">
        <div class="container-fluid">
            
            <div class="row">
	            <div class="col-md-12">
		            <% using (Html.BeginForm()) { %>
                        <div id="error_message" class="row" style="display:none">
                            <div class="card">
                             
                                 <div class="alert alert-danger">
	                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
	                                <i class="material-icons">close</i>
	                                </button>
	                                <span>
	                                <b> <%= Html.ValidationSummary(true, "Error al registrar el nuevo usuario. Por favor corrija los errores") %> </span>
	                             </div>
	                        </div>
	                     </div>
			            <div class="card ">
            				
				            <div class="card-header card-header-icon card-header-info">

					            <div class="card-icon">
						            <i class="material-icons">person_add</i>
					            </div>

					            <h4 class="card-title">Crear usuario</h4>

				            </div>

                            <div class="card-body ">
                                <div class="row">
                                    <div class="form-group bmd-form-group col-md-3">
                                            <label for="UserName" class="bmd-label-floating"> Usuario *</label>
                                            <input type="text" class="form-control" id="UserName" name="UserName" required="true" title="El usuario es obligatorio" aria-required="true" maxlength="10">
                                            <%= Html.ValidationMessageFor(m => m.UserName) %>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group bmd-form-group col-md-3">
                                            <label for="Email" class="bmd-label-floating"> Correo *</label>
                                            <input type="email" class="form-control" id="Email" name="Email" required="true" title="El correo es obligatorio" aria-required="true" maxlength="255">
                                            <%= Html.ValidationMessageFor(m => m.Email)%>
                                    </div>
                                </div>
                                
                                <div class="row">
                                    <div class="form-group bmd-form-group col-md-3">
                                            <label for="Password" class="bmd-label-floating"> Clave *</label>
                                            <input type="password" class="form-control" id="Password" name="Password" required="true" title="El Password es obligatorio" aria-required="true" minlength="6" maxlength="30">
                                            <%= Html.ValidationMessageFor(m => m.Password)%>
                                    </div>
                                </div>
                                
                                <div class="row">
                                    <div class="form-group bmd-form-group col-md-3">
                                            <label for="ConfirmPassword" class="bmd-label-floating"> Confirmar clave *</label>
                                            <input type="password" class="form-control" id="ConfirmPassword" name="ConfirmPassword" required="true" title="La confirmacion del Password es obligatoria" aria-required="true" minlength="6" maxlength="30">
                                            <%= Html.ValidationMessageFor(m => m.ConfirmPassword)%>
                                    </div>
                                </div>
                                
                            </div>
                            <div class="card-footer text-right">
                                <button type="submit" class="btn btn-info" id="confirmar">Registrar</button>
                                <a class="btn btn-fill btn-danger pull-right" href="/Account/List">Cancelar<div class="ripple-container"></div></a>
                            </div>
                        </div>
                    <% } %>
                </div>
             </div>
         </div>
     </div>
     
     <script>

         $(document).ready(function() {
             $("input").attr("autocomplete","off");
             $("#UserName").focus();

             if ($(".validation-summary-errors").length) {
                 $("#error_message").show();
             }

         });

    </script>

</asp:Content>



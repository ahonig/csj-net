<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<csj.Models.ChangePasswordModel>" %>

<asp:Content ID="changePasswordTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Cambiar Clave
</asp:Content>

<asp:Content ID="changePasswordContent" ContentPlaceHolderID="MainContent" runat="server">
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
	                                <b> <%= Html.ValidationSummary(true, "Actualizacion de cuenta sin exito. Por favor corrija los errores") %> </span>
	                             </div>
            	             
	                        </div>
	                     </div>
                        
			            <div class="card ">
            				
				            <div class="card-header card-header-icon card-header-info">

					            <div class="card-icon">
						            <i class="material-icons">person_add</i>
					            </div>

					            <h4 class="card-title">Cambiar clave</h4>

				            </div>

                            <div class="card-body ">
                                <div class="row">
                                    <div class="form-group bmd-form-group col-md-3">
                                            <label for="OldPassword" class="bmd-label-floating"> Clave anterior *</label>
                                            <input type="password" class="form-control" id="OldPassword" name="OldPassword" required="true" title="La clave anterior es obligatoria" aria-required="true" maxlength="10">
                                            <%= Html.ValidationMessageFor(m => m.OldPassword) %>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group bmd-form-group col-md-3">
                                            <label for="NewPassword" class="bmd-label-floating"> Nueva clave *</label>
                                            <input type="password" class="form-control" id="NewPassword" name="NewPassword" required="true" title="La clave nueva es obligatoria" aria-required="true" maxlength="255">
                                            <%= Html.ValidationMessageFor(m => m.NewPassword)%>
                                    </div>
                                </div>
                                
                                <div class="row">
                                    <div class="form-group bmd-form-group col-md-3">
                                            <label for="ConfirmPassword" class="bmd-label-floating"> Confirmacion de nueva clave *</label>
                                            <input type="password" class="form-control" id="ConfirmPassword" name="ConfirmPassword" required="true" title="La confirmacion es obligatoria" aria-required="true" maxlength="30">
                                            <%= Html.ValidationMessageFor(m => m.ConfirmPassword)%>
                                    </div>
                                </div>
                                
                            </div>
                            <div class="card-footer text-right">
                                <button type="submit" class="btn btn-info" id="confirmar">Cambiar clave</button>
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
             $("input").attr("autocomplete", "off");
             $("#OldPassword").focus();
             if ($(".validation-summary-errors").length) {
                 $("#error_message").show();
             }
         });

    </script>
</asp:Content>

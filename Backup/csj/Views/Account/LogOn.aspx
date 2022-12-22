<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<csj.Models.LogOnModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log On
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header login-page" style="min-height: 85vh">
	    <div class="container">
		    <div class="row">
			    <div class="col-lg-4 col-md-6 col-sm-8 ml-auto mr-auto">
				    <% using (Html.BeginForm()) { %>
					    <div class="card card-login">
						    <div class="card-header card-header-info text-center">
							    <h4 class="card-title">Iniciar sesión</h4>
						    </div>
						    <div class="card-body ">
							    <span class="bmd-form-group">
								    <div class="input-group">
									    <div class="input-group-prepend">
										    <span class="input-group-text">
											    <i class="material-icons">account_circle</i>
										    </span>
									    </div>
									    <input type="text" class="form-control" id="UserName" name="UserName" placeholder="Usuario" value="">
								    </div>
							    </span>
							    <span class="bmd-form-group">
								    <div class="input-group">
									    <div class="input-group-prepend">
										    <span class="input-group-text">
											    <i class="material-icons">lock_outline</i>
										    </span>
									    </div>
									    <input type="password" class="form-control" id="Password" name="Password" placeholder="Contraseña" value="">
								    </div>
							    </span>
						    </div>
						    <div class="card-footer justify-content-center">
							    <button type="submit" class="btn btn-info btn-link btn-lg">Ingresar</button>
						    </div>
					    </div>
				    <% } %>
			    </div>
		    </div>
	    </div>
    </div>
    
    <script>

        $(document).ready(function() {

            $("#UserName").focus();

        });

    </script>

</asp:Content>



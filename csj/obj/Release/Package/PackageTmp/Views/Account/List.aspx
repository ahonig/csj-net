<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="System.Web.Security" %>


<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Lista
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
<% var usuarios = Membership.GetAllUsers().Cast<MembershipUser>().OrderByDescending(x => x.CreationDate).ToList(); %>
    <div class="content" style="margin-top: 20px;">
        <div class="container-fluid">
            <div class="row">
	            <div class="col-md-12">
		            <form id="generarCarnet" target="_self" onSubmit="return guardarCarnet(event);">
			            <div class="card ">
            				
				            <div class="card-header card-header-icon card-header-info">

					            <div class="card-icon">
						            <i class="material-icons">fingerprint</i>
					            </div>

					            <h4 class="card-title">Listado de Usuarios</h4>

				            </div>

                            <div class="card-body ">
                                <div class="toolbar">
                                    <div class="row">
                                        <div class="col-12 text-right">
                                            <a href="/Account/Register" class="btn btn-sm btn-rose">Agregar<div class="ripple-container"></div></a>
                                        </div>
                                    </div>
                                </div>
                                <div class="material-datatables">
                                    <table id="datatables" class="table table-striped table-no-bordered table-hover" cellspacing="0" width="100%" style="width:100%">
                                        <thead>
                                            <tr>
                                                <th>Usuario</th>
                                                <th>Correo</th>
                                                <th>Activado?</th>
                                                <th>Fecha Creaci&oacute;n</th>
                                                <th>Acciones</th>
                                            </tr>
                                        </thead>
                                        
                                        <tbody>
                                            <%  
                                                if (@usuarios != null)
                                                {
                                                    foreach (MembershipUser usuario in usuarios)
                                                    {
                                                       %>
                                                       <tr>
												            <td><%= usuario.UserName %></td>
												            <td><%= usuario.Email %></td>
												            <% if (usuario.IsApproved) {%><td>Sí</td><% } else { %><td>No</td> <% } %>
												            <td><%= usuario.CreationDate %></td>
												            <td class="td-actions text-right">
												                <% if (usuario.UserName.ToUpper() != "ADMIN" && usuario.UserName.ToUpper() != Membership.GetUser().UserName.ToUpper())
                                                                {
                                                                    if (usuario.IsApproved)
                                                                    {
                                                                %>
												                <button type="button" class="btn btn-danger btn-link" data-original-title="" title="" onclick="confirm('Esta seguro que desea bloquear el usuario <%= usuario.UserName %>?') ? bloquearUsuario('<%= usuario.UserName %>') : ''">
                                                                    <i class="material-icons">close</i>
                                                                    <div class="ripple-container"></div>
                                                                    <div class="ripple-container"></div>
                                                                </button>
                                                                <% }
                                                                    else { 
                                                                    %> 
                                                                      <button type="button" class="btn btn-success btn-link" data-original-title="" title="" onclick="confirm('Esta seguro que desea resetear y activar el usuario <%= usuario.UserName %>?') ? activarUsuario('<%= usuario.UserName %>') : ''">
                                                                        <i class="material-icons">check</i>
                                                                        <div class="ripple-container"></div>
                                                                        <div class="ripple-container"></div>
                                                                    </button>  
                                                                <%        
                                                                    }
                                                                } %>
												            </td>
											            </tr>
                                                       <% 
                                                    }
                                                 } 
                                                %>
                                        </tbody>
                                    </table>
                                </div>

                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    
    <script>
        $(document).ready(function() {
            $('#datatables').DataTable({
                "pagingType": "full_numbers",
                "lengthMenu": [
                      [10, 25, 50, -1],
                      ["10  ", "25  ", "50  ", "Todos  "]
                    ],
                order: [[2, 'desc'], [3, 'desc']],
                responsive: true,
                language: {
                    search: "_INPUT_",
                    lengthMenu: "Mostrando _MENU_ registros por pagina",
                    zeroRecords: "Sin resultados",
                    info: "Mostrando pagina _PAGE_ de _PAGES_",
                    infoEmpty: "Sin registros que mostrar",
                    infoFiltered: "(filtrado de un total de _MAX_ registros)",
                    searchPlaceholder: "Buscar Registros",
                    first: 'Prim',
                    previous: 'Ant',
                    next: 'Sgte.',
                    last: 'Ult.'
                }
            });
        });

        function bloquearUsuario(pUsuario) {
            var data = { id: pUsuario };
            $.post('/Account/bloquearUsuario', data).done(function(resp) {
                console.log("Resp: ", resp);
                if (resp.result == "Ok") {
                    location.reload();
                } else {
                    alert("Error: " + resp.message);
                }
            });
        }

        function activarUsuario(pUsuario) {
            var data = { id: pUsuario };
            $.post('/Account/activarUsuario', data).done(function(resp) {
                console.log("Resp: ", resp);
                if (resp.result == "Ok") {
                    location.reload();
                } else {
                    alert("Error: " + resp.message);
                }
            });
        }
  </script>


</asp:Content>

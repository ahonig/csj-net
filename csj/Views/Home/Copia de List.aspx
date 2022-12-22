<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Lista
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">

<% var carnets = (IEnumerable<@csj.ListaCarnets>) ViewData["carnets"]; %>

    <div class="content" style="margin-top: 20px;">
        <div class="container-fluid">
            <div class="row">
	            <div class="col-md-12">
		            <form id="generarCarnet" target="_self" onSubmit="return guardarCarnet(event);">
			            <div class="card ">
            				
				            <div class="card-header card-header-icon card-header-info">

					            <div class="card-icon">
						            <i class="material-icons">assignment</i>
					            </div>

					            <h4 class="card-title">Listado de carnet</h4>

				            </div>

                            <div class="card-body ">
                                <div class="toolbar">

                                </div>
                                <div class="material-datatables">
                                    <table id="datatables" class="table table-striped table-no-bordered table-hover" cellspacing="0" width="100%" style="width:100%">
                                        <thead>
                                            <tr>
                                                <th>Carnet</th>
                                                <th>Cedula</th>
                                                <th>Nombres</th>
                                                <th>Apellidos</th>
                                                <th>Tipo</th>
                                                <th>Fch. Expedicion</th>
                                                <th>Fch. Vencimiento</th>
                                                <th>Liquidacion</th>
                                            </tr>
                                        </thead>
                                            <%  
                                                if (@carnets != null)
                                                {
                                                    foreach (var carnet in carnets)
                                                    {
                                                       %>
                                                       <tr>
												            <td><%= carnet.carnet_qr %></td>
												            <td><%= carnet.documento_nro %></td>
												            <td><%= carnet.nombres %></td>
												            <td><%= carnet.apellidos %></td>
												            <td><%= carnet.descripcion %></td>
												            <td><%= carnet.fecha_expedicion.ToString().Substring(0, 10)%></td>
												            <td><%= carnet.fecha_vencimiento.ToString().Substring(0, 10)%></td>
												            <td><%= carnet.liquidacion_nro %></td>
												           
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
  </script>


</asp:Content>

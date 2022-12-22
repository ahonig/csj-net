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
                                        <tbody>    
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
                "processing": true,
                "serverSide": true,
                "ajax":
                {
                    "url": "<%= Url.Action("GetData","Home") %>",
                    "type": "POST",
                    "dataType": "JSON"
                },
                "columns": [
                    { 
                        "data": "carnet_qr",
                        "render": function(data, type) {
                            if (type === 'display') {
                                return '<a href="http://csj.im/' + data + '">'+ data + '</a>';
                            }
                            return data;
                        }
                    },
                    { "data": "documento_nro" },
                    { "data": "nombres" },
                    { "data": "apellidos" },
                    { "data": "descripcion" },
                    { "data": "fecha_expedicion",
                      "render": function ( data, type, row, meta ) { return unixtime2Gregorian(data); } 
                    },
                    { "data": "fecha_vencimiento" ,
                      "render": function ( data, type, row, meta ) { return unixtime2Gregorian(data); } 
                    },
                    { "data": "liquidacion_nro"}
                ],
                "lengthMenu": [
              [10, 25, 50],
              ["10  ", "25  ", "50  "]
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


        function unixtime2Gregorian(pUnixTime) { 
            var timestamp = pUnixTime.replace("/Date(","").replace(")/","");
            const date = new Date(timestamp*1);
            const datevalues = [
               date.getFullYear(),
               date.getMonth()+1,
               date.getDate(),
               date.getHours(),
               date.getMinutes(),
               date.getSeconds(),
            ];
            return String(date.getDate()).padStart(2, '0')+"/"+String((date.getMonth()+1)).padStart(2, '0')+"/"+date.getFullYear();
        }
  </script>


</asp:Content>

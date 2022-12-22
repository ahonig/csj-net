<%@Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="changePasswordTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Cambiar Clave
</asp:Content>

<asp:Content ID="changePasswordSuccessContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ok_message" class="row">
        <div class="card">
         
             <div class="alert alert-success">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <i class="material-icons">close</i>
                </button>
                <span>
                <b> Se ha actualizado su cuenta con exito </span>
             </div>
         
        </div>
     </div>
     <script>

         $(document).ready(function() {
             setTimeout(function() {

                window.location.href = "/Account/List";

             }, 1000);
         });

    </script>
</asp:Content>

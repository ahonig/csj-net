<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<% var pers = (@csj.persona) ViewData["persona"]; %>
<% var carn = (@csj.carnet) ViewData["carnet"]; %>
<% var prof = (@csj.profesional) ViewData["profesional"]; %>
<% var tipo = (@csj.profesional_tipo) ViewData["profesionalTipo"]; %>
<!DOCTYPE html>
<html lang="es">
  <head>
      <title>Carnet CSJ</title>
  <script src="<%=ResolveClientUrl("~/Scripts/jquery.min.js") %>"></script>
  <script src="<%=ResolveClientUrl("~/Scripts/jspdf.umd.min.js") %>"></script>
  <script src="<%=ResolveClientUrl("~/Scripts/Montserrat-Bold-bold.js") %>"></script>
  <script src="<%=ResolveClientUrl("~/Scripts/qrcode.min.js") %>"></script>
  <script>
      window.jsPDF = window.jspdf.jsPDF;
      var codigoCarnet = window.location.href.substring(window.location.href.lastIndexOf('/') + 1);
      $(document).ready(function() {
        $('#disableRightClick').contextmenu(function() {
          return false;
        });  
        
        console.log("codigo qr_code",codigoCarnet);
        var qrcode = new QRCode("qr_code", {
            text: 'HTTP://CSJ.IM/'+codigoCarnet,
            width: 80,
            height: 80,
            colorDark : "#000000",
            colorLight : "#ffffff",
            correctLevel : QRCode.CorrectLevel.L
        });
         //CodigoBarra
        let base64Image = qrcode._oDrawing._elCanvas.toDataURL("image/png");
        setTimeout(generarPdf(base64Image),4000);
      });
      function generarPdf(pQRCode) {
          var doc = new jsPDF('l', 'mm', [86, 54]);
          var mt = parseInt(2);
          var ml = parseInt(2);
          doc.addFont("<%=ResolveClientUrl("~/Content/font/Montserrat-Bold.ttf") %>", "Montserrat", "normal");

          var background = new Image();
          background.src = "<%=ResolveClientUrl("~/Content/pattern.png") %>";
          doc.addImage(background, 'PNG', 0, 0);

          var csjLogo = new Image();
          csjLogo.src = "<%=ResolveClientUrl("~/Content/corte_suprema.png") %>";
          doc.addImage(csjLogo, 'PNG', 2.2, 2.2, 50, 19);

          doc.setFont("Montserrat");

          //Titulos
          doc.setFontSize(4);
          doc.setTextColor(77, 99, 111);
          doc.text(ml + 2.2, mt + 21.7, 'APELLIDOS:');
          doc.text(ml + 2.2, mt + 29.7, 'NOMBRES:');
          doc.text(ml + 2.2, mt + 37.7, 'CEDULA DE IDENTIDAD:');
          doc.text(ml + 2.2, mt + 45.7, 'PROFESIONAL:');
          doc.text(ml + 52.5, mt + 45.7, 'MATRICULA:');
          doc.text(ml + 66.1, mt + 45.7, 'VENCIMIENTO:');

          //datos
          //Pagina 1
          doc.setFontSize(7.6);
          doc.setTextColor(0, 0, 0);
          doc.text(ml + 2.2, mt + 24.7, '<%= (@pers != null ? @pers.apellidos : "")%>');
          doc.text(ml + 2.2, mt + 32.1, '<%= (@pers != null ? @pers.nombres : "") %>');
          doc.text(ml + 2.2, mt + 40.5, '<%= (@pers != null ? Convert.ToDecimal(@pers.documento_nro).ToString("#,##0") : "")%>');
          doc.text(ml + 2.2, mt + 48.2, '<%= (@tipo != null ? @tipo.descripcion : "")%>');
          doc.text(ml + 52.5, mt + 48.2, '<%= (@prof != null ? @prof.matricula_nro : "")%>');
          doc.text(ml + 66.1, mt + 48.2, '<%= (@carn != null ? @carn.fecha_vencimiento.ToString().Substring(0, 10) : "")%>');
          
          var portrait = new Image();
          portrait.src = "<%=ResolveClientUrl("~/Content/carnet/") %>"+codigoCarnet+'.png';
          doc.addImage(portrait, 'PNG', ml + 53, mt + 2.7, 30, 40 );
          

          doc.addPage();
          //Pagina 2
          doc.text("EL SECRETARIO GENERAL DE LA CORTE SUPREMA DE JUSTICIA CERTIFICA QUE: <%= (@pers != null ? @pers.nombres : "") %> <%= (@pers != null ? @pers.apellidos : "")%> SE HALLA INSCRIPTO EN LA MATRÍCULA DE ABOGADO CON EL Nº <%= (@prof != null ? @prof.matricula_nro : "")%>. ESTA CREDENCIAL ES DE LA CORTE SUPREMA DE JUSTICIA.", ml + 2.2, mt + 2.2, { maxWidth: 80, align: "justify" });
          doc.text("EN CASO DE SER HALLADA DEBE SER ENTREGADA A SU SECRETARÍA GENERAL. TEL (021) 481403", ml + 2.2, mt + 30, { maxWidth: 40, align: "justify" });
          doc.text(ml + 2.2, mt + 47, 'XIMENA MARÍA MARTÍNEZ SEIFART');
          doc.setFontSize(5);
          doc.text(ml + 2.2, mt + 49, 'SECRETARIA GENERAL');
          doc.text("PARA MÁS INFORMACIÓN ESCANEE EL CÓDIGO", ml + 60, mt + 47, { maxWidth: 20, align: "justify" });

          
          doc.addImage(pQRCode, 'PNG', ml + 60, mt + 22.7);
          $("#qr_code").hide();
        
          doc.autoPrint({ variant: 'non-conform' });
          //setTimeout(function(){doc.save("test.pdf")}, 2000);
          var string = doc.output("bloburl");
          $("object").attr("data", string + "#toolbar=0");
      }
  
  </script>
  
  </head>
  <body>
   <object type="application/pdf"
        data=""
        width="400"
        height="300">
    </object>
    <div id="qr_code"> </div>
  </body>

  
</html>
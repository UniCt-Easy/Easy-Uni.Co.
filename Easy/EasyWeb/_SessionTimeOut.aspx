<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="_SessionTimeOut.aspx.cs" Inherits="_SessionTimeOut" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>EasyWeb</title>
        <link rel="stylesheet" type="text/css" href="css/masterpage.css"/>

<script type="text/javascript">
        function redir(){
        var childWindow;
        // Apre una finestra child 
        // di dimensioni 1024 x 768
        // e chiude (quando ci riesce...) la finestra principale
        leftval= (screen.width- 1024)/2
        if (leftval<0) leftval=0
        topval= (768-screen.height)/2
        if (topval<0) topval=0
        childWindow=window.open("Default.aspx","_self","status=no,titlebar=no,toolbar=no,location=no,menubar=no,scrollbars=yes,resizable=yes,"+
            "width=1024,height=768,left="+leftval+",top="+topval);

        return;
        }
        setTimeout(redir,5000)
</script>
</head>

<body oncontextmenu="return false;" >
    <form id="form1" runat="server">
    <div>
    <h1>La sessione di lavoro è scaduta o è andata persa. Entro 5 secondi sarà reindirizzato alla maschera di connessione.</h1>
    </div>
    </form>
</body>
</html>

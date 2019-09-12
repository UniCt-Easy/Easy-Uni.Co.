<%@ Page Language="C#" MasterPageFile="~/MetaMaster.master" AutoEventWireup="true" CodeFile="magazzino_out.aspx.cs" Inherits="magazzino_out" %>
<asp:Content ID="Content4" ContentPlaceHolderID="CHP_PC" Runat="Server">

<script type="text/javascript">

function getUrlVar( param_name )  
{  
  param_name = param_name.replace(/[\[]/,"\\\[").replace(/[\]]/,"\\\]");  
  var regex = new RegExp( "[\\?&]"+param_name+"=([^&#]*)" );  
  var rMatch = regex.exec( window.location.href );  
  if( rMatch == null )  
  {  
    return "";  
  } else {  
    return rMatch[1];  
  }  
} 

var PopupWarning = {

  init : function()
  {      
    if(this.popups_are_disabled() == true)
    {       
      this.redirect_to_instruction_page();
    }
  },

  redirect_to_instruction_page : function()
  {
    document.write("Impossibile aprire popup. Disabilitare blocco popup");
    document.location.href = "EasyWeb Impostazioni Browser.pdf";
    //document.getElementById("dispwarn").setAttribute("display","block");
  },

  popups_are_disabled : function()
  {
    var popup = window.open("chromepopuptest.html", "popup_tester", "width=1,height=1,left=0,top=0");
    
    if(!popup || popup.closed || typeof popup == 'undefined' || typeof popup.closed=='undefined')
    {
        //alert('popup are blocked');
        return true;
    }

    window.focus();
    popup.blur();    

    //
    // Chrome popup detection requires that the popup validates itself 
    // - so we need to give
    // the popup time to load, then call js on the popup itself
    //
    if(navigator && (navigator.userAgent.toLowerCase()).indexOf("chrome") > -1)
    {      
      //alert('chrome');
      var on_load_test = function(){PopupWarning.test_chrome_popups(popup);};    
      var timer = setTimeout(on_load_test, 300);
      return;
    }
    
    
    popup.close();
    //alert('do_1');
    this.dothething();
    return false;
  },

  test_chrome_popups : function(popup)
  {
    if(popup && popup.chrome_popups_permitted && popup.chrome_popups_permitted() == true)
    {      
      popup.close();
      //alert('do_2');
      this.dothething();
      return true;
    }
    
    //
    // If the popup js fails - popups are blocked
    //
    this.redirect_to_instruction_page();
  },
  
  dothething : function ()
  {
   var childWindow;
        // Apre una finestra child 
        // di dimensioni 1024 x 768
        // e chiude (quando ci riesce...) la finestra principale
        leftval= (screen.width- 1024)/2
        if (leftval<0) leftval=0
        topval= (768-screen.height)/2
        if (topval<0) topval=0

        //childWindow=window.open("LoginServizi.aspx","EasyWeb","status=no,titlebar=no,toolbar=no,location=no,menubar=no,scrollbars=yes,resizable=yes,"+
        //"width=1024,height=768,left="+leftval+",top="+topval);
        
        childWindow=window.open("magazzino_uscita.aspx?x="+getUrlVar("dep"),"_self","status=no,titlebar=no,toolbar=no,location=no,menubar=no,scrollbars=yes,resizable=yes,"+
        "width=1024,height=768,left="+leftval+",top="+topval);
        
        //window.open("chromepopuptest.html", "_self", "width=1,height=1,left=0,top=0");// window.open('','_self','');
        //window.open('','_parent',''); 
        
        //window.close();    
  
  }
  
  
  };
  
   PopupWarning.init();
   /*
    if (window.opener==null) {
        //alert('Inizializzo PopupWarning');
        PopupWarning.init();
     }
    else 
        document.getElementById("dispwarn").setAttribute("display","block");
*/


         
         
         
         
         
         
</script>

   <div id="dispwarn" style="display:none;"><h3>Impossibile aprire popup. Disabilitare blocco popup</h3>  </div> 
    <div>
     <asp:HyperLink style="text-align:center;" ID="HyperLink1" runat="server" Font-Size="Medium" 
        target="_blank" NavigateUrl="~/EasyWeb Impostazioni Browser.pdf">Istruzioni per la configurazione del browser</asp:HyperLink><br />
</div>

</asp:Content>

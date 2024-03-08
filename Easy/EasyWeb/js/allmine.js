
///
///#jquery.tabbable.JS
/// https://github.com/marklagendijk/jQuery.tabbable/blob/master/jquery.tabbable.js
///
/*!
 * jQuery.tabbable 1.0 - Simple utility for selecting the next / previous ':tabbable' element.
 * https://github.com/marklagendijk/jQuery.tabbable
 *
 * Includes ':tabbable' and ':focusable' selectors from jQuery UI Core
 *
 * Copyright 2013, Mark Lagendijk
 * Released under the MIT license
 *
 */

//
// hwClientFunctions.js
// 
// Tag is "format.decimaldigits.prefix.suffix.scale"

// hwHTMLElements.js Configurations \r\n" +
// This file just contains the HTML Elements names which will be substituted at runtime\r\n" +
// ID della Div che contiene l'elenco\r\n" + 
var ElmElenco="_ctl0_CHP_TB_Elenco";   //<%=Elenco.ClientID%>

// ID del Textbox che vale \"S\" se è stato selezionato un record dall'elenco\r\n" +
var ElmRecordIsSelected="_ctl0_CHP_TB_RecordIsSelected";    //<%=RecordIsSelected.ClientID%>

// ID del Textbox contenente l'indice di riga del record selezionato dall'elenco\r\n" +
var ElmSelectedRecord="_ctl0_CHP_TB_SelectedRecord";   //<%=SelectedRecord.ClientID%>

// ID del Textbox contenente il valore precedente del textbox che ha invocato l'autochoose\r\n" +
var ElmPreviousValue="_ctl0_PreviousValue";   //<%=PreviousValue.ClientID%>

// ID del Textbox che vale \"S\" se va preservato il valore precedente del textbox che ha invocato l'autochoose\r\n" +
var ElmPreservePreviousValue="_ctl0_PreservePreviousValue"; //<%=PreservePreviousValue.ClientID%>

// ID del Textbox che vale \"S\" se va mostrato l'elenco\r\n" +
var ElmShowElenco="_ctl0_CHP_TB_ShowElenco";  //<%=ShowElenco.ClientID%>

// ID del Textbox che contiene la configurazione corrente dei folders\r\n" +
var ElmCurrentFoldersConfig="_ctl0_CHP_TB_CurrentFoldersConfig";  //<%=CurrentFoldersConfig.ClientID%>

// ID della div che contiene il form principale (Content4 della MP)\r\n" +
var ElmContent="_ctl0_CHP_PC_DIV";  //<%=Content.ClientID%>

// ID della div contenente la toolbar dei comandi\r\n" +
var ElmToolbar="_ctl0_CPH_MainMenu_ToolBar_Div"; //<%=ToolBar.ClientID%>


// ID della div contenente l'elenco principale\r\n" +
var ElmList="_ctl0_Div_CHPList";  //<%=List.ClientID%>s

// Nome della pagina aspx che gestisce le richieste XML per l'elenco\r\n" +
var XMLRequestURL="XMLRequestList.aspx"; //<%=XMLRequestURL%>

// Nome del foglio di stile XSL utilizzato per la trasformazione per l'elenco da XML ad HTML\r\n" +
var XSLTRequestURL="TransformToTable.xsl"; //<%=XSLTRequestURL%>
            
            
            
            
            
            
// Separatore decimale
var NumberDecimalSeparator = ",";
// Separatore delle migliaia
var NumberGroupSeparator = ".";
// Separatore decimale currency
var CurrencyDecimalSeparator = ",";
// Separatore Migliaia Currency
var CurrencyGroupSeparator = ".";
// Simbolo di currency (€)
var CurrencySymbol = String.fromCharCode(8364);
// Nome del browser
var Browser = navigator.appName.toLowerCase();
// ID del controllo al quale dare focus
var pTxtBoxToGiveFocus;
//
var PreviousTxtBoxContent;
// vale true se un record è selezionato
var RecordIsSelected=false;
// Array dei controlli da disattivare
var ControlsArray=new Array();
// Variabili per il dragging dell'elenco
var dragObject, offsetX, offsetY, isDragging=false;
var dragObjectRes, offsetXRes, offsetYRes, isDraggingRes=false;

// Variables used for rendering List Footer
// Numero di pagine visualizzate nel footer dell'elenco
var NumberOfPagesInFooter=20; // The number of page numbers displayed in footer i.e.: << < 1 2 3 4 5 6 7 8 9 10 > >>

// Numero totale di pagine dell'elenco corrente
var NumberOfPagesInList; // Total number of pages of records expected from server

// prima pagina visualizzata nell'elenco
var FirstPageDisplayedInList; // First page displayed in list (current)

var CurrentPageDisplayed;


// Id del textbox sul quale fare focus nel caso venga chiuso l'elenco
var TextBoxIdForList; // Textbox id to focus in case of list closure
// Dimensioni e posizione iniziali elenco 
var ListHeight=0;
var ListWidth=0;
var TopWindowPos=200;
var LeftWindowPos=50;
// boolean vale true se l'elenco è massimizzato
var isListFullSized=false;
// Riga precedentemente evidenziata dell'elenco corrente
var PreviousSelectedRow=-1;
// classname CSS della riga precedentemente evidenziata dell'elenco corrente
var PreviousRowClassName="";

// Variables user for rendering Tabs
var DivNumber;
// 
var FolderNumber=new Array();
// Numero massimo di tabs e di folders per tab
var MaxTabNumber=10;
var MaxFolderPerTabNumber=10;        


// Controllo al quale dare focus all'avvio della pagina
//var FocusOnStartup;

// Variabili utilizzate negli eventi focus e blur dei textbox
var OriginControl;
var TargetControl;
var ForcedOnBlur=false;
var ForcedBlur = false;


var isDetailMessageShown=false;


// Eventi a livello di window e document (globali)
//$(document).bind("onload",init);

// Immagini del checkbox
var CheckBoxImgPath="Immagini_CheckBox/";
var CheckImg=CheckBoxImgPath+"checked.gif";
var UnCheckImg=CheckBoxImgPath+"unchecked.gif";
var IndetImg=CheckBoxImgPath+"checked-three.gif";
var CheckImgOver=CheckBoxImgPath+"checked-over.gif";
var UnCheckImgOver=CheckBoxImgPath+"unchecked-over.gif";
var IndetImgOver=CheckBoxImgPath+"checked-three-over.gif";
var checkImgDis = CheckBoxImgPath+ "checked-dis.gif";
var uncheckImgDis = CheckBoxImgPath + "unchecked-dis.gif";



// Funzioni relative agli eventi collegati ai textbox ed alle textarea

/*
La seguente funzione, mediante espressione regolare, “simula” il comportamento della funzione trim (non presente in Javascript);
*/
String.prototype.trim = String.prototype.trim  || function() { return this.replace(/^\s\s*/, '').replace(/\s\s*$/, ''); };

function GenLeaveTB(pType, pTxtBox, pTag)
{
    /*
    La GenLeaveTB si occupa, quando scatta una leave client del textbox 
    “pTxtBox” (ed esso non è disabilitato o a sola lettura oppure vuoto), della 
    formattazione del suo contenuto sulla base di pType e pTag. Utilizza le funzioni 
     GetObjectFromString e StringValue.
    */

	if(pTxtBox.disabled) return;
	if(pTxtBox.readOnly) return;
	if(pTxtBox=="") return;

	try
	{
		var lObj = GetObjectFromString(pType,pTxtBox.value,pTag);
		pTxtBox.value = StringValue(lObj,pTag);
	}
	catch (e)
	{};
};

function GetObjectFromString(pType, pString, pTag)
{
    /*
    GetObjectFromString data una stringa “pString”, una definizione di tipo “pType” 
    ed un tag “pTag”, ritorna un oggetto che consta di due membri: 
    -	TypeName che contiene uno dei seguenti valori: 
        “String”, “Char”, “Double”, “Single”, “Decimal”, “DateTime”, “Byte”, “Int16”, “Int32”;
    -	Obj che contiene l’oggetto del tipo appropriato (String, Float, Int, Date) ricavato da pString. 
    */   
    
    if(pType==null) 
		pString="";
	var FieldType;
	FieldType = GetFieldLower(pTag,0);
    if(FieldType=="") 
		FieldType=null;
	var S;
	S = pString;
    
	var RetObj=new Object();

	try
	{
		switch (pType)
		{
			case "String":
				RetObj.TypeName="String";
				RetObj.Obj=S;
				return RetObj;
			break;

			case "Char":
			{
				// the ToChar() method does not exists. Could it be better to return just the first char?
				RetObj.TypeName="Char";
				RetObj.Obj=S.charAt(0);
				return RetObj;
			}
			break;

			// Double, Single and Decimal are always treated as Float
			case "Double":
			{
				RetObj.TypeName="Double";
				var D1;
				D1=0;
				if(S=="") return null;
				if (FieldType==null)
				{
					S=ConvertToJSNumber(S,GetNumberStyles(FieldType));
					D1=parseFloat(S);
					if (isNaN(D1)) return null;
					RetObj.Obj=D1;
					return RetObj;
				}
				if (IsStandardNumericFormatStyle(FieldType))
				{
					var StdDbl;
					//Double.Parse(S, GetNumberStyles(FieldType),NumberFormatInfo.CurrentInfo); -- Implement GetNumberStyles??
					S=ConvertToJSNumber(S,GetNumberStyles(FieldType));
					StdDbl=parseFloat(S);
					if (isNaN(StdDbl)) return null;
					RetObj.Obj=StdDbl;	
					return RetObj;
				}
				if (FieldType=="fixed")
				{
					var sdec = GetFieldLower(pTag,1);
					var prefix = GetFieldLower(pTag,2);
					if (prefix==null) 
						prefix="";
					var suffix = GetFieldLower(pTag,3);
					if (suffix==null) 
						suffix="";
					if (prefix != "") 
						S = S.replace(prefix,"");
					if (suffix != "") 
						S = S.replace(suffix,"");
					S=ConvertToJSNumber(S,GetNumberStyles(FieldType));
					var dec;
					dec = parseInt(sdec);
					var sscale;
					sscale = GetFieldLower(pTag,4);
					if (sscale=="") 
						sscale=null;
					D1=parseFloat(S);
					if (isNaN(D1)) return null;
					D1=D1.toFixed(dec);

					var scale=0;
					if (sscale!=null) 
						scale=parseFloat(sscale);
					if (isNaN(scale)) return null;
					if (scale!=0) D1 = D1 / scale;
					
					RetObj.Obj=D1;
					return RetObj;
				}
				return null;
			}	  
			break;	

			case "Single":
			{
				var D4;
				
				RetObj.TypeName="Single";
				if (S=="") return null;
				if (FieldType==null)
				{
					S=ConvertToJSNumber(S,GetNumberStyles(FieldType));
					D4=parseFloat(S);
					if(isNaN(D4)) return null;
					RetObj.Obj=D4;
					return RetObj;
				}
				if (IsStandardNumericFormatStyle(FieldType))
				{
					var StdSngl;
					S=ConvertToJSNumber(S);
					StdSngl = parseFloat(S);
					//Single StdSngl= Single.Parse(S, GetNumberStyles(FieldType),NumberFormatInfo.CurrentInfo); -- Implement GetNumberStyles
					RetObj.Obj=StdSngl;
					return RetObj;
				}
				if (FieldType=="fixed")
				{
					var sdec = GetFieldLower(pTag,1);
					var prefix = GetFieldLower(pTag,2);
					if (prefix==null) 
						prefix="";
					var suffix = GetFieldLower(pTag,3);
					if (suffix==null) suffix="";
					if (prefix != "") 
						S = S.replace(prefix,"");
					if (suffix != "") 
						S = S.replace(suffix,"");
					var dec;
					dec = parseInt(sdec);
					var sscale;
					sscale = GetFieldLower(pTag,4);
					if (sscale=="") 
						sscale=null;
					S=ConvertToJSNumber(S,GetNumberStyles(FieldType));
					D4 = parseFloat(S);
					if(isNaN(D4)) return null;
					D4 = D4.toFixed(dec);
					var scale=0;
					if (sscale!=null) 
						scale=parseFloat(sscale);
					if (isNaN(scale)) return null;
					if (scale!=0) 
						D4 = D4 / scale;
					RetObj.Obj=D4;
					return RetObj;
				}
				return null;
			}
			break;

			case "Decimal":
			{
				RetObj.TypeName="Decimal";
				if (S=="") 
					return null;
				if (FieldType==null)
				{
					var D2;
					D2=0;
					// D2 = Decimal.Parse(S, System.Globalization.NumberStyles.Currency, NumberFormatInfo.CurrentInfo);                
					S=ConvertToJSNumber(S,GetNumberStyles(FieldType));
					D2 = parseFloat(S);
					if(isNaN(D2)) return null;
					D2 = D2.toFixed(1);
					RetObj.Obj=D2;
					return RetObj;
				}
				if (IsStandardNumericFormatStyle(FieldType))
				{
					//Decimal StdDec= Decimal.Parse(S, GetNumberStyles(FieldType), NumberFormatInfo.CurrentInfo);
					var StdDec;
					S=ConvertToJSNumber(S,GetNumberStyles(FieldType));
					StdDec=parseFloat(S);
					if(isNaN(StdDec)) return null;
					StdDec=StdDec.toFixed(2);				
					RetObj.Obj=StdDec;
					return RetObj;
				}

				if (FieldType=="fixed")
				{
					var sdec = GetFieldLower(pTag,1);
					var prefix = GetFieldLower(pTag,2);
					if (prefix==null) 
						prefix="";
					var suffix = GetFieldLower(pTag,3);
					if (suffix==null) suffix="";
					if (prefix != "") 
						S = S.replace(prefix,"");
					if (suffix != "") 
						S = S.replace(suffix,"");
					var dec;
					dec = parseInt(sdec);
					var sscale;
					sscale = GetFieldLower(pTag,4);
					if (sscale=="") 
						sscale=null;
					S=ConvertToJSNumber(S,GetNumberStyles(FieldType));
					D2 = parseFloat(S);
					if(isNaN(D2)) return null;
					D2 = D2.toFixed(dec);
					var scale=0;
					if (sscale!=null) 
						scale=parseFloat(sscale);
					if (isNaN(scale)) return null;
					if (scale!=0) 
						D2 = D2 / scale;
					RetObj.Obj=D2;
					return RetObj;
				}

			}
			break;

			//DateTime right now just implements the "d" format
			case "DateTime":
			{
				RetObj.TypeName="DateTime";
				if (S=="") 
					return null;
				// Convert S into a Date
				var TT;
				
				// Not sure if it has to work this way... maybe the If can be removed...
				if (IsStandardDateFormatStyle(FieldType))
				{
					//TT = DateTime.Parse(S);
					TT=ConvertDateStringToDate(S,FieldType);
					RetObj.Obj=TT;
					return RetObj;
				}
				//TT= Convert.ToDateTime(S);
				TT=ConvertDateStringToDate(S,"d");
				RetObj.Obj=TT;
				return RetObj;
			}
			break;

			//The following formats wi11 always return an int datatype...
			case "Byte":
			{
				RetObj.TypeName="Byte";
				if (S=="") 
					return null;
				var I11;
				I11 = parseInt(S);
				if(isNaN(I11)) return null;
				if (FieldType==null)
				{
					RetObj.Obj=I11;
					return RetObj;
				}

				if (IsStandardNumericFormatStyle(FieldType))
				{
					// forse questo pezzo qui non servirà...
					I11 = parseInt(S);
					if(isNaN(I11)) return null;
					//I11 = Byte.Parse(S, System.Globalization.NumberStyles.Currency, NumberFormatInfo.CurrentInfo);
					RetObj.Obj=I11;
					return RetObj;
				}
                return I11;
			}
			break;

			case "Int16":
			{
				RetObj.TypeName="Int16";
				if (S=="") 
					return null;
				var I1;
				I1 = parseInt(S);
				if(isNaN(I1)) return null;
				if (FieldType==null)
				{
					RetObj.Obj=I1;
					return RetObj;
				}
				if (IsStandardNumericFormatStyle(FieldType))
				{
					// neanche questo pezzo servirà forse...
					// I1 = Int16.Parse(S, System.Globalization.NumberStyles.Currency, NumberFormatInfo.CurrentInfo);                
					
					I1=parseInt(S);
					if (isNaN(I1)) return null;
					RetObj.Obj=I1;
					return RetObj;
				}
				if (FieldType=="year")
				{
					if (I1>=100) 
					{
						RetObj.Obj=I1;
						return RetObj;
					}
					var lDate = new Date();
					var Year;
					
					//Year=lDate.getYear();
					Year=myGetYear(lDate);
					
					var aa;
					aa = (Year % 100);

					var CC;
					CC = (Year - aa);
					
					I1 = (I1 + CC);
					if (aa > 50) I1 = (I1 + 100);
					RetObj.Obj=I1;
					return RetObj;
				}
				return null;
			}
			break;

			case "Int32":
			{
				RetObj.TypeName="Int32";
				if (S=="") 
					return null;

				var I2;
				I2=parseInt(S);
				if (FieldType==null)
				{
					RetObj.Obj=I2
					return RetObj;
				}
				if(IsStandardNumericFormatStyle(FieldType))
				{
					//I2 = Int32.Parse(S, System.Globalization.NumberStyles.Currency, NumberFormatInfo.CurrentInfo);
					I2=parseInt(S);
					if (isNaN(I2)) return null;
					RetObj.Obj=I2;
					return RetObj;
				}
				if (FieldType=="year")
				{
					if (I2>=100) 
					{
						RetObj.Obj=I2;
						return RetObj;
					}
					var lDate = new Date();
					var Year;
					
					//Year=lDate.getYear();
					Year=myGetYear(lDate);
					
					var aa;
					aa = (Year % 100);

					var CC;
					CC = (Year - aa);
					
					I2 = (I2 + CC);
					if (aa > 50) I2 = (I2 + 100);
					RetObj.Obj=I2;
					return RetObj;
				}
				return null;

			}
			break;
			
			default:
				RetObj.Obj="'" + S + "'";
				return RetObj;
		}

	}
	catch (e)
	{
		alert("Error converting " + S + " into " + pType);
	}
};


function StringValue(pObject, pTag)
{
    /*
    StringValue è la funzione duale di GetObjectFromString. A partire da pObject, 
    che consta di due membri (TypeName e Obj descritti nella funzione precedente) 
    fornisce in output una stringa formattata secondo pTag.    
    */

	if (pObject==null) return "";

	var typename;
	var RetString;
	typename=pObject.TypeName;
	localObject=pObject.Obj;
	if (localObject==null) return "";

	if (typename=="DateTime")
	{
		var FieldType = GetFieldLower(pTag,0);
		if (IsStandardDateFormatStyle(FieldType))
		{
			// in questo caso lo dovrebbe riportare nel formato "g" (da implementare)
			RetString=ConvertDateToDateString(localObject,FieldType);
			return RetString;
		}
		RetString=ConvertDateToDateString(localObject,"d");
		return RetString;
	}
	else
	{
		var FieldType=GetFieldLower(pTag,0);
		var D;
		if (typename=="Decimal" || typename=="Single" || typename=="Double")
		{
			if (FieldType==null)
			{
				return ConvertToNumberString(localObject,2,GetNumberStyles(FieldType));
			}
			if(IsStandardNumericFormatStyle(FieldType))
			{
				return ConvertToNumberString(localObject,2,GetNumberStyles(FieldType));
			}
			

			if (FieldType=="fixed")
			{
				D=parseFloat(localObject);
				var sdec = GetFieldLower(pTag,1);
				var prefix = GetFieldLower(pTag,2);

				if (prefix==null) prefix="";
				var suffix = GetFieldLower(pTag,3);
				if (suffix==null) suffix="";
				
				var dec=parseInt(sdec);

				var sscale=GetFieldLower(pTag,4);
				if (sscale==null) sscale=0;
				var scale;
				if (sscale!=null)
					scale=parseFloat(sscale);
				if (scale!=0 && !isNaN(scale)) D=D*scale;
				var news=ConvertToNumberString(D,dec,GetNumberStyles(FieldType));

				if (prefix!="") news = prefix + " " + news;
				if (suffix!="") news = news + " " + suffix;

				return news;
			}
		}

	}
	return localObject.toString();
};

function IsStandardNumericFormatStyle(fmt)
{
    /*
    Ritorna true se il formato numerico fmt è standard. False altrimenti.
    */

   switch (fmt) {
    case "n":
		return true;
	break;
    case "c":
		return true;
	break;
	case "d":
		return true;
	break;
    case "e":
		return true;
	break;
    case "f":
		return true;
	break;
    case "g":
		return true;
	break;
    case "x":
		return true;
	break;
    case "p":
		return true;
	break;
    default: 
		return false;
   }
};

function GetNumberStyles(fmt){
    /*
    Ritorna una stringa contenente il numberstyle appropriato per il formato numerico fmt.    
    */
	switch(fmt){
		case "n": 
			return "Number";
		break;
		case "c": 
			return "Currency";
		break;
		case "d": 
			return "Integer";
		break;
		case "e": 
			return "Float";
		break;
		case "f": 
			return "Float";
		break;
		case "g": 
			return "Any";
		break;
		case "x": 
			return "HexNumber";
		break;
		case "p": 
			return "Number";
		break;
	}
	return "Any";
};


function IsStandardDateFormatStyle(fmt)
{
    /*
    Ritorna true se il formato data fmt è standard. False altrimenti.    
    */
	switch (fmt) 
	{
		case "d":
			return true;//short date format. -- Main Format
		break;

		case "D":
			return true;//long date format   
		break;

		case "t":
			return true;//time using the 24-hour format
		break;

		case "T":
			return true;//long time format
		break;

		case "f":
			return true;// long date and short time 
		break;

		case "F":
			return true;//  long date and long time 
		break;

		case "g":
			return true;//  short date and short time
		break;

		case "G":
			return true;//4/3/93 05:34 PM.
		break;

		case "m":
			return true;// month and the day of a date
		break;

		case "M":
			return true;// month and the day of a date
		break;

		case "r":
			return true;// date and time as Greenwich Mean Time (GMT)
		break;

		case "R":
			return true;// date and time as Greenwich Mean Time (GMT)
		break;

		case "s":
			return true;// date and time as a sortable index.
		break;

		case "u":
			return true;// date and time as a GMT sortable index
		break;

		case "U":
			return true;// date and time with the long date and long time as GMT.
		break;

		case "y":
			return true;// year and month.
		break;

		case "Y":
			return true;// year and month.
		break;

		default: 
			return false;
	}
};

// Base Functions
function GetFieldLower(pTag,pTagNumber)
{
    /*
    Ritorna l’elemento di posto pTagNumber (
    l’ultimo elemento se pTagNumber > lunghezza del tag) 
    presente in pTag e lo converte tutto in minuscole.
    */
	
	var TagArray;
	if (pTag==null || pTag=="") 
		return null;
	TagArray=pTag.split(".");
	if (pTagNumber>TagArray.length) 
		return TagArray[TagArray.length].toLowerCase();
	return TagArray[pTagNumber].toLowerCase(); 
};

function ConvertDateStringToDate(pString,pStdDateFormat)
{
    /*
    Converte una stringa pString, ritornando una data Javascript, 
    avendo in input pStdDateFormat come formato data. Al momento i 
    formati data supportati (i.e. pStdDateFormat) sono 2:
    -	“d”: DD/MM/YYYY;
    -	“g”: DD/MM/YYYY HH:MM (o HH.MM).
	*/
	
	if (pString==null) 
		return null;
	pString=pString.trim();
	if (pString!='')
	{
		switch(pStdDateFormat)
		{
			case "d":
			{
				var pArray;

				if (pString.indexOf("/")!=-1)
					pString=pString.replace(/\//g," ");  // removes slashes
				if (pString.indexOf("-")!=-1)
					pString=pString.replace(/\-/g," ");  // removes dashes
				pString=pString.replace(/\s+/g,' ');	 // removes multiple spaces
				pArray=pString.split(" ");
				if(isNaN(parseFloat(ParseYear(pArray[2]))) ||  isNaN(parseFloat(pArray[1])) || isNaN(parseFloat(pArray[0])))
					return null;
				var sDate=new Date(ParseYear(pArray[2]), parseFloat(pArray[1])-1, parseFloat(pArray[0]));
				return sDate;
			}
			break;

			case "D":
			{
				/*
				Bisognerà anche implementarlo per "D" e per gli altri formati

				var pArray;
				pArray=pString.split(" ");
				
				var pDataArray;
				pDataArray=pArray[0].split("/");

				var pTimeArray;
				pTimeArray=pArray[1].split(":");

				*/
				return null;
			}
			break;

			case "g":
			{
//				var pArray;

//				pArray=pString.split(" ");

//				var pDateArray;
//				var pTimeArray;

//				pDateArray=pArray[0].split("/");
//				pTimeArray=pArray[1].split(":");

//				var sDate=new Date(ParseYear(pDateArray[2]), parseInt(pDateArray[1])-1, parseInt(pDateArray[0]), parseInt(pTimeArray[0]), parseInt(pTimeArray[1]), parseInt(pTimeArray[2]));
//				return sDate;
//				pString=pString.replace(/[a-zA-Z]/g,"")

				var pArray;
				var pIsTime=false;
				
				if (pString.indexOf(":")!=-1 || pString.indexOf(".")!=-1 )
				{
					pString=pString.replace(/\:/g," ");  // removes colon
					pString=pString.replace(/\./g," ");  // removes dots
					pIsTime=true;
				}

				if (pString.indexOf("/")!=-1)
					pString=pString.replace(/\//g," ");  // removes slashes
				if (pString.indexOf("-")!=-1)
					pString=pString.replace(/\-/g," ");  // removes dashes
				pString=pString.replace(/\s+/g,' ');	 // removes multiple spaces
				pArray=pString.split(" ");

				switch (pArray.length)
				{
					case 2:
					{
						if (pIsTime)
						{
							// First get today's date, then add time from the array
							var sDate=new Date();
							var pYear=ParseYear(myGetYear(sDate).toString());
							var pMonth=sDate.getMonth();
							var pDate=sDate.getDate();
							
							var pHours=pArray[0];
							var pMinutes=pArray[1];
							if(isNaN(parseFloat(pYear)) ||  isNaN(parseFloat(pMonth)) || isNaN(parseFloat(pDate)) || isNaN(parseFloat(pHours)) || isNaN(parseFloat(pMinutes)))
								return null;
							var sDate=new Date(pYear,pMonth,pDate,pHours,pMinutes);
						}
						else
						{
							if (isNaN(ParseYear(pArray[2])) || isNaN(parseFloat(pArray[1])) || isNaN(parseFloat(pArray[0])))
								return null;
							var sDate=new Date(ParseYear(pArray[2]), parseFloat(pArray[1])-1, parseFloat(pArray[0]));
						}
					}
					break;
					case 3:
						if (isNaN(ParseYear(pArray[2])) || isNaN(parseFloat(pArray[1])) || isNaN(parseFloat(pArray[0])))
							return null;
						var sDate=new Date(ParseYear(pArray[2]), parseFloat(pArray[1])-1, parseFloat(pArray[0]),0,0);
					break;
					case 5:
						if (isNaN(ParseYear(pArray[2])) || isNaN(parseFloat(pArray[1])) || isNaN(parseFloat(pArray[0])) || isNaN(parseFloat(pArray[3])) || isNaN(parseFloat(pArray[4])))
							return null;
						var sDate=new Date(ParseYear(pArray[2]), parseFloat(pArray[1])-1, parseFloat(pArray[0]),parseFloat(pArray[3]),parseFloat(pArray[4]));
					break;
				
				}
				return sDate;
			
			}
			break;
		}

	}
	else
	{
		return null;
	}
};

function ConvertDateToDateString(pObject,pStdDateFormat)
{
    /*
    Funzione duale della precedente. Dato un pObject (presumibilmente di tipo Date Javascript) 
    ed un formato data pStdDateFormat (i formati supportati al momento sono “d” e “g” di cui sopra), 
    ritorna una stringa formattata secondo pStdDateFormat.    
    */
    
	var TmpDate;
	var Year;
	var Month;
	var Day;
	var Hours;
	var Minutes;
	var Seconds;
	var StrDay;
	var StrMonth;
	var StrYear;
	var StrHours;
	var StrMinutes;
//	var StrSeconds;
	var RetDateString;

	if (pObject==null)
		return null;

	TmpDate=pObject;
	//Year=TmpDate.getYear();
	Year=myGetYear(TmpDate);
	Month=TmpDate.getMonth()+1;
	Day=TmpDate.getDate();
	switch(pStdDateFormat)
	{
		case "d":
		{
			// dd/mm/yyyy
			//Pad Zeroes to the left of "Day" and "Month" (if necessary)
			StrDay=Day.toString();
			if (StrDay.length==1)
				StrDay = "0" + StrDay;
			StrMonth=Month.toString();
			if (StrMonth.length==1)
				StrMonth = "0" + StrMonth;
            StrYear=Year.toString();
			RetDateString=StrDay + "/" + StrMonth + "/" + StrYear;
			return RetDateString;
		}
		break;

		case "D":
		{
			// Not yet implemented
			return null;
		}
		break;

		case "g":
		{
			// dd/mm/yyyy hh:mm:ss -- needs to be implemented NOW
			Hours=TmpDate.getHours();
			Minutes=TmpDate.getMinutes();
//			Seconds=TmpDate.getSeconds();

			StrDay=Day.toString();
			if (StrDay.length==1)
				StrDay = "0" + StrDay;
			StrMonth=Month.toString();
			if (StrMonth.length==1)
				StrMonth = "0" + StrMonth;
			StrYear=Year.toString();
			StrHours=Hours.toString();
			//if (StrHours.length==1)
			//	StrHours = "0" + StrHours;
			StrMinutes=Minutes.toString();
			if (StrMinutes.length==1)
				StrMinutes = "0" + StrMinutes;
//			StrSeconds=Seconds.toString();
//			if (StrSeconds.length==1)
//				StrSeconds = "0" + StrSeconds;

			RetDateString = StrDay + "/" + StrMonth + "/" + StrYear + " " + StrHours + "." + StrMinutes;
			return RetDateString;
		}
	}
};

function ConvertToJSNumber(pString,pNumberStyle)
{
    /*
    Data una string pString ed un pNumberStyle (che specifica se si tratti di currency o altro), 
    rimuove il simbolo di valuta “€”, il separatore delle migliaia “.” e rimpiazza la virgola con il punto. 
    Restituisce la stringa così ottenuta. Viene richiamata dalla GetObjectFromString. 
    Utilizza le variabili globali CurrencySymbol, CurrencyGroupSeparator e CurrencyDecimalSeparator.    
    */
    
	var pNumber;
	if (pString==null||pString=="")
		return null;

    switch(pNumberStyle)
    {
        case "Currency":
            pString=pString.replace(CurrencySymbol,"");
	        while (pString.indexOf(".")!=-1)
	            pString=pString.replace(CurrencyGroupSeparator,"");
	        pNumber=pString.replace(CurrencyDecimalSeparator,".");
        break;
        default:
	        while (pString.indexOf(".")!=-1)
	            pString=pString.replace(NumberGroupSeparator,"");
	        pNumber=pString.replace(NumberDecimalSeparator,".");
        break;
    }


	return pNumber;
};

function ConvertToNumberString(pNumber,pPrecision,pNumberStyle)
{
    /*
    Dato un pNumber (numero Javascript), una precisione pPrecision ed un pNumberStyle, 
    lo converte dal formato Javascript in stringa. Ad es. 1234673.33 verrà convertito 
    in 1.234.673,33. Se pNumberStyle vale “Currency”, aggiunge anche il simbolo di valuta. 
    Questa funzione viene richiamata da StringValue.
    */
    
	var pArray;
	var IntPart;		// Stores the Integer part of a "number"
	var DecimalPart;	// Stores the Decimal part of a "number"
	var pFloat;
	var DecSeparator;
    var HasNegativeSign;
    var CurrSymbol="";
    
	// Convert the input number into a float to obtain the desired precision
	// (maybe this passage is useless)
	if(pNumber==null) return null;
	if(pNumber=="") pNumber="0";
	pFloat=parseFloat(pNumber);

	if (parseInt(pPrecision)>0)
		pFloat=pFloat.toFixed(parseInt(pPrecision));
	else
		pFloat=pFloat.toFixed(0);

	pNumber = pFloat.toString();
    
    if(pNumber.indexOf("-")!=-1)
    {
        HasNegativeSign=true;
        pNumber=pNumber.replace("-","");
    }
	if (pNumber.indexOf(".")!=-1)
	{
		pArray=pNumber.split(".");

		IntPart=pArray[0];
		DecimalPart=pArray[1];

		DecSeparator=NumberDecimalSeparator;

	}
	else
	{
		IntPart=pNumber;
		DecSeparator="";
		DecimalPart="";
	}

	// Parse Decimal Part and put NumberGroupSeparators
	if (IntPart.length>3) {

		var Counter;	
		var DestinationString;

		Counter=1;
		DestinationString="";
		for (var i=IntPart.length-1;i>=0 ;i--)
		{
			if ((Counter % 3)==0 && (i!=0))
				DestinationString = NumberGroupSeparator + IntPart.charAt(i) +  DestinationString;
			else
				DestinationString = IntPart.charAt(i) + DestinationString;
			Counter++;
		}
	    IntPart = DestinationString;
	} 


    if (pNumberStyle=="Currency") 
        CurrSymbol=CurrencySymbol + " ";
        	
    if(HasNegativeSign)
	    return "-" + CurrSymbol + IntPart + DecSeparator + DecimalPart;
	else
	    return CurrSymbol + IntPart + DecSeparator + DecimalPart;
};

function ExtEnterDecTextBox(pTxtBox, pTag)
{
    /*
    Questa funzione è legata normalmente all’evento client onfocus di un textbox. 
    Dato un textbox pTxtBox ed un tag pTag, sulla base si esso “rimuove” i caratteri extra dal textbox. 
    Per esempio, se si dà il focus ad un textbox contenente un campo di tipo valuta, rimuoverà il simbolo 
    di currency ed i separatori delle migliaia, lasciando soltanto la virgola e rimuovendo eventuali spazi 
    extra a destra e sinistra del numero.
    */
    
	if (pTxtBox.disabled) return;
	if (pTxtBox.readOnly) return;
	pTxtBox.value=pTxtBox.value.trim(); 
	if (pTxtBox.value=="") return;
	var FieldType = GetFieldLower(pTag,0);

	if (FieldType==null||FieldType=="c")
	{
		var S=pTxtBox.value;
		S=S.replace(CurrencySymbol,"");
        while(S.indexOf(NumberGroupSeparator)!=-1)
		    S=S.replace(NumberGroupSeparator,"");
		S=S.replace(" ","");
		pTxtBox.value=S.trim();
		return;
	}
   
    if (FieldType=="n")
    {
		S=pTxtBox.value;
        while(S.indexOf(NumberGroupSeparator)!=-1)
		    S=S.replace(NumberGroupSeparator,"");
		S=S.replace(CurrencySymbol,"");
		pTxtBox.value=S.trim();
    }

	if (FieldType=="fixed")
	{
		var sdec=GetFieldLower(pTag,1);
		var dec=parseInt(sdec);
		
		var prefix = GetFieldLower(pTag,2);
		if (prefix==null) prefix="";

		var suffix = GetFieldLower(pTag,3);
		if (suffix==null) suffix="";
		
		var s = pTxtBox.value;
		
		if (prefix !="") s = s.replace(prefix,"");
		if (suffix !="") s = s.replace(suffix,"");

        while(s.indexOf(NumberGroupSeparator)!=-1)
		    s=s.replace(NumberGroupSeparator,"");

		pTxtBox.value=s.trim();

	}

};

function ExtEnterNumTextBox(pTxtBox, pTag)
{
    /*
    Questa funzione è legata normalmente all’evento client onfocus di un textbox. 
    Dato un textbox pTxtBox ed un tag pTag, sulla base si esso “rimuove” i caratteri extra dal textbox. 
    Per esempio, se si dà il focus ad un textbox contenente un campo di tipo valuta, rimuoverà il simbolo 
    di currency ed i separatori delle migliaia, lasciando soltanto la virgola e rimuovendo eventuali spazi 
    extra a destra e sinistra del numero.    
    */
    
	if (pTxtBox.disabled) return;
	if (pTxtBox.readOnly) return;

	pTxtBox.value=pTxtBox.value.trim();
	if (pTxtBox.value=="") return;

	var FieldType = GetFieldLower(pTag,0);

	if (FieldType==null||FieldType=="n")
	{
		S=pTxtBox.value;
        while(S.indexOf(NumberGroupSeparator)!=-1)
		    S=S.replace(NumberGroupSeparator,"");
		pTxtBox.value=S.trim();
	}
    if (FieldType=="c")
    {
		S=pTxtBox.value;
        while(S.indexOf(NumberGroupSeparator)!=-1)
		    S=S.replace(NumberGroupSeparator,"");
		S=S.replace(CurrencySymbol,"");
		pTxtBox.value=S.trim();
    }

	if (FieldType=="fixed")
	{
		var sdec = GetFieldLower(pTag,1);
		var dec = parseInt(sdec);
		var prefix = GetFieldLower(pTag,2);
		if (prefix==null) prefix="";
		var suffix = GetFieldLower(pTag,3);
		if (suffix==null) suffix="";
		var s = pTxtBox.value;

		if (prefix!="") s = s.replace(prefix,"");
		if (suffix!="") s = s.replace(suffix,"");
        
        while(s.indexOf(NumberGroupSeparator)!=-1)
		    s=s.replace(NumberGroupSeparator,"");

		pTxtBox.value=s.trim();
	}
};

function FormatLikeYear(pTxtBox)
{
    // Non utilizzata!
    
	var D = parseInt(pTxtBox.value);

	if (isNaN(D)) return;

	if (D>=100) return;

	var lDate = new Date();
	var Year = myGetYear(lDate);

	var aa = Year % 100;

	var CC = Year - aa;

	D=D+CC;
	
	if (aa>50) D = D + 100;
	pTxtBox.value=D.toString();
	return;
};

function myGetYear(pDate)
{
    /*
    Questa funzione, data una data pDate, ritorna l’anno nel formato a 4 cifre. 
    Tale funzione è stata introdotta per aggirare una differenza di implementazione della funzione getYear() 
    tra Internet Explorer e Firefox/Chrome/Safari. Si riporta una nota:    

    The getYear() method returns the year, as a two-digit OR a three/four-digit number.
    The value returned by getYear() is not always four digits. For years between 1900 and 1999 the getYear() method returns only two digits.
    For other years (before 1900 and after 1999) the return is browsers dependant:
    Internet Explorer:
        * Returns four digits for years before 1900 and after 1999.
    Firefox:
        * Returns a value less than 0 for years before 1900. For example, the year 1800 returns -100.
        * Returns a value 100 or greater for years greater than or equal to 2000. For example, the year 2008 returns 108.
    */

    var Year;
    if (pDate==null) return null;
    return pDate.getFullYear();
    
    Year=pDate.getYear();
    if(Browser=="netscape")   
	{
        return 1900 + Year;
	}
    else
    {
        // Internet Explorer
        if(Year>=0 && Year<=99)
            return 1900 + Year;
        else
            return Year;
    }
};

function ParseYear(pYear)
{
    /*
    Dato un numero pYear (a 2 cifre), lo converte in anno secondo le seguenti regole:
    -	se pYear >=0 e <=29, ritorna 2000 + pYear;
    -	se pYear>=30 e <=99, ritorna 1900 + pYear.
    La funzione viene richiamata dalla ConvertDateStringToDate.
    */
    
    if(typeof(pYear)=="undefined" || pYear==null ||  pYear.trim()=='') 
	{	
		var TodaysDate=new Date();
		pYear=myGetYear(TodaysDate);
	}

	var intYear=parseFloat(pYear);
    if(intYear>=0 && intYear<=29)
        return 2000 + intYear;
    if(intYear>=30 && intYear<=99)
        return 1900 + intYear;
    return intYear;
};


// Funzioni relative agli elenchi
function CreateXSLTProcessObject()
{
    /*
    Crea l’oggetto per il processing dell’XML mediante foglio di stile XSLT. 
    Tale funzione si è resa necessaria in quanto l’oggetto da creare è diverso a 
    seconda del browser utilizzato. Per Internet Explorer si utilizza l’oggetto 
    ActiveX Microsoft.XMLDOM, mentre tutti gli altri utilizzano l’oggetto XSLTProcessor(). 
    Questa funzione fa parte del set di quelle che si occupano della gestione delle chiamate 
    AJAX necessarie alla gestione da parte del client dell’oggetto elenco.    
    */
    
    var xslObj;
    if (window.ActiveXObject || "ActiveXObject" in window)
    {
        try
        {
            xslObj=new ActiveXObject("Microsoft.XMLDOM");
        } catch (e)
        { }
    }
    else
        xslObj=new XSLTProcessor();
    return xslObj;
};

function CreateXmlHttpRequestObject()
{
    /*
    Crea l’oggetto necessario alle richieste XMLHTTP, necessarie alle chiamate 
    AJAX dal client al server per la gestione dell’oggetto elenco. 
    L’oggetto cambia a seconda del browser utilizzato e della versione dello stesso.
    
    In particolare:
    -	IE7-8-9 utilizzano l’ActiveX Microsoft.XMLHTTP
    -	IE6 usa l’ActiveX Msxml2.XMLHTTP.
    -	Firefox/Chrome/Safati possono utilizzare l’oggetto XMLHttpRequest nativamente.
    */
    
    var xmlObj;
   if (window.ActiveXObject || "ActiveXObject" in window) {
        try     {
           xmlObj = new ActiveXObject("Microsoft.XMLHTTP");
        } 
        catch (e)   {
           xmlObj = new ActiveXObject("Msxml2.XMLHTTP");
        }
    } else {
        xmlObj = new XMLHttpRequest();     
    }
    return xmlObj;
};

function SelectRow(pRowNumber,pTxtBoxName)
{
    if (typeof(ElmElenco)=="undefined") return;

    /*
    Evento di selezione della riga pRowNumber di un elenco (è associato all’evento doppio 
    click di ciascuna riga).  Viene scatenato nel momento in cui, dopo che è stata aperta una choose, 
    ed è stato visualizzato l’elenco, viene selezionata la riga. Dopo aver reso invisibile l’elenco 
    e riattivato i controlli del form corrente, se specificato un pTxtBoxName, ne scatena l’evento blur 
    e contestualmente rimuove la classe CSS del textbox, imposta inoltre il valore del textbox ElmRecordIsSelected 
    (variabile globale)  al valore “S” (record selezionato).
    Se non è specificato pTxtBoxName, imposta solo il valore del textbox ElmRecordIsSelected ad “S”.
    Pone inoltre nel textbox ElmSelectedRecord l’indice della riga selezionata. Viene inoltre scatenato 
    l’evento onchange di quest’ultimo textbox che scatena la postback.
    */
    
    // questo DOVREBBE far scattare l'onchange...
    //    document.getElementById("SelectedRecord").value=pRowNumber;

    // Questo pezzo andrà rimosso, perchè alla postback si porrà ShowElenco a "N"
    document.getElementById(ElmElenco).style.display="none";
    
    //EnableControls();
    RecordIsSelected = true;
    if(pTxtBoxName!=null && pTxtBoxName!="")
    {
        document.getElementById(pTxtBoxName).className="";
        document.getElementById(ElmRecordIsSelected).value="S";
        document.getElementById(pTxtBoxName).blur();
    }
    else
    {
        document.getElementById(ElmRecordIsSelected).value="S";
    }
    //alert("PostBack On Record Selected:" + pRowNumber + " written on TextBox:SelectedRecord");
    // Add Code for doPostBack
    document.getElementById(ElmSelectedRecord).value=pRowNumber;
    

    document.getElementById(ElmSelectedRecord).onchange();
    return true;
};

function CloseList(pTxtBoxToGiveFocus)
{
    /*
    Evento   legato alla chiusura dell’elenco corrente (mediante l’icona di chiusura). 
    Chiama la funzione DestroyCLM per distruggere il ListManager corrente, “nasconde” l’elenco 
    e riassegna il focus al textbox che ha “aperto” l’elenco.    
    */
    
    //document.images.imgClose.src="Immagini/CloseRev.gif";
    //setTimeout("HideList()",200);
    HideList();
    // enable controls
    DestroyCLM();
    //EnableControls();
    
    
    
    
    ListHeight=0;
    ListWidth=0;
    TopWindowPos=200;
    LeftWindowPos=50;
    isListFullSized=false;
    PreviousSelectedRow=-1;
    PreviousRowClassName="";
    //alert("imposto a N la selezione");
    document.getElementById(ElmRecordIsSelected).value="N";
    RecordIsSelected=false;

    if(pTxtBoxToGiveFocus!=null) {
        //alert("imposto a S prima di dare il focus");        
        pTxtBoxToGiveFocus.value = document.getElementById(ElmPreviousValue).value;
        pTxtBoxToGiveFocus.focus();
        //__doPostBack("do_maincommand", 'freshform');
        //__doPostBack(pTxtBoxToGiveFocus, '');
    }
    else
        document.getElementById(ElmShowElenco).value="N";
    return;
    
};

function DestroyCLM()
{
    /*
    Distrugge il ListManager corrente sul server, mediante chiamata AJAX alla 
    pagina XMLRequestList.aspx con parametro URL DestroyCLM=Y. 
    Viene chiamata da CloseList.    
    */
    
    var xmlHttpObj;
    xmlHttpObj = CreateXmlHttpRequestObject();

    xmlHttpObj.open("GET",XMLRequestURL+"?DestroyCLM=Y", false);
    var doc = xmlHttpObj.responseXML;
    xmlHttpObj.send(null);

    return;    
};


function HideList()
{
    /*
    Nasconde l’elenco corrente, ponendo la proprietà style.display della DIV 
    ElmElenco a “none”. Invocata da CloseList.
    */
    $("#" + ElmElenco).remove();
    //document.getElementById(ElmElenco).style.display="none";
    return;
};

function CreateList(pValue, pName, pPage)
{
    /*
    Viene utilizzata per richiedere la pagina pPage dell’elenco corrente. 
    Se è specificato il parametro pName, esso rappresenta il textbox che ha scatenato la choose 
    al quale bisognerà dare il focus nel caso in cui l'elenco verrà chiuso.
    pValue è il valore corrente del textbox. Con questi parametri viene effettuata la chiamata AJAX
    alla pagina ASP "XMLRequestURL" (variabile globale istanziata a runtime).
    L'XML così ottenuto viene trasformato mediante trasformazione con foglio XSLT (variabile globale 
    XSLTRequestURL istanziata a runtime - corrispondente ad XMLRequestList.aspx del website
    ) in un HTML contenente la table dell'elenco. In pratica l'XML contiene l'HTML dell'elenco. Poichè 
    l'oggetto XMLHTTPRequest risponde soltanto con dell'XML, questo codice HTML dell'elenco viene incluso 
    nell'XML e trasformato mediante il foglio di stile XSLT TransformToTable.xsl in un HTML "depurato" dell'XML.
    Nell'HTML così ottenuto, nel caso la trasformazione sia stata effettuata da IE, vengono rimpiazzati i caratteri
    "&gt;" con ">", "&lt;" con "<" ed "&amp;" con "&".
    Successivamente pone questo HTML nella DIV ElmElenco, rendendola poi visibile ponendo la proprietà style.display 
    a "block".
    Se pName!="" vuol dire che si tratta di un'autochoose. Altrimenti si tratta di una choose invocata
    con un pulsante, pertanto non è necessario dare il focus ad un textbox. 
    */

    var xmlHttpObj;
//  disable(document.getElementById("Controls"));
    //DisableControls();
    
    xmlHttpObj = CreateXmlHttpRequestObject();

    if(pName!="")
        xmlHttpObj.open("GET",XMLRequestURL+"?TxtBoxId=" + escape(pName) + "&Value=" + escape(pValue) + "&PageNumber=" + pPage + "&DivElencoId=" + ElmElenco, false);
    else
        xmlHttpObj.open("GET",XMLRequestURL+"?PageNumber=" + pPage + "&DivElencoId=" + ElmElenco, false);
    
    // doc è l'XML della table
    var doc = xmlHttpObj.responseXML;
    xmlHttpObj.send(null);

    
    xslHttpObj = CreateXmlHttpRequestObject();
    xslHttpObj.open("GET",XSLTRequestURL, false);
    
    // stylesheet è il foglio di stile XSLT per trasformare l'XML in HTML
    var stylesheet = xslHttpObj.responseXML;
    xslHttpObj.send(null);

    if (window.ActiveXObject || "ActiveXObject" in window)
    {
        //totalpages è il numero totale di pagine e si preleva dall'XML di origine
        var totalpages=doc.getElementsByTagName("totalpages")[0].firstChild.data;
        //trasforma doc in un HTML utilizzando stylesheet
        var strTable = doc.transformNode(stylesheet);
    }
    else
    {
        // crea l'oggetto XSLTProcess
        var xsltProc=CreateXSLTProcessObject();
        // importa lo stylesheet
        xsltProc.importStylesheet(xslHttpObj.responseXML);
        
        // preleva totalpages dall'XML originale
        var totalpages=xmlHttpObj.responseXML.getElementsByTagName("totalpages")[0].firstChild.data;
        
        // trasforma il doc XML in un HTML
        var html = xsltProc.transformToFragment(xmlHttpObj.responseXML,document);
        
        // serializza l'HTML in una stringa
        var strTable = new XMLSerializer().serializeToString(html);
        strTable = strTable.replace(/&amp;/gi, "&");
        strTable = strTable.replace(/&lt;/gi, "<");
        strTable = strTable.replace(/&gt;/gi, ">");
    }
    

    // Imposta la prima pagina visualizzata nell'elenco a pPage
    CurrentPageDisplayed = pPage;
    FirstPageDisplayedInList= pPage - (  NumberOfPagesInFooter/2);
    if (FirstPageDisplayedInList < 1) FirstPageDisplayedInList=1;
    LastPageDisplayed= FirstPageDisplayedInList+NumberOfPagesInFooter-1;
    
    if (NumberOfPagesInFooter<NumberOfPagesInList){
        if (LastPageDisplayed > NumberOfPagesInList ){
           FirstPageDisplayedInList=  NumberOfPagesInList-  NumberOfPagesInFooter+1;
           LastPageDisplayed=NumberOfPagesInList;
        }
    }
    else {
        FirstPageDisplayedInList=1;
        LastPageDisplayed=NumberOfPagesInList;
    }

    $("#mainhwlist").remove();

    // l'HTML ottenuto dalla trasformazione viene assegnato
    // all'innerHTML della div ElmElenco (il cui ID viene risolto a runtime)
    document.getElementById(ElmElenco).innerHTML="";
    document.getElementById(ElmElenco).innerHTML = strTable;
    

    // visualizza la div ElmElenco ponendo a "block" la proprietà style.display
    document.getElementById(ElmElenco).style.display="block";
    // Crea il footer dell'elenco
    CreateFooter();
    
    // la width della finestra che è usata per calcolare le dimensioni dell'elenco
    // si determina in maniera differente per Netscape e per IE
    //var winW=1000;
    //if (navigator.appName=="Netscape") {
    //    winW = window.innerWidth;
    //}
    //if (navigator.appName.indexOf("Microsoft")!=-1) {
    //    winW = document.body.offsetWidth;
    //}
    
    

    $("table.to_pgrid2").pgrid({
        pgrid_footer: true,
        pgrid_count: false,
        pgrid_select: true,
        pgrid_multi_select: false,
        pgrid_paginate: true,
        pgrid_sort_col: false,
        pgrid_perpage: 20,
        pgrid_row_hover_effect: false,
        pgrid_view_height: 'auto',
        pgrid_resize: false
    }
             );




    //var LeftMargin = (winW - (document.getElementById(ElmElenco).offsetWidth)) / 2 ;
    //// arrotonda il leftmargin
    //LeftMargin=LeftMargin.toFixed(0);
    

    //$( "#"+ElmElenco).draggable();
    $("#mainhwlist").dialog({
        modal: true, width: "auto",
        create: function (event) {
            $(event.target).parent().css({ 'position': 'fixed', "top": 150 });
        },
        close: function () {
            CloseList(document.getElementById($("#mainhwlist").data("txtclient")));

        }
    });
    

    return;
};
/*
function CreateHeader(pPageTitle,pTxtBoxName)
{
    var Header="";
    Header="<div class=\"tblHeader\" onmousedown=\"mD(document.getElementById('<%=%>'),event)\" width=\"100%\">";
    Header+= "<table width=\"100%\"><tr><td>" + pPageTitle + "</td>";
    Header+= "<td width=\"20px\"><img id=\"imgClose\" src=\"close.gif\" OnClick=\"CloseList(document.getElementById('" + pTxtBoxName + "'));\"/></td></tr></table>";
    Header+= "</div>";
    
    return Header;
}
*/



var hw_inited = false;
function hw_init() {
    /*
    Inizializzazione lato client della pagina. Invocata all'onload. Inizializza ob (variabile globale che
    identifica la div ElmElenco che contiene l'elenco). Se ElmShowElenco vale "S", renderizza il footer
    dell'elenco e rende visibile la div che lo contiene, disabilitando i controlli del form. Invoca la funzione
    di inizializzazione dei Tabs, imposta i margini sinistro e superiore dell'elenco. Quello sx, sulla base 
    della larghezza della finestra del browser che è determinata in maniera differente a seconda che si utilizzi
    Internet Explorer oppure FireFox & Co. Se FocusOnStartup!=null gli dà focus.
    */
    if (ElmElenco && document.getElementById(ElmElenco)) {    
        var ob = document.getElementById(ElmElenco);
        RecordIsSelected = false;
        if (ElmRecordIsSelected && document.getElementById(ElmRecordIsSelected)){
            RecordIsSelected = ((document.getElementById(ElmRecordIsSelected).value=="S") ? true : false);
        }
    
        if(ElmShowElenco && document.getElementById(ElmShowElenco) && 
                document.getElementById(ElmShowElenco).value=="S")   {
            RenderListFooterAfterPostBack();
            $("#mainhwlist").dialog({
                modal: true,
                width: "auto",
                create: function (event) {
                    $(event.target).parent().css({ 'position': 'fixed', "top": 150 });
                },
                close: function () {
                    CloseList(document.getElementById($("#mainhwlist").data("txtclient")));

                } });
            
            //ob.style.display="block";
            //DisableControls();
        }
        else {
            $("#mainhwlist").remove();
            //ob.style.display="none";
        }
     
        
    
        //if (navigator.appName=="Netscape") {
        //    var winW = window.innerWidth;
        //}
        //if (navigator.appName.indexOf("Microsoft")!=-1) {
        //    var winW = document.body.offsetWidth;
        //}
        


        //ob.style.margin="0px";
        //ob.style.position="absolute";

        //var LeftMargin = (winW - (ob.offsetWidth)) / 2 ;
        //LeftMargin=LeftMargin.toFixed(0);
      
    
        //ob.style.left=LeftMargin + "px";
        //ob.style.top="20px";
        ////$("#" + ElmElenco).draggable();

    }
   
    
    InitTabs();
    InitNewTabs();
    
    if (typeof FocusOnStartup !== 'undefined' && document.getElementById(FocusOnStartup)) {
        var el = document.getElementById(FocusOnStartup);
       
        
        if (SimulateTab == "S") {
            el = NextAfter(el);
            //$.tabNext(el);
        } 
        
        //$("#" + FocusOnStartup).focus();
        SetFocusTo(el);
        FocusOnStartup=null;

    }
    
    hw_inited = true;
    return;
};
function SetFocusTo(el) {
    SelectTabForControl(el);
    el.focus();
    savefocus(el);
}

function NextAfter(current_el){
    var selectednext = null;
    $(":visible").each(function(index, element) {
        if (element.tabIndex == null) return;
        if (element.tabIndex <= current_el.tabIndex) return;
        if (selectednext == null) {
            selectednext = element;
            return;
        }
        if (selectednext.tabIndex < element.tabIndex) return;
        selectednext = element;
    }
    );
    if (selectednext == null) return current_el;
    return selectednext;

};

 function SetImageSrc(myControl, img_src1) {
    /*
    imposta l'immagine img_src1 per il controllo myControl (img?)
    */
     //var myControl = document.getElementById(IDImg);
     if (myControl == null) {
         alert('SetImageSrcByID  --- Controllo non trovato : ' + IDImg);
         return;
     }
    myControl.src = img_src1;
 };

function RenderListFooterAfterPostBack()
{
    CreateFooter();
};

function CreateFooter()
{
    /*
    Renderizza il footer dell'elenco. Del tutto analoga alla precedente. Differisce soltanto per il 
    ciclo "for".
    */
    
    var div;
    
    div=document.getElementById("tblFooter");
    
    var Footer="";
    if(NumberOfPagesInList<=1) 
    {
        Footer+="<table width='100%' height='27px' valign='center'><tr valign='center'><td valign='center'><center><span valign='center'>";
        Footer+="</span></center></td></tr></table>";
        div.innerHTML=Footer;
        return;
    }

    Footer+="<table width='100%' height='27px' valign='center'><tr valign='center'><td valign='center'><center><span valign='center'>";
    
    if((FirstPageDisplayedInList+NumberOfPagesInFooter-1)>NumberOfPagesInList)
        var UpperLimit=NumberOfPagesInList;
    else
        var UpperLimit=FirstPageDisplayedInList + NumberOfPagesInFooter-1;

    
    if (CurrentPageDisplayed>1)     
        Footer +="<img align='middle' src='Immagini/First.gif' onclick='Javascript:GoFirstPage();'>";
    
    if (FirstPageDisplayedInList>1)
        Footer+="<img align='middle' src='Immagini/PreviousTen.gif' onclick='Javascript:ShowPreviousPages();'>";
    
    if (CurrentPageDisplayed>1)
        Footer+="<img align='middle' src='Immagini/Previous.gif' onclick='Javascript:GoPreviousPage();'>";

    
    var TextBox=document.getElementById(TextBoxIdForList);
    for(var x=FirstPageDisplayedInList;x<=UpperLimit;x++)
    {
        if(x!=CurrentPageDisplayed) {
                if (TextBoxIdForList!='' && TextBox!=null) 
                    Footer+="<a href=\"Javascript:CreateList('" +  TextBox.value + "','" + TextBox.id + "'," + x +");\">" + x + "</a>&nbsp;";       
                   else
                    Footer+="<a href=\"Javascript:CreateList('',''," + x +");\">" + x + "</a>&nbsp;";       
                   
            }
        else
            Footer+="<b>"+x + "&nbsp;</b>";
    }    
    
    if (CurrentPageDisplayed<NumberOfPagesInList)
        Footer+="<img align='middle' src='Immagini/Next.gif' onclick='Javascript:GoNextPage();'>";
    if (UpperLimit  < NumberOfPagesInList)
        Footer+="<img align='middle' src='Immagini/NextTen.gif' onclick='Javascript:ShowNextPages();'>";
    
    if (CurrentPageDisplayed!=NumberOfPagesInList)     
        Footer+="<img align='middle' src='Immagini/Last.gif' onclick='Javascript:GoLastPage();'>";
    
    Footer += "</span></center></td>";
    Footer+="</tr></table>";
    div.innerHTML="";
    div.innerHTML=Footer;
    return;    
};

function GoNextPage()
{
    /*
    Agganciato all'onclick della freccetta dx (">") nel footer dell'elenco per
    l'avanzamento (se possibile) della pagina. Richiama CreateList
    */
    CurrentPageDisplayed  = CurrentPageDisplayed+1;
    if (CurrentPageDisplayed> NumberOfPagesInList) CurrentPageDisplayed=NumberOfPagesInList;
    
    var lTextBox=document.getElementById(TextBoxIdForList);
    if (lTextBox!=null) 
        CreateList(lTextBox.value,lTextBox.id,CurrentPageDisplayed);
    else
        CreateList('','',CurrentPageDisplayed);
    
        
    return;
};


function ShowNextPages()
{
    /*
    Agganciato all'onclick della doppia freccetta dx (">>") nel footer dell'elenco
    per avanzare (se possibile) di 10 pagine. Richiama CreateList
    */
    if (CurrentPageDisplayed+NumberOfPagesInFooter > NumberOfPagesInList)
            CurrentPageDisplayed=NumberOfPagesInList;
    else
            CurrentPageDisplayed+=NumberOfPagesInFooter;

    var lTextBox=document.getElementById(TextBoxIdForList);
    if (lTextBox!=null) 
        CreateList(lTextBox.value,lTextBox.id,CurrentPageDisplayed);
    else
        CreateList('','',CurrentPageDisplayed);

    return;
};

function GoPreviousPage()
{
    /*
    Agganciato all'onclick della freccetta sx ("<") nel footer dell'elenco
    per andare (se possibile) alla pagina precedente. Richiama CreateList
    */
    if(CurrentPageDisplayed>1)  CurrentPageDisplayed-=1;
     
    var lTextBox=document.getElementById(TextBoxIdForList);
    if (lTextBox!=null) 
        CreateList(lTextBox.value,lTextBox.id,CurrentPageDisplayed);
    else
        CreateList('','',CurrentPageDisplayed);

    return;
};


function ShowPreviousPages()
{
    /*
    Agganciato all'onclick della doppia freccetta sx ("<<") nel footer dell'elenco
    per retrocedere (se possibile) di 10 pagine. Richiama CreateList
    */
    CurrentPageDisplayed -= NumberOfPagesInFooter;
    if (CurrentPageDisplayed<1) CurrentPageDisplayed=1;

    var lTextBox=document.getElementById(TextBoxIdForList);
    if (lTextBox!=null) 
        CreateList(lTextBox.value,lTextBox.id,CurrentPageDisplayed);
    else
        CreateList('','',CurrentPageDisplayed);

    return;
};

function GoFirstPage()
{
    /*
    Agganciato all'onclick della freccetta "|<" nel footer dell'elenco
    per andare alla prima pagina. Richiama CreateList
    */
    CurrentPageDisplayed=1;
    var lTextBox=document.getElementById(TextBoxIdForList);
    if (lTextBox!=null) 
        CreateList(lTextBox.value,lTextBox.id,CurrentPageDisplayed);
    else
        CreateList('','',CurrentPageDisplayed);

    return;
};

function GoLastPage()
{
    /*
    Agganciato all'onclick della freccetta ">|" nel footer dell'elenco
    per andare all'ultima pagina. Richiama CreateList
    */

    CurrentPageDisplayed=NumberOfPagesInList;
    var lTextBox=document.getElementById(TextBoxIdForList);
    if (lTextBox!=null) 
        CreateList(lTextBox.value,lTextBox.id,CurrentPageDisplayed);
    else
        CreateList('','',CurrentPageDisplayed);
    return;
};


function Resize()
{
    /*
    Evento legato al resize dell'elenco. Attivabile in due modalità:
    - mediante doppio click sulla barra blu;
    - mediante apposito pulsante (simile al pulsante "ingrandisci" di Windows).
    "Simula" la pressione del pulsante (mediante sostituzione dell'immagine associata ad 
    esso). Se la variabile "isListFullSized" è a true, vuol dire che l'elenco è già massimizzato,
    altrimenti lo massimizza.
    
    */

    //setInterval("ReplaceImg()",300);
    //document.images.imgResize.src="Immagini/ResizeRev.gif";

    if(!isListFullSized)
    {
        $("#icondialogresize").removeClass("ui-icon-arrow-4-diag");
        $("#icondialogresize").addClass("ui-icon-newwin");
        TopWindowPos=$("#"+ElmElenco).offset().top; //document.getElementById(ElmElenco).style.top;
        LeftWindowPos=$("#"+ElmElenco).offset().left; //document.getElementById(ElmElenco).style.left;
        $("#"+ElmElenco).offset({top:0,left:0});
        //document.getElementById(ElmElenco).style.top=0;
        //document.getElementById(ElmElenco).style.left=0;

        ListWidth=$("#"+ElmElenco).width(); // document.getElementById(ElmElenco).offsetWidth;
        ListHeight=$("#"+ElmElenco).height(); //document.getElementById(ElmElenco).offsetHeight;

        $("#"+ElmElenco).width('100%'); //document.getElementById(ElmElenco).style.width='100%';
        //document.getElementById("tblTable").style.width='100%';
        //document.getElementById("tblHeader").style.width='100%';
        $("#"+ElmElenco).height('100%'); //document.getElementById(ElmElenco).style.height='100%';
        isListFullSized=true;
    }
    else
    {
        $("#icondialogresize").addClass("ui-icon-arrow-4-diag");
        $("#icondialogresize").removeClass("ui-icon-newwin");
        $("#"+ElmElenco).offset({top:TopWindowPos,left:LeftWindowPos});
        //document.getElementById(ElmElenco).style.top=TopWindowPos ;
        //document.getElementById(ElmElenco).style.left=LeftWindowPos ;
        $("#"+ElmElenco).width(ListWidth);        
        //document.getElementById(ElmElenco).style.width=ListWidth ;
        //document.getElementById("tblTable").style.width=ListWidth;
        //document.getElementById("tblHeader").style.width=ListWidth;
        $("#"+ElmElenco).height(ListHeight);
        //document.getElementById(ElmElenco).style.height=ListHeight ;

        isListFullSized=false;
    }
    
    return;
};

function ReplaceImg()
{
    /*
    Utilizzata da Resize() per sostituire l'immagine del pulsante di massimizzazione
    */
    document.images.imgResize.src="Immagini/Resize.gif";
    return;
};

function HighlightListRow(pRow)
{
    PreviousSelectedRow=pRow;
    return;
    /*
    Funzione associata all'evento onclick di ogni riga di un elenco. Simula la selezione di una riga,
    mediante il cambiamento della classe css della stessa (viene posta a "selected"). Se una riga
    era precedentemente selezionata, viene rimossa la classe "selected" dalla riga e viene assegnata
    alla nuova riga. 
    Si è reso necessario memorizzare il classname della riga corrente, perchè impostarlo a "" potrebbe
    rimuovere qualsiasi stile selezionato per la riga (es. odd/even per colorare le righe in maniera 
    differente a seconda se è pari o dispari).
    */
    if(PreviousSelectedRow!=-1) 
    {
        document.getElementById("tblListRow"+PreviousSelectedRow).className="";
        document.getElementById("tblListRow"+PreviousSelectedRow).className=PreviousRowClassName;
    }

    PreviousRowClassName=document.getElementById("tblListRow"+pRow).className;
    document.getElementById("tblListRow"+pRow).className="ui-pgrid-table-row-selected ui-state-active";
    PreviousSelectedRow=pRow;

};

function getTabState() {
    if (!document.getElementById(ElmCurrentFoldersConfig)) return {};
    var txtState = document.getElementById(ElmCurrentFoldersConfig);    
    return JSON.parse(txtState.value || "{}");
    
}
function setTabState(state) {
    if (!document.getElementById(ElmCurrentFoldersConfig)) return;
    var txtState = document.getElementById(ElmCurrentFoldersConfig);
    if (state) {
        txtState.value = JSON.stringify(state);
    }
    else {
        txtState.value = JSON.stringify({});
    }
}
//http://stackoverflow.com/questions/10523433/how-do-i-keep-the-current-tab-active-with-twitter-bootstrap-after-a-page-reload
function InitNewTabs() {
    if (!MetaMasterUsingBootstrap) return;
    var json, tabsState;
    $('a[data-toggle="pill"], a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
        var href, json, parentId, tabsState;

        json = getTabState();        
        parentId = $(e.target).parents("ul.nav.nav-pills, ul.nav.nav-tabs").attr("id");
        href = $(e.target).attr('href');
        json[parentId] = href;        
        return setTabState(json);
    });
    
    json = getTabState();

    $.each(json, function (containerId, href) {
        return $("#" + containerId + " a[href=" + href + "]").tab('show');
    });

    $("ul.nav.nav-pills, ul.nav.nav-tabs").each(function () {
        var $this = $(this);
        if (!json[$this.attr("id")]) {
            return $this.find("a[data-toggle='tab']:first, a[data-toggle='pill']:first").tab("show");
        }
    });
}

function InitTabs() {
    if (MetaMasterUsingBootstrap) return;
    var x, y;
    /*
    Inizializza i Tabs (se presenti) di un form web. 
    Conta cioè le divs il cui id è nel formato TabXFolderY, dove:
    - X è il numero del tabcontrol;
    - Y è l'Y-esimo tab dell'X-esimo tab control.
    Per ognuno dei folders individuati per ciascun tab, crea degli span che contengono le intestazioni,
    utilizzando come caption la proprietà title di ciascuna div TabXFolderY.     
    La configurazione dei tabs è contenuta nel textbox ElmCurrentFoldersConfig, nel formato:
                            
                            1|4|2
                            
    Che va interpretato nella maniera seguente:
    - il primo tab è impostato sul primo folder;
    - il secondo tab è impostato sul quarto folder;
    - il terzo tab è impostato sul secondo folder.
    
    Qualora non sia presente la configurazione corrente dei folders, viene costruita inizializzando tutti
    i folders a 1, chiamando la funzione BuildInitialFoldersConfig.                             
    
    */
    // Count the number of divs in the format TabXFolderY
    for ( x = 1; x <= MaxTabNumber; x++) {
        FolderNumber[x] = 0;
        if (document.getElementById("Tab" + x + "Folder1") != null) {
            for ( y = 1; y <= MaxFolderPerTabNumber; y++) {
                if (document.getElementById("Tab" + x + "Folder" + y) == null) {
                    FolderNumber[x] = y - 1;
                    break;
                }
            }
        }
    }
    // Create Spans for header (find out HOW to give titles to each single header)
    var TabsHeader = "";
    for (x = 1; x <= MaxTabNumber; x++) {
        TabsHeader = "";
        if (FolderNumber[x]) {
            for ( y = 1; y <= FolderNumber[x]; y++)
                TabsHeader += "<span id=\"HTab" + x + "Folder" + y
                    + "\" class=\"TabsHeaderUnselected\" onclick=\"javascript:SwitchTab(" + x + "," + y + ")\">&nbsp;&nbsp;" +
                    document.getElementById("Tab" + x + "Folder" + y).title + "&nbsp;&nbsp;</span>";
            document.getElementById("TabsHeader" + x).innerHTML = TabsHeader;
        }
    }
    var isCurrentFoldersConfigEmpty = false;

    for (x = 1; x <= MaxTabNumber; x++) {
        if (FolderNumber[x] != 0) {
            if (document.getElementById(ElmCurrentFoldersConfig) != null &&
                document.getElementById(ElmCurrentFoldersConfig).value != null &&
                document.getElementById(ElmCurrentFoldersConfig).value != "") {
                SwitchTab(x, GetCurrentFolderForTab(x));
            } else {
                SwitchTab(x, 1);
                isCurrentFoldersConfigEmpty = true;
            }
        }
    }

    if (isCurrentFoldersConfigEmpty) BuildInitialFoldersConfig();

    return;
}

;

function BuildInitialFoldersConfig()
{
    /*
    Costruisce la configurazione iniziale dei tabs, ponendo
    tutti i folders a 1:
    1|1|1|....
    */
    var FoldersConfig="";
    for(var x=1;x<=MaxTabNumber;x++)
    {
        FoldersConfig+="1|";
    }
    FoldersConfig=FoldersConfig.substring(0,FoldersConfig.length-1);
    document.getElementById(ElmCurrentFoldersConfig).value=FoldersConfig
};

function GetCurrentFolderForTab(pTab)
{
    /*
    Ritorna il folder corrente del Tab pTab-esimo.
    */
    
    var CurrentFolderConfig;
    var CurrentFolderConfigArray;
    if(document.getElementById(ElmCurrentFoldersConfig).value!=null && document.getElementById(ElmCurrentFoldersConfig).value!='')
    {
        CurrentFolderConfig=document.getElementById(ElmCurrentFoldersConfig).value;
        CurrentFolderConfigArray=CurrentFolderConfig.split("|");
        if(CurrentFolderConfigArray[pTab - 1]!=null)
            return CurrentFolderConfigArray[pTab - 1];
        else
            return 1;
    }
    else
        return 1;
};

function StoreFolderForTab(pTab,pFolder)
{
    /*
    Memorizza in ElmCurrentFoldersConfig la configurazione corrente
    ricorstruendo la stringa e ponendo nella posizione pTab il folder pFolder.
    Esempio: se il text di ElmCurrentFoldersConfig vale 2|1|3
    la chiamata a StoreFolderForTab(3,2) avrà come effetto su ElmCurrentFoldersConfig:
    2|1|2
    Cioè il terzo tab viene impostato sul secondo folder.
    Viene richiamata da SwitchTab
    */
    var CurrentFolderConfig;
    var CurrentFolderConfigArray;

    if(document.getElementById(ElmCurrentFoldersConfig).value!=null && document.getElementById(ElmCurrentFoldersConfig).value!='')
    {
        CurrentFolderConfig=document.getElementById(ElmCurrentFoldersConfig).value;
        CurrentFolderConfigArray=CurrentFolderConfig.split("|");
        
        CurrentFolderConfigArray[pTab - 1] = pFolder;
        
        
        //Rebuild Array and store it ;
        var OutputString="";
        for(var x=0;x<CurrentFolderConfigArray.length;x++)
            OutputString+=CurrentFolderConfigArray[x] + "|";
        
        OutputString=OutputString.substring(0,OutputString.length-1);
        document.getElementById(ElmCurrentFoldersConfig).value=OutputString;
    }
};

function SwitchTab(pTabNumber,pFolderNumber)
{
    /*
    Switcha sul folder pFolderNumber del Tab pTabNumber, rendendo visibile la div ad esso associata
    e rendendo invisibili quelle degli altri folder dello stesso tab.
    */
    for(var x=1;x<=FolderNumber[pTabNumber];x++)    
    {
        document.getElementById("Tab"+pTabNumber+"Folder"+x).style.display="none";
        document.getElementById("HTab"+pTabNumber+"Folder"+x).className="TabsHeaderUnselected";
    }
    document.getElementById("Tab"+pTabNumber+"Folder"+pFolderNumber).style.display="block";
    document.getElementById("HTab"+pTabNumber+"Folder"+pFolderNumber).className="TabsHeaderSelected";

    StoreFolderForTab(pTabNumber,pFolderNumber);
    return;
};

function SelectTabForControl(C){
    if (!C) return;
    if (!C.parentNode ) return;
    var P = C.parentNode;
    var regex = new RegExp("^Tab([\\d+])Folder([\\d+])");
    var result = regex.exec(P.id);
    if (result == null) {
        if ($(P).hasClass("tab-pane")) {
            $("ul.nav.nav-pills, ul.nav.nav-tabs").each(function () {
                $(this).find("a[href=#" + P.id + "]").tab('show');
            });
            return
        }

        SelectTabForControl(P);
        return;
    }
    try {
        SwitchTab(result[1],result[2]);
    }
    catch (e){}

};


function ChkBox_MouseOver(pTCheckBoxID,pStateNumber)
{
    /*
    Evento MouseOver per il checkbox. 
    Ha solo il compito di sostituire l'immagine utilizzata per il checkbox
    al passaggio del puntatore del mouse
    */
    var el=document.getElementById(pTCheckBoxID);
    var im=document.getElementById(pTCheckBoxID+'_img');
    if(pStateNumber==3)
    {
        if (el.value==0) 
            im.src=UnCheckImgOver; 
        else 
        {
            if (el.value==1) 
                im.src=CheckImgOver;
            else 
                im.src=IndetImgOver;
        }
    }
    else
    {
        im.src=(el.value==1)?CheckImgOver:UnCheckImgOver;
    }
};

function ChkBox_MouseOut(pTCheckBoxID,pStateNumber)
{
    /*
    Evento MouseOut per il checkbox. 
    Ha solo il compito di sostituire l'immagine utilizzata per il checkbox
    quando il puntatore del mouse "lascia" il checkbox.
    */

    var el=document.getElementById(pTCheckBoxID); 
    var im=document.getElementById(pTCheckBoxID+'_img');

    if(pStateNumber==3)
    {
        if (el.value==0) 
            im.src=UnCheckImg;
        else 
        {
            if (el.value==1) 
                im.src=CheckImg; 
            else 
                im.src=IndetImg;
        }
    }
    else
    {
        im.src=(el.value==1)?CheckImg:UnCheckImg;
    }
};

function ChkBox_MouseClick(pTCheckBoxID,pStateNumber, pAllowOver)
{
    /*
    Gestisce l'evento click del pulsante del mouse per il checkbox.
    In particolare si occupa di cambiare l'immagine associata sulla
    base dello stato del checkbox(può anche avere 3 stati).
    Lo stato corrente viene memorizzato nel textbox pTCheckBoxID,
    l'immagine ha invece id pTCheckBoxID concatenato con la stringa
    '_img'.
    
    */
    var el=document.getElementById(pTCheckBoxID); 
    var im=document.getElementById(pTCheckBoxID+'_img');

    var lCheckImg;
    var lUnCheckImg;
    var lIndetImg;
    
    if(pAllowOver)
    {
        lCheckImg=CheckImgOver;
        lUnCheckImg=UnCheckImgOver;
        lIndetImg=IndetImgOver;
    }
    else
    {
        lCheckImg=CheckImg;
        lUnCheckImg=UnCheckImg;
        lIndetImg=IndetImg;
    }
    
    if(pStateNumber==3)
    {
        if (el.value==1) 
        { 
            el.value=2; 
            im.src=lIndetImg; 
        } 
        else
        {
            if (el.value==2) 
            { 
                el.value=0; 
                im.src=lUnCheckImg; 
            } else
            { 
                el.value=1; 
                im.src=lCheckImg; 
            }
        } 
    }
    else
    {
        if (el.value==1) 
        { 
            el.value=0; 
            im.src=lUnCheckImg; 
        } 
        else 
        { 
            el.value=1; 
            im.src=lCheckImg; 
        }
    }
};


var ShowClientMessage_disabled = new Array();


;

        




//////////////////////////////////////// MAINFUNCTIONS ////////////////////////////////////////////////
//////////////////////////////////////// MAINFUNCTIONS ////////////////////////////////////////////////
//////////////////////////////////////// MAINFUNCTIONS ////////////////////////////////////////////////
//////////////////////////////////////// MAINFUNCTIONS ////////////////////////////////////////////////
//////////////////////////////////////// MAINFUNCTIONS ////////////////////////////////////////////////
//////////////////////////////////////// MAINFUNCTIONS ////////////////////////////////////////////////
//////////////////////////////////////// MAINFUNCTIONS ////////////////////////////////////////////////
//////////////////////////////////////// MAINFUNCTIONS ////////////////////////////////////////////////
function formatAllGrids() {
    $("table.to_pgrid").pgrid({
        pgrid_footer: true,
        pgrid_count: true,
        pgrid_select: true,
        pgrid_multi_select: false,
        pgrid_paginate: true,
        //pgrid_page: 2,
        pgrid_perpage: 15,
        //pgrid_filtering: true,
        //pgrid_filter: '',
        //pgrid_hidden_cols: [2, 3],
        //pgrid_resize_cols: true,
        pgrid_sortable: false,
        //pgrid_sort_ord: 'asc',
        //pgrid_stripe_rows: false,
        pgrid_row_hover_effect: true,
        pgrid_view_height: 'auto',
        //pgrid_view_width: '800px',
        pgrid_resize: true
    }
             );

    $("table.pag_pgrid").pgrid({
        pgrid_footer: true,
        pgrid_count: true,
        pgrid_select: true,
        pgrid_multi_select: false,
        pgrid_paginate: true,
        pgrid_sort_col: false,
        pgrid_perpage: 20,
        pgrid_row_hover_effect: true,
        pgrid_view_height: 'auto',
        pgrid_resize: false
    });

    $("table.to_pgrid2").pgrid({
        pgrid_footer: false,
        pgrid_count: false,
        pgrid_select: true,
        pgrid_multi_select: false,
        pgrid_paginate: false,
        pgrid_sort_col: false,
        pgrid_row_hover_effect: false,
        pgrid_view_height: 'auto',
        pgrid_resize: false
    });

    $("table.std_pgrid").pgrid({
        pgrid_footer: false,
        pgrid_count: false,
        pgrid_select: true,
        pgrid_multi_select: false,
        pgrid_paginate: false,
        pgrid_row_hover_effect: false,
        pgrid_view_height: 'auto',
        pgrid_resize: false
    });

}

     $(        
         function () {
             //$("#_ctl0_CHP_PC_DIV").css({ opacity: .8 });

             if (MetaMasterUsingBootstrap) {
                 $("#_ctl0_CHP_PC_DIV :button").not(".btn-default").not(".btn-primary").not(".btn-warning").not(".btn-danger").not(".btn-warning").addClass("btn btn-info");
                 $("#_ctl0_Div_CHPList :button").not(".btn-default").not(".btn-primary").not(".btn-warning").not(".btn-danger").not(".btn-warning").addClass("btn btn-info");
                 $("button.masterbtn").addClass("btn btn-primary");
                 $("[data-btnmaincmd='mainsetsearch']").prepend('<span class="glyphicon glyphicon-search" aria-hidden="true"></span>');                     
                 $("[data-btnmaincmd='maindosearch']").prepend('<span class="glyphicon glyphicon-play" aria-hidden="true"></span>');
                 $("[data-btnmaincmd='maininsert']").prepend('<span class="glyphicon glyphicon-plus" aria-hidden="true"></span>');
                 $("[data-btnmaincmd='maininsertcopy']").prepend('<span class="glyphicon glyphicon-copy" aria-hidden="true"></span>');
                 $("[data-btnmaincmd='mainsave']").prepend('<span class="glyphicon glyphicon-floppy-disk" aria-hidden="true"></span>');
                 $("[data-btnmaincmd='mainselect']").prepend('<span class="glyphicon glyphicon-folder-open" aria-hidden="true"></span>');
                 $("[data-btnmaincmd='maindelete']").prepend('<span class="glyphicon glyphicon-trash" aria-hidden="true"></span>');
                 $("[data-btnmaincmd='mainclose']").prepend('<span class="glyphicon glyphicon-remove" aria-hidden="true"></span>');                 
                 $("[data-btnmaincmd='showlast']").prepend('<span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span>');

                 $("[data-gridcmd='delete']").prepend('<span class="glyphicon glyphicon-trash" aria-hidden="true"></span>').addClass("btn btn-danger");
                 $("[data-gridcmd='edit']").prepend('<span class="glyphicon glyphicon-edit" aria-hidden="true"></span>').addClass("btn btn-primary");
                 $("[data-gridcmd='insert']").prepend('<span class="glyphicon glyphicon-plus" aria-hidden="true"></span>').addClass("btn btn-primary");
                 $("[data-gridcmd='maininsertcopy']").prepend('<span class="glyphicon glyphicon-copy" aria-hidden="true"></span>').addClass("btn btn-primary");

                 $("button[data-usegliph]").each(function (index) {
                     $(this).addClass("btn btn-primary");
                     var mySpan = '<span class="glyphicon glyphicon-' + $(this).attr('data-usegliph') + '" aria-hidden="true"></span>';
                     $(this).prepend(mySpan);
                 });

                 $("[data-btnmaincmd='mainsetsearch']").attr("tabindex", "-1").attr("data-maincmd", "mainsetsearch").addClass("btn btn-primary");
                 $("[data-btnmaincmd='maindosearch']").attr("tabindex", "-1").attr("data-maincmd", "maindosearch").addClass("btn btn-primary");
                 $("[data-btnmaincmd='maininsert']").attr("tabindex", "-1").attr("data-maincmd", "maininsert").addClass("btn btn-primary");
                 $("[data-btnmaincmd='maininsertcopy']").attr("tabindex", "-1").attr("data-maincmd", "maininsertcopy").addClass("btn btn-primary");
                 $("[data-btnmaincmd='mainsave']").attr("tabindex", "-1").attr("data-maincmd", "mainsave").addClass("btn btn-primary");
                 $("[data-btnmaincmd='mainsave']").hover(function () { $(".lastfocused").blur(); $(this).focus(); });
                 $("[data-btnmaincmd='mainselect']").attr("tabindex", "-1").attr("data-maincmd", "mainselect").addClass("btn btn-primary");
                 $("[data-btnmaincmd='maindelete']").attr("tabindex", "-1").attr("data-maincmd", "maindelete").addClass("btn btn-danger");
                 $("[data-btnmaincmd='mainclose']").attr("tabindex", "-1").attr("data-maincmd", "mainclose").addClass("btn btn-primary");
                 $("[data-btnmaincmd='showlast']").attr("tabindex", "-1").attr("data-maincmd", "showlast").addClass("btn btn-info");

                 $('#_ctl0_CHP_PC_main-menu').smartmenus();
             }
             else {
                 $("[data-btnmaincmd='mainsetsearch']").button({ icons: { primary: 'ui-icon-search' } }).attr("tabindex", "-1").attr("data-maincmd", "mainsetsearch");
                 $("[data-btnmaincmd='maindosearch']").button({ icons: { primary: 'ui-icon-play' } }).attr("tabindex", "-1").attr("data-maincmd", "maindosearch");
                 $("[data-btnmaincmd='maininsert']").button({ icons: { primary: 'ui-icon-plus' } }).attr("tabindex", "-1").attr("data-maincmd", "maininsert");
                 $("[data-btnmaincmd='maininsertcopy']").button({ icons: { primary: 'ui-icon-copy' } }).attr("tabindex", "-1").attr("data-maincmd", "maininsertcopy");
                 $("[data-btnmaincmd='mainsave']").button({ icons: { primary: 'ui-icon-disk' } }).attr("tabindex", "-1").attr("data-maincmd", "mainsave");
                 $("[data-btnmaincmd='mainsave']").hover(function () { $(".lastfocused").blur(); $(this).focus(); });
                 $("[data-btnmaincmd='mainselect']").button({ icons: { primary: 'ui-icon-folder-open' } }).attr("tabindex", "-1").attr("data-maincmd", "mainselect");
                 $("[data-btnmaincmd='maindelete']").button({ icons: { primary: 'ui-icon-trash' } }).attr("tabindex", "-1").attr("data-maincmd", "maindelete");
                 $("[data-btnmaincmd='mainclose']").button({ icons: { primary: 'ui-icon-close' } }).attr("tabindex", "-1").attr("data-maincmd", "mainclose");
             }

             formatAllGrids();

             

             //$(".bottoniprincipali input[type=\"button\"]").button();
            

            $('.it-date-datepicker').datepicker({
                inputFormat: ["dd/mm/yyyy"],
                format: 'dd/mm/yyyy'
            });

            //$('.datepicker').datepicker({
            //    format: 'mm/dd/yyy',
            //    startDate: '-3d'
            //});
                          
             $("input[type='text'],textarea").hover(function() { savefocus(this); });
             $("input[type='select'],select").hover(function() { savefocus(this); });
             //$("input[type='text'],textarea, input[type='password']").focus(function() { Tent(this); });

             $("input[type='text'],textarea").focus(function() { savefocus(this); });
             $("input[type='select'],select").focus(function() { savefocus(this); });
             //$("input[type='text'],textarea, input[type='password']").focus(function() { Tent(this); });

             //$("input[type='text'],textarea, input[type='password']").blur(function() { Tlv(this); });

              
             $(".ui-button-text") .attr("tabindex", "-1");
             //$("#_ctl0_Div_CHPList").draggable();                                  

             $.fn.filterByData = function (prop, val) { return this.filter(function () { return $(this).data(prop) == val; }); };
             $.fn.filterByDataNotNull = function (prop) {
                 return this.filter(function () {
                     if ($(this).data(prop)) return true;
                     else return false;
                 });
             };
             
            
             // l'attributo cascadeid deve aggiungere all'evento change del controllo ctrl a cui è agganciata una chiamata allo script di nome cascade_+ il valore dell'attributo
             $(":text[data-cascadeid]").change(function () {
                 window["cascade_"+$(this).data("cascadeid")]();
             });

             // ltbtag = tipo;tag se impostato deve far si da collegare all'evento onchange del controllo l'azione GenLeaveTB(tipo,this,tag) dove this è il controllo
             $(":text[data-ltbtag]").change(GenLeaveNoTag);
             
             
             //se c'è enterdec = tag deve essere collegato l'OnFocus al metodo ExtEnterDecTextBox(this,tag) oltre a GenLeaveTB('Decimal',this,tag)
             $(":text[data-enterdec]").focus(GenEnterDec).change(GenLeaveNoTagDec);

             //se c'è enternum = tag deve essere collegato l'OnFocus al metodo ExtEnterNumTextBox(this,tag) oltre a GenLeaveTB('Double',this,tag)
             $(":text[data-enternum]").focus(GenEnterNum).change(GenLeaveNoTagNum);

             $(":text[data-change_customfun]").change(GenCustomFun);
             //chgpback deve generare sull'evento onchange controllo a cui è attaccata un postback con eventsource= il controllo da cui proviene 
             $(":text[data-chgpback]").change(GenPostBack);

             $(".stprev").focus(StPrv);

             $("[data-maincmd]").click(maindCmd);
             $("[data-cmd]").click(doCmd);
             //$("table .to_pgrid").on('click','td', highlightRow);

             $('table').on('click', highlightRow);

             $(':button[data-click]').on('click', GenClick);
             
             $("[data-gridpback]").click(grid_pback);
             hw_init();
         }
     );

     function highlightRow(e) {
         if (this.getAttribute("data-gridpback")) return;
          $(this).children('tr').removeClass("ui-pgrid-table-row-selected");
          $(e.target).closest('tr').addClass("ui-pgrid-table-row-selected");
      }
      
      function grid_pback(e) {
          if (!this.getAttribute("data-gridpback")) return;
         var gridName = this.getAttribute("data-gridpback");
         if (!gridName) return;
         var rowidx = $(e.target).closest('tr').data("idx");
         if (typeof (rowidx) == "undefined" || rowidx == null) return;
         e.preventDefault();
         __doPostBack(gridName, rowidx);
     }
     
      function maindCmd(e) {
          var cmd = $(e.currentTarget).data("maincmd");
          //alert("fired_0");
          e.preventDefault();
          __doPostBack('do_maincommand', cmd);
      }
      function doCmd(e) {
          var cmd = $(e.currentTarget).data("cmd");
          //alert("fired_1");
          e.preventDefault();
          __doPostBack('do_command', cmd);
      }

     function StPrv(e) {
         var pTextBox = e.target;
         /*
         Rientra nella gestione dell'elenco. Memorizza il valore precedente del textbox pTextBox in
         ElmPreviousValue (textbox nascosto - variabile globale istanziata a runtime) sulla base di
         ElmPreservePreviousValue
         */
         //alert('preserve vale:'+document.getElementById(ElmPreservePreviousValue).value);
         //$(pTextBox).data("previousvalue", pTextBox.value);
         if (!document.getElementById(ElmPreservePreviousValue)) return;

         var lPreservePreviousValue = (document.getElementById(ElmPreservePreviousValue).value == "S" ? true : false);
         if (!lPreservePreviousValue) {
             //alert('memorizzo:'+pTextBox.value);
             document.getElementById(ElmPreviousValue).value = pTextBox.value;
             return true;
         }
         else {
             document.getElementById(ElmPreservePreviousValue).value = 'N';
             return false;
         }
     };


     function GenCustomFun(e) {
         var fun = $(e.currentTarget).data("change_customfun");
         window[fun](e.currentTarget);
     }

     function GenClick(e) {
         //alert("fired_2");
         if (e) e.preventDefault();
         __doPostBack("do_maincommand", "btnclick." + $(e.currentTarget).data("click"), '');
     }
     function GenPostBack(e) {
         //alert("fired_3");
         if (e) e.preventDefault();
         __doPostBack($(e.currentTarget).data("chgpback"), '');
     }
     function GenLeaveNoTag(e) {
         var s = $(e.target).data("ltbtag");
         var firstdel = s.indexOf(";");
         var tipo = s.substring(0, firstdel);
         var tag = s.substring(firstdel + 1);
         GenLeaveTB(tipo, e.target, tag);
     };

     function GenLeaveNoTagDec(e) {
         var tag = $(e.target).data("enterdec");
         GenLeaveTB('Decimal', e.target, tag);
     };
     
     function GenLeaveNoTagNum(e) {
         var tag = $(e.target).data("enternum");
         GenLeaveTB('Double',e.target, tag);
     };

    function savefocus(pTextBox){
	if (pTextBox==null) return;
    $(".savefocus").val(pTextBox.id);
    };

    function GenEnterDec(e) {
        var tag = $(e.target).data("enterdec");
        ExtEnterDecTextBox(e.target, tag);
    };

    function GenEnterNum(e) {
        var tag = $(e.target).data("enternum");
        ExtEnterNumTextBox(e.target, tag);
    };

    
    // MasterPage Functions
   function centerDiv(div){
	var divname= "#"+div.id;
  	var DIVwidth = $(divname).outerWidth();	
	var DIVheight = $(divname).outerHeight();
	var SCREENwidth = $(window).width();
	var SCREENheight = $(window).height();
	
	var SCREENscrolltop = $(window).scrollTop();
	var SCREENscrollleft = $(window).scrollLeft();
    //$(div).hide();
    
    
	$(div).css({"position":"absolute"});
	$(divname).css({"top":(SCREENheight-DIVheight)/2+SCREENscrolltop+"px"});
	$(div).css({"margin-left":"auto"});
	$(div).css({"margin-right":"auto"});
	//$(divname).css({"left":(SCREENwidth-DIVwidth)/2+SCREENscrollleft+"px"});
	$(divname).css({"z-index":"1000"});
	//$(div).show();
 
    };
    
    
        // Aggiunge un eventlistener all'evento keydown o all'onkeydown
        // dipende dal browser
        if (document.addEventListener) {
            document.addEventListener('keydown', disableF5Key, true);
        }
        else if (document.attachEvent) {
            document.attachEvent('onkeydown', disableF5Key);
        }
        else {
            document.onkeydown = disableF5Key;
        } 
        // impedisce che si possa utilizzare l'history del browser (backspace o "Indietro")    
        window.history.forward(1);
        if (document.getElementById("_ctl0_txt_ClientConFirmed.ClientID"))
        {
            // Pone il valore di txtClientConfirmed ad "N"
            document.getElementById("_ctl0_txt_ClientConFirmed.ClientID").value="N";
        };
        
        
        // Funzione legata all'onkeydown (o al keydown)
        // intercetta in due maniere diverse (a seconda del browser utilizzato)
        // la pressione del tasto F5

        function disableF5Key(evt) {
            var event;
            if (evt) {
                event = evt;
            } else if (window.event) {
                event = window.event;
            }
            if (event) {
                var keyCode = event.keyCode ? event.keyCode : event.charCode;
                var Browser = navigator.appName.toLowerCase();
                if (keyCode == 116) {
                    if (event.preventDefault) {
                        event.preventDefault();
                        event.stopPropagation();
                    }
                    event.cancelBubble = true;
                    if (Browser == "microsoft internet explorer")
                        event.keyCode = 0;
                    else
                        event.charCode = 0;
                    if (Browser == "opera") event.lastKey = null;
                    return false;
                }
            }
        };

       
        var issubmitting = false;

        function ignoreinput() {
            return false;
        }

        function DisablePageOnSubmit() {
            //window.attachEvent("onkeydown", ignoreinput);
            //window.attachEvent("onclick", ignoreinput);
            if (issubmitting) {
                //alert("Please wait..");
                return false;
            }

            var jsMsg = $("<div id='div_wait_for_submit'></div>");
            $("#"+ElmContent).append(jsMsg);
            var showmsg_optbts = [];
            var showmsg_opts = {
                resizable: false,
                modal: true,
                autoOpen: true,
                minHeight: '0px',
                width: '200px',
                dialogClass: "no-close",
                closeOnEscape: false,
                buttons: showmsg_optbts,
                title: "Attendere prego"
            };
            $(jsMsg).dialog(showmsg_opts);
            $('button.ui-dialog-titlebar-close').hide();
            issubmitting = true;
            return false;
        }
    

        (function ($) {
            'use strict';

            /**
             * Focusses the next :focusable element. Elements with tabindex=-1 are focusable, but not tabable.
             * Does not take into account that the taborder might be different as the :tabbable elements order
             * (which happens when using tabindexes which are greater than 0).
             */
            $.focusNext = function (curr) {
                selectNextTabbableOrFocusable(':focusable', curr);
            };

            /**
             * Focusses the previous :focusable element. Elements with tabindex=-1 are focusable, but not tabable.
             * Does not take into account that the taborder might be different as the :tabbable elements order
             * (which happens when using tabindexes which are greater than 0).
             */
            $.focusPrev = function (curr) {
                selectPrevTabbableOrFocusable(':focusable', curr);
            };

            /**
             * Focusses the next :tabable element.
             * Does not take into account that the taborder might be different as the :tabbable elements order
             * (which happens when using tabindexes which are greater than 0).
             */
            $.tabNext = function (curr) {
                selectNextTabbableOrFocusable(':tabbable', curr);
            };

            /**
             * Focusses the previous :tabbable element
             * Does not take into account that the taborder might be different as the :tabbable elements order
             * (which happens when using tabindexes which are greater than 0).
             */
            $.tabPrev = function (curr) {
                selectPrevTabbableOrFocusable(':tabbable', curr);
            };

            function selectNextTabbableOrFocusable(selector, curr) {
                var selectables = $(selector);
                var current = curr | $(':focus');
                var nextIndex = 0;
                if (current.length === 1) {
                    var currentIndex = selectables.index(current);
                    if (currentIndex + 1 < selectables.length) {
                        nextIndex = currentIndex + 1;
                    }
                }

                selectables.eq(nextIndex).focus();
            }

            function selectPrevTabbableOrFocusable(selector, curr) {
                var selectables = $(selector);
                var current = curr | $(':focus');
                var prevIndex = selectables.length - 1;
                if (current.length === 1) {
                    var currentIndex = selectables.index(current);
                    if (currentIndex > 0) {
                        prevIndex = currentIndex - 1;
                    }
                }

                selectables.eq(prevIndex).focus();
            }

            /**
             * :focusable and :tabbable, both taken from jQuery UI Core
             */
            $.extend($.expr[':'], {
                data: $.expr.createPseudo ?
                        $.expr.createPseudo(function (dataName) {
                            return function (elem) {
                                return !!$.data(elem, dataName);
                            };
                        }) :
                        // support: jQuery <1.8
                        function (elem, i, match) {
                            return !!$.data(elem, match[3]);
                        },

                focusable: function (element) {
                    return focusable(element, !isNaN($.attr(element, 'tabindex')));
                },

                tabbable: function (element) {
                    var tabIndex = $.attr(element, 'tabindex'),
                            isTabIndexNaN = isNaN(tabIndex);
                    return (isTabIndexNaN || tabIndex >= 0) && focusable(element, !isTabIndexNaN);
                }
            });

            /**
             * focussable function, taken from jQuery UI Core
             * @param element
             * @returns {*}
             */
            function focusable(element) {
                var map, mapName, img,
                        nodeName = element.nodeName.toLowerCase(),
                        isTabIndexNotNaN = !isNaN($.attr(element, 'tabindex'));
                if ('area' === nodeName) {
                    map = element.parentNode;
                    mapName = map.name;
                    if (!element.href || !mapName || map.nodeName.toLowerCase() !== 'map') {
                        return false;
                    }
                    img = $('img[usemap=#' + mapName + ']')[0];
                    return !!img && visible(img);
                }
                return (/input|select|textarea|button|object/.test(nodeName) ?
                        !element.disabled :
                        'a' === nodeName ?
                                element.href || isTabIndexNotNaN :
                                isTabIndexNotNaN) &&
                        // the element and all of its ancestors must be visible
                        visible(element);

                function visible(element) {
                    return $.expr.filters.visible(element) && !$(element).parents().addBack().filter(function () {
                        return $.css(this, 'visibility') === 'hidden';
                    }).length;
                }
            }
        })(jQuery);



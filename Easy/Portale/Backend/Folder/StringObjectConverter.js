
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


function GetObjectFromString(pType, pString, pTag) {
    /*
    GetObjectFromString data una stringa “pString”, una definizione di tipo “pType” 
    ed un tag “pTag”, ritorna un oggetto che consta di due membri: 
    -	TypeName che contiene uno dei seguenti valori: 
        “String”, “Char”, “Double”, “Single”, “Decimal”, “DateTime”, “Byte”, “Int16”, “Int32”;
    -	Obj che contiene l’oggetto del tipo appropriato (String, Float, Int, Date) ricavato da pString. 
    */

    if (pType == null)
        pString = "";
    var FieldType;
    FieldType = GetFieldLower(pTag, 0);
    if (FieldType == "")
        FieldType = null;
    var S;
    S = pString;

    var RetObj = new Object();

    try {
        switch (pType) {
            case "String":
                RetObj.TypeName = "String";
                RetObj.Obj = S;
                return RetObj;
                break;

            case "Char":
                {
                    // the ToChar() method does not exists. Could it be better to return just the first char?
                    RetObj.TypeName = "Char";
                    RetObj.Obj = S.charAt(0);
                    return RetObj;
                }
                break;

                // Double, Single and Decimal are always treated as Float
            case "Double":
                {
                    RetObj.TypeName = "Double";
                    var D1;
                    D1 = 0;
                    if (S == "") return null;
                    if (FieldType == null) {
                        S = ConvertToJSNumber(S, GetNumberStyles(FieldType));
                        D1 = parseFloat(S);
                        if (isNaN(D1)) return null;
                        RetObj.Obj = D1;
                        return RetObj;
                    }
                    if (IsStandardNumericFormatStyle(FieldType)) {
                        var StdDbl;
                        //Double.Parse(S, GetNumberStyles(FieldType),NumberFormatInfo.CurrentInfo); -- Implement GetNumberStyles??
                        S = ConvertToJSNumber(S, GetNumberStyles(FieldType));
                        StdDbl = parseFloat(S);
                        if (isNaN(StdDbl)) return null;
                        RetObj.Obj = StdDbl;
                        return RetObj;
                    }
                    if (FieldType == "fixed") {
                        var sdec = GetFieldLower(pTag, 1);
                        var prefix = GetFieldLower(pTag, 2);
                        if (prefix == null)
                            prefix = "";
                        var suffix = GetFieldLower(pTag, 3);
                        if (suffix == null)
                            suffix = "";
                        if (prefix != "")
                            S = S.replace(prefix, "");
                        if (suffix != "")
                            S = S.replace(suffix, "");
                        S = ConvertToJSNumber(S, GetNumberStyles(FieldType));
                        var dec;
                        dec = parseInt(sdec);
                        var sscale;
                        sscale = GetFieldLower(pTag, 4);
                        if (sscale == "")
                            sscale = null;
                        D1 = parseFloat(S);
                        if (isNaN(D1)) return null;
                        D1 = D1.toFixed(dec);

                        var scale = 0;
                        if (sscale != null)
                            scale = parseFloat(sscale);
                        if (isNaN(scale)) return null;
                        if (scale != 0) D1 = D1 / scale;

                        RetObj.Obj = D1;
                        return RetObj;
                    }
                    return null;
                }
                break;

            case "Single":
                {
                    var D4;

                    RetObj.TypeName = "Single";
                    if (S == "") return null;
                    if (FieldType == null) {
                        S = ConvertToJSNumber(S, GetNumberStyles(FieldType));
                        D4 = parseFloat(S);
                        if (isNaN(D4)) return null;
                        RetObj.Obj = D4;
                        return RetObj;
                    }
                    if (IsStandardNumericFormatStyle(FieldType)) {
                        var StdSngl;
                        S = ConvertToJSNumber(S);
                        StdSngl = parseFloat(S);
                        //Single StdSngl= Single.Parse(S, GetNumberStyles(FieldType),NumberFormatInfo.CurrentInfo); -- Implement GetNumberStyles
                        RetObj.Obj = StdSngl;
                        return RetObj;
                    }
                    if (FieldType == "fixed") {
                        var sdec = GetFieldLower(pTag, 1);
                        var prefix = GetFieldLower(pTag, 2);
                        if (prefix == null)
                            prefix = "";
                        var suffix = GetFieldLower(pTag, 3);
                        if (suffix == null) suffix = "";
                        if (prefix != "")
                            S = S.replace(prefix, "");
                        if (suffix != "")
                            S = S.replace(suffix, "");
                        var dec;
                        dec = parseInt(sdec);
                        var sscale;
                        sscale = GetFieldLower(pTag, 4);
                        if (sscale == "")
                            sscale = null;
                        S = ConvertToJSNumber(S, GetNumberStyles(FieldType));
                        D4 = parseFloat(S);
                        if (isNaN(D4)) return null;
                        D4 = D4.toFixed(dec);
                        var scale = 0;
                        if (sscale != null)
                            scale = parseFloat(sscale);
                        if (isNaN(scale)) return null;
                        if (scale != 0)
                            D4 = D4 / scale;
                        RetObj.Obj = D4;
                        return RetObj;
                    }
                    return null;
                }
                break;

            case "Decimal":
                {
                    RetObj.TypeName = "Decimal";
                    if (S == "")
                        return null;
                    if (FieldType == null) {
                        var D2;
                        D2 = 0;
                        // D2 = Decimal.Parse(S, System.Globalization.NumberStyles.Currency, NumberFormatInfo.CurrentInfo);                
                        S = ConvertToJSNumber(S, GetNumberStyles(FieldType));
                        D2 = parseFloat(S);
                        if (isNaN(D2)) return null;
                        D2 = D2.toFixed(1);
                        RetObj.Obj = D2;
                        return RetObj;
                    }
                    if (IsStandardNumericFormatStyle(FieldType)) {
                        //Decimal StdDec= Decimal.Parse(S, GetNumberStyles(FieldType), NumberFormatInfo.CurrentInfo);
                        var StdDec;
                        S = ConvertToJSNumber(S, GetNumberStyles(FieldType));
                        StdDec = parseFloat(S);
                        if (isNaN(StdDec)) return null;
                        StdDec = StdDec.toFixed(2);
                        RetObj.Obj = StdDec;
                        return RetObj;
                    }

                    if (FieldType == "fixed") {
                        var sdec = GetFieldLower(pTag, 1);
                        var prefix = GetFieldLower(pTag, 2);
                        if (prefix == null)
                            prefix = "";
                        var suffix = GetFieldLower(pTag, 3);
                        if (suffix == null) suffix = "";
                        if (prefix != "")
                            S = S.replace(prefix, "");
                        if (suffix != "")
                            S = S.replace(suffix, "");
                        var dec;
                        dec = parseInt(sdec);
                        var sscale;
                        sscale = GetFieldLower(pTag, 4);
                        if (sscale == "")
                            sscale = null;
                        S = ConvertToJSNumber(S, GetNumberStyles(FieldType));
                        D2 = parseFloat(S);
                        if (isNaN(D2)) return null;
                        D2 = D2.toFixed(dec);
                        var scale = 0;
                        if (sscale != null)
                            scale = parseFloat(sscale);
                        if (isNaN(scale)) return null;
                        if (scale != 0)
                            D2 = D2 / scale;
                        RetObj.Obj = D2;
                        return RetObj;
                    }

                }
                break;

                //DateTime right now just implements the "d" format
            case "DateTime":
                {
                    RetObj.TypeName = "DateTime";
                    if (S == "")
                        return null;
                    // Convert S into a Date
                    var TT;

                    // Not sure if it has to work this way... maybe the If can be removed...
                    if (IsStandardDateFormatStyle(FieldType)) {
                        //TT = DateTime.Parse(S);
                        TT = ConvertDateStringToDate(S, FieldType);
                        RetObj.Obj = TT;
                        return RetObj;
                    }
                    //TT= Convert.ToDateTime(S);
                    TT = ConvertDateStringToDate(S, "d");
                    RetObj.Obj = TT;
                    return RetObj;
                }
                break;

                //The following formats wi11 always return an int datatype...
            case "Byte":
                {
                    RetObj.TypeName = "Byte";
                    if (S == "")
                        return null;
                    var I11;
                    I11 = parseInt(S);
                    if (isNaN(I11)) return null;
                    if (FieldType == null) {
                        RetObj.Obj = I11;
                        return RetObj;
                    }

                    if (IsStandardNumericFormatStyle(FieldType)) {
                        // forse questo pezzo qui non servirà...
                        I11 = parseInt(S);
                        if (isNaN(I11)) return null;
                        //I11 = Byte.Parse(S, System.Globalization.NumberStyles.Currency, NumberFormatInfo.CurrentInfo);
                        RetObj.Obj = I11;
                        return RetObj;
                    }
                    return I11;
                }
                break;

            case "Int16":
                {
                    RetObj.TypeName = "Int16";
                    if (S == "")
                        return null;
                    var I1;
                    I1 = parseInt(S);
                    if (isNaN(I1)) return null;
                    if (FieldType == null) {
                        RetObj.Obj = I1;
                        return RetObj;
                    }
                    if (IsStandardNumericFormatStyle(FieldType)) {
                        // neanche questo pezzo servirà forse...
                        // I1 = Int16.Parse(S, System.Globalization.NumberStyles.Currency, NumberFormatInfo.CurrentInfo);                

                        I1 = parseInt(S);
                        if (isNaN(I1)) return null;
                        RetObj.Obj = I1;
                        return RetObj;
                    }
                    if (FieldType == "year") {
                        if (I1 >= 100) {
                            RetObj.Obj = I1;
                            return RetObj;
                        }
                        var lDate = new Date();
                        var Year;

                        //Year=lDate.getYear();
                        Year = myGetYear(lDate);

                        var aa;
                        aa = (Year % 100);

                        var CC;
                        CC = (Year - aa);

                        I1 = (I1 + CC);
                        if (aa > 50) I1 = (I1 + 100);
                        RetObj.Obj = I1;
                        return RetObj;
                    }
                    return null;
                }
                break;

            case "Int32":
                {
                    RetObj.TypeName = "Int32";
                    if (S == "")
                        return null;

                    var I2;
                    I2 = parseInt(S);
                    if (FieldType == null) {
                        RetObj.Obj = I2
                        return RetObj;
                    }
                    if (IsStandardNumericFormatStyle(FieldType)) {
                        //I2 = Int32.Parse(S, System.Globalization.NumberStyles.Currency, NumberFormatInfo.CurrentInfo);
                        I2 = parseInt(S);
                        if (isNaN(I2)) return null;
                        RetObj.Obj = I2;
                        return RetObj;
                    }
                    if (FieldType == "year") {
                        if (I2 >= 100) {
                            RetObj.Obj = I2;
                            return RetObj;
                        }
                        var lDate = new Date();
                        var Year;

                        //Year=lDate.getYear();
                        Year = myGetYear(lDate);

                        var aa;
                        aa = (Year % 100);

                        var CC;
                        CC = (Year - aa);

                        I2 = (I2 + CC);
                        if (aa > 50) I2 = (I2 + 100);
                        RetObj.Obj = I2;
                        return RetObj;
                    }
                    return null;

                }
                break;

            default:
                RetObj.Obj = "'" + S + "'";
                return RetObj;
        }

    }
    catch (e) {
        alert("Error converting " + S + " into " + pType);
    }
}





function StringValue(pObject, pTag, pType) {
    /*
    StringValue è la funzione duale di GetObjectFromString. A partire da pObject, 
    fornisce in output una stringa formattata secondo pTag e pType.    
    */

    if (pObject == null) return "";
    var RetString;
    localObject = pObject.Obj;
    if (localObject == null) return "";

    if (pType == "DateTime") {
        var FieldType = GetFieldLower(pTag, 0);
        if (IsStandardDateFormatStyle(FieldType)) {
            // in questo caso lo dovrebbe riportare nel formato "g" (da implementare)
            RetString = ConvertDateToDateString(localObject, FieldType);
            return RetString;
        }
        RetString = ConvertDateToDateString(localObject, "d");
        return RetString;
    }
    else {
        var FieldType = GetFieldLower(pTag, 0);
        var D;
        if (pType == "Decimal" || pType == "Single" || pType == "Double") {
            if (FieldType == null) {
                return ConvertToNumberString(localObject, 2, GetNumberStyles(FieldType));
            }
            if (IsStandardNumericFormatStyle(FieldType)) {
                return ConvertToNumberString(localObject, 2, GetNumberStyles(FieldType));
            }


            if (FieldType == "fixed") {
                D = parseFloat(localObject);
                var sdec = GetFieldLower(pTag, 1);
                var prefix = GetFieldLower(pTag, 2);

                if (prefix == null) prefix = "";
                var suffix = GetFieldLower(pTag, 3);
                if (suffix == null) suffix = "";

                var dec = parseInt(sdec);

                var sscale = GetFieldLower(pTag, 4);
                if (sscale == null) sscale = 0;
                var scale;
                if (sscale != null)
                    scale = parseFloat(sscale);
                if (scale != 0 && !isNaN(scale)) D = D * scale;
                var news = ConvertToNumberString(D, dec, GetNumberStyles(FieldType));

                if (prefix != "") news = prefix + " " + news;
                if (suffix != "") news = news + " " + suffix;

                return news;
            }
        }

    }
    return localObject.toString();
}








function GetFieldLower(pTag, pTagNumber) {
    /*
    Ritorna l’elemento di posto pTagNumber (
    l’ultimo elemento se pTagNumber > lunghezza del tag) 
    presente in pTag e lo converte tutto in minuscole.
    */

    var TagArray;
    if (pTag == null || pTag == "")
        return null;
    TagArray = pTag.split(".");
    if (pTagNumber > TagArray.length)
        return TagArray[TagArray.length].toLowerCase();
    return TagArray[pTagNumber].toLowerCase();
}









function IsStandardDateFormatStyle(fmt) {
    /*
    Ritorna true se il formato data fmt è standard. False altrimenti.    
    */
    switch (fmt) {
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
}










function ConvertDateToDateString(pObject, pStdDateFormat) {
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

    if (pObject == null)
        return null;

    TmpDate = pObject;
    //Year=TmpDate.getYear();
    Year = myGetYear(TmpDate);
    Month = TmpDate.getMonth() + 1;
    Day = TmpDate.getDate();
    switch (pStdDateFormat) {
        case "d":
            {
                // dd/mm/yyyy
                //Pad Zeroes to the left of "Day" and "Month" (if necessary)
                StrDay = Day.toString();
                if (StrDay.length == 1)
                    StrDay = "0" + StrDay;
                StrMonth = Month.toString();
                if (StrMonth.length == 1)
                    StrMonth = "0" + StrMonth;
                StrYear = Year.toString();
                RetDateString = StrDay + "/" + StrMonth + "/" + StrYear;
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
                Hours = TmpDate.getHours();
                Minutes = TmpDate.getMinutes();
                //			Seconds=TmpDate.getSeconds();

                StrDay = Day.toString();
                if (StrDay.length == 1)
                    StrDay = "0" + StrDay;
                StrMonth = Month.toString();
                if (StrMonth.length == 1)
                    StrMonth = "0" + StrMonth;
                StrYear = Year.toString();
                StrHours = Hours.toString();
                //if (StrHours.length==1)
                //	StrHours = "0" + StrHours;
                StrMinutes = Minutes.toString();
                if (StrMinutes.length == 1)
                    StrMinutes = "0" + StrMinutes;
                //			StrSeconds=Seconds.toString();
                //			if (StrSeconds.length==1)
                //				StrSeconds = "0" + StrSeconds;

                RetDateString = StrDay + "/" + StrMonth + "/" + StrYear + " " + StrHours + "." + StrMinutes;
                return RetDateString;
            }
    }
}












function ConvertToNumberString(pNumber, pPrecision, pNumberStyle) {
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
    var CurrSymbol = "";

    // Convert the input number into a float to obtain the desired precision
    // (maybe this passage is useless)
    if (pNumber == null) return null;
    if (pNumber == "") pNumber = "0";
    pFloat = parseFloat(pNumber);

    if (parseInt(pPrecision) > 0)
        pFloat = pFloat.toFixed(parseInt(pPrecision));
    else
        pFloat = pFloat.toFixed(0);

    pNumber = pFloat.toString();

    if (pNumber.indexOf("-") != -1) {
        HasNegativeSign = true;
        pNumber = pNumber.replace("-", "");
    }
    if (pNumber.indexOf(".") != -1) {
        pArray = pNumber.split(".");

        IntPart = pArray[0];
        DecimalPart = pArray[1];

        DecSeparator = NumberDecimalSeparator;

    }
    else {
        IntPart = pNumber;
        DecSeparator = "";
        DecimalPart = "";
    }

    // Parse Decimal Part and put NumberGroupSeparators
    if (IntPart.length > 3) {

        var Counter;
        var DestinationString;

        Counter = 1;
        DestinationString = "";
        for (var i = IntPart.length - 1; i >= 0 ; i--) {
            if ((Counter % 3) == 0 && (i != 0))
                DestinationString = NumberGroupSeparator + IntPart.charAt(i) + DestinationString;
            else
                DestinationString = IntPart.charAt(i) + DestinationString;
            Counter++;
        }
        IntPart = DestinationString;
    }


    if (pNumberStyle == "Currency")
        CurrSymbol = CurrencySymbol + " ";

    if (HasNegativeSign)
        return "-" + CurrSymbol + IntPart + DecSeparator + DecimalPart;
    else
        return CurrSymbol + IntPart + DecSeparator + DecimalPart;
}










function IsStandardNumericFormatStyle(fmt) {
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
}









function GetNumberStyles(fmt) {
    /*
    Ritorna una stringa contenente il numberstyle appropriato per il formato numerico fmt.    
    */
    switch (fmt) {
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
}

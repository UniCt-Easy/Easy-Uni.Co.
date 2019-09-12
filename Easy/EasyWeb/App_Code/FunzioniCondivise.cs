/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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


ï»¿using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;


namespace EasyWebReport
{
    /// <summary>
    /// Descrizione di riepilogo per FunzioniCondivise
    /// </summary>
    /// 
    public class FunzioniCondivise
    {
        public FunzioniCondivise()
        {
            
        }
        public static decimal RoundDecimal6(decimal valuta)
        {
            decimal truncated = Decimal.Truncate(valuta * 10000000);
            if (truncated > 0)
            {
                if ((truncated % 10) >= 5) truncated += 5;
            }
            else
            {
                if (((-truncated) % 10) >= 5) truncated -= 5;
            }
            truncated = truncated / 10;
            truncated = Decimal.Truncate(truncated);
            return truncated / 1000000;
            //			SqlDecimal SQLV = new SqlDecimal(valuta);
            //			return SqlDecimal.Round(SQLV,NCifreDecimaliPerRisultatiValuta).Value;
        }

    }
    //Fine Classe


    

}
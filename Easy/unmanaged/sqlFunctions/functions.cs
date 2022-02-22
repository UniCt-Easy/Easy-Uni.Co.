
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


using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


public class SqlFun{
     

     [SqlFunction]
     // Aggiornamento a Data: 20/03/2017
     // 
     // Attenzione! La DLL derivata da questo progetto viene utilizzata nella stored procedure exp_dichiarazione_mancata_adesione_consip. 
     // E' necessario registrare l'assembly su server SQL e abilitare  l'esecuzione del codice clr di .NET Framework.
     // Per i dettagli della implementazione vedi task 10534
    public static SqlString estrai_valore_token(SqlString template, SqlString S, SqlString token){
        Dictionary<string, string> dict = decodifica(template.ToString(), S.ToString());
        return dict.ContainsKey(token.ToString()) ? new SqlString(dict[token.ToString()]) : null;
     }

    static Dictionary<string, string> decodifica(string template, string s) {
        List<string> l = calcola(template);
        Dictionary<string, string> res = new Dictionary<string, string>();
        Regex r = new Regex(calcolaRegExp(template));
        Match m = r.Match(s);
        for (int i = 1; i < m.Groups.Count; i++) {
            res[l[i - 1]] = m.Groups[i].Value;
        }

        return res;
    }

    static List<string> calcola(string s) {
        List<string> l = new List<string>();
        int start = 0;
        int index = s.IndexOf("%<", start);
        while (index > 0) {
            int closing = s.IndexOf(">%", index + 2);
            if (closing < 0) break;
            l.Add(s.Substring(index + 2, closing - (index + 2)));
            start = index + 2;
            index = s.IndexOf("%<", start);
        }
        return l;
    }

    static string calcolaRegExp(string template){
         string R = "";
         int start = 0;
         int index = template.IndexOf("%<", start);
         int lastPos = 0;
         while (index > 0)
         {
             if (lastPos != index)
             {
                 if (lastPos == 0)
                 {
                     //R = "^";
                 }
                 string before = template.Substring(lastPos, index - lastPos);
                 R += Regex.Escape(before);
             }
             int closing = template.IndexOf(">%", index + 2);
             if (closing < 0) break;
             R += @"([\w\W]*)";
             start = closing + 2;
             lastPos = start;
             index = template.IndexOf("%<", start);
         }
         if (lastPos < template.Length)
         {
             R += Regex.Escape(template.Substring(lastPos));
         }
         return R;
     }

   

};

		

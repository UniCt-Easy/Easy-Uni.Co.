
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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

namespace Creport.Report.Rdl {
    /// <summary>
    /// INUTILE IN QUANTO VANNO BENE I FORMAT .NET
    /// </summary>
    public static class Format {

        public static String Default { get { return "Default"; } }
        /// <summary>
        /// 31/01/2000
        /// </summary>
        public static String Data { get { return "d"; } }
        /// <summary>
        /// lunedì 31 gennaio 2000
        /// </summary>
        public static String Data1 { get { return "D"; } }
        /// <summary>
        /// lunedì 31 gennaio 2000 13:30
        /// </summary>
        public static String Data2 { get { return "f"; } }
        /// <summary>
        /// 31/01/2000 13:30
        /// </summary>
        public static String Data3 { get { return "g"; } }
        public static String Ora { get { return "t"; } }
        public static String Scientifico { get { return "E2"; } }

        public static String Numeric { get { return "n"; } }


        /// <summary>
        /// "'€'0.00;('€'0.00)"
        /// </summary>
        public static String Valuta { get { return "'€'0.00;('€'0.00)"; } }
        /// <summary>
        /// "'€'0.00"
        /// </summary>
        public static String Valuta2 { get { return "'€'0.00"; } }
        /// <summary>
        /// "'€'0.00;'€'-0.00"
        /// </summary>
        public static String Valuta3 { get { return "'€'0.00;'€'-0.00"; } }
        /// <summary>
        /// "'€'0.00;'€'0.00-"
        /// </summary>
        public static String Valuta4 { get { return "'€'0.00;'€'0.00-"; } }
        /// <summary>
        /// '€'#,0.00;('€'#,0.00)
        /// </summary>
        public static String Valuta5 { get { return "'€'#,0.00;('€'#,0.00)"; } }
        /// <summary>
        /// '€'#,0.00
        /// </summary>
        public static String Valuta6 { get { return "'€'#,0.00"; } }
        /// <summary>
        /// '€'#,0.00;-'€'#,0.00;'' mostra gli zeri come blank
        /// </summary>
        public static String Valuta7 { get { return "'€'#,0.00;-'€'#,0.00;''"; } }
        /// <summary>
        /// '€'#,0.00;-'€'#,0.00;'-' mostra gli zeri come -
        /// </summary>
        public static String Valuta8 { get { return "'€'#,0.00;-'€'#,0.00;'-'"; } }
        /// <summary>
        /// '€'#,0.X;-'€'#,0.X; mostra zero come Y 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static String ValutaCustom(int precisione,string zero) {
            {
                string nzeri = "";
                for (int i = 0; i < precisione; i++) {
                    nzeri = nzeri + "0";
                }
                return "'€'#,0."+ nzeri + ";-'€'#,0."+ nzeri + ";'"+zero+"'";
            }
        }


        public static String Percentuale { get { return "0.00%"; } }

    }
}

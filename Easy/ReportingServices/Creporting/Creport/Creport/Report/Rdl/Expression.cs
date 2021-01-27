
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


namespace Creport.Report.Rdl {
    public static class Expression {
        public static string FieldsValue(string field,bool subtotal) {

            string fieldsvalue;

            if (subtotal) { fieldsvalue = "SUM(Fields!" + field + ".Value)"; }
            else { fieldsvalue = "Fields!" + field + ".Value"; }

            return fieldsvalue;
        }

        /// <summary>
        /// Aggiunge valori con operando
        /// </summary>
        /// <param name="field"></param>
        /// <param name="operand"></param>
        /// <param name="subtotal"></param>
        /// <returns></returns>
        public static string FieldsValue(string[] field, string operand, bool subtotal) {

            string fieldsvalue="";
            foreach (var item in field) {

                if (item != field[0]) { fieldsvalue += operand; }

                if (subtotal) { fieldsvalue += "SUM(Fields!" + item + ".Value)"; }
                else { fieldsvalue += "Fields!" + item + ".Value"; }
            }

            return fieldsvalue;
        }


        /// <summary>
        /// Converte la stringa in stringa XML per il report
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ConvertInReportString(this string input) {
            return ('"')+input+('"');
        }

        public static string ReplaceSingleQuoteWithDoubleQuote(this string input) {
            return input.Replace('\'', '\"');
        }
    }
}

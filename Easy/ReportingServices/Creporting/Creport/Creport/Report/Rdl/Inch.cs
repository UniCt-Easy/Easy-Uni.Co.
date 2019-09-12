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

ï»¿using System.Globalization;

namespace Creport.Report.Rdl {
    public class Inch {
        private const double HundredthOfInches = 0.01;
        private const string Unit = "in";

        public Inch(double value) {
            this.Value = value;
        }

        public double Value { get; private set; }

        public static Inch operator +(Inch i1, Inch i2) {
            return new Inch(i1.Value + i2.Value);
        }

        public static Inch operator -(Inch i1, Inch i2) {
            return new Inch(i1.Value - i2.Value);
        }

        public static Inch operator *(Inch i1, double d) {
            return new Inch(i1.Value * d);
        }

        public static Inch operator *(double d, Inch i2) {
            return new Inch(i2.Value * d);
        }

        public static Inch operator /(Inch i1, double d) {
            return new Inch(i1.Value / d);
        }

        public static explicit operator Inch(string s) {
            return new Inch(double.Parse(s.Replace(Unit, string.Empty)));
        }

        public static Inch CentiInchToInch(int centiInch) {
            return new Inch(centiInch * HundredthOfInches);
        }

        public override string ToString() {
            return this.Value.ToString("0.###########", new CultureInfo("en-GB")) + Unit;
            //senza il new CultureInfo("en-GB") non prede bene le dimensioni e crea oggetti di dimensioni enormi
        }
    }
}
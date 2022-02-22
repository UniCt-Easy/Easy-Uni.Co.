
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


using metaeasylibrary;
using System;
using System.Collections;
using q = metadatalibrary.MetaExpression;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Backend.CommonBackend {
	public static class AuthUtils {
		public static Hashtable getUsr(EasySecurity sec) {
			Hashtable usr = new Hashtable();
			// popolo user
			string[] usrkeys = sec.EnumUsrKeys();
			foreach (object o in usrkeys) {
				object k = sec.GetUsr(o.ToString());
				if (k == null) continue;

				// sono filtri li trasformo in MetaExpression
				// aggiungo una var fe_cond_sor0x ad uso del frontend
				if (o.ToString().StartsWith("cond_sor0")) {
					usr["fe_" + o.ToString()] = getCondSorFrontend(o, k);
					usr[o.ToString()] = getCondSor(o, k);
				}
				else {
					usr[o.ToString()] = k;
				}
			}

			return usr;
		}

		public static Hashtable getSys(EasySecurity sec) {
			Hashtable sys = new Hashtable();
			string[] syskeys = sec.EnumSysKeys();
			foreach (object o in syskeys) {
				object k = sec.GetSys(o.ToString());
				if (k == null) continue;
				// COMMENTATO PER RAGIONI DI SICUREZZA NON INVIO LE SYS 
				//if (k.GetType() != typeof(string)) continue;
				// sys[o.ToString()] = k;
			}

			return sys;
		}

		private static string getCondSorFrontend(object o, Object k) {
			var filterSec = (string) k;
			if (filterSec.StartsWith("AND(1=1)")) {
				var me = q.constant(true);
				var json = DataUtils.metaExpressionToJson(me);
				return json;
			}

			if (filterSec != null) {
				// filterSec = filterSec.Replace("idsor0" + o.ToString()[10], "idsor");
				// recupero ME da filtro stringa
				var me = q.fromString(filterSec);
				var json = DataUtils.metaExpressionToJson(me);
				return json;
			}

			return null;
		}

		private static string getCondSor(object o, Object k) {
			var filterSec = (string) k;
			if (String.IsNullOrEmpty(filterSec)) {
				var me = q.fromString(filterSec);
				var json = DataUtils.metaExpressionToJson(me);
				return json;
			}

			return null;
		}

        public static T DeepClone<T>(this T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }

    }
}

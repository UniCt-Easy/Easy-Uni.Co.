
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


using System;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
using System.Data.SqlTypes;
using System.Windows.Forms;
using System.Reflection;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using q= metadatalibrary.MetaExpression;

namespace funzioni_configurazione{//funzioni_configurazione//

    
	public class ShowAutomatismi{
		public static Form ShowAzzeramento(DataTable AutoVar){
			string MyAssemblyName = "expense_clearprevphases";				
			Assembly a = System.Reflection.Assembly.Load( MyAssemblyName );
			if (a==null) {
				return null;
			}
			foreach (System.Type T in a.GetTypes()){
				if (!typeof(Form).IsAssignableFrom(T))continue;
				System.Reflection.ConstructorInfo FormBuilder = 
					T.GetConstructor(
					new System.Type[] {typeof(DataTable) });
				if (FormBuilder==null) continue;
				Form F=null;
				try { 
					F=  (Form) FormBuilder.Invoke(new object[]{AutoVar });
				}
				catch {
					continue;
				}

				return F;
			}
			return null;

		}

       
	
		public static Form Show(MetaDataDispatcher Disp, DataRow [] Automatismi,
			DataRow SpesaRow,
			string title){
			string MyAssemblyName = "expense_automatismiritenute";				
			var a = Assembly.Load( MyAssemblyName );
			if (a==null) {
				return null;
			}
			foreach (var T in a.GetTypes()){
				if (!typeof(Form).IsAssignableFrom(T))continue;
				var formBuilder = 
					T.GetConstructor(new[] {Disp.GetType(),Automatismi.GetType(),typeof(DataRow),typeof(string)});
				if (formBuilder==null) continue;
				Form f;
				try { 
					f=  (Form) formBuilder.Invoke(new object[]{Disp,Automatismi,SpesaRow,title });
				}
				catch {
					continue;
				}

				return f;
			}
			return null;

		}

        
	    public static Form show(IMetaData meta, string filterspesa, string filterentrata,
	        string filtervarspesa,string filtervarentrata){
	        string MyAssemblyName = "expense_automatismi";				
	        var a = Assembly.Load( MyAssemblyName );
	        if (a==null) {
	            return null;
	        }
	        foreach (var T in a.GetTypes()){
	            if (!typeof(Form).IsAssignableFrom(T))continue;
	            var formBuilder = 
	                T.GetConstructor(new[] {typeof(MetaData),typeof(string), typeof(string),typeof(string),typeof(string)});
	            if (formBuilder==null) continue;
	            Form f=null;
	            try { 
	                f=  (Form) formBuilder.Invoke(new object[]{meta,
	                    filterspesa,filterentrata,filtervarspesa,filtervarentrata });
	            }
	            catch {
	                continue;
	            }

	            return f;
	        }
	        return null;
	    }

		public static Form Show(MetaData meta, string filterspesa, string filterentrata,
			string filtervarspesa,string filtervarentrata){
			string MyAssemblyName = "expense_automatismi";				
			Assembly a = System.Reflection.Assembly.Load( MyAssemblyName );
			if (a==null) {
				return null;
			}
			foreach (var T in a.GetTypes()){
				if (!typeof(Form).IsAssignableFrom(T))continue;
				var formBuilder = 
					T.GetConstructor(
					new[] {typeof(MetaData),typeof(string),
										  typeof(string),typeof(string),typeof(string)
									  });
				if (formBuilder==null) continue;
				Form f;
				try { 
					f=  (Form) formBuilder.Invoke(new object[]{meta,
							filterspesa,filterentrata,filtervarspesa,filtervarentrata });
				}
				catch {
					continue;
				}

				return f;
			}
			return null;
		}

	}



	/// <summary>
	/// Funzioni generali di configurazione
	/// </summary>
	public class CfgFn {
		const int NCifreDecimaliPerRisultatiValuta=2;
		public CfgFn() {
		}
        public static string DecodeToString(object flag, int mask) {
            if ((CfgFn.GetNoNullInt32(flag) & mask)!=0) return "S";
            return "N";
        }
        public static bool DecodeToBool(object flag, int mask) {
            if ((CfgFn.GetNoNullInt32(flag) & mask) != 0) return true;
            return false;
        }

        

        static object GetCtrlByName(Form F, string Name) {
            System.Reflection.FieldInfo Ctrl = F.GetType().GetField(Name);
            if (Ctrl == null) return null;
            //if (!typeof(Label).IsAssignableFrom(Ctrl.FieldType)) return null;                         
            //Label L =  (Label) Ctrl.GetValue(this);                        
            //return L;
            return Ctrl.GetValue(F);
        }

        public static void SetGBoxClass0(Form F, int num, object sortingkind) {
            var conn = F.getInstance<IDataAccess>();
            var meta = F.getInstance<IMetaData>();
            var ds = F.getInstance<DataSet>();
            var sec = F.getInstance<ISecurity>();
            var model = MetaFactory.factory.getSingleton<IMetaModel>();
            string nums = num.ToString();
            if (sortingkind==null ||sortingkind == DBNull.Value || sortingkind.ToString()=="null" ) {
                var g = (GroupBox)GetCtrlByName(F, "gboxclass0" + nums);
                g.Tag = null;
                g.Visible = false;
                var c = (TextBox)GetCtrlByName(F, "txtCodice0" + nums);
                c.Tag = null;
            }
            else {
                object filterSec = sec.GetUsr("cond_sor0" + nums);
                if (filterSec != null) {
                    string f = filterSec.ToString().Trim();
                    if (f.StartsWith("AND(")) {
                        f = f.Substring(3);
                        filterSec = f;
                    }
                                        
                    if (f == "(1=1") {
                        f = "";
                        filterSec = null;
                    }

                    if (f != "") {
                        f = f.Replace("idsor0" + nums, "idsor");
                        filterSec = f;
                    }
                }

                QueryHelper qhs = conn.GetQueryHelper();
                string filterkind = qhs.CmpEq("idsorkind", CfgFn.GetNoNullInt32( sortingkind));
                string filtercomplete = filterkind;
                if (filterSec != null) filtercomplete = qhs.AppAnd(filtercomplete, filterSec.ToString());
                model.setStaticFilter(ds.Tables["sorting0" + nums],filterkind);
                //GetData.SetStaticFilter(ds.Tables["sorting0" + nums], filterkind);
                var gboxclass = (GroupBox)GetCtrlByName(F, "gboxclass0" + nums);
                var btnCodice = (Button)GetCtrlByName(F, "btnCodice0" + nums);
                var txtCodice = (TextBox)GetCtrlByName(F, "txtCodice0" + nums);
                //gboxclass.Tag = "AutoManage.txtCodice0" + nums + ".tree." + filter;
                var title = sec.GetSys("titlesortingkind0" + nums);
                    //Conn.DO_READ_VALUE("sortingkind", filterkind, "description").ToString();
                if (title != null) {
                    gboxclass.Text = title.ToString();
                }
                else {
                    gboxclass.Visible = false;
                }
                if (filterSec != null) {
                    btnCodice.Tag = "choose.sorting0" + nums + ".treeall." + filtercomplete;
                }
                else {
                    btnCodice.Tag = "manage.sorting0" + nums + ".treeall";
                }
                model.setExtraParams(ds.Tables["sorting0" + nums],filterkind);
                //ds.Tables["sorting0" + nums].ExtendedProperties[MetaData.ExtraParams] = filterkind;
                string gboxtag = "AutoChoose.txtCodice0" + nums + ".treeall";
                if (filterSec != null) gboxtag = gboxtag+  "." + filterSec;
                gboxclass.Tag = gboxtag;
                txtCodice.Tag = "sorting0" + nums + ".sortcode?x";
            }
        }

        public static void SetGBoxClass(Form F, int num, object sortingkind) {
            var conn = F.getInstance<IDataAccess>();
            var meta = F.getInstance<IMetaData>();
            var ds = F.getInstance<DataSet>();
            var sec = F.getInstance<ISecurity>();
            var model = MetaFactory.factory.getSingleton<IMetaModel>();
            
            string nums = num.ToString();
            if ( sortingkind==null || sortingkind == DBNull.Value || sortingkind.ToString()=="null" ) {
                var g = (GroupBox)GetCtrlByName(F, "gboxclass" + nums);
                g.Tag = null;
                g.Visible = false;
                var c = (TextBox)GetCtrlByName(F, "txtCodice" + nums);
                c.Tag = null;
            }
            else {
                var filterSec = sec.GetSys("idflowchart");
                
                QueryHelper qhs = conn.GetQueryHelper();
                var filter = qhs.CmpEq("idsorkind", CfgFn.GetNoNullInt32( sortingkind));
                model.setStaticFilter(ds.Tables["sorting" + nums],filter);
                //GetData.SetStaticFilter(DS.Tables["sorting" + nums], filter);
                var gboxclass = (GroupBox)GetCtrlByName(F, "gboxclass" + nums);
                var btnCodice = (Button)GetCtrlByName(F, "btnCodice" + nums);
                var txtCodice = (TextBox)GetCtrlByName(F, "txtCodice" + nums);
                //gboxclass.Tag = "AutoManage.txtCodice0" + nums + ".tree." + filter;
                var title = conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclass.Text = title;
                //btnCodice.Tag = "manage.sorting" + nums + ".tree." + filter;
                if (filterSec != null) {
                    btnCodice.Tag = "choose.sorting" + nums + ".treeusable." + filter;
                }
                else {
                    btnCodice.Tag = "manage.sorting" + nums + ".tree." + filter;
                }
                model.setExtraParams(ds.Tables["sorting" + nums],filter);
                //ds.Tables["sorting" + nums].ExtendedProperties[MetaData.ExtraParams] = filter;
                gboxclass.Tag = "AutoChoose.txtCodice" + nums + ".treeusable";
                txtCodice.Tag = "sorting" + nums + ".sortcode?x";
            }
        }

		public static decimal Round(decimal valuta, int nCifre)
		{		
			decimal prec = 1;
			switch (nCifre) 
			{
				case 6: prec = 1000000; break;
				case 5: prec = 100000; break;
				case 4: prec = 10000; break;
				case 3: prec = 1000; break;
				case 2: prec = 100; break;
				case 1: prec = 10; break;
				case 0: prec = 1; break;
				case-1: prec = .1M; break;
				case-2: prec = .01M; break;
				case-3: prec = .001M; break;
			}

			decimal truncated= Decimal.Truncate(valuta * prec * 10);
			if (truncated>0)
			{
				if ((truncated % 10)>=5) truncated+=5;
			}
			else 
			{
				if (((-truncated) % 10)>=5) truncated-=5;
			}
			truncated = truncated / 10;
			truncated = Decimal.Truncate(truncated);
			return truncated / prec;
			//			SqlDecimal SQLV = new SqlDecimal(valuta);
			//			return SqlDecimal.Round(SQLV,NCifreDecimaliPerRisultatiValuta).Value;
		}

		public static double Round(double valuta, int nCifre)
		{
			return Convert.ToDouble(Round(Convert.ToDecimal(valuta), nCifre));
		}

		public static decimal RoundValuta(decimal valuta)
		{
            if (valuta == Decimal.Truncate(valuta)) return valuta;
			decimal truncated= Decimal.Truncate(valuta * 1000);
			if (truncated>0){
				if ((truncated % 10)>=5) truncated+=5;
			}
			else {
				if (((-truncated) % 10)>=5) truncated-=5;
			}
			truncated = truncated/10;
			truncated = Decimal.Truncate(truncated);
			return truncated/100;
			//			SqlDecimal SQLV = new SqlDecimal(valuta);
			//			return SqlDecimal.Round(SQLV,NCifreDecimaliPerRisultatiValuta).Value;
		}

		public static double RoundValuta(double valuta){
			return  Convert.ToDouble(
				RoundValuta(Convert.ToDecimal(valuta)));
			//			SqlDecimal SQLV = new SqlDecimal(valuta);
			//			return SqlDecimal.Round(SQLV,NCifreDecimaliPerRisultatiValuta).ToDouble();
		}

		/// <summary>
		/// Restituisce il nome della previsione principale. R deve essere la
		///  riga di persbilancio  dell'esercizio da considerare.
		/// </summary>
		/// <param name="conn"></param>
		/// <returns></returns>
		public static string NomePrevisionePrincipale(DataAccess conn){
            int finkind = GetNoNullInt32(conn.GetSys("fin_kind"));
			switch (finkind){
				case 1: return "Competenza";
                case 3: return "Competenza";
                case 2: return "Cassa";	
				default: return "NON PREVISTO!";
			}
		}

		/// <summary>
		/// Restituisce il nome della previsione secondaria, o null se non prevista. 
		/// R deve essere la riga di persbilancio  dell'esercizio da considerare.
		/// </summary>
		/// <param name="conn"></param>
		/// <returns></returns>
        public static string NomePrevisioneSecondaria(DataAccess conn) {
            int finkind = GetNoNullInt32(conn.GetSys("fin_kind"));
			switch (finkind){
				case 1: return null;
                case 3: return "Cassa";
                case 2: return null;	
				default: return null;
			}

		}

/*		public static string CalcolaCF(string cognome,string nome,string sesso,DateTime nascita,int codice,char straniero)
		{
			string CF;
			CF = GetCodCognome(cognome) + GetCodNome(nome) + GetCodData(nascita) + GetCodCitta(codice,straniero);
			CF += GetCharCheck(CF);
			return CF;
		}*/

		public static int CheckDigit(int nPosizione, string lettera) {
			char chLettera=Convert.ToChar(lettera);			
			nPosizione++;
			if(nPosizione % 2 == 0) {
				if(chLettera >= 'A' && chLettera <= 'Z'){
					int res = (Convert.ToInt32(chLettera)  - Convert.ToInt32('A'));
					return res;
				}
			
				else if(chLettera >= '0' && chLettera <= '9'){
					int res =  Convert.ToInt32(chLettera.ToString());
					return res;
				}

				else if(chLettera == '-')
					return 26;
				else if(chLettera == '.')
					return 27;
				else if(chLettera == ' ')
					return 28;
				
			}
			else {
				if(chLettera == 'A' || chLettera == '0')
					return 1;
				else if(chLettera == 'B' || chLettera == '1')
					return 0;
				else if(chLettera == 'C' || chLettera == '2')
					return 5;
				else if(chLettera == 'D' || chLettera == '3')
					return 7;
				else if(chLettera == 'E' || chLettera == '4')
					return 9;
				else if(chLettera == 'F' || chLettera == '5')
					return 13;
				else if(chLettera == 'G' || chLettera == '6')
					return 15;
				else if(chLettera == 'H' || chLettera == '7')
					return 17;
				else if(chLettera == 'I' || chLettera == '8')
					return 19;
				else if(chLettera == 'J' || chLettera == '9')
					return 21;
				else if(chLettera == 'K')
					return 2;
				else if(chLettera == 'L')
					return 4;
				else if(chLettera == 'M')
					return 18;
				else if(chLettera == 'N')
					return 20;
				else if(chLettera == 'O')
					return 11;
				else if(chLettera == 'P')
					return 3;
				else if(chLettera == 'Q')
					return 6;
				else if(chLettera == 'R')
					return 8;
				else if(chLettera == 'S')
					return 12;
				else if(chLettera == 'T')
					return 14;
				else if(chLettera == 'U')
					return 16;
				else if(chLettera == 'V')
					return 10;
				else if(chLettera == 'W')
					return 22;
				else if(chLettera == 'X')
					return 25;
				else if(chLettera == 'Y')
					return 24;
				else if(chLettera == 'Z')
					return 23;
				else if(chLettera == '-')
					return 27;
				else if(chLettera == '.')
					return 28;
				else if(chLettera == ' ')
					return 26;
			}
			return 0;
		}

	    public static int checkLetter(string coordinate, int minlunghezza) {
	        int nCheckDigit = 0;
	        for(int i=0; i < coordinate.Length; i++)
	            nCheckDigit = nCheckDigit + CheckDigit(i,coordinate.Substring(i,1));

	        // if length of code is less than minimum length
	        // then right pad with spaces 
	        if(coordinate.Length < minlunghezza) {
	            for(int i=minlunghezza; i > coordinate.Length; i--) {
	                if(i % 2 == 0)
	                    nCheckDigit += 28;
	                else
	                    nCheckDigit += 26;
	            }
	        }

	        int nRemainder = nCheckDigit % 26;
	        return nRemainder + Convert.ToInt32('A');
	    }


	    public static double CheckLetter(string coordinate, int minlunghezza) {
	        return checkLetter(coordinate, minlunghezza);
	    }

        public static bool IsValidString(string Value) {
            var rgx = new Regex("[^a-zA-Z0-9]");

            string newValue = rgx.Replace(Value, string.Empty);
            if (Value == newValue) return true;
            else return false;
        }
        public static string GetValidString(string Value) {
            var rgx = new Regex("[^a-zA-Z0-9]");
            string newValue = rgx.Replace(Value, string.Empty);

            return newValue;
        }

        public static bool CheckCIN(string cin, string cab, string abi, string cc) {
		    if (cin?.Length!=1) return false;
			cin= cin.ToUpper();
			if (cin.CompareTo("A")<0||cin.CompareTo("Z")>0) return false;
			if (cab==null || abi==null || cc==null) return false;
		    if (abi.Length!=5) return false;
			
			if (cab.Length!=5) return false;

			// 14.07.2005 Rusciano G.
			// Il seguente controllo è stato cambiato da >= 13 a != 12
			if (cc.Length!=12) return false;

			var coordinate= abi+cab+cc;
			var numCin = Convert.ToInt32(cin[0]);
			if(checkLetter(coordinate,22) != numCin) return false;
			return true;
        }


        #region Calcolo IBAN
        public static string calcolaRf(string valore) {
            string normRef = alfaToNumber(normalizzaIBAN(valore));
            normRef += "271500";
            const int divisore = 97;
            uint resto = modulo(normRef, divisore);
            resto = (divisore + 1) - resto;
            return "RF" + resto.ToString("00") + valore;
        }

        public static bool verificaRf(string rfCode) {
            rfCode = normalizzaIBAN(rfCode);
            if (rfCode.Length < 4) return false;
            string valore = rfCode.Substring(4);
            string myRFcode = calcolaRf(valore);
            return myRFcode == rfCode;
        }

        public static string calcolaIBAN(string pPaese, string pBBAN) {
            pBBAN = normalizzaIBAN(pBBAN);
            string codice = pPaese + "00" + pBBAN;
            codice = codice.Substring(4) + codice.Substring(0, 4);
            string numcode = alfaToNumber(codice);
            const int divisore = 97;
            uint resto = modulo(numcode, divisore);
            resto = (divisore + 1) - resto;
            return pPaese + resto.ToString("00") + pBBAN;
        }

	    
        public static bool verificaIban(string iban) {
            iban = normalizzaIBAN(iban);
            if (iban.Length < 4) return false;
            string codice = iban.Substring(4) + iban.Substring(0, 2) + "00";
            string numcode = alfaToNumber(codice);
            const int divisore = 97;
            uint resto = modulo(numcode, 97);
            resto = (divisore + 1) - resto;
            return resto.ToString("00") == iban.Substring(2, 2);
        }

        public static string normalizzaIBAN(string pCodice) {
            pCodice = pCodice.ToUpper();
            const string alfanum = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder sb = new StringBuilder();
            foreach (char c in pCodice) {
                if (alfanum.IndexOf(c) != -1)
                    sb.Append(c);
            }
            return sb.ToString();
        }

        private static string alfaToNumber(string pCodice) {
            pCodice = pCodice.ToUpper();
            const string alfachars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder sb = new StringBuilder();
            foreach (char c in pCodice) {
                int k = alfachars.IndexOf(c);
                if (k != -1)
                    sb.Append(k + 10);
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }

        private static uint modulo(string dividendo, uint divisore) {
            uint resto = 0;
            foreach (char c in dividendo) {
                resto = resto * 10 + uint.Parse(c.ToString());
                if (resto >= divisore) {
                    resto %= divisore;
                }
            }
            return resto;
        }

        #endregion

        public static decimal CalcImponibileDipendente(
			decimal imponibile,
			decimal quotaesente,
			decimal detrazioni,
			double aliquota,
			double quotanum,
			double quotaden){
			var impreale = Convert.ToDouble(imponibile-quotaesente);
			impreale = DoubleMulDiv(impreale, quotanum, quotaden);			
			impreale = impreale* aliquota;
			var result = Convert.ToDecimal(impreale);
			result =  result-detrazioni;
			//if (result<0) result=0;
			return RoundValuta(result);
		}

		public static decimal DecMulDiv(Decimal Number, double num, double den){
			if (den==0) return Number;	
			var N =(Convert.ToDouble(Number)*num/den);
			return Convert.ToDecimal(N);			
		}

		public static double DoubleMulDiv(double Number, double num, double den){
			if (den==0) return Number;	
			return (Number*num)/den;
		}

		public static decimal CalcImponibileEnte(
			decimal imponibile,
			decimal quotaesente,
			double aliquota,
			double quotanum,
			double quotaden){
			double impreale = Convert.ToDouble(imponibile-quotaesente);
			impreale = DoubleMulDiv(impreale, quotanum, quotaden);			
			impreale = impreale* aliquota;
			decimal result = Convert.ToDecimal(impreale);
			return RoundValuta(result);
		}

		public static double GetNoNullDouble(object O){
			if (O==null) return 0;
			if (O == DBNull.Value) return 0;
		    if (O.ToString() == "") return 0;
			try {
				return Convert.ToDouble(O);
			}
			catch {
				return 0;
			}
		}
		public static decimal GetNoNullDecimal(object O){
			if (O==null || O==DBNull.Value) return 0;
			//if (O == DBNull.Value) return 0;
		    //if (O.ToString() == "") return 0;
			try {
				return Convert.ToDecimal(O);
			}
			catch {
				return 0;
			}
		}
		public static long GetNoNullInt64(object O){
			if (O==null) return 0;
			if (O == DBNull.Value) return 0;
			if (O.ToString() == "") return 0;
			try {
				return Convert.ToInt64(O);
			}
			catch {
				return 0;
			}
		}
		public static int GetNoNullInt32(object O){
			if (O==null) return 0;
			if (O == DBNull.Value) return 0;
		    if (O.ToString() == "") return 0;
			try {
				return Convert.ToInt32(O);
			}
			catch {
				return 0;
			}
		}
        public static byte GetNoNullByte(object O) {
            if (O == null) return 0;
            if (O == DBNull.Value) return 0;
            if (O.ToString() == "") return 0;
            try {
                int N = Convert.ToInt32(O);
                return Convert.ToByte(N &0xFF);
            }
            catch {
                return 0;
            }
        }

		public static void AssignNotEquals(DataRow R, string field, decimal N){
			decimal Curr= GetNoNullDecimal(R[field]);
			if (Curr==N) return;
			R[field]= N;
		}

		// by Leo
		public static void ReSetAutoIncrementPropertiesForFirstPhaseEntrata(EntityDispatcher E, DataTable T, DataRow MiddleConst) {
			if (MiddleConst["nphase"].ToString() != "1") {
				RowChange.MarkAsAutoincrement(T.Columns["idinc"],null, null, 0);
				return;
			}
			int iesercmov=CfgFn.GetNoNullInt32( MiddleConst["ymov"]);
			if (iesercmov<1000) iesercmov+=2000;
			string esercmov= iesercmov.ToString();
			RowChange.MarkAsAutoincrement(T.Columns["idinc"],null, null, 0);
		}

		public static void ReSetAutoIncrementPropertiesForFirstPhaseSpesa(EntityDispatcher E, DataTable T, DataRow MiddleConst) {
			if (MiddleConst["nphase"].ToString() != "1") {
                RowChange.MarkAsAutoincrement(T.Columns["idexp"], null, null, 0);
				return;
			}
			int iesercmov=CfgFn.GetNoNullInt32( MiddleConst["ymov"]);
			if (iesercmov<1000) iesercmov+=2000;
			string esercmov= iesercmov.ToString();
            RowChange.MarkAsAutoincrement(T.Columns["idexp"], null, null, 0);
		}

		public static void ReSetAutoIncrementPropertiesForFirstPhaseEntrataProcedura(
			DataAccess Conn, DataTable T, DataRow MiddleConst, int codfaseinizio,
			int codfasefine) {
			int iesercmov=CfgFn.GetNoNullInt32( MiddleConst["ymov"]);
			if (iesercmov<1000) iesercmov+=2000;
			string esercmov= iesercmov.ToString();
            RowChange.MarkAsAutoincrement(T.Columns["idinc"], null, null, 0);
		}

		public static void ReSetAutoIncrementPropertiesForFirstPhaseSpesaProcedura(
			DataAccess Conn, DataTable T, DataRow MiddleConst, int codfaseinizio,
			int codfasefine) {
			int iesercmov=CfgFn.GetNoNullInt32( MiddleConst["ymov"]);
			if (iesercmov<1000) iesercmov+=2000;
			string esercmov= iesercmov.ToString();
            RowChange.MarkAsAutoincrement(T.Columns["idexp"], null, null, 0);
		}


		public static void ReSetAutoIncrementPropertiesForFirstPhaseEntrata(DataAccess Conn, DataTable T, DataRow MiddleConst) {
			int iesercmov=CfgFn.GetNoNullInt32( MiddleConst["ymov"]);
			if (iesercmov<1000) iesercmov+=2000;
			string esercmov= iesercmov.ToString();
			if (MiddleConst["nphase"].ToString() != "1") {
                RowChange.MarkAsAutoincrement(T.Columns["idinc"], null, null, 0);
				return;
			}
            RowChange.MarkAsAutoincrement(T.Columns["idinc"], null, null, 0);
		}

		public static void ReSetAutoIncrementPropertiesForFirstPhaseSpesa(DataAccess Conn, DataTable T, DataRow MiddleConst) {
			int iesercmov=CfgFn.GetNoNullInt32( MiddleConst["ymov"]);
			if (iesercmov<1000) iesercmov+=2000;
			string esercmov= iesercmov.ToString();
			if (MiddleConst["nphase"].ToString() != "1") {
                RowChange.MarkAsAutoincrement(T.Columns["idexp"], null, null, 0);
				return;
			}
            RowChange.MarkAsAutoincrement(T.Columns["idexp"], null, null, 0);
		}

	    public delegate decimal decimalFunction(decimal x);

	    public static decimal funzioneInversa(decimal leftLimit, decimal rightLimit, decimalFunction fun,
	        decimal desiredResult,int precision) {
	        decimal x0 = leftLimit;
	        decimal x1 = rightLimit;	      
	      
            decimal y0 = fun(x0);
	        decimal y1 = fun(x1);
	        bool crescente = y0 < y1;
                
	        if (crescente) {
	            while (true) {//x0 sempre minore di x1 per costruzione
	                if (y0 == desiredResult || y0 == y1) return x0;
	                if (y1 == desiredResult) return x1;

	                decimal x2 = decimal.Round((x0 + (x1 - x0) * (desiredResult - y0) / (y1 - y0)),precision);
	                if (x2 <= x0) x2 = x0;
	                if (x2 >= x1) x2 = x1;

	                if (x2 == x0 || x2 == x1) {
	                    return x2;
	                }
	                decimal y2 = fun(x2);
	                if (y2 > desiredResult) {
	                    x1 = x2; //Si mette nel settore inferiore diminuendo l'estremo superiore x1
	                    y1 = y2;
	                    continue;
	                }
	                if (y2 < desiredResult) {
	                    x0 = x2; //Si mette nel sett. superiore aumentando l'estremo inferiore x0
	                    y0 = y2;
	                    continue;
	                }
	                return x2;
	            }
            }
	        else {
	            while (true) {//x0 sempre minore di x1 per costruzione
	                if (y0 == desiredResult || y0 == y1) return x0;
	                if (y1 == desiredResult) return x1;

	                decimal x2 = decimal.Round((x0 + (x1 - x0) * (desiredResult - y0) / (y1 - y0)), precision);
	                if (x2 <= x0) x2 = x0;
	                if (x2 >= x1) x2 = x1;

	                if (x2 == x0 || x2 == x1) {
	                    return x2;
	                }
	                decimal y2 = fun(x2);
	                if (y2 < desiredResult) {
	                    x1 = x2; //Si mette nel settore inferiore diminuendo l'estremo superiore x1
	                    y1 = y2;
	                    continue;
	                }
	                if (y2 > desiredResult) {
	                    x0 = x2; //Si mette nel sett. superiore aumentando l'estremo inferiore x0
	                    y0 = y2;
	                    continue;
	                }
	                return x2;
	            }

            }

        }

	    public static DataRow modalitaPagamentoDefault(Form f, object idreg){
	        if (idreg==null||idreg==DBNull.Value) return null;
	        var conn = f.getInstance<IDataAccess>();
	        MetaDataDispatcher dispatcher = new Meta_EasyDispatcher(conn);

	        var filtro = q.eq("idreg", idreg) & q.nullOrEq("active", "S");
	        var modPagam = conn.readTable("registrypaymethod", q.eq("idreg", idreg) & q.nullOrEq("active", "S"));
	                //conn.RUN_SELECT("registrypaymethod","*",null, filtro, null, true);
	        if (modPagam.Rows.Count==0) return null;
	        var defRow = modPagam.Rows[0];
	        if (modPagam.Rows.Count>1){
	            var defTipo = modPagam._Filter(q.eq("flagstandard", "S"));
	            if (defTipo.Length!=0) return defTipo[0];	
	            var mregistrypaymethod = dispatcher.Get("registrypaymethod");
	            var T = conn.CreateTableByName("registrypaymethod","*");
	            var ds= new DataSet("a");
	            ds.Tables.Add(T);
	            mregistrypaymethod.DS = ds;
	            mregistrypaymethod.FilterLocked = true;
	            var rregistrypaymethod = mregistrypaymethod.SelectOne("modpaganagrafica", conn.compile(filtro), "registrypaymethod", null);
	            if (rregistrypaymethod != null) {
	                return rregistrypaymethod;
	            }

	            MetaFactory.factory.getSingleton<IMessageShower>().Show("E' necessario selezionare una Modalità di Pagamento");
	            return null;
	        }
	        return defRow;

	    }

		public static DataRow ModalitaPagamentoDefault(DataAccess conn, object codicecreddebi){
            var qhc = new CQueryHelper();
            var qhs = conn.GetQueryHelper();
            MetaDataDispatcher dispatcher = new Meta_EasyDispatcher(conn); 
            
			if (codicecreddebi==null||codicecreddebi==DBNull.Value) return null;
            string filtro = qhs.AppAnd(qhs.CmpEq("idreg",codicecreddebi),
                qhs.NullOrEq("active", "S"));
			var modPagam= conn.RUN_SELECT("registrypaymethod","*",null, filtro, null, true);
			if (modPagam.Rows.Count==0) return null;
			var defRow = modPagam.Rows[0];
			if (modPagam.Rows.Count>1){
				var defTipo = modPagam.Select(qhc.CmpEq("flagstandard", 'S'));
				if (defTipo.Length!=0) return defTipo[0];	
                    var mregistrypaymethod = dispatcher.Get("registrypaymethod");
                    var T = conn.CreateTableByName("registrypaymethod","*");
                    var ds= new DataSet("a");
                    ds.Tables.Add(T);
                    mregistrypaymethod.DS = ds;
                    mregistrypaymethod.FilterLocked = true;
                    var rregistrypaymethod = mregistrypaymethod.SelectOne("modpaganagrafica", filtro, "registrypaymethod", null);
                    if (rregistrypaymethod != null) {
                            return rregistrypaymethod;
                        }

				    MetaFactory.factory.getSingleton<IMessageShower>().Show("E' necessario selezionare una Modalità di Pagamento");
				    return null;
			}
			return defRow;

		}

	}

}

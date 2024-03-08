
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
//using PosizioneGiuridica;
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
//using posgiuridicamain;
//using posgiuridica_anagrafica;
//using posgiuridicadetailanagrafica;
using funzioni_configurazione;//funzioni_configurazione


namespace meta_registrylegalstatus//meta_posgiuridica//
{
	/// <summary>
	/// MetaData for posgiuridica
	/// </summary>
	public class Meta_registrylegalstatus : Meta_easydata
	{
        public Meta_registrylegalstatus(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "registrylegalstatus") {
			Name = "Inquadramento";
           	ListingTypes.Add("default");
			ListingTypes.Add("posgiuridica");
			EditTypes.Add("anagrafica");
			ListingTypes.Add("anagrafica");
			EditTypes.Add("anagraficadetail");
			ListingTypes.Add("anagraficadetail");
            ListingTypes.Add("unione");
        }
    
		protected override Form GetForm(string FormName){

			if(FormName=="anagraficadetail")
			{
				Name = "Inquadramento";
				DefaultListType="anagraficadetail";
				return GetFormByDllName("registrylegalstatus_anagraficadetail");
				//return new frmposgiuridicadetailanagrafica();
			}

			if(FormName=="anagrafica")
			{
				Name = "Inquadramento";
				DefaultListType="anagrafica";
				return GetFormByDllName("registrylegalstatus_anagrafica");
			}
			return null;
        }	
		
		public override DataRow SelectOne(string ListingType, 
			string filter, string searchtable, DataTable ToMerge) 
		{
			if(ListingType=="posgiuridica")
				return base.SelectOne(ListingType, filter, "registrylegalstatusview", ToMerge);
			
			if(ListingType=="anagrafica")
				return base.SelectOne(ListingType, filter, "registrylegalstatusregview", ToMerge);

			return base.SelectOne(ListingType, filter, searchtable, ToMerge);
		}
    
		public override void SetDefaults(DataTable T) {
			base.SetDefaults (T);
			SetDefault(T, "active", "S");
			SetDefault(T, "flagdefault", "N");
		}

        public override void DescribeColumns(DataTable T, string ListingType){
            base.DescribeColumns(T, ListingType);
            if (ListingType=="default"){
	            foreach (DataColumn C in T.Columns)
		            DescribeAColumn(T, C.ColumnName, "", -1);
	            int nPos = 1;
                AddColumn(T,"descrqualifica",typeof(string),"position.description","Qualifica");                
				DescribeAColumn(T,"start","Data inizio", nPos++);
				DescribeAColumn(T,"stop","Termine", nPos++);
				DescribeAColumn(T,"incomeclass","Classe", nPos++);
				DescribeAColumn(T,"incomeclassvalidity","Data Decorrenza", nPos++);
			}

			if (ListingType=="anagraficadetail") {
				foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                AddColumn(T, "!qualificadalia", typeof(string), "dalia_position.description", "Qualifica Dalia");
                DescribeAColumn(T, "start", "Data inizio", nPos++);
                DescribeAColumn(T, "stop", "Termine", nPos++);
                DescribeAColumn(T, "incomeclass", "Classe", nPos++);
				DescribeAColumn(T, "incomeclassvalidity", "Data Decorrenza", nPos++);
                DescribeAColumn(T, "!qualifica", "Qualifica", "position.description", nPos++);
				DescribeAColumn(T, "livello", "Livello", nPos++);
				DescribeAColumn(T, "!qualificadalia", "Qualifica Dalia", "dalia_position.description", nPos++);
                DescribeAColumn(T, "csa_compartment", "Comparto CSA", nPos++);
                DescribeAColumn(T, "csa_role", "Ruolo CSA", nPos++);
                DescribeAColumn(T, "csa_class", "Inquadr.CSA", nPos++);
                DescribeAColumn(T, "csa_description", "Desr.CSA", nPos++);
				DescribeAColumn(T, "active", "Attivo", nPos++);
				DescribeAColumn(T, "flagdefault", "Predefinito", nPos++);
			}
            if (ListingType == "unione") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", - 1);
                int nPos = 1;
                DescribeAColumn(T, "!kk", ".aaaa", nPos++);
                DescribeAColumn(T, "idreg", "#", nPos++);
                DescribeAColumn(T, "start", "Data inizio", nPos++);
                DescribeAColumn(T, "stop", "Termine", nPos++);
                DescribeAColumn(T, "incomeclass", "Classe", nPos++);
                DescribeAColumn(T, "incomeclassvalidity", "Data Decorrenza", nPos++);
                DescribeAColumn(T, "!qualifica", "Qualifica", "position.description", nPos++);
                DescribeAColumn(T, "active", "Attivo", nPos++);
                DescribeAColumn(T, "lt", "Data ultima mod.", nPos++);
            }



        }

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;                 

			int codicecreddeb = CfgFn.GetNoNullInt32(R["idreg"]);
			if (codicecreddeb <= 0) {
				errmess="Inserire l'anagrafica";
				errfield="idreg";
				return false;
			}
			string codicequal = R["idposition"].ToString();
			if (codicequal=="") {
				errmess="Inserire la qualifica";
				errfield="idposition";
				return false;
			}
			if (R["incomeclass"]==DBNull.Value){
				errmess="Inserire la classe stipendiale";
				errfield="incomeclass";
				return false;
			}

			int classe = CfgFn.GetNoNullInt32(R["incomeclass"]);
			if (classe<0){
				errmess="La classe stipendiale non può essere inferiore a 0";
				errfield="incomeclass";
				return false;
			}
			DataTable Qualifiche = DS.Tables["position"];
			if (Qualifiche!=null){
				DataRow []CurrClasses = Qualifiche.Select("idposition="+
					QueryCreator.quotedstrvalue(codicequal,false));
				if (CurrClasses.Length>0){
					int maxclasse=CfgFn.GetNoNullInt32(CurrClasses[0]["maxincomeclass"]);
					if (maxclasse< classe){
						errmess="La classe non può superare "+maxclasse.ToString();
						errfield="incomeclass";
						return false;
					}
				}
			}
            if ((R["start"] != DBNull.Value) && (R["stop"] != DBNull.Value)) {
                DateTime start = (DateTime)R["start"];
                DateTime stop = (DateTime)R["stop"];

                if (start > stop)  {
                    errmess = "Attenzione! Il termine dell'inquadramento non può essere successivo alla data inizio.";
                    errfield = "stop";
                    return false;
                }
            }

			return true;
		}
        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idreg");
            RowChange.MarkAsAutoincrement(T.Columns["idregistrylegalstatus"], null, null, 0);
            RowChange.setMinimumTempValue(T.Columns["idregistrylegalstatus"], 9999);
            return base.Get_New_Row(ParentRow, T);

        }


    }



}

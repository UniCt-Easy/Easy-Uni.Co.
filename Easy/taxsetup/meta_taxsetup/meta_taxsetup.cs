/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;
//Pino: using automatismiritenute; diventato inutile

namespace meta_taxsetup//meta_automatismiritenute//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_taxsetup : Meta_easydata {
		public Meta_taxsetup(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "taxsetup") {
			EditTypes.Add("default");
			EditTypes.Add("versamento");
			ListingTypes.Add("lista");
		}
		protected override Form GetForm(string FormName){
			if ((FormName=="default") || (FormName=="versamento"))
			{
				DefaultListType="lista";
				Name = "Automatismi delle ritenute";
				return MetaData.GetFormByDllName("taxsetup_default");//PinoRana
			}
			return null;
		}		
	
		public override void SetDefaults(DataTable PrimaryTable){
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
			SetDefault(PrimaryTable, "flag", 1);
			SetDefault(PrimaryTable, "flagadminfinance", "N");
            SetDefault(PrimaryTable, "taxpaykind", "I");
		}

		public override bool IsValid(DataRow R,out string errmess, out string errfield){            
			if (!base.IsValid(R, out errmess, out errfield)) return false;                 
			if ((R["flagadminfinance"].ToString().ToLower()=="s")&&
				(R["idfinadmintax"].ToString().Trim()=="")){
				errmess="In base alle informazioni inserite Ë necessario inserire una voce di bilancio contributi.";
				errfield=null;
				return false;
			}
			if ((R["idexpirationkind"]==DBNull.Value) || (R["idexpirationkind"].ToString()=="0")){
				errmess="E' necessario selezionare una periodicit‡ valida per la ritenuta.";
				errfield=null;
				return false;
			}
            int flag = CfgFn.GetNoNullInt32(R["flag"]) & 0x07;
		    bool periodoPrecedente = (CfgFn.GetNoNullInt32(R["flag"]) & 0x08) != 0;
            int giornoPeriodicita=CfgFn.GetNoNullInt32(R["expiringday"]);
		    if (periodoPrecedente && giornoPeriodicita == 0) {
		        errmess = "Specificare il giorno di termine, nel primo mese successivo, per il periodo precedente";
		        errfield = "expiringday";
		        return false;
		    }
			if ((flag == 1) && (R["paymentagency"] == DBNull.Value))
			{
				errmess = "Specificare il percipiente a cui effettuare il versamento";
				errfield = null;
				return false;
			}

            if (R["taxpaykind"] == DBNull.Value) {
                errmess = "Specificare la modalit‡ nella quale effettuare il versamento delle ritenute";
                errfield = "taxpaykind";
                return false;
            }

			return true;
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if (ListingType=="lista")
				return base.SelectOne(ListingType, filter, "taxsetupview", Exclude);
			else
				return base.SelectOne(ListingType, filter, "taxsetup", Exclude);
		}		
	}
}

/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using metaeasylibrary;
//Pino: using persgenautomovimenti; diventato inutile
using bankdispositionsetup_trasmissione;//pergenautomovimenti_trasmissione

namespace meta_bankdispositionsetup//meta_persgenautomovimenti//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_bankdispositionsetup : Meta_easydata 
	{
		public Meta_bankdispositionsetup(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "bankdispositionsetup") 
		{
			EditTypes.Add("default");
			EditTypes.Add("siopeplus");
            EditTypes.Add("trasmissione");
            ListingTypes.Add("persgenautomovimenti");
		}
		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				DefaultListType="persgenautomovimenti";
				Name = "Configurazione";
				return MetaData.GetFormByDllName("bankdispositionsetup_default");//PinoRana
			}

            if (FormName == "siopeplus") {
                DefaultListType = "default";
                Name = "Siope+";
                return MetaData.GetFormByDllName("bankdispositionsetup_siopeplus");
            }
            if (FormName=="trasmissione"){
				Name="Esecuzione programma esterno";
                string parametro = ExtraParameter as string;
                if (parametro != null) {
                    parametro = parametro.ToString().ToLower();
                    switch (parametro) {
                        case "unicredit":
                            return GetFormByDllName("bankdispositionsetup_unicredit");
                        case "roma":
                            return GetFormByDllName("bankdispositionsetup_roma");
                        case "mps":
                            return GetFormByDllName("bankdispositionsetup_mps");
                        case "carime":
                            return GetFormByDllName("bankdispositionsetup_carime");
                        case "carimenew":
                            return GetFormByDllName("bankdispositionsetup_carimenew");
                        case "creditosiciliano":
                            return GetFormByDllName("bankdispositionsetup_creditosiciliano ");
                        case "bsondrio":
                            return GetFormByDllName("bankdispositionsetup_bsondrio");
                        case "bpcassinate":
                            return GetFormByDllName("bankdispositionsetup_bpcassinate");
                        case "bpcassinate_abi36":
                            return GetFormByDllName("bankdispositionsetup_bpcassinate_abi36");
                        case "bancodinapoli":
                            return GetFormByDllName("bankdispositionsetup_bancodinapoli");
                        case "bccirpina":
                            return GetFormByDllName("bankdispositionsetup_bccirpina");
                        case "intesasanpaolo":
                            return GetFormByDllName("bankdispositionsetup_intesasanpaolo");
                        case "bppugliese":
                            return GetFormByDllName("bankdispositionsetup_bppugliese");
                        case "bccflumeri":
                            return GetFormByDllName("bankdispositionsetup_bccflumeri");
                        case "mps_abi36":
                            return GetFormByDllName("bankdispositionsetup_mps_abi36");
                        default:
                            ShowClientMsg("Codice esportazione non previsto:" + parametro, "Avviso",MessageBoxButtons.OK);
                            return null;
                    }
                }
                

				frmPersGenAutomovimenti_Trasmissione F = 
						new frmPersGenAutomovimenti_Trasmissione(ExtraParameter.ToString());
				return F;
			}
            

			if (FormName=="importazione"){
				Name="Esecuzione programma esterno";
				string parametro = ExtraParameter==null ? "": ExtraParameter.ToString().ToLower();
				if (parametro.EndsWith(".dll")||parametro.EndsWith(".exe")) {
					frmPersGenAutomovimenti_Trasmissione F = 
						new frmPersGenAutomovimenti_Trasmissione(ExtraParameter.ToString());
					return F;
				}
				switch (parametro) {
					case "unicredit":
						return GetFormByDllName("bankdispositionsetup_unicredit");
					case "roma":
						return GetFormByDllName("bankdispositionsetup_roma");
					case "mps":
						return GetFormByDllName("bankdispositionsetup_mps");
                    case "carime":
                        return GetFormByDllName("bankdispositionsetup_carime");
                    case "carimenew":
                        return GetFormByDllName("bankdispositionsetup_creditosiciliano ");
                    case "bsondrio":
                        return GetFormByDllName("bankdispositionsetup_bsondrio");
                    case "bpcassinate":
                        return GetFormByDllName("bankdispositionsetup_bpcassinate");
                    case "bpcassinate_abi36":
                        return GetFormByDllName("bankdispositionsetup_bpcassinate_abi36");
                    case "bancodinapoli":
                        return GetFormByDllName("bankdispositionsetup_bpcassinate");
                    case "bccirpina":
                        return GetFormByDllName("bankdispositionsetup_bccirpina");
                    case "intesasanpaolo":
                        return GetFormByDllName("bankdispositionsetup_intesasanpaolo");
                    case "bppugliese":
                        return GetFormByDllName("bankdispositionsetup_bppugliese");
                    case "bccflumeri":
                        return GetFormByDllName("bankdispositionsetup_bccflumeri");
                    case "mps_abi36":
                        return GetFormByDllName("bankdispositionsetup_mps_abi36");
                    default:
                        ShowClientMsg("Codice esportazione non previsto:"+parametro, "Avviso",MessageBoxButtons.OK);
                        return null;
                }
			}
			return null;
		}		

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable,"ayear", GetSys("esercizio"));
		}
	
		public override void DescribeColumns(DataTable T, string listtype)
		{
			base.DescribeColumns(T, listtype);
			DescribeAColumn(T, "ayear", "");
		}   
	}
}


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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using resultparameter_default;//Report



namespace meta_resultparameter//meta_resultparameter//
{
	
	public class Meta_resultparameter : Meta_easydata
	{
		public Meta_resultparameter(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "resultparameter") 
		{
			EditTypes.Add("default");
			Name = "Report Parameter";
		}
		
		
		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				frmReportParameter F = new frmReportParameter();
				//	ExtraParameter  contiene il parametro da passare a BuildForm
				
			    ErrorLogger.Logger.warnEvent($"OpenForm: frmReportParameter {ExtraParameter}");
				if (F.BuildForm(ExtraParameter.ToString(),this)) return F;

			    this.LogError("Errore nella costruzione del form dei parametri. Dettaglio:" +
			                  ExtraParameter.ToString());
				QueryCreator.ShowError(null,"Non è stato possibile avviare la stampa",
					"Errore nella costruzione del form dei parametri. Dettaglio:"+
					ExtraParameter.ToString());
				return null;

			}
			return null;
		}			
	
/*		
		public override bool IsValid (DataRow R, out string errmess, out string errfield)
		{
			//Assegno le variabili poichè ho rinunciato a chiamare la base


			// E' tutto da vedere perchè non sia stata chiamata la base.
			//  Specificare la motivazione.

			errmess = "";
			errfield = "";
			
			//Per ogni colonna della riga della tabella principale
			foreach(DataColumn DC in DS.Tables["resultparameter"].Columns)
			{
				//Se il valore del determinato campo è null
				if(R[DC.ColumnName] == DBNull.Value)
				{
						//Se la colonna ammette null restituisce true
					if(DC.AllowDBNull == true) return true;
					
						//Se la colonna non ammette null e il DefaultValue è diverso da null
						//imposta il valore del campo uguale al DefaultValue
					if(DC.DefaultValue != DBNull.Value)
					{
						R[DC.ColumnName] = DC.DefaultValue;
						return true;
					}
					//Altrimenti restituisce un messaggio di errore richiedendo all'utente
					//l'inserimento di un valore valido
					errmess = "E' necessario specificare un valore diverso da null nel campo " + DC.ColumnName + ".";
					errfield = DC.ColumnName;
					return false;
				}
			}
			return true;
		}
*/

		
	
	
	}
}

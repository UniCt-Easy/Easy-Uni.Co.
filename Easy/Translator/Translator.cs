
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
using System.Data;
using System.Linq;
using System.Collections.Generic;

using metadatalibrary;

namespace Translator {
	/// <summary>
	/// Traduce oggetti associati a un parametro X e un parametro Y, tipicamente <typeparamref name="Enum">Enum</typeparamref>.
	/// Il parametro X è associato a una tabella di traduzione presente su un database mentre il parametro Y a una colonna della tabella associata a X.
	/// </summary>
	/// <typeparam name="X">Tipo del parametro associato alla tabella</typeparam>
	/// <typeparam name="Y">Tipo del parametro associato alla colonna</typeparam>
	public class Translator<X, Y> {

		/// <summary>
		/// Contiene tutti i valori del tipo X forniti al traduttore
		/// </summary>
		private readonly HashSet<X> XValues;

		/// <summary>
		/// Contiene tutti i valori del tipo Y forniti al traduttore
		/// </summary>
		private readonly HashSet<Y> YValues;

		/// <summary>
		/// Connessione al database per il recupero dei valori di traduzione
		/// </summary>
		public DataAccess dbConnection;

		/// <summary>
		/// Helper di MetaDataLibrary per la costruzione delle query alle datatable
		/// </summary>
		private readonly QueryHelper QHC;

		/// <summary>
		/// Filtro sulla tabella di traduzione per anno
		/// </summary>
		private readonly int referenceYear;

		/// <summary>
		/// Associa al parametro X una datatable di traduzione
		/// </summary>
		private readonly Dictionary<X, DataTable> tableReferences = new Dictionary<X, DataTable>();

		/// <summary>
		/// Associa alla coppia di parametri di tipo X e Y il nome di un campo sulla tabella di traduzione
		/// </summary>
		private readonly Dictionary<KeyValuePair<X, Y>, string> columnReferences = new Dictionary<KeyValuePair<X, Y>, string>();

		/// <summary>
		/// Associa alla coppia di parametri di tipo X e Y un dictionary che associa al valore da tradurre (chiave) il valore tradotto (valore)
		/// </summary>
		private readonly Dictionary<KeyValuePair<X, Y>, Dictionary<object, object>> translations = new Dictionary<KeyValuePair<X, Y>, Dictionary<object, object>>();

		/// <summary>
		/// Inizializza due HashSet che contengono i possibili valori dei due parametri X e Y, la connessione al db passata dall'esterno,
		/// un QueryHelper usato internamente per la creazione dei filtri sulle richieste a db, e un filtro relativo all'anno di attualizzazione delle tabelle.
		/// </summary>
		/// <param name="xValues">Enumerabile dei possibili valori del paramentro X</param>
		/// <param name="yValues">Enumerabile dei possibili valori del paramentro Y</param>
		/// <param name="conn">Connessione al database</param>
		/// <param name="year">Anno per cui filtrare le tabelle di traduzione</param>
		public Translator(IEnumerable<X> xValues, IEnumerable<Y> yValues, DataAccess conn, int year) {
			dbConnection = conn;
			QHC = dbConnection.GetQueryHelper();
			referenceYear = year;

			XValues = new HashSet<X>(xValues);
			YValues = new HashSet<Y>(yValues);
		}

		/// <summary>
		/// Aggiunge un'associazione tra un valore di X e una tabella di traduzione
		/// </summary>
		/// <param name="xValue">Valore di X al quale associare una tabella di traduzione</param>
		/// <param name="translationTable">Nome della tabella di traduzione</param>
		/// <returns>true se l'aggiunta è andata a buon fine, false in caso contrario</returns>
		public bool AddTableAssociation(X xValue, string translationTable) {
			DataTable tmpTable;

			try {
				tmpTable = DataAccess.CreateTableByName(dbConnection, translationTable, "*");
			}
			catch (Exception e) {
				return false;
			}

			tableReferences.Add(xValue, tmpTable);
			return true;
        }

		/// <summary>
		/// Aggiunge un'associazione tra una coppia di valori dei parametri di tipo X e Y e una colonna della tabella di traduzione
		/// </summary>
		/// <param name="parameters">Coppia di valori di X e Y alla quale associare una colonna della tabella di traduzione</param>
		/// <param name="translationColumn">Nome della colonna della tabella di traduzione</param>
		/// <returns>true se l'aggiunta è andata a buon fine, false in caso contrario</returns>
		public bool AddColumnAssociation(KeyValuePair<X, Y>parameters, string translationColumn) {
			if (tableReferences.ContainsKey(parameters.Key) && tableReferences[parameters.Key].Columns.Contains(translationColumn)) {
				columnReferences.Add(parameters, translationColumn);
				return true;
            }

			return false;
        }

		/// <summary>
		/// Consulta il database e inizializza i dictionary di traduzione interni con le associazioni aggiunte.
		/// </summary>
		public void Refresh() {

			// valutiamo una datatable per ogni valore del primo parametro X
			foreach(var xValue in XValues) {
				DataTable translationTable = tableReferences[xValue];
				dbConnection.RUN_SELECT_INTO_TABLE(translationTable, null, QHC.CmpEq("ayear", referenceYear), null, false);

				//valutiamo una colonna per ogni valore del secondo parametro Y
				foreach(var yValue in YValues) {
					var parameters = new KeyValuePair<X, Y>(xValue, yValue);
					if (!columnReferences.ContainsKey(parameters)) continue;

					var translationColumnName = columnReferences[parameters];

					var tableKeys = translationTable.Columns["id"+translationTable.TableName];
					var tableValues = translationTable.Columns[translationColumnName];
					
					// proiettiamo le due colonne in un dictionary che conterrà i valori da tradurre (key) e i valori tradotti (value)
					var translation = translationTable.AsEnumerable()
						.Select(r => new { key = r["id" + translationTable.TableName], value = r[translationColumnName] }) // proiezione di due colonne
						.Where(r => r.value.ToString() != string.Empty) // filtriamo i valori vuoti
						.ToDictionary(r => r.key, r => r.value); // mappiamo le due colonne in un dictionary

					translations.Add(parameters, translation); // aggiungiamo il dictionary di traduzione al dictionary che mappa parametri e traduzioni
				
				}
			}
		}

		/// <summary>
		/// Traduce un oggetto in base a parametri di tipo X e Y
		/// </summary>
		/// <param name="xValue">Valore del parametro di tipo X</param>
		/// <param name="yValue">Valore del parametro di tipo Y</param>
		/// <param name="toTranslate">Oggetto da tradurre</param>
		/// <param name="translated">Oggetto tradotto</param>
		/// <returns>true se la traduzione ha avuto successo, false altrimenti</returns>
		public bool TryTranslate(X xValue, Y yValue, object toTranslate, out object translated) {

			if (translations.TryGetValue(new KeyValuePair<X, Y>(xValue, yValue), out var translation)) {
				if (translation.TryGetValue(toTranslate, out object tmpTranslated)) {
					translated = tmpTranslated;
					return true;
				}
			}

			translated = null;
			return false;
		}

		/// <summary>
		/// Traduce un oggetto in base a parametri di tipo X e Y
		/// </summary>
		/// <param name="xValue">Valore del parametro di tipo X</param>
		/// <param name="yValue">Valore del parametro di tipo Y</param>
		/// <param name="toTranslate">Oggetto da tradurre</param>
		/// <returns>Oggetto tradotto</returns>
		public object Translate(X xValue, Y yValue, object toTranslate) {

			if (toTranslate == null) {
				return null;
            }

			if (!translations.TryGetValue(new KeyValuePair<X, Y>(xValue, yValue), out var translation)) {
				string message = "Tabella di traduzione per l'oggetto \"{0}\" con parametri \"{1}\" e \"{2}\" non trovata";
				throw new Exception(string.Format(message, toTranslate, xValue, yValue));
			}

			if (!translation.TryGetValue(toTranslate, out var translated)) {
				string message = "Impossibile tradurre l'oggetto con valore \"{0}\", parametri \"{1}\" e \"{2}\" utilizzando la tabella \"{3}\"";
				throw new Exception(string.Format(message, toTranslate, xValue, yValue, tableReferences[xValue].TableName));
			}

			return translated;
		}
	}
}

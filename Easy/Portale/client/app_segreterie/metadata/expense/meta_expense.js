
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


(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_expense() {
        MetaData.apply(this, ["expense"]);
        this.name = 'meta_expense';
    }

    meta_expense.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_expense,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var objCalcFieldConfig = {};
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'seg':
						this.describeAColumn(table, 'description', 'Descrizione', null, 10, 150);
						this.describeAColumn(table, 'ymov', 'Anno movimento', null, 20, null);
						this.describeAColumn(table, 'nmov', 'N.movimento', null, 30, null);
						this.describeAColumn(table, 'flag', 'Flag', null, 110, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'seg':
						table.columns["adate"].caption = "data contabile";
						table.columns["autocode"].caption = "Codice Automatismo";
						table.columns["autokind"].caption = "Tipo automatismo, descritto in tabella autokind";
						table.columns["cigcode"].caption = "Codice CIG";
						table.columns["ct"].caption = "data creazione";
						table.columns["cu"].caption = "nome utente creazione";
						table.columns["cupcode"].caption = "Codice CUP";
						table.columns["description"].caption = "Descrizione";
						table.columns["doc"].caption = "documento";
						table.columns["docdate"].caption = "data documento";
						table.columns["expiration"].caption = "scadenza";
						table.columns["external_reference"].caption = "Chiave esterna per db collegati";
						table.columns["idclawback"].caption = "Id recupero (tabella recupero)";
						table.columns["idexp"].caption = "id mov. spesa (tabella expense)";
						table.columns["idformerexpense"].caption = "id economia di spesa (idexp di expense) associata qualora questo movimento. Questo movimento è valorizzato nella maschera ct_expenselast_reset (storno residui catania) e expense_wizardcreamovcompetenza (riemissione dei movimenti in competenza)";
						table.columns["idinc_linked"].caption = "incasso collegato";
						table.columns["idpayment"].caption = "id mov. spesa collegato (idexp di expense)";
						table.columns["idreg"].caption = "id anagrafica (tabella registry)";
						table.columns["lt"].caption = "data ultima modifica";
						table.columns["lu"].caption = "nome ultimo utente modifica";
						table.columns["nmov"].caption = "N.movimento";
						table.columns["nphase"].caption = "N.fase";
						table.columns["parentidexp"].caption = "id movimento padre (idexp di tabella expense)";
						table.columns["rtf"].caption = "allegati";
						table.columns["txt"].caption = "note testuali";
						table.columns["ymov"].caption = "Anno movimento";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_expense");

				//$getNewRowInside$

				dt.autoIncrement('idexp', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},



			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('expense', new meta_expense('expense'));

	}());

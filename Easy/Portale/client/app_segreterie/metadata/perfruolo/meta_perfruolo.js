
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

    function meta_perfruolo() {
        MetaData.apply(this, ["perfruolo"]);
        this.name = 'meta_perfruolo';
    }

    meta_perfruolo.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfruolo,
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
					case 'default':
						this.describeAColumn(table, 'idperfruolo', 'Ruolo', null, 10, 50);
						this.describeAColumn(table, 'oper', 'Operatività', null, 30, null);
						this.describeAColumn(table, 'aggiorna', 'Aggiorna scheda e obiettivi', null, 100, null);
						this.describeAColumn(table, 'crea', 'Crea scheda', null, 110, null);
						this.describeAColumn(table, 'leggi', 'Visualizza scheda', null, 120, null);
						this.describeAColumn(table, 'valuta', 'Valuta obiettivi', null, 130, null);
//$objCalcFieldConfig_default$
						break;
					case 'maildest':
						this.describeAColumn(table, 'idperfruolo', 'Ruolo', null, 10, 50);
//$objCalcFieldConfig_maildest$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'maildest':
						table.columns["idperfruolo"].caption = "Ruolo";
//$innerSetCaptionConfig_maildest$
						break;
					case 'default':
						table.columns["aggiorna"].caption = "Aggiorna";
						table.columns["crea"].caption = "Crea";
						table.columns["leggi"].caption = "Visualizza";
						table.columns["oper"].caption = "Operatività";
						table.columns["valuta"].caption = "Valuta";
						table.columns["aggiorna"].caption = "Aggiorna scheda e obiettivi";
						table.columns["crea"].caption = "Crea scheda";
						table.columns["leggi"].caption = "Visualizza scheda";
						table.columns["valuta"].caption = "Valuta obiettivi";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfruolo");

				//$getNewRowInside$


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

			//$describeTree$
        });

    window.appMeta.addMeta('perfruolo', new meta_perfruolo('perfruolo'));

	}());

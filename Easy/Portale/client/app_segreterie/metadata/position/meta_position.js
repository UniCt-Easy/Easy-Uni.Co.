
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

    function meta_position() {
        MetaData.apply(this, ["position"]);
        this.name = 'meta_position';
    }

    meta_position.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_position,
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
						this.describeAColumn(table, 'description', 'Descrizione', null, 20, 50);
						this.describeAColumn(table, 'active', 'Attivo', null, 30, null);
						this.describeAColumn(table, 'codeposition', 'Codice', null, 40, 20);
//$objCalcFieldConfig_seg$
						break;
					case 'default':
						this.describeAColumn(table, 'description', 'Descrizione', null, 20, 50);
						this.describeAColumn(table, 'active', 'Attivo', null, 30, null);
						this.describeAColumn(table, 'codeposition', 'Codice', null, 40, 20);
//$objCalcFieldConfig_default$
						break;
					case 'perf':
						this.describeAColumn(table, 'description', 'Descrizione', null, 20, 50);
						this.describeAColumn(table, 'active', 'Attivo', null, 30, null);
						this.describeAColumn(table, 'codeposition', 'Codice', null, 40, 20);
//$objCalcFieldConfig_perf$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'perf':
						table.columns["active"].caption = "Attivo";
						table.columns["codeposition"].caption = "Codice";
						table.columns["description"].caption = "Descrizione";
						table.columns["ct"].caption = "data creazione";
						table.columns["cu"].caption = "nome utente creazione";
						table.columns["foreignclass"].caption = "Classe di appartenenza per Miss.all'estero";
						table.columns["idposition"].caption = "Id posiz. giuridica (tabella position)";
						table.columns["lt"].caption = "data ultima modifica";
						table.columns["lu"].caption = "nome ultimo utente modifica";
						table.columns["maxincomeclass"].caption = "Classe Stip. Max";
//$innerSetCaptionConfig_perf$
						break;
					case 'seg':
						table.columns["active"].caption = "Attivo";
						table.columns["codeposition"].caption = "Codice";
						table.columns["description"].caption = "Descrizione";
//$innerSetCaptionConfig_seg$
						break;
					case 'default':
						table.columns["active"].caption = "Attivo";
						table.columns["codeposition"].caption = "Codice";
						table.columns["ct"].caption = "data creazione";
						table.columns["cu"].caption = "nome utente creazione";
						table.columns["description"].caption = "Descrizione";
						table.columns["foreignclass"].caption = "Classe di appartenenza per Miss.all'estero";
						table.columns["idposition"].caption = "Id posiz. giuridica (tabella position)";
						table.columns["lt"].caption = "data ultima modifica";
						table.columns["lu"].caption = "nome ultimo utente modifica";
						table.columns["maxincomeclass"].caption = "Classe Stip. Max";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_position");

				//$getNewRowInside$

				dt.autoIncrement('idposition', { minimum: 99990001 });

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

    window.appMeta.addMeta('position', new meta_position('position'));

	}());

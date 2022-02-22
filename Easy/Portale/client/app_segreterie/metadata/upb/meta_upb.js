
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

    function meta_upb() {
        MetaData.apply(this, ["upb"]);
        this.name = 'meta_upb';
    }

    meta_upb.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_upb,
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
						this.describeAColumn(table, 'codeupb', 'Codice', null, 10, 50);
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 150);
						this.describeAColumn(table, 'active', 'Attivo', null, 30, null);
//$objCalcFieldConfig_seg$
						break;
					case 'default':
						this.describeAColumn(table, 'idupb', 'id voce upb (tabella upb)', null, 10, 36);
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 150);
						this.describeAColumn(table, 'active', 'Attivo', null, 30, null);
						this.describeAColumn(table, 'assured', 'Finanziamento certo (Non gestire assegnazione crediti/incassi)', null, 40, null);
						this.describeAColumn(table, 'cigcode', 'Codice CIG, Codice identificativo di gara', null, 50, 10);
						this.describeAColumn(table, 'codeupb', 'Codice', null, 60, 50);
						this.describeAColumn(table, 'cupcode', 'Codice CUP, Codice unico di progetto', null, 70, 15);
						this.describeAColumn(table, 'expiration', 'scadenza', null, 80, null);
						this.describeAColumn(table, 'flag', 'flag vari', null, 90, null);
						this.describeAColumn(table, 'flagactivity', 'Tipo attività', null, 100, null);
						this.describeAColumn(table, 'flagkind', 'Funzione', null, 110, null);
						this.describeAColumn(table, 'granted', 'Finanziamento concesso', 'fixed.2', 120, null);
						this.describeAColumn(table, 'newcodeupb', 'Codice di consolidamento', null, 220, 50);
						this.describeAColumn(table, 'previousappropriation', 'Totale impegnato pregresso (previa informatizzazione)', 'fixed.2', 240, null);
						this.describeAColumn(table, 'previousassessment', 'Totale accertato pregresso (previa informatizzazione)', 'fixed.2', 250, null);
						this.describeAColumn(table, 'printingorder', 'Ordine di stampa', null, 260, 50);
						this.describeAColumn(table, 'requested', 'Finanziamento richiesto', 'fixed.2', 270, null);
						this.describeAColumn(table, 'rtf', 'allegati', null, 280, null);
						this.describeAColumn(table, 'start', 'data inizio', null, 290, null);
						this.describeAColumn(table, 'stop', 'data fine', null, 300, null);
						this.describeAColumn(table, 'txt', 'note testuali', null, 310, null);
						this.describeAColumn(table, 'cofogmpcode', 'Cofogmpcode', null, 400, 10);
						this.describeAColumn(table, 'ri_ra_quota', 'Ri_ra_quota', 'fixed.6', 420, null);
						this.describeAColumn(table, 'ri_rb_quota', 'Ri_rb_quota', 'fixed.6', 430, null);
						this.describeAColumn(table, 'ri_sa_quota', 'Ri_sa_quota', 'fixed.6', 440, null);
						this.describeAColumn(table, 'uesiopecode', 'Uesiopecode', null, 450, 10);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_upb");

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

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "title desc";
					}
					case "default": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			},

			describeTree: function (table, listType) {
				var def = appMeta.Deferred("meta_describeTree");
				var nodedispatcher = new appMeta.SimpleUnLeveled_TreeNode_Dispatcher("title");
				var rootCondition = window.jsDataQuery.isNull("paridupb");
				return def.resolve({
					rootCondition: rootCondition,
					nodeDispatcher: nodedispatcher
				});
			}
		});

    window.appMeta.addMeta('upb', new meta_upb('upb'));

	}());

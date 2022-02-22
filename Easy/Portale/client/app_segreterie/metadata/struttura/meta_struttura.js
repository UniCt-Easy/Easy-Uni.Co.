
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

    function meta_struttura() {
        MetaData.apply(this, ["struttura"]);
        this.name = 'meta_struttura';
    }

    meta_struttura.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_struttura,
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
					case 'princ':
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 1024);
						this.describeAColumn(table, 'codice', 'Codice', null, 30, 50);
						this.describeAColumn(table, 'codiceipa', 'Codice IPA', null, 40, null);
						this.describeAColumn(table, 'email', 'E-Mail', null, 50, 200);
						this.describeAColumn(table, 'fax', 'Fax', null, 60, 50);
						this.describeAColumn(table, 'telefono', 'Telefono', null, 110, 50);
						this.describeAColumn(table, 'title_en', 'Denominazione (ENG)', null, 120, 1024);
						this.describeAColumn(table, '!idaoo_aoo_title', 'AOO', null, 71, null);
						objCalcFieldConfig['!idaoo_aoo_title'] = { tableNameLookup:'aoo_alias2', columnNameLookup:'title', columnNamekey:'idaoo' };
						this.describeAColumn(table, '!idsede_sede_title', 'Sede', null, 81, null);
						objCalcFieldConfig['!idsede_sede_title'] = { tableNameLookup:'sede_alias1', columnNameLookup:'title', columnNamekey:'idsede' };
						this.describeAColumn(table, '!idstrutturakind_strutturakind_title', 'Tipo', null, 91, null);
						objCalcFieldConfig['!idstrutturakind_strutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idstrutturakind' };
						this.describeAColumn(table, '!idupb_upb_title', 'UPB', null, 101, null);
						objCalcFieldConfig['!idupb_upb_title'] = { tableNameLookup:'upb', columnNameLookup:'title', columnNamekey:'idupb' };
//$objCalcFieldConfig_princ$
						break;
					case 'perf':
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 1024);
						this.describeAColumn(table, 'codice', 'Codice', null, 30, 50);
						this.describeAColumn(table, 'codiceipa', 'Codice IPA', null, 40, null);
//$objCalcFieldConfig_perf$
						break;
					case 'seg_child':
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 1024);
						this.describeAColumn(table, 'title_en', 'Denominazione (ENG)', null, 30, 1024);
						this.describeAColumn(table, 'codice', 'Codice', null, 40, 50);
						this.describeAColumn(table, 'email', 'E-Mail', null, 50, 200);
						this.describeAColumn(table, 'fax', 'Fax', null, 60, 50);
						this.describeAColumn(table, 'telefono', 'Telefono', null, 70, 50);
//$objCalcFieldConfig_seg_child$
						break;
					case 'default':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
						this.describeAColumn(table, 'codice', 'Codice', null, 30, 50);
//$objCalcFieldConfig_default$
						break;
					case 'perfelenchi':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
//$objCalcFieldConfig_perfelenchi$
						break;
					case 'perfelenchiparent':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 1024);
//$objCalcFieldConfig_perfelenchiparent$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'default':
						table.columns["idupb"].caption = "Unità previsionale di base (bilancio)";
						table.columns["codiceipa"].caption = "Codice IPA";
						table.columns["email"].caption = "E-Mail";
						table.columns["idaoo"].caption = "AOO";
						table.columns["idreg"].caption = "Istituto o ente o azienda";
						table.columns["idsede"].caption = "Sede";
						table.columns["idstrutturakind"].caption = "Tipo";
						table.columns["paridstruttura"].caption = "Struttura madre";
						table.columns["title"].caption = "Denominazione";
						table.columns["title_en"].caption = "Denominazione (ENG)";
//$innerSetCaptionConfig_default$
						break;
					case 'perf':
						table.columns["codiceipa"].caption = "Codice IPA";
						table.columns["email"].caption = "E-Mail";
						table.columns["idaoo"].caption = "AOO";
						table.columns["idreg"].caption = "Istituto o ente o azienda";
						table.columns["idsede"].caption = "Sede";
						table.columns["idstrutturakind"].caption = "Tipo";
						table.columns["idupb"].caption = "UPB";
						table.columns["paridstruttura"].caption = "Struttura madre";
						table.columns["pesoindicatori"].caption = "Peso della valutazione della performance degli indicatori ";
						table.columns["pesoobiettivi"].caption = "Peso della valutazione della performance degli obiettivi una tantum";
						table.columns["pesoprogaltreuo"].caption = "Peso della valutazione della performance Progetti Strategici di altre UO";
						table.columns["pesoproguo"].caption = "Peso della valutazione della performance dei Progetti Strategici della UO";
						table.columns["title"].caption = "Denominazione";
						table.columns["title_en"].caption = "Denominazione (ENG)";
						table.columns["idreg"].caption = "Istituto o ente o azienda";
//$innerSetCaptionConfig_perf$
						break;
					case 'princ':
						table.columns["codiceipa"].caption = "Codice IPA";
//$innerSetCaptionConfig_princ$
						break;
					case 'seg_child':
						table.columns["codiceipa"].caption = "Codice IPA";
//$innerSetCaptionConfig_seg_child$
						break;
					case 'perfelenchi':
						table.columns["codiceipa"].caption = "Codice IPA";
						table.columns["email"].caption = "E-Mail";
						table.columns["idaoo"].caption = "AOO";
						table.columns["idreg"].caption = "Istituto o ente o azienda";
						table.columns["idsede"].caption = "Sede";
						table.columns["idstrutturakind"].caption = "Tipo";
						table.columns["idupb"].caption = "Unità previsionale di base (bilancio)";
						table.columns["paridstruttura"].caption = "Struttura madre";
						table.columns["title"].caption = "Denominazione";
						table.columns["title_en"].caption = "Denominazione (ENG)";
						table.columns["paridstruttura"].caption = "U.O. madre";
//$innerSetCaptionConfig_perfelenchi$
						break;
					case 'perfelenchiparent':
						table.columns["codiceipa"].caption = "Codice IPA";
						table.columns["email"].caption = "E-Mail";
						table.columns["idaoo"].caption = "AOO";
						table.columns["idreg"].caption = "Istituto o ente o azienda";
						table.columns["idsede"].caption = "Sede";
						table.columns["idstrutturakind"].caption = "Tipo";
						table.columns["idupb"].caption = "Unità previsionale di base (bilancio)";
						table.columns["paridstruttura"].caption = "Struttura madre";
						table.columns["title"].caption = "Denominazione";
						table.columns["title_en"].caption = "Denominazione (ENG)";
//$innerSetCaptionConfig_perfelenchiparent$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_struttura");

				//$getNewRowInside$

				dt.autoIncrement('idstruttura', { minimum: 99990001 });

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
					case "perf": {
						return "title desc";
					}
					case "princ": {
						return "title asc ";
					}
					case "seg_child": {
						return "title asc ";
					}
					case "default": {
						return "title asc ";
					}
					case "perfelenchi": {
						return "title asc ";
					}
					case "perfelenchiparent": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			},

			describeTree: function (table, listType) {
				var def = appMeta.Deferred("meta_describeTree");
				var nodedispatcher = new appMeta.SimpleUnLeveled_TreeNode_Dispatcher("title");
				var rootCondition = window.jsDataQuery.isNull("paridstruttura");
				return def.resolve({
					rootCondition: rootCondition,
					nodeDispatcher: nodedispatcher
				});
			}
		});

    window.appMeta.addMeta('struttura', new meta_struttura('struttura'));

	}());

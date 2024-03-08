(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registry_istituti() {
        MetaData.apply(this, ["registry_istituti"]);
        this.name = 'meta_registry_istituti';
    }

    meta_registry_istituti.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registry_istituti,
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
					case 'istituti_princ':
						this.describeAColumn(table, 'codicemiur', 'Codice MIUR', null, 10, 50);
						this.describeAColumn(table, 'codiceustat', 'Codice USTAT', null, 20, 50);
						this.describeAColumn(table, 'comune', 'Comune', null, 30, 64);
						this.describeAColumn(table, 'idistitutoustat', 'Codice USTAT', null, 50, null);
						this.describeAColumn(table, 'nome', 'Denominazione breve', null, 70, null);
						this.describeAColumn(table, 'sortcode', 'Sortcode', null, 80, null);
						this.describeAColumn(table, 'title_en', 'Denominazione (ENG)', null, 90, 256);
//$objCalcFieldConfig_istituti_princ$
						break;
					case 'istituti':
						this.describeAColumn(table, 'idreg', 'Codice', null, 10, null);
						this.describeAColumn(table, 'codicemiur', 'Codice MIUR', null, 40, 50);
//$objCalcFieldConfig_istituti$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'istituti_princ':
						table.columns["codicemiur"].caption = "Codice MIUR";
						table.columns["codiceustat"].caption = "Codice USTAT";
						table.columns["comune"].caption = "Comune";
						table.columns["idistitutokind"].caption = "Tipologia";
						table.columns["idistitutoustat"].caption = "Codice USTAT";
						table.columns["idreg"].caption = "Codice";
						table.columns["nome"].caption = "Denominazione breve";
						table.columns["title_en"].caption = "Denominazione (ENG)";
//$innerSetCaptionConfig_istituti_princ$
						break;
					case 'istituti':
						table.columns["codicemiur"].caption = "Codice MIUR";
//$innerSetCaptionConfig_istituti$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_registry_istituti");

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
					case "istituti_princ": {
						return "title asc ";
					}
					case "istituti": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registry_istituti', new meta_registry_istituti('registry_istituti'));

	}());

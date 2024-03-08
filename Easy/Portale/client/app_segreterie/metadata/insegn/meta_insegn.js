(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_insegn() {
        MetaData.apply(this, ["insegn"]);
        this.name = 'meta_insegn';
    }

    meta_insegn.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_insegn,
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
						this.describeAColumn(table, 'codice', 'Codice', null, 10, 50);
						this.describeAColumn(table, 'denominazione', 'Denominazione', null, 20, 256);
//$objCalcFieldConfig_default$
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
						table.columns["denominazione_en"].caption = "Denominazione in inglese";
						table.columns["idcorsostudio"].caption = "Corso di riferimento";
						table.columns["idcorsostudiokind"].caption = "Tipologia di corso";
						table.columns["idstruttura"].caption = "Struttura didattica di riferimento";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_insegn");

				//$getNewRowInside$

				dt.autoIncrement('idinsegn', { minimum: 99990001 });

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
					case "default": {
						return "denominazione asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('insegn', new meta_insegn('insegn'));

	}());

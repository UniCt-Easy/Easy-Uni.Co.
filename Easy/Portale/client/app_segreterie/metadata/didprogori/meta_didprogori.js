﻿(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_didprogori() {
        MetaData.apply(this, ["didprogori"]);
        this.name = 'meta_didprogori';
    }

    meta_didprogori.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_didprogori,
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
					case 'sceltacorso':
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 256);
						this.describeAColumn(table, 'codice', 'Codice', null, 30, 50);
//$objCalcFieldConfig_sceltacorso$
						break;
					case 'default':
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 256);
						this.describeAColumn(table, 'codice', 'Codice', null, 30, 50);
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
				var def = appMeta.Deferred("getNewRow-meta_didprogori");

				//$getNewRowInside$

				dt.autoIncrement('iddidprogori', { minimum: 99990001 });

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
					case "sceltacorso": {
						return "title asc ";
					}
					case "default": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('didprogori', new meta_didprogori('didprogori'));

	}());

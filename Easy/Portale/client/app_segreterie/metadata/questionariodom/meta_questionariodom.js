﻿(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_questionariodom() {
        MetaData.apply(this, ["questionariodom"]);
        this.name = 'meta_questionariodom';
    }

    meta_questionariodom.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_questionariodom,
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
						this.describeAColumn(table, 'domanda', 'Domanda', null, 20, 2048);
						this.describeAColumn(table, 'indicedom', 'Ordinamento', null, 50, null);
						this.describeAColumn(table, '!idquestionariodomkind_questionariodomkind_title', 'Tipologia', null, 41, null);
						objCalcFieldConfig['!idquestionariodomkind_questionariodomkind_title'] = { tableNameLookup:'questionariodomkind', columnNameLookup:'title', columnNamekey:'idquestionariodomkind' };
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
               var def = appMeta.Deferred("getNewRow-meta_questionariodom");

				//$getNewRowInside$

				dt.autoIncrement('idquestionariodom', { minimum: 99990001 });

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
						return "indicedom asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('questionariodom', new meta_questionariodom('questionariodom'));

	}());

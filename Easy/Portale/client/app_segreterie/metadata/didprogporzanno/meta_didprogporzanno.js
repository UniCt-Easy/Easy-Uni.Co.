﻿(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_didprogporzanno() {
        MetaData.apply(this, ["didprogporzanno"]);
        this.name = 'meta_didprogporzanno';
    }

    meta_didprogporzanno.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_didprogporzanno,
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
						this.describeAColumn(table, 'indice', 'Indice', null, 10, null);
						this.describeAColumn(table, '!iddidprogporzannokind_didprogporzannokind_title', 'Durata', null, 21, null);
						objCalcFieldConfig['!iddidprogporzannokind_didprogporzannokind_title'] = { tableNameLookup:'didprogporzannokind', columnNameLookup:'title', columnNamekey:'iddidprogporzannokind' };
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
				var def = appMeta.Deferred("getNewRow-meta_didprogporzanno");

				//$getNewRowInside$

				dt.autoIncrement('iddidprogporzanno', { minimum: 99990001 });

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
						return "indice desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('didprogporzanno', new meta_didprogporzanno('didprogporzanno'));

	}());

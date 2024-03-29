﻿(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_aoo() {
        MetaData.apply(this, ["aoo"]);
        this.name = 'meta_aoo';
    }

    meta_aoo.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_aoo,
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
						this.describeAColumn(table, '!idsede_sede_title', 'Sede', null, 41, null);
						objCalcFieldConfig['!idsede_sede_title'] = { tableNameLookup:'sede', columnNameLookup:'title', columnNamekey:'idsede' };
//$objCalcFieldConfig_princ$
						break;
					case 'default':
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 1024);
						this.describeAColumn(table, 'codiceaooipa', 'Codice IPA', null, 30, 50);
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
               var def = appMeta.Deferred("getNewRow-meta_aoo");

				//$getNewRowInside$

				dt.autoIncrement('idaoo', { minimum: 99990001 });

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
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('aoo', new meta_aoo('aoo'));

	}());

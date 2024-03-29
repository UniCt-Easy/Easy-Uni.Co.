﻿(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_fasciaisee() {
        MetaData.apply(this, ["fasciaisee"]);
        this.name = 'meta_fasciaisee';
    }

    meta_fasciaisee.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_fasciaisee,
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
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 50);
						this.describeAColumn(table, 'numero', 'Numero', null, 30, null);
						this.describeAColumn(table, 'redditomin', 'Reddito Minimo', 'fixed.2', 40, null);
						this.describeAColumn(table, 'redditomax', 'Reddito massimo', 'fixed.2', 50, null);
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
				var def = appMeta.Deferred("getNewRow-meta_fasciaisee");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$


				// metto i default
				var objRow = dt.newRow({
					//$getNewRowDefault$
				}, realParentObjectRow);

				// torno la dataRow creata
				return def.resolve(objRow.getRow());
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

    window.appMeta.addMeta('fasciaisee', new meta_fasciaisee('fasciaisee'));

	}());

(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_debito() {
        MetaData.apply(this, ["debito"]);
        this.name = 'meta_debito';
    }

    meta_debito.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_debito,
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
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 2024);
						this.describeAColumn(table, 'codicebollettino', 'Codicebollettino', null, 30, null);
						this.describeAColumn(table, 'codicemav', 'Codicemav', null, 40, 50);
						this.describeAColumn(table, 'IUV', 'IUV', null, 100, null);
						this.describeAColumn(table, 'scadenza', 'Scadenza', null, 110, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_debito");

				//$getNewRowInside$

				dt.autoIncrement('iddebito', { minimum: 99990001 });

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
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('debito', new meta_debito('debito'));

	}());

(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_convenzione() {
        MetaData.apply(this, ["convenzione"]);
        this.name = 'meta_convenzione';
    }

    meta_convenzione.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_convenzione,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 256);
						this.describeAColumn(table, 'start', 'Data di inizio', null, 40, null);
						this.describeAColumn(table, 'stop', 'Data di fine', null, 50, null);
						this.describeAColumn(table, 'url', 'URL', null, 60, 512);
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
               var def = appMeta.Deferred("getNewRow-meta_convenzione");

				//$getNewRowInside$

				dt.autoIncrement('idconvenzione', { minimum: 99990001 });

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
						return "idreg desc, title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('convenzione', new meta_convenzione('convenzione'));

	}());

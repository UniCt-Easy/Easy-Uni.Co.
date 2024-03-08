(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettotestokind() {
        MetaData.apply(this, ["progettotestokind"]);
        this.name = 'meta_progettotestokind';
    }

    meta_progettotestokind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettotestokind,
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
						this.describeAColumn(table, 'sortcode', 'Ordine di presentazione', null, 30, null);
						this.describeAColumn(table, 'titolo', 'Titolo', null, 40, 2048);
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
               var def = appMeta.Deferred("getNewRow-meta_progettotestokind");

				//$getNewRowInside$

				dt.autoIncrement('idprogettotestokind', { minimum: 99990001 });

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
						return "sortcode";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('progettotestokind', new meta_progettotestokind('progettotestokind'));

	}());

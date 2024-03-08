(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_accordoscambiomi() {
        MetaData.apply(this, ["accordoscambiomi"]);
        this.name = 'meta_accordoscambiomi';
    }

    meta_accordoscambiomi.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_accordoscambiomi,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 10, -1);
						this.describeAColumn(table, 'aa_start', 'Anno accademico di inizio', null, 30, 9);
						this.describeAColumn(table, 'aa_stop', 'Anno accademico di fine', null, 40, 9);
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
               var def = appMeta.Deferred("getNewRow-meta_accordoscambiomi");

				//$getNewRowInside$

				dt.autoIncrement('idaccordoscambiomi', { minimum: 99990001 });

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

    window.appMeta.addMeta('accordoscambiomi', new meta_accordoscambiomi('accordoscambiomi'));

	}());

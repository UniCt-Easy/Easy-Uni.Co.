(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_orakind() {
        MetaData.apply(this, ["orakind"]);
        this.name = 'meta_orakind';
    }

    meta_orakind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_orakind,
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
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 50);
						this.describeAColumn(table, 'active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'sortcode', 'Ordinamento', null, 50, null);
						this.describeAColumn(table, 'ripetizioni', 'Consente ripetizioni', null, 60, null);
//$objCalcFieldConfig_seg$
						break;
					case 'seg_child':
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 50);
//$objCalcFieldConfig_seg_child$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_orakind");

				//$getNewRowInside$

				dt.autoIncrement('idorakind', { minimum: 99990001 });

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
						return "sortcode asc ";
					}
					case "seg_child": {
						return "sortcode";
					}
					case "seg": {
						return "sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('orakind', new meta_orakind('orakind'));

	}());

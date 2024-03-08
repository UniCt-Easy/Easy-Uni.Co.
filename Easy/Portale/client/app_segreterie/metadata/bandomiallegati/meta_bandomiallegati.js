(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_bandomiallegati() {
        MetaData.apply(this, ["bandomiallegati"]);
        this.name = 'meta_bandomiallegati';
    }

    meta_bandomiallegati.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_bandomiallegati,
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
						this.describeAColumn(table, 'idbandomiallegati', 'Allegato', null, 70, null);
						this.describeAColumn(table, 'title', 'Titolo', null, 80, 2048);
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
               var def = appMeta.Deferred("getNewRow-meta_bandomiallegati");

				//$getNewRowInside$

				dt.autoIncrement('idbandomiallegati', { minimum: 99990001 });

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

    window.appMeta.addMeta('bandomiallegati', new meta_bandomiallegati('bandomiallegati'));

	}());

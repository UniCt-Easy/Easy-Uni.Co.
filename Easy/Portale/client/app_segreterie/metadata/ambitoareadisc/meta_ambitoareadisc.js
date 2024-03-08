(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_ambitoareadisc() {
        MetaData.apply(this, ["ambitoareadisc"]);
        this.name = 'meta_ambitoareadisc';
    }

    meta_ambitoareadisc.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_ambitoareadisc,
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
						this.describeAColumn(table, 'title', 'Ambito', null, 20, 256);
						this.describeAColumn(table, 'sortcode', 'Ordinamento', null, 60, null);
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
               var def = appMeta.Deferred("getNewRow-meta_ambitoareadisc");

				//$getNewRowInside$

				dt.autoIncrement('idambitoareadisc', { minimum: 99990001 });

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
						return "idclassescuola desc, idtipoattform desc, sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('ambitoareadisc', new meta_ambitoareadisc('ambitoareadisc'));

	}());

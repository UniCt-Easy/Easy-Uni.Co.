(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_didprogdatepiano() {
        MetaData.apply(this, ["didprogdatepiano"]);
        this.name = 'meta_didprogdatepiano';
    }

    meta_didprogdatepiano.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_didprogdatepiano,
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
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 10, 9);
						this.describeAColumn(table, 'start', 'Dal', null, 40, null);
						this.describeAColumn(table, 'stop', 'Al', null, 50, null);
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
               var def = appMeta.Deferred("getNewRow-meta_didprogdatepiano");

				//$getNewRowInside$

				dt.autoIncrement('iddidprogdatepiano', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},



			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('didprogdatepiano', new meta_didprogdatepiano('didprogdatepiano'));

	}());

(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettoproroga() {
        MetaData.apply(this, ["progettoproroga"]);
        this.name = 'meta_progettoproroga';
    }

    meta_progettoproroga.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettoproroga,
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
						this.describeAColumn(table, 'motivazioni', 'Motivazioni', null, 30, -1);
						this.describeAColumn(table, 'proroga', 'Proroga', null, 40, null);
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
               var def = appMeta.Deferred("getNewRow-meta_progettoproroga");

				//$getNewRowInside$

				dt.autoIncrement('idprogettoproroga', { minimum: 99990001 });

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

    window.appMeta.addMeta('progettoproroga', new meta_progettoproroga('progettoproroga'));

	}());

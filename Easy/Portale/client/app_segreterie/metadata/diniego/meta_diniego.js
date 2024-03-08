(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_diniego() {
        MetaData.apply(this, ["diniego"]);
        this.name = 'meta_diniego';
    }

    meta_diniego.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_diniego,
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
					case 'seganagstupre':
						this.describeAColumn(table, 'data', 'Data', 'g', 10, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 20, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 30, null);
//$objCalcFieldConfig_seganagstupre$
						break;
					case 'seganagsturin':
						this.describeAColumn(table, 'data', 'Data', 'g', 10, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 20, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 30, null);
//$objCalcFieldConfig_seganagsturin$
						break;
					case 'segpratica':
						this.describeAColumn(table, 'data', 'Data', 'g', 10, null);
						this.describeAColumn(table, 'protnumero', 'Numero di protocollo', null, 20, null);
						this.describeAColumn(table, 'protanno', 'Anno di protocollo', null, 30, null);
//$objCalcFieldConfig_segpratica$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_diniego");

				//$getNewRowInside$

				dt.autoIncrement('iddiniego', { minimum: 99990001 });

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

    window.appMeta.addMeta('diniego', new meta_diniego('diniego'));

	}());

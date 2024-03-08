(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_attivformvalutazionekind() {
        MetaData.apply(this, ["attivformvalutazionekind"]);
        this.name = 'meta_attivformvalutazionekind';
    }

    meta_attivformvalutazionekind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_attivformvalutazionekind,
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
						this.describeAColumn(table, '!idvalutazionekind_valutazionekind_title', 'Codice', null, 21, null);
						objCalcFieldConfig['!idvalutazionekind_valutazionekind_title'] = { tableNameLookup:'valutazionekind', columnNameLookup:'title', columnNamekey:'idvalutazionekind' };
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
               var def = appMeta.Deferred("getNewRow-meta_attivformvalutazionekind");

				//$getNewRowInside$


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

    window.appMeta.addMeta('attivformvalutazionekind', new meta_attivformvalutazionekind('attivformvalutazionekind'));

	}());

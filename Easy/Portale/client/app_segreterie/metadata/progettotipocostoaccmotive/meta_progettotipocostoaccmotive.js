(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettotipocostoaccmotive() {
        MetaData.apply(this, ["progettotipocostoaccmotive"]);
        this.name = 'meta_progettotipocostoaccmotive';
    }

    meta_progettotipocostoaccmotive.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettotipocostoaccmotive,
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
						this.describeAColumn(table, '!idaccmotive_accmotive_title', 'Causale', null, 11, null);
						this.describeAColumn(table, '!idaccmotive_accmotive_codemotive', 'Codice', null, 12, null);
						objCalcFieldConfig['!idaccmotive_accmotive_title'] = { tableNameLookup:'accmotive', columnNameLookup:'title', columnNamekey:'idaccmotive' };
						objCalcFieldConfig['!idaccmotive_accmotive_codemotive'] = { tableNameLookup:'accmotive', columnNameLookup:'codemotive', columnNamekey:'idaccmotive' };
						this.describeAColumn(table, '!idaccmotive_accmotive_title', 'Causale', null, 13, null);
						this.describeAColumn(table, '!idaccmotive_accmotive_codemotive', 'Codice', null, 16, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'seg':
						table.columns["idaccmotive"].caption = "Causale economico patrimoniale";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettotipocostoaccmotive");

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

    window.appMeta.addMeta('progettotipocostoaccmotive', new meta_progettotipocostoaccmotive('progettotipocostoaccmotive'));

	}());

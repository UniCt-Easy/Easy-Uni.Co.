(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_dichiar_disabil() {
        MetaData.apply(this, ["dichiar_disabil"]);
        this.name = 'meta_dichiar_disabil';
    }

    meta_dichiar_disabil.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_dichiar_disabil,
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
					case 'disabil_seg':
						this.describeAColumn(table, 'percentuale', 'Percentuale', 'fixed.2', 550, null);
						this.describeAColumn(table, 'permanente', 'Permanente (S/N)', null, 560, null);
						this.describeAColumn(table, 'scadenza', 'Data scadenza', null, 570, null);
//$objCalcFieldConfig_disabil_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_dichiar_disabil");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$


				// metto i default
				var objRow = dt.newRow({
					idreg : 0,
					//$getNewRowDefault$
				}, realParentObjectRow);

				// torno la dataRow creata
				return def.resolve(objRow.getRow());
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('dichiar_disabil', new meta_dichiar_disabil('dichiar_disabil'));

	}());

(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettosettoreerc() {
        MetaData.apply(this, ["progettosettoreerc"]);
        this.name = 'meta_progettosettoreerc';
    }

    meta_progettosettoreerc.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettosettoreerc,
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
						this.describeAColumn(table, '!idsettoreerc_settoreerc_title', 'Settore ERC', null, 23, null);
						objCalcFieldConfig['!idsettoreerc_settoreerc_title'] = { tableNameLookup:'settoreerc', columnNameLookup:'title', columnNamekey:'idsettoreerc' };
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
						table.columns["idsettoreerc"].caption = "Settore ERC";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettosettoreerc");

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

    window.appMeta.addMeta('progettosettoreerc', new meta_progettosettoreerc('progettosettoreerc'));

	}());

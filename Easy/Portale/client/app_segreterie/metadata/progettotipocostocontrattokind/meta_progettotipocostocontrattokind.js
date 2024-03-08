(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettotipocostocontrattokind() {
        MetaData.apply(this, ["progettotipocostocontrattokind"]);
        this.name = 'meta_progettotipocostocontrattokind';
    }

    meta_progettotipocostocontrattokind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettotipocostocontrattokind,
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
						this.describeAColumn(table, 'idposition', 'Tipo di contratto', null, 10, null);
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
						table.columns["idposition"].caption = "Tipo di contratto";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettotipocostocontrattokind");

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

    window.appMeta.addMeta('progettotipocostocontrattokind', new meta_progettotipocostocontrattokind('progettotipocostocontrattokind'));

	}());

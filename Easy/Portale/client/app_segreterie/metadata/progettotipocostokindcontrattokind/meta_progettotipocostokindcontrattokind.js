(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettotipocostokindcontrattokind() {
        MetaData.apply(this, ["progettotipocostokindcontrattokind"]);
        this.name = 'meta_progettotipocostokindcontrattokind';
    }

    meta_progettotipocostokindcontrattokind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettotipocostokindcontrattokind,
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
               var def = appMeta.Deferred("getNewRow-meta_progettotipocostokindcontrattokind");

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

    window.appMeta.addMeta('progettotipocostokindcontrattokind', new meta_progettotipocostokindcontrattokind('progettotipocostokindcontrattokind'));

	}());

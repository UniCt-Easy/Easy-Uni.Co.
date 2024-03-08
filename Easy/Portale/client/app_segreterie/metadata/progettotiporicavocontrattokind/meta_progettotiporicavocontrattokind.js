(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettotiporicavocontrattokind() {
        MetaData.apply(this, ["progettotiporicavocontrattokind"]);
        this.name = 'meta_progettotiporicavocontrattokind';
    }

    meta_progettotiporicavocontrattokind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettotiporicavocontrattokind,
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
						this.describeAColumn(table, 'idposition', 'Tipologia contrattuale', null, 10, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'default':
						table.columns["idposition"].caption = "Tipologia contrattuale";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettotiporicavocontrattokind");

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

			//$describeTree$
        });

    window.appMeta.addMeta('progettotiporicavocontrattokind', new meta_progettotiporicavocontrattokind('progettotiporicavocontrattokind'));

	}());

(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_tassaistanzaconf() {
        MetaData.apply(this, ["tassaistanzaconf"]);
        this.name = 'meta_tassaistanzaconf';
    }

    meta_tassaistanzaconf.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tassaistanzaconf,
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
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'nullaosta', 'Nullaosta', null, 50, null);
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
						table.columns["aa"].caption = "Anno accademico";
						table.columns["idcostoscontodef"].caption = "Costo";
						table.columns["idistanzakind"].caption = "Tipo di istanza";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_tassaistanzaconf");

				//$getNewRowInside$

				dt.autoIncrement('idtassaistanzaconf', { minimum: 99990001 });

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

    window.appMeta.addMeta('tassaistanzaconf', new meta_tassaistanzaconf('tassaistanzaconf'));

	}());

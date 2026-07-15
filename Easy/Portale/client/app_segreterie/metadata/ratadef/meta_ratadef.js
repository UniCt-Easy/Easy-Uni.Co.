(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_ratadef() {
        MetaData.apply(this, ["ratadef"]);
        this.name = 'meta_ratadef';
    }

    meta_ratadef.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_ratadef,
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
					case 'more':
						this.describeAColumn(table, 'idratakind', 'Tipologia', null, 10, 50);
						this.describeAColumn(table, 'decorrenza', 'Decorrenza', 'g', 20, null);
						this.describeAColumn(table, 'scadenza', 'Scadenza', 'g', 60, null);
//$objCalcFieldConfig_more$
						break;
					case 'sconti':
						this.describeAColumn(table, 'idratakind', 'Tipologia', null, 10, 50);
						this.describeAColumn(table, 'decorrenza', 'Decorrenza', 'g', 20, null);
						this.describeAColumn(table, 'scadenza', 'Scadenza', 'g', 60, null);
//$objCalcFieldConfig_sconti$
						break;
					case 'default':
						this.describeAColumn(table, 'idratakind', 'Tipologia', null, 10, 50);
						this.describeAColumn(table, 'decorrenza', 'Decorrenza', 'g', 20, null);
						this.describeAColumn(table, 'scadenza', 'Scadenza', 'g', 60, null);
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
					case 'more':
						table.columns["idratakind"].caption = "Tipologia";
//$innerSetCaptionConfig_more$
						break;
					case 'sconti':
//$innerSetCaptionConfig_sconti$
						break;
					case 'default':
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_ratadef");

				//$getNewRowInside$

				dt.autoIncrement('idratadef', { minimum: 99990001 });

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

    window.appMeta.addMeta('ratadef', new meta_ratadef('ratadef'));

	}());

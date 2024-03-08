(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_fasciaiseedef() {
        MetaData.apply(this, ["fasciaiseedef"]);
        this.name = 'meta_fasciaiseedef';
    }

    meta_fasciaiseedef.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_fasciaiseedef,
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
						this.describeAColumn(table, 'idfasciaisee', 'Fascia ISEE', null, 30, 50);
//$objCalcFieldConfig_more$
						break;
					case 'sconti':
						this.describeAColumn(table, 'idfasciaisee', 'Fascia ISEE', null, 30, 50);
//$objCalcFieldConfig_sconti$
						break;
					case 'default':
						this.describeAColumn(table, 'idfasciaisee', 'Fascia ISEE', null, 30, 50);
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
						table.columns["idfasciaisee"].caption = "Fascia ISEE";
//$innerSetCaptionConfig_more$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_fasciaiseedef");

				//$getNewRowInside$

				dt.autoIncrement('idfasciaiseedef', { minimum: 99990001 });

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

    window.appMeta.addMeta('fasciaiseedef', new meta_fasciaiseedef('fasciaiseedef'));

	}());

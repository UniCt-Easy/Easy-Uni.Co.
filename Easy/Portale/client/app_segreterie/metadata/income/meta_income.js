﻿(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_income() {
        MetaData.apply(this, ["income"]);
        this.name = 'meta_income';
    }

    meta_income.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_income,
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
						this.describeAColumn(table, 'description', 'Descrizione', null, 10, 150);
						this.describeAColumn(table, 'ymov', 'Anno movimento', null, 20, null);
						this.describeAColumn(table, 'nmov', 'Numero movimento', null, 30, null);
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
						table.columns["nmov"].caption = "Numero movimento";
						table.columns["ymov"].caption = "Anno movimento";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_income");

				//$getNewRowInside$

				dt.autoIncrement('idinc', { minimum: 99990001 });

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

    window.appMeta.addMeta('income', new meta_income('income'));

	}());

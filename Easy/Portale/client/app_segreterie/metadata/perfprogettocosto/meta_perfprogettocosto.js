(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfprogettocosto() {
        MetaData.apply(this, ["perfprogettocosto"]);
        this.name = 'meta_perfprogettocosto';
    }

    meta_perfprogettocosto.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettocosto,
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
						this.describeAColumn(table, 'year', 'Anno', null, 10, null);
						this.describeAColumn(table, 'budget', 'Budget preventivato', 'fixed.2', 40, null);
						this.describeAColumn(table, 'budgetcurr', 'Budget attuale', 'fixed.2', 50, null);
						this.describeAColumn(table, 'consuntivo', 'Consuntivo', 'fixed.2', 60, null);
						this.describeAColumn(table, '!idaccmotive_accmotive_codemotive', 'Codice Voce di costo', null, 21, null);
						this.describeAColumn(table, '!idaccmotive_accmotive_title', 'Denominazione Voce di costo', null, 22, null);
						objCalcFieldConfig['!idaccmotive_accmotive_codemotive'] = { tableNameLookup:'accmotive', columnNameLookup:'codemotive', columnNamekey:'idaccmotive' };
						objCalcFieldConfig['!idaccmotive_accmotive_title'] = { tableNameLookup:'accmotive', columnNameLookup:'title', columnNamekey:'idaccmotive' };
						this.describeAColumn(table, '!idupb_upb_title', 'UPB', null, 31, null);
						objCalcFieldConfig['!idupb_upb_title'] = { tableNameLookup:'upb', columnNameLookup:'title', columnNamekey:'idupb' };
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
						table.columns["budget"].caption = "Budget preventivato";
						table.columns["budgetcurr"].caption = "Budget attuale";
						table.columns["consuntivo"].caption = "Consuntivo";
						table.columns["idaccmotive"].caption = "Voce di costo";
						table.columns["idupb"].caption = "UPB";
						table.columns["year"].caption = "Anno";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfprogettocosto");

				//$getNewRowInside$

				dt.autoIncrement('idperfprogettocosto', { minimum: 99990001 });

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

    window.appMeta.addMeta('perfprogettocosto', new meta_perfprogettocosto('perfprogettocosto'));

	}());

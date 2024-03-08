(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettobudgetvariazione() {
        MetaData.apply(this, ["progettobudgetvariazione"]);
        this.name = 'meta_progettobudgetvariazione';
    }

    meta_progettobudgetvariazione.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettobudgetvariazione,
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
						this.describeAColumn(table, 'newamount', 'Nuovo budget', 'fixed.2', 60, null);
						this.describeAColumn(table, 'data', 'Data variazione', null, 110, null);
						this.describeAColumn(table, '!idaccmotive_accmotive_codemotive', 'Codice Causale economico patrimoniale', null, 21, null);
						this.describeAColumn(table, '!idaccmotive_accmotive_title', 'Denominazione Causale economico patrimoniale', null, 22, null);
						objCalcFieldConfig['!idaccmotive_accmotive_codemotive'] = { tableNameLookup:'accmotive', columnNameLookup:'codemotive', columnNamekey:'idaccmotive' };
						objCalcFieldConfig['!idaccmotive_accmotive_title'] = { tableNameLookup:'accmotive', columnNameLookup:'title', columnNamekey:'idaccmotive' };
						this.describeAColumn(table, '!idupb_upb_title', 'Unità previsionale di base (UPB)', null, 11, null);
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
						table.columns["data"].caption = "Data variazione";
						table.columns["idaccmotive"].caption = "Causale economico patrimoniale";
						table.columns["idupb"].caption = "Unità previsionale di base (UPB)";
						table.columns["newamount"].caption = "Nuovo budget";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettobudgetvariazione");

				//$getNewRowInside$

				dt.autoIncrement('idprogettobudgetvariazione', { minimum: 99990001 });

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

    window.appMeta.addMeta('progettobudgetvariazione', new meta_progettobudgetvariazione('progettobudgetvariazione'));

	}());

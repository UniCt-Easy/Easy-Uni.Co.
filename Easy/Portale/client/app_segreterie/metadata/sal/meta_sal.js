(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_sal() {
        MetaData.apply(this, ["sal"]);
        this.name = 'meta_sal';
    }

    meta_sal.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_sal,
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
						this.describeAColumn(table, 'start', 'Data di inizio', null, 10, null);
						this.describeAColumn(table, 'stop', 'Data di fine', null, 40, null);
						this.describeAColumn(table, 'budget', 'Budget preventivato', 'fixed.2', 50, null);
						this.describeAColumn(table, '!budgetcalcolato', 'Budget calcolato', 'fixed.2', 60, null);
						this.describeAColumn(table, 'datablocco', 'Data di Blocco', null, 70, null);
//$objCalcFieldConfig_default$
						break;
					case 'elenchi':
						this.describeAColumn(table, 'start', 'Data di inizio', null, 10, null);
						this.describeAColumn(table, 'stop', 'Data di fine', null, 40, null);
						this.describeAColumn(table, 'datablocco', 'Data di Blocco', null, 70, null);
//$objCalcFieldConfig_elenchi$
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
						table.columns["!budgetcalcolato"].caption = "Budget calcolato";
						table.columns["budget"].caption = "Budget preventivato";
						table.columns["datablocco"].caption = "Data di Blocco";
						table.columns["idprogetto"].caption = "Progetto";
						table.columns["idsal"].caption = "SAL";
						table.columns["start"].caption = "Data di inizio";
						table.columns["stop"].caption = "Data di fine";
//$innerSetCaptionConfig_default$
						break;
					case 'elenchi':
						table.columns["budget"].caption = "Budget preventivato";
						table.columns["datablocco"].caption = "Data di Blocco";
						table.columns["idprogetto"].caption = "Progetto";
						table.columns["idsal"].caption = "SAL";
						table.columns["start"].caption = "Data di inizio";
						table.columns["stop"].caption = "Data di fine";
						table.columns["!budgetcalcolato"].caption = "Budget calcolato";
//$innerSetCaptionConfig_elenchi$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_sal");

				//$getNewRowInside$

				dt.autoIncrement('idsal', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},



			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "start asc ";
					}
					case "elenchi": {
						return "start asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('sal', new meta_sal('sal'));

	}());

(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettobudget() {
        MetaData.apply(this, ["progettobudget"]);
        this.name = 'meta_progettobudget';
    }

    meta_progettobudget.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettobudget,
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
						this.describeAColumn(table, 'idworkpackage', 'Workpackage', null, 10, null);
						this.describeAColumn(table, 'idprogettotipocosto', 'Voce di costo', null, 20, null);
						this.describeAColumn(table, 'budget', 'Budget iniziale', 'fixed.2', 30, null);
						this.describeAColumn(table, '!budgetvariazione', 'Budget corrente', 'fixed.2', 40, null);
						this.describeAColumn(table, '!spese', 'Costi', 'fixed.2', 50, null);
						this.describeAColumn(table, '!ricaviincassati', 'Ricavi', 'fixed.2', 150, null);
						this.describeAColumn(table, '!idprogettotipocosto_progettotipocosto_title', 'Voce di costo', null, 21, null);
						objCalcFieldConfig['!idprogettotipocosto_progettotipocosto_title'] = { tableNameLookup:'progettotipocosto_alias2', columnNameLookup:'title', columnNamekey:'idprogettotipocosto' };
						this.describeAColumn(table, '!idworkpackage_workpackage_raggruppamento', 'Raggruppamento Workpackage', null, 11, null);
						this.describeAColumn(table, '!idworkpackage_workpackage_title', 'Titolo Workpackage', null, 12, null);
						objCalcFieldConfig['!idworkpackage_workpackage_raggruppamento'] = { tableNameLookup:'workpackage_alias2', columnNameLookup:'raggruppamento', columnNamekey:'idworkpackage' };
						objCalcFieldConfig['!idworkpackage_workpackage_title'] = { tableNameLookup:'workpackage_alias2', columnNameLookup:'title', columnNamekey:'idworkpackage' };
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
						table.columns["budget"].caption = "Budget iniziale";
						table.columns["idprogettotipocosto"].caption = "Voce di costo";
						table.columns["idworkpackage"].caption = "Workpackage";
						table.columns["sortcode"].caption = "Ordine di visualizzazione";
						table.columns["!budgetvariazione"].caption = "Budget corrente";
						table.columns["!ricaviincassati"].caption = "Ricavi";
						table.columns["!ricavinonincassati"].caption = "Ricavi non incassati";
						table.columns["!spese"].caption = "Costi";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettobudget");

				//$getNewRowInside$

				dt.autoIncrement('idprogettobudget', { minimum: 99990001 });

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
					case "seg": {
						return "idworkpackage asc , sortcode asc , idprogettotipocosto asc ";
					}
					case "seg": {
						return "sortcode";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('progettobudget', new meta_progettobudget('progettobudget'));

	}());

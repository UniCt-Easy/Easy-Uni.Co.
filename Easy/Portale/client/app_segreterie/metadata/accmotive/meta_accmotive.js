(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_accmotive() {
        MetaData.apply(this, ["accmotive"]);
        this.name = 'meta_accmotive';
    }

    meta_accmotive.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_accmotive,
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
						this.describeAColumn(table, 'codemotive', 'Codice', null, 10, 50);
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 150);
//$objCalcFieldConfig_default$
						break;
					case 'seg':
						this.describeAColumn(table, 'title', 'Causale', null, 20, 150);
						this.describeAColumn(table, 'codemotive', 'Codice', null, 40, 50);
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
					case 'default':
						table.columns["codemotive"].caption = "Codice";
						table.columns["title"].caption = "Denominazione";
//$innerSetCaptionConfig_default$
						break;
					case 'seg':
						table.columns["codemotive"].caption = "Codice";
						table.columns["title"].caption = "Causale";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_accmotive");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;

				//$getNewRowInside$


				// metto i default
				var objRow = dt.newRow({
					//$getNewRowDefault$
				}, realParentObjectRow);

				// torno la dataRow creata
				return def.resolve(objRow.getRow());
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "default": {
						return "codemotive asc , title asc ";
					}
					case "seg": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('accmotive', new meta_accmotive('accmotive'));

	}());

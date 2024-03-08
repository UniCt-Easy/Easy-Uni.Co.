(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_costoscontodef() {
        MetaData.apply(this, ["costoscontodef"]);
        this.name = 'meta_costoscontodef';
    }

    meta_costoscontodef.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_costoscontodef,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 2024);
//$objCalcFieldConfig_more$
						break;
					case 'sconti':
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 2024);
//$objCalcFieldConfig_sconti$
						break;
					case 'default':
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 2024);
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
						table.columns["idcostoscontodefkind"].caption = "Tipologia";
						table.columns["paridcostoscontodef"].caption = "Relativo al costo";
						table.columns["title"].caption = "Titolo";
//$innerSetCaptionConfig_more$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_costoscontodef");

				//$getNewRowInside$

				dt.autoIncrement('idcostoscontodef', { minimum: 99990001 });

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
					case "more": {
						return "title asc ";
					}
					case "sconti": {
						return "title asc ";
					}
					case "default": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('costoscontodef', new meta_costoscontodef('costoscontodef'));

	}());

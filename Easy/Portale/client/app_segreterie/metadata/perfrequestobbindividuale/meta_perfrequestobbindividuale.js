(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfrequestobbindividuale() {
        MetaData.apply(this, ["perfrequestobbindividuale"]);
        this.name = 'meta_perfrequestobbindividuale';
    }

    meta_perfrequestobbindividuale.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfrequestobbindividuale,
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
						this.describeAColumn(table, 'title', 'Titolo obiettivo', null, 20, 1024);
						this.describeAColumn(table, 'year', 'Anno solare', null, 20, null);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, 'peso', 'Peso', 'fixed.2', 50, null);
						this.describeAColumn(table, 'inserito', 'Inserito', null, 60, null);
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
						table.columns["description"].caption = "Descrizione";
						table.columns["idreg"].caption = "Valutato";
						table.columns["inserito"].caption = "Inserito";
						table.columns["peso"].caption = "Peso";
						table.columns["title"].caption = "Titolo obiettivo";
						table.columns["year"].caption = "Anno solare";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfrequestobbindividuale");

				//$getNewRowInside$

				dt.autoIncrement('idperfrequestobbindividuale', { minimum: 99990001 });

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
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('perfrequestobbindividuale', new meta_perfrequestobbindividuale('perfrequestobbindividuale'));

	}());

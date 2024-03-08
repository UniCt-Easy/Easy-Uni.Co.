(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfindicatoresoglia() {
        MetaData.apply(this, ["perfindicatoresoglia"]);
        this.name = 'meta_perfindicatoresoglia';
    }

    meta_perfindicatoresoglia.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfindicatoresoglia,
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
						this.describeAColumn(table, 'idperfsogliakind', 'Tipo', null, 20, 50);
						this.describeAColumn(table, 'valore', 'Valore percentuale', 'fixed.2', 30, null);
						this.describeAColumn(table, 'valorenumerico', 'Valore numerico soglia', 'fixed.2', 40, null);
						this.describeAColumn(table, 'description', 'Descrizione', null, 50, -1);
//$objCalcFieldConfig_default$
						break;
					case 'valutazione':
						this.describeAColumn(table, 'year', 'Anno', null, 10, null);
						this.describeAColumn(table, 'idperfsogliakind', 'Tipo', null, 20, 50);
						this.describeAColumn(table, 'valore', 'Valore percentuale', 'fixed.2', 30, null);
						this.describeAColumn(table, 'valorenumerico', 'Valore numerico soglia', 'fixed.2', 40, null);
						this.describeAColumn(table, 'description', 'Descrizione', null, 50, -1);
//$objCalcFieldConfig_valutazione$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'valutazione':
						table.columns["description"].caption = "Descrizione";
						table.columns["idperfsogliakind"].caption = "Tipo";
						table.columns["valore"].caption = "Valore percentuale";
						table.columns["valorenumerico"].caption = "Valore numerico soglia";
						table.columns["year"].caption = "Anno";
//$innerSetCaptionConfig_valutazione$
						break;
					case 'default':
						table.columns["description"].caption = "Descrizione";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfindicatoresoglia");

				//$getNewRowInside$

				dt.autoIncrement('idperfindicatoresoglia', { minimum: 99990001 });

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
						return "valore asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('perfindicatoresoglia', new meta_perfindicatoresoglia('perfindicatoresoglia'));

	}());

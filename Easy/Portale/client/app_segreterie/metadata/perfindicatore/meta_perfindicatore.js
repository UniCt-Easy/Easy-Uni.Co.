(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfindicatore() {
        MetaData.apply(this, ["perfindicatore"]);
        this.name = 'meta_perfindicatore';
    }

    meta_perfindicatore.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfindicatore,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 10, 2048);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, -1);
//$objCalcFieldConfig_default$
						break;
					case 'valutazione':
						this.describeAColumn(table, 'title', 'Titolo', null, 10, 2048);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, -1);
						this.describeAColumn(table, '!idperfindicatorekind_perfindicatorekind_title', 'Tipo indicatore', null, 21, null);
						objCalcFieldConfig['!idperfindicatorekind_perfindicatorekind_title'] = { tableNameLookup:'perfindicatorekind', columnNameLookup:'title', columnNamekey:'idperfindicatorekind' };
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
						table.columns["idperfindicatorekind"].caption = "Tipo indicatore";
						table.columns["inverso"].caption = "Valore inverso";
						table.columns["title"].caption = "Titolo";
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
               var def = appMeta.Deferred("getNewRow-meta_perfindicatore");

				//$getNewRowInside$

				dt.autoIncrement('idperfindicatore', { minimum: 99990001 });

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
					case "valutazione": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('perfindicatore', new meta_perfindicatore('perfindicatore'));

	}());

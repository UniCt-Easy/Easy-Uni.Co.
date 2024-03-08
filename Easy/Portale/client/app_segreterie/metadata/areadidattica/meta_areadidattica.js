(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_areadidattica() {
        MetaData.apply(this, ["areadidattica"]);
        this.name = 'meta_areadidattica';
    }

    meta_areadidattica.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_areadidattica,
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
						this.describeAColumn(table, 'idareadidattica', 'Codice', null, 10, null);
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 100);
						this.describeAColumn(table, 'active', 'Attivo', null, 30, null);
						this.describeAColumn(table, 'sortcode', 'Ordinamento', null, 50, null);
						this.describeAColumn(table, 'subtitle', 'Sotto-titolo', null, 60, 100);
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
						table.columns["active"].caption = "Attivo";
						table.columns["idareadidattica"].caption = "Codice";
						table.columns["idcorsostudiokind"].caption = "Tipo di corso";
						table.columns["sortcode"].caption = "Ordinamento";
						table.columns["subtitle"].caption = "Sotto-titolo";
						table.columns["title"].caption = "Titolo";
						table.columns["idmacroareadidattica"].caption = "Macroarea didattica";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_areadidattica");

				//$getNewRowInside$

				dt.autoIncrement('idareadidattica', { minimum: 99990001 });

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
						return "title asc ";
					}
					case "default": {
						return "title asc , sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('areadidattica', new meta_areadidattica('areadidattica'));

	}());

(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_dichiardisabilkind() {
        MetaData.apply(this, ["dichiardisabilkind"]);
        this.name = 'meta_dichiardisabilkind';
    }

    meta_dichiardisabilkind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_dichiardisabilkind,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 10, 50);
						this.describeAColumn(table, 'specification', 'Specifica', null, 20, 50);
						this.describeAColumn(table, 'active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'sortcode', 'Ordinamento', null, 50, null);
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
						table.columns["description"].caption = "Descrizione";
						table.columns["sortcode"].caption = "Ordinamento";
						table.columns["specification"].caption = "Specifica";
						table.columns["title"].caption = "Titolo";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_dichiardisabilkind");

				//$getNewRowInside$

				dt.autoIncrement('iddichiardisabilkind', { minimum: 99990001 });

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
						return "title desc, specification desc";
					}
					case "default": {
						return "title desc, specification desc, sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('dichiardisabilkind', new meta_dichiardisabilkind('dichiardisabilkind'));

	}());

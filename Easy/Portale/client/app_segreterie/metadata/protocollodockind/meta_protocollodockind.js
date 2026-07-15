(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_protocollodockind() {
        MetaData.apply(this, ["protocollodockind"]);
        this.name = 'meta_protocollodockind';
    }

    meta_protocollodockind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_protocollodockind,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 20, 50);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, 256);
						this.describeAColumn(table, 'active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'kind', 'Tipo', null, 50, 50);
						this.describeAColumn(table, 'sortcode', 'Ordinamento', null, 60, null);
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
						table.columns["active"].caption = "Attivo";
						table.columns["description"].caption = "Descrizione";
						table.columns["kind"].caption = "Tipo";
						table.columns["sortcode"].caption = "Ordinamento";
						table.columns["title"].caption = "Titolo";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_protocollodockind");

				//$getNewRowInside$

				dt.autoIncrement('idprotocollodockind', { minimum: 99990001 });

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
						return "title desc";
					}
					case "seg": {
						return "title desc, sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('protocollodockind', new meta_protocollodockind('protocollodockind'));

	}());

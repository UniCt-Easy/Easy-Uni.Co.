(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfobiettivokind() {
        MetaData.apply(this, ["perfobiettivokind"]);
        this.name = 'meta_perfobiettivokind';
    }

    meta_perfobiettivokind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfobiettivokind,
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
						this.describeAColumn(table, 'title', 'Obiettivo', null, 20, 1024);
						this.describeAColumn(table, 'description', 'Descrizione', null, 70, -1);
						this.describeAColumn(table, 'active', 'Attivo', null, 80, null);
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
						table.columns["title"].caption = "Obiettivo";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfobiettivokind");

				//$getNewRowInside$

				dt.autoIncrement('idperfobiettivokind', { minimum: 99990001 });

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

    window.appMeta.addMeta('perfobiettivokind', new meta_perfobiettivokind('perfobiettivokind'));

	}());

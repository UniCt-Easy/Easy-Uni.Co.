(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_classescuolakind() {
        MetaData.apply(this, ["classescuolakind"]);
        this.name = 'meta_classescuolakind';
    }

    meta_classescuolakind.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_classescuolakind,
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
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 1024);
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
						table.columns["idclassescuolakind"].caption = "Codice";
						table.columns["idclassescuolakind"].caption = "Sigla";
						table.columns["idcorsostudiokind"].caption = "Tipologia di corso";
						table.columns["idcorsostudiolivello"].caption = "Livello del corso";
						table.columns["title"].caption = "Tipologia";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_classescuolakind");

				//$getNewRowInside$


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

        });

    window.appMeta.addMeta('classescuolakind', new meta_classescuolakind('classescuolakind'));

	}());

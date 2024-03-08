(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registry_amministrativi() {
        MetaData.apply(this, ["registry_amministrativi"]);
        this.name = 'meta_registry_amministrativi';
    }

    meta_registry_amministrativi.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registry_amministrativi,
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
					case 'amministrativi':
						return this.superClass.describeColumns(table, listType);
//$objCalcFieldConfig_amministrativi$
						break;
					case 'amministrativi_personale':
						return this.superClass.describeColumns(table, listType);
//$objCalcFieldConfig_amministrativi_personale$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'amministrativi':
						table.columns["cv"].caption = "Curriculum vitae";
//$innerSetCaptionConfig_amministrativi$
						break;
					case 'amministrativi_personale':
//$innerSetCaptionConfig_amministrativi_personale$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_registry_amministrativi");

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
					case "amministrativi": {
						return "surname asc , forename asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registry_amministrativi', new meta_registry_amministrativi('registry_amministrativi'));

	}());

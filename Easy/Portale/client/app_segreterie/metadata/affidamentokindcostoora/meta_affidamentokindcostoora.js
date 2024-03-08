(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_affidamentokindcostoora() {
        MetaData.apply(this, ["affidamentokindcostoora"]);
        this.name = 'meta_affidamentokindcostoora';
    }

    meta_affidamentokindcostoora.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_affidamentokindcostoora,
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
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'title', 'Descrizione', null, 30, 1024);
						this.describeAColumn(table, 'costoora', 'Costo orario', 'fixed.2', 40, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_affidamentokindcostoora");

				//$getNewRowInside$

				dt.autoIncrement('idaffidamentokindcostoora', { minimum: 99990001 });

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
						return "aa asc , title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('affidamentokindcostoora', new meta_affidamentokindcostoora('affidamentokindcostoora'));

	}());

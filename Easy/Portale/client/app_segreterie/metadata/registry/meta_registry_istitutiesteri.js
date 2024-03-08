(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registry_istitutiesteri() {
        MetaData.apply(this, ["registry_istitutiesteri"]);
        this.name = 'meta_registry_istitutiesteri';
    }

    meta_registry_istitutiesteri.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registry_istitutiesteri,
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
					case 'istitutiesteri':
						this.describeAColumn(table, 'idreg', 'Identificativo', null, 10, null);
						this.describeAColumn(table, 'name', 'Name', null, 20, 1024);
						this.describeAColumn(table, 'city', 'City', null, 30, 255);
						this.describeAColumn(table, 'code', 'Code', null, 40, 50);
						this.describeAColumn(table, 'institutionalcode', 'Institutional code', null, 50, 50);
						this.describeAColumn(table, 'referencenumber', 'Reference number', null, 60, 50);
//$objCalcFieldConfig_istitutiesteri$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'istitutiesteri':
						table.columns["idnace"].caption = "NACE code";
						table.columns["institutionalcode"].caption = "Institutional code";
						table.columns["referencenumber"].caption = "Reference number";
//$innerSetCaptionConfig_istitutiesteri$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_registry_istitutiesteri");

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
					case "istitutiesteri": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registry_istitutiesteri', new meta_registry_istitutiesteri('registry_istitutiesteri'));

	}());

(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registry_aziende() {
        MetaData.apply(this, ["registry_aziende"]);
        this.name = 'meta_registry_aziende';
    }

    meta_registry_aziende.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registry_aziende,
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
					case 'aziende':
						this.describeAColumn(table, 'pic', 'Participant Identification Code (PIC)', null, 120, 10);
//$objCalcFieldConfig_aziende$
						break;
					case 'aziende_ro':
						this.describeAColumn(table, 'pic', 'Participant Identification Code (PIC)', null, 120, 10);
//$objCalcFieldConfig_aziende_ro$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'aziende_ro':
						table.columns["idateco"].caption = "Classificazione Ateco";
						table.columns["idnace"].caption = "NACE";
						table.columns["idnaturagiur"].caption = "Natura Giuridica";
						table.columns["idnumerodip"].caption = "Numero di dipendenti";
						table.columns["idreg"].caption = "Codice";
						table.columns["pic"].caption = "Participant Identification Code (PIC)";
						table.columns["title_en"].caption = "Denominazione (ENG)";
//$innerSetCaptionConfig_aziende_ro$
						break;
					case 'aziende':
						table.columns["idateco"].caption = "Classificazione Ateco";
//$innerSetCaptionConfig_aziende$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_registry_aziende");

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
					case "aziende": {
						return "title asc ";
					}
					case "aziende_ro": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registry_aziende', new meta_registry_aziende('registry_aziende'));

	}());

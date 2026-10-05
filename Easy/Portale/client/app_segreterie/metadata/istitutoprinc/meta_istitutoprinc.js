(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istitutoprinc() {
        MetaData.apply(this, ["istitutoprinc"]);
        this.name = 'meta_istitutoprinc';
    }

    meta_istitutoprinc.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istitutoprinc,
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
						this.describeAColumn(table, 'acronimo', 'Acronimo', null, 10, 50);
						this.describeAColumn(table, 'tipoente', 'Tipologia di ente', null, 100, null);
						this.describeAColumn(table, 'codiceerasmus', 'Codice Erasmus', null, 120, 50);
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
						table.columns["codiceerasmus"].caption = "Codice Erasmus";
						table.columns["idistitutokind"].caption = "Sottotipologia di ente";
						table.columns["idreg_dir"].caption = "Direttore";
						table.columns["idreg_diramm"].caption = "Direttore Amministrativo";
						table.columns["subtipoente"].caption = "Sottotipologia di ente";
						table.columns["tipoente"].caption = "Tipologia di ente";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_istitutoprinc");

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
						return "idreg desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('istitutoprinc', new meta_istitutoprinc('istitutoprinc'));

	}());

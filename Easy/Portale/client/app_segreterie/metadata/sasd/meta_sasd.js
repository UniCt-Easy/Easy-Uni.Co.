(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_sasd() {
        MetaData.apply(this, ["sasd"]);
        this.name = 'meta_sasd';
    }

    meta_sasd.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_sasd,
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
						this.describeAColumn(table, 'idsasd', 'Codice Istituto', null, 10, null);
						this.describeAColumn(table, 'codice', 'Codice', null, 20, 50);
						this.describeAColumn(table, 'title', 'Denominazione', null, 30, 255);
						this.describeAColumn(table, 'codice_old', 'Codice legge precedente', null, 50, 4);
//$objCalcFieldConfig_default$
						break;
					case 'integrandi':
						this.describeAColumn(table, 'idsasd', 'Codice Istituto', null, 10, null);
						this.describeAColumn(table, 'codice', 'Codice', null, 20, 50);
						this.describeAColumn(table, 'title', 'Denominazione', null, 30, 255);
						this.describeAColumn(table, 'codice_old', 'Codice legge precedente', null, 50, 4);
//$objCalcFieldConfig_integrandi$
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
						table.columns["codice_old"].caption = "Codice legge precedente";
						table.columns["idareadidattica"].caption = "Area o ambito disciplinare";
						table.columns["idsasd"].caption = "Codice Istituto";
						table.columns["title"].caption = "Denominazione";
//$innerSetCaptionConfig_default$
						break;
					case 'integrandi':
						table.columns["codice_old"].caption = "Codice legge precedente";
						table.columns["idareadidattica"].caption = "Area o ambito disciplinare";
						table.columns["idsasd"].caption = "Codice Istituto";
						table.columns["title"].caption = "Denominazione";
//$innerSetCaptionConfig_integrandi$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_sasd");

				//$getNewRowInside$

				dt.autoIncrement('idsasd', { minimum: 99990001 });

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
						return "codice asc , title desc";
					}
					case "integrandi": {
						return "codice asc , title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('sasd', new meta_sasd('sasd'));

	}());

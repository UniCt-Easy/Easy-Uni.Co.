(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfobiettiviuo() {
        MetaData.apply(this, ["perfobiettiviuo"]);
        this.name = 'meta_perfobiettiviuo';
    }

    meta_perfobiettiviuo.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfobiettiviuo,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 10, 2048);
						this.describeAColumn(table, 'description', 'Descrizione', null, 20, -1);
						this.describeAColumn(table, 'peso', 'Peso', 'fixed.2', 30, null);
						this.describeAColumn(table, 'valorenumerico', 'Valore numerico raggiunto', 'fixed.2', 50, null);
						this.describeAColumn(table, 'completamento', 'Percentuale di completamento', 'fixed.2', 60, null);
						this.describeAColumn(table, '!perfobiettiviuosoglia', 'Soglie', null, 40, null);
//$objCalcFieldConfig_default$
						break;
					case 'onlyunatantum':
						this.describeAColumn(table, 'title', 'Obiettivo', null, 10, 2048);
						this.describeAColumn(table, 'description', 'Indicatore', null, 20, -1);
						this.describeAColumn(table, 'peso', 'Peso', 'fixed.2', 30, null);
						this.describeAColumn(table, 'valorenumerico', 'Valore numerico raggiunto', 'fixed.2', 50, null);
						this.describeAColumn(table, 'completamento', 'Percentuale di completamento', 'fixed.2', 60, null);
						this.describeAColumn(table, 'note', 'Note', null, 70, -1);
						this.describeAColumn(table, '!perfobiettiviuosoglia', 'Target', null, 40, null);
//$objCalcFieldConfig_onlyunatantum$
						break;
					case 'onlyprestazionali':
						this.describeAColumn(table, 'title', 'Obiettivo', null, 10, 2048);
						this.describeAColumn(table, 'description', 'Indicatore', null, 20, -1);
						this.describeAColumn(table, 'peso', 'Peso', 'fixed.2', 30, null);
						this.describeAColumn(table, 'valorenumerico', 'Valore numerico raggiunto', 'fixed.2', 50, null);
						this.describeAColumn(table, 'completamento', 'Percentuale di completamento', 'fixed.2', 60, null);
						this.describeAColumn(table, 'note', 'Note', null, 70, -1);
						this.describeAColumn(table, '!perfobiettiviuosoglia', 'Target', null, 40, null);
//$objCalcFieldConfig_onlyprestazionali$
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
						table.columns["completamento"].caption = "Percentuale di completamento";
						table.columns["description"].caption = "Descrizione";
						table.columns["peso"].caption = "Peso";
						table.columns["title"].caption = "Titolo";
						table.columns["valorenumerico"].caption = "Valore numerico raggiunto";
//$innerSetCaptionConfig_default$
						break;
					case 'onlyunatantum':
						table.columns["completamento"].caption = "Percentuale di completamento";
						table.columns["description"].caption = "Indicatore";
						table.columns["peso"].caption = "Peso";
						table.columns["title"].caption = "Obiettivo";
						table.columns["valorenumerico"].caption = "Valore numerico raggiunto";
						table.columns["idperfvalutazionepersonale"].caption = "Responsabile";
//$innerSetCaptionConfig_onlyunatantum$
						break;
					case 'onlyprestazionali':
						table.columns["completamento"].caption = "Percentuale di completamento";
						table.columns["description"].caption = "Indicatore";
						table.columns["peso"].caption = "Peso";
						table.columns["title"].caption = "Obiettivo";
						table.columns["valorenumerico"].caption = "Valore numerico raggiunto";
//$innerSetCaptionConfig_onlyprestazionali$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfobiettiviuo");

				//$getNewRowInside$

				dt.autoIncrement('idperfobiettiviuo', { minimum: 99990001 });

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
						return "title asc ";
					}
					case "onlyunatantum": {
						return "title asc ";
					}
					case "onlyprestazionali": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

			//$describeTree$
        });

    window.appMeta.addMeta('perfobiettiviuo', new meta_perfobiettiviuo('perfobiettiviuo'));

	}());

(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_esonero_titolostudio() {
        MetaData.apply(this, ["esonero_titolostudio"]);
        this.name = 'meta_esonero_titolostudio';
    }

    meta_esonero_titolostudio.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_esonero_titolostudio,
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
					case 'titolostudio':
						this.describeAColumn(table, 'conseguitoincorso', 'Conseguito in corso', null, 10, null);
						this.describeAColumn(table, 'dataconstutticf', 'Data limite per aver conseguito tutti i crediti formativi', null, 20, null);
						this.describeAColumn(table, 'datalaurea', 'Data limite di conseguimento del titolo', null, 30, null);
						this.describeAColumn(table, 'nellistituto', 'Solo per corsi dell\'istituto', null, 60, null);
						this.describeAColumn(table, 'noabbr', 'Senza abbreviazioni di carriera', null, 70, null);
						this.describeAColumn(table, 'noparttime', 'Senza aver effettuato iscrizioni part-time', null, 80, null);
						this.describeAColumn(table, 'votomin', 'Voto minimo', null, 90, null);
//$objCalcFieldConfig_titolostudio$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'titolostudio':
						table.columns["conseguitoincorso"].caption = "Conseguito in corso";
						table.columns["dataconstutticf"].caption = "Data limite per aver conseguito tutti i crediti formativi";
						table.columns["datalaurea"].caption = "Data limite di conseguimento del titolo";
						table.columns["idstruttura"].caption = "Struttura didattica";
						table.columns["nellistituto"].caption = "Solo per corsi dell'istituto";
						table.columns["noabbr"].caption = "Senza abbreviazioni di carriera";
						table.columns["noparttime"].caption = "Senza aver effettuato iscrizioni part-time";
						table.columns["votomin"].caption = "Voto minimo";
//$innerSetCaptionConfig_titolostudio$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_esonero_titolostudio");

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
					case "titolostudio": {
						return "title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('esonero_titolostudio', new meta_esonero_titolostudio('esonero_titolostudio'));

	}());

(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_getregistrydocentiamministrativi() {
        MetaData.apply(this, ["getregistrydocentiamministrativi"]);
        this.name = 'meta_getregistrydocentiamministrativi';
    }

    meta_getregistrydocentiamministrativi.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_getregistrydocentiamministrativi,
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
						this.describeAColumn(table, 'surname', 'Cognome', null, 10, 50);
						this.describeAColumn(table, 'forename', 'Nome', null, 20, 50);
						this.describeAColumn(table, 'extmatricula', 'Matricola', null, 30, 40);
						this.describeAColumn(table, 'cf', 'CF', null, 40, 16);
						this.describeAColumn(table, 'contratto', 'Contratto', null, 50, 50);
						this.describeAColumn(table, 'ssd', 'SSD', null, 60, 50);
						this.describeAColumn(table, 'struttura', 'Struttura', null, 70, 1024);
						this.describeAColumn(table, 'istituto', 'Istituto', null, 80, 101);
//$objCalcFieldConfig_default$
						break;
					case 'nomcogn':
						this.describeAColumn(table, 'surname', 'Cognome', null, 10, 50);
						this.describeAColumn(table, 'forename', 'Nome', null, 20, 50);
//$objCalcFieldConfig_nomcogn$
						break;
					case 'macroarea':
						this.describeAColumn(table, 'surname', 'Cognome', null, 10, 50);
						this.describeAColumn(table, 'forename', 'Nome', null, 20, 50);
						this.describeAColumn(table, 'extmatricula', 'Matricola', null, 30, 40);
						this.describeAColumn(table, 'cf', 'CF', null, 40, 16);
						this.describeAColumn(table, 'contratto', 'Contratto', null, 50, 50);
						this.describeAColumn(table, 'ssd', 'SSD', null, 60, 50);
						this.describeAColumn(table, 'macroareadidattica', 'Macroarea', null, 70, 1024);
						this.describeAColumn(table, 'struttura', 'Struttura', null, 80, 1024);
						this.describeAColumn(table, 'istituto', 'Istituto', null, 90, 101);
//$objCalcFieldConfig_macroarea$
						break;
					case 'nomcognmat':
						this.describeAColumn(table, 'surname', 'Cognome', null, 10, 50);
						this.describeAColumn(table, 'forename', 'Nome', null, 20, 50);
						this.describeAColumn(table, 'extmatricula', 'Matricola', null, 30, 40);
//$objCalcFieldConfig_nomcognmat$
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
						table.columns["cf"].caption = "CF";
						table.columns["forename"].caption = "Nome";
						table.columns["ssd"].caption = "SSD";
						table.columns["surname"].caption = "Cognome";
						table.columns["extmatricula"].caption = "Matricola";
//$innerSetCaptionConfig_default$
						break;
					case 'nomcogn':
						table.columns["cf"].caption = "CF";
						table.columns["forename"].caption = "Nome";
						table.columns["ssd"].caption = "SSD";
						table.columns["surname"].caption = "Cognome";
//$innerSetCaptionConfig_nomcogn$
						break;
					case 'macroarea':
						table.columns["cf"].caption = "CF";
						table.columns["extmatricula"].caption = "Matricola";
						table.columns["forename"].caption = "Nome";
						table.columns["macroareadidattica"].caption = "Macroarea";
						table.columns["ssd"].caption = "SSD";
						table.columns["surname"].caption = "Cognome";
//$innerSetCaptionConfig_macroarea$
						break;
					case 'nomcognmat':
						table.columns["cf"].caption = "CF";
						table.columns["extmatricula"].caption = "Matricola";
						table.columns["forename"].caption = "Nome";
						table.columns["ssd"].caption = "SSD";
						table.columns["surname"].caption = "Cognome";
//$innerSetCaptionConfig_nomcognmat$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_getregistrydocentiamministrativi");

				//$getNewRowInside$

				dt.autoIncrement('idreg', { minimum: 99990001 });

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
						return "surname ASC , forename ASC ";
					}
					case "nomcogn": {
						return "surname ASC , forename ASC ";
					}
					case "macroarea": {
						return "surname ASC , forename ASC ";
					}
					case "nomcognmat": {
						return "surname ASC , forename ASC ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('getregistrydocentiamministrativi', new meta_getregistrydocentiamministrativi('getregistrydocentiamministrativi'));

	}());

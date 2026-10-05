(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_tassaiscrizioneconf() {
        MetaData.apply(this, ["tassaiscrizioneconf"]);
        this.name = 'meta_tassaiscrizioneconf';
    }

    meta_tassaiscrizioneconf.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_tassaiscrizioneconf,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 30, 2024);
						this.describeAColumn(table, 'aamax', 'Anno accademico massimo', null, 40, 9);
						this.describeAColumn(table, 'aamin', 'Anno accademico minimo', null, 50, 9);
						this.describeAColumn(table, 'annofcmax', 'Anno di iscrizione fuori corso massimo', null, 60, null);
						this.describeAColumn(table, 'annofcmin', 'Anno di iscrizione fuori corso minimo', null, 70, null);
						this.describeAColumn(table, 'annomax', 'Anno di iscrizione massimo', null, 80, null);
						this.describeAColumn(table, 'annomin', 'Anno di iscrizione minimo', null, 90, null);
						this.describeAColumn(table, 'codice_corsostudio', 'Codice del corso di studio', null, 100, 50);
						this.describeAColumn(table, 'codice_didprog', 'Codice della didattica programmata', null, 110, 50);
						this.describeAColumn(table, 'codice_didprogcurr', 'Codice del curriculum', null, 120, 50);
						this.describeAColumn(table, 'codice_didprogori', 'Codice dell\'orientamento', null, 130, 50);
						this.describeAColumn(table, 'corsisingoli', 'Corsi singoli', null, 140, null);
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
						table.columns["aa"].caption = "Anno accademico";
						table.columns["aamax"].caption = "Anno accademico massimo";
						table.columns["aamin"].caption = "Anno accademico minimo";
						table.columns["annofcmax"].caption = "Anno di iscrizione fuori corso massimo";
						table.columns["annofcmin"].caption = "Anno di iscrizione fuori corso minimo";
						table.columns["annomax"].caption = "Anno di iscrizione massimo";
						table.columns["annomin"].caption = "Anno di iscrizione minimo";
						table.columns["codice_corsostudio"].caption = "Codice del corso di studio";
						table.columns["codice_didprog"].caption = "Codice della didattica programmata";
						table.columns["codice_didprogcurr"].caption = "Codice del curriculum";
						table.columns["codice_didprogori"].caption = "Codice dell'orientamento";
						table.columns["corsisingoli"].caption = "Corsi singoli";
						table.columns["idcorsostudio"].caption = "Corso di studi";
						table.columns["idcorsostudiokind"].caption = "Tipo di corso";
						table.columns["idcostoscontodef"].caption = "Costo";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["iddidprogcurr"].caption = "Curriculum";
						table.columns["iddidprogori"].caption = "orientamento";
						table.columns["idstruttura"].caption = "Dipartimento - Scuola";
						table.columns["title"].caption = "Titolo";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_tassaiscrizioneconf");

				//$getNewRowInside$

				dt.autoIncrement('idtassaiscrizioneconf', { minimum: 99990001 });

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
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('tassaiscrizioneconf', new meta_tassaiscrizioneconf('tassaiscrizioneconf'));

	}());

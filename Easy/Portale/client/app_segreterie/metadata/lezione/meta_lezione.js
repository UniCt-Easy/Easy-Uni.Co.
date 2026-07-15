(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_lezione() {
        MetaData.apply(this, ["lezione"]);
        this.name = 'meta_lezione';
    }

    meta_lezione.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_lezione,
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
					case 'seg':
						this.describeAColumn(table, '!title', 'Lezione', null, 10, null);
						this.describeAColumn(table, 'start', 'Data e ora inizio', 'g', 30, null);
						this.describeAColumn(table, 'stop', 'Data e ora fine', 'g', 40, null);
						this.describeAColumn(table, 'titolo', 'Titolo', null, 80, 2048);
//$objCalcFieldConfig_seg$
						break;
					case 'rendicont':
						this.describeAColumn(table, '!title', 'Lezione', null, 10, null);
						this.describeAColumn(table, 'start', 'Data e ora inizio', 'g', 90, null);
						this.describeAColumn(table, 'stop', 'Data e ora fine', 'g', 100, null);
						this.describeAColumn(table, 'titolo', 'Titolo', null, 110, 2048);
//$objCalcFieldConfig_rendicont$
						break;
					case 'attivform':
						this.describeAColumn(table, '!title', 'Lezione', null, 10, null);
						this.describeAColumn(table, 'start', 'Data e ora inizio', 'g', 30, null);
						this.describeAColumn(table, 'stop', 'Data e ora fine', 'g', 40, null);
						this.describeAColumn(table, 'titolo', 'Titolo', null, 80, 2048);
//$objCalcFieldConfig_attivform$
						break;
					case 'default':
						this.describeAColumn(table, '!title', 'Lezione', null, 10, null);
						this.describeAColumn(table, 'start', 'Data e ora inizio', 'g', 90, null);
						this.describeAColumn(table, 'stop', 'Data e ora fine', 'g', 100, null);
						this.describeAColumn(table, 'titolo', 'Titolo', null, 110, 2048);
//$objCalcFieldConfig_default$
						break;
					case 'aulapublic':
						this.describeAColumn(table, '!title', 'Lezione', null, 10, null);
						this.describeAColumn(table, 'start', 'Data e ora inizio', 'g', 90, null);
						this.describeAColumn(table, 'stop', 'Data e ora fine', 'g', 100, null);
						this.describeAColumn(table, 'titolo', 'Titolo', null, 110, 2048);
//$objCalcFieldConfig_aulapublic$
						break;
					case 'docenti':
						this.describeAColumn(table, '!title', 'Lezione', null, 0, null);
						this.describeAColumn(table, 'start', 'Data e ora inizio', 'g', 90, null);
						this.describeAColumn(table, 'stop', 'Data e ora fine', 'g', 100, null);
						this.describeAColumn(table, 'titolo', 'Titolo', null, 110, 2048);
//$objCalcFieldConfig_docenti$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'seg':
						table.columns["idlezione"].caption = "Identificativo";
						table.columns["idaffidamento"].caption = "Affidamento";
						table.columns["idattivform"].caption = "attività formativa";
						table.columns["idaula"].caption = "Aula";
						table.columns["idcanale"].caption = "Canale";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["iddidproganno"].caption = "Anno di corso";
						table.columns["iddidprogcurr"].caption = "Curriculum";
						table.columns["iddidprogori"].caption = "Orientamento";
						table.columns["iddidprogporzanno"].caption = "Porzione d'anno";
						table.columns["idedificio"].caption = "Edificio";
						table.columns["idreg_docenti"].caption = "Docente";
						table.columns["idsede"].caption = "Sede";
						table.columns["nonsvolta"].caption = "Non svolta";
						table.columns["start"].caption = "Data e ora inizio";
						table.columns["stop"].caption = "Data e ora fine";
						table.columns["titolo"].caption = "Titolo";
						table.columns["!title"].caption = "Lezione";
//$innerSetCaptionConfig_seg$
						break;
					case 'rendicont':
						table.columns["idcorsostudio"].caption = "Corso di studi";
//$innerSetCaptionConfig_rendicont$
						break;
					case 'attivform':
//$innerSetCaptionConfig_attivform$
						break;
					case 'default':
//$innerSetCaptionConfig_default$
						break;
					case 'aulapublic':
//$innerSetCaptionConfig_aulapublic$
						break;
					case 'docenti':
//$innerSetCaptionConfig_docenti$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_lezione");

				//$getNewRowInside$

				dt.autoIncrement('idlezione', { minimum: 99990001 });

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
					case "rendicont": {
						return "!title asc ";
					}
					case "default": {
						return "!title asc ";
					}
					case "rendicont": {
						return "!title asc , titolo desc";
					}
					case "aulapublic": {
						return "!title asc ";
					}
					case "docenti": {
						return "!title asc , titolo desc";
					}
					case "docenti": {
						return "titolo desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('lezione', new meta_lezione('lezione'));

	}());

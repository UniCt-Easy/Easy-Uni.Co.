(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_staffagrteaching() {
        MetaData.apply(this, ["staffagrteaching"]);
        this.name = 'meta_staffagrteaching';
    }

    meta_staffagrteaching.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_staffagrteaching,
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
						this.describeAColumn(table, 'idlivelloeqf', 'Livello EQF', null, 50, null);
						this.describeAColumn(table, 'numore', 'Numero di ore dell’attività del docente', null, 110, null);
						this.describeAColumn(table, 'numstud', 'Numero di studenti a cui si rivolge l’attività del docente', null, 120, null);
						this.describeAColumn(table, 'obiettivi', 'Obiettivi generali della mobilità', null, 130, -1);
						this.describeAColumn(table, 'programma', 'Contenuto del programma di insegnamento', null, 140, -1);
						this.describeAColumn(table, 'risultati', 'Risultati attesi e impatto', null, 150, -1);
						this.describeAColumn(table, 'valore', 'Valore aggiunto della mobilità', null, 160, -1);
						this.describeAColumn(table, '!idisced2013_isced2013_detailedfield', 'Mansione', null, 31, null);
						objCalcFieldConfig['!idisced2013_isced2013_detailedfield'] = { tableNameLookup:'isced2013', columnNameLookup:'detailedfield', columnNamekey:'idisced2013' };
						this.describeAColumn(table, '!idnation_geo_nation_title', 'Lingua in cui svolge l’attività', null, 61, null);
						objCalcFieldConfig['!idnation_geo_nation_title'] = { tableNameLookup:'geo_nation_alias2', columnNameLookup:'title', columnNamekey:'idnation' };
						this.describeAColumn(table, '!idreg_docenti_registry_docenti_title', 'Docente', null, 81, null);
						objCalcFieldConfig['!idreg_docenti_registry_docenti_title'] = { tableNameLookup:'registry_alias2', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						this.describeAColumn(table, '!idreg_resp_registry_title', 'Responsabile', null, 91, null);
						objCalcFieldConfig['!idreg_resp_registry_title'] = { tableNameLookup:'registry_alias3', columnNameLookup:'title', columnNamekey:'idreg_resp' };
						this.describeAColumn(table, '!idreg_respestero_registry_title', 'Responsabile estero', null, 101, null);
						objCalcFieldConfig['!idreg_respestero_registry_title'] = { tableNameLookup:'registry_alias4', columnNameLookup:'title', columnNamekey:'idreg_respestero' };
//$objCalcFieldConfig_seg$
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
						table.columns["idisced2013"].caption = "Mansione";
						table.columns["idiscrizionebmi"].caption = "Iscrizione al bando di mobilità internazionale";
						table.columns["idlivelloeqf"].caption = "Livello EQF";
						table.columns["idnation"].caption = "Lingua in cui svolge l’attività";
						table.columns["idreg_docenti"].caption = "Docente";
						table.columns["idreg_resp"].caption = "Responsabile";
						table.columns["idreg_respestero"].caption = "Responsabile estero";
						table.columns["numore"].caption = "Numero di ore dell’attività del docente";
						table.columns["numstud"].caption = "Numero di studenti a cui si rivolge l’attività del docente";
						table.columns["obiettivi"].caption = "Obiettivi generali della mobilità";
						table.columns["programma"].caption = "Contenuto del programma di insegnamento";
						table.columns["risultati"].caption = "Risultati attesi e impatto";
						table.columns["valore"].caption = "Valore aggiunto della mobilità";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_staffagrteaching");

				//$getNewRowInside$

				dt.autoIncrement('idstaffagrteaching', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},



			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('staffagrteaching', new meta_staffagrteaching('staffagrteaching'));

	}());

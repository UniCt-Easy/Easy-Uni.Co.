(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettoudrmembro() {
        MetaData.apply(this, ["progettoudrmembro"]);
        this.name = 'meta_progettoudrmembro';
    }

    meta_progettoudrmembro.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettoudrmembro,
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
						this.describeAColumn(table, 'costoorario', 'Costo orario', 'fixed.2', 30, null);
						this.describeAColumn(table, 'ricavoorario', 'Ricavo orario', 'fixed.2', 40, null);
						this.describeAColumn(table, 'orepreventivate', 'Ore/uomo preventivate', null, 50, null);
						this.describeAColumn(table, '!orerendicontate', 'Ore rendicontate', null, 60, null);
						this.describeAColumn(table, 'impegno', 'Mesi/uomo preventivati', 'fixed.2', 100, null);
						this.describeAColumn(table, 'giornipreventivati', 'Giorni/uomo preventivati', null, 110, null);
						this.describeAColumn(table, 'start', 'Dal', null, 130, null);
						this.describeAColumn(table, 'stop', 'Al', null, 140, null);
						this.describeAColumn(table, 'fondiprogetto', 'Assunto con fondi del progetto', null, 150, null);
						this.describeAColumn(table, '!idprogettoudrmembrokind_progettoudrmembrokind_title', 'Ruolo', null, 21, null);
						objCalcFieldConfig['!idprogettoudrmembrokind_progettoudrmembrokind_title'] = { tableNameLookup:'progettoudrmembrokind', columnNameLookup:'title', columnNamekey:'idprogettoudrmembrokind' };
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_surname', 'Cognome Membro', null, 11, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_forename', 'Nome Membro', null, 12, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_extmatricula', 'Matricola Membro', null, 13, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_contratto', 'Contratto Membro', null, 14, null);
						this.describeAColumn(table, '!idreg_getregistrydocentiamministrativi_macroareadidattica', 'Macroarea Membro', null, 15, null);
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_surname'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'surname', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_forename'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'forename', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_extmatricula'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'extmatricula', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_contratto'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'contratto', columnNamekey:'idreg' };
						objCalcFieldConfig['!idreg_getregistrydocentiamministrativi_macroareadidattica'] = { tableNameLookup:'getregistrydocentiamministrativi', columnNameLookup:'macroareadidattica', columnNamekey:'idreg' };
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
						table.columns["!orerendicontate"].caption = "Ore rendicontate";
						table.columns["costoorario"].caption = "Costo orario";
						table.columns["idprogettoudrmembrokind"].caption = "Ruolo";
						table.columns["idreg"].caption = "Membro";
						table.columns["impegno"].caption = "Mesi/uomo preventivati";
						table.columns["orepreventivate"].caption = "Ore/uomo preventivate";
						table.columns["ricavoorario"].caption = "Ricavo orario";
						table.columns["fondiprogetto"].caption = "Assunto con fondi del progetto";
						table.columns["giornipreventivati"].caption = "Giorni/uomo preventivati";
						table.columns["start"].caption = "Dal";
						table.columns["stop"].caption = "Al";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettoudrmembro");

				//$getNewRowInside$

				dt.autoIncrement('idprogettoudrmembro', { minimum: 99990001 });

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

    window.appMeta.addMeta('progettoudrmembro', new meta_progettoudrmembro('progettoudrmembro'));

	}());

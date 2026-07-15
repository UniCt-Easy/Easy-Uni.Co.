(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_debito() {
        MetaData.apply(this, ["debito"]);
        this.name = 'meta_debito';
    }

    meta_debito.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_debito,
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
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 2024);
						this.describeAColumn(table, 'scadenza', 'Scadenza', null, 60, null);
//$objCalcFieldConfig_seg$
						break;
					case 'stu':
						this.describeAColumn(table, 'title', 'Denominazione', null, 10, 2024);
						this.describeAColumn(table, 'scadenza', 'Scadenza', null, 50, null);
//$objCalcFieldConfig_stu$
						break;
					case 'seganagstu':
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 2024);
						this.describeAColumn(table, 'scadenza', 'Scadenza', null, 110, null);
						this.describeAColumn(table, '!idtassaconf_tassaconf_title', 'Tassa', null, 91, null);
						objCalcFieldConfig['!idtassaconf_tassaconf_title'] = { tableNameLookup:'tassaconf', columnNameLookup:'title', columnNamekey:'idtassaconf' };
						this.describeAColumn(table, '!debitodettaglio', 'Dettagli', null, 100, null);
//$objCalcFieldConfig_seganagstu$
						break;
					case 'default':
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 2024);
						this.describeAColumn(table, 'scadenza', 'Scadenza', null, 110, null);
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
					case 'seg':
						table.columns["idfasciaiseedef"].caption = "Fascia";
						table.columns["idiscrizione"].caption = "Iscrizione";
						table.columns["idiscrizioneanno"].caption = "Rinnovo iscrizione";
						table.columns["idistanza"].caption = "Istanza";
						table.columns["idnullaosta"].caption = "Nullaosta";
						table.columns["idratadef"].caption = "Rata";
						table.columns["idreg"].caption = "Studente";
						table.columns["idtassaconf"].caption = "Tassa generica";
						table.columns["title"].caption = "Denominazione";
//$innerSetCaptionConfig_seg$
						break;
					case 'stu':
//$innerSetCaptionConfig_stu$
						break;
					case 'seganagstu':
//$innerSetCaptionConfig_seganagstu$
						break;
					case 'default':
						table.columns["idtassaconf"].caption = "Tassa";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_debito");

				//$getNewRowInside$

				dt.autoIncrement('iddebito', { minimum: 99990001 });

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
					case "seg": {
						return "title desc";
					}
					case "stu": {
						return "title desc";
					}
					case "seganagstu": {
						return "title desc";
					}
					case "default": {
						return "title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('debito', new meta_debito('debito'));

	}());

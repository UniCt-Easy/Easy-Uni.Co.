(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_pianostudio() {
        MetaData.apply(this, ["pianostudio"]);
        this.name = 'meta_pianostudio';
    }

    meta_pianostudio.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_pianostudio,
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
					case 'seganagstusing':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, '!idpianostudiostatus_pianostudiostatus_title', 'Status', null, 21, null);
						objCalcFieldConfig['!idpianostudiostatus_pianostudiostatus_title'] = { tableNameLookup:'pianostudiostatus', columnNameLookup:'title', columnNamekey:'idpianostudiostatus' };
						this.describeAColumn(table, '!pianostudioattivform_alias1', 'Attività formative pianificate', null, 30, null);
//$objCalcFieldConfig_seganagstusing$
						break;
					case 'seganagstu':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'idpianostudiostatus', 'Status', null, 20, null);
						this.describeAColumn(table, '!idpianostudiostatus_pianostudiostatus_title', 'Status', null, 21, null);
						objCalcFieldConfig['!idpianostudiostatus_pianostudiostatus_title'] = { tableNameLookup:'pianostudiostatus', columnNameLookup:'title', columnNamekey:'idpianostudiostatus' };
						this.describeAColumn(table, '!pianostudioattivform', 'Attività formative pianificate', null, 30, null);
//$objCalcFieldConfig_seganagstu$
						break;
					case 'segstud':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 20, 9);
//$objCalcFieldConfig_segstud$
						break;
					case 'didprog':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 10, 9);
						this.describeAColumn(table, 'idpianostudiostatus', 'Status', null, 20, null);
						this.describeAColumn(table, '!idpianostudiostatus_pianostudiostatus_title', 'Status', null, 21, null);
						objCalcFieldConfig['!idpianostudiostatus_pianostudiostatus_title'] = { tableNameLookup:'pianostudiostatus', columnNameLookup:'title', columnNamekey:'idpianostudiostatus' };
						this.describeAColumn(table, '!pianostudioattivform', 'Attività formative pianificate', null, 30, null);
//$objCalcFieldConfig_didprog$
						break;
					case 'stupiano':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 20, 9);
						this.describeAColumn(table, '!idpianostudiostatus_pianostudiostatus_title', 'Status', null, 41, null);
						objCalcFieldConfig['!idpianostudiostatus_pianostudiostatus_title'] = { tableNameLookup:'pianostudiostatus', columnNameLookup:'title', columnNamekey:'idpianostudiostatus' };
						this.describeAColumn(table, '!pianostudioattivform', 'Attività formative pianificate', null, 50, null);
//$objCalcFieldConfig_stupiano$
						break;
					case 'stusing':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 20, 9);
						this.describeAColumn(table, '!iddidprog_didprog_title', 'Denominazione Didattica programmata', null, 11, null);
						this.describeAColumn(table, '!iddidprog_didprog_aa', 'Anno accademico Didattica programmata', null, 12, null);
						this.describeAColumn(table, '!iddidprog_didprog_idsede_title', 'Sede Didattica programmata', null, 10, null);
						objCalcFieldConfig['!iddidprog_didprog_title'] = { tableNameLookup:'didprog', columnNameLookup:'title', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_aa'] = { tableNameLookup:'didprog', columnNameLookup:'aa', columnNamekey:'iddidprog' };
						objCalcFieldConfig['!iddidprog_didprog_idsede_title'] = { tableNameLookup:'sede', columnNameLookup:'title', columnNamekey:'iddidprog' };
						this.describeAColumn(table, '!idpianostudiostatus_pianostudiostatus_title', 'Status', null, 41, null);
						objCalcFieldConfig['!idpianostudiostatus_pianostudiostatus_title'] = { tableNameLookup:'pianostudiostatus', columnNameLookup:'title', columnNamekey:'idpianostudiostatus' };
						this.describeAColumn(table, '!pianostudioattivform', 'Attività formative pianificate', null, 60, null);
//$objCalcFieldConfig_stusing$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'seganagstusing':
						table.columns["aa"].caption = "Anno accademico";
						table.columns["idpianostudio"].caption = "Identificativo";
						table.columns["idcorsostudio"].caption = "Corso di studi";
						table.columns["iddidprog"].caption = "Didattica programmata";
						table.columns["idiscrizione"].caption = "Iscrizione";
						table.columns["idiscrizionebmi"].caption = "Iscrizione al bando di mobilità internazionale";
						table.columns["idpianostudiostatus"].caption = "Status";
						table.columns["idreg"].caption = "Studente";
//$innerSetCaptionConfig_seganagstusing$
						break;
					case 'seganagstu':
						table.columns["aa"].caption = "Anno accademico";
//$innerSetCaptionConfig_seganagstu$
						break;
					case 'segstud':
//$innerSetCaptionConfig_segstud$
						break;
					case 'didprog':
//$innerSetCaptionConfig_didprog$
						break;
					case 'stupiano':
//$innerSetCaptionConfig_stupiano$
						break;
					case 'stusing':
//$innerSetCaptionConfig_stusing$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_pianostudio");

				//$getNewRowInside$

				dt.autoIncrement('idpianostudio', { minimum: 99990001 });

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
					case "seganagstusing": {
						return "aa desc";
					}
					case "seganagstu": {
						return "aa desc";
					}
					case "segstud": {
						return "aa desc";
					}
					case "didprog": {
						return "aa desc";
					}
					case "stupiano": {
						return "aa desc";
					}
					case "stusing": {
						return "aa desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('pianostudio', new meta_pianostudio('pianostudio'));

	}());

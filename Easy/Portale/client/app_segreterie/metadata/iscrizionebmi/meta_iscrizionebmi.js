(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_iscrizionebmi() {
        MetaData.apply(this, ["iscrizionebmi"]);
        this.name = 'meta_iscrizionebmi';
    }

    meta_iscrizionebmi.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_iscrizionebmi,
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
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, '!idiscrizione_iscrizione_anno', 'Anno di corso Iscrizione', null, 51, null);
						this.describeAColumn(table, '!idiscrizione_iscrizione_aa', 'Anno accademico Iscrizione', null, 53, null);
						this.describeAColumn(table, '!idiscrizione_iscrizione_iddidprog_title', 'Denominazione Iscrizione', null, 51, null);
						this.describeAColumn(table, '!idiscrizione_iscrizione_iddidprog_aa', 'Anno accademico Iscrizione', null, 52, null);
						this.describeAColumn(table, '!idiscrizione_iscrizione_iddidprog_idsede', 'Sede Iscrizione', null, 53, null);
						objCalcFieldConfig['!idiscrizione_iscrizione_anno'] = { tableNameLookup:'iscrizione', columnNameLookup:'anno', columnNamekey:'idiscrizione' };
						objCalcFieldConfig['!idiscrizione_iscrizione_aa'] = { tableNameLookup:'iscrizione', columnNameLookup:'aa', columnNamekey:'idiscrizione' };
						objCalcFieldConfig['!idiscrizione_iscrizione_iddidprog_title'] = { tableNameLookup:'didprog', columnNameLookup:'title', columnNamekey:'idiscrizione' };
						objCalcFieldConfig['!idiscrizione_iscrizione_iddidprog_aa'] = { tableNameLookup:'didprog', columnNameLookup:'aa', columnNamekey:'idiscrizione' };
						objCalcFieldConfig['!idiscrizione_iscrizione_iddidprog_idsede'] = { tableNameLookup:'didprog', columnNameLookup:'idsede', columnNamekey:'idiscrizione' };
						this.describeAColumn(table, '!idreg_registry_title', 'Identificativo', null, 31, null);
						objCalcFieldConfig['!idreg_registry_title'] = { tableNameLookup:'registry_alias2', columnNameLookup:'title', columnNamekey:'idreg' };
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
						table.columns["idbandomi"].caption = "Bando di mobilità internazionale";
						table.columns["idiscrizione"].caption = "Iscrizione";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_iscrizionebmi");

				//$getNewRowInside$

				dt.autoIncrement('idiscrizionebmi', { minimum: 99990001 });

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
						return "idreg asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('iscrizionebmi', new meta_iscrizionebmi('iscrizionebmi'));

	}());

(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_relatore() {
        MetaData.apply(this, ["relatore"]);
        this.name = 'meta_relatore';
    }

    meta_relatore.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_relatore,
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
					case 'segistcons':
						this.describeAColumn(table, '!idrelatorekind_relatorekind_title', 'Tipologia', null, 51, null);
						objCalcFieldConfig['!idrelatorekind_relatorekind_title'] = { tableNameLookup:'relatorekind', columnNameLookup:'title', columnNamekey:'idrelatorekind' };
						this.describeAColumn(table, '!idreg_docenti_registry_docenti_title', 'Relatore', null, 41, null);
						objCalcFieldConfig['!idreg_docenti_registry_docenti_title'] = { tableNameLookup:'registry_alias1', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
						objCalcFieldConfig['!idreg_docenti_registry_docenti_title'] = { tableNameLookup:'registry', columnNameLookup:'title', columnNamekey:'idreg_docenti' };
//$objCalcFieldConfig_segistcons$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'segistcons':
						table.columns["idistanza"].caption = "Istanza di conseguimento del titolo";
						table.columns["idreg"].caption = "Studente";
						table.columns["idreg_docenti"].caption = "Relatore";
						table.columns["idrelatore"].caption = "Identificativo";
						table.columns["idrelatorekind"].caption = "Tipologia";
//$innerSetCaptionConfig_segistcons$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_relatore");

				//$getNewRowInside$

				dt.autoIncrement('idrelatore', { minimum: 99990001 });

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

    window.appMeta.addMeta('relatore', new meta_relatore('relatore'));

	}());

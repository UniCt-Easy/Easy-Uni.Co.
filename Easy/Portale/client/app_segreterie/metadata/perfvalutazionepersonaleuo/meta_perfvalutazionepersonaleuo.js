(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfvalutazionepersonaleuo() {
        MetaData.apply(this, ["perfvalutazionepersonaleuo"]);
        this.name = 'meta_perfvalutazionepersonaleuo';
    }

    meta_perfvalutazionepersonaleuo.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfvalutazionepersonaleuo,
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
						this.describeAColumn(table, 'idstruttura', 'Unità organizzativa', null, 10, null);
						this.describeAColumn(table, 'punteggio', 'Punteggio', 'fixed.2', 30, null);
						this.describeAColumn(table, 'afferenza', 'Tempo di afferenza', 'fixed.2', 50, null);
						this.describeAColumn(table, '!idstruttura_struttura_title', 'Denominazione Unità organizzativa', null, 11, null);
						this.describeAColumn(table, '!idstruttura_struttura_idstrutturakind_title', 'Tipo Unità organizzativa', null, 10, null);
						objCalcFieldConfig['!idstruttura_struttura_title'] = { tableNameLookup:'struttura', columnNameLookup:'title', columnNamekey:'idstruttura' };
						objCalcFieldConfig['!idstruttura_struttura_idstrutturakind_title'] = { tableNameLookup:'strutturakind', columnNameLookup:'title', columnNamekey:'idstruttura' };
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
						table.columns["afferenza"].caption = "Tempo di afferenza";
						table.columns["idstruttura"].caption = "Unità organizzativa";
						table.columns["peso"].caption = "Peso";
						table.columns["punteggio"].caption = "Punteggio";
						table.columns["punteggiopesato"].caption = "Punteggio pesato";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfvalutazionepersonaleuo");

				//$getNewRowInside$

				dt.autoIncrement('idperfvalutazionepersonaleuo', { minimum: 99990001 });

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

			//$describeTree$
        });

    window.appMeta.addMeta('perfvalutazionepersonaleuo', new meta_perfvalutazionepersonaleuo('perfvalutazionepersonaleuo'));

	}());

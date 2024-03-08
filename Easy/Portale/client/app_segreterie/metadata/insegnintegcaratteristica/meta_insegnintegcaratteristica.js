(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_insegnintegcaratteristica() {
        MetaData.apply(this, ["insegnintegcaratteristica"]);
        this.name = 'meta_insegnintegcaratteristica';
    }

    meta_insegnintegcaratteristica.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_insegnintegcaratteristica,
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
						this.describeAColumn(table, 'cf', 'Crediti', 'fixed.2', 20, null);
						this.describeAColumn(table, 'profess', 'Professionalizzante', null, 50, null);
						this.describeAColumn(table, '!idsasd_sasd_codice', 'Codice SASD', null, 41, null);
						this.describeAColumn(table, '!idsasd_sasd_title', 'Denominazione SASD', null, 42, null);
						objCalcFieldConfig['!idsasd_sasd_codice'] = { tableNameLookup:'sasd_alias1', columnNameLookup:'codice', columnNamekey:'idsasd' };
						objCalcFieldConfig['!idsasd_sasd_title'] = { tableNameLookup:'sasd_alias1', columnNameLookup:'title', columnNamekey:'idsasd' };
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
						table.columns["cf"].caption = "Crediti";
						table.columns["idsasd"].caption = "Settore artistico scientifico disciplinare";
						table.columns["profess"].caption = "Professionalizzante";
						table.columns["idsasd"].caption = "SASD";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_insegnintegcaratteristica");

				//$getNewRowInside$

				dt.autoIncrement('idinsegnintegcaratteristica', { minimum: 99990001 });

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

    window.appMeta.addMeta('insegnintegcaratteristica', new meta_insegnintegcaratteristica('insegnintegcaratteristica'));

	}());

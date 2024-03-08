(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_insegncaratteristica() {
        MetaData.apply(this, ["insegncaratteristica"]);
        this.name = 'meta_insegncaratteristica';
    }

    meta_insegncaratteristica.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_insegncaratteristica,
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
						objCalcFieldConfig['!idsasd_sasd_codice'] = { tableNameLookup:'sasd', columnNameLookup:'codice', columnNamekey:'idsasd' };
						objCalcFieldConfig['!idsasd_sasd_title'] = { tableNameLookup:'sasd', columnNameLookup:'title', columnNamekey:'idsasd' };
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
						table.columns["idsasd"].caption = "SASD";
						table.columns["profess"].caption = "Professionalizzante";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
				var def = appMeta.Deferred("getNewRow-meta_insegncaratteristica");

				//$getNewRowInside$

				dt.autoIncrement('idinsegncaratteristica', { minimum: 99990001 });

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

    window.appMeta.addMeta('insegncaratteristica', new meta_insegncaratteristica('insegncaratteristica'));

	}());

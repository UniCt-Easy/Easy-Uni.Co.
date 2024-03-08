(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfvalutazioneateneo() {
        MetaData.apply(this, ["perfvalutazioneateneo"]);
        this.name = 'meta_perfvalutazioneateneo';
    }

    meta_perfvalutazioneateneo.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfvalutazioneateneo,
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
						this.describeAColumn(table, 'year', 'Anno', null, 20, null);
						this.describeAColumn(table, 'performance', 'Performance', 'fixed.2', 70, null);
						this.describeAColumn(table, 'calcoloautomatico', 'Risultato calcolato automaticamente', null, 80, null);
//$objCalcFieldConfig_default$
						break;
					case 'consoglie':
						this.describeAColumn(table, 'year', 'Anno', null, 20, null);
						this.describeAColumn(table, 'performance', 'Performance', 'fixed.2', 70, null);
						this.describeAColumn(table, 'calcoloautomatico', 'Calcoloautomatico', null, 80, null);
//$objCalcFieldConfig_consoglie$
						break;
					case 'obiettivi':
						this.describeAColumn(table, 'year', 'Anno', null, 20, null);
						this.describeAColumn(table, 'performance', 'Performance', 'fixed.2', 70, null);
						this.describeAColumn(table, 'calcoloautomatico', 'Risultato calcolato automaticamente', null, 80, null);
//$objCalcFieldConfig_obiettivi$
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
						table.columns["year"].caption = "Anno";
						table.columns["calcoloautomatico"].caption = "Risultato calcolato automaticamente";
//$innerSetCaptionConfig_default$
						break;
					case 'consoglie':
						table.columns["year"].caption = "Anno";
//$innerSetCaptionConfig_consoglie$
						break;
					case 'obiettivi':
						table.columns["calcoloautomatico"].caption = "Risultato calcolato automaticamente";
						table.columns["year"].caption = "Anno";
//$innerSetCaptionConfig_obiettivi$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfvalutazioneateneo");

				//$getNewRowInside$

				dt.autoIncrement('idperfvalutazioneateneo', { minimum: 99990001 });

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

    window.appMeta.addMeta('perfvalutazioneateneo', new meta_perfvalutazioneateneo('perfvalutazioneateneo'));

	}());

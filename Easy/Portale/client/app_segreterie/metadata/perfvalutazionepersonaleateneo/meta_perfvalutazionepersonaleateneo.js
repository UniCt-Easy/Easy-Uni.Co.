(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfvalutazionepersonaleateneo() {
        MetaData.apply(this, ["perfvalutazionepersonaleateneo"]);
        this.name = 'meta_perfvalutazionepersonaleateneo';
    }

    meta_perfvalutazionepersonaleateneo.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfvalutazionepersonaleateneo,
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
						this.describeAColumn(table, 'peso', 'Peso', 'fixed.2', 30, null);
						this.describeAColumn(table, 'punteggio', 'Punteggio', 'fixed.2', 40, null);
						this.describeAColumn(table, 'punteggiopesato', 'Punteggio pesato', 'fixed.2', 50, null);
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
						table.columns["peso"].caption = "Peso";
						table.columns["punteggio"].caption = "Punteggio";
						table.columns["punteggiopesato"].caption = "Punteggio pesato";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfvalutazionepersonaleateneo");

				//$getNewRowInside$

				dt.autoIncrement('idperfvalutazionepersonaleateneo', { minimum: 99990001 });

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

    window.appMeta.addMeta('perfvalutazionepersonaleateneo', new meta_perfvalutazionepersonaleateneo('perfvalutazionepersonaleateneo'));

	}());

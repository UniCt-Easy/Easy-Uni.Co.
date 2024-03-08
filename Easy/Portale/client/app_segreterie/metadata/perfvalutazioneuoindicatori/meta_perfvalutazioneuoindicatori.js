(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfvalutazioneuoindicatori() {
        MetaData.apply(this, ["perfvalutazioneuoindicatori"]);
        this.name = 'meta_perfvalutazioneuoindicatori';
    }

    meta_perfvalutazioneuoindicatori.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfvalutazioneuoindicatori,
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
						this.describeAColumn(table, 'peso', 'Peso', 'fixed.2', 20, null);
						this.describeAColumn(table, 'valorenumerico', 'Valore raggiunto', 'fixed.2', 120, null);
						this.describeAColumn(table, 'completamento', 'Percentuale di completamento', 'fixed.2', 140, null);
						this.describeAColumn(table, '!idperfindicatore_perfindicatore_title', 'Indicatore', null, 11, null);
						objCalcFieldConfig['!idperfindicatore_perfindicatore_title'] = { tableNameLookup:'perfindicatore', columnNameLookup:'title', columnNamekey:'idperfindicatore' };
						this.describeAColumn(table, '!perfvalutazioneuoindicatorisoglia', 'Soglie', null, 30, null);
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
						table.columns["completamento"].caption = "Percentuale di completamento";
						table.columns["idperfindicatore"].caption = "Indicatore";
						table.columns["valorenumerico"].caption = "Valore raggiunto";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfvalutazioneuoindicatori");

				//$getNewRowInside$

				dt.autoIncrement('idperfvalutazioneuoindicatori', { minimum: 99990001 });

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

    window.appMeta.addMeta('perfvalutazioneuoindicatori', new meta_perfvalutazioneuoindicatori('perfvalutazioneuoindicatori'));

	}());

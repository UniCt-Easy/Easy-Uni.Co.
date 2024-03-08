(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_progettofinanziamento() {
        MetaData.apply(this, ["progettofinanziamento"]);
        this.name = 'meta_progettofinanziamento';
    }

    meta_progettofinanziamento.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_progettofinanziamento,
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
						this.describeAColumn(table, 'contributoente', 'Contributo totale richiesto dall\'ateneo all’ente finanziatore', 'fixed.2', 10, null);
						this.describeAColumn(table, 'contributo', 'Cofinanziamento richiesto all\'ateneo', 'fixed.2', 20, null);
						this.describeAColumn(table, 'data', 'Data', null, 40, null);
//$objCalcFieldConfig_default$
						break;
					case 'catania':
						this.describeAColumn(table, 'contributoente', 'Contributo all’ateneo approvato dall’ente finanziatore', 'fixed.2', 10, null);
						this.describeAColumn(table, 'contributo', 'Cofinanziamento approvato', 'fixed.2', 20, null);
						this.describeAColumn(table, 'data', 'Data', null, 40, null);
//$objCalcFieldConfig_catania$
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
						table.columns["contributo"].caption = "Cofinanziamento richiesto all'ateneo";
						table.columns["contributoente"].caption = "Contributo totale richiesto dall'ateneo all’ente finanziatore";
//$innerSetCaptionConfig_default$
						break;
					case 'catania':
						table.columns["contributo"].caption = "Cofinanziamento approvato";
						table.columns["contributoente"].caption = "Contributo all’ateneo approvato dall’ente finanziatore";
//$innerSetCaptionConfig_catania$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_progettofinanziamento");

				//$getNewRowInside$

				dt.autoIncrement('idprogettofinanziamento', { minimum: 99990001 });

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

    window.appMeta.addMeta('progettofinanziamento', new meta_progettofinanziamento('progettofinanziamento'));

	}());

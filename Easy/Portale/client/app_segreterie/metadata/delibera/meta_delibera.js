(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_delibera() {
        MetaData.apply(this, ["delibera"]);
        this.name = 'meta_delibera';
    }

    meta_delibera.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_delibera,
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
						this.describeAColumn(table, 'oggetto', 'Oggetto', null, 50, 512);
						this.describeAColumn(table, 'testo', 'Testo', null, 80, -1);
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
						table.columns["iddelibera"].caption = "Identificativo";
						table.columns["idstatuskind"].caption = "Status";
						table.columns["idstruttura"].caption = "Struttura";
						table.columns["protanno"].caption = "Anno di protocollo";
						table.columns["protnumero"].caption = "Numero di protocollo";
//$innerSetCaptionConfig_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_delibera");

				//$getNewRowInside$

				dt.autoIncrement('iddelibera', { minimum: 99990001 });

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

    window.appMeta.addMeta('delibera', new meta_delibera('delibera'));

	}());

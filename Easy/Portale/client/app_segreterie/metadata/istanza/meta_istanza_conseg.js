(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanza_conseg() {
        MetaData.apply(this, ["istanza_conseg"]);
        this.name = 'meta_istanza_conseg';
    }

    meta_istanza_conseg.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanza_conseg,
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
					case 'conseg_seg':
						this.describeAColumn(table, 'datacompalmalaur', 'Data di compilazione del questionario su Almalaurea', null, 510, null);
						this.describeAColumn(table, 'fascicolo', 'Fascicolo', null, 520, 50);
						this.describeAColumn(table, 'posizione', 'Posizione', null, 580, 50);
//$objCalcFieldConfig_conseg_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'conseg_seg':
						table.columns["datacompalmalaur"].caption = "Data di compilazione del questionario su Almalaurea";
						table.columns["idappello"].caption = "Appello";
						table.columns["idistanza"].caption = "Istanza";
						table.columns["idreg"].caption = "Studenti";
						table.columns["idrichitesi"].caption = "Richiesta tesi";
//$innerSetCaptionConfig_conseg_seg$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_istanza_conseg");

				//$getNewRowInside$


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

    window.appMeta.addMeta('istanza_conseg', new meta_istanza_conseg('istanza_conseg'));

	}());

(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfruolo() {
        MetaData.apply(this, ["perfruolo"]);
        this.name = 'meta_perfruolo';
    }

    meta_perfruolo.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfruolo,
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
						this.describeAColumn(table, 'idperfruolo', 'Ruolo', null, 10, 50);
						this.describeAColumn(table, 'oper', 'Operatività', null, 30, null);
						this.describeAColumn(table, 'aggiorna', 'Compila i completamenti degli obiettivi', null, 100, null);
						this.describeAColumn(table, 'crea', 'Crea le schede e inserisce gli obiettivi', null, 110, null);
						this.describeAColumn(table, 'leggi', 'Visualizza le schede', null, 120, null);
						this.describeAColumn(table, 'valuta', 'Valuta il completamento degli obiettivi', null, 130, null);
						this.describeAColumn(table, 'approva', 'Approva le schede', null, 140, null);
						this.describeAColumn(table, 'escluso', 'Non utilizzabile nelle schede', null, 160, null);
//$objCalcFieldConfig_default$
						break;
					case 'maildest':
						this.describeAColumn(table, 'idperfruolo', 'Ruolo', null, 10, 50);
//$objCalcFieldConfig_maildest$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'maildest':
						table.columns["idperfruolo"].caption = "Ruolo";
//$innerSetCaptionConfig_maildest$
						break;
					case 'default':
						table.columns["aggiorna"].caption = "Compila i completamenti degli obiettivi";
						table.columns["approva"].caption = "Approva le schede";
						table.columns["crea"].caption = "Crea le schede e inserisce gli obiettivi";
						table.columns["escluso"].caption = "Non utilizzabile nelle schede";
						table.columns["generascheda"].caption = "Ha la scheda di valutazione sul sistema";
						table.columns["leggi"].caption = "Visualizza le schede";
						table.columns["oper"].caption = "Operatività";
						table.columns["valuta"].caption = "Valuta il completamento degli obiettivi";
//$innerSetCaptionConfig_default$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_perfruolo");

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

			//$describeTree$
        });

    window.appMeta.addMeta('perfruolo', new meta_perfruolo('perfruolo'));

	}());

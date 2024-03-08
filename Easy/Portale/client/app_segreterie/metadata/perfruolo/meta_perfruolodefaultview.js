(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfruolodefaultview() {
        MetaData.apply(this, ["perfruolodefaultview"]);
        this.name = 'meta_perfruolodefaultview';
    }

    meta_perfruolodefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfruolodefaultview,
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
						this.describeAColumn(table, 'idperfruolo', 'Ruolo', null, 1000, 50);
						this.describeAColumn(table, 'perfruolo_oper', 'Operatività', null, 3000, null);
						this.describeAColumn(table, 'perfruolo_aggiorna', 'Compila i completamenti degli obiettivi', null, 10000, null);
						this.describeAColumn(table, 'perfruolo_crea', 'Crea le schede e inserisce gli obiettivi', null, 11000, null);
						this.describeAColumn(table, 'perfruolo_leggi', 'Visualizza le schede', null, 12000, null);
						this.describeAColumn(table, 'perfruolo_valuta', 'Valuta il completamento degli obiettivi', null, 13000, null);
						this.describeAColumn(table, 'perfruolo_approva', 'Approva le schede', null, 14000, null);
						this.describeAColumn(table, 'perfruolo_escluso', 'Non utilizzabile nelle schede', null, 16000, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idperfruolo"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

			//$describeTree$
        });

    window.appMeta.addMeta('perfruolodefaultview', new meta_perfruolodefaultview('perfruolodefaultview'));

	}());

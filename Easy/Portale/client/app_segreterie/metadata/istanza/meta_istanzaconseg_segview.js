(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_istanzaconseg_segview() {
        MetaData.apply(this, ["istanzaconseg_segview"]);
        this.name = 'meta_istanzaconseg_segview';
    }

    meta_istanzaconseg_segview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_istanzaconseg_segview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'conseg_seg':
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 1000, 9);
						this.describeAColumn(table, 'istanza_data', 'Data', 'g', 3000, null);
						this.describeAColumn(table, 'didprog_title', 'Denominazione Didattica programmata', null, 6100, 1024);
						this.describeAColumn(table, 'didprog_aa', 'Anno accademico Didattica programmata', null, 6200, 9);
						this.describeAColumn(table, 'sede_title', 'Denominazione Sede Didattica programmata', null, 7920, 1024);
						this.describeAColumn(table, 'statuskind_title', 'Status', null, 10200, 50);
						this.describeAColumn(table, 'istanza_conseg_datacompalmalaur', 'Data di compilazione del questionario su Almalaurea', null, 51000, null);
						this.describeAColumn(table, 'istanza_conseg_fascicolo', 'Fascicolo', null, 52000, 50);
						this.describeAColumn(table, 'appello_description', 'Descrizione Appello', null, 53100, 1024);
						this.describeAColumn(table, 'appello_aa', 'Anno accademico Appello', null, 53200, 9);
						this.describeAColumn(table, 'istanza_conseg_posizione', 'Posizione', null, 58000, 50);
//$objCalcFieldConfig_conseg_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idistanza", "idistanzakind", "idreg_studenti"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('istanzaconseg_segview', new meta_istanzaconseg_segview('istanzaconseg_segview'));

	}());

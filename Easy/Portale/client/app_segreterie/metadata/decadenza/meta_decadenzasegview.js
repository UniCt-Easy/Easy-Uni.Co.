(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_decadenzasegview() {
        MetaData.apply(this, ["decadenzasegview"]);
        this.name = 'meta_decadenzasegview';
    }

    meta_decadenzasegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_decadenzasegview,
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
					case 'seg':
						this.describeAColumn(table, 'registrystudenti_title', 'Studente', null, 1300, 101);
						this.describeAColumn(table, 'iscrizione_aa', 'Anno accademico Iscrizione', null, 2100, 9);
						this.describeAColumn(table, 'iscrizione_anno', 'Anno di corso Iscrizione', null, 2300, null);
						this.describeAColumn(table, 'iscrizione_iddidprog', 'Didattica programmata Iscrizione', null, 2500, null);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 3000, 9);
						this.describeAColumn(table, 'decadenza_data', 'Data', 'g', 4000, null);
						this.describeAColumn(table, 'decadenza_protanno', 'Anno di protocollo', null, 5000, null);
						this.describeAColumn(table, 'decadenza_protnumero', 'Numero di protocollo', null, 6000, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["iddecadenza", "idiscrizione", "idreg_studenti"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "registrystudenti_title asc , iscrizione_anno asc , iscrizione_iddidprog asc ";
					}
					case "seg": {
						return "registrystudenti_title asc , iscrizione_aa asc , iscrizione_anno asc , iscrizione_iddidprog asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('decadenzasegview', new meta_decadenzasegview('decadenzasegview'));

	}());

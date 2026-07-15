(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_debitosegview() {
        MetaData.apply(this, ["debitosegview"]);
        this.name = 'meta_debitosegview';
    }

    meta_debitosegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_debitosegview,
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
						this.describeAColumn(table, 'registry_title', 'Studente', null, 1300, 101);
						this.describeAColumn(table, 'debito_title', 'Denominazione', null, 2000, 2024);
						this.describeAColumn(table, 'debito_scadenza', 'Scadenza', null, 6000, null);
						this.describeAColumn(table, 'iscrizione_aa', 'Anno accademico Iscrizione', null, 7100, 9);
						this.describeAColumn(table, 'iscrizione_anno', 'Anno di corso Iscrizione', null, 7300, null);
						this.describeAColumn(table, 'iscrizione_iddidprog', 'Didattica programmata Iscrizione', null, 7500, null);
						this.describeAColumn(table, 'iscrizioneanno_aa', 'Anno Accademico Rinnovo iscrizione', null, 8100, 9);
						this.describeAColumn(table, 'iscrizioneanno_iddidprog', 'Didattica programmata Rinnovo iscrizione', null, 8200, null);
						this.describeAColumn(table, 'iscrizioneanno_anno', 'Anno Rinnovo iscrizione', null, 8300, null);
						this.describeAColumn(table, 'istanza_aa', 'Anno accademico Istanza', null, 9200, 9);
						this.describeAColumn(table, 'istanza_data', 'Data Istanza', 'g', 9300, null);
						this.describeAColumn(table, 'istanza_idistanzakind', 'Tipologia Istanza', null, 9600, null);
						this.describeAColumn(table, 'nullaosta_data', 'Nullaosta', 'g', 10200, null);
						this.describeAColumn(table, 'XXdebitodettaglio', 'Dettagli', null, 11000, null);
						this.describeAColumn(table, 'tassaconf_title', 'Tassa generica', null, 11300, 2024);
						this.describeAColumn(table, 'fasciaiseedef_idfasciaisee', 'Fascia', null, 16100, 50);
						this.describeAColumn(table, 'ratadef_idratakind', 'Rata', null, 17100, 50);
						this.describeAColumn(table, 'XXpagamento', 'Pagamento', null, 20000, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "iddebito"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "title desc";
					}
					case "seg": {
						return "debito_title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('debitosegview', new meta_debitosegview('debitosegview'));

	}());

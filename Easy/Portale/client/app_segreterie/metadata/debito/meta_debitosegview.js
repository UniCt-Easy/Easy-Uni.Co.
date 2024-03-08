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
						this.describeAColumn(table, 'title', 'Denominazione', null, 20, 2024);
						this.describeAColumn(table, 'debito_codicebollettino', 'Codicebollettino', null, 30, null);
						this.describeAColumn(table, 'debito_codicemav', 'Codicemav', null, 40, 50);
						this.describeAColumn(table, 'iscrizione_anno', 'Anno di corso Iscrizione', null, 50, null);
						this.describeAColumn(table, 'iscrizione_iddidprog', 'Didattica programmata Iscrizione', null, 50, null);
						this.describeAColumn(table, 'iscrizione_aa', 'Anno accademico Iscrizione', null, 50, 9);
						this.describeAColumn(table, 'istanza_aa', 'Anno accademico Istanza', null, 60, 9);
						this.describeAColumn(table, 'istanza_extension', 'Tabella che estende il record Istanza', null, 60, 200);
						this.describeAColumn(table, 'nullaosta_data', 'Nullaosta', 'g', 70, null);
						this.describeAColumn(table, 'tassaconf_title', 'Tassa', null, 90, 2024);
						this.describeAColumn(table, 'debito_IUV', 'IUV', null, 100, null);
						this.describeAColumn(table, 'debito_scadenza', 'Scadenza', null, 110, null);
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
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('debitosegview', new meta_debitosegview('debitosegview'));

	}());

(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_creditosegview() {
        MetaData.apply(this, ["creditosegview"]);
        this.name = 'meta_creditosegview';
    }

    meta_creditosegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_creditosegview,
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
						this.describeAColumn(table, 'registry_title', 'Denominazione Studente Debito che ha generato il pagamento', null, 3130, 101);
						this.describeAColumn(table, 'debito_title', 'Denominazione Debito che ha generato il pagamento', null, 3200, 2024);
						this.describeAColumn(table, 'debito_scadenza', 'Scadenza Debito che ha generato il pagamento', null, 3600, null);
						this.describeAColumn(table, 'pagamento_dataora', 'Data e ora Pagamento che ha generato il credito', 'g', 4200, null);
						this.describeAColumn(table, 'pagamentokind_title', 'Tipologia Tipologia Pagamento che ha generato il credito', null, 4420, 50);
						this.describeAColumn(table, 'autorizzato', 'Autorizzato', null, 5000, null);
						this.describeAColumn(table, 'XXpagamento', 'Pagamento', null, 20000, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "iddebito", "idcredito", "idpagamento"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('creditosegview', new meta_creditosegview('creditosegview'));

	}());

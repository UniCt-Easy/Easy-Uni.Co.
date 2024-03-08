(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_commissregistry_docentidefaultview() {
        MetaData.apply(this, ["commissregistry_docentidefaultview"]);
        this.name = 'meta_commissregistry_docentidefaultview';
    }

    meta_commissregistry_docentidefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_commissregistry_docentidefaultview,
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
					case 'default':
						this.describeAColumn(table, 'registry_docenti_docenti_matricola', 'Matricola', null, 10, 50);
						this.describeAColumn(table, 'registry_docenti_idreg', 'Identificativo', null, 10, null);
						this.describeAColumn(table, 'registry_docenti_docenti_idsasd', 'SASD', null, 20, null);
						this.describeAColumn(table, 'registry_docenti_docenti_idstruttura', 'Struttura di afferenza', null, 30, null);
						this.describeAColumn(table, 'registry_docenti_title', 'Denominazione', null, 30, 101);
						this.describeAColumn(table, 'registry_docenti_docenti_idreg_istituti', 'Istituto, Ente o Azienda', null, 40, null);
						this.describeAColumn(table, 'registry_docenti_cf', 'Codice fiscale', null, 40, 16);
						this.describeAColumn(table, 'registry_docenti_docenti_idclassconsorsuale', 'Classe consorsuale', null, 50, null);
						this.describeAColumn(table, 'registry_docenti_p_iva', 'Partita iva', null, 50, 15);
						this.describeAColumn(table, 'registry_docenti_active', 'attivo', null, 60, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idprova", "idappello", "idcommiss", "idreg_docenti"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('commissregistry_docentidefaultview', new meta_commissregistry_docentidefaultview('commissregistry_docentidefaultview'));

	}());

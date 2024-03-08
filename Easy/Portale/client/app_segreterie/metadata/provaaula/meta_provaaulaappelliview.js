(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_provaaulaappelliview() {
        MetaData.apply(this, ["provaaulaappelliview"]);
        this.name = 'meta_provaaulaappelliview';
    }

    meta_provaaulaappelliview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_provaaulaappelliview,
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
					case 'appelli':
						this.describeAColumn(table, 'aula_title', 'Denominazione', null, 10, 1024);
						this.describeAColumn(table, 'aula_code', 'Codice', null, 20, 128);
						this.describeAColumn(table, 'aula_idedificio', 'Edificio', null, 30, null);
						this.describeAColumn(table, 'aula_idstruttura', 'Struttra didattica di afferenza', null, 40, null);
						this.describeAColumn(table, 'aula_capienza', 'Capienza', null, 50, null);
						this.describeAColumn(table, 'aula_capienzadis', 'Capienza disabili', null, 60, null);
						this.describeAColumn(table, 'aula_idaulakind', 'Tipologia', null, 70, null);
//$objCalcFieldConfig_appelli$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idaula", "idsede", "idprova", "idappello", "idedificio"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('provaaulaappelliview', new meta_provaaulaappelliview('provaaulaappelliview'));

	}());

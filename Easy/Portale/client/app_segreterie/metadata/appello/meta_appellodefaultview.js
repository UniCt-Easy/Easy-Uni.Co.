(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_appellodefaultview() {
        MetaData.apply(this, ["appellodefaultview"]);
        this.name = 'meta_appellodefaultview';
    }

    meta_appellodefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_appellodefaultview,
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
						this.describeAColumn(table, 'description', 'Descrizione', null, 1000, 1024);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 2000, 9);
						this.describeAColumn(table, 'appelloazionekind_title', 'Ordinario/Correttivo/Integrativo', null, 8200, 50);
						this.describeAColumn(table, 'appellokind_title', 'Tipologia', null, 9200, 50);
						this.describeAColumn(table, 'sessionekind_title', 'Tipologia Tipologia Sessione', null, 10320, 50);
						this.describeAColumn(table, 'sessione_start', 'Data di inizio Sessione', null, 10400, null);
						this.describeAColumn(table, 'sessione_stop', 'Data di fine Sessione', null, 10500, null);
						this.describeAColumn(table, 'appello_minvoto', 'Voto minimo', null, 14000, null);
						this.describeAColumn(table, 'appello_basevoto', 'Votazione di base', null, 15000, null);
						this.describeAColumn(table, 'appello_prointermedia', 'Prova intermedia', null, 16000, null);
						this.describeAColumn(table, 'appello_posti', 'Numero massimo di posti', null, 17000, null);
						this.describeAColumn(table, 'appello_prenotstart', 'Data di inizio prenotazioni', 'g', 18000, null);
						this.describeAColumn(table, 'appello_penotend', 'Data fine delle prenotazioni', 'g', 19000, null);
						this.describeAColumn(table, 'appello_publicato', 'Publicato', null, 20000, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idappello"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('appellodefaultview', new meta_appellodefaultview('appellodefaultview'));

	}());

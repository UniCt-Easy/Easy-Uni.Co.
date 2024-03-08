(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_appelloerogataview() {
        MetaData.apply(this, ["appelloerogataview"]);
        this.name = 'meta_appelloerogataview';
    }

    meta_appelloerogataview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_appelloerogataview,
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
					case 'erogata':
						this.describeAColumn(table, 'description', 'Descrizione', null, 10, 1024);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 20, 9);
						this.describeAColumn(table, 'appelloazionekind_title', 'Ordinario/Correttivo/Integrativo', null, 80, 50);
						this.describeAColumn(table, 'appellokind_title', 'Tipologia', null, 90, 50);
						this.describeAColumn(table, 'sessione_start', 'Data di inizio Sessione', null, 100, null);
						this.describeAColumn(table, 'sessione_stop', 'Data di fine Sessione', null, 100, null);
						this.describeAColumn(table, 'appello_minvoto', 'Voto minimo', null, 140, null);
						this.describeAColumn(table, 'appello_basevoto', 'Votazione di base', null, 150, null);
						this.describeAColumn(table, 'appello_prointermedia', 'Prova intermedia', null, 160, null);
						this.describeAColumn(table, 'appello_posti', 'Numero massimo di posti', null, 170, null);
						this.describeAColumn(table, 'appello_prenotstart', 'Data di inizio prenotazioni', 'g', 180, null);
						this.describeAColumn(table, 'appello_penotend', 'Data fine delle prenotazioni', 'g', 190, null);
						this.describeAColumn(table, 'appello_publicato', 'Publicato', null, 200, null);
						this.describeAColumn(table, 'sessionekind_title', 'Tipologia', null, 30, 50);
//$objCalcFieldConfig_erogata$
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

    window.appMeta.addMeta('appelloerogataview', new meta_appelloerogataview('appelloerogataview'));

	}());

(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registrationuserauthview() {
        MetaData.apply(this, ["registrationuserauthview"]);
        this.name = 'meta_registrationuserauthview';
    }

    meta_registrationuserauthview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registrationuserauthview,
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
					case 'auth':
						this.describeAColumn(table, 'registrationuser_surname', 'Cognome', null, 1000, 50);
						this.describeAColumn(table, 'registrationuser_forename', 'Nome', null, 2000, 49);
						this.describeAColumn(table, 'registrationuser_cf', 'Codice fiscale', null, 3000, 16);
						this.describeAColumn(table, 'registrationuser_email', 'E-Mail', null, 5000, 1024);
						this.describeAColumn(table, 'registrationuser_login', 'Login', null, 6000, 60);
						this.describeAColumn(table, 'usertype', 'Categoria di utente', null, 7000, 50);
						this.describeAColumn(table, 'registrationuser_matricola', 'Matricola', null, 8000, 50);
						this.describeAColumn(table, 'userkind_title', 'Tipologia di accesso', null, 9100, 64);
						this.describeAColumn(table, 'registrationuserstatus_title', 'Stato della richiesta', null, 10200, 64);
						this.describeAColumn(table, 'registrationuser_requesttimestamp', 'Data della richiesta', 'g', 11000, null);
						this.describeAColumn(table, 'title', 'Descrizione ruolo', null, 16000, 150);
						this.describeAColumn(table, 'registrationuser_start', 'Data inizio', null, 17000, null);
						this.describeAColumn(table, 'registrationuser_stop', 'Data fine', null, 18000, null);
						this.describeAColumn(table, 'registrationuser_flagdefault', 'Flagdefault', null, 19000, null);
						this.describeAColumn(table, 'sortingusable01_sortcode', 'Codice Classificazione 1', null, 23100, 50);
						this.describeAColumn(table, 'sortingusable01_description', 'Denominazione Classificazione 1', null, 23200, 200);
						this.describeAColumn(table, 'sortingusable02_sortcode', 'Codice Classificazione 2', null, 24100, 50);
						this.describeAColumn(table, 'sortingusable02_description', 'Denominazione Classificazione 2', null, 24200, 200);
						this.describeAColumn(table, 'sortingusable03_sortcode', 'Codice Classificazione 3', null, 25100, 50);
						this.describeAColumn(table, 'sortingusable03_description', 'Denominazione Classificazione 3', null, 25200, 200);
						this.describeAColumn(table, 'sortingusable04_sortcode', 'Codice Classificazione 4', null, 26100, 50);
						this.describeAColumn(table, 'sortingusable04_description', 'Denominazione Classificazione 4', null, 26200, 200);
						this.describeAColumn(table, 'sortingusable05_sortcode', 'Codice Classificazione 5', null, 27100, 50);
						this.describeAColumn(table, 'sortingusable05_description', 'Denominazione Classificazione 5', null, 27200, 200);
//$objCalcFieldConfig_auth$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idregistrationuser"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "auth": {
						return "surname asc , registrationuser_forename asc ";
					}
					case "auth": {
						return "registrationuser_surname asc , registrationuser_forename asc , title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registrationuserauthview', new meta_registrationuserauthview('registrationuserauthview'));

	}());

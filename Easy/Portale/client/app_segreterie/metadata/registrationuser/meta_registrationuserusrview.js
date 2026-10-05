(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registrationuserusrview() {
        MetaData.apply(this, ["registrationuserusrview"]);
        this.name = 'meta_registrationuserusrview';
    }

    meta_registrationuserusrview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registrationuserusrview,
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
					case 'usr':
						this.describeAColumn(table, 'registrationuser_surname', 'Cognome', null, 1000, 50);
						this.describeAColumn(table, 'registrationuser_forename', 'Nome', null, 2000, 49);
						this.describeAColumn(table, 'registrationuser_cf', 'Codice fiscale', null, 3000, 16);
						this.describeAColumn(table, 'registrationuser_email', 'E-Mail', null, 5000, 1024);
						this.describeAColumn(table, 'registrationuser_login', 'Login', null, 6000, 60);
						this.describeAColumn(table, 'usertype', 'Categoria di utente', null, 7000, 50);
						this.describeAColumn(table, 'registrationuserstatus_title', 'Stato della richiesta', null, 8200, 64);
						this.describeAColumn(table, 'registrationuser_requesttimestamp', 'Data della richiesta', 'g', 11000, null);
						this.describeAColumn(table, 'title', 'Descrizione ruolo', null, 16000, 150);
						this.describeAColumn(table, 'registrationuser_flagdefault', 'Flagdefault', null, 22000, null);
						this.describeAColumn(table, 'registrationuser_start', 'Data inizio', null, 33000, null);
						this.describeAColumn(table, 'registrationuser_stop', 'Data fine', null, 34000, null);
//$objCalcFieldConfig_usr$
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
					case "usr": {
						return "surname asc , registrationuser_forename asc ";
					}
					case "usr": {
						return "surname asc , forename asc ";
					}
					case "usr": {
						return "registrationuser_surname asc , registrationuser_forename asc , title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registrationuserusrview', new meta_registrationuserusrview('registrationuserusrview'));

	}());

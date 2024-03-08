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
						this.describeAColumn(table, 'surname', 'Cognome', null, 1000, 50);
						this.describeAColumn(table, 'registrationuser_forename', 'Nome', null, 2000, 49);
						this.describeAColumn(table, 'registrationuser_cf', 'Codice fiscale', null, 3000, 16);
						this.describeAColumn(table, 'registrationuser_email', 'E-Mail', null, 5000, 1024);
						this.describeAColumn(table, 'registrationuser_login', 'Login', null, 6000, 60);
						this.describeAColumn(table, 'usertype', 'Categoria di utente', null, 7000, 50);
						this.describeAColumn(table, 'registrationuserstatus_title', 'Stato della richiesta', null, 8200, 64);
						this.describeAColumn(table, 'registrationuser_requesttimestamp', 'Data della richiesta', 'g', 11000, null);
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
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registrationuserauthview', new meta_registrationuserauthview('registrationuserauthview'));

	}());

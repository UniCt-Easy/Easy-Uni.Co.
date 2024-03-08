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
						this.describeAColumn(table, 'surname', 'Cognome', null, 1000, 50);
						this.describeAColumn(table, 'forename', 'Nome', null, 2000, 49);
						this.describeAColumn(table, 'cf', 'Codice fiscale', null, 3000, 16);
						this.describeAColumn(table, 'email', 'E-Mail', null, 5000, 1024);
						this.describeAColumn(table, 'login', 'Login', null, 6000, 60);
						this.describeAColumn(table, 'usertype', 'Categoria di utente', null, 7000, 50);
						this.describeAColumn(table, 'registrationuserstatus_title', 'Stato della richiesta', null, 8200, 64);
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
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registrationuserusrview', new meta_registrationuserusrview('registrationuserusrview'));

	}());

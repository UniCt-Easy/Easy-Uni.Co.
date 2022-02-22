
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


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
						this.describeAColumn(table, 'surname', 'Cognome', null, 10, 50);
						this.describeAColumn(table, 'registrationuser_forename', 'Nome', null, 20, 49);
						this.describeAColumn(table, 'registrationuser_cf', 'Codice fiscale', null, 30, 16);
						this.describeAColumn(table, 'registrationuser_email', 'E-Mail', null, 50, 1024);
						this.describeAColumn(table, 'registrationuser_login', 'Login', null, 60, 60);
						this.describeAColumn(table, 'usertype_usertype', 'Categoria di utente', null, 70, 50);
						this.describeAColumn(table, 'registrationuserstatus_title', 'Stato della richiesta', null, 80, 64);
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

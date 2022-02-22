
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

    function meta_registryreference() {
        MetaData.apply(this, ["registryreference"]);
        this.name = 'meta_registryreference';
    }

    meta_registryreference.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registryreference,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var objCalcFieldConfig = {};
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'user':
						this.describeAColumn(table, '!clientpassword', 'Password', null, 0, null);
						this.describeAColumn(table, '!confirmpassword', 'Conferma password', null, 0, null);
						this.describeAColumn(table, 'referencename', 'Nome Contatto', null, 10, 50);
						this.describeAColumn(table, 'email', 'E-Mail', null, 40, 200);
						this.describeAColumn(table, 'phonenumber', 'Numero di telefono', null, 80, 50);
						this.describeAColumn(table, 'faxnumber', 'Numero Fax', null, 90, 50);
						this.describeAColumn(table, 'mobilenumber', 'Numero di cellulare', null, 100, 20);
						this.describeAColumn(table, 'pec', 'Pec', null, 110, 200);
						this.describeAColumn(table, 'userweb', 'Nome utente', null, 110, 40);
						this.describeAColumn(table, 'passwordweb', 'Password', null, 120, 40);
						this.describeAColumn(table, 'website', 'Web page', null, 200, 512);
//$objCalcFieldConfig_user$
						break;
					case 'persone':
						this.describeAColumn(table, 'referencename', 'Nome Contatto', null, 10, 50);
						this.describeAColumn(table, 'flagdefault', 'Contatto predefinito', null, 30, null);
						this.describeAColumn(table, 'email', 'Email', null, 40, 200);
						this.describeAColumn(table, 'skypenumber', 'Skype No.', null, 60, 50);
						this.describeAColumn(table, 'msnnumber', 'MSN No.', null, 70, 50);
						this.describeAColumn(table, 'phonenumber', 'Numero tel.', null, 80, 50);
						this.describeAColumn(table, 'faxnumber', 'Numero fax.', null, 90, 50);
						this.describeAColumn(table, 'mobilenumber', 'Num. cellulare', null, 100, 20);
						this.describeAColumn(table, 'pec', 'Pec', null, 110, 200);
						this.describeAColumn(table, 'userweb', 'login web', null, 110, 40);
						this.describeAColumn(table, 'passwordweb', 'password per accesso web', null, 120, 40);
						this.describeAColumn(table, 'registryreferencerole', 'Funzione contatto', null, 130, 50);
						this.describeAColumn(table, 'website', 'Website', null, 200, 512);
//$objCalcFieldConfig_persone$
						break;
					case 'seg':
						this.describeAColumn(table, 'referencename', 'Nome Contatto', null, 10, 50);
						this.describeAColumn(table, 'flagdefault', 'Contatto predefinito', null, 30, null);
						this.describeAColumn(table, 'email', 'Email', null, 40, 200);
						this.describeAColumn(table, 'skypenumber', 'Skype No.', null, 60, 50);
						this.describeAColumn(table, 'msnnumber', 'MSN No.', null, 70, 50);
						this.describeAColumn(table, 'phonenumber', 'Numero tel.', null, 80, 50);
						this.describeAColumn(table, 'faxnumber', 'Numero fax.', null, 90, 50);
						this.describeAColumn(table, 'mobilenumber', 'Num. cellulare', null, 100, 20);
						this.describeAColumn(table, 'pec', 'Pec', null, 110, 200);
						this.describeAColumn(table, 'website', 'Website', null, 200, 512);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'user':
						table.columns["!clientpassword"].caption = "Password";
						table.columns["!confirmpassword"].caption = "Conferma password";
						table.columns["email"].caption = "E-Mail";
						table.columns["faxnumber"].caption = "Numero Fax";
						table.columns["mobilenumber"].caption = "Numero di cellulare";
						table.columns["passwordweb"].caption = "Password";
						table.columns["phonenumber"].caption = "Numero di telefono";
						table.columns["userweb"].caption = "Nome utente";
						table.columns["website"].caption = "Web page";
//$innerSetCaptionConfig_user$
						break;
					case 'persone':
						table.columns["activeweb"].caption = "accesso web attivato?";
						table.columns["ct"].caption = "data creazione";
						table.columns["cu"].caption = "nome utente creazione";
						table.columns["email"].caption = "Email";
						table.columns["faxnumber"].caption = "Numero fax.";
						table.columns["flagdefault"].caption = "Contatto predefinito";
						table.columns["idreg"].caption = "id anagrafica (tabella registry)";
						table.columns["idregistryreference"].caption = "#";
						table.columns["iterweb"].caption = "iterazioni algoritmo di hashing";
						table.columns["lt"].caption = "data ultima modifica";
						table.columns["lu"].caption = "nome ultimo utente modifica";
						table.columns["mobilenumber"].caption = "Num. cellulare";
						table.columns["msnnumber"].caption = "MSN No.";
						table.columns["passwordweb"].caption = "password per accesso web";
						table.columns["phonenumber"].caption = "Numero tel.";
						table.columns["referencename"].caption = "Nome Contatto";
						table.columns["registryreferencerole"].caption = "Funzione contatto";
						table.columns["rtf"].caption = "allegati";
						table.columns["saltweb"].caption = "sale per la codifica della password";
						table.columns["skypenumber"].caption = "Skype No.";
						table.columns["txt"].caption = "note testuali";
						table.columns["userweb"].caption = "login web";
//$innerSetCaptionConfig_persone$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_registryreference");

				//$getNewRowInside$

				dt.autoIncrement('idregistryreference', { minimum: 99990001 });

				// metto i default
				return this.superClass.getNewRow(parentRow, dt, editType)
					.then(function (dtRow) {
						//$getNewRowDefault$
						return def.resolve(dtRow);
					});
			},



			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "user": {
						return "idregistryreference asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registryreference', new meta_registryreference('registryreference'));

	}());

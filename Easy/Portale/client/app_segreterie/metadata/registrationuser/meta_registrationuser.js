(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_registrationuser() {
        MetaData.apply(this, ["registrationuser"]);
        this.name = 'meta_registrationuser';
    }

    meta_registrationuser.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registrationuser,
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
					case 'auth':
						this.describeAColumn(table, 'surname', 'Cognome', null, 10, 50);
						this.describeAColumn(table, 'forename', 'Nome', null, 20, 49);
						this.describeAColumn(table, 'cf', 'Codice fiscale', null, 30, 16);
						this.describeAColumn(table, 'email', 'E-Mail', null, 50, 1024);
						this.describeAColumn(table, 'login', 'Login', null, 60, 60);
						this.describeAColumn(table, 'usertype', 'Categoria di utente', null, 70, 50);
						this.describeAColumn(table, 'requesttimestamp', 'Data della richiesta', 'g', 110, null);
//$objCalcFieldConfig_auth$
						break;
					case 'usr':
						this.describeAColumn(table, 'surname', 'Cognome', null, 10, 50);
						this.describeAColumn(table, 'forename', 'Nome', null, 20, 49);
						this.describeAColumn(table, 'cf', 'Codice fiscale', null, 30, 16);
						this.describeAColumn(table, 'email', 'E-Mail', null, 50, 1024);
						this.describeAColumn(table, 'login', 'Login', null, 60, 60);
						this.describeAColumn(table, 'usertype', 'Categoria di utente', null, 70, 50);
//$objCalcFieldConfig_usr$
						break;
//$objCalcFieldConfig$
				}
				table['customObjCalculateFields'] = objCalcFieldConfig;
				appMeta.metaModel.computeRowsAs(table, listType, this.superClass.calculateFields);
				return appMeta.Deferred("describeColumns").resolve();
			},


			setCaption: function (table, edittype) {
				switch (edittype) {
					case 'usr':
						table.columns["cf"].caption = "Codice fiscale";
						table.columns["email"].caption = "E-Mail";
						table.columns["forename"].caption = "Nome";
						table.columns["idregistrationuserstatus"].caption = "Stato della richiesta";
						table.columns["surname"].caption = "Cognome";
						table.columns["userkind"].caption = "Tipologia di accesso";
						table.columns["usertype"].caption = "Categoria di utente";
//$innerSetCaptionConfig_usr$
						break;
					case 'auth':
						table.columns["cf"].caption = "Codice fiscale";
						table.columns["requesttimestamp"].caption = "Data della richiesta";
//$innerSetCaptionConfig_auth$
						break;
//$innerSetCaptionConfig$
				}
			},


			getNewRow: function (parentRow, dt, editType){
               var def = appMeta.Deferred("getNewRow-meta_registrationuser");

				//$getNewRowInside$

				dt.autoIncrement('idregistrationuser', { minimum: 99990001 });

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
					case "auth": {
						return "surname asc , forename asc ";
					}
					case "usr": {
						return "surname asc , forename asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registrationuser', new meta_registrationuser('registrationuser'));

	}());

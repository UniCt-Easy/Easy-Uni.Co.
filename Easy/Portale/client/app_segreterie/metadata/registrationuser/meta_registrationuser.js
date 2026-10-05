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
						this.describeAColumn(table, 'matricola', 'Matricola', null, 80, 50);
						this.describeAColumn(table, 'requesttimestamp', 'Data della richiesta', 'g', 110, null);
						this.describeAColumn(table, 'title', 'Descrizione ruolo', null, 160, 150);
						this.describeAColumn(table, 'start', 'Data inizio', null, 170, null);
						this.describeAColumn(table, 'stop', 'Data fine', null, 180, null);
						this.describeAColumn(table, 'flagdefault', 'Flagdefault', null, 190, null);
//$objCalcFieldConfig_auth$
						break;
					case 'usr':
						this.describeAColumn(table, 'surname', 'Cognome', null, 10, 50);
						this.describeAColumn(table, 'forename', 'Nome', null, 20, 49);
						this.describeAColumn(table, 'cf', 'Codice fiscale', null, 30, 16);
						this.describeAColumn(table, 'email', 'E-Mail', null, 50, 1024);
						this.describeAColumn(table, 'login', 'Login', null, 60, 60);
						this.describeAColumn(table, 'usertype', 'Categoria di utente', null, 70, 50);
						this.describeAColumn(table, 'requesttimestamp', 'Data della richiesta', 'g', 110, null);
						this.describeAColumn(table, 'title', 'Descrizione ruolo', null, 160, 150);
						this.describeAColumn(table, 'flagdefault', 'Flagdefault', null, 220, null);
						this.describeAColumn(table, 'start', 'Data inizio', null, 330, null);
						this.describeAColumn(table, 'stop', 'Data fine', null, 340, null);
//$objCalcFieldConfig_usr$
						break;
					case 'new':
						this.describeAColumn(table, '!password', 'Password', null, 0, null);
						this.describeAColumn(table, 'surname', 'Cognome', null, 10, 50);
						this.describeAColumn(table, 'forename', 'Nome', null, 20, 49);
						this.describeAColumn(table, 'cf', 'Codice fiscale', null, 30, 16);
						this.describeAColumn(table, 'email', 'E-Mail', null, 50, 1024);
						this.describeAColumn(table, 'login', 'Username', null, 60, 60);
						this.describeAColumn(table, 'usertype', 'Categoria di utente', null, 70, 50);
						this.describeAColumn(table, 'matricola', 'Matricola', null, 80, 50);
						this.describeAColumn(table, 'requesttimestamp', 'Data della richiesta', 'g', 110, null);
						this.describeAColumn(table, 'title', 'Descrizione ruolo', null, 160, 150);
						this.describeAColumn(table, 'start', 'Data inizio', null, 170, null);
						this.describeAColumn(table, 'stop', 'Data fine', null, 180, null);
						this.describeAColumn(table, 'flagdefault', 'Nodo di default', null, 190, null);
//$objCalcFieldConfig_new$
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
						table.columns["title"].caption = "Descrizione ruolo";
						table.columns["cf"].caption = "Codice fiscale";
						table.columns["email"].caption = "E-Mail";
						table.columns["forename"].caption = "Nome";
						table.columns["idregistrationuserstatus"].caption = "Stato della richiesta";
						table.columns["idsor01"].caption = "Classificazione 1";
						table.columns["idsor02"].caption = "Classificazione 2";
						table.columns["idsor03"].caption = "Classificazione 3";
						table.columns["idsor04"].caption = "Classificazione 4";
						table.columns["idsor05"].caption = "Classificazione 5";
						table.columns["requesttimestamp"].caption = "Data della richiesta";
						table.columns["start"].caption = "Data inizio";
						table.columns["stop"].caption = "Data fine";
						table.columns["surname"].caption = "Cognome";
						table.columns["userkind"].caption = "Tipologia di accesso";
						table.columns["usertype"].caption = "Categoria di utente";
//$innerSetCaptionConfig_usr$
						break;
					case 'auth':
						table.columns["all_sorkind01"].caption = "Vedi tutto";
						table.columns["all_sorkind02"].caption = "Vedi tutto";
						table.columns["all_sorkind03"].caption = "Vedi tutto";
						table.columns["all_sorkind04"].caption = "Vedi tutto";
						table.columns["all_sorkind05"].caption = "Vedi tutto";
						table.columns["sorkind01_withchilds"].caption = "Con gerarchia sottostante";
						table.columns["sorkind02_withchilds"].caption = "Con gerarchia sottostante";
						table.columns["sorkind03_withchilds"].caption = "Con gerarchia sottostante";
						table.columns["sorkind04_withchilds"].caption = "Con gerarchia sottostante";
						table.columns["sorkind05_withchilds"].caption = "Con gerarchia sottostante";
//$innerSetCaptionConfig_auth$
						break;
					case 'new':
						table.columns["flagdefault"].caption = "Nodo di default";
						table.columns["login"].caption = "Username";
						table.columns["!password"].caption = "Password";
//$innerSetCaptionConfig_new$
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
					case "auth": {
						return "surname asc , forename asc , title desc";
					}
					case "usr": {
						return "surname asc , forename asc , title desc";
					}
					case "new": {
						return "surname asc , forename asc , title desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('registrationuser', new meta_registrationuser('registrationuser'));

	}());

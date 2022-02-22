
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

    function meta_rendicontlezionestuddefaultview() {
        MetaData.apply(this, ["rendicontlezionestuddefaultview"]);
        this.name = 'meta_rendicontlezionestuddefaultview';
    }

    meta_rendicontlezionestuddefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_rendicontlezionestuddefaultview,
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
						this.describeAColumn(table, 'registry_studenti_studenti_authinps', 'Autorizzazione all\'istituto di accedere ai propri dati INPS', null, 10, null);
						this.describeAColumn(table, 'rendicontlezionestud_assente', 'Assente', null, 20, null);
						this.describeAColumn(table, 'registry_studenti_studenti_idreg', 'Codice Istituto', null, 20, null);
						this.describeAColumn(table, 'registry_studenti_studenti_idstuddirittokind', 'Tipologia per il diritto allo studio', null, 30, null);
						this.describeAColumn(table, 'registry_studenti_title', 'Denominazione', null, 30, 101);
						this.describeAColumn(table, 'rendicontlezionestud_ritardo', 'Ritardo', 'g', 30, null);
						this.describeAColumn(table, 'registry_studenti_studenti_idstudprenotkind', 'Tipologia per la prenotazione degli appelli', null, 40, null);
						this.describeAColumn(table, 'registry_studenti_cf', 'Codice fiscale', null, 40, 16);
						this.describeAColumn(table, 'rendicontlezionestud_ritardogiustifica', 'Giustificazione del ritardo', null, 40, 1024);
						this.describeAColumn(table, 'registry_studenti_p_iva', 'Partita iva', null, 50, 15);
						this.describeAColumn(table, 'rendicontlezionestud_notadisciplinare', 'Nota disciplinare', null, 50, 1024);
						this.describeAColumn(table, 'registry_studenti_active', 'attivo', null, 60, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["aa", "idaula", "idsede", "idcanale", "iddidprog", "idlezione", "idedificio", "idattivform", "iddidprogori", "idaffidamento", "idcorsostudio", "iddidproganno", "iddidprogcurr", "idreg_docenti", "idreg_studenti", "iddidprogporzanno"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('rendicontlezionestuddefaultview', new meta_rendicontlezionestuddefaultview('rendicontlezionestuddefaultview'));

	}());

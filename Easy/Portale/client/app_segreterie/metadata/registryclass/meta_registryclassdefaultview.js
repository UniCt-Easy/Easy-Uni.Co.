
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

    function meta_registryclassdefaultview() {
        MetaData.apply(this, ["registryclassdefaultview"]);
        this.name = 'meta_registryclassdefaultview';
    }

    meta_registryclassdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_registryclassdefaultview,
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
						this.describeAColumn(table, 'idregistryclass', 'Codice', null, 10, 2);
						this.describeAColumn(table, 'description', 'Descrizione', null, 20, 150);
						this.describeAColumn(table, 'registryclass_active', 'Attivo', null, 30, null);
						this.describeAColumn(table, 'registryclass_flagbadgecode', 'Codice badge visibile', null, 40, null);
						this.describeAColumn(table, 'registryclass_flagbadgecode_forced', 'Codice badge obbligatorio', null, 50, null);
						this.describeAColumn(table, 'registryclass_flagCF', 'Codice fiscale visibile', null, 60, null);
						this.describeAColumn(table, 'registryclass_flagcf_forced', 'Codice fiscale obbligatorio', null, 70, null);
						this.describeAColumn(table, 'registryclass_flagcfbutton', 'Bottone \"calcola codice fiscale\" visibile', null, 80, null);
						this.describeAColumn(table, 'registryclass_flagextmatricula', 'Matricola esterna visibile', null, 90, null);
						this.describeAColumn(table, 'registryclass_flagextmatricula_forced', 'Matricola esterna obbligatoria', null, 100, null);
						this.describeAColumn(table, 'registryclass_flagfiscalresidence', 'Campo residenza visibile', null, 110, null);
						this.describeAColumn(table, 'registryclass_flagfiscalresidence_forced', 'inserimento residenza obbligatorio', null, 120, null);
						this.describeAColumn(table, 'registryclass_flagforeigncf', 'Codice fiscale estero visibile', null, 130, null);
						this.describeAColumn(table, 'registryclass_flagforeigncf_forced', 'Codice fiscale estero obbligatorio', null, 140, null);
						this.describeAColumn(table, 'registryclass_flaghuman', 'Persona fisica', null, 150, null);
						this.describeAColumn(table, 'registryclass_flaginfofromcfbutton', 'Bottone \"Comune, Data da C.F.\" visibile', null, 160, null);
						this.describeAColumn(table, 'registryclass_flagmaritalstatus', 'Campo stato civile visibile', null, 170, null);
						this.describeAColumn(table, 'registryclass_flagmaritalstatus_forced', 'Campo stato civile obbligatorio', null, 180, null);
						this.describeAColumn(table, 'registryclass_flagmaritalsurname', 'Cognome acquisito visibile', null, 190, null);
						this.describeAColumn(table, 'registryclass_flagmaritalsurname_forced', 'Cognome acquisito obbligatorio', null, 200, null);
						this.describeAColumn(table, 'registryclass_flagothers', 'campo non usato', null, 210, null);
						this.describeAColumn(table, 'registryclass_flagothers_forced', 'campo non usato', null, 220, null);
						this.describeAColumn(table, 'registryclass_flagp_iva', 'Partita iva visibile', null, 230, null);
						this.describeAColumn(table, 'registryclass_flagp_iva_forced', 'Partita iva obbligatoria', null, 240, null);
						this.describeAColumn(table, 'registryclass_flagqualification', 'campo \"Titolo\" visibile', null, 250, null);
						this.describeAColumn(table, 'registryclass_flagqualification_forced', 'campo \"Titolo\" obbligatorio', null, 260, null);
						this.describeAColumn(table, 'registryclass_flagresidence', 'Usato congiuntamente a flagresidence_forced per stabilire se l\'indirizzo di residenza ? obbligatorio, Da solo non ha un gran significato poich? non esiste un campo indirizzo di residenza', null, 270, null);
						this.describeAColumn(table, 'registryclass_flagresidence_forced', 'Informazioni sulla residenza obbligatorie', null, 280, null);
						this.describeAColumn(table, 'registryclass_flagtitle', 'Campo Denominazione diverso da cognome+nome, inserito manualmente', null, 290, null);
						this.describeAColumn(table, 'registryclass_flagtitle_forced', 'Non usato, il campo denominazione  ? sempre obbligatorio in un modo o nell\'altro', null, 300, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idregistryclass"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('registryclassdefaultview', new meta_registryclassdefaultview('registryclassdefaultview'));

	}());


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

    function meta_appelloerogataview() {
        MetaData.apply(this, ["appelloerogataview"]);
        this.name = 'meta_appelloerogataview';
    }

    meta_appelloerogataview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_appelloerogataview,
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
					case 'erogata':
						this.describeAColumn(table, 'description', 'Descrizione', null, 10, 1024);
						this.describeAColumn(table, 'aa', 'Anno accademico', null, 20, 9);
						this.describeAColumn(table, 'appelloazionekind_title', 'Ordinario/Correttivo/Integrativo', null, 80, 50);
						this.describeAColumn(table, 'appellokind_title', 'Tipologia', null, 90, 50);
						this.describeAColumn(table, 'sessione_start', 'Data di inizio Sessione', null, 100, null);
						this.describeAColumn(table, 'sessione_stop', 'Data di fine Sessione', null, 100, null);
						this.describeAColumn(table, 'appello_minvoto', 'Voto minimo', null, 140, null);
						this.describeAColumn(table, 'appello_basevoto', 'Votazione di base', null, 150, null);
						this.describeAColumn(table, 'appello_prointermedia', 'Prova intermedia', null, 160, null);
						this.describeAColumn(table, 'appello_posti', 'Numero massimo di posti', null, 170, null);
						this.describeAColumn(table, 'appello_prenotstart', 'Data di inizio prenotazioni', 'g', 180, null);
						this.describeAColumn(table, 'appello_penotend', 'Data fine delle prenotazioni', 'g', 190, null);
						this.describeAColumn(table, 'appello_publicato', 'Publicato', null, 200, null);
						this.describeAColumn(table, 'sessionekind_title', 'Tipologia', null, 30, 50);
//$objCalcFieldConfig_erogata$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idappello"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('appelloerogataview', new meta_appelloerogataview('appelloerogataview'));

	}());

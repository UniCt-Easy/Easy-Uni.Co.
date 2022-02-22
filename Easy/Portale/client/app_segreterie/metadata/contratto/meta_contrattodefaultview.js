
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

    function meta_contrattodefaultview() {
        MetaData.apply(this, ["contrattodefaultview"]);
        this.name = 'meta_contrattodefaultview';
    }

    meta_contrattodefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_contrattodefaultview,
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
						this.describeAColumn(table, 'contrattokind_title', 'Tipologia di contratto', null, 10, 50);
						this.describeAColumn(table, 'inquadramento_idcontrattokind', 'Identificativo Inquadramento', null, 20, null);
						this.describeAColumn(table, 'inquadramento_title', 'Denominazione Inquadramento', null, 20, 2048);
						this.describeAColumn(table, 'inquadramento_tempdef', 'Tempo definito Inquadramento', null, 20, null);
						this.describeAColumn(table, 'contratto_start', 'Inizio', null, 30, null);
						this.describeAColumn(table, 'contratto_stop', 'Fine', null, 40, null);
						this.describeAColumn(table, 'contratto_parttime', 'Part-time %', 'fixed.2', 50, null);
						this.describeAColumn(table, 'contratto_tempdef', 'Tempo definito', null, 70, null);
						this.describeAColumn(table, 'contratto_tempindet', 'Tempo indeterminato', null, 80, null);
						this.describeAColumn(table, 'contratto_scatto', 'Scatto', null, 110, null);
						this.describeAColumn(table, 'contratto_classe', 'Classe', null, 120, null);
						this.describeAColumn(table, 'contratto_percentualesufondiateneo', 'Percentuale su fondi interni', 'fixed.2', 140, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idcontratto"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

			//$describeTree$
        });

    window.appMeta.addMeta('contrattodefaultview', new meta_contrattodefaultview('contrattodefaultview'));

	}());


/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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

    function meta_accordoscambiomidettsegview() {
        MetaData.apply(this, ["accordoscambiomidettsegview"]);
        this.name = 'meta_accordoscambiomidettsegview';
    }

    meta_accordoscambiomidettsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_accordoscambiomidettsegview,
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
					case 'seg':
						this.describeAColumn(table, 'registryistitutiesteri_title', 'Istituto estero', null, 10, 101);
						this.describeAColumn(table, 'isced2013_detailedfield', 'Classificazione ISCED 2013', null, 30, 64);
						this.describeAColumn(table, 'torkind_title', 'Tipologia Modalit� di invio del trascript of record', null, 50, 50);
						this.describeAColumn(table, 'torkind_description', 'Descrizione Modalit� di invio del trascript of record', null, 50, 256);
						this.describeAColumn(table, 'accordoscambiomidett_numdocincoming', 'Numero di docenti incoming', null, 60, null);
						this.describeAColumn(table, 'accordoscambiomidett_numdocoutgoing', 'Numero di docenti outgoing', null, 70, null);
						this.describeAColumn(table, 'accordoscambiomidett_numpersincoming', 'Numero di personale incoming', null, 80, null);
						this.describeAColumn(table, 'accordoscambiomidett_numpersoutgoing', 'Numero di personale outgoing', null, 90, null);
						this.describeAColumn(table, 'accordoscambiomidett_numstulearincoming', 'Numero di studenti incoming for learning', null, 100, null);
						this.describeAColumn(table, 'accordoscambiomidett_numstulearoutgoing', 'Numero di studenti outgoing for learning', null, 110, null);
						this.describeAColumn(table, 'accordoscambiomidett_numstutraincoming', 'Numero di studenti incoming for traineeship', null, 120, null);
						this.describeAColumn(table, 'accordoscambiomidett_numstutraoutgoing', 'Numero di studenti outgoing for traineeship', null, 130, null);
						this.describeAColumn(table, 'accordoscambiomidett_stipula', 'Data di stipula', null, 140, null);
						this.describeAColumn(table, 'accordoscambiomidett_stop', 'Data di termine dell\'accordo', null, 150, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idaccordoscambiomi", "idreg_istitutiesteri", "idaccordoscambiomidett"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

			//$describeTree$
        });

    window.appMeta.addMeta('accordoscambiomidettsegview', new meta_accordoscambiomidettsegview('accordoscambiomidettsegview'));

	}());


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

    function meta_dichiardisabil_segview() {
        MetaData.apply(this, ["dichiardisabil_segview"]);
        this.name = 'meta_dichiardisabil_segview';
    }

    meta_dichiardisabil_segview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_dichiardisabil_segview,
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
					case 'disabil_seg':
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 10, 9);
						this.describeAColumn(table, 'dichiar_date', 'Data', null, 30, null);
						this.describeAColumn(table, 'registry_title', 'Studente', null, 60, 101);
						this.describeAColumn(table, 'dichiardisabilkind_title', 'Titolo Topologia', null, 520, 50);
						this.describeAColumn(table, 'dichiardisabilkind_specification', 'Specifica Topologia', null, 520, 50);
						this.describeAColumn(table, 'dichiardisabilsuppkind_title', 'Supporto richiesto', null, 530, 50);
						this.describeAColumn(table, 'dichiar_disabil_percentuale', 'Percentuale', 'fixed.2', 550, null);
						this.describeAColumn(table, 'dichiar_disabil_permanente', 'Permanente (S/N)', null, 560, null);
						this.describeAColumn(table, 'dichiar_disabil_scadenza', 'Data scadenza', null, 570, null);
//$objCalcFieldConfig_disabil_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "iddichiar"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('dichiardisabil_segview', new meta_dichiardisabil_segview('dichiardisabil_segview'));

	}());

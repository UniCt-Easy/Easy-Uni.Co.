
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

    function meta_dichiardisabil_seganagstuview() {
        MetaData.apply(this, ["dichiardisabil_seganagstuview"]);
        this.name = 'meta_dichiardisabil_seganagstuview';
    }

    meta_dichiardisabil_seganagstuview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_dichiardisabil_seganagstuview,
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
					case 'disabil_seganagstu':
						this.describeAColumn(table, 'aa', 'Anno Accademico', null, 10, 9);
						this.describeAColumn(table, 'dichiar_date', 'Data', null, 30, null);
						this.describeAColumn(table, 'dichiarkind_title', 'Tipologia', null, 50, 50);
						this.describeAColumn(table, 'dichiar_disabil_iddichiardisabilkind', 'Iddichiardisabilkind', null, 520, null);
						this.describeAColumn(table, 'dichiar_disabil_iddichiardisabilsuppkind', 'Iddichiardisabilsuppkind', null, 530, null);
						this.describeAColumn(table, 'dichiar_disabil_percentuale', 'Percentuale', 'fixed.2', 550, null);
						this.describeAColumn(table, 'dichiar_disabil_permanente', 'Permanente', null, 560, null);
						this.describeAColumn(table, 'dichiar_disabil_scadenza', 'Scadenza', null, 570, null);
						this.describeAColumn(table, 'dichiardisabilkind_title', 'Iddichiardisabilkind', null, 520, 50);
						this.describeAColumn(table, 'dichiardisabilsuppkind_title', 'Iddichiardisabilsuppkind', null, 530, 50);
//$objCalcFieldConfig_disabil_seganagstu$
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

    window.appMeta.addMeta('dichiardisabil_seganagstuview', new meta_dichiardisabil_seganagstuview('dichiardisabil_seganagstuview'));

	}());

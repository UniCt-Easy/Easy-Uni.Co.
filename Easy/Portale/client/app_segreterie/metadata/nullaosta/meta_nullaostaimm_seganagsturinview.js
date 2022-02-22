
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

    function meta_nullaostaimm_seganagsturinview() {
        MetaData.apply(this, ["nullaostaimm_seganagsturinview"]);
        this.name = 'meta_nullaostaimm_seganagsturinview';
    }

    meta_nullaostaimm_seganagsturinview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_nullaostaimm_seganagsturinview,
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
					case 'imm_seganagsturin':
						this.describeAColumn(table, 'data', 'Data', 'g', 20, null);
						this.describeAColumn(table, 'nullaosta_protnumero', 'Numero di protocollo', null, 50, null);
						this.describeAColumn(table, 'nullaosta_protanno', 'Anno di protocollo', null, 60, null);
						this.describeAColumn(table, 'nullaosta_imm_annoimm', 'anno di corso di immatricolazione', null, 10, null);
						this.describeAColumn(table, 'didprogcurr_title', 'Curriculum', null, 10, 256);
						this.describeAColumn(table, 'didprogori_title', 'Corso e orientamento', null, 20, 256);
						this.describeAColumn(table, 'nullaosta_imm_parttime', 'Parttime', null, 70, null);
//$objCalcFieldConfig_imm_seganagsturin$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "iddidprog", "idistanza", "idnullaosta", "idcorsostudio", "idistanzakind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('nullaostaimm_seganagsturinview', new meta_nullaostaimm_seganagsturinview('nullaostaimm_seganagsturinview'));

	}());

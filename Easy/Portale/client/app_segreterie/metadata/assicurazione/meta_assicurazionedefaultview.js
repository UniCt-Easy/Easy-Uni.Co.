
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

    function meta_assicurazionedefaultview() {
        MetaData.apply(this, ["assicurazionedefaultview"]);
        this.name = 'meta_assicurazionedefaultview';
    }

    meta_assicurazionedefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_assicurazionedefaultview,
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
						this.describeAColumn(table, 'societaassicura', 'Società assicurativa', null, 10, 1024);
						this.describeAColumn(table, 'assicurazione_datarilascio', 'Data di rilascio', null, 20, null);
						this.describeAColumn(table, 'assicurazione_datascadenza', 'Data di scadenza', null, 30, null);
						this.describeAColumn(table, 'assicurazione_infortunisullavoro', 'Infortunio sul lavoro', null, 50, null);
						this.describeAColumn(table, 'assicurazione_rca', 'Rca', null, 70, null);
						this.describeAColumn(table, 'assicurazione_spostamenti', 'Spostamenti', null, 90, null);
						this.describeAColumn(table, 'assicurazione_viaggi', 'Viaggi', null, 100, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idassicurazione"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('assicurazionedefaultview', new meta_assicurazionedefaultview('assicurazionedefaultview'));

	}());


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


(function () {

	// deriva da MetaData
	var MetaData = window.appMeta.MetaData;

	function MetaEasyData() {
		MetaData.apply(this, arguments);
		this.sec = appMeta.security;
		// var di sicurezza notevoli
		this.q = window.jsDataQuery;
	}

	MetaEasyData.prototype = _.extend(
		new MetaData(),
		{
			constructor: MetaEasyData,
			superClass: MetaData.prototype,
			getNewRow: function (parentRow, dt) {
				var def = appMeta.Deferred("getNewRow-MetaEasyData");
				var realParentObjectRow = parentRow ? parentRow.current : undefined;
				var objRow = dt.newRow({}, realParentObjectRow);
				// torno la dataRow creata
				return def.resolve(objRow.getRow());
			},

			/**
			 *
			 * @param {DataTable} dt
			 */
			setDefaults: function (dt) {
				var logUserClos = ['cu', 'lu'];
				var logTimeClos = ['ct', 'lt'];
				var numericColumnsType = ['Decimal','Int32','Int16','Int64','Double','Float','Single'];
				var objDefaults = {};
				_.forEach(dt.columns, function (c) {
					if (logUserClos.includes(c.name)){
						objDefaults[c.name] = appMeta.security.usr('userweb');
					}

					if (logTimeClos.includes(c.name)) {
						objDefaults[c.name] = new Date();
					}

					if (dt.isKey(c)) {
						if (numericColumnsType.includes(c.ctype) && !dt.defaults()[c.name]) {
							objDefaults[c.name] = 0;
						}
						if (c.ctype === 'String' && (dt.defaults()[c.name] === undefined || dt.defaults()[c.name] === null)) {
							objDefaults[c.name] = '';
						}
						if (c.ctype === 'DateTime'){
							objDefaults[c.name] = new Date();
						}
					}
				});

				dt.defaults(objDefaults);
			}

		});

	appMeta.MetaEasyData = MetaEasyData;
}());

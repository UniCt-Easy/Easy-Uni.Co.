
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

    function meta_expenseview() {
        MetaData.apply(this, ["expenseview"]);
        this.name = 'meta_expenseview';
    }

    meta_expenseview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_expenseview,
			superClass: MetaData.prototype,

			//$describeColumns$

			//$setCaptions$

			//$getNewRow$

			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('expenseview', new meta_expenseview('expenseview'));

	}());
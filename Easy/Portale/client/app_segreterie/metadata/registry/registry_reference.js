
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
    var MetaPage = window.appMeta.MetaPage;
    var q = window.jsDataQuery;
    
    function metaPage_registryreference() {
        MetaPage.apply(this, arguments);
        this.name = 'metaPage_registryreference';   
        this.startFilter = q.or(q.eq('idreg',1) , q.eq('idreg',2), q.eq('idreg',6), q.eq('idreg',1040471), q.eq('idreg',1040479));
    }

    metaPage_registryreference.prototype = _.extend(
        new MetaPage('registry', 'reference', true),
        {
            constructor: metaPage_registryreference,

            superClass: MetaPage.prototype
        });

	window.appMeta.addMetaPage('registry', 'reference', metaPage_registryreference);

}());

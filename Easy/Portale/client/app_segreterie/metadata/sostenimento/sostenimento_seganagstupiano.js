
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
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_sostenimento() {
		MetaPage.apply(this, ['sostenimento', 'seganagstupiano', true]);
        this.name = 'Sostenimenti';
		this.defaultListType = 'seganagstupiano';
		//pageHeaderDeclaration
    }

    metaPage_sostenimento.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_sostenimento,
            superClass: MetaPage.prototype,

            getName:function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			beforeFill:function () {
				var self = this;
				var parentRow = self.state.currentRow;
				
				if(!parentRow.data)
					parentRow.data =  new Date();
				//beforeFillFilter
				
				return self.superClass.beforeFill.call(self);
			},

			//afterFill

			//afterLink

			//afterRowSelect

			//rowSelected

			//buttonClickEnd

			//buttons
        });

	window.appMeta.addMetaPage('sostenimento', 'seganagstupiano', metaPage_sostenimento);

}());

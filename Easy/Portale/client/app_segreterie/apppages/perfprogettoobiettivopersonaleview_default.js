
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
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_perfprogettoobiettivopersonaleview() {
		MetaPage.apply(this, ['perfprogettoobiettivopersonaleview', 'default', true]);
        this.name = 'Obiettivi dei progetti Strategici di altre UO';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_perfprogettoobiettivopersonaleview.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfprogettoobiettivopersonaleview,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			afterClear: function () {
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettoobiettivopersonaleview'), this.getDataTable('perfprogettoobiettivosoglia'));
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#perfprogettoobiettivopersonaleview_default_completamento'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('perfprogettoobiettivopersonaleview'), this.getDataTable('perfprogettoobiettivosoglia'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.setDenyNull("perfprogettoobiettivopersonaleview","idperfvalutazioneuo");
				this.setDenyNull("perfprogettoobiettivopersonaleview","idstruttura");
				this.setDenyNull("perfprogettoobiettivopersonaleview","idperfprogettoobiettivo");
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			//buttons
        });

	window.appMeta.addMetaPage('perfprogettoobiettivopersonaleview', 'default', metaPage_perfprogettoobiettivopersonaleview);

}());

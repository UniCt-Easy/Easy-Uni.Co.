
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

    function metaPage_stipendio() {
		MetaPage.apply(this, ['stipendio', 'default', true]);
        this.name = 'Tabella stipendiale';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_stipendio.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_stipendio,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-stipendio_default");
				var arraydef = [];
				
				arraydef.push(this.managestipendio_default_tredicesima());
				arraydef.push(this.managestipendio_default_lordo());
				arraydef.push(this.managestipendio_default_tesoro());
				arraydef.push(this.managestipendio_default_previdenza());
				arraydef.push(this.managestipendio_default_irap());
				arraydef.push(this.managestipendio_default_totalece());
				arraydef.push(this.managestipendio_default_totale());
				//afterGetFormDataInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return def.resolve();
					});
				return def.promise();
			},
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				this.managestipendio_default_tredicesima();
				this.managestipendio_default_lordo();
				this.managestipendio_default_tesoro();
				this.managestipendio_default_previdenza();
				this.managestipendio_default_irap();
				this.managestipendio_default_totalece();
				this.managestipendio_default_totale();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-stipendio_default");
				var arraydef = [];
				
				//beforeFillInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return self.superClass.beforeFill.call(self)
							.then(function () {
								return def.resolve();
							});
					});
				return def.promise();
			},

			//afterClear

			afterFill: function () {
				this.enableControl($('#stipendio_default_tredicesima'), false);
				this.enableControl($('#stipendio_default_lordo'), false);
				this.enableControl($('#stipendio_default_tesoro'), false);
				this.enableControl($('#stipendio_default_previdenza'), false);
				this.enableControl($('#stipendio_default_irap'), false);
				this.enableControl($('#stipendio_default_totalece'), false);
				this.enableControl($('#stipendio_default_totale'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			managestipendio_default_tredicesima: function () {
				this.state.currentRow['!tredicesima'] = (this.state.currentRow.stipendio + this.state.currentRow.iis) / 12;

			},

			managestipendio_default_lordo: function () {
				this.state.currentRow.lordo = (this.state.currentRow.stipendio + this.state.currentRow.iis)/12*13 + this.state.currentRow.assegno;

			},

			managestipendio_default_tesoro: function () {
			this.state.currentRow['!tesoro'] = this.state.currentRow.lordo * 0.242;

			},

			managestipendio_default_previdenza: function () {
				this.state.currentRow['!previdenza'] = 0.071 * (0.8 * this.state.currentRow.stipendio + 0.48 * this.state.currentRow.iis) / 12 * 13;

			},

			managestipendio_default_irap: function () {
				this.state.currentRow.irap = this.state.currentRow.lordo * 0.085;

			},

			managestipendio_default_totalece: function () {
				this.state.currentRow['!totalece'] = this.state.currentRow['!tesoro'] + this.state.currentRow['!previdenza'] + this.state.currentRow.irap;

			},

			managestipendio_default_totale: function () {
				this.state.currentRow.totale = this.state.currentRow.lordo + this.state.currentRow['!totalece'];

			},

			//buttons
        });

	window.appMeta.addMetaPage('stipendio', 'default', metaPage_stipendio);

}());


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

    function metaPage_perfvalutazioneateneo() {
		MetaPage.apply(this, ['perfvalutazioneateneo', 'default', false]);
        this.name = 'Scheda di valutazione di Ateneo';
		this.defaultListType = 'default';
		this.firstSearchFilter = window.jsDataQuery.constant(true);
		//pageHeaderDeclaration
    }

    metaPage_perfvalutazioneateneo.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_perfvalutazioneateneo,
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
				var def = appMeta.Deferred("afterGetFormData-perfvalutazioneateneo_default");
				var arraydef = [];
				
				arraydef.push(this.manageperfvalutazioneateneo_default_performance());
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
				
				this.manageperfvalutazioneateneo_default_performance();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-perfvalutazioneateneo_default");
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
				this.enableControl($('#perfvalutazioneateneo_default_performance'), false);
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

			manageperfvalutazioneateneo_default_performance: function () {
				if (this.getDataTable("perfvalutazioneateneores").rows.length > 0) {
					var arrayPsuo = _.map(this.getDataTable("perfvalutazioneateneores").rows, function (r) { return { valore: r.percentualeraggiunta, peso: r.peso } });
					var average = this.calculateWeightedAverage(arrayPsuo);
					if(this.state.currentRow.performance != average)
						this.state.currentRow.performance= average;
				}
			},

			//buttons
        });

	window.appMeta.addMetaPage('perfvalutazioneateneo', 'default', metaPage_perfvalutazioneateneo);

}());

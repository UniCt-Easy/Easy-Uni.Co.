
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

    function metaPage_flowchart() {
		MetaPage.apply(this, ['flowchart', 'segamm', false]);
        this.name = 'Diritti utenti';
		this.defaultListType = 'segamm';
		this.isList = true;
		this.isTree = true;
		//pageHeaderDeclaration
    }

    metaPage_flowchart.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_flowchart,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			beforeFill: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				appMeta.metaModel.getTemporaryValues(this.getDataTable('flowchartrestrictedfunction'));
				appMeta.metaModel.getTemporaryValues(this.getDataTable('flowchartuser'));
				if (!parentRow.nlevel)
					parentRow.nlevel = 1;
				if (!parentRow.paridflowchart)
					parentRow.paridflowchart = (new Date()).getFullYear().toString().substr(2, 3);
				if (!parentRow.printingorder)
					parentRow.printingorder = 1;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-flowchart_segamm");
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
				this.enableControl($('#flowchart_segamm_idflowchart'), false);
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

			beforeSelectTreeManager: function () {
				var def = appMeta.Deferred('beforeSelectTreeManager');
				return def.resolve(true);
			},

			//buttons
        });

	window.appMeta.addMetaPage('flowchart', 'segamm', metaPage_flowchart);

}());

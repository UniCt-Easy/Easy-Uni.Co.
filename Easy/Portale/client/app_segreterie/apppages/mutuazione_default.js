(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_mutuazione() {
		MetaPage.apply(this, ['mutuazione', 'default', true]);
        this.name = 'Mutuazione o fruizione';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_mutuazione.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_mutuazione,
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
				var def = appMeta.Deferred("afterGetFormData-mutuazione_default");
				var arraydef = [];
				
				arraydef.push(this.managemutuazione_default_title());
				arraydef.push(this.managemutuazione_default_idsede());
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
				
				if (!parentRow.riferimento)
					parentRow.riferimento = "N";
				this.managemutuazione_default_idsede();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-mutuazione_default");
				var arraydef = [];
				
				arraydef.push(this.managemutuazione_default_title());
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

			//afterFill

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			managemutuazione_default_title: function () {
				var def = appMeta.Deferred("beforeFill-managemutuazione_title");
				var self = this;
				var currcanale = _.find(this.state.DS.tables.canale.rows, function (row) {
					return row.idcanale === self.state.currentRow.idcanale_from;
				});
				var output = "<table>" + _.join(
					_.map(this.state.DS.tables.mutuazionecaratteristica.rows, function (row) {
						if (row.idmutuazione === self.state.currentRow.idmutuazione)
							return "<tr class='table-in-cell-tr' ><td class='table-in-cell-td' >" + row.title + '</td></tr>';
					}),
					''
				) + '</table>';

				var p = [];
				p.push([currcanale, 'title', 'Canale mutuato']);
				p.push([output, null, 'CF e ore assegnati']);
				this.state.currentRow.json = this.stringify(p, 'json');
				this.state.currentRow.title = this.stringify(p, 'string');

				return def.resolve();

			},

			managemutuazione_default_idsede: function () {
this.state.currentRow.idsede= this.state.callerState.currentRow.idsede;
			},

			//buttons
        });

	window.appMeta.addMetaPage('mutuazione', 'default', metaPage_mutuazione);

}());

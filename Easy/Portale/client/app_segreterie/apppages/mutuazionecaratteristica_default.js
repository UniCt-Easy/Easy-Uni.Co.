(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_mutuazionecaratteristica() {
		MetaPage.apply(this, ['mutuazionecaratteristica', 'default', true]);
        this.name = 'Caratteristiche della mutuazione';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_mutuazionecaratteristica.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_mutuazionecaratteristica,
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
				var def = appMeta.Deferred("afterGetFormData-mutuazionecaratteristica_default");
				var arraydef = [];
				
				arraydef.push(this.managemutuazionecaratteristica_default_title());
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
				
				if (!parentRow.profess)
					parentRow.profess = "N";
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-mutuazionecaratteristica_default");
				var arraydef = [];
				
				arraydef.push(this.managemutuazionecaratteristica_default_title());
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

			managemutuazionecaratteristica_default_title: function () {
				var def = appMeta.Deferred("beforeFill-managemutuazionecaratteristica_title");
				var self = this;
				var currtipoattform = _.find(this.state.DS.tables.tipoattformdefaultview.rows, function (row) {
					return row.idtipoattform === self.state.currentRow.idtipoattform;
				});
				var currambitoareadisc = _.find(this.state.DS.tables.ambitoareadisc.rows, function (row) {
					return row.idambitoareadisc === self.state.currentRow.idambitoareadisc;
				});
				var currsasd = _.find(this.state.DS.tables.sasddefaultview.rows, function (row) {
					return row.idsasd === self.state.currentRow.idsasd;
				});

				var output = _.join(
					_.map(this.state.DS.tables.mutuazionecaratteristicaora.rows, function (row) {
						if (row.idmutuazionecaratteristica === self.state.currentRow.idmutuazionecaratteristica)
							return row.ora + ' ore di ' + row['!idorakind_orakind_title'];
					}),
					', '
				);

				var p = [];
				p.push([this.state.currentRow, 'cf', 'Crediti']);
				p.push([currtipoattform, 'title', 'Attività']);
				p.push([currambitoareadisc, 'title', 'Ambito']);
				p.push([currsasd, 'sasd_codice', 'SSD']);
				p.push([output, null, 'Ore']);
				this.state.currentRow.json = this.stringify(p, 'json');
				this.state.currentRow.title = this.stringify(p, 'string');

				return def.resolve();

			},

			//buttons
        });

	window.appMeta.addMetaPage('mutuazionecaratteristica', 'default', metaPage_mutuazionecaratteristica);

}());

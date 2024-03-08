(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_attivformcaratteristica() {
		MetaPage.apply(this, ['attivformcaratteristica', 'default', true]);
        this.name = 'Caratteristiche dell\'attività formativa';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_attivformcaratteristica.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_attivformcaratteristica,
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
				var def = appMeta.Deferred("afterGetFormData-attivformcaratteristica_default");
				var arraydef = [];
				
				arraydef.push(this.manageattivformcaratteristica_default_title());
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
				var def = appMeta.Deferred("beforeFill-attivformcaratteristica_default");
				var arraydef = [];
				
				arraydef.push(this.manageattivformcaratteristica_default_title());
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

			manageattivformcaratteristica_default_title: function () {
				var def = appMeta.Deferred("beforeFill-manageattivform_title");
				var self = this;
				var currtipoattform = _.find(this.state.DS.tables.tipoattform.rows, function (row) {
					return row.idtipoattform === self.state.currentRow.idtipoattform;
				});
				var currambitoareadisc = _.find(this.state.DS.tables.ambitoareadiscdefaultview.rows, function (row) {
					return row.idambitoareadisc === self.state.currentRow.idambitoareadisc;
				});
				var currsasd = _.find(this.state.DS.tables.sasddefaultview.rows, function (row) {
					return row.idsasd === self.state.currentRow.idsasd;
				});

				var output = _.join(
					_.map(this.state.DS.tables.attivformcaratteristicaora.rows, function (row) {
						if (row.idattivformcaratteristica === self.state.currentRow.idattivformcaratteristica)
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

	window.appMeta.addMetaPage('attivformcaratteristica', 'default', metaPage_attivformcaratteristica);

}());

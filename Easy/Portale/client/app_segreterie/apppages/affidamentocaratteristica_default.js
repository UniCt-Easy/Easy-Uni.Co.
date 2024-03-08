(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_affidamentocaratteristica() {
		MetaPage.apply(this, ['affidamentocaratteristica', 'default', true]);
        this.name = 'Caratteristiche dell\'affidamento';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_affidamentocaratteristica.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_affidamentocaratteristica,
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
				var def = appMeta.Deferred("afterGetFormData-affidamentocaratteristica_default");
				var arraydef = [];
				
				arraydef.push(this.manageaffidamentocaratteristica_default_title());
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
				var def = appMeta.Deferred("beforeFill-affidamentocaratteristica_default");
				var arraydef = [];
				
				arraydef.push(this.manageaffidamentocaratteristica_default_title());
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
				this.enableControl($('#affidamentocaratteristica_default_idsasdgruppo'), false);
				this.enableControl($('#affidamentocaratteristica_default_professSi'), false);
				this.enableControl($('#affidamentocaratteristica_default_professNo'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				appMeta.metaModel.cachedTable(this.getDataTable("ambitoareadiscdefaultview"), true);
				appMeta.metaModel.lockRead(this.getDataTable("ambitoareadiscdefaultview"));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				//afterRowSelectin
				var arraydef = [];
				var self = this;
				if (t.name === "tipoattformdefaultview" && r !== null) {
					var filter = this.q.and(this.q.eq('idattivform', this.state.currentRow.idattivform), this.q.eq('idtipoattform', r.idtipoattform));
					var def = appMeta.getData.runSelect('attivformcaratteristica', 'idambitoareadisc', filter, null)
						.then(function (dt) {
							var ambiti = _.map(dt.rows, function (ambito) {
								return ambito.idambitoareadisc;
							});
							var filtroAmbito = window.jsDataQuery.isIn("idambitoareadisc", ambiti);
							appMeta.metaModel.cachedTable(self.getDataTable("ambitoareadiscdefaultview"), false);
							var affidamentocaratteristica_default_idambitoareadiscCtrl = $('#affidamentocaratteristica_default_idambitoareadisc').data("customController");
							return affidamentocaratteristica_default_idambitoareadiscCtrl.filteredPreFillCombo(filtroAmbito, null, true);
						});
					arraydef.push(def);

				}
				//afterRowSelectAsincIn
				return $.when.apply($, arraydef);
			},

			afterActivation: function () {
				var parentRow = this.state.currentRow;
				var self = this;
				//afterActivationin
				var arraydef = [];
				if (parentRow.idtipoattform) {
					appMeta.metaModel.cachedTable(this.getDataTable("ambitoareadiscdefaultview"), false);
					var affidamentocaratteristica_default_idambitoareadiscCtrl = $('#affidamentocaratteristica_default_idambitoareadisc').data("customController");
					arraydef.push(affidamentocaratteristica_default_idambitoareadiscCtrl.filteredPreFillCombo(window.jsDataQuery.eq("ambitoareadisc_idtipoattform", parentRow.idtipoattform), null, true));
				}
				//afterActivationAsincIn
				return $.when.apply($, arraydef);
			},

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			manageaffidamentocaratteristica_default_title: function () {
				var def = appMeta.Deferred("beforeFill-manageaffidamento_title");
				var self = this;
				var currtipoattform = _.find(this.state.DS.tables.tipoattformdefaultview.rows, function (row) {
					return row.idtipoattform === self.state.currentRow.idtipoattform;
				});
				var currambitoareadisc = _.find(this.state.DS.tables.ambitoareadiscdefaultview.rows, function (row) {
					return row.idambitoareadisc === self.state.currentRow.idambitoareadisc;
				});
				var currsasd = _.find(this.state.DS.tables.sasddefaultview.rows, function (row) {
					return row.idsasd === self.state.currentRow.idsasd;
				});

				var output = _.join(
					_.map(this.state.DS.tables.affidamentocaratteristicaora.rows, function (row) {
						if (row.idaffidamentocaratteristica === self.state.currentRow.idaffidamentocaratteristica)
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

	window.appMeta.addMetaPage('affidamentocaratteristica', 'default', metaPage_affidamentocaratteristica);

}());

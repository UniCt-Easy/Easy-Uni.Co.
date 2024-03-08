(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_affidamentocaratteristica() {
		MetaPage.apply(this, ['affidamentocaratteristica', 'seg', true]);
        this.name = 'Caratteristiche dell\'affidamento';
		this.defaultListType = 'seg';
		this.canInsert = false;
		this.canInsertCopy = false;
		this.canCancel = false;
		this.canShowLast = false;
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
				var def = appMeta.Deferred("afterGetFormData-affidamentocaratteristica_seg");
				var arraydef = [];
				
				arraydef.push(this.manageaffidamentocaratteristica_seg_title());
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
				var def = appMeta.Deferred("beforeFill-affidamentocaratteristica_seg");
				var arraydef = [];
				
				arraydef.push(this.manageaffidamentocaratteristica_seg_title());
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

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-affidamentocaratteristica_seg");
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
					arraydef.push(def);				}
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			manageaffidamentocaratteristica_seg_title: function () {
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

	window.appMeta.addMetaPage('affidamentocaratteristica', 'seg', metaPage_affidamentocaratteristica);

}());

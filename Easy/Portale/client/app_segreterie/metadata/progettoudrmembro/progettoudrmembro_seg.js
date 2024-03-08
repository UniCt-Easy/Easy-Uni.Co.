(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_progettoudrmembro() {
		MetaPage.apply(this, ['progettoudrmembro', 'seg', true]);
        this.name = 'Membri';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_progettoudrmembro.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_progettoudrmembro,
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
				var def = appMeta.Deferred("afterGetFormData-progettoudrmembro_seg");
				var arraydef = [];
				
				arraydef.push(this.manageprogettoudrmembro_seg_orerendicontate());
				arraydef.push(this.manageprogettoudrmembro_seg_giornipreventivati());
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
				
				this.manageprogettoudrmembro_seg_giornipreventivati();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-progettoudrmembro_seg");
				var arraydef = [];
				
				arraydef.push(this.manageprogettoudrmembro_seg_orerendicontate());
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

			afterClear: function () {
				//parte sincrona
				this.enableControl($('#progettoudrmembro_seg_orerendicontate'), true);
				this.enableControl($('#progettoudrmembro_seg_giornipreventivati'), true);
				//afterClearin
				
				//afterClearInAsyncBase
			},

			afterFill: function () {
				this.enableControl($('#progettoudrmembro_seg_orerendicontate'), false);
				this.enableControl($('#progettoudrmembro_seg_giornipreventivati'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				this.setDenyNull("progettoudrmembro","idreg");
				appMeta.metaModel.insertFilter(this.getDataTable("progettoudrmembrokinddefaultview"), this.q.eq('progettoudrmembrokind_active', 'Si'));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-progettoudrmembro_seg");
				if (t.name === "getregistrydocentiamministrativi" && r !== null) {
					this.state.DS.tables.getregistrydocentiamministrativimacroareaview.staticFilter(window.jsDataQuery.eq("idreg", r.idreg));
					if (this.state.DS.tables.getregistrydocentiamministrativimacroareaview.rows.length)
						if (this.state.DS.tables.getregistrydocentiamministrativimacroareaview.rows[0].idreg !== r.idreg) {
							this.state.DS.tables.getregistrydocentiamministrativimacroareaview.clear();
							$('#progettoudrmembro_seg_idreg').val('');
						}
				}
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			beforePost: function () {
				var self = this;
				this.getDataTable('rendicontattivitaprogettourdmemboview').acceptChanges();
				//innerBeforePost
			},

			manageprogettoudrmembro_seg_orerendicontate: function () {
				if (this.getDataTable("rendicontattivitaprogettourdmemboview").rows.length) {
					this.state.currentRow['!orerendicontate'] = _.sumBy(this.getDataTable("rendicontattivitaprogettourdmemboview").rows, function (r) {
						if (r.oreattivita) return r.ore;
						return 0;
					});
				}
					
			//	var def = appMeta.Deferred("manageorerendicontate-progettoudrmembro_seg");
			//	var projectPage = appMeta.currApp.currentMetaPage.state.callerPage;
			//	var membroRow = appMeta.currApp.currentMetaPage.state.currentRow;
			//	var q = appMeta.currApp.currentMetaPage.q;
			//	if (membroRow.idreg) {
			//		var rendicontattivitaprogettoRows = projectPage.getDataTable("rendicontattivitaprogetto")
			//			.select(q.eq("idreg", membroRow.idreg));
			//		if (rendicontattivitaprogettoRows.length > 0) {
			//			var rendicontattivitaprogettooraRows = projectPage.getDataTable("rendicontattivitaprogettoora")
			//				.select(q.isIn("idrendicontattivitaprogetto", _.map(
			//					rendicontattivitaprogettoRows, function (row) {
			//						return row.idrendicontattivitaprogetto;
			//					})));
			//			if (rendicontattivitaprogettooraRows.length > 0) {
			//				membroRow['!orerendicontate'] = _.sumBy(rendicontattivitaprogettooraRows, function (r) {
			//					if (r.ore) return r.ore;
			//					return 0;
			//				});
			//			}
			//		}
			//	}
			//	return def.resolve();
			},

			manageprogettoudrmembro_seg_giornipreventivati: function () {
				//calcolato in base alla divisione di 8 ore al giorno per i docenti e 7,2 per il personale tecnico-amministrativo
				if (this.state.currentRow.orepreventivate) {
					var tb = this.getDataTable('getregistrydocentiamministrativimacroareaview');
					if (tb.rows.length) {
						var oregg = tb.rows[0].getregistrydocentiamministrativi_categoria == 'D' ? 8 : 7.2;
						this.state.currentRow.giornipreventivati = (this.state.currentRow.orepreventivate / oregg)
					}
				}
			},

			//buttons
        });

	window.appMeta.addMetaPage('progettoudrmembro', 'seg', metaPage_progettoudrmembro);

}());

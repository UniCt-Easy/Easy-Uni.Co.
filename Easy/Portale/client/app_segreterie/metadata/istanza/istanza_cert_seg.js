(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_istanza() {
		MetaPage.apply(this, ['istanza', 'cert_seg', false]);
        this.name = 'Richiesta di certificato';
		this.defaultListType = 'cert_seg';
		this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		//pageHeaderDeclaration
    }

    metaPage_istanza.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_istanza,
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
				
				var gridParentRelsistanzaattach25 = self.state.DS.getParentChildRelation("istanza", "istanzaattach");
				var fatherfilteristanzaattach25 = gridParentRelsistanzaattach25[0].getChildFilter(parentRow);
				var filterGrididistanzakind25 = window.jsDataQuery.eq("idistanzakind", 9);
				var istanzaattach = this.getDataTable("istanzaattach");
				istanzaattach.rows =  _.filter(istanzaattach.rows, function(r) {return filterGrididistanzakind25(r)});
				var filteridistanzakind25 = window.jsDataQuery.and(fatherfilteristanzaattach25, filterGrididistanzakind25);
				$("#grid_istanzaattach_seg").data("customParentRelation", filteridistanzakind25);
				if (self.isNullOrMinDate(parentRow.data))
					parentRow.data = new Date();
				if (!parentRow.extension)
					parentRow.extension = "cert";
				if (!parentRow.idistanzakind)
					parentRow.idistanzakind = 9;
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-istanza_cert_cert_seg");
				var arraydef = [];
				
				var dt = this.state.DS.tables["istanza_cert"];
				if (dt.rows.length === 0) {
					var meta = appMeta.getMeta("istanza_cert");
					meta.setDefaults(dt);
					var defistanza_cert = meta.getNewRow(parentRow.getRow(), dt, self.editType).then(
						function (currentRowcert) {
							currentRowcert.current.idistanzakind = 9;
							//defaultExtendingObject
							return true;
						}
					);
					arraydef.push(defistanza_cert);
				}

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
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanza_cert'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanzaattach'));
				//afterClearin
			},

			afterFill: function () {
				this.enableControl($('#istanza_cert_seg_protnumero'), false);
				this.enableControl($('#istanza_cert_seg_protanno'), false);
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanza_cert'));
				appMeta.metaModel.addNotEntityChild(this.getDataTable('istanza'), this.getDataTable('istanzaattach'));
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			afterLink: function () {
				var self = this;
				$("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
				$("#btnProtocol").prop("disabled", true);
				this.state.DS.tables.statuskind.staticFilter(window.jsDataQuery.eq('istanze', 'S'));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-istanza_cert_cert_seg");
				$('#istanza_cert_seg_idreg_studenti').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#istanza_cert_seg_idreg_studenti').prop("readonly", this.state.isEditState() || this.haveChildren());
				if (t.name === 'registrystudentiview' && r !== null)
					if (this.state.DS.tables['istanza_cert'].rows.length)
						this.state.DS.tables['istanza_cert'].rows[0].idreg = r.idreg;
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			rowSelected: function (dataRow) {
				$("#btnProtocol").prop("disabled", false);
				//firerowSelected
			},


			buttonClickEnd: function (currMetaPage, cmd) {
				//fireRelButtonClickEnd
				cmd = cmd.toLowerCase();
				if (cmd === "mainsetsearch") {
					$("#btnProtocol").prop("disabled", true);
					//firebuttonClickEnd
				}
				return this.superClass.buttonClickEnd(currMetaPage, cmd);
			},


			insertClick: function (that, grid) {
				if (!$('#istanza_cert_seg_idreg_studenti').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Studente');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			firebtnProtocol: function (that) {
				var idreg_origine = that.state.currentRow.idreg_studenti;
				var idreg_destinazione = that.idreg_istituto;
				var statuskind = that.getDataTable('statuskind');
				var rowsStatusKind = statuskind.select(that.q.eq('idstatuskind', that.state.currentRow.idstatuskind));
				var oggetto = 'Istanza del ' + that.stringFromDate_ddmmyyyy(that.state.currentRow.data) + (rowsStatusKind.length ? ' ' + rowsStatusKind[0].title : '');
				var idprotocollodockind = 2;
				var arrayTablesToProtocol = ['istanza', 'istanza_cert'];
				var codiceregistro = that.state.currentRow.getRow().table.name + that.state.currentRow.idistanza;

				return that.assegnaProtocollo(idreg_origine, idreg_destinazione, idprotocollodockind, oggetto, codiceregistro, arrayTablesToProtocol);
			},

			children: ['istanzaattach'],
			haveChildren: function () {
				var self = this;
				return _.some(this.children, function (child) {
					if (child !== '')
						return !!self.getDataTable(child).rows.length;
					else
						return false;
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('istanza', 'cert_seg', metaPage_istanza);

}());

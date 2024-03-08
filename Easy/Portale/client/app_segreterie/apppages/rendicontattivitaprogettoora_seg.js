(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_rendicontattivitaprogettoora() {
		MetaPage.apply(this, ['rendicontattivitaprogettoora', 'seg', true]);
        this.name = 'Dettaglio giorni della attività';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_rendicontattivitaprogettoora.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_rendicontattivitaprogettoora,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			manageValidResult: function (rowToCheck) {
				var loc = appMeta.localResource;
				var def = appMeta.Deferred("isValid-rendicontattivitaprogettoora_seg");
				var firstErrorObj;

				var progettoStop = null;
				var progettoStart = null;
				var workpackageStop = null;
				var workpackageStart = null;
				var activityStop = null;
				var activityStart = null;
				var lastProroga = null;

				if (!rowToCheck.current.ore) {
					firstErrorObj = {
						warningMsg: "",
						errMsg: 'Occorre indicare il numero di ore. Compilare il campo ',
						outCaption: 'Ore',
						errField: 'ore',
						row: rowToCheck
					};
					return def.resolve(firstErrorObj);
				}

				if (rowToCheck.current.ore > 24) {
					firstErrorObj = {
						warningMsg: "",
						errMsg: 'Occorre diminuire il numero di ore. Indicare un valore al massimo di 24 ore ',
						outCaption: 'Ore',
						errField: 'ore',
						row: rowToCheck
					};
					return def.resolve(firstErrorObj);
				}


				if (this.state.callerState.callerState && this.state.callerState.callerState.callerState) {
					//pronipote del'interfaccia progetto
					progettoStop = this.state.callerState.callerState.callerState.currentRow.stop;
					progettoStart = this.state.callerState.callerState.callerState.currentRow.start;
					lastProroga = this.state.callerState.callerState.callerState.DS.tables.progettoproroga.rows.length ?
						_.orderBy(this.state.callerState.callerState.callerState.DS.tables.progettoproroga.rows, 'proroga', 'desc')[0] : null;
					this.Membro = this.state.callerState.callerState.callerState.DS.tables.progettoudrmembro.rows.length ?
						_.orderBy(this.state.callerState.callerState.callerState.DS.tables.progettoudrmembro
							.select(this.q.and(this.q.eq("idprogetto", this.state.callerState.currentRow.idprogetto), this.q.eq("idreg", this.state.callerState.currentRow.idreg))
							), 'stop', 'desc')[0] : null;
					workpackageStop = this.state.callerState.callerState.currentRow.stop;
					workpackageStart = this.state.callerState.callerState.currentRow.start;
					activityStop = this.state.callerState.currentRow.stop;
					activityStart = this.state.callerState.currentRow.datainizioprevista;
				}
				else {
					//figlia di pagine delle attività e nessun altro antenato da cui prendere i dati
					progettoStop = this.state.callerState.DS.tables.progettosegview ?
						this.state.callerState.DS.tables.progettosegview.select(this.q.eq('idprogetto', rowToCheck.current.idprogetto))[0].progetto_stop
						: this.state.callerState.DS.tables.progettoelenchiview.select(this.q.eq('idprogetto', rowToCheck.current.idprogetto))[0].progetto_stop;
					progettoStart = this.state.callerState.DS.tables.progettosegview ?
						this.state.callerState.DS.tables.progettosegview.select(this.q.eq('idprogetto', rowToCheck.current.idprogetto))[0].progetto_start
						: this.state.callerState.DS.tables.progettoelenchiview.select(this.q.eq('idprogetto', rowToCheck.current.idprogetto))[0].progetto_start;
					lastProroga = this.lastProroga;
					workpackageStop = this.state.callerState.DS.tables.workpackageelenchiview.select(this.q.eq('idworkpackage', rowToCheck.current.idworkpackage))[0].workpackage_stop;
					workpackageStart = this.state.callerState.DS.tables.workpackageelenchiview.select(this.q.eq('idworkpackage', rowToCheck.current.idworkpackage))[0].workpackage_start;
					activityStop = this.state.callerState.currentRow.stop;
					activityStart = this.state.callerState.currentRow.datainizioprevista;

				}

				//durata del membro
				if (this.Membro) {
					if (rowToCheck.current.data > (lastProroga ? lastProroga.proroga : this.Membro.stop)) {
						firstErrorObj = {
							warningMsg: "",
							errMsg: 'La data impostata è successiva ' + (lastProroga ?
								'alla proroga del ' + this.stringFromDate_ddmmyyyy(lastProroga.proroga)
								: 'al termine dell\'appartenenza all\'unità di ricerca che è ' + this.stringFromDate_ddmmyyyy(this.Membro.stop)
							) + ". Correggere il campo",
							outCaption: 'Data',
							errField: 'data',
							row: rowToCheck
						};
						return def.resolve(firstErrorObj);
					}
					if (rowToCheck.current.data < this.Membro.start) {
						firstErrorObj = {
							warningMsg: "",
							errMsg: 'La data impostata è precedente all\'inizio dell\'appartenenza all\'unità di ricerca che è ' + this.stringFromDate_ddmmyyyy(this.Membro.start) + ". Correggere il campo",
							outCaption: 'Data',
							errField: 'data',
							row: rowToCheck
						};
						return def.resolve(firstErrorObj);
					}
				}

				//attività
				if (rowToCheck.current.data > (lastProroga ? lastProroga.proroga : activityStop)) {
					firstErrorObj = {
						warningMsg: "",
						errMsg: 'La data impostata è successiva ' + (lastProroga ?
							'alla proroga del ' + this.stringFromDate_ddmmyyyy(lastProroga.proroga)
							: 'al termine della attività che è ' + this.stringFromDate_ddmmyyyy(activityStop)
						) + ". Correggere il campo",
						outCaption: 'Data',
						errField: 'data',
						row: rowToCheck
					};
					return def.resolve(firstErrorObj);
				}
				if (rowToCheck.current.data < activityStart) {
					firstErrorObj = {
						warningMsg: "",
						errMsg: 'La data impostata è precedente all\'inizio della attività che è ' + this.stringFromDate_ddmmyyyy(activityStart) + ". Correggere il campo",
						outCaption: 'Data',
						errField: 'data',
						row: rowToCheck
					};
					return def.resolve(firstErrorObj);
				}

				//workpackage
				if (rowToCheck.current.data > (lastProroga ? lastProroga.proroga : workpackageStop)) {
					firstErrorObj = {
						warningMsg: "",
						errMsg: 'La data impostata è successiva ' + (lastProroga ?
							'alla proroga del ' + this.stringFromDate_ddmmyyyy(lastProroga.proroga)
							: 'al termine del workpackage che è ' + this.stringFromDate_ddmmyyyy(workpackageStop)
						) + ". Correggere il campo",
						outCaption: 'Data',
						errField: 'data',
						row: rowToCheck
					};
					return def.resolve(firstErrorObj);
				}
				if (rowToCheck.current.data < workpackageStart) {
					firstErrorObj = {
						warningMsg: "",
						errMsg: 'La data impostata è precedente all\'inizio del workpackage che è ' + this.stringFromDate_ddmmyyyy(workpackageStart) + ". Correggere il campo",
						outCaption: 'Data',
						errField: 'data',
						row: rowToCheck
					};
					return def.resolve(firstErrorObj);
				}

				//progetto
				if (rowToCheck.current.data > (lastProroga ? lastProroga.proroga : progettoStop)) {
					firstErrorObj = {
						warningMsg: "",
						errMsg: 'La data impostata è successiva ' + (lastProroga ?
							'alla proroga del ' + this.stringFromDate_ddmmyyyy(lastProroga.proroga)
							: 'al termine del progetto che è ' + this.stringFromDate_ddmmyyyy(progettoStop)
						) + ". Correggere il campo",
						outCaption: 'Data',
						errField: 'data',
						row: rowToCheck
					};
					return def.resolve(firstErrorObj);
				}
				if (rowToCheck.current.data < progettoStart) {
					firstErrorObj = {
						warningMsg: "",
						errMsg: 'La data impostata è precedente all\'inizio del progetto che è ' + this.stringFromDate_ddmmyyyy(progettoStart) + ". Correggere il campo",
						outCaption: 'Data',
						errField: 'data',
						row: rowToCheck
					};
					return def.resolve(firstErrorObj);
				}

				//WARNINGS (dopo gli errori perchè interrompono il flusso delle verifiche)

				let oreRendicontate = _.sumBy(this.state.callerState.DS.tables.rendicontattivitaprogettoora.rows, function (r) {
					return r.ore;
				});
				if (this.isNullOrNotANumber(oreRendicontate)) oreRendicontate = 0;

				let orePreventivate = this.state.callerState.currentRow.orepreventivate;
				if (this.isNullOrNotANumber(orePreventivate)) orePreventivate = 0;

				if (rowToCheck.current.ore + oreRendicontate > orePreventivate) {

					let wmess = 'Il numero di ore indicato sommato alle ore già rendicontate supera il numero di ore preventivato. Siete sicuri di voler indicare un valore superiore a ' + (orePreventivate - oreRendicontate) + ' ore? ';
					if ((orePreventivate - oreRendicontate) == 0)
						wmess = 'Il numero di ore preventivato è già stato raggiunto con le ore già rendicontate. Siete sicuri di voler aggiungere ulteriori ' + rowToCheck.current.ore + ' ore? ';
					if ((orePreventivate - oreRendicontate) < 0)
						wmess = 'Il numero di ore preventivato è già stato superato con le ore già rendicontate di ' + Math.abs(orePreventivate - oreRendicontate) + ' ore. Siete sicuri di voler aggiungere ulteriori ' + rowToCheck.current.ore + ' ore? ';

					firstErrorObj = {
						warningMsg: wmess,
						errMsg: '',
						outCaption: 'Ore',
						errField: 'ore',
						row: rowToCheck
					};
					return def.resolve(firstErrorObj);
				}

				def.resolve();

				//$isValid$
				
				return  MetaPage.prototype.manageValidResult.call(this, rowToCheck);
			},

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-rendicontattivitaprogettoora_seg");
				var arraydef = [];
				
				arraydef.push(this.managerendicontattivitaprogettoora_seg_titleancestor());
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
				
				this.managerendicontattivitaprogettoora_seg_titleancestor();
				//beforeFillFilter
				
				//parte asincrona
				var def = appMeta.Deferred("beforeFill-rendicontattivitaprogettoora_seg");
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

			//afterFill

			afterLink: function () {
				var self = this;
				this.state.DS.tables.saldefaultview.staticFilter(window.jsDataQuery.eq("idprogetto", this.state.callerState.currentRow.idprogetto));
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					arraydef.push(self.getProroghe());
					arraydef.push(self.getMembro());
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			createAndGetListManager: function (searchTableName, listingType, prefilter, isModal, rootElement, that, filterLocked, toMerge, isCommandSearch) {
                // isCommandSearch è true se lancio comando di ricerca, false se vengo da un autochoose, e qin quel caso implemnto comportamento di default
                var startColumnName = "data";
                var titleColumnName = "!titleancestor";
                var stopColumnName = null;
                if (isCommandSearch) return new window.appMeta.ListManagerCalendar(searchTableName, listingType, prefilter, isModal, rootElement, that, filterLocked, toMerge, startColumnName , titleColumnName, stopColumnName);
                // se non esco prima, significa autochoose e quindi esegue il sodiuce della superClass
                return this.superClass.createAndGetListManager(searchTableName, listingType, prefilter, isModal,rootElement, that, filterLocked, toMerge, isCommandSearch);
            },

			getProroghe: function () {
				//se mancano le pagine antenate che contengono le proroghe devo recuperarle da db
				var self = this;
				var def = appMeta.Deferred("getProroghe-rendicontattivitaprogettoora_seg");
				if (this.state.callerState.callerState && this.state.callerState.callerState.callerState) {
					return def.resolve();
				} else {
					appMeta.getData.runSelect("progettoproroga", "proroga", this.q.eq("idprogetto", this.state.callerState.currentRow.idprogetto))
						.then(function (dt) {
							self.lastProroga = dt.rows.length ?
								_.orderBy(dt.rows, 'proroga', 'desc')[0] : null;
							return def.resolve();
						});
					return def.promise();
				}
			},

			getMembro: function () {
				//se mancano le pagine antenate che contengono i membri devo recuperarle da db 
				var self = this;
				var def = appMeta.Deferred("getMembro-rendicontattivitaprogettoora_seg");
				if (this.state.callerState.callerState && this.state.callerState.callerState.callerState) {
					return def.resolve();
				} else {
					appMeta.getData.runSelect("progettoudrmembro", "start,stop",
						self.q.and(self.q.eq("idprogetto", self.state.callerState.currentRow.idprogetto), self.q.eq("idreg", self.state.callerState.currentRow.idreg)))
						.then(function (dtMembro) {
							self.Membro = dtMembro.rows.length ?
								_.orderBy(dtMembro.rows, 'stop', 'desc')[0] : null;
							return def.resolve();
						});
					return def.promise();
				} 
			},

			managerendicontattivitaprogettoora_seg_titleancestor: function () {
				var self = this;
				var p = [];

				var progettoTitle = '';
				var workpageTitle = '';
				if (this.state.callerState.callerState && this.state.callerState.callerState.callerState) {
					progettoTitle = this.state.callerState.callerState.callerState.currentRow.titolobreve;
					workpageTitle = this.state.callerState.callerState.currentRow.title;
				}
				else {
					progettoTitle = this.state.callerState.DS.tables.progettosegview ?
						this.state.callerState.DS.tables.progettosegview.rows[0].titolobreve
						: this.state.callerState.DS.tables.progettoelenchiview.rows[0].titolobreve;
					workpageTitle = this.state.callerState.DS.tables.workpackageelenchiview.rows[0].dropdown_title;
				}

				var rendicontattivitaprogettoTitle = this.state.callerState.currentRow.description;
				p.push([progettoTitle, null, 'Progetto']);
				p.push([workpageTitle, null, 'Workpackage']);
				p.push([rendicontattivitaprogettoTitle, null, 'Attività']);
				self.state.currentRow["!titleancestor"] = self.stringify(p, 'string');
				return true;
			},

			//buttons
        });

	window.appMeta.addMetaPage('rendicontattivitaprogettoora', 'seg', metaPage_rendicontattivitaprogettoora);

}());

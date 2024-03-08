(function () {

	// Deriva da MetaEasyPage
	let MetaEasyPage = window.appMeta.MetaEasyPage;
	let Deferred = appMeta.Deferred;
	let metaModel = appMeta.metaModel;
	let getData = appMeta.getData;
	var postData = appMeta.postData;
	var localResource = appMeta.localization;
	var utils = appMeta.utils;
	var getDataUtils = appMeta.getDataUtils;
	var security = appMeta.security;
	var dataRowState = jsDataSet.dataRowState;

	function MetaSegreteriePage() {
		MetaEasyPage.apply(this, arguments);
		this.eventManager.subscribe(appMeta.EventEnum.listCreated, this.listCreated, this);
		this.eventManager.subscribe(appMeta.EventEnum.saveDataStop, this.saveDataStop, this);
		appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
		this.localResource = appMeta.localization;
		this.idreg_istituto = appMeta.security.usr("idreg_istituto");
		this.manageButtonsPrivileges();
	}

	MetaSegreteriePage.prototype = _.extend(
		new MetaEasyPage(),
		{
			constructor: MetaSegreteriePage,
			superClass: MetaEasyPage.prototype,

			/**
			 * gestisce in base ai privilegi letti dalle usr_env l'abilitazione o meno dei bottoni per il salvataggio
			 */
			manageButtonsPrivileges: function () {
				var self = this;
				// 1. trova menuwebid dati editType e tableName
				var dtMenuWeb = appMeta.security.dtMenuWeb;
				if (dtMenuWeb) {
					var found = _.find(dtMenuWeb.rows, function (row) {
						return row.editType === self.editType && row.tableName === self.primaryTableName;
					});
					// 2. controlla le var di ambiente dell'user
					if (found) {
						var idmenuweb = found.idmenuweb;
						var menukeyW = "mw_" + idmenuweb;
						var privilegeW = security.usr(menukeyW);
						if ((privilegeW && privilegeW === "'S'")) {
							self.setButtonEnabled(true);
							// in tutti gli altri casi metterà false
							return;
						}
					}
				}

				// se non trovo privilegio li inviisbilizzo
				self.setButtonEnabled(false);
			},

			setButtonEnabled: function (enabled) {
				this.canInsert = enabled;
				this.canInsertCopy = enabled;
				if (!this.detailPage) {
					this.canSave = enabled; // metapaqge di dettaglio "ok", cioè tasto salva è presente per tornare indietro
					this.canCancel = enabled;
				}
			},

			/**
			 * "this" è la metaPage derivata da questa classe, per cui mi passa lo stato
				* @returns {boolean}
				**/
			beforeFill: function () {

				// lo metto in self perchè su lodash il "this" cambia
				var self = this;

				var pt = this.getDataTable(this.primaryTableName);
				var rels = pt.childRelations();
				// algoritmo per richiamare la getTemporaryValues su tabelle nipoti, che sono figlie di un fratello 1:1
				// oppure di un oggetto estendente
				// quindi tutte le griglie che non sono child dirette della tabella principale
				_.forEach($("[data-custom-control=gridx],[data-custom-control=checklist]"), function (grid) {
					// recupero info di che tabella si tratti dal tag
					var eltag = $(grid).data("tag");
					var tcurrName = self.helpForm.getTableName(eltag);
					var tCurr = self.getDataTable(tcurrName);

					var bool = _.some(rels, function (rel) {
						return rel.childTable === tcurrName;
					});

					if (!bool) appMeta.metaModel.getTemporaryValues(tCurr);
				});

				// se esiste beforeFill sulla classe base MetaEasyPage lo invoco
				return MetaEasyPage.prototype.beforeFill.call(self);
			},

			afterLink: function () {
				var self = this;
				var pt = this.getDataTable(this.primaryTableName);
				_.forEach(pt.key(), function (key) {
					metaModel.allowZero(pt.columns[key], false);
				});
				// calcolo giorni sospensioni
				return this.getSospensioni()
					.then(function () {
						return MetaEasyPage.prototype.afterLink.call(self);
					});
			},



			afterFill: function () {
				// PARTE SYNC
				// calcola la giusta height delle grid, serve 
				// per far apparire la scrollbar orizzontale visibile e non in fondo
				$('[data-custom-control = "gridx"]').each(function () {
					// recupero il controllere delg rid specifico
					var screenH = $(window).height();
					var offset = 200;
					var offsetDetail = 230;
					var h = (screenH - offset).toString() + 'px';
					var htab = (screenH - offset + 20).toString() + 'px';
					var hdetail = (screenH - offsetDetail).toString() + 'px';
					var htabdetail = (screenH - offsetDetail + 20).toString() + 'px';
					$(".tab-content").css("min-height", htab);
					$(this).css("max-height", h);
					$(".detailPage .tab-content").css("min-height", htabdetail);
					$(".detailPage").find(this).css("max-height", hdetail);
				});

				$('[data-custom-control = "checklist"]').each(function () {
					var screenH = $(window).height();
					var offset = 200;
					var offsetDetail = 230;
					var h = (screenH - offset).toString() + 'px';
					var htab = (screenH - offset + 8).toString() + 'px';
					var hdetail = (screenH - offsetDetail).toString() + 'px';
					var htabdetail = (screenH - offsetDetail + 8).toString() + 'px';
					$(".tab-content").css("min-height", htab);
					$(this).find(".table").css("max-height", h);
					$(".detailPage .tab-content").css("min-height", htabdetail);
					$(".detailPage").find(this).css("max-height", hdetail);
				});

				// appare una scroll veticale se il tree viene espanso oltre la finestra.
				// utile nel master - detail duante navigazione tree
				$('[data-custom-control = "tree"]').each(function () {
					var screenH = $(window).height();
					var offset = 150;
					var htab = (screenH - offset).toString() + 'px';
					$(this).css("max-height", htab);
					$(this).css("overflow-y", "auto");
					$(this).css("overflow-x", "hidden");
				});

				// ASYNC
				// se esiste beforeFill sulla classe base MetaEasyPage lo invoco
				return MetaEasyPage.prototype.afterFill.call(this);
			},

			/**
			  * @method cmdMainSave
			  * @private
			  * @description
			  * @returns Deferred<boolean> the deferred
			  */
			cmdMainSave: function () {
				//chiudo l'elenco di ricerca al salvataggio
				this.closeListManagerResultsSearch();
				return MetaEasyPage.prototype.cmdMainSave.call(this);
			},

			/**
			 * @method cmdMainDelete
			 * @private
			 * @description ASYNC
			 * Manages a main delete command
			 * @returns {Deferred}
			 */
			cmdMainDelete: function () {
				//chiudo l'elenco dei risultati alla cancellazione
				this.closeListManagerResultsSearch();
				return MetaEasyPage.prototype.cmdMainDelete.call(this);
			},

			/**
			 * sposto i grid per centrarli
			 */
			moveGridControlCenter: function () {
				$('[data-custom-control = "gridx"]').each(function () {
					// recupero il controllere delg rid specifico
					var gridControl = $(this).data("customController");
					var screenW = $(window).width();
					var pageContainerW = parseInt($(".container").css("width").replace("px", ""));
					var gridW = parseInt(gridControl.mytable.css("width").replace("px", ""));
					var left, newleft;

					if (gridW < pageContainerW) {
						// se il grid ha size minore del contaner non faccio nulla
					} else if (gridW > pageContainerW && gridW < screenW) {
						left = (gridW - pageContainerW) / 2;
						newleft = (-left).toString() + "px";
						$(gridControl.mytable).css("left", newleft);
					} else if (gridW > screenW) {
						left = (screenW - pageContainerW - 5) / 2;
						newleft = (-left).toString() + "px";
						$(gridControl.mytable).css("left", newleft);
					}
				});
			},

			/**
			* Set denyNull to true for the column columnName of table tableName
			* @param {string} tableName
			* @param {string} columnName
			*/
			setDenyNull: function (tableName, columnName) {
				var c = this.getDataTable(tableName).columns[columnName];
				if (metaModel.isColumnNumeric(c)) {
					metaModel.denyZero(c, true);
				} else {
					metaModel.denyNull(c, true);
				}
			},

			/**
			 * @method getName
			 * @private
			 * @description SYNC
			 * To override. sets the name of the page
			 */
			getName: function () {
				return "SegreteriaPage " + ((this.name !== undefined) ? this.name : "");
			},

			/**
			 * @method editNewCopy
			 * @private
			 * @description ASYNC
			 * Funzione per la copia dei dati effettuata tramite getNewRow lato frontend.
			 * @returns {Deferred}
			 */
			editNewCopy: function () {
				return this.editNewCopyJsSide();
			},

			/**
			 *
			 * @param {ListManager} listManager
			 */
			listCreated: function (listManager) {
				// this.adjustPositionListManager(listManager);
			},


			/**
			 * @method adjustSizeNotModal
			 * @private
			 * @description SYNC.
			 * Adjusts the size and the position of the "elenco" based on its content (based on the grid)
			 * 1. grid < page container sets the w maximum
			 * 2. gridw > page containe < widow size the move to left to center the grid
			 * 3. if grid w > winwdow size then move to left and set the width. a scrollbar appear on the page
			 * @param {ListManager} listManager
			 */
			adjustPositionListManager: function (listManager) {
				if ($(".container").length && !listManager.isModal) {
					var screenW = $(window).width();
					var pageContainerW = parseInt($(".container").css("width").replace("px", ""));
					var gridW = parseInt(listManager.gridControl.mytable.css("width").replace("px", ""));
					var w, left, newleft;

					if (gridW < pageContainerW) {
						w = gridW + 20;
						listManager.currentRootElement.css("width", w + "px");
					} else if (gridW > pageContainerW && gridW < screenW) {
						w = gridW + 20;
						left = (gridW - pageContainerW) / 2;
						newleft = (-left).toString() + "px";
						listManager.currentRootElement.css("width", w + "px");
						listManager.currentRootElement.css("left", newleft);
						$(".container").css("width", w + "px");
					} else if (gridW > screenW) {
						w = gridW + 20;
						left = (screenW - pageContainerW - 5) / 2;
						newleft = (-left).toString() + "px";
						listManager.currentRootElement.css("width", w + "px");
						listManager.currentRootElement.css("left", newleft);
						$(".container").css("width", w + "px");
					}
				}

				// ottimizzo altezza dell'elenco. max 50%
				var screenH = $(window).height();
				// offset dovuto ai controlli ulteriori del num record e grouping
				var offset = 100;
				var gridH = parseInt(listManager.gridControl.mytable.css("height").replace("px", "")) + offset;
				if (gridH < screenH / 2) {
					listManager.currentRootElement.css("height", gridH + "px");
				}
			},


			/***
			 *
			 * @param that
			 * @param tag
			 */
			buttonClickEnd: function (that, tag) {
				// osserva i campi mandatory dopo il save.
				if (tag === 'mainsave') this.mandatoryUiFields(that);
			},

			/**
			 * @method mandatoryUiFields
			 * @public
			 * @description SYNC
			 * If user set data-mandatory it puts a specific css to the control that has null value
			 * For now it puts a red outline
			 */
			mandatoryUiFields: function (that) {
				var defaultcolor = "1px solid #ccc !important";
				var errcolor = "1px solid red !important";
				var self = that;
				// torna true se NON c'è il valore mandatory
				var checkMandatoryValue = function (val, dc) {
					if ((val === null) || (val === undefined)) return true;
					if ((dc.ctype === "String") && (val.replace(/\s*$/, "") === "")) return true;
					if (!metaModel.allowZero(dc) && metaModel.isColumnNumeric(dc) && metaModel.denyZero(dc) && val === 0) return true;
					return false;
				};

				// funzione che setta il corretto css
				var setCssFunc = function (el, tname, cname, cssproperty) {
					var rows = self.state.DS.tables[tname].rows;
					var dc = self.state.DS.tables[tname].columns[cname];
					var objrow = rows[0];
					if (objrow && checkMandatoryValue(objrow[cname], dc)) {
						$(el).attr('style', cssproperty + ':' + errcolor);
					} else if (!objrow) {
						$(el).attr('style', cssproperty + ':' + errcolor);
					} else {
						$(el).attr('style', cssproperty + ':' + defaultcolor);
					}
				};

				// funzione che setta il corretto css
				var setCssFuncSelect2 = function (el, tname, cname) {
					var rows = self.state.DS.tables[tname].rows;
					var objrow = rows[0];
					var dc = self.state.DS.tables[tname].columns[cname];
					if (objrow && checkMandatoryValue(objrow[cname], dc)) {
						$(el).data('select2').$container.addClass("select2-error");
					} else {
						$(el).data('select2').$container.removeClass("select2-error");
					}
				};

				$(this.rootElement + "  [data-mandatory]")
					.each(function () {
						var tag = self.helpForm.getStandardTag($(this).data("tag"));
						var tname = self.helpForm.getTableName(tag);
						var cname = self.helpForm.getColumnName(tag);

						// controllo input di autochoose per recuperare il giusto valore nullo
						if ($(this).closest("div").attr('class') === "autoChoose" &&
							$(this).next("input").attr('id') &&
							$(this).next("input").attr('id').startsWith("Invisible")) {

							// recupero quello dell'input nascosta, dove ci sono tabella e colonna vera
							var tagac = $(this).next("input").data("tag");
							var tagSearch = self.helpForm.getSearchTag(tagac);
							if (!tagSearch) return true;
							var tableSearchName = self.helpForm.getTableName(tagSearch);
							var columnSearchName = self.helpForm.getColumnName(tagSearch);

							if (self.state.DS.tables[tableSearchName] && self.state.DS.tables[tableSearchName].columns[columnSearchName])
								setCssFunc(this, tableSearchName, columnSearchName, "border-bottom");

							// controllo campi semplici. la check potrebbe avere nel tag un valore specificato
						} else if ($(this).attr("type") && ($(this).attr("type").toUpperCase() === "CHECKBOX" || $(this).attr("type").toUpperCase() === "RADIO")) {
							setCssFunc(this, tname, cname, "outline");
						} else if (this.tagName.toUpperCase() === "SELECT") {
							setCssFuncSelect2(this, tname, cname);
						} else if (self.state.DS.tables[tname] && self.state.DS.tables[tname].columns[cname]) {
							setCssFunc(this, tname, cname, "border-bottom");
						}
					});
			},

			/**
			 *
			 * @param {Date} date
			 * @returns {boolean}
			 */
			isNullOrMinDate: function (date) {
				if (!date
					|| (date.getDate() === 1 && date.getMonth() === 0 && date.getFullYear() === 1000)
					|| (date.getDate() === 31 && date.getMonth() === 11 && date.getFullYear() === 999)
				)
					return true;
				else
					return false;
			},

			/**
			 *
			 * @param {string} dateTimeString
			 * @returns {Date}
			 */
			getDateTimeFromString: function (dateTimeString) {
				var typedObject = new appMeta.TypedObject('DateTime', dateTimeString, 'tabella.colonna.g');
				return typedObject.value;
			},

			/**
			 * Format the value to show on textBox. Es number on row is 1234.56 it become 1.234,56. point thousand separator and comma decimal separator
			 * @param {number} value
			 * @param {number} precision
			 * @returns {string}
			 */
			fillTextBoxFromNumber: function (value, precision) {
				precision = (precision ? precision : 2);
				return new appMeta.TypedObject('Decimal', value, 'tabella.colonna.fixed.' + precision).stringValue('tabella.colonna.fixed.' + precision)
			},

			/**
			 *
			 * @param {Date} d
			 */
			stringFromDate_ddmmyyyy: function (d) {
				if (!d) return '';
				return d.getDate().toString() + '/' + (d.getMonth() + 1).toString() + '/' + d.getFullYear().toString();
			},

			/**
			 *
			 * @param {Date} d
			 */
			stringForDbFromDate_yyyymmdd: function (d) {
				if (!d) return '';

				return d.getFullYear().toString() + ((d.getMonth() + 1) > 9 ? '' : '0') + (d.getMonth() + 1).toString() + ((d.getDate()) > 9 ? '' : '0') + d.getDate().toString();
			},
			
			/*funzione per il calcolo del json delle colonne nipoti o del titlo calcolato
			 p[0] : stringa o objectRow
			 p[1] : colonna della riga
			 p[2] : label
			 */
			stringify: function (params, outputType) {
				if (outputType === 'string') {
					return _.filter(
						_.map(params, function (line) {
							if (line[0]) {
								if (line[1] && line[0][line[1]]) return '<b>' + line[2] + '</b>: ' + (line[0][line[1]] + '').trim();
								if (!line[1]) return '<b>' + line[2] + '</b>: ' + line[0].toString().trim();
							}
						}, ''),
						function (s) {
							return !!s;
						})
						.join("; ");
				}

				if (outputType === 'json') {
					var obj = {};
					_.forEach(params, function (line) {
						if (line[0]) {
							if (line[1] && line[0][line[1]]) obj[line[2]] = (line[0][line[1]] + '').trim();
							if (!line[1]) obj[line[2]] = line[0].toString().trim();
						}
					});

					return JSON.stringify(obj);
				}
			},

			/**
			 * @private
			 * abilita e disabilita un controllo sulla pagina
			 */
			enableControl: function (el, bool) {
				this.enableEl(el, bool);
				this.readOnlyEl(el, !bool);
				if (el.css)
					if (bool) {
						el.css("pointer-events", "unset")
					} else {
						el.css("pointer-events", "none")
					}
			},

			/**
			 * abilita e disabilita tutti i controlli dell'oggetto principale
		
			 */
			enableAllParentRowControl: function (parentRow, DSName, bool) {
				var DSName = DSName;
				var enable = bool;
				var self = this;
				_.forEach(parentRow.getRow().table.columns, function (column, bool) {
					var control = "#" + DSName + "_" + column.name;
					if ($(control)) {
						self.enableControl($(control), enable);
					}
				});

			},



			saveDataStop: function (mp, res) {
				if (res && !mp.detailPage) appMeta.Toast.showNotification(appMeta.localResource.saveSuccesfully);
				return true;
			},

			/**
			 * @method setPageTitle
			 * @public
			 * @description SYNC
			 * Based on the state of the form it sets the page title ("name of Page" + "suffix depending on state")
			 */
			setPageTitle: function () {
				var suffix = appMeta.localResource.insertTitle;
				if (this.state.isSearchState()) {
					suffix = appMeta.localResource.searchTitle;
					this.hideTabs();
				} else {
					if (this.state.isEditState()) {
						suffix = appMeta.localResource.changeTitle;
					}
					this.showAllTbas();
				}
				this.setTitle(this.getName() + " (" + suffix + ")");
			},

			hideTabs: function () {
				//nascondo le linguette dei tab
				$("a[href^='#tab']").hide();
				//rimuovo eventuali fake tab rimasti
				$("#tabfake").remove();
				//spengo il pannello del tab attivo in quel momento se non è il primo ed attivo il primo
				var currentActiveTab = document.getElementsByClassName("active")[1];
				var firstTab = document.getElementsByClassName("tab-pane")[0];
				if (firstTab != currentActiveTab) {
					currentActiveTab.className = currentActiveTab.className.replace(" active", "");
					currentActiveTab.className = currentActiveTab.className.replace(" show", "");
					firstTab.className = firstTab.className + " show active";
				}

				//aggiungo la linguetta del tab fake con la frase dei filtri di ricerca
				$(this.rootElement + " .nav.nav-tabs").append('<li id="tabfake"  class="nav-item">');
				$("#tabfake").append('<a id="atabfake" data-bs-toggle="pill" class="nav-link active show">');
				$("#atabfake").append('<i class="fa fa-fw fa-search">');
				$("#atabfake").append('<span id="spantab">');
				$("#spantab").text(" " + appMeta.localResource.insertFilterSearch);
			},

			showAllTbas: function () {
				$("a[href^='#tab']").show();
				$("#tabfake").remove();
			},
			
			/**
			 * @method multichoose
			 * @public
			 * @description ASYNC
			 * Manages the choice of a row
			 * @param {string} command
			 * @param {jsDataQuery} filter
			 * @param {html element} origin
			 * @returns {Deferred(DataRow[])}
			 */
			multichoose: function (entityName, listtype, filter) {
				var def = Deferred("multichoose");
				var self = this;
				this.showWaitingIndicator(appMeta.localResource.modalLoader_wait_valuesSearching);
				var res = this.getFormData(true).then(function () {
					var unaliased = self.getDataTable(entityName).tableForReading();
					var entityTable = self.getDataTable(entityName);
					entityTable.clear();
					return def.from(self.selectMany(listtype, filter, unaliased));
				});
				return def.from(res).promise();
			},

			/**
			 * @method selectMany
			 * @private
			 * @description ASYNC
			 * @param listingType
			 * @param filter
			 * @param searchTableName
			 * @returns {Deferred(DataRow[])}
			 */
			selectMany: function (listingType, filter, searchTableName) {
				var def = Deferred("selectOne");
				var isSearchTable = true;  // memorizzo per capire se sedvo forzare la chiusura dell'elenco eventualmente aperto
				var mergedFilter = filter;
				var self = this;

				var metaToConsider = this.state.meta;

				if (searchTableName !== this.primaryTableName) {
					metaToConsider = appMeta.getMeta(searchTableName);
					metaToConsider.listTop = this.listTop;
				}
				var prefilter = mergedFilter;
				var dataTableSearch = this.getDataTable(searchTableName);
				var sort = metaToConsider.getSorting(listingType);
				var staticFilter = metaToConsider.getStaticFilter(listingType);

				var res = utils._if(!!dataTableSearch)
					._then(function () {
						// il sort prendod al emtadato.se non lo trovo allora provo a vedere se sta sulla tabella, perchè configurato sul meta server e serializzato
						sort = (sort ? sort : dataTableSearch.orderBy());
						// il backend già me lo ha impostato. se è esplicitato sul meta js allora leggo anche quello
						mergedFilter = self.helpForm.mergeFilters(mergedFilter, staticFilter);
						mergedFilter = self.helpForm.mergeFilters(mergedFilter, dataTableSearch.staticFilter());
						return true;
					})._else(function () {
						return getData.createTableByName(searchTableName, "*")
							.then(function (temp) {
								if (!temp.key().length &&
									!!metaToConsider.primaryKey &&
									metaToConsider.primaryKey().length > 0) {
									temp.key(metaToConsider.primaryKey());
								}
								return metaToConsider.describeColumns(temp, listingType);
							});
					}).then(function () {
						// eseguo la query. passo "null" come sorting, perchè la prima volta vince quello del backend. in quanto potrebbe esserci redirezione
						// poi quando vive il controllo nelle successive paginazioni o dordinamenti sarà passato quello client.
						return getData.getPagedTable(searchTableName, 1, appMeta.config.listManager_nRowPerPage, mergedFilter, listingType, null)
							.then(function (dataTablePaged, totPage, totRows) {
								dataTablePaged.dataset = self.state.DS;
								if ((totRows === 0)) {
									var mergedFilterString = (mergedFilter) ? mergedFilter.toString() : "";
									var filterString = appMeta.localResource.getFilterMessage(mergedFilterString);
									var msgNoRowFound = appMeta.localResource.getNoRowFound(searchTableName,
										filterString,
										listingType);
									if (!appMeta.security.isAdmin()) msgNoRowFound = null;
									return new appMeta.BootstrapModal(appMeta.localResource.alert,
										appMeta.localResource.noElementFound,
										[appMeta.localResource.ok],
										appMeta.localResource.cancel,
										msgNoRowFound).show(self)
										.then(function () {
											self.hideWaitingIndicator();
											return def.resolve(null);
										});
								}

								// se c'èuna riga sola la torno subito
								if (totRows === 1) {
									self.hideWaitingIndicator();
									// array con una riga
									return def.resolve([dataTablePaged.rows[0].getRow()]);
								}

								// mostra lista modale. Nel caso di elenco di ricerca salvo in var di classe, così lo chiudo quando encessario
								// Nel caso autochoose lascio aperto l'elenco, e apro nuova modale per la liste dei risultati, senza nascondere l'elenco
								// Utile nel caso di edit consecutivi di righe prese da un elenco (Al click singolo infatti l'elenco non si chiude)
								var currList = self.createAndGetListManagerMulti(searchTableName, listingType, prefilter, true, self.rootElement, self, true, null, !isSearchTable, sort);
								return currList.show(dataTablePaged, totPage, totRows)
									.then(function (res) {
										if (res) {
											return def.resolve(res);
										}
										return def.resolve(null);
									});
							});
					});

				return def.from(res).promise();
			},

			/**
			 * @method createAndGetListManagerMulti
			 * @private
			 * @description SYNC
			 * @param searchTableName
			 * @param listingType
			 * @param prefilter
			 * @param isModal
			 * @param rootElement
			 * @param metaPage
			 * @param filterLocked
			 * @param toMerge
			 * @param isCommandSearch
			 * @param sort
			 * @returns {ListManagerMultiSelect}
			 */
			createAndGetListManagerMulti: function (searchTableName, listingType, prefilter, isModal, rootElement, metaPage, filterLocked, toMerge, isCommandSearch, sort) {
				var lm = new window.appMeta.ListManagerMultiSelect(searchTableName, listingType, prefilter, isModal, rootElement, metaPage, filterLocked, toMerge, sort);
				lm.init();
				return lm;
			},

			/**
			 * Apre un controllo multiselect control e crea nuove righe in "tableToFill"
			 * @param objPrm {
					{
					 columnNameText: string -> nome colonna della tabella identificativa sorgente, in cui si legge il testo per farne poi la like
					 tableName: string, -> nome della tabella sorgente
					 tagSearch: string -> tag del controllo text dove inserire il testo da cercare
					 columnSource: string, -> colonna sorgente da cui copiare le chiavi da mettere nella tab di collegamento
					 columnToFill: string, -> colonna in cui copiare la columnSource
					 tableToFill: string, -> tabella di collegamento in cui inserire le nuove righe
					 listType: string, -> listtype dell'elenco da mostrare
					 idControl: string -> id html del controllo in cui inseriamo il testo da cercare
				  }
			   }
			 */
			searchAndAssign: function (objPrm) {
				var waitingHandler;
				var self = this;
				var def = Deferred('searchAndAssign');
				// recupero riga principale corrente
				var parentRow = this.state.currentRow;
				if (objPrm.parentRow) {
					parentRow = objPrm.parentRow;
				}
				//console.log("table is "+objPrm.tableName);
				var dtSource = this.getDataTable(objPrm.tableName);
				var filterSearch = this.helpForm.getSearchText($("#" + objPrm.idControl), dtSource.columns[objPrm.columnNameText], objPrm.tagSearch);
				var filterSearchAndParm = self.helpForm.mergeFilters(filterSearch, objPrm.filter);

				// elementi già presenti nella tabella di collegamento
				// quando si apre la tabella collegata questi elemnti devono essere esclusi
				var toEsclude = _.map(this.state.DS.tables[objPrm.tableToFill].rows, function (r) {
					return r[objPrm.columnToFill];
				});

				var filter = null;
				// aggiungo un filtro che esclude dalal tabella collegata gli elementi già selezionati (cioè presenti nella tabella di collegamento)
				if (!objPrm.columnSource.includes(",")) {
					var filterToEsclude = this.q.isNotIn(objPrm.columnSource, toEsclude);
					filter = self.helpForm.mergeFilters(filterSearchAndParm, filterToEsclude);
				} else {
					filter = filterSearchAndParm;
				}

				//console.log('select * from ' + objPrm.tableName + ' where ' + filter.toString());

				// rowp -> è la riga già presente sul dtTofill
				// rowSelected -> è la riga scelta sul controllo, che dobiamo inserire
				// objPrm -> oggetto che contiene prm di configurazioni passati dalla specifica istanza di metapage
				// parentRow -> riga padre
				// come riga nella tabella di collegamento, e va controllato se è stataa ggiunta
				var isRowAlreadyAdded = function (rowp, rowSelected, objPrm, parentRow) {
					var columnsToFill = objPrm.columnToFill.split(",");
					var columnsSource = objPrm.columnSource.split(",");
					var isAdded = true;
					_.forEach(columnsToFill, function (colToFill, index) {
						var columnSource = columnsSource[index];
						// se prendo una chiave diversa allora non è già aggiunto
						if (rowp[colToFill] !== rowSelected[columnSource]) {
							isAdded = false;
							return false; // esco dal ciclo
						}
					});

					// se già ho individuato che non è stata aggiunta allora torno false
					// altrimenti controllo chiavi del padre
					if (!isAdded) {
						return false;
					}

					// oltre a controllare le colonne passate da oggetto di configurazione objPrm
					// controlliamo la chiave della riga padre.
					var keysParent = parentRow.getRow().table.key();
					_.forEach(keysParent, function (key) {
						// se prendo una chiave diversa allora non è già aggiunto
						if (rowp[key] !== parentRow[key]) {
							isAdded = false;
							return false; // esco dal ciclo
						}
					});

					return isAdded;
				};

				// effettuo la scelta sulla tabella sorgente
				this.multichoose(objPrm.tableName, objPrm.listType, filter)
					.then(function (rowsToAdd) {
						var isToAdd = !!rowsToAdd && rowsToAdd.length > 0;
						var dtToFill = self.getDataTable(objPrm.tableToFill);
						var arrayRowsToAdd = [];
						// ci sono righe da aggiungere
						if (isToAdd) {
							// per ogni riga selezionata sul selezionatore multiplo
							_.forEach(rowsToAdd, function (rowSelected) {
								var isRowToadd = true;
								//console.log(rowSelected.current[objPrm.columnToFill]);

								// osservo se già è inserita, e nel caso era deleted la riammetto tramite "rejectChanges"
								_.forEach(dtToFill.rows, function (rowp) {
									// se è la stessa chiave allora vedo se era deleted
									if (isRowAlreadyAdded(rowp, rowSelected.current, objPrm, parentRow)) {
										if (rowp.getRow().state === jsDataSet.dataRowState.deleted) {
											rowp.getRow().rejectChanges(); // riabilito, e tolgo da array di righe da aggiungere
										}
										isRowToadd = false;
										return false; // esco se trovo che è la stessa, non serve confrontare con altre
									}
								});

								// se esco dal ciclo annidato con riga da aggiungere popolo un nuovo array
								if (isRowToadd) {
									arrayRowsToAdd.push(rowSelected);
								}

							});
						}

						// aggiungo se serve, altriementi eseguo solo refresh
						appMeta.utils._if(arrayRowsToAdd.length > 0)
							._then(function () {
								waitingHandler = self.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
								var meta = appMeta.getMeta(objPrm.tableToFill);
								meta.setDefaults(dtToFill);
								// eseguo loop asincrono per fare getNewRow, cioè inserisco le righe sulla tabella
								var chain = $.when();
								_.forEach(arrayRowsToAdd, function (rowToAdd) {
									chain = chain.then(function () {
										return meta.getNewRow(parentRow.getRow(), dtToFill, self.editType)
											.then(function (rowToInsert) {
												// valorizzo il campo/i campi necessari presi dal controllo
												var columnsToFill = objPrm.columnToFill.split(",");
												var columnsSource = objPrm.columnSource.split(",");
												_.forEach(columnsToFill, function (colToFill, index) {
													// prendo la rispettiva columnsoruce
													var columnSource = columnsSource[index];
													rowToInsert.current[colToFill] = rowToAdd.current[columnSource];
												});
												// se la chiave dell'oggetto scelto è composta da più colonne le valorizzo adesso
												_.forEach(rowToInsert.table.key(), function (key) {
													var value = rowToInsert.current[key];
													if (!value && rowToAdd.current[key]) {
														rowToInsert.current[key] = rowToAdd.current[key];
													}
												});
												return true; // devo tornare qualcosa per risolvere il deferred
											});
									});
								});

								// risolvo array di deferred con le getNewRow appena create
								return chain;
							})
							.then(function () {
								// rinfresco la pagina
								self.freshForm(true, true)
									.then(function () {
										// nascondo indicatore di attesa
										self.hideWaitingIndicator(waitingHandler);
										def.resolve();
									});
							});

						// fine multichoose
					});

				return def.promise();
			},

			getOriginalFileName: function (fileName) {
				var fname = fileName;
				var sep = appMeta.config.separatorFileName;
				var sepIndex = fileName.indexOf(sep);
				if (sepIndex) fname = fileName.substring(sepIndex + 4, fileName.length);
				return fname;
			},

			/**
			* Calcola differenza in giorni tra due date
			* @param endDate
			* @param startDate
			*/
			getDays: function (startDate, endDate) {
				var datediff = Math.abs(startDate.getTime() - endDate.getTime());
				return parseInt(datediff / (24 * 60 * 60 * 1000), 10);
			},

			isNullOrNotANumber: function (variable) {
				return isNaN(variable) || variable === undefined || variable === null;
			},

			isNull: function (variable) {
				return variable === undefined || variable === null;
			},

			sumBy: function (elements, filterFunction, decimalDigits) {
				if (!decimalDigits) decimalDigits = 2;
				return _.ceil(_.sumBy(elements, filterFunction), decimalDigits);
			},

			getChildren: function (tableName, parentIdValue, parentIdName, parent) {

				var children = [];
				var rows = appMeta.currApp.currentMetaPage.state.DS.tables[tableName].rows;

				if (parent) {
					rows = appMeta.currApp.currentMetaPage.state.callerPage.getDataTable("perfprogettoobiettivoattivita_alias3").rows;
				}

				for (var i = 0; i < rows.length; i++) {
					if (rows[i][parentIdName] == parentIdValue) {
						children.push(rows[i]);

					}
				}
				return children;

			},

			getChildRow: function (dataset, tableName, keyColumn, parentKeyColumn, rootNode) {

				var table = dataset.getDataTable(tableName);
				var map = {}, node, roots = [], i;


				for (i = 0; i < table.rows.length; i += 1) {
					map[table.rows[i][key]] = i; // initialize the map
					//   table.rows[i].children = []; // initialize the children
				}

				for (i = 0; i < table.rows.length; i += 1) {
					node = list[i];
					if (node.parentId !== "0") {
						// if you have dangling branches check that map[node.parentId] exists
						table.rows[map[node.parentId]].children.push(node);
					} else {
						roots.push(node);
					}
				}
				return roots;
			},

			determinaSessoDaCodiceFiscale: function (codiceFiscale) {
				// Verifica se il codice fiscale ha la lunghezza corretta
				if(codiceFiscale.length !== 16) {
				return "Codice fiscale non valido";
				}

				// Estrai i caratteri che rappresentano il sesso
				const sessoCode = codiceFiscale.substring(8, 10);

				// Converte il codice del sesso in un numero
				const sessoNumero = parseInt(sessoCode, 10);

				// Determina il sesso corretto
				if (sessoNumero >= 40) {
					return "F";
				} else {
					return "M";
				}
			},
			
			/*********************************************************************
			****************  FUNZIONI PER PROTOCOLLO: ***************************
			*********************************************************************/

			/**
			 *
			 * @param idreg_origine
			 * @param idreg_destinazione
			 * @param oggetto
			 * @param testo
			 * @param codiceregistro
			 */
			assegnaProtocollo: function (idreg_origine, idreg_destinazione, idprotocollodockind, oggetto, codiceregistro, arrayTablesToProtocol) {
				if (!this.state.isInsertState()) {
					var self = this;
					var rowToNullify = null;
					// salvo prima l'oggetto da protocollare, così se ci sono errori blocco tutto
					var waitingHandler = self.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
					return this.getFormData(true)
						.then(function () {
							var def = Deferred('assegnaProtocollo');
							var testo = self.getHashForProtocol(arrayTablesToProtocol);

							// verifico se protocollo gia esiste
							var filterExisting = self.q.and(
								self.q.eq("annullato", "N"),
								self.q.eq("codiceregistro", codiceregistro)
							);

							// ha salvato e quindi protocollo
							return getData.runSelect("protocollo", "*", filterExisting, null)
								.then(function (dt) {
									if (dt.rows.length) {
										// confronta il testo
										var testoDb = dt.rows[0].testo;
										// Gia protocollato
										if (self.areEqualTestoProtocollo(testoDb, testo)) {
											self.hideWaitingIndicator(waitingHandler);
											return def.from(self.showMessageOk("documento già protocollato"));
										}
										// Devo annullare il doc, infatti passo come primo parametro la riga attuale e fare un nuovo protocollo
										rowToNullify = dt.rows[0];
									}
									self.hideWaitingIndicator(waitingHandler);
									// procedo con la protocollazione automatica
									return def.from(self.saveProtocol(rowToNullify, idreg_origine, idreg_destinazione, oggetto, testo, codiceregistro, idprotocollodockind));

								}); // chiude la runSelect
						});
				}

				return this.showMessageOk(localResource.protocolSaveNOSaved);

			},

			areEqualTestoProtocollo: function (testoDb, testoClient) {
				return testoDb === testoClient;
			},


			saveProtocol: function (rowToNullify, idreg_origine, idreg_destinazione, oggetto, testo, codiceregistro, idprotocollodockind) {
				var self = this;
				var def = Deferred('saveProtocol');
				var metaProtocollo = appMeta.getMeta('protocollo');
				var metaProtocolloDestinatario = appMeta.getMeta('protocollodestinatario');
				var metaProtocolloDoc = appMeta.getMeta('protocollodoc');
				var metaProtocollodocElement = appMeta.getMeta('protocollodocelement');
				var protocollo, protocollodestinatario, protocollodoc, protocollodocelement;
				var dataSetProtocolloSeg;
				var waitingHandler;
				var tMain;

				utils._if(!this.detailPage)
					._then(function () {
						return self.cmdMainSave();
					})._else(function () {
						return true;
					}).then(function (res) {
						if (!res) {
							return def.resolve();
						}
						waitingHandler = self.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
						return getData.getDataSet('protocollo', 'seg')
							.then(function (dsRes) {
								dataSetProtocolloSeg = dsRes;
								protocollo = dataSetProtocolloSeg.tables.protocollo;
								protocollodestinatario = dataSetProtocolloSeg.tables.protocollodestinatario;
								protocollodoc = dataSetProtocolloSeg.tables.protocollodoc;
								protocollodocelement = dataSetProtocolloSeg.tables.protocollodocelement;
								// --------------> potrebbe chaimare qualcosa di esterno
								metaProtocollo.setDefaults(protocollo);
								return metaProtocollo.getNewRow(null, protocollo, null);
							}).then(function () {
								metaProtocolloDestinatario.setDefaults(protocollodestinatario);
								return metaProtocolloDestinatario.getNewRow(protocollo.rows[0].getRow(), protocollodestinatario, null);
							}).then(function () {
								metaProtocolloDoc.setDefaults(protocollodoc);
								return metaProtocolloDoc.getNewRow(protocollo.rows[0].getRow(), protocollodoc, null);
							}).then(function () {
								metaProtocollodocElement.setDefaults(protocollodocelement);
								return metaProtocollodocElement.getNewRow(protocollodoc.rows[0].getRow(), protocollodocelement, null);
							}).then(function () {
								return getData.getDataSet('registry', 'istituti_princ');
							}).then(function (dsRegIstitutiPrinc) {
								var filter = self.q.eq('idreg', self.idreg_istituto);
								return getData.fillDataSet(dsRegIstitutiPrinc, 'registry', 'istituti_princ', filter);
							}).then(function (dsRegIstitutiPrinc) {
								var rowProtocollo = protocollo.rows[0];
								var rowProtocolloDestinatario = protocollodestinatario.rows[0];
								var rowProtocolloDoc = protocollodoc.rows[0];
								var rowProtocolloDocElement = protocollodocelement.rows[0];

								//TODO rowProtocolloDocElement primo protocollo

								rowProtocollo.idreg_origine = idreg_origine;
								rowProtocollo.oggetto = oggetto;
								rowProtocollo.protdata = new Date();
								rowProtocollo.testo = testo;
								rowProtocollo.codiceammipa = dsRegIstitutiPrinc.tables.istitutoprinc.rows[0].codiceammipa;
								rowProtocollo.idaoo = dsRegIstitutiPrinc.tables.aoo.rows[0].idaoo;
								rowProtocollo.codiceregistro = codiceregistro;
								rowProtocollo.annullato = 'N';

								rowProtocolloDestinatario.idreg_dest = idreg_destinazione;

								//se istituto origine == destinatario studente
								//se studente origine == destinatario istituto
								//se istituto origine == destinatario istituto

								// mittente istituto, destinatario studente
								utils._if(idreg_origine === self.idreg_istituto && idreg_destinazione === self.idreg_studente)
									._then(function () {
										// recupero mail dello studente
										var filter = self.q.and(self.q.eq('idreg', idreg_destinazione), self.q.isNotNull('email'));
										return getData.runSelect('registryreference', 'email', filter, null).then(function (dt) {
											if (dt.rows.length) {
												rowProtocolloDestinatario.destmail = dt.rows[0].email;
											}
											return true;
										});
									})
									._else(function () {

										if (idreg_origine === self.idreg_studente && idreg_destinazione === self.idreg_istituto) {

											// mittente studente , destinatario istituto
											if (dsRegIstitutiPrinc.tables.registryreference.rows.length) {
												rowProtocolloDestinatario.destmail = dsRegIstitutiPrinc.tables.registryreference.rows[0].email;
											}
										}
										if (idreg_origine === self.idreg_istituto && idreg_destinazione === self.idreg_istituto) {

											// mittente istituto , destinatario istituto
											if (dsRegIstitutiPrinc.tables.registryreference.rows.length) {
												rowProtocolloDestinatario.destmail = dsRegIstitutiPrinc.tables.registryreference.rows[0].email;
											}
										}

										return true;
									})
									.then(function () {

										rowProtocolloDoc.idprotocollorifkind = 3;
										rowProtocolloDoc.idmimetype = 23;

										rowProtocolloDocElement.oggetto = oggetto;
										rowProtocolloDocElement.idprotocollodockind = idprotocollodockind;
										// ******** ---> calcolare sha-1 del testo e inserirlo nel prox campo "telematicohash"
										// rowProtocolloDocElement.telematicohash = 'hashtodo'

										// ABBIAMO CREATO la nuova riga protocollo, prima di salvare verifichaimo che la vecchia riga sia da annullare
										if (rowToNullify) {
											rowToNullify.annullato = "S";
											rowToNullify.dataannullamento = new Date();
											dataSetProtocolloSeg.tables.protocollo.importRow(rowToNullify);
										}

										// -----> su "protocollo seg" prend e la tabella principale corrente e inietta la riga attuale con i valori modificati.
										tMain = dataSetProtocolloSeg.tables[self.primaryTableName];
										if (!self.detailPage) {
											// forzo un valore di default inventato, coì la riga va in stato modificata, e rimarrà sincronizzata con quella del server
											self.state.currentRow.protnumero = "99999";
										}
										tMain.importRow(self.state.currentRow);
										return appMeta.callWebService("protocolla",
											{
												dsProtocolloSeg: getDataUtils.getJsonFromJsDataSet(dataSetProtocolloSeg, true),
												tableName: self.primaryTableName
											});
									}).then(function (jsonRes) {
										return self.manageProtocollaResponse(dataSetProtocolloSeg, jsonRes);
									}).then(function (dsOut, msg, success) {
										self.hideWaitingIndicator(waitingHandler);
										if (success) {
											// il protocolla è andato bene, quindi rinfresco i valori sulla riga principale
											// che ho appena reso persistenti
											self.state.currentRow.getRow().makeSameAs(tMain.rows[0].getRow());
											return self.freshForm(true, false)
												.then(function () {
													return self.showMessageOk(localResource.protocolSaveOK);
												}).then(function () {
													def.resolve();
												});
										}
										// il save ha avuto problemi
										return self.showMessageOk(localResource.protocolSaveNOK + " " + msg)
											.then(function () {
												def.resolve();
											});
									});
							});
					});

				return def.promise();
			},

			/**
			 *
			 * @param dataSetProtocolloSeg
			 * @param jsonRes
			 * @returns {Deferred}
			 */
			manageProtocollaResponse: function (dataSetProtocolloSeg, jsonRes) {
				var def = Deferred("saveDataSet");
				// recupero oggetto json
				var obj = getDataUtils.getJsObjectFromJson(jsonRes);
				// dal json obj recupero i vari pezzi. 1. dataset 2. success 3. canignore 4. messages
				// messages a sua volta sarà un array di oggetti che metterò in obj js di tipo DbProcedureMessage
				var dsOut = getDataUtils.getJsDataSetFromJson(obj.dataset);
				var success = obj.success;
				// a prescindere se il salvataggio è avvenuto, mergio il ds di output del metodo save con quello di input
				var changesCommittedToDB = (obj.messages.length === 0); // se non ci sono msg e quindi è andato bene sono effettivamente da calcellare
				getDataUtils.mergeDataSetChanges(dataSetProtocolloSeg, dsOut, changesCommittedToDB);
				var msg = _.reduce(obj.messages, function (acc, m) {
					acc += " " + m.description + "\n";
					return acc;
				}, '');
				return def.resolve(dataSetProtocolloSeg, msg, success);
			},

			/**
			 * @private
			 * funzione di utility utilizzata in assegnaProtocollo()
			 */
			getHashForProtocol: function (arrayTablesToProtocol) {
				var self = this;
				var obj = _.reduce(arrayTablesToProtocol, function (result, value, key) {
					var dt = self.getDataTable(value);
					var exclude = ["protanno", "protnumero", "lt", "cu", "lu"];
					result += _.reduce(dt.rows, function (acc, r) {
						acc += _.join(
							_.map(Object.keys(r), function (k) {
								if (!exclude.includes(k)) {
									return r[k];
								}
								return '';
							}), ",");
						return acc;
					}, '');
					return result;
				}, '');

				return obj;
			},
			
			/*********************************************************************
			****************  FUNZIONI PER SEGRETERIE: ***************************
			*********************************************************************/

			getSospensioni: function () {
				var def = Deferred('getSospensioni');
				if (!appMeta.appMain.dtSospensioni && this.idreg_istituto) {
					// salva giorni di sospensione, da utilizzare poi nella funz schedule()
					var filterSosp =
						this.q.or(
							this.q.eq("idreg", this.idreg_istituto),
							this.q.eq("idreg", appMeta.security.usr('idreg'))
						);
					return appMeta.getData.runSelect("sospensione", "start,stop", filterSosp)
						.then(function (dtSosp) {
							appMeta.appMain.dtSospensioni = dtSosp;
							return def.resolve();
						});
				}

				return def.resolve();
			},
			
			/**
			 * /
			 * @param {any} i indice della tipologia della porzione d'anno
			 */
			stringFromIdporzanno: function (i) {
				var output = '';
				switch (i) {
					case 1:
						output = ' mese';
						break;
					case 2:
						output = ' bimestre';
						break;
					case 3:
						output = ' trimestre';
						break;
					case 4:
						output = ' quadrimestre';
						break;
					case 5:
						output = ' semestre';
						break;
					case 6:
						output = ' annualità';
						break;
				}
				return output;
			},

			/**
			 * Calcola anno accademico, a seconda se sto prima o dopo Ferragosto
			 * @param date
			 */
			getAAByDate: function (date) {
				var myDate = moment(date);
				var year = myDate.year();
				var watermark = moment("15/08/" + year, "DD/MM/YYYY");
				if (myDate.diff(watermark) > 0) {
					return (myDate.year()) + "/" + (myDate.year() + 1);
				}
				return (myDate.year() - 1) + "/" + myDate.year();
			},

			/*********************************************************************
			****************  FUNZIONI PER PERFORMANCE: ***************************
			*********************************************************************/

			getComportamentiAndAteneo: function (listType, listTypeComportamenti) {
				var def = appMeta.Deferred("getCompotamenti");

				if (!this.comportamentiGiaCalcolati) {
					var grid = $('#grid_perfvalutazionepersonalecomportamento_' + listTypeComportamenti).data("customController");
					var gridAteneo = $('#grid_perfvalutazionepersonaleateneo_default').data("customController");

					var self = this;
					var IsIn = false;
					var chain = $.when(); //inizializzo la chain

					var waitingHandler = self.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);

					appMeta.callWebService("calcolaComportamenti",
						{
							idAfferenza: !self.state.currentRow.idafferenza ? $('#perfvalutazionepersonale_' + listType + '_idafferenza').val() : self.state.currentRow.idafferenza,
							year: !self.state.currentRow.year ? $('#perfvalutazionepersonale_' + listType + '_year').val() : self.state.currentRow.year
						}).then(function (resDS) {

							//per assicurarsi di farlo una volta sola
							self.comportamentiGiaCalcolati = true;

							var DS = appMeta.getDataUtils.getJsDataSetFromJson(resDS);
							//---------------aggiorno i pesi ----------------------------------
							if (self.state.isInsertState() || self.state.isEditState()) {
								if (DS.tables.mansionekind) {
									var mansionekindDt = DS.tables.mansionekind;
									if (self.state.DS.tables["perfvalutazionepersonaleateneo"].rows.length) {
										var valAteneo = self.state.DS.tables["perfvalutazionepersonaleateneo"].rows[0];
										valAteneo.peso = mansionekindDt.rows[0].pesoateneo;
										valAteneo.punteggiopesato = valAteneo.punteggio * valAteneo.peso / 100;
										if (!valAteneo.punteggiopesato)
											valAteneo.punteggiopesato = 0;
									}
									self.state.currentRow.pesoperfuo = mansionekindDt.rows[0].pesouo;
									$('#perfvalutazionepersonale_' + listType + '_pesoperfuo').val(mansionekindDt.rows[0].pesouo)
									//solo la prima volta perchè il valutatore li può azzerare!!!!!
									if (!self.state.currentRow.pesocomportamenti) {
										self.state.currentRow.pesocomportamenti = mansionekindDt.rows[0].pesocomp;
										$('#perfvalutazionepersonale_' + listType + '_pesocomportamenti').val(mansionekindDt.rows[0].pesocomp);
									}
									//solo la prima volta perchè il valutatore li può azzerare!!!!!
									if (!self.state.currentRow.pesoobiettivi) {
										self.state.currentRow.pesoobiettivi = mansionekindDt.rows[0].pesoindividuale;
										$('#perfvalutazionepersonale_' + listType + '_pesoobiettivi').val(mansionekindDt.rows[0].pesoindividuale)
									}
								}
							}
							//---------------associo i comportamenti -------------------------
							//solo in inserimento e se non le ho già calcolate
							if (self.getDataTable('perfvalutazionepersonalecomportamento').rows.length == 0) {
								if (DS.tables.perfcomportamento) {
									var comportamentoDt = DS.tables.perfcomportamento;
									var comportamentoTable = self.getDataTable("perfcomportamento");

									appMeta.getDataUtils.mergeRowsIntoTable(comportamentoTable, comportamentoDt.rows, true);

									_.forEach(comportamentoTable.rows, function (comportamentoRows) {

										//il merge è fatto su perfcomportamento, righe sdoppiate su perfvalutazionepersonalecomportamento se inserisco i comportamenti presenti già sul dataset.
										_.forEach(self.getDataTable("perfvalutazionepersonalecomportamento").rows, function (perfcompRows) {

											IsIn = IsIn || (perfcompRows.idperfcomportamento == comportamentoRows.idperfcomportamento);

											return true;
										});

										if (IsIn)
											return;

										chain = chain.then(function () {

											var meta = appMeta.getMeta("perfvalutazionepersonalecomportamento");

											meta.setDefaults(self.getDataTable("perfvalutazionepersonalecomportamento"));

											return meta.getNewRow(self.state.currentRow, self.getDataTable("perfvalutazionepersonalecomportamento")).then(function (row) {
												row.current.idperfcomportamento = comportamentoRows.idperfcomportamento;
												row.current.peso = comportamentoRows.peso;
												row.current.idperfvalutazionepersonale = self.state.currentRow.idperfvalutazionepersonale;

												return true;

											});
										});
									});//chiudo primo foreach
								}
							}
							return chain; //chiudo la chain
						}).then(function () {

							chain = $.when();
							//solo in inserimento e se non le ho già calcolate
							if (self.getDataTable('perfvalutazionepersonalecomportamentosoglia').rows.length == 0) {

								var i = 0;
								_.forEach(self.getDataTable("perfvalutazionepersonalecomportamento").rows, function (comportamentoRows) {
									chain = chain.then(function () {
										var filterYear = window.jsDataQuery.eq('year', self.state.currentRow.year);
										var filterComportamento = window.jsDataQuery.eq('idperfcomportamento', comportamentoRows.idperfcomportamento);
										var filter = window.jsDataQuery.and(filterYear, filterComportamento);
										//visualizzo il messaggio solo per l'ultimo inserimento
										if (i != self.getDataTable("perfvalutazionepersonalecomportamento").rows.length - 1) {
											message = false;
										}
										else message = null;
										i++;

										return self.superClass.insertSoglie({
											table: "perfvalutazionepersonalecomportamentosoglia", tableSoglie: "perfcomportamentosoglia", tableParent: "", keyColumns: "idperfvalutazionepersonale=" + comportamentoRows.idperfvalutazionepersonale + ",idperfvalutazionepersonalecomportamento=" + comportamentoRows.idperfvalutazionepersonalecomportamento, filter: filter, desMessage: message
										});

									});

								});
							}
							return chain;

						}).then(function () {

							if (grid.gridRows.length == 0) {
								appMeta.metaModel.getTemporaryValues(self.getDataTable("perfvalutazionepersonalecomportamento"));
							}
							if (gridAteneo.gridRows.length == 0) {
								appMeta.metaModel.getTemporaryValues(self.getDataTable("perfvalutazionepersonaleateneo"));
							}
							return grid.fillControl().then(function () {
								return gridAteneo.fillControl();
							});
						}).then(function () {


							self.hideWaitingIndicator(waitingHandler);
							return def.resolve();

						});


					return def.promise();
				}
				else {
					return def.resolve();
				}
			},
			calculatePercTree: function (parentIdValue, tablename) {

				var days = 0;
				var perc = 0;

				var minDataInizioPrevista;
				var minDataInizioEffettiva;
				var maxDataFinePrevista;
				var maxDataFineEffettiva;


				var children = this.getChildren(tablename, parentIdValue, "paridperfprogettoobiettivoattivita");
				for (var j = 0; j < children.length; j++) {

					var currentRow = children[j].getRow();

					if (this.getChildren(tablename, currentRow.current.idperfprogettoobiettivoattivita, "paridperfprogettoobiettivoattivita").length > 0) {
						var retValue = this.calculatePercTree(currentRow.current.idperfprogettoobiettivoattivita, tablename);
						currentRow.current.completamento = retValue.completamento;
						currentRow.current.datainizioprevista = retValue.dataInizioPrevista;
						currentRow.current.datafineprevista = retValue.dataFinePrevista;
						currentRow.current.datainizioeffettiva = retValue.dataInizioEffettiva;
						currentRow.current.datafineeffettiva = retValue.dataFineEffettiva;
					}



					var dataInizio = (!currentRow.current.datainizioeffettiva ? currentRow.current.datainizioprevista : currentRow.current.datainizioeffettiva)
					var dataFine = (!currentRow.current.datafineeffettiva ? currentRow.current.datafineprevista : currentRow.current.datafineeffettiva);


					// in caso di mancanza data prevista o effettiva delle attività, il calcolo della percentuale totale, verrà effettuato
					// utilizzando le datainizioprevista e datafineprevista del progetto
					if (this.state.callerState) {
						if (dataInizio > this.state.callerState.currentRow.datainizioprevista)
							dataInizio = this.state.callerState.currentRow.datainizioprevista;

						if (dataFine < this.state.callerState.currentRow.datafineprevista)
							dataFine = this.state.callerState.currentRow.datafineprevista;
					}

					if (dataInizio && dataFine) {

						if (!minDataInizioEffettiva) {
							minDataInizioEffettiva = dataInizio;
							if (currentRow.current.datainizioeffettiva && currentRow.current.datainizioeffettiva < minDataInizioEffettiva) {
								minDataInizioEffettiva = currentRow.current.datainizioeffettiva;
							}

						}
						else if (currentRow.current.datainizioeffettiva < minDataInizioEffettiva) {
							minDataInizioEffettiva = currentRow.current.datainizioeffettiva;
						}
						if (!minDataInizioPrevista) {
							minDataInizioPrevista = dataInizio;
							if (currentRow.current.datainizioprevista && currentRow.current.datainizioprevista < minDataInizioPrevista) {
								minDataInizioPrevista = currentRow.current.datainizioprevista;
							}
						}
						else if (currentRow.current.datainizioprevista < minDataInizioPrevista) {
							minDataInizioPrevista = currentRow.current.datainizioprevista;
						}
						if (!maxDataFinePrevista) {
							maxDataFinePrevista = dataFine;
							if (currentRow.current.datafineprevista && currentRow.current.datafineprevista > maxDataFinePrevista) {
								maxDataFinePrevista = currentRow.current.datafineprevista;
							}

						}

						else if (currentRow.current.datafineprevista > maxDataFinePrevista) {
							maxDataFinePrevista = currentRow.current.datafineprevista;
						}

						if (!maxDataFineEffettiva) {
							maxDataFineEffettiva = dataFine;
							if (currentRow.current.datafineeffettiva && currentRow.current.datafineeffettiva > maxDataFineEffettiva) {
								maxDataFineEffettiva = currentRow.current.datafineeffettiva;
							}
						}
						else if (currentRow.current.datafineeffettiva > maxDataFineEffettiva) {
							maxDataFineEffettiva = currentRow.current.datafineeffettiva;
						}

						days += this.getDays(dataInizio, dataFine);
						perc += (!currentRow.current.completamento ? 0 : currentRow.current.completamento) * this.getDays(dataInizio, dataFine);
					}
				}

				if (perc && days)
					return {
						completamento: _.ceil(perc / days, 2),
						dataInizioPrevista: minDataInizioPrevista,
						dataFinePrevista: maxDataFinePrevista,
						dataInizioEffettiva: minDataInizioEffettiva,
						dataFineEffettiva: maxDataFineEffettiva,
					};
				return 0;

			},

			/**
			* Associa le soglie censite alla tabella indicata
			* @param objPrm {
					{					 
					 table: string -> nome della tabella a cui associare le soglie
					 tableSoglie: string, -> nome della tabella da cui recuperare le soglie
					 filter: obj, -> filtro con cui recuperare le soglie,
					 ds: obj, -> nome del metadato se diverso da quello di pagina
					 keyColumns: string, -> tutte le chiavi di table esclusa quella della soglia, divise con virgola se prevalorizzati per ulteriori tabelle di collegamento 
											o per dataset diversi da quello della metapage corrente, inserire nomeChiave=valoreChiave					 
					 columnValueName: string, -> colonna a cui assegnare il valore della soglia se null "valore"
					 desMessage: string, -> testo del messaggio che indica l'associazione delle soglie, se false non è visualizzato alcun messaggio					
					}
			   }
			*/
			insertSoglie: function (objPrm) {
				var self = appMeta.currApp.currentMetaPage;

				if (!self.state.currentRow) {
					return;
				}

				var def = appMeta.Deferred("insertSoglie");

				var sogliaTable;
				var dataSet = objPrm.ds;
				var table = objPrm.table;
				var desMessage = objPrm.desMessage;
				var columnValueName = objPrm.columnValueName;
				var keyColumns = objPrm.keyColumns;
				var tableSoglie = objPrm.tableSoglie;
				var dataSetTable;
				var filter = objPrm.filter;

				var chain = $.when();
				var alreadyrowsNew = false;

				if (!tableSoglie) {
					tableSoglie = "perfsoglia";
				}


				var waitingHandler = self.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);

				appMeta.getData.runSelect(tableSoglie, "*", filter).
					then(function (dtSoglia) {
						sogliaTable = dtSoglia.rows;
						dataSetTable = self.getDataTable(table);
						if (dataSet) {
							dataSetTable = dataSet.tables[table];
						}
						alreadyrowsNew = dataSetTable.rows.some(function (r) {
							return r.getRow().state === jsDataSet.dataRowState.added;
						});

						var keys = keyColumns.split(",");
						if (!columnValueName) {
							columnValueName = "valore";
						}
						_.forEach(sogliaTable, function (sogliaRow) {
							chain = chain.then(function () {

								var alreadyExist = false;
								//per ogni soglia già inserita 
								_.forEach(dataSetTable.rows, function (oldSogliaRow) {

									if (alreadyExist)
										return;

									//controllo se per quella che sto per inserire non ha anno e tipo soglia uguali a quelle che ho inserito prima
									//per queste inoltre se ci sono ulteriori chiavi già inserite

									//l'anno può non esserci per le soglie legate alle valutazioni
									if ((!oldSogliaRow.year || oldSogliaRow.year == sogliaRow.year) && oldSogliaRow.idperfsogliakind == sogliaRow.idperfsogliakind
										/*&& oldSogliaRow[columnValueName] == sogliaRow.valore*/) { //il valore non conta
										alreadyExist = true;
									}

									if (keyColumns !== null && keyColumns.indexOf('=') > 0 && alreadyExist) {
										var constant = 0;
										var equal = 0;
										_.forEach(keys, function (key) {

											key = key.split('=');
											if (key.length > 1) {
												constant += 1;
												if (oldSogliaRow[key[0]] == key[1])
													equal += 1;

											}

										});
										if (constant != equal) {
											alreadyExist = false;
										}





									}



								});


								if (!alreadyExist) {

									var meta = appMeta.getMeta(table);
									meta.setDefaults(dataSetTable);
									// se non è passato un dataset prendo le chiavi da riga corrente del metadato, se è passato prendo le chiavi dalle costanti passate
									var currentRow = self.state.currentRow;
									if (dataSet) {
										currentRow = null;
									}

									return meta.getNewRow(currentRow, dataSetTable).then(function (row) {

										_.forEach(keys, function (key) {
											key = key.split('=');

											var keyValue;

											if (key.length > 1) {
												keyValue = key[1];
											}
											else { keyValue = currentRow[key[0]]; }

											if (typeof (row.current[key[0]]) == "number") {
												keyValue = parseFloat(keyValue);
											}

											row.current[key[0]] = keyValue;
										});

										if (row.table.columns.year) {
											row.current.year = sogliaRow.year;
										}

										if (!columnValueName) {
											columnValueName = "valore";
										}
										// i nomi delle colonne che indicano le percentuali nelle varie tabelle non coincidono
										var columnValueNameSoglia = columnValueName;
										if (!sogliaRow[columnValueName]) {
											columnValueNameSoglia = "valore";
										}


										if (row.table.columns[columnValueName]) {
											row.current[columnValueName] = sogliaRow[columnValueNameSoglia];
										}


										row.current.idperfsogliakind = sogliaRow.idperfsogliakind;

										if (row.table.columns["description"]) {

											if (sogliaRow.description)
												row.current.description = sogliaRow.description;
											else row.current.description = "";

										}


										if (row.table.columns["valorenumerico"]) {
											row.current.valorenumerico = sogliaRow.valorenumerico;
										}

										return true;
									});


								}

								return true;


							});
						});
						return chain;
					}).then(function () {
						self.hideWaitingIndicator(waitingHandler);
						if (desMessage !== false) {

							var rows = dataSetTable.rows;

							if (typeof (desMessage) != 'boolean' && !alreadyrowsNew && rows.length && rows.some(function (r) {
								return r.getRow().state === jsDataSet.dataRowState.added;
							})) {

								if (!desMessage) {
									desMessage = "Sono state aggiunte automaticamente le attuali soglie, queste verranno memorizzate quando si preme salva";
								}

								self.showMessageOk(desMessage).then(function () {
									return def.resolve();
								});
							}
						}


						return def.resolve();
					});


				return def.promise();

			},



			/**
			* Recupera i dati amministrativi di uno o più idreg
			* @param objPrm {
					{
					 idreg => uno o array di idreg 
					}
			   }
			*/
			getRegistryreference: function (objPrm) {
				var self = appMeta.currApp.currentMetaPage;
				var filterDefault = self.q.eq('flagdefault', 'S');
				var par = [];
				if (!_.isArray(objPrm)) {
					par.push(objPrm);
				}
				else par = _.map(objPrm, function (x) { return x; });
				var filterReg = self.q.isIn('idreg', par);
				var filterComplete = self.q.and(filterDefault, filterReg);
				var def = appMeta.Deferred("getRegistryreference");
				// se ci sono contatti predefiniti ...
				return appMeta.getData.runSelect("registry", "*", filterReg).
					then(function (dtRegistry) {
						return appMeta.getData.runSelect("registryreference", "*", filterReg).
							then(function (dtRef) {
								_.forEach(dtRef.rows, function (referenceRow) {
									var registryCurrent = _.first(dtRegistry.rows, function (registryRow) {
										return registryRow.idreg == referenceRow.idreg;
									});
									referenceRow.referencename = registryCurrent.forename + ' ' + registryCurrent.surname;
								});
								return def.resolve(_.orderBy(dtRef.rows, 'flagdefault', 'desc'));
							});

					});
			},

			/**
			* Invia una mail a uno o più utenti indicati
			* @param objPrm {
					{
					 emailDest: string, -> uno o più indirizzi email divisi da ;				
					 body: string, -> corpo della mail
					 subject: string, -> oggetto della mail
					 viewMessage: boolean -> visualizza il messaggio finale
					}
			   }
			*/

			sendMail: function (objPrm) {
				var self = appMeta.currApp.currentMetaPage;

				var viewMessage;

				if (objPrm.viewMessage === null) {
					viewMessage = true
				}
				else viewMessage = objPrm.viewMessage;

				var def = appMeta.Deferred("sendMail");
				var waitingHandler = self.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
				return appMeta.callWebService("sendMail",
					{
						emailDest: objPrm.emailDest,
						htmlBody: objPrm.body,
						subject: objPrm.subject

					}).then(function (msg) {
						self.hideWaitingIndicator(waitingHandler);

						if (!viewMessage) {
							if (msg) {
								def.from(self.showMessageOk(msg));
							}
							else def.resolve();

						} else {

							if (!msg) {
								msg = "La mail è stata inviata";
							}
							def.from(self.showMessageOk(msg));
						}
					});

			},

			/**
			* Invia una mail a uno o più utenti indicati 
			* @param objPrm {
					{
					 emailDest: string, -> uno o più indirizzi email divisi da ;
					 idReg: string -> uno più idReg divisi da , a cui inviare la mail
					 body: string, -> corpo della mail
					 subject: string, -> oggetto della mail			
					 viewMessage: boolean -> visualizza il messaggio finale
					}
			   }
			*/
			sendMailByIdReg: function (objPrm) {
				var self = appMeta.currApp.currentMetaPage;


				var idRegDest = [];

				if (!self.state.currentRow) {
					return;
				}
				var emailDest = [];
				var email = objPrm.emailDest;
				var def = appMeta.Deferred("sendMail");

				var waitingHandler = self.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);

				//se i destinatari sono entrambi nulli invio la mail all'utente loggato 
				if (!objPrm.emailDest && !objPrm.idReg) {
					idRegDest.push(appMeta.security.userEnv.idreg);
				}

				if (objPrm.idReg !== null && objPrm.idReg !== undefined && objPrm.idReg != '') {
					idRegDest.push(objPrm.idReg.split(',').map(function (item) {
						return Number(item);
					}));


				}

				self.getRegistryreference(idRegDest).then(function (resReg) {


					var emailDest = _.uniq(_.map(resReg, function (x) { return x.email }), function (res) {
						return res.email;

					});


					var dest = email;
					_.forEach(emailDest, function (mail) {
						if (!(dest.contains(mail))) {
							dest = dest + ";" + mail;
						}
					});



					return self.sendMail(
						{
							emailDest: dest,
							body: objPrm.body,
							subject: objPrm.subject,
							viewMessage: objPrm.viewMessage

						})
				}).then(function (msg) {
					self.hideWaitingIndicator(waitingHandler);
					def.resolve();
				});


				def.promise();


			},

			/**
			* Trasforma in <br/> gli accapo su Db (\n,\n\r,ecc)
			* @param objPrm {
					{
					 str: string, -> testo da trasformare			
					}
			   }
			*/
			getReturnFromDb: function (str) {

				return str.replace(/\r\n|\n\r|\n|\r/gi, "<br />");
			},

			/**
			* Calcola la percentuale di completamento, inserendo un valore        
			* @param arraySoglieIndicatori: contenente la lista delle soglie, del tipo {indicatore: valore, soglia: percentuale}
			* @param valorenumerico: valore da cui calcolare il completamento
			*/
			calculateCompletamentoByValoreNumerico: function (arraySoglieIndicatori, valorenumerico) {


				if (arraySoglieIndicatori.length === 0)
					return 0;

				if (arraySoglieIndicatori.length === 1) {
					// se non ho valore numerico per la soglia e sono arrivato qui vuol dire che è stato inserito 
					//un valore numerico per una soglia che non lo ha e quindi è errato e quindi torno 0
					if (arraySoglieIndicatori[0].indicatore) {
						var soglia = arraySoglieIndicatori[0].soglia;
						//se la soglia non è stata indicata vuol dire che è stato indicato 
						//solo un valore numerico e quindi per me rappresenta il 100 %
						if (!soglia) soglia = 100;
						if (valorenumerico >= arraySoglieIndicatori[0].indicatore) {
							//non si supera mail il 100%
							return soglia;
						}
						else {
							//se il valore raggiunto è sotto il valore numerico di soglia faccio la proporzione con la percentuale della soglia
							return (valorenumerico * soglia) / arraySoglieIndicatori[0].indicatore;
						}
					}
					return 0;
				}
				arraySoglieIndicatori.push({ indicatore: valorenumerico, soglia: null });

				var rowsordinate = _.orderBy(arraySoglieIndicatori, ['indicatore'], ['asc']);

				var obj1, obj2;

				var index = _.findIndex(rowsordinate, { indicatore: valorenumerico, soglia: null });
				// sono sugli estremi
				if (index === 0) {
					//recupero l'estremo
					var obj = rowsordinate[1];
					var soglia = obj.soglia;
					//se l'estremo non è il massimo (100%) ...
					if (soglia !== 100) {
						//... sono sotto alla soglia minima e torno 0
						return 0;
					}
					obj1 = rowsordinate[1];
					obj2 = rowsordinate[2];
				} else if (index === rowsordinate.length - 1) {

					index = rowsordinate.length - 1;
					var obj = rowsordinate[index - 1];
					var soglia = obj.soglia;
					if (soglia != 100) {
						return 0;
					}
					obj1 = rowsordinate[index - 1];
					obj2 = rowsordinate[Math.abs(index - 2)];
				} else {

					obj1 = rowsordinate[index - 1];
					obj2 = rowsordinate[index + 1];
				}

				var res = (((obj2.soglia - obj1.soglia) / (obj2.indicatore - obj1.indicatore)) * (valorenumerico - obj1.indicatore)) + obj1.soglia;
				return res > 100 ? 100 : res;

			},

			//Calcola la media pesata
			// arrayWeighValue contiene la lista dei valori e pesi, del tipo { valore: valore, peso: percentuale }
			calculateWeightedAverage: function (arrayWeighValue) {
				if (arrayWeighValue.length === 0)
					return 0;
				var numeratore = 0;
				var denominatore = 0;

				for (var i = 0; i < arrayWeighValue.length; i++) {
					if (isNaN(arrayWeighValue[i].valore)) {
						arrayWeighValue[i].valore = 0;
					}
					if (isNaN(arrayWeighValue[i].peso)) {
						arrayWeighValue[i].peso = 0;
					}
					numeratore += arrayWeighValue[i].valore * arrayWeighValue[i].peso;
					denominatore += arrayWeighValue[i].peso;
				}


				if (denominatore > 0) {
					return _.ceil((numeratore / denominatore), 2);

				}

				return 0;
			},

			loadRulesPerson: function (arraydef, dt, action, objective, colName, tablename, controlId) {
				var self = this;
				var valutatori = dt.select(self.q.and(self.q.eq('escluso', 'N'), self.q.eq(action, 'S'), self.q.eq(objective, 'S')));

				if (valutatori.length > 0) {
					var valutatoriOrd = _.orderBy(valutatori, ['resplevel', 'start'], ['desc', 'desc'])
					self.state.currentRow[colName] = valutatoriOrd[0].idreg;
					// se più di uno e ho scelto se stesso ...
					if (valutatori.length > 1 && self.state.currentRow.idreg == self.state.currentRow[colName]) {
						//... allora prendo l'altro
						var valutatoriFilter = _.filter(valutatori, function (o) {
							return o.idreg != self.state.currentRow.idreg;
						});
						if (valutatoriFilter.length > 0) {
							valutatoriOrd = _.orderBy(valutatoriFilter, 'resplevel', 'desc')
							self.state.currentRow[colName] = valutatoriOrd[0].idreg;
						}
					}
				}


				var filterListValutatori = self.q.isIn("idreg", _.map(valutatori,
					function (row) {
						if (row.idreg) {
							return row.idreg;
						}
						return true;
					})
				);

				appMeta.metaModel.cachedTable(self.getDataTable(tablename), false);
				var perfvalutazionepersonale_default_idreg_valCtrl = $('#' + controlId).data("customController");
				arraydef.push(perfvalutazionepersonale_default_idreg_valCtrl.filteredPreFillCombo(filterListValutatori, null, true)
					.then(function (dt) {
						if (self.state.currentRow && self.state.currentRow[colName])
							return perfvalutazionepersonale_default_idreg_valCtrl.fillControl(null, self.state.currentRow[colName]);
						return true;
					})
				);
			},

			/**
			 * calcola i diritti delle schede di valutazione del personale
			 * @returns {Deferred(dtVal)}
			 * @constructor
			 */
			calcDiritti: function (filter) {
				var self = this;
				return appMeta.getData.runSelect("strutturaparentresponsabiliafferenzaview", "*", filter).
					then(function (dtVal) {
						self.responsabili = dtVal;
						//calcolo i diritti dell'utente loggato 
						var userRight = dtVal.select(self.q.eq('idreg', parseInt(self.sec.usr('idreg'))));
						if (userRight.length > 0) {
							self.approva = userRight.some(function (ur) {
								return ur.approva === 'S'
							});
							self.crea = userRight.some(function (ur) {
								return ur.crea === 'S'
							}) || self.state.isInsertState();
							self.aggiorna_ut = userRight.some(function (ur) {
								return ur.aggiorna === 'S' && ur.obiettivi_unatantum === 'S'
							});
							self.valuta_ut = userRight.some(function (ur) {
								return ur.valuta === 'S' && ur.obiettivi_unatantum === 'S'
							});
							self.aggiorna_ind = userRight.some(function (ur) {
								return ur.aggiorna === 'S' && ur.obiettivi_individuali === 'S'
							});
							self.valuta_ind = userRight.some(function (ur) {
								return ur.valuta === 'S' && ur.obiettivi_individuali === 'S'
							});
							self.aggiorna_co = userRight.some(function (ur) {
								return ur.aggiorna === 'S' && ur.obiettivi_comportamentali === 'S'
							});
							self.valuta_co = userRight.some(function (ur) {
								return ur.valuta === 'S' && ur.obiettivi_comportamentali === 'S'
							});
							self.leggi = userRight.some(function (ur) {
								return ur.leggi === 'S'
							});
							self.roles = _.map(userRight, function (r) { return r.idperfruolo });
						}
						else {
							self.crea = false;
							self.aggiorna_ind = false;
							self.valuta_ind = false;
							self.aggiorna_co = false;
							self.valuta_co = false;
							self.leggi = false;
						}

						return dtVal;

					});
			},

			/**
			 * calcola i diritti delle schede di valutazione delle unità organizzative
			 * @returns {Deferred(dtVal)}
			 * @constructor
			 */
			calcDirittiUO: function (filter) {
				var self = this;
				return appMeta.getData.runSelect("strutturaparentresponsabiliview", "*", filter).
					then(function (dtVal) {
						self.responsabili = dtVal;
						//calcolo i diritti dell'utente loggato
						var userRight = dtVal.select(self.q.eq('idreg', parseInt(self.sec.usr('idreg'))));
						if (userRight.length > 0) {
							self.crea = userRight.some(function (ur) {
								return ur.crea === 'S'
							});
							self.aggiorna_org = userRight.some(function (ur) {
								return ur.aggiorna === 'S' && ur.obiettivi_organizzativi === 'S'
							});
							self.valuta_org = userRight.some(function (ur) {
								return ur.valuta === 'S' && ur.obiettivi_organizzativi === 'S'
							});
							self.aggiorna_ut = userRight.some(function (ur) {
								return ur.aggiorna === 'S' && ur.obiettivi_unatantum === 'S'
							});
							self.valuta_ut = userRight.some(function (ur) {
								return ur.valuta === 'S' && ur.obiettivi_unatantum === 'S'
							});
							self.leggi = userRight.some(function (ur) {
								return ur.leggi === 'S'
							});
							self.roles = _.map(userRight, function (r) { return r.idperfruolo });
						}
						else {
							self.crea = false;
							self.aggiorna = false;
							self.valuta = false;
							self.leggi = false;
							self.obiettivi_organizzativi = false;
							self.obiettivi_unatantum = false;
						}

						return dtVal;

					});
			},

			/**
			 * calcola la media pesata dei completamenti rispetto al peso di una tabella e la assegna a una collonna della riga corrente e lancia il ricalcolo generale calculateRisultatoPerc
			 * @param {any} tableName
			 * Tabella con i completamenti e i pesi
			 * @param {any} columnName
			 * Nome della colonna della riga corrente in cui scrivere la media pesata
			 * @param {any} columnNameCompletamento
			 * Nome della colonna che contiene il completamento
			 * @param {any} columnNamePeso
			 * Nome della colonna che contiene il peso
			 */
			assignPercentuali: function (tableName, columnName, columnNameCompletamento, columnNamePeso) {

				if (!columnNameCompletamento)
					columnNameCompletamento = 'completamento';

				if (!columnNamePeso)
					columnNamePeso = 'peso';

				if (this.getDataTable(tableName).rows.length > 0) {
					var arrayIndicatori = _.map(this.getDataTable(tableName).rows, function (r) { return { valore: r[columnNameCompletamento], peso: r[columnNamePeso] } });
					var average = this.calculateWeightedAverage(arrayIndicatori);
					//if (average === this.state.currentRow[columnName]) {
					//	return;
					//}
					this.state.currentRow[columnName] = average;
					this.calculateRisultatoPerc();
				}
			},

			/**
			 * Invia la segnalazione di cambio di stato delle schede di valutazione personale
			 * @param {any} withMotivazioni 
			 * se presenti invia le motivazioni
			 * @param {any} description 
			 * label che descrive la scheda
			 * @returns
			 */
			sendMailChangeStatusValutazionePersonale: function (withMotivazioni, description, listType) {
				// è stato cliccato annulla o elimina non invio mail

				if (!this.state.currentRow) {
					return appMeta.Deferred("afterPost").resolve();
				}

				if (!this.state.currentRow.getRow) {
					return appMeta.Deferred("afterPost").resolve();
				}

				if (this.stateValue == this.state.currentRow.idperfschedastatus || !this.state.currentRow.idperfschedastatus) {
					return appMeta.Deferred("afterPost").resolve();
				}

				var self = this;

				var waitingHandler = self.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
				var destinatari = [];
				var filterRuolo;
				var filterDestinatario;
				var body;
				var ruoloDestinatario;
				var ruoloLoggato;
				var destinatario;
				var loggato;
				var valutato;
				var invio = false;
				var def = appMeta.Deferred("fireSendMail");
				var sendMail = '';



				//filtriamo tutti i ruoli dell'utente loggato perchè in base a chi cambia stato potremmo dover avvisare persone diverse
				filterRuolo = this.q.isIn('idperfruolo', this.roles);

				var filterStato = self.q.eq('idperfschedastatus', this.stateValue);
				if (!this.stateValue) {
					filterStato = self.q.isNull(self.state.currentRow.idperfschedastatus);
				}

				var filterStatoTo = self.q.eq('idperfschedastatus_to', self.state.currentRow.idperfschedastatus)
				var filterAll = self.q.and(filterStato, filterStatoTo, filterRuolo);

				appMeta.getData.runSelect("perfschedacambiostatoruolimailview", "*", filterAll)
					.then(function (dtCambiostato) {
						//self.stateValue = self.state.currentRow.idperfschedastatus; //lo faccio alla fine
						if (dtCambiostato.rows.length == 0) {
							self.hideWaitingIndicator(waitingHandler);
							return def.resolve();
						}

						//inseriamo tra i destinatari tutti i self.responsabili ... 
						_.forEach(self.responsabili.rows, function (responsabile) {
							//if (responsabile.escluso != 'S') {

							//...che hanno un ruolo tra quelli che devono ricevere la mail...(idperfruolo_mail)
							if (dtCambiostato.rows.some(function (ur) {
								return ur.idperfruolo_mail === responsabile.idperfruolo
							})) {
								destinatari.push([responsabile.idreg, responsabile.idperfruolo]);
							}
							// ...ricavando anche il ruolo dell'utente loggato ...
							//...se l'idreg corrisponde all'utente loggato e il ruolo è tra quelli che permette lo stato (idperfruolo)
							if (responsabile.idreg == self.sec.usrEnv.idreg && dtCambiostato.rows.some(function (ur) {
								return ur.idperfruolo === responsabile.idperfruolo
							})) {
								ruoloLoggato = responsabile.idperfruolo;
							}

						});

						if (dtCambiostato.rows.length > 0) {

							self.hideWaitingIndicator(waitingHandler);
							waitingHandler = self.showWaitingIndicator('Invio mail');
							invio = true;
						}


						//se tra i ruoli restituiti in dtCambiostato c'è "Valutato", allora invio mail anche al valutato
						if (dtCambiostato.rows.some(function (ur) {
							return ur.idperfruolo_mail === 'Valutato'
						})) {

							destinatari.push([self.state.currentRow.idreg, "Valutato"]);
						}

						self.superClass.getRegistryreference(self.state.currentRow.idreg)
							.then(function (dsValutato) {

								_.forEach(dsValutato, function (item) {
									if (item.referencename) {
										valutato = item.referencename;
									}
									else if (item.email) {
										valutato = item.email;
									}
									if (valutato)
										return;
								})

								//NB: se il valutato non ha l'email non invio mail, non ho i suoi dati da inserire nella mail
								//da verificare i controlli da fare
								if (valutato == undefined) {

									self.hideWaitingIndicator(waitingHandler);
									// da verificare i controllare 
									self.showMessageOk('I dati di contatto del valutato non sono presenti, la mail di notifica del cambio stato della scheda non è stata inviata');
									return def.resolve();
								}

								self.superClass.getRegistryreference(self.sec.usrEnv.idreg)
									.then(function (dsLoggato) {

										if (dsLoggato[0].referencename) {
											loggato = dsLoggato[0].referencename;
										}
										else if (destinatario[0].email) {
											loggato = dsLoggato[0].email;
										}
										var filterStato = self.q.eq('idperfschedastatus', self.state.currentRow.idperfschedastatus);

										appMeta.getData.runSelect("perfschedastatus", "*", filterStato)
											.then(function (dsStato) {

												var chain = $.when();
												var arrayDef = [];

												_.forEach(destinatari, function (destinatario) {
													chain = chain.then(function () {


														return self.superClass.getRegistryreference(destinatario[0])
															.then(function (dsRows) {

																if (!dsRows.length)
																	return true;

																if (dsRows[0].email == undefined || sendMail.includes(dsRows[0].email))
																	return;

																if (dsRows[0].referencename) {
																	recapito = dsRows[0].referencename;
																}
																else if (dsRows[0].email) {
																	recapito = dsRows[0].email;
																}

																subject = "Modifica stato " + description + (self.state.currentRow.year ? ' ' + self.state.currentRow.year + ' ' : '');

																body = "Buongiorno,";// "Gentile " + recapito;

																if (destinatario[0] != self.state.currentRow.idreg) {

																	body += ", <br> l'/il " + ruoloLoggato + " " + loggato + " ha modificato lo stato " + description + " di " + valutato + ", in  \"" + dsStato.rows[0].title + "\"<br />";
																	subject += " di " + valutato;
																}
																else body += ", lo stato " + description + " è stato modificato in \"" + dsStato.rows[0].title + "\"<br />";

																if (withMotivazioni == true && (self.valuta_ind == true || self.valuta_co == true)) {
																	body += "<br />Motivazioni della Valutazione:<br />" + $('#perfvalutazionepersonale_' + listType + '_motivazione').val() + "<br />";
																}
																body += "<br /><a href=\"" + document.URL.split('?')[0] + "\">Vai al portale<\a>";

																sendMail += dsRows[0].email + ";";
																return self.superClass.sendMail({ emailDest: dsRows[0].email, body: body, subject: subject, viewMessage: false })

															});
													});
													arrayDef.push(chain);
												});

												$.when.apply($, arrayDef)
													.then(function (msg) {

														self.hideWaitingIndicator(waitingHandler);

														if (!msg && invio) {

															msg = 'Invio mail avvenuto con successo';
														}

														if (msg) {
															// return def.from(self.showMessageOk(msg));

															return self.showMessageOk(msg).then(function () {
																def.resolve();
															});
														}

														def.resolve();

													});
											});
									});
							});
					})
					.then(function () {

						//setto lo stato attuale per non ripetere l'invio delle mail
						self.stateValue = self.state.currentRow.idperfschedastatus;

						//se nel dataset c'è la tabella dei cambi di stato ...
						let changesTableName = "perfvalutazionepersonalestatuschanges";
						if (self.state.DS.tables[changesTableName]) {
							//... inserisco l'attuale stato nello storico
							var meta = appMeta.getMeta([changesTableName]);
							var dataSetTable = self.state.DS.tables[changesTableName];
							meta.setDefaults(dataSetTable);

							meta.getNewRow(self.state.currentRow.getRow(), dataSetTable)
								.then(function (row) {
									//if (!row) {
									//	return def.resolve();
									//}
									row.current.idperfschedastatus = self.state.currentRow.idperfschedastatus;
									row.current.changedate = new Date();
									row.current.changeuser = self.sec.usr('userweb');
									//row.current.idperfvalutazionepersonale = self.state.currentRow.idperfvalutazionepersonale;

									return true;

								})
								.then(function (row) {
									return self.cmdMainSave();
								});
						}
						else {
							return true;
						}
					});

				return def.promise();

			},

			/**
			 * Invia la segnalazione di cambio di stato delle schede di valutazione delle unità organizzative
			 * @param {any} withMotivazioni 
			 * se presenti invia le motivazioni
			 * @param {any} description 
			 * label che descrive la scheda
			 * @returns
			 */
			sendMailChangeStatusValutazioneUO: function (withMotivazioni, tableToRefresh, description) {
				// verifica che il metodo getRow sia attaccato alla riga. Se non lo è significa che la riga è deleted.
				if (!this.state.currentRow.getRow) {
					return appMeta.Deferred("afterPost").resolve();
				}

				if (this.stateValue == this.state.currentRow.idperfschedastatus || !this.state.currentRow.idperfschedastatus)
					return appMeta.Deferred("afterPost").resolve();

				var self = this;
				var destinatari = [];
				var destinatariDbRow = [];
				var invio = false;
				var exit = false;
				var ruoloLoggato;
				var titleStruttura;
				var def = appMeta.Deferred("afterPost");
				var parentRow = self.state.currentRow;
				var waitingHandler = self.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);

				var filter = this.q.and([this.q.eq("idperfvalutazioneuo", parentRow.idperfvalutazioneuo), this.q.eq("idstruttura", parentRow.idstruttura)]);
				var selBuilderArray = [];

				_.forEach(tableToRefresh, function (tname) {
					selBuilderArray.push({ filter: filter, top: null, tableName: tname, table: self.state.DS.tables[tname] });
				});

				// --> CHIAMATA a store procedure realizzata in maniera asincrona.
				/*appMeta.getData.launchCustomServerMethodAsync("callSP", {
					spname: "menuweb_addentry",
					prm1: this.state.currentRow.idmenuwebparent,
					prm2: this.state.currentRow.idmenuweb,
					prm3: this.state.currentRow.tableName,
					prm4: this.state.currentRow.editType,
					prm5: this.state.currentRow.label
				});*/

				appMeta.getData.multiRunSelect(selBuilderArray)
					.then(function () {
						return self.freshForm(false, false)
					})
					.then(function () {

						// è stato cliccato annulla o elimina non invio mail
						if (!self.state.currentRow.getRow) {
							exit = true;
							return;
						}

						//lo stato è rimasto lo stesso, o non viene inizialmente inserito non invio mail
						if (self.stateValue == self.state.currentRow.idperfschedastatus || !self.state.currentRow.idperfschedastatus) {
							exit = true;
							return;
						}

						if (exit) {
							return;
						}

						//vecchio stato scheda
						var filterStato = self.q.eq('idperfschedastatus', self.stateValue);
						//se è il primo stato che viene salvato alla scheda setto lo stato attuale come quello di partenza
						if (!self.stateValue) {
							filterStato = self.q.isNull(self.state.currentRow.idperfschedastatus);
						}

						//nuovo stato scheda
						var filterStatoTo = self.q.eq('idperfschedastatus_to', self.state.currentRow.idperfschedastatus);

						var filterRuolo = self.q.isIn('idperfruolo', self.roles);
						var filterAll = self.q.and(filterStato, filterStatoTo, filterRuolo);

						//recupero i cambi stato/ruoli a cui devo inviare la mail
						return appMeta.getData.runSelect("perfschedacambiostatoruolimailview", "*", filterAll)
					})
					.then(function (dtCambiostato) {
						if (exit) {
							return;
						}
						self.stateValue = self.state.currentRow.idperfschedastatus;


						if (dtCambiostato.rows.length == 0) {
							self.hideWaitingIndicator(waitingHandler);
							exit = true;
							return;
						}

						//inseriamo tra i destinatari tutti i self.responsabili, solo se vanno avvisati ... 

						_.forEach(self.responsabili.rows, function (responsabile) {

							//agli amministatori non invio la mail
							//if (responsabile.escluso != 'S') {

							//se è già stato aggiunto non lo rimetto tra i destinatari
							if (!destinatari.some(function (ur) {
								return ur[0] == responsabile.idreg;
							})) {

								//lo aggiungo solo se il suo ruolo è tra quelli che vanno avvisati per email (idperfruolo_mail)
								if (dtCambiostato.rows.some(function (ur) {
									return ur.idperfruolo_mail === responsabile.idperfruolo
								})) {
									destinatari.push([responsabile.idreg, responsabile.idperfruolo]);
								}
							}
							//}
							//... ricavando anche il ruolo dell'utente loggato (che consente il cambio) (idperfruolo)
							if (responsabile.idreg == self.sec.usrEnv.idreg && dtCambiostato.rows.some(function (ur) {
								return ur.idperfruolo === responsabile.idperfruolo
							})) {
								ruoloLoggato = responsabile.idperfruolo;
								titleStruttura = responsabile.title;
							}

						});

						//se non ci sono destinatari esco
						if (destinatari.length == 0) {
							self.hideWaitingIndicator(waitingHandler);
							exit = true;
							return;
						}

						if (dtCambiostato.rows.length > 0) {

							self.hideWaitingIndicator(waitingHandler);
							waitingHandler = self.showWaitingIndicator('Invio mail');
							invio = true;
						}


						var arrayDest = [];
						_.map(destinatari, function (row) { return arrayDest.push(row[0]); });
						//Recupero i dati della persona a cui inviare la mail
						return self.superClass.getRegistryreference(arrayDest)
					})
					.then(function (dtRows) {
						if (exit) {
							return;
						}
						if (dtRows.length == 0) {
							self.hideWaitingIndicator(waitingHandler);
							exit = true;
							return self.showMessageOk("Non ci sono destinatari a cui inviare la notifica");
						}

						destinatariDbRow = dtRows;

						var filterStato = self.q.eq("idperfschedastatus", self.state.currentRow.idperfschedastatus);

						//recupero i cambi stato /ruoli a cui devo inviare la mail
						return appMeta.getData.runSelect("perfschedastatus", "*", filterStato)
					})
					.then(function (dtStato) {

						if (exit) {
							return;
						}

						var arrayDef = [];
						var body;
						if (!dtStato || dtStato.rows.length == 0) {
							self.hideWaitingIndicator(waitingHandler);
							exit = true;
							return self.showMessageOk("Lo stato selezionato non è riconosciuto");
						}

						var sended = [];
						//verificare le distinct
						_.forEach(destinatariDbRow, function (row) {
							if (row.email && sended.indexOf(row.email) == -1) {

								var subject = "Modifica stato della scheda valutazione dell'unità organizzativa " + titleStruttura + (self.state.currentRow.year ? ' ' + self.state.currentRow.year + ' ' : '');

								body = "Buongiorno,";//"Gentile " + row.referencename + ",<br />";
								body += "l'utente " + self.sec.usrEnv.surname + " " + self.sec.usrEnv.forename + " ha modificato lo stato della scheda in  \"" + dtStato.rows[0].title + "\".<br />";

								if (withMotivazioni == true && (self.valuta_org == true || self.valuta_ut == true)) {
									body += "<br />Motivazioni della Valutazione:<br /> " + $('#perfvalutazioneuo_upo_motivazione').val() + "<br />";
								}

								body += "<br /><a href=\"" + document.URL.replace("?tablename=perfvalutazioneuo&edittype=upo", "") + "\">Vai al portale<\a>";

								arrayDef.push(self.superClass.sendMail({ emailDest: row.email, body: body, subject: subject, viewMessage: false }));
								sended.push(row.email);
							}
						});

						return $.when.apply($, arrayDef);
					})
					.then(function () {
						self.hideWaitingIndicator(waitingHandler);
						if (exit) {
							return def.resolve();
						}
						if (invio) {
							return def.from(self.showMessageOk('Invio mail avvenuto con successo'));
						}
						return def.resolve();
					})
					.then(function () {

						//setto lo stato attuale per non ripetere l'invio delle mail
						self.stateValue = self.state.currentRow.idperfschedastatus;

						//se nel dataset c'è la tabella dei cambi di stato ...
						let changesTableName = "perfvalutazioneuostatuschanges";
						if (self.state.DS.tables[changesTableName]) {
							//... inserisco l'attuale stato nello storico
							var meta = appMeta.getMeta([changesTableName]);
							var dataSetTable = self.state.DS.tables[changesTableName];
							meta.setDefaults(dataSetTable);

							meta.getNewRow(self.state.currentRow.getRow(), dataSetTable)
								.then(function (row) {
									//if (!row) {
									//	return def.resolve();
									//}
									row.current.idperfschedastatus = self.state.currentRow.idperfschedastatus;
									row.current.changedate = new Date();
									row.current.changeuser = self.sec.usr('userweb');
									//row.current.idperfvalutazioneuo = self.state.currentRow.idperfvalutazioneuo;

									return true;

								})
								.then(function (row) {
									return self.cmdMainSave();
								});
						}
						else {
							return true;
						}
					});


				return def.promise();
			},

			/****************************************************************************************************
			 ****************  FUNZIONI PER TIMESHEET E ATTIVITA' E ORE RENDICONTATE: ***************************
			 ****************************************************************************************************/

			buildRendicontattivitaprogettooraTitle: function () {
				var def = Deferred('buildRendicontattivitaprogettooraTitle');
				var self = this;
				var p = [];
				if (self.getDataTable("rendicontattivitaprogettoora").rows.length) {
					appMeta.getData.runSelect('progetto', 'title', self.q.eq('idprogetto', self.state.currentRow.idprogetto), null)
						.then(function (dt) {
							if (dt.rows.length) {
								p.push([dt.rows[0].title, null, 'Progetto']);
								return appMeta.getData.runSelect('workpackage', 'title', self.q.eq('idworkpackage', self.state.currentRow.idworkpackage), null);
							}
							else
								return true;
						}).then(function (dt) {
							if (dt.rows.length) {
								p.push([dt.rows[0].title, null, 'Workpackage']);
								p.push([self.state.currentRow.description, null, 'Attività']);
								_.forEach(self.getDataTable("rendicontattivitaprogettoora").rows, function (r) {
									//tolgo le ore in testa all'array
									var pcurr = p.slice();
									//ci metto le sue
									pcurr.unshift([r.ore, null, 'Ore']);
									r['!titleancestor'] = self.stringify(pcurr, 'string');
								});
							}
							return def.resolve();
						});
				} else
					return def.resolve();
			},

			buildAndGetTimesheet: function (opts) {
				var waitingHandler = this.showWaitingIndicator("Attendi generazione timesheet");
				var self = this;
				appMeta.Timesheet.buildAndGetTimesheet(Object.assign(opts, { state: this.state }))
					.then(function () {
						self.hideWaitingIndicator(waitingHandler);
					})
					.fail(function (message) {
						message = message || "Non è possibile generare il timeshhet";
						alert(message);
						self.hideWaitingIndicator(waitingHandler);
					});
			},

			getExternalEventForCalendar: function (filter, calendarCtrl) {
				var def = Deferred('getExternalEventForCalendar');
				var filterComplete = this.q.or(filter, this.q.eq('idreg', this.idreg_istituto));
				return appMeta.getData.runSelect("getcalendareventview",
					"color, title, start, stop, ore, idlezione, idassetdiary, idrendicontattivitaprogetto", filterComplete, null)
					.then(function (dt) {
						var calendar = calendarCtrl.data("customController");
						calendar.addExternalEvents([{
							dt: dt, config: {
								startColumnName: 'start',
								stopColumnName: 'stop',
								titleColumnName: 'title',
								color: 'color'
							}
						}]);
						def.resolve();
					});
			},

			/**
			 * da utilizzare per stabilire i limiti temporali per una attività di ricerca in base a progetto,wp,proroghe,membro
			 * @param {any} wpStart
			 * @param {any} wpStop
			 * @param {any} membroStart
			 * @param {any} membroStop
			 * @param {any} prorogaRow
			 */
			setRealStartStop: function (wpStart, wpStop, membroStart, membroStop, prorogaRow) {

				//va verificata la più grande tra il membro e il wp 
				if (wpStart && ((membroStart && wpStart > membroStart) || (!membroStart))) {
					this.start = wpStart;
					this.startMessage = 'a quella dell\'inizio del workpackage (' + this.stringFromDate_ddmmyyyy(wpStart) + ')';
				} else {
					if (membroStart) {
						this.start = membroStart;
						this.startMessage = 'all\'inizio della partecipazione del membro (' + this.stringFromDate_ddmmyyyy(membroStart) + ')';
					}
				}

				//se c'è una proroga allora la data di fine è della proroga
				if (prorogaRow) {
					this.stop = prorogaRow.proroga;
					this.stopMessage = 'a quella della proroga (' + this.stringFromDate_ddmmyyyy(prorogaRow.proroga) + ')';
				}
				else {
					//altrimenti è la più piccola tra il membro e il wp
					if ((wpStop && membroStop && wpStop < membroStop) || (wpStop && !membroStop)) {
						this.stop = wpStop;
						this.stopMessage = 'a quella finale del workpackage (' + this.stringFromDate_ddmmyyyy(wpStop) + ')';
					} else {
						if (membroStop) {
							this.stop = membroStop;
							this.stopMessage = 'alla fine della partecipazione del membro (' + this.stringFromDate_ddmmyyyy(membroStop) + ')';
						}
					}
				}
			},

			/**
			 * da utilizzare per avere la data fine per schedulare le attività di ricerca
			 */
			getRealStopForSchedulingResearchActivity: function () {
				let dataTag = this.primaryTableName + '_' + this.editType + '_stop';
				//prevale quanto inserito sul controllo su quello che sta sul dataset
				let datafine = this.getDateTimeFromString($('#' + dataTag).val());
				if (!datafine)
					datafine = this.state.currentRow.stop;
				//se c'è una proroga che vince su tutto allora la data di fine è della proroga
				if (this.lastProroga)
					datafine = this.lastProroga.proroga;
				return datafine;
			},

			/**
			 * da utilizzare per avere la data inizio per schedulare le attività di ricerca
			 */
			getRealStartForSchedulingResearchActivity: function () {
				let dataTag = this.primaryTableName + '_' + this.editType + '_datainizioprevista';
				//prevale quanto inserito sul controllo su quello che sta sul dataset
				let dataInizio = this.getDateTimeFromString($('#' + dataTag).val());
				if (!dataInizio)
					dataInizio = this.state.currentRow.datainizioprevista;
				return dataInizio;
			},

			/** 
			 * imposta e filtra la chekboxlist delle missioni nella maschera delle attività
			 */
			setFilterRendicontattivitaprogettoItineration: function () {
				var self = this;
				var filtermembro = self.q.eq('idreg', self.state.currentRow ? self.state.currentRow.idreg : 0);
				var filterstart = self.q.lt('start', self.state.currentRow ? (self.state.currentRow.stop ? self.state.currentRow.stop : new Date()) : new Date());
				var filterstop = self.q.gt('stop', self.state.currentRow ? (self.state.currentRow.datainizioprevista ? self.state.currentRow.datainizioprevista : new Date()) : new Date());
				var filter = self.q.and([filtermembro, filterstart, filterstop]);
				this.state.DS.tables.itineration.staticFilter(filter);
				this.getDataTable('itineration').clear();
				var checkListCtrl = $("[data-tag='itineration.seg.seg']");
				var ctrl = checkListCtrl.data("customController");
				if (ctrl) {
					return ctrl.loadCheckBoxList();
				} else
					return true;
			},

			/**
			 * recupera le proroghe a partire da una attività
			 * @returns
			 */
			getProroghe: function () {
				//se mancano le pagine antenate che contengono le proroghe devo recuperarle da db
				var self = this;
				var def = appMeta.Deferred("getProroghe-rendicontattivitaprogettoora_seg");
				appMeta.getData.runSelect("progettoproroga", "proroga", this.q.eq("idprogetto", this.state.currentRow.idprogetto))
					.then(function (dt) {
						self.lastProroga = dt.rows.length ?
							_.orderBy(dt.rows, 'proroga', 'desc')[0] : null;
						return def.resolve();
					});
				return def.promise();
			},

			/**
			 * recupera il membro del progetto a partire da una attività
			 * @returns
			 */
			getMembro: function () {
				//se mancano le pagine antenate che contengono i membri devo recuperarle da db 
				var self = this;
				var def = appMeta.Deferred("getMembro-rendicontattivitaprogettoora_seg");

				appMeta.getData.runSelect("progettoudrmembro", "start,stop",
					self.q.and(self.q.eq("idprogetto", self.state.currentRow.idprogetto), self.q.eq("idreg", self.state.currentRow.idreg)))
					.then(function (dtMembro) {
						self.Membro = dtMembro.rows.length ?
							_.orderBy(dtMembro.rows, 'stop', 'desc')[0] : null;
						return def.resolve();
					});
				return def.promise();
			},

			/**
			 * metodo che, in presenza di una tabella rendicontattivitaprogettoora nel dataset di pagina, 
			 * se gli elementi vengono aggiunti programmaticamente, 
			 * consente il popolamento delle tabelle con le foreignkey
			 * @param {any} page
			 * @param {any} tableNameProgetto
			 * @returns
			 */
			refreshForeignKeyRendicontattivitaprogettoora: function (page, tableNameProgetto) {
				//ricarico tutte le foreign key
				var selBuilderArrayFK = [];
				//ricavo tutte le foreignkey verso la tabella progetto che sono in rendicontattivitaprogettoora
				var progettoIds = _.filter(page.getDataTable('rendicontattivitaprogettoora').rows, function (r) { return !!r.idprogetto });
				//se anche solo uno non c'è sulla tabella progetto allora faccio la query
				if (!progettoIds.some(function (id) {
					return _.map(page.getDataTable('progetto').rows, function (r) {
						return r.idprogetto;
					}).includes(id);
				})) {
					page.filterProgettoIds = page.q.isIn('idprogetto',
						_.map(progettoIds, function (r) {
							return r.idprogetto;
						}));

					selBuilderArrayFK.push({ filter: page.filterProgettoIds, top: null, tableName: tableNameProgetto, table: page.getDataTable(tableNameProgetto) });
				}
				//ricavo tutte le foreignkey verso la tabella workpackage che sono in rendicontattivitaprogettoora
				var workpackageIds = _.filter(page.getDataTable('rendicontattivitaprogettoora').rows, function (r) { return !!r.idworkpackage });
				//se anche solo uno non c'è sulla tabella workpackage allora faccio la query
				if (!workpackageIds.some(function (id) {
					return _.map(page.getDataTable('workpackage').rows, function (r) {
						return r.idworkpackage;
					}).includes(id);
				})) {
					page.filterWorkpackageIds = page.q.isIn('idworkpackage',
						_.map(workpackageIds, function (r) {
							return r.idworkpackage;
						}));

					selBuilderArrayFK.push({ filter: page.filterWorkpackageIds, top: null, tableName: 'workpackage', table: page.getDataTable('workpackage') });
				}

				//ricavo tutte le foreignkey verso la tabella rendicontattivitaprogetto che sono in rendicontattivitaprogettoora
				var rendicontattivitaprogettoIds = _.filter(page.getDataTable('rendicontattivitaprogettoora').rows, function (r) { return !!r.idrendicontattivitaprogetto });
				//se anche solo uno non c'è sulla tabella rendicontattivitaprogetto allora faccio la query
				if (!rendicontattivitaprogettoIds.some(function (id) {
					return _.map(page.getDataTable('rendicontattivitaprogetto').rows, function (r) {
						return r.idrendicontattivitaprogetto;
					}).includes(id);
				})) {
					page.filterRendicontattivitaprogettoIds = page.q.isIn('idrendicontattivitaprogetto',
						_.map(rendicontattivitaprogettoIds, function (r) {
							return r.idrendicontattivitaprogetto;
						}));

					selBuilderArrayFK.push({ filter: page.filterRendicontattivitaprogettoIds, top: null, tableName: 'rendicontattivitaprogetto', table: page.getDataTable('rendicontattivitaprogetto') });
				}

				//ricavo tutte le foreignkey verso la tabella sal che sono in rendicontattivitaprogettoora
				var salIds = _.filter(page.getDataTable('rendicontattivitaprogettoora').rows, function (r) { return !!r.idsal });
				//se anche solo uno non c'è sulla tabella sal allora faccio la query
				if (!salIds.some(function (id) {
					return _.map(page.getDataTable('sal').rows, function (r) {
						return r.idsal;
					}).includes(id);
				})) {
					page.filtersalIds = page.q.isIn('idsal',
						_.map(salIds, function (r) {
							return r.idsal;
						}));

					selBuilderArrayFK.push({ filter: page.filtersalIds, top: null, tableName: 'sal', table: page.getDataTable('sal') });
				}

				//se c'è da fare una query la faccio se no no
				if (selBuilderArrayFK.length)
					return appMeta.getData.multiRunSelect(selBuilderArrayFK);
				else
					return true;
			},

			/*********************************************************************
			 ****************  FUNZIONI PER RISORSE UMANE: ***************************
			 *********************************************************************/

			//restituisce l'intersezione temporale con un range si riferimento e 
			//withUnabled = true => la singola riga di servizio
			//withUnabled = false => la singola riga di indisponibilità
			getDaysAndMonth: function (startRif, stopRif, servizioRows, withUnabled) {
				var self = this;
				var start = startRif;
				var stop = stopRif;
				//l'inizio del servizio (se assente il 1/1/1970) o dell'indisponibilità
				var startRow = servizioRows.start ?
					servizioRows.start :
					(withUnabled ?
						new Date(1970, 0, 1) :
						(servizioRows.aa_start ?
							new Date(servizioRows.aa_start.substring(0, 4), 10, 1) :
							null
						)
					);
				//la fine del servizio (se assente oggi) o dell'indisponibilità (se non c'è nemmeno quella dell'indisponibilità in realtà è un servizio senza fine)
				var stopRow = servizioRows.stop ?
					servizioRows.stop :
					(withUnabled ? new Date() : (servizioRows.aa_stop ?
						new Date(servizioRows.aa_stop.substring(5, 9), 9, 31) : new Date())
					);
				//deve essere iniziato prima o durante e finito durante o dopo delle date di riferimento
				if (startRow <= stop && stopRow >= start) {
					//se finisce prima mi fermo prima della data di riferimento
					if (stopRow < stop) {
						stop = stopRow;
					}
					//se inizia dopo parto alla data di riferimento
					if (startRow > start) {
						start = startRow;
					}

					//calcolo i mesi e i giorni di differenza:
					var output = this.getDaysAndMonthByDates(start, stop);
					//se voglio sottrarre la non validità
					if (withUnabled) {
						var nvgg = 0;
						var nvmm = 0;
						var nvaa = 0;

						//tolgo tutti i giorni di intersezione tra il periodo ottenuto e i periodi di non validità
						_.forEach(self.getDataTable('ricostruzioneperiodonv').rows, function (nvRows) {
							var nv = self.getDaysAndMonth(start, stop, nvRows, false);
							nvgg += nv.gg;
							nvmm += nv.mm;
							nvaa += nv.aa;
						});

						//togliamo sempre a tutti un periodo di non validità con start = 1/1/2012 e stop = 31/12/2014
						//perchè in quei tre anni non valgono i servizi
						var nv = self.getDaysAndMonth(start, stop, { start: new Date(2012, 0, 1), stop: new Date(2014, 11, 31) }, false);
						nvgg += nv.gg;
						nvmm += nv.mm;
						nvaa += nv.aa;

						//tolgo tutti i giorni di intersezione tra il periodo ottenuto e gli anni accademici per i quali non ha totalizzato i 180 gg
						_.forEach(self.getDataTable('ricostruzionenonvaliditaview').rows, function (nvRows) {
							var nv = self.getDaysAndMonth(start, stop, nvRows, false);
							nvgg += nv.gg;
							nvmm += nv.mm;
							nvaa += nv.aa;
						});

						//alla fine levo tutti i meesi e giorni non valutabili
						output.gg -= nvgg;
						output.mm -= nvmm;
						output.aa -= nvaa;
						output = this.reevaluateDaysAndMonth(output);
					}

					return output;
				}
				return { gg: 0, mm: 0, aa: 0 };
			},

			getDaysAndMonthByDates: function (start, stop, stops) {
				if (start && stop && (
					start.getFullYear() != stop.getFullYear() || start.getMonth() != stop.getMonth() || start.getDate() != stop.getDate()
				)) {

					let anzianitaDiRitardo = { gg: 0, mm: 0, aa: 0 };
					if (stops) {
						//non è possibile fare un ciclo sui giorni perchè sfalza la conversione i aa,mm,gg, devo ragionare a intervalli:


						//1 - se il periodo è interamente o termina durante uno stop l'anzianità è quella già maturata
						let currStop = null;
						stops.forEach(function (stopWork) {
							if (stopWork.start < stop && stopWork.stop > stop)
								currStop = stopWork;
						});
						if (currStop) {
							return currStop.anzianita;
						} else { 
							//2 - se il periodo è a cavallo tra uno stop e un periodo lavorato vado per differenza con l'ultimo stop
							//ricavo l'ultimo stop
							let lastStop = null;
							stops.forEach(function (stopWork) {
								if (stopWork.stop < stop && stopWork.stop >start && stopWork.start < start)
									lastStop = stopWork;
							});
							if (lastStop) {
								//ricavo la differenza di anzianità
								let diff = this.getDaysAndMonthByDates(lastStop.stop, stop);
								//sommo la differenza di anzianità a quella dello stop
								return { gg: lastStop.anzianita.gg + diff.gg, mm: lastStop.anzianita.mm + diff.mm, aa: lastStop.anzianita.aa + diff.aa };
							} else {
								//calcolo l'anzianità a prescindere per tutto il periodo
								let output = this.getDaysAndMonthByDates(start, stop);
								let self = this;
								//3 - controllo che non ci siano stops all'interno del periodo e quindi anzianità da sottrarre
								stops.forEach(function (stopWork) {
									if (stopWork.start > start && stopWork.stop < stop) {
										let anzianitaDaTogliere = self.getDaysAndMonthByDates(stopWork.start, stopWork.stop);
										output = self.anzianitaDiff(output, anzianitaDaTogliere);
									}
								});

								return output;
							}
						}
					}

					//se le date sono in anni o mesi diversi
					if (start.getFullYear() != stop.getFullYear() || start.getMonth() != stop.getMonth()) {

						//se la data è la stessa ma di anni diversi

						if (start.getFullYear() != stop.getFullYear() && start.getMonth() == stop.getMonth() && start.getDate() == stop.getDate()) {
							return { gg: 0 - anzianitaDiRitardo.gg, mm: ((stop.getFullYear() - start.getFullYear()) * 12) - anzianitaDiRitardo.mm, aa: - anzianitaDiRitardo.aa };
						}

						var dateDiffMonth = 0;
						var daysUntilEndOfMonth = 0;

						//se inizia il primo del mese vale tutto il mese
						if (start.getDate() == 1) {
							dateDiffMonth += 1;
						} else {
							//altrimenti prendo i gg dalla data di inizio alla fine del suo mese
							var lastDayOfMonth = new Date(start.getFullYear(), start.getMonth() + 1, 0).getDate();
							daysUntilEndOfMonth = lastDayOfMonth - start.getDate() + 1; //il giorno di start va compreso
						}

						var dateDiffDays = daysUntilEndOfMonth;
						//se finisco l'ultimo giorno del mese vale tutto il mese
						if (stop.getDate() == new Date(stop.getFullYear(), stop.getMonth() + 1, 0).getDate()) {
							dateDiffMonth += 1;
						} else {
							//altrimenti aggiungo i giorni dall'inizio dell'ultimo mese alla data di fine
							dateDiffDays += stop.getDate();
						}
						//aggiungo tutti i mesi, gli anni li calcolo dopo
						dateDiffMonth += this.getMonthDiff(start, stop)

						return { gg: dateDiffDays - anzianitaDiRitardo.gg, mm: dateDiffMonth - anzianitaDiRitardo.mm, aa: - anzianitaDiRitardo.aa };
					}
					else {
						return { gg: stop.getDate() - start.getDate() + 1 - anzianitaDiRitardo.gg, mm: 0 - anzianitaDiRitardo.mm, aa: - anzianitaDiRitardo.aa };
					}
				}
				return { gg: 0, mm: 0, aa:0 };
			},

			/**
			 * funzione che a partire dai servizi li deduplica e restituisce gli anni accademici con + di 180 giorni
			 * @param {any} servizioTables
			 * @param {any} withUnabled
			 */
			getYearDiffServices: function (servizioTables) {
				var self = this;

				//var annoAccademico = { annoAccademico: '', giorni: 0, servizioRows: [], scrutinio = false, start: null, maxStart: };
				var anniAccademici = [];

				_.forEach(servizioTables, function (servizioTable) {
					_.forEach(_.sortBy(self.getDataTable(servizioTable).rows, function (r) { return r.start; }), function (servizioRow) {
						if (servizioRow.start) {
							var start = servizioRow.start;
							var stop = (servizioRow.stop ? servizioRow.stop : new Date());
							//per ogni anno accademico coinvolto dal servizio
							var anniCoinvolti = self.getAcademicYears(start, stop, servizioRow.annokind);
							_.forEach(anniCoinvolti, function (annoCoinvolto) {
								//vedo se l'aa è già lavorato in parte
								var anno = _.find(anniAccademici, function (a) { return a.annoAccademico == annoCoinvolto; });

								//sego il segmento di servizio che ricade nell'anno accademico
								var begin = servizioRow.annokind == 'S' ? new Date(parseInt(annoCoinvolto.substring(0, 4)), 8, 1) : new Date(parseInt(annoCoinvolto.substring(0, 4)), 10, 1);
								var realStart = begin;
								var end = servizioRow.annokind == 'S' ? new Date(parseInt(annoCoinvolto.substring(5, 9)), 7, 31) : new Date(parseInt(annoCoinvolto.substring(5, 9)), 9, 31);
								var realStop = end;
								if (start > begin)
									realStart = start;
								if (stop < end)
									realStop = stop;

								if (!anno) {
									//se non c'è ancora l'anno lo aggiungo con i suoi dati e quelli della riga del servizio corrente e passo al servizio successivo
									anno = {
										annoAccademico: annoCoinvolto,
										giorni: Math.ceil(Math.abs(realStop - realStart) / (1000 * 60 * 60 * 24)) + 1,
										servizioRows: [],
										servizi: [],
										anninonvalidi: [],
										scrutinio: servizioRow.cedolini,
										start: servizioRow.start,
										maxStart: new Date(parseInt(annoCoinvolto.substring(5, 9)), 1, 1),
										begin: begin,
										end: end
									};

									anno.servizioRows.push(servizioRow);
									anno.servizi.push({
										inizio: self.stringFromDate_ddmmyyyy(servizioRow.start),
										fine: self.stringFromDate_ddmmyyyy(servizioRow.stop),
										anni: servizioRow.anni,
										mesi: servizioRow.mesi,
										giorni: servizioRow.giorni,
										istituzione: servizioRow.istituzione
									});
									anniAccademici.push(anno);
								}
								else {
									//cancella i giorni in conflitto con quelli già caricati per l'anno
									var slots = [{ start: realStart, stop: realStop }];
									_.forEach(slots, function (slot) {
										_.forEach(anno.servizioRows, function (annoServizioRow) {
											//se c'è confitto
											if (annoServizioRow.start <= slot.stop && annoServizioRow.stop >= slot.start) {

												//Se il annoServizioRow copre tutto servizioRow azzero e esco
												if (annoServizioRow.start <= slot.start && annoServizioRow.stop >= slot.stop) {
													//rimuovo lo slot
													slots = slots.filter(function (slotInSlots) {
														return slotInSlots.start != slot.start && slotInSlots.stop != slot.stop;
													});
												} else {

													//se cade in mezzo spezzo lo slot in due
													if (annoServizioRow.start > slot.start && annoServizioRow.stop < slot.stop) {
														slots = slots.filter(function (slotInSlots) {
															return slotInSlots.start != slot.start && slotInSlots.stop != slot.stop;
														});

														if (!slots.some(function (slotInSlots) {
															return slotInSlots.start == slot.start && slotInSlots.stop == annoServizioRow.start;
														}))
															slots.push({ start: slot.start, stop: annoServizioRow.start })
														if (!slots.some(function (slotInSlots) {
															return slotInSlots.start == annoServizioRow.stop && slotInSlots.stop == slot.stop;
														}))
															slots.push({ start: annoServizioRow.stop, stop: slot.stop })
													} else {

														//se annoServizioRow inizia dopo ...
														if (annoServizioRow.start > slot.start) {
															//... riduco la fine dello lo slot 
															slot.stop = annoServizioRow.start;
														}

														//se annoServizioRow finisce prima ...
														if (annoServizioRow.stop < slot.stop) {
															//... posticipo l'inizio dello slot
															slot.start = annoServizioRow.stop;
														}
													}
												}
											}
										});
									});

									//aggiunge ai servizi valutati per l'anno il servizio vautato adesso 
									anno.servizioRows.push(servizioRow);
									anno.servizi.push({
										inizio: self.stringFromDate_ddmmyyyy(servizioRow.start),
										fine: self.stringFromDate_ddmmyyyy(servizioRow.stop),
										anni: servizioRow.anni,
										mesi: servizioRow.mesi,
										giorni: servizioRow.giorni,
										istituzione: servizioRow.istituzione
									});

									//aggiunge al contatore il proprio apporto ai giorni
									_.forEach(slots, function (slot) {
										anno.giorni += Math.ceil(Math.abs(slot.stop - slot.start) / (1000 * 60 * 60 * 24)) + 1;
									});

									//se ha lo scrutinio mette scrutinio a true
									if (servizioRow.cedolini == 'S')
										anno.scrutinio = true;

									//se la data start è precedente allo start attuale lo aggiorna
									if (anno.start > servizioRow.start)
										anno.start = servizioRow.start;
								}
							});
						}
					});
				});

				var validYears = 0;
				//per ogni anno accademico con più di 180 giorni oppure meno ma ha scrutinio e start < 1/Febbraio incremento il contatore degli anni
				_.forEach(anniAccademici, function (annoAccademico) {


					var invalidYear = false;

					//tolgo tutti i giorni di intersezione tra il periodo ottenuto e i periodi di non validità
					_.forEach(self.getDataTable('ricostruzioneperiodonv').rows, function (nvRows) {
						if (nvRows.aa_start <= annoAccademico.annoAccademico && nvRows.aa_stop >= annoAccademico.annoAccademico) {
							invalidYear = true;
							annoAccademico.anninonvalidi.push({ Anno_accademico_inizio: nvRows.aa_start, Anno_accademico_fine: nvRows.aa_stop })
						}
					});

					//togliamo sempre a tutti un periodo di non validità con start = 1/1/2012 e stop = 31/12/2014
					//perchè in quei tre anni non valgono i servizi
					var isTriennioNonValido = false;
					if (
						annoAccademico.annoAccademico == '2011/2012' ||
						annoAccademico.annoAccademico == '2012/2013' ||
						annoAccademico.annoAccademico == '2013/2014' ||
						annoAccademico.annoAccademico == '2014/2015'
					) {
						isTriennioNonValido = true;
						var start = annoAccademico.begin;
						var stop = annoAccademico.end;

						if (annoAccademico.annoAccademico == '2011/2012')
							start = new Date(2012, 0, 1);
						if (annoAccademico.annoAccademico == '2014/2015')
							stop = new Date(2014, 11, 31);

						var nvgg = 0;
						var nvmm = 0;
						var nvaa = 0;

						_.forEach(annoAccademico.servizioRows, function (servizioRow) {
							var nv = self.getDaysAndMonth(servizioRow.start, servizioRow.stop, { start: start, stop: stop }, false);
							nvgg += nv.gg;
							nvmm += nv.mm;
							nvaa += nv.aa;
						});

						annoAccademico.giorni -= nvgg + (nvmm * 30);

						if (!(annoAccademico.giorni > 180 || (annoAccademico.scrutinio == true && annoAccademico.start < annoAccademico.maxStart)))
							annoAccademico.anninonvalidi.push({ Anno_accademico_inizio: annoAccademico.annoAccademico, Anno_accademico_fine: annoAccademico.annoAccademico });

					}


					if ((annoAccademico.giorni > 180 || (annoAccademico.scrutinio == true && annoAccademico.start < annoAccademico.maxStart))
						&& !invalidYear) {
						validYears++;
					} else {
						if (!isTriennioNonValido)
							annoAccademico.anninonvalidi.push({ Anno_accademico_inizio: annoAccademico.annoAccademico, Anno_accademico_fine: annoAccademico.annoAccademico });
					}
				});

				return { gg: 0, mm: 0, aa: validYears, years: anniAccademici };
			},

			/**
			 * restituisce l'anno accademico della data
			 * @param {any} data
			 * @param {any} annokind
			 */
			getAcademicYear: function (data, annokind) {

				var startYear = 0;
				if (data < (annokind == 'S' ? new Date(data.getFullYear(), 8, 1) : new Date(data.getFullYear(), 10, 1)))
					startYear = data.getFullYear() - 1;
				else
					startYear = data.getFullYear();

				var stopYear = 0;
				if (data < (annokind == 'S' ? new Date(data.getFullYear(), 8, 1) : new Date(data.getFullYear(), 10, 1)))
					stopYear = data.getFullYear();
				else
					stopYear = data.getFullYear() + 1;

				return startYear.toString() + '/' + stopYear.toString();
			},


			/**
			 * restituisce tutti gli anni accademici che si intersecano con un periodo da start a stop
			 * @param {any} start
			 * @param {any} stop
			 */
			getAcademicYears: function (start, stop, annokind) {
				var output = [];

				var startYear = 0;
				if (start < (annokind == 'S' ? new Date(start.getFullYear(), 8, 1) : new Date(start.getFullYear(), 10, 1)))
					startYear = start.getFullYear() - 1;
				else
					startYear = start.getFullYear();

				var stopYear = 0;
				if (stop < (annokind == 'S' ? new Date(stop.getFullYear(), 8, 1) : new Date(stop.getFullYear(), 10, 1)))
					stopYear = stop.getFullYear();
				else
					stopYear = stop.getFullYear() + 1;

				for (var i = startYear; i < stopYear; i++) {
					output.push(i.toString() + '/' + (i + 1).toString());
				}
				return output;
			},

			/**
			 * restituisce tutti gli anni che si intersecano con un periodo da start a stop
			 * @param {any} start
			 * @param {any} stop
			 */
			getYears: function (start, stop) {
				var output = [];

				if (!stop)
					stop = new Date();

				for (var i = start.getFullYear(); i <= stop.getFullYear(); i++) {
					output.push(i.toString());
				}
				return output;
			},

			getDateDiffServices: function (startRif, stopRif, servizioTables, withUnabled) {
				var self = this;
				var anni = [];

				if (this.isNull(withUnabled))
					withUnabled = true;

				//calcolo i giorni e i mesi dei servizi
				var dateDiffDays = 0;
				var dateDiffMonth = 0;
				var dateDiffYear = 0;
				_.forEach(servizioTables, function (servizioTable) {
					_.forEach(self.getDataTable(servizioTable).rows, function (servizioRow) {
						var dateDiff = self.getDaysAndMonth(startRif, stopRif, servizioRow, withUnabled);
						dateDiffDays += dateDiff.gg;
						dateDiffMonth += dateDiff.mm;
						dateDiffYear += dateDiff.aa;

						var anniCoinvolti = self.getYears(servizioRow.start, servizioRow.stop);
						_.forEach(anniCoinvolti, function (annoCoinvolto) {
							//vedo se l'aa è già lavorato in parte
							var anno = _.find(anni, function (a) { return a == annoCoinvolto; });
							if (!anno) {
								anni.push(annoCoinvolto);
							}
						});
					});
				});

				//rivaluto i giorni in mesi e i mesi in anni
				var output = this.reevaluateDaysAndMonth({ gg: dateDiffDays, mm: dateDiffMonth, aa: dateDiffYear });
				output.anni = anni;
				return output;
			},

			/**
			 * restituisce una terna anni, mesi, giorni con valori sensati 0<gg<30, 0<mm<12, 0<aa
			 * @param {any} input
			 */
			reevaluateDaysAndMonth: function (input) {
				//rivaluto i giorni in mesi e i mesi in anni
				var dateDiffYears = 0;
				var dateDiffMonth = 0;
				if (input.gg >= 30) {
					dateDiffMonth = Math.trunc(input.gg / 30);
					input.mm += dateDiffMonth;
					input.gg -= dateDiffMonth * 30;
				}
				if (input.gg < 0) {
					dateDiffMonth = Math.trunc(input.gg / 30);
					input.mm += dateDiffMonth;
					//tolgo ai giorni negativi i mesi già sottratti
					input.gg -= dateDiffMonth * 30;
					//se c'è un resto di giorni negativi vanno stornati (sempre con +) da un'altro mese
					if (input.gg < 0) {
						input.mm -= 1;
						input.gg = 30 + input.gg;
					}
				}
				if (input.mm >= 12) {
					dateDiffYears = Math.trunc(input.mm / 12);
					input.mm -= dateDiffYears * 12;
				}
				if (input.mm < 0) {
					dateDiffYears = Math.trunc(input.mm / 12);
					input.aa += dateDiffYears;
					//tolgo ai mesi negativigli anni già sottratti
					input.mm -= dateDiffYears * 12;
					//dateDiffYears è stato consumato, lo azzero per non farlo uscire sull'output
					dateDiffYears = 0;
					//se c'è un resto di mesi negativi vanno stornati (sempre con +) da un'altro anno
					if (input.mm < 0) {
						input.aa -= 1;
						input.mm = 12 + input.mm;
					}
				}

				return { gg: input.gg, mm: input.mm, aa: (dateDiffYears + (input.aa ? input.aa : 0)) }
			},

			getMonthDiff: function (d1, d2) {
				var months;
				months = (d2.getFullYear() - d1.getFullYear()) * 12;
				months -= d1.getMonth();
				months += d2.getMonth();
				months -= 1; //mi interessano solo i mesi pieni
				return months <= 0 ? 0 : months;
			},

			anzianitaLessThan(a1, a2) {
				if (a1.aa < a2.aa) {
					return true;
				} else {
					if (a1.aa == a2.aa && a1.mm < a2.mm) {
						return true;
					} else {
						if (a1.aa == a2.aa && a1.mm == a2.mm && a1.gg < a2.gg) {
							return true;
						}
					}
				}
				return false;
			},

			anzianitaSum(a1, a2) {
				return this.reevaluateDaysAndMonth({
					gg: a1.gg + a2.gg,
					mm: a1.mm + a2.mm,
					aa: a1.aa + a2.aa
				});
			},

			anzianitaDiff(a1, a2) {
				return this.reevaluateDaysAndMonth({
					gg: a1.gg - a2.gg,
					mm: a1.mm - a2.mm,
					aa: a1.aa - a2.aa
				});
			},

			getDateByStartAndAnzianita: function (start, anniFrom, mesiFrom, giorniFrom, anniTo, mesiTo, giorniTo, stop, stops) {
				var dataCorrente = null;
				//va usata con le anzianita ordinate FROM la più piccola TO la più grande
				var diffA = anniTo - anniFrom;
				var diffM = mesiTo - mesiFrom;
				var diffG = giorniTo - giorniFrom;
				if (start) {
					dataCorrente = new Date(start);
					if (stops) {
						let self = this;
					//	let anzianitaCorrente = { gg: giorniFrom, mm: mesiFrom, aa: anniFrom };
						let anzianitaFinale = { gg: giorniTo, mm: mesiTo, aa: anniTo };
					//	let ggSlittamento = 0;
					//	while (this.anzianitaLessThan(anzianitaCorrente, anzianitaFinale)) {
					//		//incremento la data
					//		dataCorrente.setDate(dataCorrente.getDate() + 1);
					//		if (!stops.some(function (stop) { return stop.start.getTime() <= dataCorrente.getTime() && stop.stop.getTime() > dataCorrente.getTime() })) {
					//			//se la data cade in un momento in cui lavorava l'anzianità viene incrementata
					//			anzianitaCorrente.gg++;
					//			anzianitaCorrente = this.reevaluateDaysAndMonth(anzianitaCorrente);
					//		}
					//		else {
					//			//altrimenti accumulo giorni di slittamento della data
					//			ggSlittamento++;
					//		}
					//	}
					//	//calcolo l'anzianità SENZA contare le interruzioni e ...
					//	dataCorrente = new Date(start);
					//	dataCorrente.setFullYear(dataCorrente.getFullYear() + diffA);
					//	dataCorrente.setMonth(dataCorrente.getMonth() + diffM);
					//	dataCorrente.setDate(dataCorrente.getDate() + diffG);
					//	//...aggiungo i giorni in cui non ha lavorato perchè l'anzianità era ferma (ma in formato aammgg perchè se no si guadagnano 5 o 6 gg l'anno)
					//	let anzianitaDiRitardo = { gg: ggSlittamento, mm: 0, aa: 0 };
					//	anzianitaDiRitardo = this.reevaluateDaysAndMonth(anzianitaDiRitardo);
					//	dataCorrente.setFullYear(dataCorrente.getFullYear() + anzianitaDiRitardo.aa);
					//	dataCorrente.setMonth(dataCorrente.getMonth() + anzianitaDiRitardo.mm);
					//	dataCorrente.setDate(dataCorrente.getDate() + anzianitaDiRitardo.gg);
						let lastStop = null;
						stops.forEach(function (stop) {
							if (self.anzianitaLessThan(stop.anzianita, anzianitaFinale))
								lastStop = stop;
						});
						if (lastStop) {
							//2-ricavo la differenza
							let diff = this.anzianitaDiff(anzianitaFinale, lastStop.anzianita);
							//3-sommo la differenza di anzianità alla fine dello stop
							dataCorrente.setFullYear(lastStop.stop.getFullYear() + diff.aa);
							dataCorrente.setMonth(lastStop.stop.getMonth() + diff.mm);
							dataCorrente.setDate(lastStop.stop.getDate() + diff.gg);
						} else {
							//se non c'è uno stop precedente uso il metodo classico
							dataCorrente.setFullYear(dataCorrente.getFullYear() + diffA);
							dataCorrente.setMonth(dataCorrente.getMonth() + diffM);
							dataCorrente.setDate(dataCorrente.getDate() + diffG);
						}
					} else { 
						dataCorrente.setFullYear(dataCorrente.getFullYear() + diffA);
						dataCorrente.setMonth(dataCorrente.getMonth() + diffM);
						dataCorrente.setDate(dataCorrente.getDate() + diffG);
					}
				}
				if (stop) {
					dataCorrente = new Date(stop);
					dataCorrente.setFullYear(dataCorrente.getFullYear() - diffA);
					dataCorrente.setMonth(dataCorrente.getMonth() - diffM);
					dataCorrente.setDate(dataCorrente.getDate() - diffG);
				}

				return dataCorrente;
			},

			getLineaByFasce: function (stipendioOrd, tipoParagrafo, metaPage, dataPresaServizio, virtualDataPresaServizio, dataConfluimento, anniConfluimento, anzianitaStartA, anzianitaStartM, anzianitaStartG/*, dtRicostruzione*/, stops) {
				var lineaStipendio = [];
				var currentAnzianita = { aa: anzianitaStartA, mm: anzianitaStartM, gg: anzianitaStartG };
				var currentDataPresaServizio = new Date(dataPresaServizio);
				var currentVirtualDataPresaServizio = new Date(virtualDataPresaServizio);
				var currentDataConfluimento = new Date(dataConfluimento);

				//per ogniuno 
				_.forEach(stipendioOrd, function (stipendioCurr) {
					var tipo = tipoParagrafo;
					var tempCurrentAnzianita = currentAnzianita;
					let stipendioCurrStart = (stipendioCurr.start ? stipendioCurr.start : new Date(1970, 1, 1));
					let stipendioCurrAnzianitamax = (stipendioCurr.anzianitamax ? stipendioCurr.anzianitamax : 100);
					// - calcolo le dataInizioFasciaCorrente e dataFineFasciaCorrente (escludendo così quelle con start e stop di validità incompatibili) in base alla data di presa servizio

					//-------------------------data inizio fascia ------------------------------
					var dataInizioFasciaCorrente = new Date(currentDataPresaServizio);

					if (stipendioCurr.anzianitamin != anzianitaStartA) {
						if (stipendioCurr.anzianitamin > anzianitaStartA) {
							dataInizioFasciaCorrente = metaPage.getDateByStartAndAnzianita(
								currentDataPresaServizio,
								anzianitaStartA,
								anzianitaStartM,
								anzianitaStartG,
								stipendioCurr.anzianitamin, 0, 0,
								null,
								stops
							)
						}
						else {
							dataInizioFasciaCorrente = metaPage.getDateByStartAndAnzianita(
								null,
								stipendioCurr.anzianitamin, 0, 0,
								anzianitaStartA,
								anzianitaStartM,
								anzianitaStartG,
								currentDataPresaServizio,
								stops
							)
						}
					}

					//salvo momentaneamente la data inizio fascia appena calcolata per considerazioni successive
					let originalDataInizioFasciaCorrente = new Date(dataInizioFasciaCorrente);

					//se la fascia inizia DOPO il confluimento di anzianità ...
					if (dataInizioFasciaCorrente > currentDataConfluimento) {

						//verifico quanto trasla indietro nel tempo l'inizio della  fascia
						dataInizioFasciaCorrente = new Date(currentVirtualDataPresaServizio);
						dataInizioFasciaCorrente.setFullYear(dataInizioFasciaCorrente.getFullYear() + stipendioCurr.anzianitamin);

						//se la data inizio è precedente a quella del confluimento ...
						if (dataInizioFasciaCorrente < currentDataConfluimento) {
							//... prendo come inizio la data del confluimento
							dataInizioFasciaCorrente = currentDataConfluimento;
							//è il pragrafo del confluimento
							if (tipo == 1)
								tipo = 4;
							//l'anzianità è del cofluimento
							tempCurrentAnzianita = metaPage.reevaluateDaysAndMonth({
								aa: anniConfluimento + metaPage.state.currentRow.preruoloecona,
								mm: anzianitaStartM,
								gg: anzianitaStartG
							});
						}
						else {
							//se inizia prima della presa di servizio ...
							if (dataInizioFasciaCorrente < currentDataPresaServizio) {
								//... l'anzianità e quella della presa in servizio (default)
								//faccio iniziare la fascia alla presa di servizio
								dataInizioFasciaCorrente = new Date(currentDataPresaServizio);
								//il tipo è quello della fascia di partenza
								if (tipo == 1)
									tipo = 0;
							} else {
								//altrimenti l'anzianità è quella di fascia
								tempCurrentAnzianita = { aa: stipendioCurr.anzianitamin, mm: 0, gg: 0 };
							}
						}

					}
					//se la fascia inizia PRIMA del confluimento di anzianità
					else {
						//se inizia dopo della presa di servizio ...
						if (dataInizioFasciaCorrente > currentDataPresaServizio) {
							//l'anzianità è quella di fascia
							tempCurrentAnzianita = { aa: stipendioCurr.anzianitamin, mm: 0, gg: 0 };
							//l'inizio della fascia è quello reale (appena calcolato)
							//il tipo di paragrafo è l'avanzamento di fascia (default)
						}
						//altrimenti ...
						else {
							//... l'anzianità e quella della presa in servizio (default)
							//faccio iniziare la fascia alla presa di servizio
							dataInizioFasciaCorrente = new Date(currentDataPresaServizio);
						}
					}

					//se però la validità dello stipendio parte successivamente ...
					if (dataInizioFasciaCorrente < stipendioCurrStart) {
							//...anche la fascia parte successivamente
							dataInizioFasciaCorrente = new Date(stipendioCurr.start)
					}

						//se la fascia comincia alla presa sevizio
						if (dataInizioFasciaCorrente.getTime() == currentDataPresaServizio.getTime() && tipo == 1)
							//il paragrafo è quello iniziale
							tipo = 0;

						let isChangeFasciaForAnzianta = false;
						//se l'inizio della fascia corrente corrisponde a quello calcolato in base alla anzianità di partenza è un cambio fascia
						if (dataInizioFasciaCorrente.getTime() == originalDataInizioFasciaCorrente.getTime() && tipo == 1)
							isChangeFasciaForAnzianta = true;

						//-------------------------data fine fascia ------------------------------
						var dataFineFasciaCorrente = null;
						if (stipendioCurr.anzianitamax) {
							if (stipendioCurr.anzianitamax + 1 > anzianitaStartA) {
								dataFineFasciaCorrente = metaPage.getDateByStartAndAnzianita(
									currentDataPresaServizio,
									anzianitaStartA,
									anzianitaStartM,
									anzianitaStartG,
									stipendioCurr.anzianitamax + 1, 0, 0,
									null,
									stops
								)
							}
							else {
								dataFineFasciaCorrente = metaPage.getDateByStartAndAnzianita(
									null,
									stipendioCurr.anzianitamax + 1, 0, 0,
									anzianitaStartA,
									anzianitaStartM,
									anzianitaStartG,
									currentDataPresaServizio,
									stops
								)
							}

							//se la data fine è successiva alla data di confluimento:
							if (dataFineFasciaCorrente > currentDataConfluimento) {
								// se la data di inizio è precedente allora la data di fine è quella del cnfluimento 
								if (dataInizioFasciaCorrente < currentDataConfluimento) {
									dataFineFasciaCorrente = new Date(currentDataConfluimento);
								}
								//altrimenti va rivalutata con la data di presa servizio virtuale
								else {
									dataFineFasciaCorrente = new Date(currentVirtualDataPresaServizio);
									dataFineFasciaCorrente.setFullYear(dataFineFasciaCorrente.getFullYear() + (stipendioCurr.anzianitamax + 1));
								}
							}
							//in ogni caso meno un giorno
							dataFineFasciaCorrente.setDate(dataFineFasciaCorrente.getDate() - 1)

							//se la data fine fascia calcolato è successiva allo stop di validità dello stipendio ...
							if (dataFineFasciaCorrente > stipendioCurr.stop)
								//...vince lo stop di validità dello stipendio
								dataFineFasciaCorrente = new Date(stipendioCurr.stop)

						} else {
							//se la fascia non ha fine ma lo stop di validità dello stipendio c'è vince lui
							dataFineFasciaCorrente = stipendioCurr.stop ? new Date(stipendioCurr.stop) : null;
						}

						//se le date inizio e fine reali sono compatibili con quelle di validità della fascia e l'anzianità attuale allora l'aggiungo alla mia linea temporale oppure no
						if (stipendioCurr.anzianitamin <= tempCurrentAnzianita.aa && stipendioCurrAnzianitamax >= tempCurrentAnzianita.aa
							&& !(
								//inizio validità stipendo successivo alla fine fascia
								(dataFineFasciaCorrente ? dataFineFasciaCorrente : new Date(2150, 1, 1)) < stipendioCurrStart 
								 //fine validità stipendio precedente all'inizio fascia
								|| dataInizioFasciaCorrente > (stipendioCurr.stop ? stipendioCurr.stop : new Date(2150, 1, 1))
							)) {
							lineaStipendio.push({
								start: stipendioCurr.start,
								stop: stipendioCurr.stop,
								anzianitaMin: stipendioCurr.anzianitamin,
								anzianitaMax: stipendioCurr.anzianitamax,
								startFascia: new Date(dataInizioFasciaCorrente),
								stopFascia: (dataFineFasciaCorrente ? new Date(dataFineFasciaCorrente) : null),
								stipendio: stipendioCurr.stipendio,
								iis: stipendioCurr.iis,
								lordonotredicesima: stipendioCurr.lordonotredicesima,
								complementomensile: stipendioCurr.complementomensile,
								anzianita: tempCurrentAnzianita,
								tipo: tipo,
								rifnormativo: stipendioCurr.rifnormativo,
								isChangeFasciaForAnzianta: isChangeFasciaForAnzianta
							});

							currentAnzianita = tempCurrentAnzianita;
						}
				});
				return lineaStipendio;
			},

			/**
			 * metodo che a partire da una scadenza delle linee e un array di accoppiate fasce stipendiali (tutte quelle definite nelle normative) 
			 * con tipologia ([{ fasce: stipendioOrd, tipo: 1 }, { fasce: ivcs, tipo: 2 }, { fasce: rpdOrd, tipo: 3 }])
			 * resetta le fasce nel formato delle linee stipendiali (sono come le fasce stipendiali ma tagliate sulla anzianità acquisita nel tempo del docente) 
			 * che sono valide per quella data e anzianità, facendole partire dalla data in input 
			 * (quindi si può usare solo per scadenze di cambio fascia per anzianità acquisita e NON per scadenze di cambio normativo)
			 * @param {any} scadenza
			 * @param {any} linee
			 */
			resetFasceScadenza: function (scadenza, linee) {

				scadenza.fasce = [];
				linee.forEach(function (linea) {
					let fascia = _.find(linea.fasce, function (f) {
						return (f.anzianitamin <= (scadenza.anzianita ? scadenza.anzianita.aa : 0) && (f.anzianitamax ? f.anzianitamax : 100) >= (scadenza.anzianita ? scadenza.anzianita.aa : 0)) &&
							((f.start ? f.start.getTime() : new Date(1900, 1, 1)) <= scadenza.data.getTime() && (f.stop ? f.stop.getTime() : new Date(2160, 1, 1)) >= scadenza.data.getTime());
					});
					if (fascia) {
						scadenza.fasce.push({
							start: fascia.start,
							stop: fascia.stop,
							anzianitaMin: fascia.anzianitamin,
							anzianitaMax: fascia.anzianitamax,
							startFascia: scadenza.data,
							//stopFascia: (dataFineFasciaCorrente ? new Date(dataFineFasciaCorrente) : null),
							stipendio: fascia.stipendio,
							iis: fascia.iis,
							lordonotredicesima: fascia.lordonotredicesima,
							complementomensile: fascia.complementomensile,
							//anzianita: tempCurrentAnzianita,
							tipo: linea.tipo,
							rifnormativo: fascia.rifnormativo
						});
					}
				});
			}
		});

	appMeta.MetaSegreteriePage = MetaSegreteriePage;

}());

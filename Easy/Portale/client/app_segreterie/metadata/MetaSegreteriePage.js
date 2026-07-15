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
		this.tipoente = appMeta.security.usr("tipoente");
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


				//recupero i campi obbligatori dalla tabella mandatoryfields
				var def = appMeta.Deferred("beforeFill-MetaSegreteriePage");
				var arraydef = [];

				arraydef.push(this.getMandatoryFields());

				$.when.apply($, arraydef)
					.then(function () {
						return MetaEasyPage.prototype.beforeFill.call(self)
							.then(function () {
								return def.resolve();
							});
					});
				return def.promise();

			},

			manageValidResult: function (rowToCheck) {
				var def = appMeta.Deferred("isValid-workpackage_seg");
				var firstErrorObj;
				var self = this;

				//controllo i campi obbligatori
				this.mandatoryFields.rows
					.sort((a, b) => b.position - a.position) //li ordino dal più grande al più piccolo (l'ultima position per prima) perchè poi firstErrorObj alla fine del forEach è l'ultimo che viene restituito, in questo modo ottengo il primo
					.forEach(function (field) {
					var value = rowToCheck.current[field.columnname];
					if (
						(value === null || value === undefined || value === '') && !field.mastervalue //se il campo obbligatorio non è stato definito e non dipende da un altro valore
					) {

						firstErrorObj = {
							warningMsg: "",
							errMsg: (field.message ? field.message : 'Il campo ' + field.title + ' non puo essere vuoto '),
							outCaption: field.title,
							errField: field.columnname,
							row: rowToCheck
						};
						return firstErrorObj;
					}

					if (
						(value === null || value === undefined || value === '') && !!field.mastervalue //se il campo obbligatorio non è stato definito e dipende da un altro valore
						&& rowToCheck.current[field.mastercolumnname] == field.mastervalue //ed è proprio il valore attuale
					) {

						firstErrorObj = {
							warningMsg: "",
							errMsg: (field.message ? field.message : 'Il campo ' + field.title + ' non può essere vuoto con il valore attuale impostato per ' + field.mastertitle + ' '),
							outCaption: field.title,
							errField: field.columnname,
							row: rowToCheck
						};
						return firstErrorObj;
					}
				});

				if (firstErrorObj) {
					return def.resolve(firstErrorObj);
				} else {
					def.resolve(true);
					return MetaEasyPage.prototype.manageValidResult.call(this, rowToCheck);
				}
			},

			afterLink: function () {
				var self = this;
				var pt = this.getDataTable(this.primaryTableName);
				_.forEach(pt.key(), function (key) {
					metaModel.allowZero(pt.columns[key], false);
				});

				//fisso l'altezza del contenuto dei TAB ovvero il contenitore di griglie, ecc. uguale per tutti
				var screenH = $(window).height();
				var offset = 190;
				var navtabHeight = $('.nav-tabs').height();
				var htabContainerVal = screenH - offset - navtabHeight;
				var htabContainer = (htabContainerVal).toString() + 'px';
				$(".tab-content").css("height", htabContainer);

				// calcolo giorni sospensioni
				return this.getSospensioni()
					.then(function (result) {
						//carico la configurazione di performance
						self.getConfPerformance();
					})
					.then(function () {
						return MetaEasyPage.prototype.afterLink.call(self);
					});
			},

			afterFill: function () {
				// PARTE SYNC
				// calcola la giusta height delle grid, serve
				// per far apparire la scrollbar orizzontale visibile e non in fondo

				//fisso l'altezza del contenuto dei TAB ovvero il contenitore di griglie, ecc. uguale per tutti
				var screenH = $(window).height();
				var offset = 175;
				var navtabHeight = $('.nav-tabs').height();
				var htabContainerVal = screenH - offset - (navtabHeight ?? 0);
				var htabContainer = (htabContainerVal).toString() + 'px';
				$(".tab-content").css("height", htabContainer);

				//pagine di dettaglio
				var offsetDetail = 230;
				var hdetail = (screenH - offsetDetail).toString() + 'px';
				var htabdetail = (screenH - offsetDetail + 8).toString() + 'px';
				$(".detailPage ").css("min-height", htabdetail);
				$(".detailPage").find(this).css("max-height", hdetail);

				$('[data-custom-control = "gridx"]').each(function () {
					var h = (htabContainerVal - 40).toString() + 'px';
					$(this).css("max-height", h);
				});

				$('[data-custom-control = "checklist"]').each(function () {
					var h = (htabContainerVal - 40).toString() + 'px';
					$(this).find(".table").css("max-height", h);
				});

				// appare una scroll veticale se il tree viene espanso oltre la finestra.
				// utile nel master - detail duante navigazione tree
				$('[data-custom-control = "tree"]').each(function () {
					var offsetTree = 150;
					var htab = (screenH - offsetTree).toString() + 'px';
					$(this).css("max-height", htab);
					$(this).css("overflow-y", "auto");
					$(this).css("overflow-x", "hidden");
				});

				this.setMandatoryFieldsLabels();

				// ASYNC
				// se esiste beforeFill sulla classe base MetaEasyPage lo invoco
				return MetaEasyPage.prototype.afterFill.call(this);
			},

			/**
			 * Metodo che aggiunge il grassetto e l'asterisco ai cambi obbligatori
			 */
			setMandatoryFieldsLabels: function () {
				let self = this;
				//prima recupero quelli definiti manualmente
				let allMandatoryFileds = [];
				this.mandatoryFields.rows.forEach(function (field) {
					if (
						!field.mastervalue ||
						(!!field.mastervalue && self.state.currentRow[field.mastercolumnname] == field.mastervalue)
					) {
						allMandatoryFileds.push(field);
					}
				});

				//poi queli che non sono nullabili sul dataset
				var pt = this.getDataTable(this.primaryTableName);
				_.forEach(pt.columns, function (c) {
					if (c.allowNull == false) {
						allMandatoryFileds.push({
							tablename: self.primaryTableName,
							editlistingtype: self.editType,
							columnname: c.name,
							title: c.caption,
							mastercolumnname: '',
							mastertitle: '',
							mastervalue: ''
						})
					}
				}
				);

				//cancello i grassetti e gli asterischi se ce ne sono (ad es: sto aprendo i risultati di una ricerca cliccando su tutti i risultati in sequenza)
				$('label').each(function () {
					$(this).html($(this).html().replace("</b> *", '').replace("<b>", ''));
				});

				//per ogni campo obbligatorio ...
				allMandatoryFileds.forEach(function (mf) {
					let elId = self.primaryTableName + '_' + self.editType + '_' + mf.columnname;
					//...individuo la label, a meno che non sia relativa a un campo non editabile perchè non avrebbe senso segnalarglielo
					let el = $('[for = "' + elId + '"]')
						.not(function () {
							return $(this).attr('for') && $('input#' + $(this).attr('for')).attr('readonly') !== undefined;
						});
					if (el.length)
						if (el[0].innerHTML.indexOf('*') === -1)
							//aggiungo all'elemento il grassetto e un asterisco alla fine alla label
							el[0].innerHTML = "<b>" + el[0].innerHTML + "</b> *";
				}
				);

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

			stringFromDate_ddmmyyyy_hhmm: function (d) {
				if (!d) return '';

				var day = d.getDate().toString().padStart(2, '0');
				var month = (d.getMonth() + 1).toString().padStart(2, '0');
				var year = d.getFullYear().toString();

				var hours = d.getHours().toString().padStart(2, '0');
				var minutes = d.getMinutes().toString().padStart(2, '0');

				return day + '/' + month + '/' + year + ' ' + hours + ':' + minutes;
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
				if (el) {
					//gestione del controllo upload
					if (el[0] && el[0].attributes && el[0].attributes['data-custom-control'] && el[0].attributes['data-custom-control'].nodeValue == 'upload') {
						//se devo disabilitare agisco (altrimenti lascio com'è)
						if (!bool) {
							//nascondo il bottone "rimuovi allegato"
							if (el[0].children.length >= 4) {
								var delButton = el[0].children[4];
								delButton.hidden = true;
							}
							//nascondo il bottone "carica allegato"
							if (el[0].children.length >= 0) {
								var uploadButton = el[0].children[0];
								uploadButton.hidden = true;
							}
						}
					} else {
						this.enableEl(el, bool);
						this.readOnlyEl(el, !bool);
						if (el.css)
							if (bool) {
								el.css("pointer-events", "unset")
							} else {
								el.css("pointer-events", "none")
							}
					}
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
				var isSearchTable = true;  // memorizzo per capire se devo forzare la chiusura dell'elenco eventualmente aperto
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
				if (!objPrm.columnSource.includes(",") && toEsclude.length) {
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

			getChildren: function (tableName, parentIdValue, parentIdName, fromCallerStateDS) {

				var children = [];
				var rows = [];

				if (fromCallerStateDS) {
					rows = appMeta.currApp.currentMetaPage.state.callerPage.getDataTable(tableName).rows;
				} else {
					rows = appMeta.currApp.currentMetaPage.getDataTable(tableName).rows;
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
				if (codiceFiscale.length !== 16) {
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

			/**
			 * calcola i campi obbligatori
			 * @returns {Deferred(dtVal)}
			 * @constructor
			 */
			getMandatoryFields: function () {
				var self = this;
				return appMeta.getData.runSelect("appfieldmandatoryview", "*", this.q.and(this.q.eq("editlistingtype", this.editType), this.q.eq("tablename", this.primaryTableName))).
					then(function (dt) {
						self.mandatoryFields = dt;
						return dt;
					});
			},

			/**
			 * Restituisce le righe non cancellate tu una tabella jsDataSet
			 */
			getNotDeletedRows: function (table) {

				let notDeletedRows = [];
				_.forEach(table.rows, function (r) {
					if (r.getRow().myState != 'deleted')
						notDeletedRows.push(r);
				});
				return notDeletedRows;
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

					//le pratiche ad esempio non hanno origine e si intende comunicazione interna
					if (!idreg_origine) idreg_origine = idreg_destinazione;

					var self = this;
					var rowToNullify = null;
					var rowFirstProtocol = null;
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

										var filterForstProtocol = self.q.and(
											self.q.eq("protnumero", rowToNullify.protnumero),
											self.q.eq("protanno", rowToNullify.protanno)
										);

										return getData.runSelect("protocollodocelement", "idprotocollodocelement", filterForstProtocol, null)
											.then(function (dt) {
												if (dt.rows.length) {
													rowFirstProtocol = dt.rows[0];
												}
												self.hideWaitingIndicator(waitingHandler);
												// procedo con la protocollazione automatica
												return def.from(self.saveProtocol(rowToNullify, rowFirstProtocol, idreg_origine, idreg_destinazione, oggetto, testo, codiceregistro, idprotocollodockind));

											}); // chiude la runSelect

									}
									self.hideWaitingIndicator(waitingHandler);
									// procedo con la protocollazione automatica
									return def.from(self.saveProtocol(rowToNullify, rowFirstProtocol, idreg_origine, idreg_destinazione, oggetto, testo, codiceregistro, idprotocollodockind));

								}); // chiude la runSelect
						});
				}

				return this.showMessageOk(localResource.protocolSaveNOSaved);

			},

			areEqualTestoProtocollo: function (testoDb, testoClient) {
				return testoDb === testoClient;
			},

			saveProtocol: function (rowToNullify, rowFirstProtocol, idreg_origine, idreg_destinazione, oggetto, testo, codiceregistro, idprotocollodockind) {
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
						return getData.getDataSet('protocollo', 'default')
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

								// PROTOCOLLO IN USCITA
								utils._if(idreg_origine === self.idreg_istituto && idreg_destinazione != self.idreg_istituto)
									._then(function () {
										rowProtocollo.originemail = dsRegIstitutiPrinc.tables.registryreference.rows[0].email;
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

										if (idreg_origine != self.idreg_istituto && idreg_destinazione === self.idreg_istituto) {

											// PROTOCOLLO IN INGRESSO
											if (dsRegIstitutiPrinc.tables.registryreference.rows.length) {
												rowProtocolloDestinatario.destmail = dsRegIstitutiPrinc.tables.registryreference.rows[0].email;
											}
											// recupero mail dello studente
											var filter = self.q.and(self.q.eq('idreg', idreg_origine), self.q.isNotNull('email'));
											return getData.runSelect('registryreference', 'email', filter, null).then(function (dt) {
												if (dt.rows.length) {
													rowProtocollo.originemail = dt.rows[0].email;
												}
												return true;
											});

										}
										if (idreg_origine === self.idreg_istituto && idreg_destinazione === self.idreg_istituto) {

											// PROTOCOLLO INTERNO
											if (dsRegIstitutiPrinc.tables.registryreference.rows.length) {
												rowProtocolloDestinatario.destmail = dsRegIstitutiPrinc.tables.registryreference.rows[0].email;
												rowProtocollo.originemail = dsRegIstitutiPrinc.tables.registryreference.rows[0].email;
											}
										}

										return true;
									})
									.then(function () {

										rowProtocolloDoc.idprotocollorifkind = 3;
										rowProtocolloDoc.idmimetype = 35;

										//creo il PDF
										appMeta.PdfExport.metaPage = self;
										let pdf = appMeta.PdfExport.doExportPdf(appMeta.PdfExport, null, true);

										var Attachment = appMeta.Attachment;
										self.attachManger = new Attachment();

										rowProtocolloDoc.fileName = pdf.name;
										rowProtocolloDoc.datadoc = new Date();

										return self.calculateSHA1(pdf);
									}).then(function (fileAndHash) {
										// calcolo sha-1 del pdf per inserirlo nel campo "telematicohash" del protocollo
										rowProtocolloDocElement.telematicohash = fileAndHash.hash;

										//ne faccio l'upload
										return self.attachManger.upload(fileAndHash.file, fileAndHash.file.name)
											.then(function (dsattach) {
												// merge della tab attach
												var tableAttach = dataSetProtocolloSeg.tables["attach"];
												// recupero dt attach del dataset dal qaule prenderò tutte le informazioni persistenti che ho salvato circa l'allegato
												var dtattach = dsattach.tables["attach"];
												var idattach = dtattach.rows[0]["idattach"];

												// popolo tab attach, mergiando la riga ricevuta dal nuovo allegato
												appMeta.getDataUtils.mergeRowsIntoTable(tableAttach, dtattach.rows, true);
												// valorizzo il campo/i campi necessari per la logica di assegnazione dell'allegato alla riga principale del ds
												// Qui son sicuro che la riga principale è ok, i controlli di conf esatta li ho fatti all'inizio del emtodo
												rowProtocolloDoc["idattach"] = idattach;

												return true
											})
											.fail(function (err) {
												alert(JSON.stringify(err));
												// nascondo indicatore di attesa
												self.metaPage.hideWaitingIndicator(waitingHandler);
												return false
											});

									}).then(function (res) {

										rowProtocolloDocElement.oggetto = oggetto;
										rowProtocolloDocElement.idprotocollodockind = idprotocollodockind;

										// ABBIAMO CREATO la nuova riga protocollo, prima di salvare verifichaimo che la vecchia riga sia da annullare
										if (rowToNullify) {
											rowToNullify.annullato = "S";
											rowToNullify.dataannullamento = new Date();
											rowToNullify.motivoann = "Annullato in seguito a una nuova protocollazione dello stesso documento";
											dataSetProtocolloSeg.tables.protocollo.importRow(rowToNullify);
											rowProtocolloDocElement.idprotocollodocelement_primo = rowFirstProtocol.idprotocollodocelement;
										}

										// -----> su "protocollo seg" prende la tabella principale corrente e inietta la riga attuale con i valori modificati.
										tMain = dataSetProtocolloSeg.tables[self.primaryTableName];
										//if (!self.detailPage) {
										// forzo un valore di default inventato, così la riga va in stato modificata, e rimarrà sincronizzata con quella del server
										//sia che sia dettaglio o pagina principale lo modifico perchè se resta unchanged poi il merge con il ds restituito dal servizio non funzona
										self.state.currentRow.protnumero = 99999;
										//}
										tMain.importRow(self.state.currentRow);
										let params = {
											dsProtocolloSeg: getDataUtils.getJsonFromJsDataSet(dataSetProtocolloSeg, true),
											tableName: self.primaryTableName
										};

										return appMeta.callWebService("protocolla", params);
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
			 * Calcola l'hash SHA-1 di un oggetto File usando le Promise.
			 * @param {File} file - L'oggetto File di input.
			 * @returns {Promise<string>} - Una Promise che risolverà con la stringa dell'hash.
			 */
			calculateSHA1: function(file) {
				// 1. Iniziamo la catena leggendo il file
				return file.arrayBuffer()
					.then(function (arrayBuffer) {
						// 2. Quando il file è letto, calcoliamo l'hash
						return crypto.subtle.digest('SHA-1', arrayBuffer);
					})
					.then(function (hashBuffer) {
						// 3. Quando l'hash è calcolato, lo convertiamo in stringa esadecimale
						const byteArray = new Uint8Array(hashBuffer);
						const hashHex = Array.from(byteArray)
							.map(function (byte) {
								return byte.toString(16).padStart(2, '0');
							})
							.join('');

						// Il valore ritornato qui sarà il valore di risoluzione della Promise finale
						return {hash: hashHex, file: file};
					})
					.catch(function (error) {
						console.error("Si è verificato un errore:", error);
						throw error; // Propaga l'errore a chi chiamerà la funzione
					});
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

			manageProtocollaResponseWithRules: function (dataSetProtocolloSeg, jsonRes) {
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
				var msg = obj.messages;
				return def.resolve(dataSetProtocolloSeg, msg, success);
			},

			/**
			 * @private
			 * funzione di utility utilizzata in assegnaProtocollo() con useLegacyFormat a true restituisce una stringa chiave/valore
			 * nello stile legacy, altrimenti restituisce una stringa in formato XML con attributi caption per ogni colonna
			 * @param {string[]} arrayTablesToProtocol - Array di nomi delle tabelle da includere nel testo del protocollo
			 * @param {boolean} useLegacyFormat - Se true utilizza il formato legacy, altrimenti utilizza il formato XML con attributi caption
			 * @returns {string} - Testo formattato per il protocollo
			 */
			getHashForProtocol: function (arrayTablesToProtocol, useLegacyFormat) {
				var self = this;
				var exclude = ["protanno", "protnumero", "lt", "cu", "lu"];

				// 1. Helper per formattare le Date
				var getValue = function (val) {
					if (val instanceof Date) {
						return self.stringFromDate_ddmmyyyy(val);
					}
					return val;
				};

				// 2. Helper per rendere sicure le stringhe negli attributi XML (gestisce " < > &)
				var escapeXmlAttr = function (str) {
					if (typeof str !== 'string') return str;
					return str.replace(/&/g, '&amp;')
						.replace(/</g, '&lt;')
						.replace(/>/g, '&gt;')
						.replace(/"/g, '&quot;');
				};

				// --- RAMO 1: Formato Legacy (Nessuna modifica qui) ---
				if (useLegacyFormat === true) {
					return _.reduce(arrayTablesToProtocol, function (result, tableName) {
						var dt = self.getDataTable(tableName);
						result += _.reduce(dt.rows, function (acc, r) {
							acc += _.join(
								_.map(Object.keys(r), function (k) {
									if (!exclude.includes(k)) {
										return tableName + "." + k + ": " + getValue(r[k]);
									}
									return '';
								}), ",");
							return acc;
						}, '');
						return result;
					}, '');
				}

				// --- RAMO 2: Formato XML con attributi Caption ---
				return _.reduce(arrayTablesToProtocol, function (result, tableName) {
					var dt = self.getDataTable(tableName);

					// Apro tag Tabella
					result += "<" + tableName + ">";

					result += _.reduce(dt.rows, function (rowAcc, r) {
						rowAcc += "<row>";

						rowAcc += _.join(
							_.compact(_.map(Object.keys(r), function (k) {
								if (!exclude.includes(k)) {
									var val = getValue(r[k]);
									val = (val === null || val === undefined) ? '' : val;

									// Recupero la caption dalla definizione delle colonne
									var captionAttr = "";
									// Controllo difensivo se dt.columns e la colonna specifica esistono
									if (dt.columns && dt.columns[k] && dt.columns[k].caption) {
										// Aggiungo l'attributo caption="Valore Escapato"
										captionAttr = ' caption="' + escapeXmlAttr(dt.columns[k].caption) + '"';
									}

									// Costruisco il tag: <nomecolonna caption="...">Valore</nomecolonna>
									return "<" + k + captionAttr + ">" + val + "</" + k + ">";
								}
								return null;
							})), "");

						rowAcc += "</row>";
						return rowAcc;
					}, '');

					// Chiudo tag Tabella
					result += "</" + tableName + ">";
					return result;
				}, '');
			},

			/**
			 * converte una stringa xml con dentro delle tabelle in una serie di tabelle html
			 * @param {any} xmlString
			 * @returns
			 */
			convertXmlToHtmlTable: function (xmlString) {
				// 1. VERIFICA PRELIMINARE
				// Se è vuoto, non è una stringa, o non inizia con '<' (escluso whitespace),
				// assumiamo sia testo semplice o formato legacy -> esco con stringa vuota.
				if (!xmlString || typeof xmlString !== 'string' || xmlString.trim().indexOf('<') !== 0) {
					return '';
				}

				// 2. PARSING
				var parser = new DOMParser();
				// Avvolgo in <root> per gestire stringhe con più tabelle affiancate
				var xmlDoc = parser.parseFromString("<root>" + xmlString + "</root>", "text/xml");
				var root = xmlDoc.documentElement;

				// 3. VERIFICA VALIDITÀ XML
				// I browser moderni inseriscono un tag <parsererror> se l'XML è malformato
				var parseErrors = xmlDoc.getElementsByTagName("parsererror");
				if (parseErrors.length > 0) {
					return '';
				}

				// 4. VERIFICA CONTENUTO (Non deve essere solo testo avvolto in root)
				// Se root.children.length è 0, significa che non ci sono tag Tabella dentro
				if (root.children.length === 0) {
					return '';
				}

				// --- DA QUI INIZIA LA GENERAZIONE HTML (come prima) ---

				var htmlOutput = '<div class="xml-tables-container">';

				htmlOutput += `
        <style>
            .generated-table { 
                width: 100%; 
                border-collapse: collapse; 
                margin-bottom: 20px; 
                table-layout: fixed; 
            }
            .generated-table th, .generated-table td { 
                border: 1px solid #ddd; 
                padding: 8px; 
                text-align: left; 
                vertical-align: top;
                word-wrap: break-word;
                overflow-wrap: break-word; 
                white-space: normal;
            }
            .generated-table th { 
                background-color: #f2f2f2; 
                font-weight: bold;
            }
            .table-title {
                font-size: 1.2em;
                margin-bottom: 5px;
                margin-top: 15px;
                font-weight: bold;
                text-transform: uppercase;
            }
        </style>
    `;

				for (var i = 0; i < root.children.length; i++) {
					var tableNode = root.children[i];
					var tableName = tableNode.nodeName;
					var rows = tableNode.getElementsByTagName("row");

					if (rows.length === 0) continue;

					htmlOutput += '<div class="table-title">' + tableName + '</div>';
					htmlOutput += '<table class="generated-table">';

					// Intestazione
					htmlOutput += '<thead><tr>';
					var firstRowChildren = rows[0].children;
					var columnsMap = [];

					for (var j = 0; j < firstRowChildren.length; j++) {
						var colNode = firstRowChildren[j];
						var tag = colNode.tagName;
						var caption = colNode.getAttribute("caption") || tag;

						columnsMap.push(tag);
						htmlOutput += '<th>' + caption + '</th>';
					}
					htmlOutput += '</tr></thead>';

					// Corpo
					htmlOutput += '<tbody>';
					for (var r = 0; r < rows.length; r++) {
						var rowNode = rows[r];
						htmlOutput += '<tr>';

						for (var c = 0; c < columnsMap.length; c++) {
							var colTag = columnsMap[c];
							var cellNode = rowNode.getElementsByTagName(colTag)[0];
							var cellValue = cellNode ? cellNode.textContent : "";

							htmlOutput += '<td>' + cellValue + '</td>';
						}
						htmlOutput += '</tr>';
					}
					htmlOutput += '</tbody></table>';
				}

				htmlOutput += '</div>';
				return htmlOutput;
			},

			/*********************************************************************
			****************  FUNZIONI PER SEGRETERIE: ***************************
			*********************************************************************/

			/**
			 * Funzione di recupero delle sospensioni di istituto
			 * @returns
			 */
			getSospensioni: function () {
				var def = Deferred('getSospensioni');
				if (!appMeta.appMain.dtSospensioni && this.idreg_istituto) {
					// salva giorni di sospensione dell'isitituto, da utilizzare poi nella funz schedule()
					var filterSosp = this.q.eq("idreg", this.idreg_istituto);//,
					return appMeta.getData.runSelect("sospensione", "start,stop", filterSosp)
						.then(function (dtSosp) {
							appMeta.appMain.dtSospensioni = dtSosp;
							return def.resolve();
						});
				}

				return def.resolve();
			},

			/**
			 * Funzione di recupero delle sospensioni di un soggetto
			 * @returns
			 */
			getSospensioniMembro: function (idreg) {
				var def = Deferred('getSospensioniMembro');
					// restituisce giorni di sospensione del soggetto, da utilizzare poi nella funz schedule()
					var filterSosp = this.q.eq("idreg", idreg);
					return appMeta.getData.runSelect("sospensione", "start,stop", filterSosp)
						.then(function (dtSosp) {
							return def.resolve(dtSosp);
						});

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
				if (!date) date = new Date();
				var myDate = moment(date);
				var year = myDate.year();
				var watermark = moment("15/08/" + year, "DD/MM/YYYY");
				if (myDate.diff(watermark) > 0) {
					return (myDate.year()) + "/" + (myDate.year() + 1);
				}
				return (myDate.year() - 1) + "/" + myDate.year();
			},

			getAttivformByIscrizione: function (idiscrizione) {
				var def = Deferred('getAttivformByIscrizione');
				let self = this;
				appMeta.getData.runSelect("pianostudio", "*", self.q.and(self.q.eq('idiscrizione', self.state.callerState.currentRow.idiscrizione), self.q.eq('idpianostudiostatus', 3)))
					.then(function (dt) {
						if (dt.rows.length === 0) return def.resolve([]);
						let pianostudio = dt.rows[0];
						appMeta.getData.runSelect("pianostudioattivform", "*", self.q.eq('idpianostudio', pianostudio.idpianostudio))
							.then(function (dtt) {
								let idattivforms = _.map(dtt.rows, 'idattivform');
								return def.resolve(idattivforms);
							})
					})

				return def.promise();
			},

			sendIstanza: function () {
				var def = appMeta.Deferred("Invia-istanza_stu");
				//dico di atendere
				waitingHandler = this.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
				let self = this;
				//salvo
				self.cmdMainSave()
					.then(function () {
						//imposto che non è possibile salvare o cancellare
						self.canSave = false;
						self.canCancel = false;
						self.enableControl($("#Invia"), false);
						//rinfresco la toolbar
						return self.freshToolBar();
					}).then(function () {
						//rinfresco la pagina
						return self.freshForm(true, false);
					}).then(function () {
						//ottengo lo IUV

						let params1 = {
							idistanza: self.state.currentRow.idistanza,
							idreg_studenti: self.state.currentRow.idreg_studenti,
							aa: self.state.currentRow.aa,
							user: self.state.currentRow.userEnv
						};

						return appMeta.callWebService("generaCrediti", params1);

					}).then(function (res) {
						var msg = "OK. L'istanza è stata inviata e i debiti sono stati generati";
						if (res != "ok") {
							msg = "L'istanza è stata inviata ma c'è stato un probema nella generazione dei debiti: " + res.err;
						}
						else {
							// L'invio è andato a buon fine, aggiorno lo stato dell'istanza passandolo a Inviata.
							$('#istanza_imm_stu_idstatuskind').prop('disabled', false)
								.val('2')
								.trigger('change')
								.prop('disabled', true);
							self.state.currentRow.idstatuskind = 2;
							self.getDataTable('istanza').acceptChanges();
						}
						//riattivo la pagina
						self.hideWaitingIndicator(waitingHandler);
						//mostro che è tutto ok
						return self.showMessageOk(msg);
					}).then(function () {
						return def.resolve();
					});
				return def.promise();
			},

			sendPagamento: function () {
				var def = appMeta.Deferred("sendPagamento-debito_stu");
				//dico di atendere
				waitingHandler = this.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
				let self = this;

				let params = {
					iddebito: this.state.currentRow.iddebito,
					//ds: this.state.DS,
					primaryTableName: this.primaryTableName
				};

				return appMeta.callWebService("ProcediPagamento", params)
					.then(function (res) {
					////	var msg = "OK. Pagamento avviato";
					////	if (res.err) {
					////		msg = "Errore nel pagamento: " + res.err;
					////	}
					////	//riattivo la pagina
					////	self.hideWaitingIndicator(waitingHandler);
					////	//mostro che è tutto ok
					////	return self.showMessageOk(msg);
					////})
					////.then(function () {
					////	def.resolve();
					////});

						self.hideWaitingIndicator(waitingHandler);
						//////if (res.err) {
						//////	return self.showMessageOk("Errore nel pagamento: " + res.err);
						//////}
						if (typeof res === "string" && res.startsWith("http")) {
							window.location.href = res;
						} else {
							self.showMessageOk("URL di pagamento non valido");
						}
					});

				return def.promise();

			},

			base64ToUint8Array: function (base64) {
				// rimuove eventuale prefix "data:application/pdf;base64,"
				const clean = base64.includes("base64,")
					? base64.split("base64,")[1]
					: base64;

				const binary = atob(clean);
				const bytes = new Uint8Array(binary.length);

				for(let i = 0; i<binary.length; i++) {
					bytes[i] = binary.charCodeAt(i);
				}
				return bytes;
			},

			getFileName: function () {
				const now = new Date();

				// yyyyMMdd_HHmmss
				const yyyy = now.getFullYear();
				const MM = String(now.getMonth() + 1).padStart(2, '0'); // mesi da 0 a 11
				const dd = String(now.getDate()).padStart(2, '0');
				const HH = String(now.getHours()).padStart(2, '0');
				const mm = String(now.getMinutes()).padStart(2, '0');
				const ss = String(now.getSeconds()).padStart(2, '0');

				return `avviso_pagamento_${yyyy}${MM}${dd}_${HH}${mm}${ss}.pdf`;
			},

			getAvvisoPagamento: function () {
				var def = appMeta.Deferred("getAvvisoPagamento-debito_stu");
				//dico di atendere
				waitingHandler = this.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
				let self = this;

				let params = {
							iddebito: this.state.currentRow.iddebito,
							//ds: this.state.DS,
							primaryTableName: this.primaryTableName
						};

						return appMeta.callWebService("scaricaAvvisoPagamento", params)

					.then(function (res) {
						var msg = "Avviso scaricato correttamente";
						if (res==null) {
							msg = "Impossibile scaricare Avviso pagamento";
						}
						//riattivo la pagina
						self.hideWaitingIndicator(waitingHandler);
						if (res.err) {
							msg = "Errore scaricato Avviso pagamento: " + res.err;
						}

						const bytes = self.base64ToUint8Array(res);
						const blob = new Blob([bytes], { type: "application/pdf" });
						const url = URL.createObjectURL(blob);
						const a = document.createElement("a");
						a.href = url;
						const filename = self.getFileName();
						a.download = filename;
						document.body.appendChild(a);
						a.click();
						a.remove();
						URL.revokeObjectURL(url);
						//mostro che è tutto ok
						return self.showMessageOk(msg);
					}).then(function () {
						def.resolve();
					});

				return def.promise();
			},

			/**
			 * flusso di immatricolazione/iscrizione
			 * @param {any} idreg
			 * @param {any} iddidprog
			 * @returns un oggetto con tre valori:
			 * iddidprog : 0 se non può prorcedere, altrimenti la didprog da utilizzare per l'iscrizione, iscrizione al test o nel passaggio
			 * delay : se è una icrizione fuori dai termini allora è true (sarà attivata la casella delle motivazioni obbligatoria)
			 * pass : se occorre compilare un passaggio di corso allora è l'idiscrizione_from da inseerire nel passaggio e la iddiprog è quella di arrivo (sarà fatto un redirect)
			 */
			flussoIscrizione: function (idreg, iddidprog) {
				var self = this;
				var def = appMeta.Deferred("flussoIscrizione");
				var waitingHandler = self.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
				//recupero tutte le didattiche possibili per l'iscrizione con eventuali riferimenti a quelle già fatte dallo studente nel medesimo anno accademico
				appMeta.getData.runSelect("didprogiscrizioneview", "*", this.q.and(this.q.eq("idreg", idreg), this.q.eq("iddidprog", iddidprog)))
					.then(function (dt) {
						if (dt.rows.length > 0) {

							//esce una riga per ogni combinazione studente/corso, quindi se escono righe ne esce sempre una sola
							let firstRow = dt.rows[0];

							//GIA' ISCRITTO
							//////////////////////////////

							if (firstRow.idiscrizione) {
								self.hideWaitingIndicator(waitingHandler);
								return self.showMessageOk("Studente già iscritto a questo corso. Non è possibile procedere a una nuova iscrizione per lo stesso corso.")
									.then(function () {
										return def.resolve({ iddidprog: 0, delay: false, pass: 0 });
									});
							}

							//TERMINI DI ISCRIZIONE
							//////////////////////////////

							//se i termini sono scaduti ...
							if ((firstRow.startiscrizioni > new Date() || firstRow.stopiscrizioni < new Date())
								//...e sono bloccanti oppure no ma sei oltre la data massima oltre i termini di iscrizione 
								&& (firstRow.immatoltreauth == 'N' || (firstRow.immatoltreauth == 'S' && firstRow.dataconsmaxiscr < new Date()))) {
								self.hideWaitingIndicator(waitingHandler);
								return self.showMessageOk("Termini di iscrizione scaduti. Non è possibile procedere all'iscrizione al di fuori dei termini di iscrizione.")
									.then(function () {
										return def.resolve({ iddidprog: 0, delay: false, pass: 0 });
									});
							}

							//se sono scaduti mostro un avviso ma lascio procedere
							if (firstRow.startiscrizioni < new Date() && firstRow.stopiscrizioni > new Date() && firstRow.immatoltreauth == 'S') {
								self.hideWaitingIndicator(waitingHandler);
								return self.showMessageOk("Termini di iscrizione scaduti. E' possibile procedere all'iscrizione al di fuori dei termini di iscrizione ma sarà sottoposta ad approvazione.")
									.then(function () {
										return def.resolve({ iddidprog: iddidprog, delay: true, pass: 0 });
									});
							}

							//ISCRIZIONE A NUMERO CHIUSO
							//////////////////////////////

							//se il corso è a numero chiuso devo controllare se ci sono posti liberi
							if (firstRow.iddidprognumchiusokind == 2 || firstRow.iddidprognumchiusokind == 3) {
								//se i termini sono scaduti ...
								if ((firstRow.test_startiscrizioni > new Date() || firstRow.test_stopiscrizioni < new Date())
									//...e sono bloccanti oppure no ma sei oltre la data massima oltre i termini di iscrizione 
									&& (firstRow.test_immatoltreauth == 'N' || (firstRow.test_immatoltreauth == 'S' && firstRow.test_dataconsmaxiscr < new Date()))) {
									self.hideWaitingIndicator(waitingHandler);
									return self.showMessageOk("Termini di iscrizione al test di ingresso scaduti. Non è possibile procedere all'iscrizione al test di ingresso al di fuori dei termini.")
										.then(function () {
											return def.resolve({ iddidprog: 0, delay: false, pass: 0 });
										});
								}

								//se sono scaduti mostroun avviso ma lascio procedere
								if (firstRow.test_startiscrizioni < new Date() && firstRow.test_stopiscrizioni > new Date() && firstRow.test_immatoltreauth == 'S') {
									self.hideWaitingIndicator(waitingHandler);
									return self.showMessageOk("Termini di iscrizione al test di ingresso scaduti. E' possibile procedere all'iscrizione al di fuori dei termini ma sarà assegnato un debito formativo.")
										.then(function () {
											return def.resolve({ iddidprog: firstRow.test_iddidprog, delay: true, pass: 0 });
										});
								}

								//controllose è già iscritto al test se no ritorno la didprog del test (così la pagina sostituirà quella scelta con il rispettivo test)
								if (!firstRow.iscr_test_data) {
									self.hideWaitingIndicator(waitingHandler);
									return self.showMessageOk("Occorre iscriversi alla prova di ammissione per potersi iscrivere a questo corso. State per essere rendirizzati alla pagina di iscrizione alla prova di amissione.")
										.then(function () {
											return def.resolve({ iddidprog: firstRow.test_iddidprog, delay: false, pass: 0 });
										});
								} else {
									//controllo se c'è l'esito altrimenti dico di attendere
									if (!firstRow.iscr_test_esito) {
										self.hideWaitingIndicator(waitingHandler);
										return self.showMessageOk("Occorre attendere l'esito della prova di ammissione per poter porcedere all'iscrizione. Provare più tardi.")
											.then(function () {
												return def.resolve({ iddidprog: 0, delay: false, pass: 0 });
											});
									} else {
										//controllo se l'esito non è positivo
										if (firstRow.iscr_test_esito != 7) {
											self.hideWaitingIndicator(waitingHandler);
											return self.showMessageOk("La prova di ammissione non è stata superata. Non sarà possibile procedere alla iscrizione.")
												.then(function () {
													return def.resolve({ iddidprog: 0, delay: false, pass: 0 });
												});
										}
									}
								}

							}

							//ISCRIZIONE MULTIPLA
							///////////////////////////////

							//se è già iscritto a un altro corso
							if (firstRow.iscr_other_iddidprog) {
								//controllo se c'è un passaggio
								if (!firstRow.ist_pass_idstatuskind) {
									//se non c'è lo deve fare
									self.hideWaitingIndicator(waitingHandler);
									return self.showMessageOk("Prima occorre effettuare una istanza di passaggio di corso dal corso a cui si è attualmente iscritti a questo corso. Sarete redirezionati alla pagina per effettuare l'istanza di passaggio di corso.")
										.then(function () {
											return def.resolve({ iddidprog: iddidprog, delay: false, pass: firstRow.iscr_other_idiscrizione });
										});
								} else {
									//se c'è l'istanza controllo che non sia stata respinta ...
									if (firstRow.ist_pass_diniego_data) {
										//se non c'è lo deve fare
										self.hideWaitingIndicator(waitingHandler);
										return self.showMessageOk("L'istanza di passaggio di corso è stata rifiutata il " + self.stringFromDate_ddmmyyyy(firstRow.ist_pass_diniego_data) + ". Non é possibile procedere all'iscrizione.")
											.then(function () {
												return def.resolve({ iddidprog: 0, delay: false, pass: 0 });
											});
									}
									//o se non è stata ancora accettata
									if (!firstRow.ist_pass_nullaosta_data) {
										//se non c'è lo deve fare
										self.hideWaitingIndicator(waitingHandler);
										return self.showMessageOk("L'istanza di passaggio di corso non è ancora stata perfezionata. Non é possibile procedere all'iscrizione.")
											.then(function () {
												return def.resolve({ iddidprog: 0, delay: false, pass: 0 });
											});
									}

								}
							}

							//SE SONO ARRIVATO FINO A QUI SI PUO' PROCEDERE ALL'ISCRIZIONE
							/////////////////////////////////////
							self.hideWaitingIndicator(waitingHandler);
							return def.resolve({ iddidprog: iddidprog, delay: false, pass: 0 });

						} else {
							self.hideWaitingIndicator(waitingHandler);
							return def.from(self.showMessageOk("Iscrizione impossibile in questo momento. Riprovare più tardi."));
						}
					});

				return def.promise();
			},

			/*********************************************************************
			****************  FUNZIONI PER PERFORMANCE: ***************************
			*********************************************************************/

			thereIsOnlyOneModifedField: function (tableName, fieldName) {
				// _.some() restituisce true se *almeno una* tabella viola la regola
				const isViolationFound = _.some(this.state.DS.tables, function (t) {
					const rowsChanged = t.getChanges();

					if (rowsChanged.length === 0) {
						return false; // Continua (nessuna violazione)
					}

					// 1. Violazione: modifica su una tabella diversa da quella cercata
					if (t.name !== tableName) {
						return true; // Trovata violazione, interrompe e restituisce true
					}

					// Se la tabella è quella giusta, controlla le righe
					// _.some() restituisce true se *almeno una* riga viola la regola
					return _.some(rowsChanged, function (o) {
						const rowState = o.getRow().state;

						// 2. Violazione: riga cancellata o aggiunta (nello scenario "solo un campo modificato")
						if (rowState === dataRowState.deleted || rowState === dataRowState.added) {
							return true; // Trovata violazione, interrompe e restituisce true
						}

						if (rowState === dataRowState.modified) {
							const modifiedFields = o.getRow().getModifiedFields();

							// 3. Violazione: campo modificato diverso da fieldName e non temporaneo ('!')
							if (_.some(modifiedFields, function (f) {
								return f !== fieldName && f[0] !== '!';
							})) {
								return true; // Trovata violazione, interrompe e restituisce true
							}
						}

						return false; // Continua (nessuna violazione in questa riga)
					});
				});

				// Se è stata trovata una violazione, la funzione dovrebbe restituire false (non c'è solo un campo modificato).
				return !isViolationFound;
			},

			getConfPerformance: function () {
				var def = Deferred('getConfPerformance');
				if (!appMeta.appMain.dtConfPerf) {
					return appMeta.getData.runSelect("confperformance", "*", null)
						.then(function (dtConfPerf) {
							appMeta.appMain.dtConfPerf = dtConfPerf;
							return def.resolve();
						})
				}
				return def.resolve();
			},

			getComportamentiAndAteneo: function (listType, listTypeComportamenti) {
				var def = appMeta.Deferred("getCompotamenti");
				var self = this;

				let idAfferenza = !self.state.currentRow.idafferenza ? $('#perfvalutazionepersonale_' + listType + '_idafferenza').val() : self.state.currentRow.idafferenza;
				self.state.currentRow.year = /*!self.state.currentRow.year ?*/ $('#perfvalutazionepersonale_' + listType + '_year').val() /*: self.state.currentRow.year*/;

				if (!this.comportamentiGiaCalcolati && idAfferenza && self.state.currentRow.year) {


					var grid = $('#grid_perfvalutazionepersonalecomportamento_' + listTypeComportamenti).data("customController");
					var gridAteneo = $('#grid_perfvalutazionepersonaleateneo_default').data("customController");

					var IsIn = false;
					var chain = $.when(); //inizializzo la chain

					var waitingHandler = self.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);

					appMeta.callWebService("calcolaComportamenti",
						{
							idAfferenza: idAfferenza,
							year: self.state.currentRow.year
						}).then(function (resDS) {

							//per assicurarsi di farlo una volta sola
							self.comportamentiGiaCalcolati = true;

							var DS = appMeta.getDataUtils.getJsDataSetFromJson(resDS);
							//---------------aggiorno i pesi ----------------------------------
							if (self.state.isInsertState() || self.state.isEditState()) {
								if (DS.tables.mansionekind) {
									var mansionekindDt = DS.tables.mansionekind;
									if (self.state.DS.tables["perfvalutazionepersonaleateneo"] && self.state.DS.tables["perfvalutazionepersonaleateneo"].rows.length) {
										var valAteneo = self.state.DS.tables["perfvalutazionepersonaleateneo"].rows[0];
										valAteneo.peso = mansionekindDt.rows[0].pesoateneo;
										valAteneo.punteggiopesato = valAteneo.punteggio * valAteneo.peso / 100;
										if (!valAteneo.punteggiopesato)
											valAteneo.punteggiopesato = 0;
									}
									self.state.currentRow.pesoateneo = mansionekindDt.rows[0].pesoateneo;
									$('#perfvalutazionepersonale_' + listType + '_pesoateneo').val(mansionekindDt.rows[0].pesoateneo)
									self.state.currentRow.pesoperfuo = mansionekindDt.rows[0].pesouo;
									$('#perfvalutazionepersonale_' + listType + '_pesoperfuo').val(mansionekindDt.rows[0].pesouo)
									//solo la prima volta perchè il valutatore li può azzerare!!!!!
									if (self.isNullOrNotANumber(self.state.currentRow.pesocomportamenti)) {
										self.state.currentRow.pesocomportamenti = mansionekindDt.rows[0].pesocomp;
										$('#perfvalutazionepersonale_' + listType + '_pesocomportamenti').val(mansionekindDt.rows[0].pesocomp);
									}
									//solo la prima volta perchè il valutatore li può azzerare!!!!!
									if (self.isNullOrNotANumber(self.state.currentRow.pesoobiettivi)) {
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
							if (self.getDataTable('perfvalutazionepersonalecomportamentosoglia') && self.getDataTable('perfvalutazionepersonalecomportamentosoglia').rows.length == 0) {

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
							if (gridAteneo && gridAteneo.gridRows.length == 0) {
								appMeta.metaModel.getTemporaryValues(self.getDataTable("perfvalutazionepersonaleateneo"));
							}
							return grid.fillControl().then(function () {
								if (gridAteneo)
									return gridAteneo.fillControl();
								else {
									let d = new Deferred('d');
									return d.resolve();
								}
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

			sleep: function (ms) {
					const end = Date.now() + ms;
					while(Date.now() < end) { }
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

				//attendo un piccolo ritardo per non essere bannato dal server SMTP
				var delayMs = (objPrm && objPrm.delayMs) ? objPrm.delayMs : 0;
				self.sleep(delayMs);

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
			* Calcola il punteggio, inserendo un valore        
			* @param arraySoglieIndicatori: contenente la lista delle soglie, del tipo {indicatore: punteggio, soglia: percentuale}
			* @param valorenumerico: valore da cui calcolare il completamento
			*/
			calculatePunteggioByPercentuale: function (arraySoglieIndicatori, percentuale) {

				if (!percentuale || percentuale == '') percentuale = '0';

				if (arraySoglieIndicatori.length === 0)
					return 0;

				//trovo la soglia la cui percentuale è la più alta di tutte ma che sia minore o uguale a quella passata come parametro
				var soglia = _.maxBy(_.filter(arraySoglieIndicatori, function (x) { return x.soglia <= parseFloat(percentuale.replace(',', '.'))  }), function (x) {
                    return x.soglia;
				});

				if (soglia)
					return soglia.indicatore;
				else
                    return 1;
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
					if (soglia < 0) {
						//... sono sotto alla soglia minima e torno 0
						return 0;
					}
					obj1 = rowsordinate[1];
					obj2 = rowsordinate[2];
				} else if (index === rowsordinate.length - 1) {

					index = rowsordinate.length - 1;
					var obj = rowsordinate[index - 1];
					var soglia = obj.soglia;
					if (soglia < 0) {
						return 0;
					}
					obj1 = rowsordinate[index - 1];
					obj2 = rowsordinate[Math.abs(index - 2)];
				} else {

					obj1 = rowsordinate[index - 1];
					obj2 = rowsordinate[index + 1];
				}

				var res = (((obj2.soglia - obj1.soglia) / (obj2.indicatore - obj1.indicatore)) * (valorenumerico - obj1.indicatore)) + obj1.soglia;
				//se la percentuale è inferiore a zero torno zero
				res = res < 0 ? 0 : res;
				//se la percentuale è più del 100% la ritorno solo se consentito dalla configurazione
				if ((appMeta.appMain.dtConfPerf.rows[0].denyoverpercent == 'S'))  
					res = res > 100 ? 100 : res;
				//in ogni caso TRONCO e non restituisco oltre il terzo decimale perchè in caso di soglie ravvicinate (<=0,1) gli arrotondamenti ti spostano sulla soglia successiva
				return Math.trunc(res * 100) / 100;

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
					return _.round((numeratore / denominatore), 2);

				}

				return 0;
			},

			loadRulesPerson: function (arraydef, dt, action, objective, colName, tablename, controlId) {
				var self = this;
				var valutatori = dt.select(self.q.and(self.q.eq('escluso', 'N'), self.q.eq(action, 'S'), self.q.eq(objective, 'S')));

				if (valutatori.length > 0) {
					var valutatoriOrd = _.orderBy(valutatori, ['resplevel', 'stop', 'start'], ['desc', 'desc', 'desc'])
					self.state.currentRow[colName] = valutatoriOrd[0].idreg;
					// se più di uno e ho scelto se stesso ...
					if (valutatori.length > 1 && self.state.currentRow.idreg == self.state.currentRow[colName]) {
						//... allora prendo l'altro
						var valutatoriFilter = _.filter(valutatori, function (o) {
							return o.idreg != self.state.currentRow.idreg;
						});
						if (valutatoriFilter.length > 0) {
							valutatoriOrd = _.orderBy(valutatoriFilter, ['resplevel', 'stop', 'start'], ['desc', 'desc', 'desc'])
							self.state.currentRow[colName] = valutatoriOrd[0].idreg;
							//se è un campo nascosto il tablename non c'è ma il controllo si e va popolato
							if (!tablename && !!controlId)
								$('#' + controlId).val(valutatoriOrd[0].idreg);
						}
					}
					// se uno e ho non ho scelto se stesso va bene
					else if (valutatori.length && self.state.currentRow.idreg != self.state.currentRow[colName]) {

						var valutatoriFilter = _.filter(valutatori, function (o) {
							return o.idreg != self.state.currentRow.idreg;
						});
						if (valutatoriFilter.length > 0) {
							valutatoriOrd = _.orderBy(valutatoriFilter, ['resplevel', 'stop', 'start'], ['desc', 'desc', 'desc'])
							self.state.currentRow[colName] = valutatoriOrd[0].idreg;
							//se è un campo nascosto il tablename non c'è ma il controllo si e va popolato
							if (!tablename && !!controlId)
								$('#' + controlId).val(valutatoriOrd[0].idreg);
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

				if (!!tablename && !!controlId) {
					appMeta.metaModel.cachedTable(self.getDataTable(tablename), false);
					var perfvalutazionepersonale_default_idreg_valCtrl = $('#' + controlId).data("customController");
					arraydef.push(perfvalutazionepersonale_default_idreg_valCtrl.filteredPreFillCombo(filterListValutatori, null, true)
						.then(function (dt) {
							if (self.state.currentRow && self.state.currentRow[colName])
								return perfvalutazionepersonale_default_idreg_valCtrl.fillControl(null, self.state.currentRow[colName]);
							return true;
						})
					);
				}
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
								return ur.aggiorna === 'S' && (ur.obiettivi_unatantum === 'S' || ur.obiettivi_organizzativi === 'S')
							});
							self.valuta_ut = userRight.some(function (ur) {
								return ur.valuta === 'S' && (ur.obiettivi_unatantum === 'S' || ur.obiettivi_organizzativi === 'S')
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
								return ur.aggiorna === 'S' && (ur.obiettivi_unatantum === 'S' || ur.obiettivi_organizzativi === 'S')
							});
							self.valuta_ut = userRight.some(function (ur) {
								return ur.valuta === 'S' && (ur.obiettivi_unatantum === 'S' || ur.obiettivi_organizzativi === 'S')
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

																body = "Buongiorno";// "Gentile " + recapito;

																if (destinatario[0] != self.state.currentRow.idreg) {

																	body += ", <br /> l'/il " + ruoloLoggato + " " + loggato + " ha modificato lo stato " + description + " di " + valutato + ", in  \"" + dsStato.rows[0].title + "\"<br />";
																	subject += " di " + valutato;
																}
																else body += ", <br /> lo stato " + description + " è stato modificato in \"" + dsStato.rows[0].title + "\"<br />";

																if (withMotivazioni == true && (self.valuta_ind == true || self.valuta_co == true)) {
																	body += "<br />Motivazioni della Valutazione:<br />" + $('#perfvalutazionepersonale_' + listType + '_motivazione').val() + "<br />";
																}
																body += "<br /><a href=\"" + document.URL.split('?')[0] + "\">Vai al portale<\a>";

																sendMail += dsRows[0].email + ";";
																return self.superClass.sendMail({ emailDest: dsRows[0].email, body: body, subject: subject, viewMessage: false, delayMs:1000 })

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
							dataSetTable.autoIncrement('idperfvalutazionepersonalestatuschanges', { minimum: 99990001 });
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
									self.secondSave = true;
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

								arrayDef.push(self.superClass.sendMail({ emailDest: row.email, body: body, subject: subject, viewMessage: false, delayMs: 1000 }));
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
							dataSetTable.autoIncrement('idperfvalutazioneuostatuschanges', { minimum: 99990001 });
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
									self.secondSave = true;
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
				let self = this;
				var filterComplete = this.q.or(filter, this.q.eq('idreg', this.idreg_istituto));
				return appMeta.getData.runSelect("getcalendareventview",
					"color, title, start, stop, ore, idlezione, idassetdiary, idrendicontattivitaprogetto, idprogetto", filterComplete, null)
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
						//memorizzo il dataset in una variabile di pagina
						self[calendar.tag] = dt;
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
			setRealStartStop: function (wpStart, wpStop, membroStart, membroStop, prorogaRow, progettoStart, progettoStop) {

				if (!progettoStart) progettoStart = new Date(1900, 0, 1);
				if (!wpStart) wpStart = new Date(1900, 0, 1);
				if (!membroStart) membroStart = new Date(1900, 0, 1);

				this.start = progettoStart;
				this.startMessage = 'a quella dell\'inizio del progetto (' + this.stringFromDate_ddmmyyyy(progettoStart) + ')';
				if (wpStart > this.start) {
					this.start = wpStart;
					this.startMessage = 'a quella dell\'inizio del workpackage (' + this.stringFromDate_ddmmyyyy(wpStart) + ')';
				} 
				if (membroStart > this.start) {
					this.start = membroStart;
					this.startMessage = 'all\'inizio della partecipazione del membro (' + this.stringFromDate_ddmmyyyy(membroStart) + ')';
				}

				if (!progettoStop) progettoStop = new Date(2100, 0, 1);
				if (!wpStop) wpStop = new Date(2100, 0, 1);
				if (!membroStop) membroStop = new Date(2100, 0, 1);

				this.stop = progettoStop;
				this.stopMessage = 'a quella finale del progetto (' + this.stringFromDate_ddmmyyyy(progettoStop) + ')';
				//se c'è una proroga allora la data di fine è della proroga
				if (prorogaRow) {
					this.stop = prorogaRow.proroga;
					this.stopMessage = 'a quella della proroga (' + this.stringFromDate_ddmmyyyy(prorogaRow.proroga) + ')';
				}
				else {
					//altrimenti è la più piccola tra il membro e il wp
					if (wpStop < this.stop) {
						this.stop = wpStop;
						this.stopMessage = 'a quella finale del workpackage (' + this.stringFromDate_ddmmyyyy(wpStop) + ')';
					} 
					if (membroStop < this.stop) {
						this.stop = membroStop;
						this.stopMessage = 'alla fine della partecipazione del membro (' + this.stringFromDate_ddmmyyyy(membroStop) + ')';
					}
				}

				if (this.state.DS.tables.rendicontattivitaprogettoora) 
					if (this.state.DS.tables.rendicontattivitaprogettoora.rows.length) {
					this.oreNonCancellate = this.state.DS.tables.rendicontattivitaprogettoora.rows.filter(function (row) {
						return row.getRow().state !== jsDataSet.dataRowState.deleted;
					});
					if (this.oreNonCancellate.length) {
						this.oraStart = _.orderBy(this.oreNonCancellate, 'data', 'asc')[0].data;
						this.oraStop = _.orderBy(this.oreNonCancellate, 'data', 'desc')[0].data;
						//La data di inizio della attività deve essere precedente 
						this.oraStartMessage = 'alla prima ora già rendicontata (' + this.stringFromDate_ddmmyyyy(this.oraStart) + ')';
						//La data di fine della attività deve essere successiva 
						this.oraStopMessage = 'all\'ultima ora già rendicontata (' + this.stringFromDate_ddmmyyyy(this.oraStop) + ')';
					}
					else {
						this.oraStart = null;
						this.oraStop = null;
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


			// Funzione di utilità per garantire la robustezza delle Date
			isValidDate: function(d) {
				// 1. Controlla se è un oggetto Date
				return d instanceof Date &&
					// 2. Controlla se il valore numerico non è NaN
					!isNaN(d);
			},

			/** 
			 * imposta e filtra la chekboxlist delle missioni nella maschera delle attività
			 */
			setFilterRendicontattivitaprogettoItineration: function () {
				var self = this;

				// --- Filtro Start ---
				// Tenta di creare una nuova data, assicurandosi di non lanciare errori e usa null se il campo manca
				const rowStopDate = self.state.currentRow?.stop ? new Date(self.state.currentRow.stop) : null;
				// Se la data creata è valida, usala, altrimenti usa new Date()
				const startCompareDate = self.isValidDate(rowStopDate) ? rowStopDate : new Date();

				var filterstart = self.q.lt('start', startCompareDate);

				// --- Filtro Stop ---
				// Tenta di creare una nuova data, assicurandosi di non lanciare errori
				const rowPrevStart = self.state.currentRow?.datainizioprevista ? new Date(self.state.currentRow.datainizioprevista) : null;
				// Se la data creata è valida, usala, altrimenti usa new Date()
				const stopCompareDate = self.isValidDate(rowPrevStart) ? rowPrevStart : new Date();

				var filterstop = self.q.gt('stop', stopCompareDate);

				// --- Filtro Membro ---
				var filtermembro = self.q.eq('idreg', self.state.currentRow ? self.state.currentRow.idreg : 0);
				//var filterstart = self.q.lt('start', self.state.currentRow ? (self.state.currentRow.stop ? self.state.currentRow.stop : new Date()) : new Date());
				//var filterstop = self.q.gt('stop', self.state.currentRow ? (self.state.currentRow.datainizioprevista ? self.state.currentRow.datainizioprevista : new Date()) : new Date());
				var filter = self.q.and([filtermembro, filterstart, filterstop]);
				this.state.DS.tables.itineration.staticFilter(filter);
				this.getDataTable('itineration').clear();
				var checkListCtrl = $("[data-tag='itineration.seg.seg']");
				var ctrl = checkListCtrl.data("customController");
				if (ctrl) {
					//return ctrl.loadCheckBoxList();
					var selBuilderArray = [];
					selBuilderArray.push({ filter: filter, top: null, tableName: 'itineration', table: self.getDataTable('itineration') });
					return appMeta.getData.multiRunSelect(selBuilderArray)
						.then(function () {
							//ripulisco la checkbox 
							return ctrl.clearControl()
						})
						.then(function () {
							//faccio il fill control della checkbox 
							return ctrl.fillControl(checkListCtrl);
						});
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

				////ricavo tutte le foreignkey verso la tabella sal che sono in rendicontattivitaprogettoora
				//var salIds = _.filter(page.getDataTable('rendicontattivitaprogettoora').rows, function (r) { return !!r.idsal });
				////se anche solo uno non c'è sulla tabella sal allora faccio la query
				//if (!salIds.some(function (id) {
				//	return _.map(page.getDataTable('sal').rows, function (r) {
				//		return r.idsal;
				//	}).includes(id);
				//})) {
				//	page.filtersalIds = page.q.isIn('idsal',
				//		_.map(salIds, function (r) {
				//			return r.idsal;
				//		}));

				//	selBuilderArrayFK.push({ filter: page.filtersalIds, top: null, tableName: 'sal', table: page.getDataTable('sal') });
				//}


				//ricavo tutti i sal dei progetti relativi a rendicontattivitaprogettoora
				var progIds = _.filter(page.getDataTable('rendicontattivitaprogettoora').rows, function (r) { return !!r.idprogetto });
				//se anche solo uno non c'è sulla tabella sal allora faccio la query
				if (!progIds.some(function (id) {
					return _.map(page.getDataTable('sal').rows, function (r) {
						return r.idpogetto;
					}).includes(id);
				})) {
					page.filterprogIds = page.q.isIn('idprogetto',
						_.map(progIds, function (r) {
							return r.idprogetto;
						}));

					selBuilderArrayFK.push({ filter: page.filterprogIds, top: null, tableName: 'sal', table: page.getDataTable('sal') });
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

			getDaysAndMonthByDates: function (start, stop, stops, addAlwaysOneDay) {

				if (this.isNull(addAlwaysOneDay)) addAlwaysOneDay = true; //di default considero il giorno di inizio come appartenente all'intervallo

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
									if (stopWork.start >= start && stopWork.stop < stop) {
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
							daysUntilEndOfMonth = lastDayOfMonth - start.getDate() + (addAlwaysOneDay ? 1 : 0); //il giorno di start va compreso
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
						//caso dei giorni dello stesso mese ...
						//...se è dal primo all'ultimo giorno vale un mese intero a prescindere dalla durata
						if (start.getDate() == 1 && stop.getDate() == new Date(stop.getFullYear(), stop.getMonth() + 1, 0).getDate()) 
							return { gg: 0, mm: 1, aa: 0 };
						else
							return { gg: stop.getDate() - start.getDate() + (addAlwaysOneDay ? 1 : 0) - anzianitaDiRitardo.gg, mm: 0 - anzianitaDiRitardo.mm, aa: - anzianitaDiRitardo.aa };
					}
				}

				if (start && stop && (
					start.getFullYear() == stop.getFullYear() || start.getMonth() == stop.getMonth() || start.getDate() == stop.getDate()
				))
					return { gg: 1, mm: 0, aa: 0 };

				return { gg: 0, mm: 0, aa: 0 };
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

								let figura = (servizioRow['!idposition_position_title'] ? servizioRow['!idposition_position_title'] : '');
								let classe = (servizioRow['!idclassconsorsuale_classconsorsuale_description'] ? servizioRow['!idclassconsorsuale_classconsorsuale_title'] + ' ' + servizioRow['!idclassconsorsuale_classconsorsuale_description'] : '');
								let nomina = (servizioRow['!idtiponomina_tiponomina_title'] ? servizioRow['!idtiponomina_tiponomina_title'] : '');

								let isRuolo = servizioTable == 'registrylegalstatus';
								if (isRuolo == true && self.state.currentRow) {
									let ssd = _.find(self.state.DS.tables.sasddefaultview.rows, function (o) {
										return o.idsasd == self.state.currentRow.idsasd;
									});
									if (ssd) {
										classe = ssd.dropdown_title;
									}
									nomina = 'TEMPO INDETERMINATO';
								}

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
										maxStart: new Date(parseInt(annoCoinvolto.substring(5, 9)), 0, 1),
										begin: begin,
										end: end
									};

									anno.servizioRows.push(servizioRow);
									anno.servizi.push({
										inizio: self.stringFromDate_ddmmyyyy(servizioRow.start),
										fine: self.stringFromDate_ddmmyyyy(servizioRow.stop),
										start: servizioRow.start,
										stop: servizioRow.stop,
										anni: servizioRow.anni,
										mesi: servizioRow.mesi,
										giorni: servizioRow.giorni,
										istituzione: servizioRow.istituzione,
										figura: figura,
										classe: classe,
										nomina: nomina
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
										start: servizioRow.start,
										stop: servizioRow.stop,
										anni: servizioRow.anni,
										mesi: servizioRow.mesi,
										giorni: servizioRow.giorni,
										istituzione: servizioRow.istituzione,
										figura: figura,
										classe: classe,
										nomina: nomina
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
					if (self.state.DS.tables.ricostruzioneperiodonv) {
						_.forEach(self.getDataTable('ricostruzioneperiodonv').rows, function (nvRows) {
							if (nvRows.aa_start <= annoAccademico.annoAccademico && nvRows.aa_stop >= annoAccademico.annoAccademico) {
								invalidYear = true;
								annoAccademico.anninonvalidi.push({ Anno_accademico_inizio: nvRows.aa_start, Anno_accademico_fine: nvRows.aa_stop })
							}
						});
					}

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
				//NOTA MOLTO BENE!! devo togliere gli eventuali negativi perchè andado a sottrarre i giorni dai mesi di lunghezze differenti ottengo risultati diversi mentre aggiungendo al primo del mese no
				let diff = this.reevaluateDaysAndMonth({ aa: diffA, mm: diffM, gg: diffG });
				if (start) {
					dataCorrente = new Date(start);
					if (stops) {
						let self = this;
						let anzianitaFinale = { gg: giorniTo, mm: mesiTo, aa: anniTo };
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
						//se non è inferiore al mese e ci sono dei giorni di differenza
						if (diff.aa + diff.mm > 0 && diff.gg > 0) {
							//se si tratta di una differenza di mesi o anni ...
							let isBisestile = (dataCorrente.getFullYear() % 4) == 0;

							//se è il primo del mese DI PARTENZA vale il mese intero a prescindere oppure se è un mese di 30 gg
							if (dataCorrente.getDate() == 1 || [3, 5, 8, 10].contains(dataCorrente.getMonth())) {
								dataCorrente.setDate(dataCorrente.getDate() + diff.gg);
							}
							else {
								//se il mese DI PARTENZA  dura 31
								//e parto in mezzo al mese
								//e la somma supera il 31
								//avrò in giorno in più alla fine e quindi raggiungo l'anziantià finale il giorno prima
								if ([0, 2, 4, 6, 7, 9, 11].contains(dataCorrente.getMonth())) {
									if ((dataCorrente.getDate() + diff.gg) > 31)
										dataCorrente.setDate(dataCorrente.getDate() + diff.gg - 1);
									else
										dataCorrente.setDate(dataCorrente.getDate() + diff.gg);
								}
								else {
									//se febbraio
									//e parto in mezzo al mese
									//e la somma supera il 28 o 29
									//due o un giorno più tardi
									if ((dataCorrente.getDate() + diff.gg) > (isBisestile ? 29 : 28))
										dataCorrente.setDate(dataCorrente.getDate() + diff.gg + (isBisestile ? 1 : 2));
									else
										dataCorrente.setDate(dataCorrente.getDate() + diff.gg);
								}
							}
						} else {
							//... ma se la differenza è inferiore al mese è una somma semplice
							dataCorrente.setDate(dataCorrente.getDate() + diff.gg);
						}

						dataCorrente.setFullYear(dataCorrente.getFullYear() + diff.aa);
						dataCorrente.setMonth(dataCorrente.getMonth() + diff.mm);

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
			getLineaByFasceServizi: function (stipendioOrd, tipoParagrafo, metaPage, dataPresaServizio, virtualDataPresaServizio, dataConfluimento, anniConfluimento,
				anzianitaStartA, anzianitaStartM, anzianitaStartG, stops, firstIdposition, services, dataStopDecreto) {

				//si suppone che al più tardi l'ultimo articolo dopo la data del decreto sia relativo ad un evento entro i 7 anni perchiè le fasce al massimo sono di 6 anni
				let dataStopArticoli = new Date(dataStopDecreto);
				dataStopArticoli.setFullYear(dataStopDecreto.getFullYear() + 7);
				var lineaStipendio = [];
				//anzianità di partenza
				var currentAnzianita = { aa: anzianitaStartA, mm: anzianitaStartM, gg: anzianitaStartG };

				var self = this;
				//Ciclo sui servizi che hanno già i buchi delle interruzioni, quindi non le devo più considerare
				_.forEach(services, function (serviceCurr) {

					//per ogni servizio memorizzo l'anzianità a cui sono arrivato come la sua anziantià di partenza per calcolare poi tutte le anzianità delle inee temporali in cui viene spezzato
					//lo devo fare altrimenti linee diverse con durate diverse producono necessariamente cambi di facia per anzianità in giorni diversi
					//così facendo se un'anziantà di fascia viene raggiunta, sarà raggiunta sempre lo stesso giorno a prescindere da quanti spezzoni di linea temporale ho generato 
					let currentAnzianitaServizio = currentAnzianita;

					let anzianitaAcquisita = self.getDaysAndMonthByDates(serviceCurr.start, (serviceCurr.stop ? serviceCurr.stop : dataStopArticoli));
					let currentAnzianitaFinale = self.anzianitaSum(currentAnzianita, anzianitaAcquisita);
					//la fascia iniza con il servizio
					let currentDate = new Date(serviceCurr.start);

					//fitro i soli stipendi convolti  per figura, validità e anzianità ---------------------------------------
					let stipendiCurr = _.filter(stipendioOrd, function (stipendioFascia) {
							//solo stipendi pertinenti alla figura contrattuale
						return stipendioFascia.idposition == (serviceCurr.idposition ? serviceCurr.idposition : firstIdposition) 
							//inizio validità stipendo successivo alla fine fascia
							&& (serviceCurr.stop ? serviceCurr.stop : dataStopArticoli) > (stipendioFascia.start ? stipendioFascia.start : new Date(1970, 0, 1))
							//fine validità stipendio precedente all'inizio fascia
							&& serviceCurr.start < (stipendioFascia.stop ? stipendioFascia.stop : dataStopArticoli)
							//escludo stipendi che non raggiungono l'anzialità corrente
							&& (stipendioFascia.anzianitamax ? stipendioFascia.anzianitamax : 100) >= currentAnzianita.aa
							//escludo stipendi che sono di anzianità superiori a quella finale
							&& (stipendioFascia.anzianitamin ? stipendioFascia.anzianitamin : 0) <= currentAnzianitaFinale.aa
					});

					if (stipendiCurr.length) {
						_.forEach(stipendiCurr, function (stipendioCurr) {
							let tipo = tipoParagrafo;
							let currentAnzianitaPrimoGiornoServizioCorrente = self.reevaluateDaysAndMonth({ aa: currentAnzianita.aa, mm: currentAnzianita.mm, gg: currentAnzianita.gg + 1 })
							//procedo solo se l'anzianità e la validità dello stipendio sono ancora compatibili con quella corrente
							if ((stipendioCurr.stop ? stipendioCurr.stop : dataStopArticoli) > currentDate
								&& (stipendioCurr.start ? stipendioCurr.start : new Date(1900, 0, 1)) <= currentDate
								&& (stipendioCurr.anzianitamin ? stipendioCurr.anzianitamin : 0) <= currentAnzianitaPrimoGiornoServizioCorrente.aa
								&& (stipendioCurr.anzianitamax ? stipendioCurr.anzianitamax : 100) >= currentAnzianita.aa) {

								let isChangeFasciaForAnzianta = false;
								//se l'inizio della fascia corrente corrisponde a quello calcolato in base alla anzianità di partenza è un cambio fascia
								if (currentAnzianitaPrimoGiornoServizioCorrente.aa == (stipendioCurr.anzianitamin ? stipendioCurr.anzianitamin : 0)
									&& currentAnzianitaPrimoGiornoServizioCorrente.mm == 0 && currentAnzianitaPrimoGiornoServizioCorrente.gg == 0
									&& tipo == 1)
									isChangeFasciaForAnzianta = true;

								//faccio partire la fascia dalla data a cui sono arrivato a calcolare
								//che in partenza è quella del servizio
								//e la currentAnzianita è quella di partenza del servizio
								let dataInizioFasciaCorrente = new Date(currentDate);

								//OPZIONE 0 faccio finire la fascia con il servizio ...
								//e la currentAnzianitaFinale è quella di fine del servizio + 1 giorno
								let dataFineFasciaCorrente = (serviceCurr.stop ? serviceCurr.stop : dataStopArticoli); 
								let dataInizioFasciaSuccessiva =  new Date(dataFineFasciaCorrente);
								if (dataInizioFasciaSuccessiva)
									dataInizioFasciaSuccessiva.setDate(dataInizioFasciaSuccessiva.getDate() + 1);

								//calcolo quando scatta l'anzianità successiva
								//(partendo dal primo giorno del servizio e non dall'ultimo del precedente aggiungo un giorno all'anzianità per allineare l'anzianità al giorno in più da cui parto con il calcolo)
								let dataScattoSuccessivo = self.getDateByStartAndAnzianita(dataInizioFasciaCorrente,
									currentAnzianitaPrimoGiornoServizioCorrente.aa, currentAnzianitaPrimoGiornoServizioCorrente.mm, currentAnzianitaPrimoGiornoServizioCorrente.gg,
									(stipendioCurr.anzianitamax ? stipendioCurr.anzianitamax : 100) + 1, 0, 0, null, null);

								let currentAnzianitaFinaleAlreadyCalc = false;

								//se matura o scade la validità dello stipendio prima del servizio ...
								if (dataScattoSuccessivo < dataFineFasciaCorrente || (stipendioCurr.stop ? stipendioCurr.stop : dataStopArticoli) < dataFineFasciaCorrente) {
									//verifico se finisce prima la validità dello stipendio o se il soggetto matura una anziantià superiore
									if (dataScattoSuccessivo > (stipendioCurr.stop ? stipendioCurr.stop : dataStopArticoli)) {
										//OPZIONE 1...ma se lo stipendio finisce la sua validità prima ...
										if ((stipendioCurr.stop ? stipendioCurr.stop : dataStopArticoli) < dataFineFasciaCorrente) {
											//faccio finire la fascia con lo stipendio ...
											//e la currentAnzianitaFinale è quella di fine dello stipendio + 1 giorno
											dataFineFasciaCorrente = stipendioCurr.stop;
											dataInizioFasciaSuccessiva = (stipendioCurr.stop ? new Date(stipendioCurr.stop) : null);
											if (dataInizioFasciaSuccessiva)
												dataInizioFasciaSuccessiva.setDate(dataInizioFasciaSuccessiva.getDate() + 1);
										}
									} else {
										//OPZIONE 2 ... ma se l'anzianità viene raggiunta prima
										//faccio finire la fascia il giorno prima che aumenti l'anzianità ...
										//e la currentAnzianitaFinale è quella che maturerà il giorno dopo
										dataInizioFasciaSuccessiva = new Date(dataScattoSuccessivo);
										dataFineFasciaCorrente = new Date(dataScattoSuccessivo.setDate(dataScattoSuccessivo.getDate() - 1));
										//l'anzianità è quella di inizio fascia successiva - un giorno
										currentAnzianitaFinale = self.reevaluateDaysAndMonth({ aa: (stipendioCurr.anzianitamax ? stipendioCurr.anzianitamax : 100) + 1, mm: 0, gg: -1 });
										currentAnzianitaFinaleAlreadyCalc = true;
									}
								}
								//altrimenti OPZIONE 0 lascio tutto com'è

								if (!currentAnzianitaFinaleAlreadyCalc)
									//calcolo l'anzianità finale si parte sempre dall'anzianità iniziale del servizio per non avere difformità su linee diverse con suddivisioni temporali un numero o durata diversi
									currentAnzianitaFinale = (dataFineFasciaCorrente ?
										//self.anzianitaSum({ aa: currentAnzianita.aa, mm: currentAnzianita.mm, gg: currentAnzianita.gg }, self.getDaysAndMonthByDates(dataInizioFasciaCorrente, dataFineFasciaCorrente))
										self.anzianitaSum(currentAnzianitaServizio, self.getDaysAndMonthByDates(serviceCurr.start, dataFineFasciaCorrente))
										: currentAnzianita);

								//se la fascia comincia alla presa sevizio
								if (dataInizioFasciaCorrente.getTime() == dataPresaServizio.getTime() && tipo == 1)
									//il paragrafo è quello iniziale
									tipo = 0;


								lineaStipendio.push({
									start: stipendioCurr.start,
									stop: stipendioCurr.stop,
									anzianitaMin: stipendioCurr.anzianitamin,
									anzianitaMax: stipendioCurr.anzianitamax,
									stipendio: stipendioCurr.stipendio,
									iis: stipendioCurr.iis,
									lordonotredicesima: stipendioCurr.lordonotredicesima,
									complementomensile: stipendioCurr.complementomensile,
									rifnormativo: stipendioCurr.rifnormativo,

									figura: serviceCurr["!idposition_position_title"],
									stipendioFascia: stipendioCurr,
									startFascia: new Date(dataInizioFasciaCorrente),
									stopFascia: (dataFineFasciaCorrente ? new Date(dataFineFasciaCorrente) : null),
									anzianita: currentAnzianita,
									tipo: tipo,
									isChangeFasciaForAnzianta: isChangeFasciaForAnzianta
								});

								//riparto dalla anziantà finale + 1 giorno
								currentAnzianita = currentAnzianitaFinale;
								//riparto dal giorno dopo
								currentDate = dataInizioFasciaSuccessiva
							}
						});
					}
					else {
						//se non ci sono stipendi compatibili deve avanzare comunque l'anzianità corrente
						let dataInizioFasciaCorrente = new Date(currentDate);
						let dataFineFasciaCorrente = (serviceCurr.stop ? serviceCurr.stop : dataStopArticoli);
						let dataInizioFasciaSuccessiva = new Date(dataFineFasciaCorrente);
						if (dataInizioFasciaSuccessiva)
							dataInizioFasciaSuccessiva.setDate(dataInizioFasciaSuccessiva.getDate() + 1);

						currentAnzianita = (dataFineFasciaCorrente ?
							self.anzianitaSum({ aa: currentAnzianita.aa, mm: currentAnzianita.mm, gg: currentAnzianita.gg }, self.getDaysAndMonthByDates(dataInizioFasciaCorrente, dataFineFasciaCorrente))
							: currentAnzianita);
						currentDate = dataInizioFasciaSuccessiva

					}
				});
				return lineaStipendio;
			},

			getLineaByFasce: function (stipendioOrd, tipoParagrafo, metaPage, dataPresaServizio, virtualDataPresaServizio, dataConfluimento, anniConfluimento,
				anzianitaStartA, anzianitaStartM, anzianitaStartG, stops) {
				var lineaStipendio = [];
				var currentAnzianita = { aa: anzianitaStartA, mm: anzianitaStartM, gg: anzianitaStartG };
				var currentDataPresaServizio = new Date(dataPresaServizio);
				var currentVirtualDataPresaServizio = new Date(virtualDataPresaServizio);
				var currentDataConfluimento = new Date(dataConfluimento);

				//per ogniuno 
				_.forEach(stipendioOrd, function (stipendioCurr) {
					var tipo = tipoParagrafo;
					var tempCurrentAnzianita = currentAnzianita;
					let stipendioCurrStart = (stipendioCurr.start ? stipendioCurr.start : new Date(1970, 0, 1));
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
								(dataFineFasciaCorrente ? dataFineFasciaCorrente : new Date(2150, 0, 1)) < stipendioCurrStart 
								 //fine validità stipendio precedente all'inizio fascia
								|| dataInizioFasciaCorrente > (stipendioCurr.stop ? stipendioCurr.stop : new Date(2150, 0, 1))
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
							((f.start ? f.start.getTime() : new Date(1900, 0, 1)) <= scadenza.data.getTime() && (f.stop ? f.stop.getTime() : new Date(2160, 0, 1)) >= scadenza.data.getTime());
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
			},

			getAmountsByScadenza: function (scadenza) {
				var stipendio = _.find(scadenza.fasce, function (f) {
					return f.tipo == 0 || f.tipo == 1 || f.tipo == 4;
				});

				if (!stipendio)
					stipendio = {
						rifnormativo: "",
						stipendio: 0,
						iis: 0,
						lordonotredicesima: 0
					};

				if (!stipendio.rifnormativo)
					stipendio.rifnormativo = "";
				if (!stipendio.stipendio)
					stipendio.stipendio = 0;
				if (!stipendio.iis)
					stipendio.iis = 0;
				if (!stipendio.lordonotredicesima)
					stipendio.lordonotredicesima = 0;

				var ivc = _.find(scadenza.fasce, function (f) {
					return f.tipo == 2;
				});
				if (!ivc)
					ivc = { complementomensile: 0 };

				var rpd = _.find(scadenza.fasce, function (f) {
					return f.tipo == 3;
				});
				if (!rpd)
					rpd = { complementomensile: 0 };
				var cia = _.find(scadenza.fasce, function (f) {
					return f.tipo == 5;
				});
				if (!cia)
					cia = { complementomensile: 0 };

				var ia = _.find(scadenza.fasce, function (f) {
					return f.tipo == 6;
				});
				if (!ia)
					ia = { complementomensile: 0 };

				return { stipendio: stipendio, ivc: ivc, rpd: rpd, cia: cia, ia: ia };
			},

			eliminaSospensioni: function (services, sospensioni, dataStopDecreto) {
				let self = this;
				_.forEach(sospensioni, function (sospensione) {

					const giornoPrima = new Date(sospensione.start);
					giornoPrima.setDate(giornoPrima.getDate() - 1);
					const giornoDopo = new Date(sospensione.stop);
					giornoDopo.setDate(giornoDopo.getDate() + 1);

					for (let i = services.length - 1; i >= 0; i--) {
						var currServ = services[i];
						//contiene il triennio
						if (currServ.start <= giornoPrima && (currServ.stop ? currServ.stop : dataStopDecreto) > sospensione.stop) {
							//tronco la fine e creo un nuovo servizio che parte dalla fine
							let clonedService = { ...currServ };
							clonedService.start = giornoDopo;
							let clonedServiceanzianita = self.reevaluateDaysAndMonth(self.getDaysAndMonthByDates(clonedService.start, clonedService.stop));
							clonedService.anni = clonedServiceanzianita.aa;
							clonedService.mesi = clonedServiceanzianita.mm;
							clonedService.giorni = clonedServiceanzianita.gg;
							services.push(clonedService);
							//accorcio il servizio corrente
							currServ.stop = giornoPrima;
							let currServanzianita = self.reevaluateDaysAndMonth(self.getDaysAndMonthByDates(currServ.start, currServ.stop));
							currServ.anni = currServanzianita.aa;
							currServ.mesi = currServanzianita.mm;
							currServ.giorni = currServanzianita.gg;

						} else {
							//è nel triennio
							if (currServ.start > giornoPrima && (currServ.stop ? currServ.stop : dataStopDecreto) <= sospensione.stop) {
								//lo elimino
								services.splice(i, 1);
							} else {
								//finisce nel triennio
								if ((currServ.stop ? currServ.stop : dataStopDecreto) > giornoPrima && (currServ.stop ? currServ.stop : dataStopDecreto) <= sospensione.stop) {
									//tronco la fine
									currServ.stop = giornoPrima;
								}
								//inizia nel triennio
								if (currServ.start > giornoPrima && currServ.start <= sospensione.stop) {
									//tronco l'inizio
									currServ.start = giornoDopo;
								}
								let currServanzianita = self.reevaluateDaysAndMonth(self.getDaysAndMonthByDates(currServ.start, (currServ.stop ? currServ.stop : dataStopDecreto)));
								currServ.anni = currServanzianita.aa;
								currServ.mesi = currServanzianita.mm;
								currServ.giorni = currServanzianita.gg;
							}
						}
					}
				})
			}

		});

	appMeta.MetaSegreteriePage = MetaSegreteriePage;

}());

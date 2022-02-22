(function () {

   // Deriva da MetaEasyPage
   var MetaEasyPage = window.appMeta.MetaEasyPage;
   var Deferred = appMeta.Deferred;
   var metaModel = appMeta.metaModel;
   var getData = appMeta.getData;
   var postData = appMeta.postData;
   var localResource = appMeta.localization;
   var utils = appMeta.utils;
   var getDataUtils = appMeta.getDataUtils;
   var security = appMeta.security;
   var dataRowState = jsDataSet.dataRowState;

   function Meta$template$Page() {
      MetaEasyPage.apply(this, arguments);
      this.eventManager.subscribe(appMeta.EventEnum.listCreated, this.listCreated, this);
      this.eventManager.subscribe(appMeta.EventEnum.saveDataStop, this.saveDataStop, this);
      appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
      this.localResource = appMeta.localization;
      this.idreg_istituto = appMeta.security.usr("idreg_istituto");
      this.manageButtonsPrivileges();
   }

   Meta$template$Page.prototype = _.extend(
      new MetaEasyPage(),
      {
         constructor: Meta$template$Page,
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

         afterFill: function () {
            // PARTE SYNC
            // calcola la giusta height delle grid, serve 
            //per far apparire la scrollbar orizzontale visibile e non in fondo
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
               // recupero il controllere delg rid specifico
               var screenH = $(window).height();
               var offset = 200;
               var offsetDetail = 230;
               var h = (screenH - offset).toString() + 'px';
               var htab = (screenH - offset + 20).toString() + 'px';
               var hdetail = (screenH - offsetDetail).toString() + 'px';
               var htabdetail = (screenH - offsetDetail + 20).toString() + 'px';
               $(".tab-content").css("min-height", htab);
               $(this).find(".table").css("max-height", h);
               $(".detailPage .tab-content").css("min-height", htabdetail);
               $(".detailPage").find(this).css("max-height", hdetail);
            });

            // ASYNC
            // se esiste beforeFill sulla classe base MetaEasyPage lo invoco
            return MetaEasyPage.prototype.afterFill.call(this);
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
			 * Fromat the value to show on textBox. Es number on row is 1234.56 it become 1.234,56. point thousand separator and comma decimal separator
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
            return d.getDate().toString() + '/' + d.getMonth().toString() + '/' + d.getFullYear().toString();
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

         /**
          * @private
          * abilita e disabilita un controllo sulla pagina
          */
         enableControl: function (el, bool) {
            this.enableEl(el, bool);
            this.readOnlyEl(el, !bool);
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
            $("a[href^='#tab']").hide();
            $("#tabfake").remove();
            $(this.rootElement + " .nav.nav-tabs").append('<li id="tabfake"  class="nav-item">');
            $("#tabfake").append('<a id="atabfake" data-toggle="pill" class="nav-link active show">');
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
            var isSearchTable = true; // memorizzo per capire se sedvo forzare la chiusura dell'elenco eventualmente aperto
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
            var dtSource = this.getDataTable(objPrm.tableName);
            var filter = this.helpForm.getSearchText($("#" + objPrm.idControl), dtSource.columns[objPrm.columnNameText], objPrm.tagSearch);
            filter = self.helpForm.mergeFilters(filter, objPrm.filter);

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

            // effettuo la scelta su accmotive
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
                        // osservo se già è inserita, e nelc aso era deleted la riammetto tramite "rejectChanges"
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

         calculatePercTree: function (parentIdValue) {

            var days = 0;
            var perc = 0;

            var minDataInizioPrevista;
            var minDataInizioEffettiva;
            var maxDataFinePrevista;
            var maxDataFineEffettiva;


            var children = this.getChildren("perfprogettoobiettivoattivita", parentIdValue, "paridperfprogettoobiettivoattivita");
            for (var j = 0; j < children.length; j++) {

               var currentRow = children[j].getRow();

               if (this.getChildren("perfprogettoobiettivoattivita", currentRow.current.idperfprogettoobiettivoattivita, "paridperfprogettoobiettivoattivita").length > 0) {
                  var retValue = this.calculatePercTree(currentRow.current.idperfprogettoobiettivoattivita);
                  currentRow.current.completamento = retValue.completamento;
                  currentRow.current.datainizioprevista = retValue.dataInizioPrevista;
                  currentRow.current.datafineprevista = retValue.dataFinePrevista;
                  currentRow.current.datainizioeffettiva = retValue.dataInizioEffettiva;
                  currentRow.current.datafineeffettiva = retValue.dataFineEffettiva;
               }


               var dataInizio = (!currentRow.current.datainizioeffettiva ? currentRow.current.datainizioprevista : currentRow.current.datainizioeffettiva)
               var dataFine = (!currentRow.current.datafineeffettiva ? currentRow.current.datafineprevista : currentRow.current.datafineeffettiva);


               if (dataInizio && dataFine) {

                  if (!minDataInizioEffettiva) {
                     minDataInizioEffettiva = currentRow.current.datainizioeffettiva;
                  }
                  else if (currentRow.current.datainizioeffettiva < minDataInizioEffettiva) {
                     minDataInizioEffettiva = currentRow.current.datainizioeffettiva;
                  }
                  if (!minDataInizioPrevista) {
                     minDataInizioPrevista = currentRow.current.datainizioprevista;
                  }
                  else if (currentRow.current.datainizioprevista < minDataInizioPrevista) {
                     minDataInizioPrevista = currentRow.current.datainizioprevista;
                  }
                  if (!maxDataFinePrevista) {
                     maxDataFinePrevista = currentRow.current.datafineprevista;
                  }
                  else if (currentRow.current.datafineprevista > maxDataFinePrevista) {
                     maxDataFinePrevista = currentRow.current.datafineprevista;
                  }

                  if (!maxDataFineEffettiva) { }
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

         getChildren: function (tableName, parentIdValue, parentIdName, parent) {

            var children = [];
            var rows = appMeta.currentMetaPage.state.DS.tables[tableName].rows;

            if (parent) {
               rows = appMeta.currentMetaPage.state.callerState.callerPage.getDataTable("perfprogettoobiettivoattivita").rows;
            }

            for (var i = 0; i < rows.length; i++) {
               if (rows[i][parentIdName] == parentIdValue) {
                  children.push(rows[i]);

               }
            }
            return children;

         },

         getChildRow: function (dataset, tableName, keyColumn, parentKeyColumn, rootNode) {

            //vedere then expandnode treeviewmanager
            /*  var table = dataset.getDataTable(tableName);
              var childFilter = null;
              var self = this;
              var def = Deferred("getParents");

          
           if (table.length === 0) return def.resolve(false);

           var rel = getDataUtils.getAutoChildRelation(table);

              var rowsManaged = [];

           _.forEach(table.rows, function (row) {

                 // con return true, eseguo prox iterazione
                 if (!row) return true;
                 if (!row.getRow) return true;
                 //  if (table.existingRow(row)) return true; // se esiste non considero di nuovo nel filtro
                 var dtRow = row.getRow();
              if (dtRow.state === dataRowState.deleted || dtRow.state === dataRowState.detached) return true;

                 //  osservo se già ho considerato
                 var arr = _.filter(rowsManaged, table.keyFilter(row));
                 if (arr.length !== 0) return true;
                 rowsManaged.push(row);

                 var parentCols = _.map(rel.parentCols,
                    function (cName) {
                       return table.columns[cName];
                    });

                 var childCols = _.map(rel.childCols,
                    function (cName) {
                       return table.columns[cName];
                    });

                 // calcolo nuovo filtro
              var currFilter = getData.getWhereKeyClauseByColumns(dtRow, parentCols, childCols, table, true);
                 if (!currFilter) return true;

                 // se esiste il filtro lo concateno in or con il filtro parziale se già esiste, altrimenti inizializzo con il  currFilter
              childFilter = childFilter ? window.jsDataQuery.or(childFilter, currFilter) : currFilter;
              });

           childFilter = self.helpForm.mergeFilters(childFilter, table.staticFilter());
              // eseguo la select, con il filtro di or costruito con e clausole dei child. popolo la self.treeTable
           var res = getData.runSelectIntoTable(table, childFilter, null);

              return def.from(res).promise(); */

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
        
         /*********************************************************************
          ****************  FUNZIONI PER TIMESHEET: ***************************
          *********************************************************************/

         buildAndGetTimesheet: function (filterProgetti, idreg, year, showactivitiesrow) {
            var waitingHandler = this.showWaitingIndicator("Attendi generazione timesheet");
            var self = this;
            appMeta.Timesheet.buildAndGetTimesheet(filterProgetti, idreg, year, showactivitiesrow, this.state)
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

         //Calcola la media pesata
         // arrayWeighValue contiene la lista dei valori e pesi, del tipo { valore: valore, peso: percentuale }
         calculateWeightedAverage: function (arrayWeighValue) {
            if (arrayWeighValue.length === 0)
               return 0;
            var numeratore = 0;
            var denominatore = 0;

            for (i = 0; i < arrayWeighValue.length; i++) {
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
               return numeratore / denominatore;

            }

            return 0;
         }

      });

   appMeta.Meta$template$Page = Meta$template$Page;

}());

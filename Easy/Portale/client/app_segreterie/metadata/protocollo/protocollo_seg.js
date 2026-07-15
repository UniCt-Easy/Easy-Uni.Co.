(function () {

    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_protocollo() {
        MetaPage.apply(this, ['protocollo', 'seg', false]);
        this.name = 'Registrazioni di protocollo';
        this.defaultListType = 'seg';
        this.canInsertCopy = false;
        this.canSave = false;
        this.canCancel = false;
        this.eventManager.subscribe(appMeta.EventEnum.stopMainRowSelectionEvent, this.rowSelected, this);
        appMeta.globalEventManager.subscribe(appMeta.EventEnum.buttonClickEnd, this.buttonClickEnd, this);
        //pageHeaderDeclaration
    }

    metaPage_protocollo.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_protocollo,
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
                var def = appMeta.Deferred("afterGetFormData-protocollo_seg");
                var arraydef = [];

                arraydef.push(this.manageprotocollo_seg_anteprima());
                arraydef.push(this.manageprotocollo_seg_codiceammipa());
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

                if (self.isNullOrMinDate(parentRow.protdata))
                    parentRow.protdata = new Date();
                this.manageprotocollo_seg_anteprima();
                if (this.state.isSearchState()) {
                    this.helpForm.filter($('#protocollo_seg_idreg_origine'), null);
                } else {
                    this.helpForm.filter($('#protocollo_seg_idreg_origine'), this.q.eq('registry_active', 'Si'));
                }
                //beforeFillFilter

                //parte asincrona
                var def = appMeta.Deferred("beforeFill-protocollo_seg");
                var arraydef = [];

                arraydef.push(this.manageprotocollo_seg_codiceammipa());
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


            afterFill: function () {
                this.enableControl($('#protocollo_seg_codiceammipa'), false);
                this.enableControl($('#protocollo_seg_annullatoSi'), false);
                this.enableControl($('#protocollo_seg_annullatoNo'), false);
                this.enableControl($('#protocollo_seg_dataannullamento'), false);
                this.enableControl($('#protocollo_seg_anteprima'), false);

                // sourceTableName: protocollo
                // sourceEditType:  seg
                // idrelated:       2026|154
                $("#notificationstatus").text('Invia Mail');
                $("#sendmail").prop("disabled", true);
                $("#sendmail").prop('checked', false);

                let sentTime = "";

                // Destinatari
                let numDest = this.state.DS.tables.protocollodestinatario.rows.length;

                // idrelated = 2026|154
                let idrelated = this.state.currentRow.protanno + "|" + this.state.currentRow.protnumero;
                // filtro notificationQueue idrelated = 2026|154, sourceTableName=protocoll, sourceEditType=seg
                let filterNotificationQueue = this.q.and(this.q.eq('sourceTableName', 'protocollo'), this.q.and(this.q.eq('sourceEditType', 'seg'), this.q.eq('idrelated', idrelated)));
                // cerco notificationQueue
                appMeta.getData.runSelectIntoTable(this.state.DS.tables["notificationqueue"], filterNotificationQueue, null)
                    .then(function (dt) {

                        let inQueue = false;        // Mail accodata
                        let mailSent = false;       // Mail Inviata

                        if (dt.rows.length > 0) {
                            inQueue = true;
                            if (dt.rows[0].senttimestamp != null) {
                                mailSent = true;
                                $("#notificationstatus").text('Mail inviata il ' + dt.rows[0].senttimestamp.toLocaleString());
                            }
                        }

                        // Se in coda [Invia mail] è checked
                        $("#sendmail").prop('checked', inQueue);

                        // Se è stata inviata, o non è stata inviata e non ci sono ancora destinatari [Invia mail] è disabilitato
                        $("#sendmail").prop("disabled", mailSent || !mailSent && numDest == 0);
                    });

                //afterFillin
                return this.superClass.afterFill.call(this);
            },

            afterLink: function () {
                var self = this;
                this.state.DS.tables.protocollo.defaults({ 'annullato': 'N' });
                this.state.DS.tables.protocollo.defaults({ 'codiceregistro': 'Registro Unico' });
                this.state.DS.tables.protocollo.defaults({ 'idprotocollokind': 1 });
                this.state.DS.tables.protocollo.defaults({ 'protanno': new Date().getFullYear() });
                $("#Salva").on("click", _.partial(this.fireSalva, this));
                $("#Salva").prop("disabled", true);
                $("#Annulla").on("click", _.partial(this.fireAnnulla, this));
                $("#Annulla").prop("disabled", true);
                $("#Carica").on("click", _.partial(this.fireCarica, this));
                $("#Carica").prop("disabled", true);
                $("#btnProtocol").on("click", _.partial(this.firebtnProtocol, this));
                $("#btnProtocol").prop("disabled", true);
                this.setDenyNull("protocollo", "idprotocollokind");
                appMeta.metaModel.insertFilter(this.getDataTable("protocollokinddefaultview"), this.q.eq('protocollokind_active', 'Si'));
                this.state.DS.tables.aoodefaultview.staticFilter(window.jsDataQuery.eq('aoo_idreg', parseInt(this.idreg_istituto)));
                appMeta.metaModel.insertFilter(this.getDataTable("classificazioneprotocollodefaultview"), this.q.eq('classificazioneprotocollo_active', 'Si'));
                //fireAfterLink
                return this.superClass.afterLink.call(this).then(function () {
                    var arraydef = [];
                    //fireAfterLinkAsinc
                    return $.when.apply($, arraydef);
                });
            },

            //afterRowSelect

            //afterActivation


            buttonClickEnd: function (currMetaPage, cmd) {
                //fireRelButtonClickEnd
                cmd = cmd.toLowerCase();
                if (cmd === "mainsetsearch") {
                    $("#Salva").prop("disabled", this.state.isInsertState() || this.state.isSearchState());
                    $("#Annulla").prop("disabled", this.state.currentRow.annullato == 'S' || this.state.isInsertState());
                    $("#Carica").prop("disabled", this.state.isSearchState());
                    $("#btnProtocol").prop("disabled", true);
                    //firebuttonClickEnd
                }
                return this.superClass.buttonClickEnd(currMetaPage, cmd);
            },


            //insertClick

            //beforePost

            //afterPost

            rowSelected: function (dataRow) {
                $("#Annulla").prop("disabled", this.state.currentRow.annullato == 'S' || this.state.isInsertState());
                $("#Salva").prop("disabled", this.state.currentRow.protregistro != null || this.state.isInsertState() || this.state.isSearchState());
                $("#btnProtocol").prop("disabled", !this.state.isInsertState());
                $("#Carica").prop("disabled", this.state.isSearchState());
            },

            afterClear: function () {
                //parte sincrona
                const annoCorrente = new Date().getFullYear();
                $('#protocollo_seg_protanno').val(annoCorrente);
                this.enableControl($('#protocollo_seg_protnumero'), true);
                this.enableControl($('#protocollo_seg_protanno'), true);
                this.enableControl($('#protocollo_seg_codiceammipa'), true);
                this.helpForm.filter($('#protocollo_seg_idreg_origine'), null);
                this.enableControl($('#protocollo_seg_annullatoSi'), true);
                this.enableControl($('#protocollo_seg_annullatoNo'), true);
                this.enableControl($('#protocollo_seg_dataannullamento'), true);
                this.enableControl($('#protocollo_seg_anteprima'), true);
                //afterClearin

                //afterClearInAsyncBase
            }
            ,

            fireSalva: function (that) {
                that.getFormData(true);
                that.showMessageOkCancel('Salvare il protocollo?')
                    .then(function (res) {
                        if (!res) {
                            that.hideWaitingIndicator(waitingHandler);
                            return def.resolve();
                        }

                        let params = {
                            dsProtocolloSeg: appMeta.getDataUtils.getJsonFromJsDataSet(that.state.DS, true),
                            tableName: that.primaryTableName,
                            sendmail: $("#sendmail").is(':checked')
                        };

                        let waitingHandler = that.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
                        let tMain = that.state.DS.tables["protocollo"];

                        appMeta.callWebService("aggiornaprotocollo", params)
                            .then(function (jsonRes) {

                                return that.manageProtocollaResponseWithRules(that.state.DS, jsonRes);
                            }).then(function (dsOut, msg, success, canIgnore) {
                                that.hideWaitingIndicator(waitingHandler);
                                if (success) {
                                    // il protocolla è andato bene, quindi rinfresco i valori sulla riga principale
                                    // che ho appena reso persistenti
                                    that.state.currentRow.getRow().makeSameAs(tMain.rows[0].getRow());

                                    return that.freshForm(true, false)
                                        .then(function () {

                                            let elNum = $('#protocollo_seg_protnumero')[0];

                                            that.helpForm.reEnable(elNum);

                                            that.helpForm.disableControl(elNum);

                                            return that.showMessageOk(appMeta.localization.protocolSaveOK);
                                        }).then(function () {
                                            def.resolve();
                                        });
                                }

                                if (msg && msg.length) {
                                    return appMeta.postData.showErrorList(msg, canIgnore, that);
                                }

                                // il save ha avuto problemi
                                return that.showMessageOk(localResource.protocolSaveNOK + " " + msg)
                                    .then(function () {
                                        def.resolve();
                                    });
                            });
                    });
                return def.promise();
            },

            fireAnnulla: function (that) {
                var def = appMeta.Deferred("Invia-istanza_stu");
                that.showMessageOkCancel('Il protocollo verrà annullato. Procedere?')
                    .then(function (res) {
                        if (!res) {
                            that.hideWaitingIndicator(waitingHandler);
                            return def.resolve();
                        }
                        //dico di atendere
                        let waitingHandler = that.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
                        //that.state.currentRow.annullato = 'S';
                        //that.state.currentRow.dataannullamento = new Date();
                        $('#protocollo_seg_annullatoSi, #protocollo_seg_annullatoNo').prop('disabled', false);
                        $('#protocollo_seg_annullatoSi').prop('checked', true);
                        $('#protocollo_seg_annullatoSi, #protocollo_seg_annullatoNo').prop('disabled', true);
                        $('#protocollo_seg_dataannullamento').val(that.stringFromDate_ddmmyyyy_hhmm(new Date()));
                        //salvo
                        that.cmdMainSave()
                            .then(function () {
                                //rinfresco la pagina
                                return that.freshForm(true, false);
                            }).then(function () {
                                $("#Annulla").prop("disabled", true);
                                that.hideWaitingIndicator();
                                return def.resolve();
                            });
                    });
                return def.promise();
            },

            fireCarica: function (that) {
                let idqryregistry = $('#protocollo_seg_idqueryregistry').val();

                if (idqryregistry == null) {
                    alert("Selezionare una tipologia di destinatari");
                    return;
                }

                let waitingHandler = that.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);

                let params = {
                    idqueryregistry: idqryregistry
                };

                var chain = $.when();

                appMeta.callWebService("getMailList", params)
                    .then(function (mails) {

                        if (mails.length > 0) {

                            mails.forEach(item => {
                                const _idreg_dest = item['idreg_dest'];
                                const _destmail = item['destmail'];

                                let exists = false;
                                _.forEach(that.getDataTable("protocollodestinatario").rows, function (protDestRows) {
                                    if (protDestRows.idreg_dest == _idreg_dest) {
                                        exists = true;
                                        return false;
                                    }
                                    return true;
                                });

                                if (exists)
                                    return;

                                chain = chain.then(function () {

                                    var meta = appMeta.getMeta("protocollodestinatario");

                                    meta.setDefaults(that.getDataTable("protocollodestinatario"));

                                    return meta.getNewRow(that.state.currentRow, that.getDataTable("protocollodestinatario"))
                                        .then(function (row) {
                                            row.current.idreg_dest = _idreg_dest;
                                            row.current.destmail = _destmail;
                                            row.current.protanno = that.state.currentRow.protanno;
                                            row.current.protnumero = that.state.currentRow.protnumero;
                                            return true;
                                        });
                                });
                            });

                            return chain
                        }
                    })
                    .then(function () {
                        return that.freshForm(true, false);
                    })
                    .then(function () {
                        that.hideWaitingIndicator(waitingHandler);
                    });
            },

            firebtnProtocol: function (that) {
                that.getFormData(true);
                that.showMessageOkCancel('Il protocollo verrà assegnato e i dati non saranno più modificabili. Procedere?')
                    .then(function (res) {
                        if (!res) {
                            that.hideWaitingIndicator(waitingHandler);
                            return def.resolve();
                        }

                        let params = {
                            dsProtocolloSeg: appMeta.getDataUtils.getJsonFromJsDataSet(that.state.DS, true),
                            tableName: that.primaryTableName,
                            sendmail: $("#sendmail").is(':checked')
                        };

                        let waitingHandler = that.showWaitingIndicator(appMeta.localResource.modalLoader_wait_waiting);
                        let tMain = that.state.DS.tables["protocollo"];

                        appMeta.callWebService("protocolla", params)
                            .then(function (jsonRes) {

                                return that.manageProtocollaResponseWithRules(that.state.DS, jsonRes);
                            }).then(function (dsOut, msg, success, canIgnore) {
                                that.hideWaitingIndicator(waitingHandler);
                                if (success) {
                                    // il protocolla è andato bene, quindi rinfresco i valori sulla riga principale
                                    // che ho appena reso persistenti
                                    that.state.currentRow.getRow().makeSameAs(tMain.rows[0].getRow());

                                    return that.freshForm(true, false)
                                        .then(function () {

                                            let elNum = $('#protocollo_seg_protnumero')[0];
                                            let elAnno = $('#protocollo_seg_protanno')[0]
                                            let elButton = $('#btnProtocol')[0];
                                            let elSalva = $('#Salva')[0];

                                            that.helpForm.reEnable(elNum);

                                            that.helpForm.disableControl(elNum);
                                            that.helpForm.disableControl(elAnno);
                                            that.helpForm.disableControl(elButton);
                                            that.helpForm.enableControl(elSalva);

                                            $("#btnProtocol").prop("disabled", true);

                                            return that.showMessageOk(appMeta.localization.protocolSaveOK);
                                        }).then(function () {
                                            def.resolve();
                                        });
                                }

                                if (msg && msg.length) {
                                    return appMeta.postData.showErrorList(msg, canIgnore, that);
                                }

                                // il save ha avuto problemi
                                return that.showMessageOk(localResource.protocolSaveNOK + " " + msg)
                                    .then(function () {
                                        def.resolve();
                                    });
                            });
                    });
                return def.promise();
            },

            manageprotocollo_seg_anteprima: function () {
                document.getElementById('protocollo_seg_anteprima').innerHTML = this.convertXmlToHtmlTable(this.state.currentRow.testosegnatura);
            },

            manageprotocollo_seg_codiceammipa: function () {
                def = appMeta.Deferred("getCodiceIpa");
                if (!this.state.currentRow.codiceammipa) {
                    var filter = this.q.eq("idreg", this.idreg_istituto);
                    var self = this;
                    return appMeta.getData.doReadValue("registry", filter, "ipa_fe", null)
                        .then(function (ipa_fe) {
                            if (ipa_fe) {
                                self.state.currentRow.codiceammipa = ipa_fe;
                                $('#protocollo_seg_codiceammipa').val(ipa_fe);
                            }
                            return def.resolve();
                        });
                }
                else {
                    return def.resolve();
                }
            },

            //buttons
        });

    window.appMeta.addMetaPage('protocollo', 'seg', metaPage_protocollo);

}());

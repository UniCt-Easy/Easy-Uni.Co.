
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


/**
 * @module MainToolBarManager
 * @description
 * Manages the logic and the graphics of the main toolbar of the application
 */
(function() {

    var locale = appMeta.localResource;
    var Deferred = appMeta.Deferred;
    var logType = appMeta.logTypeEnum;
    var logger = appMeta.logger;

    /**
     * @constructor MainToolBarManager
     * @description
     * Initializes the main toolbar of the application
     * @param {Html node} rootElement
     * @param {MetaPage} metaPage
     */
    function MainToolBarManager(rootElement, metaPage) {

        this.templateFileHtmlPath  = appMeta.basePath + appMeta.config.path_maintoolBarTemplate;
        this.rootElement = rootElement;
        this.metaPage = metaPage;

        this.loadTemplate();
    }

    MainToolBarManager.prototype = {
        constructor: MainToolBarManager,

        /**
         * @method setMetaPage
         * @public
         * @description SYNC
         * Sets the current metaPage
         * @param {MetaPage} metaPage
         */
        setMetaPage:function (metaPage) {
            this.metaPage = metaPage;
            // se la metaPage è null come nel caso della chiusra di un form principla edisabilito tutti ibottoni
            if (!metaPage){this.enableDisableAllButtons(false)}
        },

        /**
         * @method setLogLevel
         * @private
         * @description SYNC
         * Loads the html template of the mainToolBar control, and append it to the "rootElement"
         */
        loadTemplate:function () {
            // carico il template della toolbar
            var htmlCodeTemplate = appMeta.getData.cachedSyncGetHtml(this.templateFileHtmlPath);
            $(this.rootElement).html(htmlCodeTemplate);
            this.loadButtonProperties();
        },

        /**
         * Re-localize the button
         */
        localize:function () {
            var self = this;
            $(this.rootElement)
                .find("button[type=button]")
                .each(function() {
                    var tag = $(this).data("tag");
                    if (tag)self.setButtonText(this, tag);
                });

            this.freshButtons();
        },

        /**
         * @method loadButtonProperties
         * @private
         * @description SYNC
         * Loads the text and adds the events to the toolbar buttons
         */
        loadButtonProperties:function () {
            var self = this;
            $(this.rootElement)
                .find("button[type=button]")
                .each(function() {
                    var tag = $(this).data("tag");
                    if (tag) {
                        self.setButtonText(this, tag);
                        self.addEvent(this);
                        self.activeDeactiveButton($(this), false);
                    } else {
                        logger.log(logType.ERROR, "Missing tag on toolbar button");
                    }
                });
        },

        /**
         * @method enableDisableAllButtons
         * @private
         * @description SYNC
         * If "enable" is true it enables all the buttons, otherwise it disables all the buttons
         * @param {boolean} enable
         */
        enableDisableAllButtons:function (enable) {
            var self = this;
            // loop sui pulsanti
            $(this.rootElement)
                .find("button[type=button]")
                .each(function() {
                    var btn = this;
                    var cmd = $(btn).data("tag");
                    if (!cmd) return true; // button unchanged
                    self.activeDeactiveButton($(btn), enable);
                });
        },

        /**
         * @method activeDeactivebutton
         * @private
         * @description SYNC
         * Contains the logic to activate or deactivate a button. It could be visible or not visible, but also enabled/disabled
         * @param {jquery button} btn
         * @param {boolean} enable
         */
        activeDeactiveButton:function (btn, enable) {
            // Gestione con abilita/ disabilita, cioè pulsanti sempre presenti
            // btn.prop('disabled', !enable);

            // mette visibile/invisibile
            if (enable){
                btn.show();
            }else{
                btn.hide();
            }
        },

        /**
         * @method setButtonText
         * @private
         * @description SYNC
         * Assign the localized label for the button "btn" depending on "tag"
         * @param {html button} btn
         * @param {string} tag
         */
        setButtonText:function (btn, tag) {
            // set the text
            var txt = "";
            // prendo il testo del bottone dal file locale
            if (locale[tag] !== undefined){
                txt = locale[tag];
            }
            this.buttonText(btn, txt);
        },

        /**
         * @method addEvent
         * @private
         * @description SYNC
         * Adds to the button "btn" the events
         * @param {Html button} btn
         */
        addEvent:function (btn) {
            $(btn).on("click", _.partial(this.buttonClick, this));
            $(btn).data("mdlPushed", false);
        },

        /**
         * @method buttonClick
         * @private
         * @description ASYNC
         * Hsndler for the event "click" of a button.
         * "this" is the button that fired the event
         * @param {MainToolBarManager} that
         * @returns {Deferred}
         */
        buttonClick:function (that) {
            if (!that.metaPage) return;
            var def  = Deferred("buttonClick");
            var tag = $(this).data("tag");
            if (!tag) return def.resolve(false).promise();
            var cmd = tag;
            var filter = $(this).data("filter");
            return that.metaPage.commandEnabled(cmd).then(
                function (res) {
                    if (res) {
                        return that.metaPage.doMainCommand(cmd, filter)
                            .then(function() {
                                return def.from(that.freshButtons())
                                    .then(function () {
                                        appMeta.globalEventManager.trigger(appMeta.EventEnum.buttonClickEnd, that.metaPage, cmd);
                                        return def.resolve();
                                })
                            });
                    }

                    return def.resolve(false).promise();
                });
        },

        /**
         * @method freshButtons
         * @public
         * @description ASYNC
         * Updates button status
         * @returns {Deferred}
         */
        freshButtons: function() {
            if (!this.rootElement) return Deferred("freshButton").resolve(true);
            if (!this.metaPage) return Deferred("freshButton").resolve(true);
            var self = this;
            var allDeferredCommandEnabled = [];
            // loop sui pulsanti
            _.forEach($(this.rootElement).find("button[type=button]"), function (button) {
                var cmd = $(button).data("tag");
                if (!cmd) return true; //button unchanged
                // memorizzo array di deferred
                allDeferredCommandEnabled.push(
                    self.metaPage.commandEnabled(cmd).then(function (result) {
                        return { btn: button, res: result };
                    }));
                return true;
            });

            // risolvo tutti i deferred dei bottoni
            // N.B la commandEnabled torna una struttura {res:true , btn:btn} con risultato + elemento html bottone
            var def = Deferred("freshButton");
            var res =
                $.when.apply($, allDeferredCommandEnabled)
                    .then(function() {

                        // loop sui risultati della when. ogni data è un oggetto del tipo {res:true , btn:btn} 
                        _.forEach(arguments,
                            function(data) {
                                var mybtn = $(data.btn);
                                if (data.res) {
                                    var cmd = $(data.btn).data("tag");

                                    if (cmd === "mainclose") {
                                        if (self.metaPage.detailPage || self.metaPage.state.isInsertState()) {
                                            //deve usare l'annulla
                                            self.activeDeactiveButton(mybtn, false);
                                            self.setVisible(mybtn, false);
                                            return true; // passo iterazione successiva del forEach
                                        }
                                    }
                                    
                                    if (cmd === "mainsetsearch") {
                                        if (self.metaPage.state.isSearchState()) {
                                            self.buttonText(mybtn, locale.emptyField);
                                        } else {
                                            self.buttonText(mybtn, locale.mainsetsearch);
                                        }
                                    }

                                    if (cmd === "maindelete") {
                                        if (self.metaPage.state.isInsertState()) {
                                            if (self.buttonText(mybtn) !== locale.cancel) self.buttonText(mybtn, locale.cancel);
                                        }

                                        if (self.metaPage.state.isEditState()) {
                                            if (self.metaPage.detailPage) {
                                                if (self.buttonText(mybtn) !== locale.cancel) self.buttonText(mybtn, locale.cancel);
                                            }
                                            else {
                                                if (self.buttonText(mybtn) !== locale.eliminate) self.buttonText(mybtn, locale.eliminate);
                                            }
                                        }
                                    }
                                    
                                    if (cmd === "mainsave") {
                                        if (self.metaPage.detailPage) {
                                            if (self.buttonText(mybtn) !== locale.ok) self.buttonText(mybtn, locale.ok);
                                        } else {
                                            if (self.buttonText(mybtn) !== locale.mainsave) self.buttonText(mybtn, locale.mainsave);
                                        }
                                    }

                                    self.activeDeactiveButton(mybtn, true);

                                    if (cmd === "editnotes") {
                                        if (self.metaPage.notesAvailable()) {
                                            if (!mybtn.data("mdlPushed")) {
                                                mybtn.data("mdlPushed", true);
                                                mybtn.addClass(appMeta.cssDefault.btnPushed);
                                            }
                                        } else {
                                            if (mybtn.data("mdlPushed")) {
                                                mybtn.data("mdlPushed", false);
                                                mybtn.removeClass(appMeta.cssDefault.btnPushed);
                                            }
                                        }
                                    }

                                    self.setVisible(mybtn, true);
                                } else {
                                    self.activeDeactiveButton(mybtn, false)
                                    self.setVisible(mybtn, false);
                                }
                            });

                        return true;
                    })
                    .then(function() {
                        if (!self.tooBarVisible()) {
                            self.tooBarVisible(true);
                        }
                        
                        return true;
                    });

            return def.from(res).promise();

        },

        /**
         * @method tooBarVisible
         * @private
         * @description SYNC
         * Gets/Sets the visibility of the toolbar, in jquery style
         * @param {Boolean|undefined}visible
         * @returns {boolean} return true if the toolbar is visible
         */
        tooBarVisible:function (visible) {
            if (visible === undefined){
                return ($(this.rootElement).prop('hidden') === false);
            }
            $(this.rootElement).prop('hidden', !visible);
            return visible;
        },

        /**
         * @method buttonText
         * @private
         * @description SYNC
         * Gets/sets the text "txt" in the button "btn" in jquery style
         * @param {Html Button} btn the button in the toolbar
         * @param {string} txt
         */
        buttonText:function (btn, txt) {
            // il testo del bottone deve essere ospitato in uno span
            if (txt === undefined){
                return $(btn).find('span', this).text();
            }

            $(btn).find('span').text(txt);

            return txt;
        },

        /**
         * @method setVisible
         * @private
         * @description SYNC
         * Set the visibility of button "btn" depending on "visible" parameter
         * @param {Html button} btn
         * @param {boolean} visible
         * @returns {boolean}
         */
        setVisible:function (btn, visible) {
            if (this.mustDoFix()) {
                if (!$(this).prop("disabled") === visible) return false;
                $(this).prop("disabled", !visible);
                return true;
            }
            if ( !$(this).prop('hidden') === visible) return false;
            $(this).prop('hidden',visible);
            return true;
        },

        /**
         * @method mustDoFix
         * @private
         * @description SYNC
         * @returns {boolean}
         */
        mustDoFix:function () {
            return false;
        },

        /**
         * Sets the title. usually is the "brad crumbs" path "page1 > page 2...> pagen"
         * @param {string} title
         */
        setTitle:function (title) {
            if($('#toolbartitle').length) $('#toolbartitle').text(title);
        }

    };

    appMeta.MainToolBarManager = MainToolBarManager;

}());

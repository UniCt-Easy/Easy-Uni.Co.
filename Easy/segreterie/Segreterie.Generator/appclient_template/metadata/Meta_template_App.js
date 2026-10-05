(function () {

    // Deriva da MetaApp
    var MetaApp = appMeta.MetaApp;

   function Meta$template$App() {
        MetaApp.apply(this, arguments);
    }

    Meta$template$App.prototype = Object.create(MetaApp.prototype);
    // Aggiungi poi i metodi specifici di Meta$template$App
    _.extend(Meta$template$App.prototype, {
        constructor: Meta$template$App,
        superClass: MetaApp.prototype,

        /**
        * Register dynamic metapages from exportdefinition table.
        * @returns
        */
        registerDynamicMetapages: function () {

            let defs = ["exportfunction", "report"].map(edName => appMeta.getData.createTableByName(edName, "*"));

            return Promise.all(defs)
                .then((tables) => {

                    let selectBuilders = tables.map(table => ({
                        filter: null,
                        top: null,
                        tableName: table.tableName,
                        table: table
                    }));

                    appMeta.getData.multiRunSelect(selectBuilders)
                    .then(function () {

                        metaPageDescription = _.find(appMeta.metaPages, { "tableName": "exportviewer", "editType": "default" });

                        tables.forEach(table => {
                            table.rows.forEach(function (definition) {

                                let editType = `${table.name}_${definition[table.myKey]}`;

                                appMeta.addMetaPage("exportviewer", editType, metaPageDescription.MetaPage);    // registriamo una "copia" della metapage di exportviewer di default
                            });
                        });
                    });
            });
        },
    });

    let baseGetJsFilePath = appMeta.getJsFilePath;

    appMeta.getJsFilePath = function (tableName, editType) {
        return tableName == 'exportviewer'
            ? this.getMetaPagePath(tableName) + "/" + tableName + "_default.js"
            : baseGetJsFilePath.call(this, tableName, editType);
    }

    //A differenza di quella originale non la cerco nella cache dell'applicativo.
    //Per il browser la cache è false di default.
    appMeta.getMetaPage = function (tableName, editType) {
        let res = appMeta.Deferred("getMetaPage");

        //let found = _.find(this.metaPages, { "tableName": tableName, "editType": editType });
        let self = this;
        //if (found) {
        //    let isDetail = found.MetaPage.prototype.detailPage;
        //    return res.resolve(new found.MetaPage(tableName, editType, isDetail)); //non aggiunge due volte la metaPage
        //}

        let jsFileName = this.getJsFilePath(tableName, editType);

        $.getScript(jsFileName) // questo esegue il js caricato
            .done(
                function () { //mi attendo che il js caricato abbia effettuato la addMetaPage
                    found = _.find(self.metaPages, { "tableName": tableName, "editType": editType });
                    if (found) {
                        let isDetail = found.MetaPage.prototype.detailPage;
                        let metaPage = new found.MetaPage(tableName, editType, isDetail);
                        if (tableName == 'exportviewer') {
                            metaPage.editType = editType; // setto l'editType per le pagine che lo usano
                        }
                        res.resolve(metaPage);
                        return;
                    }

                    res.reject('Failed to load metaPage ' + jsFileName + ' edittype:' + editType + ". Compile wrong or missing file.");
                })
            .fail(
                function (err) {
                    res.reject('Failed to load ' + jsFileName + ' edittype:' + editType + ". Compile wrong or missing file." + err);
                });

        return res.promise();

    }

    //We save the original getMetaDataPath function
    let baseGetMetaPagePath = appMeta.getMetaPagePath;

    appMeta.getMetaPagePath = function (tableName) {
        if (appMeta.config.env === appMeta.config.envEnum.PROD) {
            return this.basePathMetadata ? this.basePathMetadata : this.basePath;
        }
        //We invoke the original function
        return baseGetMetaPagePath.call(this, tableName);
    };

    let baseGetHtmlFilePath = appMeta.getHtmlFilePath;

    appMeta.getHtmlFilePath = function (tableName, editType) {
        return tableName == 'exportviewer'
            ? this.getMetaPagePath(tableName) + "/" + tableName + "_default.html"
            : baseGetHtmlFilePath.call(this, tableName, editType);
    }

    appMeta.callWebService = function (method, prms) {
        return appMeta.currApp.callWebService(method, prms);
    }

    //A differenza di quella originale non la cerco nella cache dell'applicativo.
    //Disabilito anche la chache del browser che di default è true.
    appMeta.getPage = function (rootElement, tableName, editType) {
        let res = this.Deferred("getPage");

        //let page = _.find(this.htmlPages, { "tableName": tableName, "editType": editType });

        let self = this;
        //if (page) {
        //    $(rootElement).html(page.html);
        //    return res.resolve(page.html).promise();
        //}

        let htmlFileName = this.getHtmlFilePath(tableName, editType); //this.getMetaPagePath(tableName) + "/" + tableName + "_" + editType + ".html";
        $.get({
            url: htmlFileName,
            cache: false
        })
            .done(
                function (data) {
                    self.htmlPages.push({ tableName: tableName, editType: editType, html: data });
                    $(rootElement).html(data);
                    res.resolve(data);
                })
            .fail(
                function (err) {
                    res.reject('Failed to load ' + htmlFileName + ' ' + JSON.stringify(err.responseText));
                });

        return res.promise();

    }

    //A differenza di quella originale non la prendo nella cache ma la aggiorno, ma solo se sono nell'ambiente di produzione altrimenti non funziona il debug;
    appMeta.addMetaPage = function (tableName, editType, metaPage) {

        let found = _.find(this.metaPages, { "tableName": tableName, "editType": editType });

        if (found) {
            if (appMeta.config.env === appMeta.config.envEnum.PROD) {
                found.MetaPage = metaPage;
            }
            return;
        }
        this.metaPages.push({ tableName: tableName, editType: editType, MetaPage: metaPage });
    }

    /**
     * Calls a backend method to generate an export file by identifying the export definition and supplying its parameters. 
     * @param {any} editType
     * @param {any} exportParams
     * @returns
     */
    appMeta.generateExport = function (editType, parameters) {

        var def = appMeta.Deferred("generateExport");

        var objConn = {
            method: appMeta.routing.methodEnum.generateExport,
            prm: {
                editType: editType,
                generateExportParams: parameters || {}
            }
        };

        appMeta.connection.call(objConn)
            .then(function (res) {

                let response = JSON.parse(res);

                if (res == null || response == null) {

                    def.reject("No response from server or invalid response format.");
                }

                if (response.error) {

                    def.reject(response.error);
                }

                if (response.base64StringBytes) {

                    let blob;

                    const binaryString = atob(response.base64StringBytes);
                    const byteArray = new Uint8Array(binaryString.length);

                    for (let i = 0; i < binaryString.length; i++) {
                        byteArray[i] = binaryString.charCodeAt(i);
                    }

                    blob = new Blob([byteArray], { type: "application/octet-stream" });

                    // creiamo un link per il download del file e invochiamo il click su di esso
                    const url = URL.createObjectURL(blob);
                    const link = document.createElement("a");
                    link.href = url;
                    link.download = response.filename || "exported_file";
                    document.body.appendChild(link);

                    link.click();

                    document.body.removeChild(link);
                    URL.revokeObjectURL(url);

                    def.resolve(res);
                }
            })
            .catch(function (err) {

                def.reject(err);
            });

        return def.promise();
    };

    appMeta.currApp = new Meta$template$App();
}());

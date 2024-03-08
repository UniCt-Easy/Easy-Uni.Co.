(function () {

    // Deriva da MetaApp
    var MetaApp = appMeta.MetaApp;

    function MetaSegreterieApp() {
        MetaApp.apply(this, arguments);
    }

    MetaSegreterieApp.prototype = _.extend(
        new MetaApp(),
        {
            constructor: MetaSegreterieApp,
            superClass: MetaApp.prototype,
        });

    appMeta.currApp = new MetaSegreterieApp();

    //We save the original getMetaDataPath function
    let baseGetPageDataPath = appMeta.getMetaPagePath;

    appMeta.getMetaPagePath = function (tableName) {
        if (appMeta.config.env === appMeta.config.envEnum.PROD) {
            return this.basePathMetadata ? this.basePathMetadata : this.basePath;
        }
        //We invoke the original function
        return baseGetPageDataPath.call(this, tableName);
    }

    appMeta.callWebService = function (method, prms) {
        return appMeta.currApp.callWebService(method,prms);
    },

    //A differenza di quella originale non la cerco nella cache dell'applicativo.
    //Disabilito anche la chache del browser che di default è true.
    appMeta.getPage = function(rootElement, tableName, editType) {
        let res = this.Deferred("getPage");

        //let page = _.find(this.htmlPages, { "tableName": tableName, "editType": editType });

        let self = this;
        //if (page) {
        //    $(rootElement).html(page.html);
        //    return res.resolve(page.html).promise();
        //}

        let htmlFileName = this.getMetaPagePath(tableName) + "/" + tableName + "_" + editType + ".html";
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

        },

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
        },

    //A differenza di quella originale non la cerco nella cache dell'applicativo.
    //Per il browser la cache è false di default.
    appMeta.getMetaPage = function(tableName, editType) {
        let res = this.Deferred("getMetaPage");

        //let found = _.find(this.metaPages, { "tableName": tableName, "editType": editType });
        let self = this;
        //if (found) {
        //    let isDetail = found.MetaPage.prototype.detailPage;
        //    return res.resolve(new found.MetaPage(tableName, editType, isDetail)); //non aggiunge due volte la metaPage
        //}

        let jsFileName = this.getMetaPagePath(tableName) + "/" + tableName + "_" + editType + ".js";

        $.getScript(jsFileName) // questo esegue il js caricato
            .done(
                function () { //mi attendo che il js caricato abbia effettuato la addMetaPage
                    found = _.find(self.metaPages, { "tableName": tableName, "editType": editType });
                    if (found) {
                        let isDetail = found.MetaPage.prototype.detailPage;
                        res.resolve(new found.MetaPage(tableName, editType, isDetail));
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

}());

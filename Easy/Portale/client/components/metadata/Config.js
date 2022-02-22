
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
 * @class Config
 * @description
 * Contains global variables for the configuration
 */
(function () {

    /**
     * Indicates the environment. Some feature or debug option are enabled for example only in some cases
     * @type {{DEV: number, QA: number, PROD: number}}
     */
    var envEnum = {
        DEV : 0,
        QA : 1,
        PROD : 2
    };

    // path all'interno dei file del fmw dove sono contenuti i template
    var path_rootTemplate = "components/template/";

    /**
     * Contains the global variables for the configuration
     * @type {{path_maintoolBarTemplate: string, path_multiSelectTemplate: string, path_loaderTemplate: string, path_procedureMessagesTemplate: string, env: number}}
     */
    var config = {

        MDLW_VERSION : "0.0.1",

        // ********** path dei template dei controlli ******
        path_maintoolBarTemplate: path_rootTemplate + "mainToolBar_Template.html",
        path_multiSelectTemplate: path_rootTemplate + "multiSelect_Template.html",
        path_loaderTemplate : path_rootTemplate + "loader_Template.html",
        path_procedureMessagesTemplate :  path_rootTemplate + "listProcedureMessages_Template.html",
        path_modalLoaderTemplate:  path_rootTemplate + "modalLoader_Template.html",
        path_gridOption_Template:  path_rootTemplate + "gridOption_Template.html",
        env: envEnum.DEV,
        forceShowErrorInfo: false,
        //******************************************************

        //************* url backend ****************************
        webSocketAddress: "ws://localhost:54471/WebSocket/WSServer.ashx",
        //******************************************************
        
        // ********** var globali di classe ******
        // List Manager
        listManager_nRowPerPage : 100, // numero di righe nelle liste paginate.
        listManager_numberOfPagesInFooter : 5, // numero di pulsanti visibili in un form di tipo list per gestire la paginazione
        // Combo manager
        minimumResultsForSearch : 20, // numero di record oltre il quale la combo mostra la riga di filtro.
        // DropDownControl
        dropDownMinCharTyped : 2, // numero di caratteri da quale scatta la ricerca nel drop down
        dropDownDelayKeyUp : 500, // ritardo in ms per cui scatta la query nel dropdown
        // *************************************//

        // timeout delle chiamate ajax.
        ajax_timeout: 60000,

        enableSearchLikeOnTextBox: false, // Abilita/Disabilita la ricerca tramite la like su tutti i text della app
        defaultDecimalFormat: 'c', // Formato di default per colonne di tipo Decimal
        defaultDecimalPrecision : '2', // Numero di cifre decimali di default per colonne di tipo decimal
        selectedRowColor : 'rgb(255, 255, 153)', // colore riga selezionata
        // separatore tra guid e nome file per gli allegati
        separatorFileName: "$__$"

    };

    appMeta.config = config;
    appMeta.config.envEnum = envEnum;
}());



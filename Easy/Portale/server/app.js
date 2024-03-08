const express = require('express');
const app = express();
const bodyParser = require('body-parser');
const morgan = require('morgan');

//*****************************************************************************
// THIRD PARTH REQUIRE
// browser-nodejs compatibility
global.window = global;
// third party lib + mdlw frontend compatibility
global.$ = {};
global.$.Deferred = require("JQDeferred");
global._ = require('lodash');
global.jsDataSet = require('jsDataSet');
global.DataTable = global.jsDataSet.DataTable;
global.DataSet = global.jsDataSet.DataSet;
global.dataRowState = global.jsDataSet.dataRowState;
global.jsDataQuery = global.qh = require('jsDataQuery');
global.jsSqlServerFormatter = global.sqlFormatter = require('jsSqlServerFormatter');
// *******************************************************************************

// *************************** FMW FILES *****************************************
// fmw mdlw
require('../client/components/metadata/MetaApp');
require('../client/components/metadata/LocalResource');
require('../client/components/metadata/Enum.js');
require('../client/components/i18n/LocalResourceIt.js');
require('../client/components/metadata/Config.js');
require('../client/components/metadata/Logger.js');
require('../client/components/metadata/DbProcedureMessage.js');
require('../client/components/metadata/Routing.js');
require('../client/components/metadata/EventManager.js');
require('../client/components/metadata/Utils.js');
require('../client/components/metadata/GetDataUtils.js');
require('../client/components/metadata/MetaModel.js');
require('../client/components/metadata/GetData.js');
require('../client/components/metadata/Security.js');
require('../client/components/metadata/AuthManager.js');
require('../client/components/metadata/BootstrapModal.js');
require('../client/components/metadata/LoaderControl.js');
require('../client/components/metadata/TypedObject.js');
require('../client/components/metadata/MetaData.js');

// be file
require('./utils/metaPortale');

// Base class
require('../client/componentsEasy/metadata/MetaEasyData');
require('../client/app_segreterie/metadata/MetaSegreterieData');

// Add ----> MetaDati
// require('../client/metadata/meta_registry');

// ************************** FMW REQUIRE END ************************************


// ****************************** middlware to manage BODY ************************
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());
app.use(bodyParser.raw());
// ****************************** END POST BODY **********************************


// ****************************** CORS MANAGEMENT **********************************
app.use((req, res, next) => {
    res.header("Access-Control-Allow-Origin", "*");
    res.header(
      "Access-Control-Allow-Headers",
      "Origin, X-Requesred-With, Content-Type, Accept, Authorization"
    );
    if (req.method === 'OPTIONS') {
        res.header('Access-Control-allow-Methods', 'GET, PUT, POST, PATCH, DELETE');
        return res.status(200).json({})
    }
    return next();
});
// ****************************** END CORS MANAGEMENT *********************************


// ****************************** LOGGING MANAGEMENT *********************************
// Logging rest api --> npm install --save morgan
app.use(morgan('dev'));
// ****************************** END LOGGING MANAGEMENT *****************************

// ****************************** ROUTES MANAGEMENT **********************************
// Routes, definisci route nell'array arrayRoutes
const dataRoute = '/data/';
const authRoute = '/auth/';

/**
 * builds tha path of the route
 * @param {string} rootRoute
 * @param {string} routeMethod
 * @returns {string} ie: ./api/data/<myMethod> or .api/auth/<myMethod>
 */
getRoute = (rootRoute, routeMethod) => {
    const routePrefix = './api';
    return routePrefix + rootRoute + routeMethod;
};

// loops on routes (rest service): folder api/data or api/auth
// ------> DATA ROUTES
const arrayDataRoutes = [
    'getPagedTable',
    'getDataSet',
    'select',
    'multiRunSelect',
    'getDsByRowKey',
    'saveDataSet',
    'doGet'
];
_.forEach(arrayDataRoutes, (route) => {
    const routeImport = require(getRoute(dataRoute, route));
    app.use(dataRoute + route, routeImport);
});

// ------> AUTH ROUTES
const arrayAuthRoutes = [
    'login'
];
_.forEach(arrayAuthRoutes, (route) => {
    const routeImport = require(getRoute(authRoute, route));
    app.use(authRoute + route, routeImport);
});
// **********************************  Routes MANAGEMENT END ********************************

// ***************************** CACHE INIT *************************************************
initMetaDataCache = () => {
    // init the cache of metadata
    const cache = require('./cache/cache');
    const constant = require('./constants');
    const multiRunSelect = require('./api/data/multiRunSelect');
    const ds = new jsDataSet.DataSet("temp");
    const selBuilderArray = [
        constant.METADATAMANAGEDTABLE,
        constant.METADATAPRIMARYKEY,
        constant.METADATASORTING,
        constant.METADATASTATICFILTER
    ].reduce((acc , tname) => {
        acc.push({ filter: null, top: null, tableName: tname });
        return acc;
    }, []);
    multiRunSelect.multiRunSelect(selBuilderArray, ds)
        .then(() => cache.initMetaDataCache(ds));
};

initCache = () => {
    initMetaDataCache();
};

initCache();
// ***************************** END CACHE INIT **********************************************

module.exports = app;

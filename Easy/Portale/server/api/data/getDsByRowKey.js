
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


const express = require('express');
const router = express.Router();
const getData = require('jsGetData');
const dbconn = require('../../dbconn/dbconn');
const datasetUtils = require('../utils/datasetUtils');
/**
 * Read json dataset form keys tableName and edittype and a filter. It populates the rows based on that main row
 * @type {path.PlatformPath | path}
 */
const path = require('path');
router.post('/', (req, res, next) => {

    // N.B INDAGARE meglio. per far funzionare il metodo ho dovuto apportare 2 modifiche allo strato sottostante, perchè il ds non veniva popolato
    // in quanto ild ef non fa le notify e i chiamanti nella progress non aggiornano i datatable con le righe che nel frattempo vengono caricate
    // dalle query:
    // 1. riga 302 di edje-sql  	if (raw) -> if (true) . Non capisco come passare raw = true tra le opzioni
    // 2. riga 1192 di jsDataAccess if (r.meta) -> if (false)
    // 3. riga 303 di jsGetData: funzione per ricostruire la riga. arrivano 2 array meta con le colonne e rows con le righe con solo i valori
    // 4. le funzioni del fmw in getDataUtils con il be di tipo nodejs non devono effettuare la normalizzazione delle date poichè
    //    la stringfy applica il offset , ma la parse lo toglie quindi la data in qiesto caso visggia bene tra fe e be (diversamente invece da be .net in cui si ha bisogno di normalizzare la data)

    const tableName = req.body.tableName;
    const editType = req.body.editType;
    const filterPrm = req.body.filter;

    // leggo da ds vuoto e recupero tabella principale
    const ds = datasetUtils.createAndGetEmptyDataSet(tableName, editType);
    var table = ds.tables[tableName];

    dbconn.getDataAccess()
        .then((DAC) => {
            // preparo i prm di inpout per "fillDataSetByFilter"
            const ctx = {dataAccess: DAC};
            // trasforma il filtro passato in input in jsDataQuery
            const filter = appMeta.getDataUtils.getJsDataQueryFromJson(filterPrm);

            getData.fillDataSetByFilter(ctx, ds, table, filter)
                .then(() => {
                    let json = appMeta.getDataUtils.getJsonFromJsDataSet(ds, true);
                    res.status(200).json(json);
                }, err => {
                    res.status(500).json("fillDataSetByFilter failed: " + err);
                })

        }, err =>   res.status(500).json("conn to DataAccess failed: " + err));

});

module.exports = router;

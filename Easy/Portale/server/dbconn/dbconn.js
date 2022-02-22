
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


let  Deferred = require("jsDeferred");
let  DA = require("jsDataAccess");

const dbConfig =
    {
        "server": "185.56.8.51,5839",
        useTrustedConnection: false,
        "database": "unibas_easy",
        "user": "assistenza",
        "pwd": "123***********"
    };

const sqlServerDriver = require('jsSqlServerDriver'),
    IsolationLevel = {
        readUncommitted: 'READ_UNCOMMITTED',
        readCommitted: 'READ_COMMITTED',
        repeatableRead: 'REPEATABLE_READ',
        snapshot: 'SNAPSHOT',
        serializable: 'SERIALIZABLE'
    };

// create a pool of connection shared
module.exports = {
        //La connessione andrebbe presa dal DataAccess e non separatamente
        getConnection: () => {
                let conn;
                if (!conn) {
                        conn = new sqlServerDriver.Connection(dbConfig);
                }
                return conn;
        },
        getDataAccess: () => {
                const q = Deferred(), sqlConn = new sqlServerDriver.Connection(dbConfig);
                let da = new DA.DataAccess({
                        sqlConn: sqlConn,
                        errCallBack: function (err) {
                                q.reject(err);
                        },
                        doneCallBack: function (d) {
                                q.resolve(d);
                        }
                });
                return q.promise();
        }
};

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


'use strict';
var Deferred = require("jsDeferred");
var _ = require('lodash');

function Environment() {
    this.mySys = {};
    this.myUsr = {};
    this.stampFields = {};
}
Environment.prototype.sys = function (key, value) {
    if (value !== undefined) {
        this.mySys[key] = value;
        return this;
    }
    return this.mySys[key];
};

Environment.prototype.usr = function (key, value) {
    if (value !== undefined) {
        this.myUsr[key] = value;
        return this;
    }
    return this.myUsr[key];
};

/**
 * Get a value for a field
 * @method field
 * @param {string} fieldName
 * @returns {object}
 */
Environment.prototype.field = function (fieldName) {
    return undefined;
};


Environment.prototype.enumSys = function () {
    return _.keys(this.mySys);
};

Environment.prototype.enumUsr = function () {
    return _.keys(this.myUsr);
};

function defaultQuoter(s, noSurroundQuotes) {
    if (noSurroundQuotes) {
        if (s === null || s === undefined) {
            return 'null';
        }
        if (typeof s === 'string' || s instanceof String) {
            return s;
        }
        return s.toString();
    }

    if (s === null || s === undefined) {
        return 'null';
    }
    if (typeof s === 'string' || s instanceof String) {
        return "'" + s.replace("'", "\\'") + "'";
    }
    return s.toString();
}

Environment.prototype.compile = function (str, quoteFun, surroundQuotes) {
    quoteFun = quoteFun || defaultQuoter;
    if (surroundQuotes === undefined) {
        surroundQuotes = false;
    }
    var s = '',
        prev = '',
        that = this,
        replaceSys = function (match, p1) {
            return quoteFun(that.mySys[p1], !surroundQuotes);
        },
        replaceUsr = function (match, p1) {
            return quoteFun(that.myUsr[p1], !surroundQuotes);
        };
    while (prev !== str) {
        prev = str;
        s = str.replace(/(?:<%sys\[)[\s]*([\w]+)[\s]*(?:\]%>)/g, replaceSys);
        s = s.replace(/(?:<%usr\[)[\s]*([\w]+)[\s]*(?:\]%>)/g, replaceUsr);
        str = s;
    }
    return s;
};

Environment.prototype.compileFun = function(sqlFun,formatter) {
    return sqlFun.toSql(formatter,this);
};

module.exports = Environment;


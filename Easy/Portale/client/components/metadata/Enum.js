
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
     * Type of position of listManager control
     * inpage: such as for the list on search.
     * modal: for example in autochoose
     * relative: for droDowncontrol
     * @type {{inpage: string, modal: string, relative: string}}
     */
    var E_LISTMANAGER_POSITION_TYPE = {
        inpage: "inpage",
        modal: "modal",
        relative: "relative"
    };

    appMeta.E_LISTMANAGER_POSITION_TYPE = E_LISTMANAGER_POSITION_TYPE;
}());

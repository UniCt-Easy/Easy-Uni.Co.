
/*
Easy
Copyright (C) 2022 Universit‡ degli Studi di Catania (www.unict.it)
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
 * @module ConfigDev
 * @description
 * Contains global variables used in test environment
 */
(function () {

    var configDev = {
        // dati per login e utente gi√† registrato
        /*userName:"riccardo2",
        password:"65266DC08B",
        email : 'riccardo@treagles.it',
        codiceFiscale : 'cf',
        partitaIva :  '08586690961',
        cognome :  'proietti',
        nome: 'riccardo',
        dataNascita:  '02/10/1980',*/

        //userName: "vis_psuma",
        //password: "vis_psuma",
        userName: "riccardotest",
		password: "riccardotest",
        email : 'info@treagles.it',
        codiceFiscale : 'cf',
        partitaIva :  '08586690961',
        cognome :  'riccardotestProietti',
        nome: 'riccardotestNome',
        dataNascita:  '02/10/1980',

        // dati per login e utente per reset passoword
        userNameResetPassword: 'riccardo2',
        passwordResetPassword: 'riccardo2',
        emailResetPassword: 'riccardo@treagles.it',


        userName2: "riccardotest",
        password2:"riccardotest",
        email2 : 'info@treagles.it',
        codiceFiscale2 : 'cf',
        partitaIva2 :  '08586690961',
        cognome2 :  'riccardotestProietti',
        nome2: 'riccardotestNome',
        dataNascita2:  '02/10/1980',

        datacontabile : new Date()

    };

    appMeta.configDev = configDev;
}());



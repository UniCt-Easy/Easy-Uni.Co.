/**
 * @module PartitaIva
 * @description
 * Contains the common methods to check Italian PartitaIva
 */
(function () {

    // Deriva da MetaApp
    var MetaApp = appMeta.MetaApp;
    /**
     * @constructor PartitaIva
     * @description
     * Utilities for calculate  and validate PartitaIva on web app developed wth MDLW
     */
    function PartitaIva() {
        "use strict";

        this.errorepiva = [
            'OK',
            'Ultimo carattere non coerente con gli altri caratteri',
            'La partita IVA deve essere composta da 11 caratteri numerici',
            'Si è verificata una eccezione generica'];

        this.simplehash = new Object();
        // or
        // var simplehash = {};

        this.simplehash['AT'] = [9];
        this.simplehash['BE'] = [10];
        this.simplehash['BG'] = [9];
        this.simplehash['HR'] = [11];
        this.simplehash['DE'] = [9];
        this.simplehash['DK'] = [8];
        this.simplehash['EL'] = [9];
        this.simplehash['ES'] = [9];
        this.simplehash['FI'] = [8]
        this.simplehash['FR'] = [11];
        this.simplehash['GB'] = [9, 12];
        this.simplehash['IE'] = [8, 9];
        this.simplehash['IT'] = [11];
        this.simplehash['LU'] = [8];
        this.simplehash['NL'] = [12];
        this.simplehash['SE'] = [12];
        this.simplehash['CY'] = [9];
        this.simplehash['EE'] = [9];
        this.simplehash['LV'] = [11];
        this.simplehash['LT'] = [9, 12];
        this.simplehash['MT'] = [8];
        this.simplehash['PL'] = [10];
        this.simplehash['PT'] = [9];
        this.simplehash['CZ'] = [8, 9, 10];
        this.simplehash['SK'] = [9, 10];
        this.simplehash['SI'] = [8];
        this.simplehash['HU'] = [8];
        this.simplehash['RO'] = [2, 3, 4, 5, 6, 7, 8, 9, 10];
        //for (var key in this.simplehash) {
        //    // use hasOwnProperty() to filter out properties from Object.prototype
        //    if (this.simplehash.hasOwnProperty(key)) {
        //        console.log('key is: ' + key + ', value is: ' + this.simplehash[key]);
        //    }
        //}

    }

    PartitaIva.prototype = {
        constructor: PartitaIva,

        //-----------------------------------  New ------------------------------------------

        controllaPartitaIva: function (r) {
            var def = appMeta.Deferred("controllaPartitaIva");
            var outobj = {};
            outobj.isValid = false;
            outobj.errMsg = "";
            outobj.errField = "piva";
            outobj.outCaption = "PartitaIva";
            outobj.row = r;

            var errori = "";

            if ((r.current.p_iva == null) || (r.current.p_iva == '')) {
                outobj.isValid = true;
                def.resolve(outobj);
                return def.promise();
            }

            var PartitaIva = r.current.p_iva;

            if (PartitaIva.length < 3) {
                errori += "(La partita IVA italiana è composta da 11 numeri; la partita IVA straniera deve "+
                    + "cominciare con la sigla della nazione).Lunghezza P.iva inserita: " + PartitaIva.length + ") ";
                outobj.isValid = false;
                outobj.errMsg = errori;
                def.resolve(outobj);
                return def.promise();
            }

            if ((PartitaIva.substr(0, 1) >= '0') && (PartitaIva.substr(0, 1) <= '9') && (PartitaIva.substr(1, 2) >= '0') && (PartitaIva.substr(1, 2) <= '9')) {
                var errorePIvaIt = this.controllaPartitaIvaItaliana(PartitaIva, 'F');
                if (errorePIvaIt != 0) {
                    //ritorna false + errore letto dall'array errorepiva descritto sopra.
                    errori += this.errorepiva[errorePIvaIt];
                    outobj.isValid = false;
                    outobj.errMsg = errori;
                    def.resolve(outobj);
                    return def.promise();
                }
                else {
                    outobj.isValid = true;
                    def.resolve(outobj);
                    return def.promise();
                }
            }

            if (PartitaIva.substr(0, 2).toUpperCase() == "IT") {
                //return errore[2];
                errori += this.errorepiva[2];
                outobj.isValid = false;
                outobj.errMsg = errori;
                def.resolve(outobj);
                return def.promise();

            }
            //da controllare
            var Codenazione = PartitaIva.substr(0, 2).toUpperCase();
            //controlla che siano interi

            //var ValoreH = simplehash.get_siglanazione(Codnazione);
            var lensNazione = this.get_siglanazione(Codenazione);
            if (lensNazione == null) {
                errori += "I primi due caratteri non identificano un Paese UE";
                outobj.isValid = false;
                outobj.errMsg = errori;
                def.resolve(outobj);
                return def.promise();
            }
            var lunghezzaInserita = PartitaIva.length - 2;
            var ll = "";
            var isok = false;
            for (var i = 0; i < lensNazione.length; i++) {
                if (lunghezzaInserita == lensNazione[i]) {
                    isok = true;
                    break;
                }
                if (ll != "") ll += ",";
                ll += lensNazione[i];
            }

            if (!isok) {
                errori += "La partita IVA che comincia con "
                    + PartitaIva.substr(0, 2).toUpperCase()
                    + " deve contenere una quantità di numeri pari a :" + ll;
                outobj.isValid = false;
                outobj.errMsg = errori;
                def.resolve(outobj);
                return def.promise();
            }
            else {
                outobj.isValid = true;
                return def.resolve(outobj).promise();
            }

            return def.promise();

        },

        controllaPartitaIvaItaliana: function (piva, controlType) {
            try {
                var str1 = null;
                var totale = 0;
                var somma = 0;//0L; da rivedere
                var numerico = true;

                var vchar = piva;
                for (var i1 = 0; numerico && i1 < piva.length; i1++)
                if ((vchar[i1] < '0') || (vchar[i1] > '9'))
                    numerico = false;
                else
                    somma += vchar[i1];

                if ((piva.length != 11) || !numerico) {
                    return 2;
                }
                if (somma == 0)
                return 0;

                if (controlType == 'I') {
                    if ((piva[0] == '8') || (piva[0] == '9')) {
                        return 4;
                    }
                    var prov = parseInt(piva.substr(7, 3));
                    if ((prov != 121) && (prov != 120) && ((1 > prov) || (prov > 100)) && (prov != 999)) {
                        return 5;
                    }
                }
                for (var i = 1; i < 11; i += 2) {
                    var integer1 = parseInt(piva.substr(i, 1));
                    str1 = (integer1 * 2).toString();
                    for (var j = 0; j < str1.length; j++) {
                        var integer3 = parseInt(str1.substr(j, 1));
                        totale += integer3;
                    }

                }

                for (var k = 0; k < 9; k += 2) {
                    var integer4 = parseInt(piva.substr(k, 1));
                    totale += integer4;
                }

                var ultimocarattere = parseInt(piva.substr(10, 1));
                if (totale % 10 == 0) {
                    if (totale % 10 == ultimocarattere)
                        return 0;
                    else
                        return 1;
                }
                else
                    if (10 - totale % 10 == ultimocarattere)
                        return 0;
                    else
                        return 1;
            }
            catch (err) {
                return 3;
            }
        },

        get_siglanazione: function (key_sigla) {
            var value = this.simplehash[key_sigla];
            return value; // da controllare

        },


    };


    appMeta.PartitaIva = new PartitaIva();
}());



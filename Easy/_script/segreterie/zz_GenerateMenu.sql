
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


exec menuweb_addentry @idmenuwebparent = NULL, @idx = 1, @tableName = null, @editType = null, @label = 'Tutti i Menù';
exec menuweb_addentry @idmenuwebparent = 1, @idx = 29, @tableName = null, @editType = null, @label = 'Menù dell''applicazione delle segreterie';
exec menuweb_addentry @idmenuwebparent = 29, @idx = 400, @tableName = null, @editType = null, @label = 'Amministrazione';
exec menuweb_addentry @idmenuwebparent = 29, @idx = 81, @tableName = null, @editType = null, @label = 'Segreteria didattica';
exec menuweb_addentry @idmenuwebparent = 29, @idx = 83, @tableName = null, @editType = null, @label = 'Segreteria amministrativa';
exec menuweb_addentry @idmenuwebparent = 29, @idx = 296, @tableName = null, @editType = null, @label = 'Progetti di ricerca e attività istituzionali';
exec menuweb_addentry @idmenuwebparent = 400, @idx = 41, @tableName = null, @editType = null, @label = 'Elenchi';
exec menuweb_addentry @idmenuwebparent = 400, @idx = 143, @tableName = null, @editType = null, @label = 'Configurazioni';
exec menuweb_addentry @idmenuwebparent = 400, @idx = 177, @tableName = null, @editType = null, @label = 'Tipologie';
exec menuweb_addentry @idmenuwebparent = 400, @idx = 244, @tableName = null, @editType = null, @label = 'Definizione delle tasse';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 57, @tableName = 'sasd', @editType = 'default', @label = 'Settori artistico-scientifico disciplinari';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 72, @tableName = 'classconsorsuale', @editType = 'default', @label = 'Classi di concorso MIUR';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 145, @tableName = 'ccnl', @editType = 'default', @label = 'Contratti Collettivi Nazionali del Lavoro';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 170, @tableName = 'areadidattica', @editType = 'default', @label = 'Aeree didattiche';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 178, @tableName = 'istattitolistudio', @editType = 'default', @label = 'Titoli di studio ISTAT';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 180, @tableName = 'classescuola', @editType = 'default', @label = 'Scuole / Classi di laurea';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 186, @tableName = 'upb', @editType = 'default', @label = 'Unità previsionali di base';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 191, @tableName = 'geo_nation', @editType = 'seg', @label = 'Nazioni';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 193, @tableName = 'geo_continent', @editType = 'default', @label = 'Continenti';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 194, @tableName = 'geo_country', @editType = 'seg', @label = 'Province';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 195, @tableName = 'geo_region', @editType = 'seg', @label = 'Regioni';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 196, @tableName = 'geo_city', @editType = 'seg', @label = 'Comuni';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 197, @tableName = 'corsostudionorma', @editType = 'default', @label = 'Normativa dei corsi di studio';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 213, @tableName = 'corsostudiolivello', @editType = 'default', @label = 'Livelli dei corsi di studio';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 239, @tableName = 'geo_continent', @editType = 'anagrafica_easyweb', @label = 'Continenti';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 270, @tableName = 'pianostudiostatus', @editType = 'default', @label = 'Stati dei piani di studio';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 278, @tableName = 'nace', @editType = 'default', @label = 'Classificazione delle attività economiche nella Comunità Europea';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 279, @tableName = 'ateco', @editType = 'default', @label = 'Classificazione ATECO';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 292, @tableName = 'sasdgruppo', @editType = 'default', @label = 'Gruppo';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 293, @tableName = 'classescuolaarea', @editType = 'default', @label = 'Area della scuola / classe di laurea';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 294, @tableName = 'classescuolakind', @editType = 'default', @label = 'Tipologia della scuola / classe di laurea';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 295, @tableName = 'ambitoareadisc', @editType = 'default', @label = 'Ambiti o aree disciplinari';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 302, @tableName = 'progettostatuskind', @editType = 'default', @label = 'Stati delle attività o progetti';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 303, @tableName = 'settoreerc', @editType = 'seg', @label = 'Settori dell''European Research Council';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 304, @tableName = 'fonteindicebibliometrico', @editType = 'seg', @label = 'Fonti degli indici bibliometrici';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 306, @tableName = 'settoreerc', @editType = 'segprog', @label = 'Settori dell''European Research Council';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 307, @tableName = 'tax', @editType = 'seg', @label = 'Tipi di ritenuta';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 310, @tableName = 'changes', @editType = 'default', @label = 'Cambiamento per learning agreement';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 311, @tableName = 'changeskind', @editType = 'default', @label = 'Tipo di cambiamenti';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 344, @tableName = 'stipendiokind', @editType = 'default', @label = 'Tabelle stipendiali';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 346, @tableName = 'naturagiur', @editType = 'default', @label = 'Natura giuridica';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 347, @tableName = 'numerodip', @editType = 'default', @label = 'Numero dipendenti';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 348, @tableName = 'inventorytree', @editType = 'seg', @label = 'Classificazione inventariale';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 353, @tableName = 'isced2013', @editType = 'default', @label = 'International Standard Classification of Education (ISCED)';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 354, @tableName = 'cefr', @editType = 'default', @label = 'Quadro europeo comune di riferimento per le lingue';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 357, @tableName = 'bandomobilitaintkind', @editType = 'default', @label = 'Tipologa del bando di mobilità internanzionale';
exec menuweb_addentry @idmenuwebparent = 41, @idx = 397, @tableName = 'currency', @editType = 'default', @label = 'Valute';
exec menuweb_addentry @idmenuwebparent = 81, @idx = 82, @tableName = null, @editType = null, @label = 'Anagrafiche';
exec menuweb_addentry @idmenuwebparent = 81, @idx = 179, @tableName = null, @editType = null, @label = 'Didattica';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 45, @tableName = 'location', @editType = 'aula', @label = 'Aule';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 77, @tableName = 'registry', @editType = 'anagrafica', @label = 'Anagrafica';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 79, @tableName = 'registry', @editType = 'docenti', @label = 'Docenti';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 136, @tableName = 'publicaz', @editType = 'default', @label = 'Pubblicazioni';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 182, @tableName = 'insegn', @editType = 'default', @label = 'Insegnamenti o Campi disciplinari';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 218, @tableName = 'aula', @editType = 'default', @label = 'Aule';
exec menuweb_addentry @idmenuwebparent = 82, @idx = 220, @tableName = 'edificio', @editType = 'default', @label = 'Edifici';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 84, @tableName = null, @editType = null, @label = 'Iscrizioni, rinnovi, conseguimenti e decadenze';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 86, @tableName = null, @editType = null, @label = 'Anagrafiche';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 280, @tableName = null, @editType = null, @label = 'Istanze e delibere';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 283, @tableName = null, @editType = null, @label = 'Protocollo';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 313, @tableName = null, @editType = null, @label = 'Tirocini';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 349, @tableName = null, @editType = null, @label = 'Mobilità internazionale';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 358, @tableName = null, @editType = null, @label = 'Diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 367, @tableName = null, @editType = null, @label = 'Dichiarazioni';
exec menuweb_addentry @idmenuwebparent = 83, @idx = 369, @tableName = null, @editType = null, @label = 'Contabilità studenti';
exec menuweb_addentry @idmenuwebparent = 84, @idx = 274, @tableName = 'iscrizione', @editType = 'seg', @label = 'Iscrizioni';
exec menuweb_addentry @idmenuwebparent = 84, @idx = 308, @tableName = 'decadenza', @editType = 'seg', @label = 'Decadenza';
exec menuweb_addentry @idmenuwebparent = 84, @idx = 381, @tableName = 'sostenimento', @editType = 'segcons', @label = 'Conseguimento del titolo';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 42, @tableName = 'registry', @editType = 'default', @label = 'Anagrafica generale';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 51, @tableName = 'registry', @editType = 'aziende', @label = 'Enti e Aziende';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 52, @tableName = 'registry', @editType = 'istituti', @label = 'Istituti';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 53, @tableName = 'registry', @editType = 'istitutiesteri', @label = 'Istituti esteri';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 174, @tableName = 'registry', @editType = 'studenti', @label = 'Studenti';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 187, @tableName = 'aoo', @editType = 'default', @label = 'Aree organizzative interne';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 212, @tableName = 'sede', @editType = 'default', @label = 'Sedi';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 214, @tableName = 'registry', @editType = 'default', @label = 'Anagrafica generale';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 215, @tableName = 'struttura', @editType = 'default', @label = 'Struttura / Unità organizzativa';
exec menuweb_addentry @idmenuwebparent = 86, @idx = 300, @tableName = 'registry', @editType = 'amministrativi', @label = 'Personale Amministrativo';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 146, @tableName = 'menuweb', @editType = 'tree', @label = 'Menù';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 233, @tableName = 'registry', @editType = 'user', @label = 'Pagina di registrazione';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 241, @tableName = 'questionario', @editType = 'default', @label = 'Questionari';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 242, @tableName = 'graduatoriavar', @editType = 'default', @label = 'Variabili delle graduatorie';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 243, @tableName = 'registry', @editType = 'istituti_princ', @label = 'Istituto in gestione';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 277, @tableName = 'graduatoria', @editType = 'default', @label = 'Definizioni delle graduatorie';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 135, @tableName = 'contrattokind', @editType = 'default', @label = 'Tipologie di contratto';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 137, @tableName = 'publicazkind', @editType = 'default', @label = 'Tipologie di pubblicazione ';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 139, @tableName = 'rendicontaltrokind', @editType = 'default', @label = 'Tipologia delle attività da rendicontare oltre le lezioni ';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 141, @tableName = 'studdirittokind', @editType = 'default', @label = 'Categoria dello studente per il diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 142, @tableName = 'studprenotkind', @editType = 'default', @label = 'Tipologia di studente durante la prenotazione';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 171, @tableName = 'corsostudiokind', @editType = 'default', @label = 'Tipologie dei corsi di studio';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 172, @tableName = 'istitutokind', @editType = 'default', @label = 'Tipologia di istituto';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 176, @tableName = 'registryclass', @editType = 'default', @label = 'Tipologia fiscale';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 183, @tableName = 'valutazionekind', @editType = 'default', @label = 'Tipologia di valutazione di una attività didattica';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 211, @tableName = 'strutturakind', @editType = 'default', @label = 'Tipologia delle strutture';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 217, @tableName = 'tipoattform', @editType = 'default', @label = 'Tipologia delle attività formative';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 221, @tableName = 'valutazionekind', @editType = 'seg_child', @label = 'Tipologia di valutazione di una attività didattica';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 223, @tableName = 'aulakind', @editType = 'default', @label = 'Tipologie delle aule';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 225, @tableName = 'affidamentokind', @editType = 'default', @label = 'Tipologie di affidamento';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 227, @tableName = 'erogazkind', @editType = 'default', @label = 'Tipologie di erogazione della didattica';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 229, @tableName = 'sessionekind', @editType = 'default', @label = 'Tipologie di sessione';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 230, @tableName = 'appellokind', @editType = 'default', @label = 'Tipologie di appello';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 263, @tableName = 'istanzakind', @editType = 'default', @label = 'Tipologie di istanza';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 264, @tableName = 'ofakind', @editType = 'default', @label = 'Titologie di obblighi formativi aggiuntivi';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 265, @tableName = 'questionariodomkind', @editType = 'default', @label = 'Tipologie di  domande del questionario';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 266, @tableName = 'questionariokind', @editType = 'default', @label = 'Tipologie di questionario';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 267, @tableName = 'tirociniocandidaturakind', @editType = 'default', @label = 'Tipologia di candidatura ad un tirocinio';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 268, @tableName = 'tirociniostato', @editType = 'default', @label = 'Stato dei tirocini';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 269, @tableName = 'appelloazionekind', @editType = 'default', @label = 'Titologie di azione in appello';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 271, @tableName = 'sostenimentoesito', @editType = 'default', @label = 'Esito';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 290, @tableName = 'dichiarkind', @editType = 'default', @label = 'Tipi di dichiarazione';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 298, @tableName = 'orakind', @editType = 'seg', @label = 'Tipologia di ore';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 305, @tableName = 'progettoactivitykind', @editType = 'default', @label = 'Tipo di attività o progetto';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 345, @tableName = 'duratakind', @editType = 'default', @label = 'Tipo di durata';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 365, @tableName = 'accreditokind', @editType = 'default', @label = 'Tipi di accredito in una richiesta di partecipazione al bando per il diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 366, @tableName = 'convalidakind', @editType = 'default', @label = 'Tipologie di convalida';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 376, @tableName = 'dichiardisabilkind', @editType = 'default', @label = 'Tipologie di disabilità';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 377, @tableName = 'dichiardisabilsuppkind', @editType = 'default', @label = 'Tipologie dichiarazioni disabilita';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 382, @tableName = 'dichiaraltrekind', @editType = 'default', @label = 'Tipologia delle altre dichiarazioni';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 383, @tableName = 'dichiaraltrekind', @editType = 'elenchi', @label = 'Tipologia delle altre dichiarazioni';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 392, @tableName = 'bandodsiscresitokind', @editType = 'default', @label = 'Esito della partecipazione al bando per il diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 177, @idx = 401, @tableName = 'progettoudrmembrokind', @editType = 'default', @label = 'Tipologia di membro delle unità di personale';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 181, @tableName = 'didprog', @editType = 'default', @label = 'Didattiche programmate';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 188, @tableName = 'corsostudio', @editType = 'default', @label = 'Corsi di studio';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 219, @tableName = 'diderog', @editType = 'default', @label = 'Didattica Erogata';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 226, @tableName = 'appello', @editType = 'default', @label = 'Appelli';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 228, @tableName = 'sessione', @editType = 'default', @label = 'Sessioni di esami';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 232, @tableName = 'corsostudio', @editType = 'ingresso', @label = 'Prove di ammissione';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 272, @tableName = 'corsostudio', @editType = 'dotmas', @label = 'Master';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 273, @tableName = 'corsostudio', @editType = 'stato', @label = 'Esami di stato';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 276, @tableName = 'pianostudio', @editType = 'segstud', @label = 'Piani di studio';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 312, @tableName = 'pratica', @editType = 'segstud', @label = 'Pratica di convalida/riconoscimento/dispensa';
exec menuweb_addentry @idmenuwebparent = 179, @idx = 391, @tableName = 'getcostididattica', @editType = 'default', @label = 'Riepilogo dei costi degli affidamenti';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 246, @tableName = 'costoscontodef', @editType = 'default', @label = 'Costi';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 247, @tableName = 'costoscontodef', @editType = 'sconti', @label = 'Sconti';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 248, @tableName = 'costoscontodef', @editType = 'more', @label = 'Indennità / More';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 249, @tableName = 'costoscontodefdettagliokind', @editType = 'default', @label = 'Voci dei dettaglio debito';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 250, @tableName = 'esonero', @editType = 'default', @label = 'Definizione degli esoneri generici';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 251, @tableName = 'esonero', @editType = 'carriera', @label = 'Definizione degli esoneri  derivanti dalla carriera';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 252, @tableName = 'esonero', @editType = 'disabil', @label = 'Definizione degli esoneri di invalidità';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 253, @tableName = 'esonero', @editType = 'titolostudio', @label = 'Definizione degli esoneri per titoli di studio conseguiti';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 254, @tableName = 'fasciaisee', @editType = 'default', @label = 'Fasce ISEE';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 255, @tableName = 'pagamentokind', @editType = 'default', @label = 'Tipologie di pagamento';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 256, @tableName = 'ratakind', @editType = 'default', @label = 'Rate';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 257, @tableName = 'tassaconf', @editType = 'default', @label = 'Definizione dei costi generici';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 258, @tableName = 'tassaconfkind', @editType = 'default', @label = 'Definizione delle tasse generiche';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 259, @tableName = 'tassacsingconf', @editType = 'default', @label = 'Definizione dei costi dei corsi singoli';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 260, @tableName = 'tassaiscrizioneconf', @editType = 'default', @label = 'Definizione delle tasse di iscrizione';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 261, @tableName = 'tassaistanzaconf', @editType = 'default', @label = 'Definizione dei costi delle istanze';
exec menuweb_addentry @idmenuwebparent = 244, @idx = 262, @tableName = 'costoscontodefkind', @editType = 'default', @label = 'Tipologia tra Costo, Sconto, Mora, indennizzo';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 287, @tableName = 'istanza', @editType = 'imm_segpre', @label = 'Istanze di preimmatricolazione';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 288, @tableName = 'istanza', @editType = 'imm_seg', @label = 'Istanze di immatricolazione';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 289, @tableName = 'istanza', @editType = 'imm_segrin', @label = 'Istanze di rinnovo iscrizione';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 385, @tableName = 'istanza', @editType = 'rin_seg', @label = 'Istanza di rinuncia agli studi';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 386, @tableName = 'istanza', @editType = 'tru_seg', @label = 'Istanza di trasferimento in uscita';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 387, @tableName = 'istanza', @editType = 'eq_seg', @label = 'Istanza di equipollenza ';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 388, @tableName = 'istanza', @editType = 'cert_seg', @label = 'Richiesta di certificato';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 389, @tableName = 'istanza', @editType = 'sosp_seg', @label = 'Istanza di sospensione degli studi';
exec menuweb_addentry @idmenuwebparent = 280, @idx = 390, @tableName = 'delibera', @editType = 'seg', @label = 'Delibere';
exec menuweb_addentry @idmenuwebparent = 283, @idx = 284, @tableName = 'protocollo', @editType = 'seg', @label = 'Registrazioni di protocollo';
exec menuweb_addentry @idmenuwebparent = 283, @idx = 285, @tableName = 'protocollodockind', @editType = 'seg', @label = 'Tipo di documento protocollato';
exec menuweb_addentry @idmenuwebparent = 283, @idx = 286, @tableName = 'protocollorifkind', @editType = 'seg', @label = 'Tipo di documento di riferimento';
exec menuweb_addentry @idmenuwebparent = 296, @idx = 297, @tableName = 'progetto', @editType = 'seg', @label = 'Progetti e attività';
exec menuweb_addentry @idmenuwebparent = 296, @idx = 299, @tableName = 'progettokind', @editType = 'seg', @label = 'Tipo di progetto o attività';
exec menuweb_addentry @idmenuwebparent = 313, @idx = 342, @tableName = 'convenzione', @editType = 'seg', @label = 'Convenzioni';
exec menuweb_addentry @idmenuwebparent = 313, @idx = 343, @tableName = 'tirocinioproposto', @editType = 'seg', @label = 'Proposte di tirocinio';
exec menuweb_addentry @idmenuwebparent = 349, @idx = 350, @tableName = 'programmami', @editType = 'seg', @label = 'Programmi di cooperazione';
exec menuweb_addentry @idmenuwebparent = 349, @idx = 351, @tableName = 'accordoscambiomi', @editType = 'seg', @label = 'Accordi bilaterali';
exec menuweb_addentry @idmenuwebparent = 349, @idx = 352, @tableName = 'bandomi', @editType = 'seg', @label = 'Bandi di mobilità';
exec menuweb_addentry @idmenuwebparent = 349, @idx = 356, @tableName = 'assicurazione', @editType = 'default', @label = 'Assicurazione';
exec menuweb_addentry @idmenuwebparent = 358, @idx = 359, @tableName = 'bandods', @editType = 'seg', @label = 'Bandi di diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 359, @idx = 360, @tableName = 'bandods', @editType = 'seg', @label = 'Bandi di diritto allo studio';
exec menuweb_addentry @idmenuwebparent = 367, @idx = 371, @tableName = 'dichiar', @editType = 'altrititoli_seg', @label = 'Altri titoli';
exec menuweb_addentry @idmenuwebparent = 367, @idx = 378, @tableName = 'dichiar', @editType = 'altre_seg', @label = 'Altre dichiarazioni';
exec menuweb_addentry @idmenuwebparent = 367, @idx = 379, @tableName = 'dichiar', @editType = 'disabil_seg', @label = 'Dichiarazione di disabilità';
exec menuweb_addentry @idmenuwebparent = 367, @idx = 380, @tableName = 'dichiar', @editType = 'isee_seg', @label = 'Attestazione ISEE';
exec menuweb_addentry @idmenuwebparent = 367, @idx = 384, @tableName = 'dichiar', @editType = 'titolo_seg', @label = 'Dichiarazione titoli di studio';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 405, @tableName = 'registry', @editType = 'admin', @label = 'Funzioni di amministrazione';
--docenti
exec menuweb_addentry @idmenuwebparent = 29, @idx = 415, @tableName = null, @editType = null, @label = 'I miei dati';
exec menuweb_addentry @idmenuwebparent = 29, @idx = 416, @tableName = null, @editType = null, @label = 'I miei corsi';
exec menuweb_addentry @idmenuwebparent = 29, @idx = 421, @tableName = null, @editType = null, @label = 'Le mie attività di ricerca e istituzionali';
exec menuweb_addentry @idmenuwebparent = 421, @idx = 417, @tableName = 'assetdiary', @editType = 'doc', @label = 'Diari di utilizzo di beni strumentali';
exec menuweb_addentry @idmenuwebparent = 416, @idx = 418, @tableName = 'affidamento', @editType = 'doc', @label = 'Affidamento';
exec menuweb_addentry @idmenuwebparent = 421, @idx = 419, @tableName = 'rendicontattivitaprogetto', @editType = 'doc', @label = 'Attività di ricerca';
exec menuweb_addentry @idmenuwebparent = 415, @idx = 420, @tableName = 'registry', @editType = 'docenti_doc', @label = 'Dati personali';
--amministrativi
exec menuweb_addentry @idmenuwebparent = 415, @idx = 422, @tableName = 'registry', @editType = 'amministrativi_personale', @label = 'Dati personali';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 428, @tableName = 'bolla', @editType = 'demo', @label = 'Bolle';
exec menuweb_addentry @idmenuwebparent = 143, @idx = 429, @tableName = 'prodotto', @editType = 'demo', @label = 'Prodotti';
--menu

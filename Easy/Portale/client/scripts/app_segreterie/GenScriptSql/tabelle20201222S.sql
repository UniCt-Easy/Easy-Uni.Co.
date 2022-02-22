
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


setuser 'amministrazione'

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
exec menuweb_addentry @idmenuwebparent = 82, @idx = 136, @tableName = 'publicaz', @editType = 'default', @label = 'Pubblicazione';
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
exec menuweb_addentry @idmenuwebparent = 86, @idx = 42, @tableName = 'registry', @editType = 'default', @label = 'Anagrafica Generale';
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
exec menuweb_addentry @idmenuwebparent = 296, @idx = 299, @tableName = 'progettokind', @editType = 'seg', @label = 'Tipi di progetto o attività';
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
exec menuweb_addentry @idmenuwebparent = 143, @idx = 408, @tableName = 'registry', @editType = 'admin', @label = 'Funzioni di amministrazione';
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
--menu

?exec GenerateRule @table = 'progettokind', @code = 'PROGETTOKIND01', @message = 'Non è possibile mettere la stessa causale ep su voci di costo diverse della stessa tipologia di progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa causale ep su voci di costo diverse della stessa tipologia di progetto
([
select count(*) from (
	select count(*) as cc, idaccmotive, idprogettokind  
	from progettotipocostokindaccmotive
	where idprogettokind = %<progettokind.idprogettokind>%
	group by idaccmotive, idprogettokind
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progettokind', @code = 'PROGETTOKIND02', @message = 'Non è possibile mettere la stessa tipologia di contratto su voci di costo diverse della stessa tipologia di progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa tipologia di contratto su voci di costo diverse della stessa tipologia di progetto
([
select count(*) from (
	select count(*) as cc, idcontrattokind, idprogettokind  
	from progettotipocostokindcontrattokind
	where idprogettokind = %<progettokind.idprogettokind>%
	group by idcontrattokind, idprogettokind
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progettokind', @code = 'PROGETTOKIND03', @message = 'Non è possibile mettere la stessa classificazione inventariale su voci di costo diverse della stessa tipologia di progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa classificazione inventariale su voci di costo diverse della stessa tipologia di progetto
([
select count(*) from (
	select count(*) as cc, idinv, idprogettokind  
	from progettotipocostokindinventorytree
	where idprogettokind = %<progettokind.idprogettokind>%
	group by idinv, idprogettokind
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progettokind', @code = 'PROGETTOKIND04', @message = 'Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse della stessa tipologia di progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse della stessa tipologia di progetto
([
select count(*) from (
	select count(*) as cc, taxcode, idprogettokind  
	from progettotipocostokindtax
	where idprogettokind = %<progettokind.idprogettokind>%
	group by taxcode, idprogettokind
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO01', @message = 'Non è possibile mettere la stessa causale ep su voci di costo diverse dello stesso progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa causale ep su voci di costo diverse dello stesso progetto
([
select count(*) from (
	select count(*) as cc, idaccmotive, idprogetto  
	from progettotipocostoaccmotive
	where idprogetto = %<progetto.idprogetto>%
	group by idaccmotive, idprogetto
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO02', @message = 'Non è possibile mettere la stessa tipologia di contratto su voci di costo diverse dello stesso progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa tipologia di contratto su voci di costo diverse dello stesso progetto
([
select count(*) from (
	select count(*) as cc, idcontrattokind, idprogetto  
	from progettotipocostocontrattokind
	where idprogetto = %<progetto.idprogetto>%
	group by idcontrattokind, idprogetto
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO03', @message = 'Non è possibile mettere la stessa classificazione inventariale su voci di costo diverse dello stesso progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa classificazione inventariale su voci di costo diverse dello stesso progetto
([
select count(*) from (
	select count(*) as cc, idinv, idprogetto  
	from progettotipocostoinventorytree
	where idprogetto = %<progetto.idprogetto>%
	group by idinv, idprogetto
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'progetto', @code = 'PROGETTO04', @message = 'Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse dello stesso progetto', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '--post
--Non è possibile mettere la stessa ritenuta a carico dell''ente su voci di costo diverse dello stesso progetto
([
select count(*) from (
	select count(*) as cc, taxcode, idprogetto  
	from progettotipocostotax
	where idprogetto = %<progetto.idprogetto>%
	group by taxcode, idprogetto
) tbl1 where cc > 1
]{I} =0)', @executor = 'rulesGenerator';
exec GenerateRule @table = 'workpackageupb', @code = 'WORKPACKAGEUPB01', @message = 'L''UPB risulta già  associato ad un''altro Workpackage.', @post = 'O', @warning = 'B', @ins = 'S', @upd = 'S', @del = 'N', @sql = '[(select cc from (
select count(*)as cc, idprogetto, idupb  from workpackageupb
group by idprogetto, idupb) tbl1
where idupb= %<workpackageupb.idupb>% and idprogetto = %<workpackageupb.idprogetto>%)]{I} =1', @executor = 'rulesGenerator';
--rule	--LANCIARE SOLO DOPO LO SCRIPT CHE GENERA IL MENU'!!!!!!!!!!!!!!!!!!!!!!!!

--query per la generazione dell'elenco delle variabili di sicurezza da associare
--select variablename  from [restrictedfunction] where idrestrictedfunction in (
--	select idrestrictedfunction 
--	from amministrazione.[FlowChartrestrictedfunction] 
--	where idflowchart = (select top 1 idflowchart from amministrazione.flowchart where codeflowchart = 'SEGDOC')
--	)
--order by variablename

--verifica esistenza nodi
--select * from [amministrazione].[flowchart] where idflowchart in ('202099','202098','20','202096')
IF NOT EXISTS(select * from [amministrazione].[flowchart] where [idflowchart] = '202099')
INSERT INTO [amministrazione].[flowchart]
           ([idflowchart]
           ,[address]
           ,[ayear]
           ,[cap]
           ,[codeflowchart]
           ,[ct]
           ,[cu]
           ,[fax]
           ,[idcity]
           ,[location]
           ,[lt]
           ,[lu]
           ,[nlevel]
           ,[paridflowchart]
           ,[phone]
           ,[printingorder]
           ,[title]
           ,[idsor1]
           ,[idsor2]
           ,[idsor3])
     VALUES
           ('202099'
           ,null
           ,2020
           ,null
           ,'SEGADM'
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,null
           ,null
           ,null
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,1
           ,'20'
           ,null
           ,1
           ,'Segreterie Amministratori'
           ,null
           ,null
           ,null)
GO

IF NOT EXISTS(select * from [amministrazione].[flowchart] where [idflowchart] = '202098')
INSERT INTO [amministrazione].[flowchart]
           ([idflowchart]
           ,[address]
           ,[ayear]
           ,[cap]
           ,[codeflowchart]
           ,[ct]
           ,[cu]
           ,[fax]
           ,[idcity]
           ,[location]
           ,[lt]
           ,[lu]
           ,[nlevel]
           ,[paridflowchart]
           ,[phone]
           ,[printingorder]
           ,[title]
           ,[idsor1]
           ,[idsor2]
           ,[idsor3])
     VALUES
           ('202098'
           ,null
           ,2020
           ,null
           ,'SEGPRG'
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,null
           ,null
           ,null
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,1
           ,'20'
           ,null
           ,1
           ,'Segreterie Progetti Amministratori'
           ,null
           ,null
           ,null)
GO

IF NOT EXISTS(select * from [amministrazione].[flowchart] where [idflowchart] = '202096')
INSERT INTO [amministrazione].[flowchart]
           ([idflowchart]
           ,[address]
           ,[ayear]
           ,[cap]
           ,[codeflowchart]
           ,[ct]
           ,[cu]
           ,[fax]
           ,[idcity]
           ,[location]
           ,[lt]
           ,[lu]
           ,[nlevel]
           ,[paridflowchart]
           ,[phone]
           ,[printingorder]
           ,[title]
           ,[idsor1]
           ,[idsor2]
           ,[idsor3])
     VALUES
           ('202096'
           ,null
           ,2020
           ,null
           ,'SEGDOC'
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,null
           ,null
           ,null
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,1
           ,'20'
           ,null
           ,1
           ,'Docenti'
           ,null
           ,null
           ,null)
GO


IF NOT EXISTS(select * from [amministrazione].[flowchart] where [idflowchart] = '202095')
INSERT INTO [amministrazione].[flowchart]
           ([idflowchart]
           ,[address]
           ,[ayear]
           ,[cap]
           ,[codeflowchart]
           ,[ct]
           ,[cu]
           ,[fax]
           ,[idcity]
           ,[location]
           ,[lt]
           ,[lu]
           ,[nlevel]
           ,[paridflowchart]
           ,[phone]
           ,[printingorder]
           ,[title]
           ,[idsor1]
           ,[idsor2]
           ,[idsor3])
     VALUES
           ('202095'
           ,null
           ,2020
           ,null
           ,'SEGAMM'
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,null
           ,null
           ,null
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,1
           ,'20'
           ,null
           ,1
           ,'Personale amministrativo'
           ,null
           ,null
           ,null)
GO

--diritti Docenti

INSERT INTO [amministrazione].[flowchartrestrictedfunction]
           ([idflowchart]
           ,[idrestrictedfunction]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
           '202096'
           ,rf.idrestrictedfunction
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,CURRENT_TIMESTAMP
           ,'setup'
	 FROM [restrictedfunction] rf
	 WHERE rf.variablename in (
'mr_415'  --menu
,'mr_416'
,'mr_421'
,'mr_417' --interfacce
,'mr_418'
,'mr_419'
,'mr_420'
,'mw_417'
,'mw_418'
,'mw_419'
--,'mw_420' --non pu? modificare i suoi dati
,'all_upb' --elenchi
,'all_man'
,'cespiti_read'
,'missioni' 
)
and not exists(select *  FROM amministrazione.[flowchartrestrictedfunction] fcrf  WHERE fcrf.idflowchart = '202096' and  fcrf.idrestrictedfunction = rf.idrestrictedfunction)

--diritti Personale amministrativo

INSERT INTO [amministrazione].[flowchartrestrictedfunction]
           ([idflowchart]
           ,[idrestrictedfunction]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
           '202095'
           ,rf.idrestrictedfunction
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,CURRENT_TIMESTAMP
           ,'setup'
	 FROM [restrictedfunction] rf
	 WHERE rf.variablename in (
'mr_415'  --menu
,'mr_421'
,'mr_417' --interfacce
,'mr_419'
,'mr_422'
,'mw_417'
,'mw_419'
--,'mw_422' --non pu? modificare i suoi dati
,'all_upb' --elenchi
,'all_man'
,'cespiti_read'
,'missioni'
)
and not exists(select *  FROM amministrazione.[flowchartrestrictedfunction] fcrf  WHERE fcrf.idflowchart = '202095' and  fcrf.idrestrictedfunction = rf.idrestrictedfunction)


--diritti Amministratori segreterie

INSERT INTO [amministrazione].[flowchartrestrictedfunction]
           ([idflowchart]
           ,[idrestrictedfunction]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
           '202099'
           ,rf.idrestrictedfunction
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,CURRENT_TIMESTAMP
           ,'setup'
	 FROM [restrictedfunction] rf
	 WHERE rf.variablename in (
'mandato'
,'reversale'
,'compensi'
,'bilancio'
,'upb'
,'spesa'
,'entrata'
,'ordine'
,'trasmissione'
,'esitazione'
,'fondoec'
,'annullamento'
,'cespiti'
,'iva'
,'anag_c'
,'anag_l'
,'econopatr'
,'liquidazione'
,'stampe'
,'classificazione'
,'contrattivo'
,'impegni'
,'accertamenti'
,'ordinegrande'
,'organigramma'
,'management'
,'dichiarazione'
,'imposta'
,'configurazione'
,'anagrafeprestazioni'
,'consolidamento'
,'man_ufficiale'
,'rev_ufficiale'
,'multiprint'
,'banca'
,'crediti'
,'incassi'
,'coana'
,'contcompensi'
,'contiva'
,'contcontratti'
,'previsione'
,'assestamento'
,'list_man'
,'responsabile'
,'contrattivogrande'
,'list_mfin'
,'list_mupb'
,'menu'
,'anagrafica'
,'sel_cp'
,'sel_ca'
,'bilancio_read'
,'anagrafica_read'
,'spesa_read'
,'entrata_read'
,'trasmissione_read'
,'fondoec_read'
,'adm_localconfig'
,'adm_backup'
,'adm_ondemand'
,'adm_menuupdate'
,'varspesa'
,'varentrata'
,'tax_clawback'
,'endofyear_entry'
,'all_fin'
,'all_upb'
,'all_man'
,'all_mandatekind'
,'all_estimatekind'
,'all_invoicekind'
,'all_pettycash'
,'list_estimatekind'
,'list_invoicekind'
,'list_pettycash'
,'list_mandatekind'
,'fattura'
,'del_invoice'
,'cespiti_read'
,'liquidazioneiva'
,'anag_d'
,'classificazione_mod'
,'anag_dis'
,'chiusura'
,'anag_config'
,'anag_procedure'
,'adm_magazzino'
,'ric_magazzino'
,'config_magazzino'
,'pre_accertamenti'
,'post_accertamenti'
,'pre_impegni'
,'post_impegni'
,'dipendenti'
,'missioni'
,'occasionali'
,'cococo'
,'professionali'
,'stipendi'
,'eco_entry'
,'all_authmodel'
,'list_authmodel'
,'crea_card'
,'admin_card'
,'var_bilancio'
,'asspendenti'
,'movimprotetta'
,'saldicassa'
,'finvarapproved'
,'manage_estimatekind'
,'manage_mandatekind'
,'manage_invoicekind'
,'storniapprove'
,'sitfinanziaria_read'
,'finanziamenti'
,'trasmissione_ap'
,'edit_limit'
,'stornimedesimocapitoloapprove'
,'finvarcredit'
,'sel_fatture'
,'trasmissione_abilita'
,'certificazionecrediti'
,'fe_ipa_rifamm'
,'fe_ipa'
,'fe_all'
,'manage_split_payment'
,'accetta_fe'
,'rifiuta_fe'
,'creaincontabilita_fe'
,'cambia_rifamm'
,'tipologiaincarichi_ap'
,'var_budget'
,'storno_budget'
,'storno_budget_approve'
,'var_budget_approve'
,'edit_epexpresidui'
,'flussostudenti'
,'flussomovimenti'
,'config_bil_sottosezionali'
,'mov_protettecomp'
,'ct_stornocompetenzaclass'
,'pat'
,'UPBsecurity'
,'edit_epaccresidui'
,'flag_escludidacu'
,'notcreacontabilita'
,'flag_authorizationfree'
,'config_stipendi'
,'stipendi_ct'
,'conf_classauto'
,'upd_paymentcompetency'
,'config_account'
,'mw_40'
,'mr_1'
,'mr_29'
,'mr_400'
,'mr_81'
,'mr_83'
,'mr_296'
,'mr_41'
,'mr_143'
,'mr_177'
,'mr_244'
,'mr_57'
,'mw_57'
,'mr_72'
,'mw_72'
,'mr_145'
,'mw_145'
,'mr_170'
,'mw_170'
,'mr_178'
,'mw_178'
,'mr_180'
,'mw_180'
,'mr_186'
,'mw_186'
,'mr_191'
,'mw_191'
,'mr_193'
,'mw_193'
,'mr_194'
,'mw_194'
,'mr_195'
,'mw_195'
,'mr_196'
,'mw_196'
,'mr_197'
,'mw_197'
,'mr_213'
,'mw_213'
,'mr_239'
,'mw_239'
,'mr_270'
,'mw_270'
,'mr_278'
,'mw_278'
,'mr_279'
,'mw_279'
,'mr_292'
,'mw_292'
,'mr_293'
,'mw_293'
,'mr_294'
,'mw_294'
,'mr_295'
,'mw_295'
,'mr_302'
,'mw_302'
,'mr_303'
,'mw_303'
,'mr_304'
,'mw_304'
,'mr_306'
,'mw_306'
,'mr_307'
,'mw_307'
,'mr_310'
,'mw_310'
,'mr_311'
,'mw_311'
,'mr_344'
,'mw_344'
,'mr_346'
,'mw_346'
,'mr_347'
,'mw_347'
,'mr_348'
,'mw_348'
,'mr_353'
,'mw_353'
,'mr_354'
,'mw_354'
,'mr_357'
,'mw_357'
,'mr_397'
,'mw_397'
,'mr_82'
,'mr_179'
,'mr_45'
,'mw_45'
,'mr_77'
,'mw_77'
,'mr_79'
,'mw_79'
,'mr_136'
,'mw_136'
,'mr_182'
,'mw_182'
,'mr_218'
,'mw_218'
,'mr_220'
,'mw_220'
,'mr_84'
,'mr_86'
,'mr_280'
,'mr_283'
,'mr_313'
,'mr_349'
,'mr_358'
,'mr_367'
,'mr_369'
,'mr_274'
,'mw_274'
,'mr_308'
,'mw_308'
,'mr_381'
,'mw_381'
,'mr_42'
,'mw_42'
,'mr_51'
,'mw_51'
,'mr_52'
,'mw_52'
,'mr_53'
,'mw_53'
,'mr_174'
,'mw_174'
,'mr_187'
,'mw_187'
,'mr_212'
,'mw_212'
,'mr_215'
,'mw_215'
,'mr_300'
,'mw_300'
,'mr_146'
,'mw_146'
,'mr_233'
,'mw_233'
,'mr_241'
,'mw_241'
,'mr_242'
,'mw_242'
,'mr_243'
,'mw_243'
,'mr_277'
,'mw_277'
,'mr_135'
,'mw_135'
,'mr_137'
,'mw_137'
,'mr_139'
,'mw_139'
,'mr_141'
,'mw_141'
,'mr_142'
,'mw_142'
,'mr_171'
,'mw_171'
,'mr_172'
,'mw_172'
,'mr_176'
,'mw_176'
,'mr_183'
,'mw_183'
,'mr_211'
,'mw_211'
,'mr_217'
,'mw_217'
,'mr_221'
,'mw_221'
,'mr_223'
,'mw_223'
,'mr_225'
,'mw_225'
,'mr_227'
,'mw_227'
,'mr_229'
,'mw_229'
,'mr_230'
,'mw_230'
,'mr_263'
,'mw_263'
,'mr_264'
,'mw_264'
,'mr_265'
,'mw_265'
,'mr_266'
,'mw_266'
,'mr_267'
,'mw_267'
,'mr_268'
,'mw_268'
,'mr_269'
,'mw_269'
,'mr_271'
,'mw_271'
,'mr_290'
,'mw_290'
,'mr_298'
,'mw_298'
,'mr_305'
,'mw_305'
,'mr_345'
,'mw_345'
,'mr_365'
,'mw_365'
,'mr_366'
,'mw_366'
,'mr_376'
,'mw_376'
,'mr_377'
,'mw_377'
,'mr_382'
,'mw_382'
,'mr_383'
,'mw_383'
,'mr_392'
,'mw_392'
,'mr_401'
,'mw_401'
,'mr_181'
,'mw_181'
,'mr_188'
,'mw_188'
,'mr_219'
,'mw_219'
,'mr_226'
,'mw_226'
,'mr_228'
,'mw_228'
,'mr_232'
,'mw_232'
,'mr_272'
,'mw_272'
,'mr_273'
,'mw_273'
,'mr_276'
,'mw_276'
,'mr_312'
,'mw_312'
,'mr_391'
,'mw_391'
,'mr_246'
,'mw_246'
,'mr_247'
,'mw_247'
,'mr_248'
,'mw_248'
,'mr_249'
,'mw_249'
,'mr_250'
,'mw_250'
,'mr_251'
,'mw_251'
,'mr_252'
,'mw_252'
,'mr_253'
,'mw_253'
,'mr_254'
,'mw_254'
,'mr_255'
,'mw_255'
,'mr_256'
,'mw_256'
,'mr_257'
,'mw_257'
,'mr_258'
,'mw_258'
,'mr_259'
,'mw_259'
,'mr_260'
,'mw_260'
,'mr_261'
,'mw_261'
,'mr_262'
,'mw_262'
,'mr_287'
,'mw_287'
,'mr_288'
,'mw_288'
,'mr_289'
,'mw_289'
,'mr_385'
,'mw_385'
,'mr_386'
,'mw_386'
,'mr_387'
,'mw_387'
,'mr_388'
,'mw_388'
,'mr_389'
,'mw_389'
,'mr_390'
,'mw_390'
,'mr_284'
,'mw_284'
,'mr_285'
,'mw_285'
,'mr_286'
,'mw_286'
,'mr_297'
,'mw_297'
,'mr_299'
,'mw_299'
,'mr_342'
,'mw_342'
,'mr_343'
,'mw_343'
,'mr_350'
,'mw_350'
,'mr_351'
,'mw_351'
,'mr_352'
,'mw_352'
,'mr_356'
,'mw_356'
,'mr_359'
,'mw_359'
,'mr_360'
,'mw_360'
,'mr_371'
,'mw_371'
,'mr_378'
,'mw_378'
,'mr_379'
,'mw_379'
,'mr_380'
,'mw_380'
,'mr_384'
,'mw_384'
,'mr_402'
,'mw_402'
,'mr_403'
,'mw_403'
,'mr_404'
,'mw_404'
,'mr_408'
,'mw_408'

,'mr_417' --interfacce docenti e amministrativi
,'mr_418'
,'mr_419'
,'mw_417'
,'mw_418'
,'mw_419'

)
and not exists(select *  FROM amministrazione.[flowchartrestrictedfunction] fcrf  WHERE fcrf.idflowchart = '202099' and  fcrf.idrestrictedfunction = rf.idrestrictedfunction)


--diriti Amministratori progetti
INSERT INTO [amministrazione].[flowchartrestrictedfunction]
           ([idflowchart]
           ,[idrestrictedfunction]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
           '202098'
           ,rf.idrestrictedfunction
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,CURRENT_TIMESTAMP
           ,'setup'
	 FROM [restrictedfunction] rf
	 WHERE rf.variablename in (
'anag_config',
'anagrafica',
'anagrafica_read',
'all_upb',
'all_man',
'missioni',
'mr_135',
'mr_136',
'mr_137',
'mr_143',
'mr_176',
'mr_177',
'mr_179',
'mr_211',
'mr_212',
'mr_215',
'mr_272',
'mr_283',
'mr_284',
'mr_285',
'mr_286',
'mr_29',
'mr_296',
'mr_297',
'mr_299',
'mr_300',
'mr_302',
'mr_303',
'mr_304',
'mr_305',
'mr_306',
'mr_307',
'mr_344',
'mr_348',
'mr_397',
'mr_400',
'mr_401',
'mr_41',
'mr_51',
'mr_52',
'mr_53',
'mr_79',
'mr_81',
'mr_82',
'mr_83',
'mr_86',
'mw_135',
'mw_136',
'mw_137',
'mw_211',
'mw_212',
'mw_215',
'mw_284',
'mw_285',
'mw_286',
'mw_297',
'mw_299',
'mw_300',
'mw_302',
'mw_303',
'mw_304',
'mw_305',
'mw_306',
'mw_401',
'mw_51',
'mw_52',
'mw_53',
'mw_79'
,'mr_408'
,'mw_408'

,'mr_417' --interfacce docenti e amministrativi
,'mr_418'
,'mr_419'
,'mw_417'
,'mw_418'
,'mw_419'

)
and not exists(select *  FROM amministrazione.[flowchartrestrictedfunction] fcrf  WHERE fcrf.idflowchart = '202098' and  fcrf.idrestrictedfunction = rf.idrestrictedfunction)





--? INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('duratakind', 'default', 'duratakinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progetto', 'seg', 'progettosegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('naturagiur', 'default', 'naturagiurdefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accmotive', 'seg', 'accmotivesegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('address', 'seg', 'addresssegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('affidamento', 'default', 'affidamentodefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('affidamento', 'seg', 'affidamentosegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('affidamentokind', 'default', 'affidamentokinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ambitoareadisc', 'default', 'ambitoareadiscdefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aoo', 'default', 'aoodefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aoo', 'princ', 'aooprincview', 'princ', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('appello', 'default', 'appellodefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('appello', 'erogata', 'appelloerogataview', 'erogata', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('appelloazionekind', 'default', 'appelloazionekinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('appellokind', 'default', 'appellokinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('areadidattica', 'default', 'areadidatticadefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('asset', 'seg', 'assetsegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ateco', 'default', 'atecodefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'appello', 'attivformappelloview', 'appello', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'default', 'attivformdefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'erogata', 'attivformerogataview', 'erogata', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'gruppo', 'attivformgruppoview', 'gruppo', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('attivform', 'proped', 'attivformpropedview', 'proped', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aula', 'default', 'auladefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aula', 'seg_child', 'aulaseg_childview', 'seg_child', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('aulakind', 'default', 'aulakinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('canale', 'erogata', 'canaleerogataview', 'erogata', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ccnl', 'default', 'ccnldefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('changeskind', 'default', 'changeskinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('classconsorsuale', 'default', 'classconsorsualedefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('classescuola', 'default', 'classescuoladefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('classescuolakind', 'default', 'classescuolakinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('contrattokind', 'default', 'contrattokinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('convenzione', 'seg', 'convenzionesegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudio', 'default', 'corsostudiodefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudio', 'dotmas', 'corsostudiodotmasview', 'dotmas', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudio', 'ingresso', 'corsostudioingressoview', 'ingresso', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudio', 'stato', 'corsostudiostatoview', 'stato', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudiokind', 'default', 'corsostudiokinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudiolivello', 'default', 'corsostudiolivellodefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('corsostudionorma', 'default', 'corsostudionormadefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('costoscontodef', 'more', 'costoscontodefmoreview', 'more', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('costoscontodef', 'sconti', 'costoscontodefscontiview', 'sconti', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('costoscontodefkind', 'default', 'costoscontodefkinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('decadenza', 'seg', 'decadenzasegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'seg', 'dichiarsegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiarkind', 'default', 'dichiarkinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('diderog', 'default', 'diderogdefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprog', 'default', 'didprogdefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprog', 'dotmas', 'didprogdotmasview', 'dotmas', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprog', 'ingresso', 'didprogingressoview', 'ingresso', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprog', 'stato', 'didprogstatoview', 'stato', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didproganno', 'default', 'didprogannodefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprogori', 'default', 'didprogoridefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprogori', 'sceltacorso', 'didprogorisceltacorsoview', 'sceltacorso', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('didprogporzanno', 'default', 'didprogporzannodefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('edificio', 'default', 'edificiodefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('edificio', 'seg_child', 'edificioseg_childview', 'seg_child', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('erogazkind', 'default', 'erogazkinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('esonero', 'default', 'esonerodefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('esonero', 'carriera', 'esonerocarrieraview', 'carriera', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('esonero', 'disabil', 'esonerodisabilview', 'disabil', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('esonero', 'titolostudio', 'esonerotitolostudioview', 'titolostudio', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('expense', 'seg', 'expensesegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('fasciaiseedef', 'default', 'fasciaiseedefdefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('fasciaiseedef', 'more', 'fasciaiseedefmoreview', 'more', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('fasciaiseedef', 'sconti', 'fasciaiseedefscontiview', 'sconti', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('fonteindicebibliometrico', 'seg', 'fonteindicebibliometricosegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_city', 'default', 'geo_citydefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_city', 'seg', 'geo_citysegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_city', 'segchild', 'geo_citysegchildview', 'segchild', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_country', 'seg', 'geo_countrysegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_country', 'segchild', 'geo_countrysegchildview', 'segchild', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_nation', 'lingue', 'geo_nationlingueview', 'lingue', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_nation', 'seg', 'geo_nationsegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_nation', 'segchild', 'geo_nationsegchildview', 'segchild', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('geo_region', 'seg', 'geo_regionsegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('graduatoriavar', 'default', 'graduatoriavardefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('inquadramento', 'default', 'inquadramentodefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('insegn', 'default', 'insegndefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('insegninteg', 'default', 'insegnintegdefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'default', 'iscrizionedefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'didprog', 'iscrizionedidprogview', 'didprog', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'dotmas', 'iscrizionedotmasview', 'dotmas', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'ingresso', 'iscrizioneingressoview', 'ingresso', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seg', 'iscrizionesegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstu', 'iscrizioneseganagstuview', 'seganagstu', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstuacc', 'iscrizioneseganagstuaccview', 'seganagstuacc', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstumast', 'iscrizioneseganagstumastview', 'seganagstumast', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstusing', 'iscrizioneseganagstusingview', 'seganagstusing', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'seganagstustato', 'iscrizioneseganagstustatoview', 'seganagstustato', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizione', 'stato', 'iscrizionestatoview', 'stato', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'seganagstusonpre', 'istanzaseganagstusonpreview', 'seganagstusonpre', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_seg', 'istanzaimm_segview', 'imm_seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_seganagstu', 'istanzaimm_seganagstuview', 'imm_seganagstu', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_seganagstupre', 'istanzaimm_seganagstupreview', 'imm_seganagstupre', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_seganagsturin', 'istanzaimm_seganagsturinview', 'imm_seganagsturin', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_segpre', 'istanzaimm_segpreview', 'imm_segpre', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'imm_segrin', 'istanzaimm_segrinview', 'imm_segrin', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'pas_seganagstu', 'istanzapas_seganagstuview', 'pas_seganagstu', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanzakind', 'default', 'istanzakinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('itineration', 'seg', 'itinerationsegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('nace', 'default', 'nacedefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('nullaosta', 'imm_seganagstu', 'nullaostaimm_seganagstuview', 'imm_seganagstu', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('nullaosta', 'imm_seganagstupre', 'nullaostaimm_seganagstupreview', 'imm_seganagstupre', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('nullaosta', 'imm_seganagsturin', 'nullaostaimm_seganagsturinview', 'imm_seganagsturin', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ofakind', 'default', 'ofakinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('orakind', 'seg', 'orakindsegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pagamentokind', 'default', 'pagamentokinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pettycash', 'seg', 'pettycashsegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pianostudio', 'segstud', 'pianostudiosegstudview', 'segstud', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pianostudiostatus', 'default', 'pianostudiostatusdefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('pratica', 'segstud', 'praticasegstudview', 'segstud', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettoactivitykind', 'default', 'progettoactivitykinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettokind', 'seg', 'progettokindsegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettotipocosto', 'seg', 'progettotipocostosegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('protocollo', 'seg', 'protocollosegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('protocollodockind', 'seg', 'protocollodockindsegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('protocollorifkind', 'seg', 'protocollorifkindsegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'aula', 'provaaulaview', 'aula', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'default', 'provadefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'dotmas', 'provadotmasview', 'dotmas', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'ingresso', 'provaingressoview', 'ingresso', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('prova', 'stato', 'provastatoview', 'stato', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('publicazkind', 'default', 'publicazkinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('questionario', 'default', 'questionariodefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('questionariodomkind', 'default', 'questionariodomkinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('questionariokind', 'default', 'questionariokinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ratadef', 'default', 'ratadefdefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ratadef', 'more', 'ratadefmoreview', 'more', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ratadef', 'sconti', 'ratadefscontiview', 'sconti', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('ratakind', 'default', 'ratakinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'default', 'registrydefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'amministrativi', 'registryamministrativiview', 'amministrativi', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'aziende', 'registryaziendeview', 'aziende', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'docenti', 'registrydocentiview', 'docenti', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'istituti', 'registryistitutiview', 'istituti', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'istituti_princ', 'registryistituti_princview', 'istituti_princ', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'istitutiesteri', 'registryistitutiesteriview', 'istitutiesteri', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'studenti', 'registrystudentiview', 'studenti', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'user', 'registryuserview', 'user', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryaddress', 'seg', 'registryaddresssegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryaddress', 'user', 'registryaddressuserview', 'user', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryclass', 'aziende', 'registryclassaziendeview', 'aziende', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryclass', 'default', 'registryclassdefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryclass', 'persone', 'registryclasspersoneview', 'persone', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryprogfin', 'seg', 'registryprogfinsegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registryprogfinbando', 'seg', 'registryprogfinbandosegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontaltrokind', 'default', 'rendicontaltrokinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontattivitaprogetto', 'anag', 'rendicontattivitaprogettoanagview', 'anag', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontattivitaprogetto', 'anagamm', 'rendicontattivitaprogettoanagammview', 'anagamm', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontattivitaprogetto', 'seg', 'rendicontattivitaprogettosegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sasd', 'default', 'sasddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sasdgruppo', 'default', 'sasdgruppodefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sede', 'default', 'sededefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sede', 'seg_child', 'sedeseg_childview', 'seg_child', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sede', 'seg_child_azienda', 'sedeseg_child_aziendaview', 'seg_child_azienda', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sessione', 'default', 'sessionedefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sessionekind', 'default', 'sessionekinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('settoreerc', 'seg', 'settoreercsegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('settoreerc', 'segprog', 'settoreercsegprogview', 'segprog', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'default', 'sostenimentodefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'didprog', 'sostenimentodidprogview', 'didprog', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'ingresso', 'sostenimentoingressoview', 'ingresso', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstu', 'sostenimentoseganagstuview', 'seganagstu', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstuacc', 'sostenimentoseganagstuaccview', 'seganagstuacc', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstuconsmast', 'sostenimentoseganagstuconsmastview', 'seganagstuconsmast', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstusing', 'sostenimentoseganagstusingview', 'seganagstusing', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'seganagstustato', 'sostenimentoseganagstustatoview', 'seganagstustato', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'segstud', 'sostenimentosegstudview', 'segstud', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimentoesito', 'default', 'sostenimentoesitodefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('stipendiokind', 'default', 'stipendiokinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('struttura', 'default', 'strutturadefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('struttura', 'princ', 'strutturaprincview', 'princ', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('struttura', 'seg_child', 'strutturaseg_childview', 'seg_child', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('strutturakind', 'default', 'strutturakinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('studdirittokind', 'default', 'studdirittokinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('studprenotkind', 'default', 'studprenotkinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassaconf', 'default', 'tassaconfdefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassaconfkind', 'default', 'tassaconfkinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassacsingconf', 'default', 'tassacsingconfdefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassaiscrizioneconf', 'default', 'tassaiscrizioneconfdefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tassaistanzaconf', 'default', 'tassaistanzaconfdefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tax', 'seg', 'taxsegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tipoattform', 'default', 'tipoattformdefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tirociniocandidaturakind', 'default', 'tirociniocandidaturakinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tirocinioprogetto', 'seg', 'tirocinioprogettosegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tirocinioproposto', 'seg', 'tirociniopropostosegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tirociniostato', 'default', 'tirociniostatodefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('titolostudio', 'docenti', 'titolostudiodocentiview', 'docenti', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('upb', 'default', 'upbdefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('upb', 'seg', 'upbsegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('inventorytree', 'seg', 'inventorytreesegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accordoscambiomi', 'seg', 'accordoscambiomisegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('bandomi', 'seg', 'bandomisegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('cefr', 'default', 'cefrdefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('cefrlanglevel', 'default', 'cefrlangleveldefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('assicurazione', 'default', 'assicurazionedefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('bandomobilitaintkind', 'default', 'bandomobilitaintkinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizionebmi', 'seg', 'iscrizionebmisegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('iscrizionebmiattach', 'seg', 'iscrizionebmiattachsegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('bandods', 'seg', 'bandodssegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('learningagrstud', 'seg', 'learningagrstudsegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('tipologiastudente', 'seg', 'tipologiastudentesegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('learningagrtrainer', 'seg', 'learningagrtrainersegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accreditokind', 'default', 'accreditokinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'isee_seganagstu', 'dichiarisee_seganagstuview', 'isee_seganagstu', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'disabil_seganagstu', 'dichiardisabil_seganagstuview', 'disabil_seganagstu', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiardisabilkind', 'default', 'dichiardisabilkinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiardisabilsuppkind', 'default', 'dichiardisabilsuppkinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'disabil_seg', 'dichiardisabil_segview', 'disabil_seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'isee_seg', 'dichiarisee_segview', 'isee_seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'altrititoli_seg', 'dichiaraltrititoli_segview', 'altrititoli_seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'altre_seg', 'dichiaraltre_segview', 'altre_seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sostenimento', 'segcons', 'sostenimentosegconsview', 'segcons', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiaraltrekind', 'default', 'dichiaraltrekinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('dichiar', 'titolo_seg', 'dichiartitolo_segview', 'titolo_seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'rin_seg', 'istanzarin_segview', 'rin_seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'tru_seg', 'istanzatru_segview', 'tru_seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('titolostudio', 'segtitolo', 'titolostudiosegtitoloview', 'segtitolo', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'eq_seg', 'istanzaeq_segview', 'eq_seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'cert_seg', 'istanzacert_segview', 'cert_seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanza', 'sosp_seg', 'istanzasosp_segview', 'sosp_seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('istanzaattach', 'seg', 'istanzaattachsegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('delibera', 'seg', 'deliberasegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getdocentiperssd', 'seg', 'getdocentiperssdsegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getcostididattica', 'default', 'getcostididatticadefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getregistrydocentiamministrativi', 'default', 'getregistrydocentiamministratividefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getcostididattica', 'erogata', 'getcostididatticaerogataview', 'erogata', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('workpackage', 'seg', 'workpackagesegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('accmotive', 'default', 'accmotivedefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('assetacquire', 'seg', 'assetacquiresegview', 'seg', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('publicaz', 'default', 'publicazdefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('publicaz', 'docenti', 'publicazdocentiview', 'docenti', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettoudrmembrokind', 'default', 'progettoudrmembrokinddefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('progettoasset', 'default', 'progettoassetdefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('affidamento', 'doc', 'affidamentodocview', 'doc', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('rendicontattivitaprogetto', 'doc', 'rendicontattivitaprogettodocview', 'doc', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'docenti_doc', 'registrydocenti_docview', 'docenti_doc', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('assetdiary', 'doc', 'assetdiarydocview', 'doc', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('sal', 'default', 'saldefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getprogettocostoview', 'default', 'getprogettocostoviewdefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('getprogettocostoliquidatoview', 'default', 'getprogettocostoliquidatoviewdefaultview', 'default', NULL, NULL, NULL, NULL)
-- INSERT INTO [dbo].[web_listredir] ([tablename],[listtype],[newtablename],[newlisttype],[ct],[cu],[lt],[lu])VALUES('registry', 'amministrativi_personale', 'registryamministrativi_personaleview', 'amministrativi_personale', NULL, NULL, NULL, NULL)
-- --insert

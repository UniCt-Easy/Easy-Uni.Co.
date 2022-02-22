
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


--setuser 'Amministrazione'

select * from [flowchart] where [codeflowchart] in (
'SEGADM','SEGDOC','SEGAMM','SEGPRG','PERFADM'
,'CASHFLOW'
,'VMDLW'
,'COAN') 
order by ayear desc, idflowchart

--Amministratore segreterie
IF NOT EXISTS(select * from [flowchart] where [idflowchart] = '222099')
INSERT INTO [flowchart]
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
           ('222099'
           ,null
           ,2022
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
           ,'22'
           ,null
           ,1
           ,'Segreterie Amministratori'
           ,null
           ,null
           ,null)
GO

IF NOT EXISTS(select * from [flowchart] where [idflowchart] = '222096')
INSERT INTO [flowchart]
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
           ('222096'
           ,null
           ,2022
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
           ,'22'
           ,null
           ,1
           ,'Docenti'
           ,null
           ,null
           ,null)
GO

IF NOT EXISTS(select * from [flowchart] where [idflowchart] = '222095')
INSERT INTO [flowchart]
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
           ('222095'
           ,null
           ,2022
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
           ,'22'
           ,null
           ,1
           ,'Personale amministrativo'
           ,null
           ,null
           ,null)
GO

--Amministratori progetti
IF NOT EXISTS(select * from [flowchart] where [idflowchart] = '222098')
INSERT INTO [flowchart]
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
           ('222098'
           ,null
           ,2022
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
           ,'22'
           ,null
           ,1
           ,'Amministratori progetti di ricerca'
           ,null
           ,null
           ,null)
GO

--performance
IF NOT EXISTS(select * from [flowchart] where [idflowchart] = '222094')
INSERT INTO [flowchart]
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
           ('222094'
           ,null
           ,2022
           ,null
           ,'PERFADM'
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,null
           ,null
           ,null
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,1
           ,'22'
           ,null
           ,1
           ,'Amministratori performance ateneo'
           ,null
           ,null
           ,null)
GO

--Direzione generale
IF NOT EXISTS(select * from [flowchart] where [idflowchart] = '222091')
INSERT INTO [flowchart]
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
           ('222091'
           ,null
           ,2022
           ,null
           ,'DIRGEN'
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,null
           ,null
           ,null
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,1
           ,'22'
           ,null
           ,1
           ,'Direzione generale'
           ,null
           ,null
           ,null)
GO


--ricavare il parametro IN per le insert successive
select variablename,description , ',''' + variablename + ''' -- ' + description as isIn
FROM [flowchartrestrictedfunction] fcrf 
inner join [restrictedfunction] rf on rf.idrestrictedfunction = fcrf.idrestrictedfunction
WHERE fcrf.idflowchart = 'XXXXXXXX'
order by description

--diritti Docenti

INSERT INTO [flowchartrestrictedfunction]
           ([idflowchart]
           ,[idrestrictedfunction]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
           '222096'
           ,rf.idrestrictedfunction
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,CURRENT_TIMESTAMP
           ,'setup'
	 FROM [restrictedfunction] rf
	 WHERE rf.variablename in (
 'all_upb' -- Accesso a tutti gli UPB
,'all_man' -- Accesso a tutti i Responsabili
,'all_mandatekind' -- Accesso a tutti i Tipi di Contratto Passivo
,'anag_config' -- Configurazione Anagrafiche
,'anagrafica' -- Gestione Anagrafica
,'mr_418' -- Menu Portale: Affidamento - Lettura
,'mw_418' -- Menu Portale: Affidamento - Scrittura
,'mr_419' -- Menu Portale: Attività di ricerca - Lettura
,'mw_419' -- Menu Portale: Attività di ricerca - Scrittura
,'mr_420' -- Menu Portale: Dati personali - Lettura
,'mw_420' -- Menu Portale: Dati personali - Scrittura
,'mr_438' -- Menu Portale: Dettaglio dei costi - Lettura
,'mw_438' -- Menu Portale: Dettaglio dei costi - Scrittura
,'mr_417' -- Menu Portale: Diari di utilizzo di beni strumentali - Lettura
,'mw_417' -- Menu Portale: Diari di utilizzo di beni strumentali - Scrittura
,'mr_416' -- Menu Portale: I miei corsi
,'mr_415' -- Menu Portale: I miei dati
,'mr_421' -- Menu Portale: Le mie attività di ricerca e istituzionali
,'mr_296' -- Menu Portale: Progetti di ricerca e attività istituzionali
,'mr_297' -- Menu Portale: Progetti e attività - Lettura
,'mw_297' -- Menu Portale: Progetti e attività - Scrittura
,'mr_440' -- Menu Portale: Stato avanzamento lavori - Lettura
,'mw_440' -- Menu Portale: Stato avanzamento lavori - Scrittura
,'missioni' -- Missioni
,'anagrafica_read' -- Visione Anagrafica
,'cespiti_read' -- Visione Patrimonio
)
and not exists(select *  FROM [flowchartrestrictedfunction] fcrf  WHERE fcrf.idflowchart = '222096' and  fcrf.idrestrictedfunction = rf.idrestrictedfunction)

--diritti Personale amministrativo

INSERT INTO [flowchartrestrictedfunction]
           ([idflowchart]
           ,[idrestrictedfunction]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
           '222095'
           ,rf.idrestrictedfunction
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,CURRENT_TIMESTAMP
           ,'setup'
	 FROM [restrictedfunction] rf
	 WHERE rf.variablename in (
 'all_upb' -- Accesso a tutti gli UPB
,'all_man' -- Accesso a tutti i Responsabili
,'all_mandatekind' -- Accesso a tutti i Tipi di Contratto Passivo
,'anag_config' -- Configurazione Anagrafiche
,'anagrafica' -- Gestione Anagrafica
,'mr_419' -- Menu Portale: Attività di ricerca - Lettura
,'mw_419' -- Menu Portale: Attività di ricerca - Scrittura
,'mr_422' -- Menu Portale: Dati personali - Lettura
,'mw_422' -- Menu Portale: Dati personali - Scrittura
,'mr_417' -- Menu Portale: Diari di utilizzo di beni strumentali - Lettura
,'mw_417' -- Menu Portale: Diari di utilizzo di beni strumentali - Scrittura
,'mr_415' -- Menu Portale: I miei dati
,'mr_421' -- Menu Portale: Le mie attività di ricerca e istituzionali
,'missioni' -- Missioni
,'anagrafica_read' -- Visione Anagrafica
,'cespiti_read' -- Visione Patrimonio

,'mr_467' -- Menu Portale: Performance di ateneo
,'mr_482' -- Menu Portale: Progetti Strategici
,'mr_533' -- Menu Portale: Le mie attività sui progetti strategici - Lettura
,'mw_533' -- Menu Portale: Le mie attività sui progetti strategici - Scrittura

,'mr_491' -- Menu Portale: Schede di valutazione
,'mr_495' -- Menu Portale: Scheda di valutazione di Ateneo - Lettura
,'mw_495' -- Menu Portale: Scheda di valutazione di Ateneo - Scrittura
,'mr_493' -- Menu Portale: Schede di valutazione del personale - Lettura
,'mw_493' -- Menu Portale: Schede di valutazione del personale - Scrittura
,'mr_494' -- Menu Portale: Schede di valutazione delle Unità organizzative - Lettura
,'mw_494' -- Menu Portale: Schede di valutazione delle Unità organizzative - Scrittura
,'mr_515' -- Menu Portale: Richiesta di inserimento di un obiettivo individuale - Lettura
,'mw_515' -- Menu Portale: Richiesta di inserimento di un obiettivo individuale - Scrittura
,'mr_514' -- Menu Portale: Richiesta di inserimento di un obiettivo una tantum - Lettura
,'mw_514' -- Menu Portale: Richiesta di inserimento di un obiettivo una tantum - Scrittura

)
and not exists(select *  FROM [flowchartrestrictedfunction] fcrf  WHERE fcrf.idflowchart = '222095' and  fcrf.idrestrictedfunction = rf.idrestrictedfunction)


--diritti Amministratori segreterie

INSERT INTO [flowchartrestrictedfunction]
           ([idflowchart]
           ,[idrestrictedfunction]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
           '222099'
           ,rf.idrestrictedfunction
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,CURRENT_TIMESTAMP
           ,'setup'
	 FROM [restrictedfunction] rf
	 WHERE rf.variablename in (
'adm_ondemand' -- Abilitazione ai live update on demand
,'adm_backup' -- Abilitazione al backup
,'adm_menuupdate' -- Abilitazione all'aggiornamento del menu
,'endofyear_entry' -- Abilitazione alle scritture di Inizio e Fine Anno
,'all_fin' -- Accesso a tutte le Voci di Bilancio
,'all_upb' -- Accesso a tutti gli UPB
,'all_authmodel' -- Accesso a tutti i Modelli Autorizzativi
,'all_man' -- Accesso a tutti i Responsabili
,'all_estimatekind' -- Accesso a tutti i Tipi di Contratto Attivo
,'all_mandatekind' -- Accesso a tutti i Tipi di Contratto Passivo
,'all_invoicekind' -- Accesso a tutti i Tipi di Documento IVA
,'all_pettycash' -- Accesso a tutti i Tipi di Fondo Economale
,'accetta_fe' -- Accetta F.E.
,'anagrafeprestazioni' -- Anagrafe delle Prestazioni
,'banca' -- Anagrafica Banca
,'anag_c' -- Anagrafiche Centralizzate
,'anag_l' -- Anagrafiche Dipartimentali
,'annullamento' -- Annullamento di Mandati e Reversali
,'tax_clawback' -- Applicazione recuperi e ritenute/contributi
,'storniapprove' -- Approvazione storni (var. non ufficiale su UNA sola voce di bilancio)
,'storno_budget_approve' -- Approvazione storni di budget 
,'stornimedesimocapitoloapprove' -- Approvazione storni(va.non ufficiali sul medesimo primo livello operativo)
,'finvarcredit' -- Approvazione Variazione Crediti
,'var_budget_approve' -- Approvazione variazioni budget (no storni)
,'finvarapproved' -- Approvazione variazioni di bilancio
,'crediti' -- Assegnazione Crediti
,'incassi' -- Assegnazione Incassi
,'asspendenti' -- Attribuisce cassiere a partite pendenti
,'assestamento' -- Bilancio di Assestamento
,'previsione' -- Bilancio di Previsione
,'management' -- Business Rule e Transazione
,'cambia_rifamm' -- Cambia il riferimento amministrazione in fattura di acquisto
,'del_invoice' -- Cancellazione Fatture
,'certificazionecrediti' -- Certificazione dei Crediti
,'chiusura' -- Chiusura Esercizio
,'classificazione' -- Classificazioni
,'cococo' -- Compensi a co.co.co
,'dipendenti' -- Compensi a Dipendenti
,'occasionali' -- Compensi a Occasionali
,'professionali' -- Compensi a Pofessionali
,'stipendi' -- Compensi da Ufficio Stipendi
,'configurazione' -- Configurazione
,'anag_config' -- Configurazione Anagrafiche
,'conf_classauto' -- Configurazione classificazione automatiche
,'config_magazzino' -- Configurazione magazzino
,'config_account' -- Configurazione Piano dei Conti
,'config_stipendi' -- Configurazione Procedura Stipendi
,'config_bil_sottosezionali' -- Configurazione Utilizzo delle voci di bilancio nei sottosezionali
,'anag_d' -- Consenti duplicazione di CF o P. IVA per Anagrafiche
,'coana' -- Contabilità Analitica  e movimenti di budget
,'contcompensi' -- Contabilizzazione dei compensi
,'contiva' -- Contabilizzazione delle fatture IVA
,'contcontratti' -- Contabilizzazione delli contratti attivi / passivi
,'contrattivo' -- Contratto Attivo
,'contrattivogrande' -- Contratto Attivo superiore a 5.000 euro
,'ordine' -- Contratto Passivo
,'ordinegrande' -- Contratto Passivo superiore a 5.000 euro
,'UPBsecurity' -- Controllo Operatività su UPB
,'creaincontabilita_fe' -- Crea F.E. in Contabilità
,'crea_card' -- Creazione Card Magazzino
,'anag_dis' -- Disabilita Anagrafiche
,'mandato' -- Emissione dei Mandati
,'dichiarazione' -- Emissione delle Dichiarazioni (E-Mens, CUD, 770 ...)
,'reversale' -- Emissione delle Reversali
,'esitazione' -- Esitazione di Mandati e Reversali
,'fe_all' -- F.E. ( tutte )
,'fe_ipa' -- F.E. con IPA
,'fe_ipa_rifamm' -- F.E. con IPA e Riferimento amministrazione
,'stipendi_ct' -- Flusso Movimenti UNICT
,'fondoec' -- Fondo Economale
,'anagrafica' -- Gestione Anagrafica
,'admin_card' -- Gestione Card Magazzino
,'classificazione_mod' -- Gestione Classificazione
,'accertamenti' -- Gestione degli Accertamenti
,'impegni' -- Gestione degli Impegni
,'compensi' -- Gestione dei Compensi
,'finanziamenti' -- Gestione dei Finanziamenti
,'manage_invoicekind' -- Gestione dei Tipi di documento IVA
,'bilancio' -- Gestione del Bilancio
,'adm_localconfig' -- Gestione della config.locale del client
,'post_accertamenti' -- Gestione delle fasi Post-Accertamento
,'post_impegni' -- Gestione delle fasi Post-Impegno
,'pre_accertamenti' -- Gestione delle fasi Pre-Accertamento
,'pre_impegni' -- Gestione delle fasi Pre-Impegno
,'upb' -- Gestione delle U.P.B.
,'fattura' -- Gestione Fatture
,'flussomovimenti' -- Gestione Flusso Movimenti (Import Flow)
,'flussostudenti' -- Gestione Flusso Studenti
,'imposta' -- Gestione Imposte
,'iva' -- Gestione IVA
,'adm_magazzino' -- Gestione magazzino
,'menu' -- Gestione Menu
,'entrata' -- Gestione Movimentazione Finanziaria di Entrata
,'spesa' -- Gestione Movimentazione Finanziaria di Spesa
,'cespiti' -- Gestione Patrimoniale
,'responsabile' -- Gestione Responsabili
,'saldicassa' -- Gestione saldi di cassa
,'manage_split_payment' -- Gestione Split Payment
,'stampe' -- Gestione Stampe
,'manage_estimatekind' -- Gestione Tipi di contratto attivo
,'manage_mandatekind' -- Gestione Tipi di contratto passivo
,'liquidazione' -- Liquidazione Imposte
,'liquidazioneiva' -- Liquidazione IVA
,'list_authmodel' -- Lista dei Modelli Autorizzativi
,'list_man' -- Lista dei Responsabili
,'list_estimatekind' -- Lista dei Tipi di Contratto Attivo
,'list_mandatekind' -- Lista dei Tipi di Contratto Passivo
,'list_invoicekind' -- Lista dei Tipi di Documento IVA
,'list_pettycash' -- Lista dei Tipi di Fondo Economale
,'list_mupb' -- Lista delle U.P.B.
,'list_mfin' -- Lista delle voci di Bilancio
,'man_ufficiale' -- Mandati Stampati Ufficialmente
,'mr_351' -- Menu Portale: Accordi bilaterali - Lettura
,'mw_351' -- Menu Portale: Accordi bilaterali - Scrittura
,'mr_170' -- Menu Portale: Aeree didattiche - Lettura
,'mw_170' -- Menu Portale: Aeree didattiche - Scrittura
,'mr_378' -- Menu Portale: Altre dichiarazioni - Lettura
,'mw_378' -- Menu Portale: Altre dichiarazioni - Scrittura
,'mr_371' -- Menu Portale: Altri titoli - Lettura
,'mw_371' -- Menu Portale: Altri titoli - Scrittura
,'mr_295' -- Menu Portale: Ambiti o aree disciplinari - Lettura
,'mw_295' -- Menu Portale: Ambiti o aree disciplinari - Scrittura
,'mr_400' -- Menu Portale: Amministrazione
,'mr_86' -- Menu Portale: Anagrafiche
,'mr_82' -- Menu Portale: Anagrafiche
,'mr_226' -- Menu Portale: Appelli - Lettura
,'mw_226' -- Menu Portale: Appelli - Scrittura
,'mr_293' -- Menu Portale: Area della scuola / classe di laurea - Lettura
,'mw_293' -- Menu Portale: Area della scuola / classe di laurea - Scrittura
,'mr_187' -- Menu Portale: Aree organizzative omogenee - Lettura
,'mw_187' -- Menu Portale: Aree organizzative omogenee - Scrittura
,'mr_356' -- Menu Portale: Assicurazione - Lettura
,'mw_356' -- Menu Portale: Assicurazione - Scrittura
,'mr_380' -- Menu Portale: Attestazione ISEE - Lettura
,'mw_380' -- Menu Portale: Attestazione ISEE - Scrittura
,'mr_419' -- Menu Portale: Attività di ricerca - Lettura
,'mw_419' -- Menu Portale: Attività di ricerca - Scrittura
,'mr_218' -- Menu Portale: Aule - Lettura
,'mw_218' -- Menu Portale: Aule - Scrittura
,'mr_359' -- Menu Portale: Bandi di diritto allo studio - Lettura
,'mr_360' -- Menu Portale: Bandi di diritto allo studio - Lettura
,'mw_360' -- Menu Portale: Bandi di diritto allo studio - Scrittura
,'mw_359' -- Menu Portale: Bandi di diritto allo studio - Scrittura
,'mr_352' -- Menu Portale: Bandi di mobilità - Lettura
,'mw_352' -- Menu Portale: Bandi di mobilità - Scrittura
,'mr_428' -- Menu Portale: Bolle - Lettura
,'mw_428' -- Menu Portale: Bolle - Scrittura
,'mr_496' -- Menu Portale: Cambi di stato dei progetti - Lettura
,'mw_496' -- Menu Portale: Cambi di stato dei progetti - Scrittura
,'mr_479' -- Menu Portale: Cambi di stato delle schede - Lettura
,'mw_479' -- Menu Portale: Cambi di stato delle schede - Scrittura
,'mr_310' -- Menu Portale: Cambiamento per learning agreement - Lettura
,'mw_310' -- Menu Portale: Cambiamento per learning agreement - Scrittura
,'mr_141' -- Menu Portale: Categoria dello studente per il diritto allo studio - Lettura
,'mw_141' -- Menu Portale: Categoria dello studente per il diritto allo studio - Scrittura
,'mr_72' -- Menu Portale: Classi di concorso MIUR - Lettura
,'mw_72' -- Menu Portale: Classi di concorso MIUR - Scrittura
,'mr_279' -- Menu Portale: Classificazione ATECO - Lettura
,'mw_279' -- Menu Portale: Classificazione ATECO - Scrittura
,'mr_278' -- Menu Portale: Classificazione delle attività economiche nella Comunità Europea - Lettura
,'mw_278' -- Menu Portale: Classificazione delle attività economiche nella Comunità Europea - Scrittura
,'mr_348' -- Menu Portale: Classificazione inventariale - Lettura
,'mw_348' -- Menu Portale: Classificazione inventariale - Scrittura
,'mr_472' -- Menu Portale: Comportamenti - Lettura
,'mw_472' -- Menu Portale: Comportamenti - Scrittura
,'mr_196' -- Menu Portale: Comuni - Lettura
,'mw_196' -- Menu Portale: Comuni - Scrittura
,'mr_143' -- Menu Portale: Configurazioni
,'mr_381' -- Menu Portale: Conseguimento del titolo - Lettura
,'mw_381' -- Menu Portale: Conseguimento del titolo - Scrittura
,'mr_369' -- Menu Portale: Contabilità studenti
,'mr_193' -- Menu Portale: Continenti - Lettura
,'mr_239' -- Menu Portale: Continenti - Lettura
,'mw_239' -- Menu Portale: Continenti - Scrittura
,'mw_193' -- Menu Portale: Continenti - Scrittura
,'mr_145' -- Menu Portale: Contratti Collettivi Nazionali del Lavoro - Lettura
,'mw_145' -- Menu Portale: Contratti Collettivi Nazionali del Lavoro - Scrittura
,'mr_342' -- Menu Portale: Convenzioni - Lettura
,'mw_342' -- Menu Portale: Convenzioni - Scrittura
,'mr_188' -- Menu Portale: Corsi di studio - Lettura
,'mw_188' -- Menu Portale: Corsi di studio - Scrittura
,'mr_246' -- Menu Portale: Costi - Lettura
,'mw_246' -- Menu Portale: Costi - Scrittura
,'mr_473' -- Menu Portale: Curriculum - Lettura
,'mw_473' -- Menu Portale: Curriculum - Scrittura
,'mr_308' -- Menu Portale: Decadenza - Lettura
,'mw_308' -- Menu Portale: Decadenza - Scrittura
,'mr_506' -- Menu Portale: Definizione degli allegati  - Lettura
,'mw_506' -- Menu Portale: Definizione degli allegati  - Scrittura
,'mr_251' -- Menu Portale: Definizione degli esoneri  derivanti dalla carriera - Lettura
,'mw_251' -- Menu Portale: Definizione degli esoneri  derivanti dalla carriera - Scrittura
,'mr_252' -- Menu Portale: Definizione degli esoneri di invalidità - Lettura
,'mw_252' -- Menu Portale: Definizione degli esoneri di invalidità - Scrittura
,'mr_250' -- Menu Portale: Definizione degli esoneri generici - Lettura
,'mw_250' -- Menu Portale: Definizione degli esoneri generici - Scrittura
,'mr_253' -- Menu Portale: Definizione degli esoneri per titoli di studio conseguiti - Lettura
,'mw_253' -- Menu Portale: Definizione degli esoneri per titoli di studio conseguiti - Scrittura
,'mr_259' -- Menu Portale: Definizione dei costi dei corsi singoli - Lettura
,'mw_259' -- Menu Portale: Definizione dei costi dei corsi singoli - Scrittura
,'mr_261' -- Menu Portale: Definizione dei costi delle istanze - Lettura
,'mw_261' -- Menu Portale: Definizione dei costi delle istanze - Scrittura
,'mr_257' -- Menu Portale: Definizione dei costi generici - Lettura
,'mw_257' -- Menu Portale: Definizione dei costi generici - Scrittura
,'mr_507' -- Menu Portale: Definizione dei requisiti - Lettura
,'mw_507' -- Menu Portale: Definizione dei requisiti - Scrittura
,'mr_244' -- Menu Portale: Definizione delle tasse
,'mr_260' -- Menu Portale: Definizione delle tasse di iscrizione - Lettura
,'mw_260' -- Menu Portale: Definizione delle tasse di iscrizione - Scrittura
,'mr_258' -- Menu Portale: Definizione delle tasse generiche - Lettura
,'mw_258' -- Menu Portale: Definizione delle tasse generiche - Scrittura
,'mr_277' -- Menu Portale: Definizioni delle graduatorie - Lettura
,'mw_277' -- Menu Portale: Definizioni delle graduatorie - Scrittura
,'mr_390' -- Menu Portale: Delibere - Lettura
,'mw_390' -- Menu Portale: Delibere - Scrittura
,'mr_438' -- Menu Portale: Dettaglio dei costi - Lettura
,'mw_438' -- Menu Portale: Dettaglio dei costi - Scrittura
,'mr_417' -- Menu Portale: Diari di utilizzo di beni strumentali - Lettura
,'mw_417' -- Menu Portale: Diari di utilizzo di beni strumentali - Scrittura
,'mr_379' -- Menu Portale: Dichiarazione di disabilità - Lettura
,'mw_379' -- Menu Portale: Dichiarazione di disabilità - Scrittura
,'mr_384' -- Menu Portale: Dichiarazione titoli di studio - Lettura
,'mw_384' -- Menu Portale: Dichiarazione titoli di studio - Scrittura
,'mr_367' -- Menu Portale: Dichiarazioni
,'mr_179' -- Menu Portale: Didattica
,'mr_219' -- Menu Portale: Didattica Erogata - Lettura
,'mw_219' -- Menu Portale: Didattica Erogata - Scrittura
,'mr_181' -- Menu Portale: Didattiche programmate - Lettura
,'mw_181' -- Menu Portale: Didattiche programmate - Scrittura
,'mr_466' -- Menu Portale: Diritti utenti - Lettura
,'mw_466' -- Menu Portale: Diritti utenti - Scrittura
,'mr_358' -- Menu Portale: Diritto allo studio
,'mr_79' -- Menu Portale: Docenti - Lettura
,'mw_79' -- Menu Portale: Docenti - Scrittura
,'mr_434' -- Menu Portale: Driver UPB - Lettura
,'mw_434' -- Menu Portale: Driver UPB - Scrittura
,'mr_220' -- Menu Portale: Edifici - Lettura
,'mw_220' -- Menu Portale: Edifici - Scrittura
,'mr_41' -- Menu Portale: Elenchi
,'mr_51' -- Menu Portale: Enti e Aziende - Lettura
,'mw_51' -- Menu Portale: Enti e Aziende - Scrittura
,'mr_273' -- Menu Portale: Esami di stato - Lettura
,'mw_273' -- Menu Portale: Esami di stato - Scrittura
,'mr_271' -- Menu Portale: Esito - Lettura
,'mw_271' -- Menu Portale: Esito - Scrittura
,'mr_392' -- Menu Portale: Esito della partecipazione al bando per il diritto allo studio - Lettura
,'mw_392' -- Menu Portale: Esito della partecipazione al bando per il diritto allo studio - Scrittura
,'mr_254' -- Menu Portale: Fasce ISEE - Lettura
,'mr_499' -- Menu Portale: Fasce ISEE - Lettura
,'mr_498' -- Menu Portale: Fasce ISEE - Lettura
,'mr_500' -- Menu Portale: Fasce ISEE - Lettura
,'mw_500' -- Menu Portale: Fasce ISEE - Scrittura
,'mw_498' -- Menu Portale: Fasce ISEE - Scrittura
,'mw_499' -- Menu Portale: Fasce ISEE - Scrittura
,'mw_254' -- Menu Portale: Fasce ISEE - Scrittura
,'mr_304' -- Menu Portale: Fonti degli indici bibliometrici - Lettura
,'mw_304' -- Menu Portale: Fonti degli indici bibliometrici - Scrittura
,'mr_405' -- Menu Portale: Funzioni di amministrazione - Lettura
,'mr_502' -- Menu Portale: Gruppi opzionali - Lettura
,'mw_502' -- Menu Portale: Gruppi opzionali - Scrittura
,'mr_292' -- Menu Portale: Gruppo - Lettura
,'mw_292' -- Menu Portale: Gruppo - Scrittura
,'mr_248' -- Menu Portale: Indennità / More - Lettura
,'mw_248' -- Menu Portale: Indennità / More - Scrittura
,'mr_471' -- Menu Portale: Indicatori - Lettura
,'mw_471' -- Menu Portale: Indicatori - Scrittura
,'mr_182' -- Menu Portale: Insegnamenti - Lettura
,'mw_182' -- Menu Portale: Insegnamenti - Scrittura
,'mr_353' -- Menu Portale: International Standard Classification of Education (ISCED) - Lettura
,'mw_353' -- Menu Portale: International Standard Classification of Education (ISCED) - Scrittura
,'mr_274' -- Menu Portale: Iscrizioni - Lettura
,'mw_274' -- Menu Portale: Iscrizioni - Scrittura
,'mr_84' -- Menu Portale: Iscrizioni, rinnovi, conseguimenti e decadenze
,'mr_455' -- Menu Portale: Istanza di abbreviazione - Lettura
,'mw_455' -- Menu Portale: Istanza di abbreviazione - Scrittura
,'mr_387' -- Menu Portale: Istanza di equipollenza  - Lettura
,'mw_387' -- Menu Portale: Istanza di equipollenza  - Scrittura
,'mr_454' -- Menu Portale: Istanza di passaggio corso o cambio ordinamento - Lettura
,'mw_454' -- Menu Portale: Istanza di passaggio corso o cambio ordinamento - Scrittura
,'mr_444' -- Menu Portale: Istanza di reintegro - Lettura
,'mw_444' -- Menu Portale: Istanza di reintegro - Scrittura
,'mr_385' -- Menu Portale: Istanza di rinuncia agli studi - Lettura
,'mw_385' -- Menu Portale: Istanza di rinuncia agli studi - Scrittura
,'mr_389' -- Menu Portale: Istanza di sospensione degli studi - Lettura
,'mw_389' -- Menu Portale: Istanza di sospensione degli studi - Scrittura
,'mr_456' -- Menu Portale: Istanza di trasferimento in ingresso - Lettura
,'mw_456' -- Menu Portale: Istanza di trasferimento in ingresso - Scrittura
,'mr_386' -- Menu Portale: Istanza di trasferimento in uscita - Lettura
,'mw_386' -- Menu Portale: Istanza di trasferimento in uscita - Scrittura
,'mr_446' -- Menu Portale: Istanze di conseguimento - Lettura
,'mw_446' -- Menu Portale: Istanze di conseguimento - Scrittura
,'mr_288' -- Menu Portale: Istanze di immatricolazione - Lettura
,'mw_288' -- Menu Portale: Istanze di immatricolazione - Scrittura
,'mr_287' -- Menu Portale: Istanze di preimmatricolazione - Lettura
,'mw_287' -- Menu Portale: Istanze di preimmatricolazione - Scrittura
,'mr_445' -- Menu Portale: Istanze di rimborso - Lettura
,'mw_445' -- Menu Portale: Istanze di rimborso - Scrittura
,'mr_289' -- Menu Portale: Istanze di rinnovo della iscrizione - Lettura
,'mw_289' -- Menu Portale: Istanze di rinnovo della iscrizione - Scrittura
,'mr_280' -- Menu Portale: Istanze e delibere
,'mr_52' -- Menu Portale: Istituti - Lettura
,'mw_52' -- Menu Portale: Istituti - Scrittura
,'mr_53' -- Menu Portale: Istituti esteri - Lettura
,'mw_53' -- Menu Portale: Istituti esteri - Scrittura
,'mr_243' -- Menu Portale: Istituto in gestione - Lettura
,'mw_243' -- Menu Portale: Istituto in gestione - Scrittura
,'mr_213' -- Menu Portale: Livelli dei corsi di studio - Lettura
,'mw_213' -- Menu Portale: Livelli dei corsi di studio - Scrittura
,'mr_272' -- Menu Portale: Master - Lettura
,'mw_272' -- Menu Portale: Master - Scrittura
,'mr_449' -- Menu Portale: Menù - Lettura
,'mr_146' -- Menu Portale: Menù - Lettura
,'mw_146' -- Menu Portale: Menù - Scrittura
,'mr_29' -- Menu Portale: Menù dell'applicazione delle segreterie
,'mr_406' -- Menu Portale: Menù dell'applicazione visualMDLW
,'mr_432' -- Menu Portale: Menù formato albero - Lettura
,'mw_432' -- Menu Portale: Menù formato albero - Scrittura
,'mr_404' -- Menu Portale: Menù formato lista - Lettura
,'mw_404' -- Menu Portale: Menù formato lista - Scrittura
,'mr_489' -- Menu Portale: Missioni istituzionali - Lettura
,'mw_489' -- Menu Portale: Missioni istituzionali - Scrittura
,'mr_349' -- Menu Portale: Mobilità internazionale
,'mr_346' -- Menu Portale: Natura giuridica - Lettura
,'mw_346' -- Menu Portale: Natura giuridica - Scrittura
,'mr_191' -- Menu Portale: Nazioni - Lettura
,'mw_191' -- Menu Portale: Nazioni - Scrittura
,'mr_197' -- Menu Portale: Normativa dei corsi di studio - Lettura
,'mw_197' -- Menu Portale: Normativa dei corsi di studio - Scrittura
,'mr_347' -- Menu Portale: Numero dipendenti - Lettura
,'mw_347' -- Menu Portale: Numero dipendenti - Scrittura
,'mr_233' -- Menu Portale: Pagina di registrazione - Lettura
,'mw_233' -- Menu Portale: Pagina di registrazione - Scrittura
,'mr_468' -- Menu Portale: Parametrizzazione
,'mr_467' -- Menu Portale: Performance di ateneo
,'mr_300' -- Menu Portale: Personale Amministrativo - Lettura
,'mw_300' -- Menu Portale: Personale Amministrativo - Scrittura
,'mr_276' -- Menu Portale: Piani di studio - Lettura
,'mw_276' -- Menu Portale: Piani di studio - Scrittura
,'mr_312' -- Menu Portale: Pratica di convalida/riconoscimento/dispensa - Lettura
,'mw_312' -- Menu Portale: Pratica di convalida/riconoscimento/dispensa - Scrittura
,'mr_429' -- Menu Portale: Prodotti - Lettura
,'mw_429' -- Menu Portale: Prodotti - Scrittura
,'mr_296' -- Menu Portale: Progetti di ricerca e attività istituzionali
,'mr_297' -- Menu Portale: Progetti e attività - Lettura
,'mw_297' -- Menu Portale: Progetti e attività - Scrittura
,'mr_482' -- Menu Portale: Progetti Strategici
,'mr_483' -- Menu Portale: Progetti strategici - Lettura
,'mw_483' -- Menu Portale: Progetti strategici - Scrittura
,'mr_350' -- Menu Portale: Programmi di cooperazione - Lettura
,'mw_350' -- Menu Portale: Programmi di cooperazione - Scrittura
,'mr_343' -- Menu Portale: Proposte di tirocinio - Lettura
,'mw_343' -- Menu Portale: Proposte di tirocinio - Scrittura
,'mr_283' -- Menu Portale: Protocollo
,'mr_232' -- Menu Portale: Prove di ammissione - Lettura
,'mw_232' -- Menu Portale: Prove di ammissione - Scrittura
,'mr_194' -- Menu Portale: Province - Lettura
,'mw_194' -- Menu Portale: Province - Scrittura
,'mr_136' -- Menu Portale: Pubblicazioni - Lettura
,'mw_136' -- Menu Portale: Pubblicazioni - Scrittura
,'mr_354' -- Menu Portale: Quadro europeo comune di riferimento per le lingue - Lettura
,'mw_354' -- Menu Portale: Quadro europeo comune di riferimento per le lingue - Scrittura
,'mr_241' -- Menu Portale: Questionari - Lettura
,'mw_241' -- Menu Portale: Questionari - Scrittura
,'mr_256' -- Menu Portale: Rate - Lettura
,'mw_256' -- Menu Portale: Rate - Scrittura
,'mr_195' -- Menu Portale: Regioni - Lettura
,'mw_195' -- Menu Portale: Regioni - Scrittura
,'mr_284' -- Menu Portale: Registrazioni di protocollo - Lettura
,'mw_284' -- Menu Portale: Registrazioni di protocollo - Scrittura
,'mr_441' -- Menu Portale: Richiesta di accesso - Lettura
,'mw_441' -- Menu Portale: Richiesta di accesso - Scrittura
,'mr_388' -- Menu Portale: Richiesta di certificato - Lettura
,'mw_388' -- Menu Portale: Richiesta di certificato - Scrittura
,'mr_391' -- Menu Portale: Riepilogo dei costi degli affidamenti - Lettura
,'mw_391' -- Menu Portale: Riepilogo dei costi degli affidamenti - Scrittura
,'mr_475' -- Menu Portale: Ruoli - Lettura
,'mw_475' -- Menu Portale: Ruoli - Scrittura
,'mr_495' -- Menu Portale: Scheda di valutazione di Ateneo - Lettura
,'mw_495' -- Menu Portale: Scheda di valutazione di Ateneo - Scrittura
,'mr_491' -- Menu Portale: Schede di valutazione
,'mr_493' -- Menu Portale: Schede di valutazione del personale - Lettura
,'mw_493' -- Menu Portale: Schede di valutazione del personale - Scrittura
,'mr_494' -- Menu Portale: Schede di valutazione delle Unità organizzative - Lettura
,'mw_494' -- Menu Portale: Schede di valutazione delle Unità organizzative - Scrittura
,'mr_247' -- Menu Portale: Sconti - Lettura
,'mw_247' -- Menu Portale: Sconti - Scrittura
,'mr_180' -- Menu Portale: Scuole / Classi di laurea - Lettura
,'mw_180' -- Menu Portale: Scuole / Classi di laurea - Scrittura
,'mr_212' -- Menu Portale: Sedi - Lettura
,'mw_212' -- Menu Portale: Sedi - Scrittura
,'mr_83' -- Menu Portale: Segreteria amministrativa
,'mr_81' -- Menu Portale: Segreteria didattica
,'mr_228' -- Menu Portale: Sessioni di esami - Lettura
,'mw_228' -- Menu Portale: Sessioni di esami - Scrittura
,'mr_57' -- Menu Portale: Settori artistico-scientifico disciplinari - Lettura
,'mw_57' -- Menu Portale: Settori artistico-scientifico disciplinari - Scrittura
,'mr_303' -- Menu Portale: Settori dell'European Research Council - Lettura
,'mw_303' -- Menu Portale: Settori dell'European Research Council - Scrittura
,'mr_469' -- Menu Portale: Soglie - Lettura
,'mw_469' -- Menu Portale: Soglie - Scrittura
,'mr_270' -- Menu Portale: Stati dei piani di studio - Lettura
,'mw_270' -- Menu Portale: Stati dei piani di studio - Scrittura
,'mr_480' -- Menu Portale: Stati dei progetti - Lettura
,'mw_480' -- Menu Portale: Stati dei progetti - Scrittura
,'mr_302' -- Menu Portale: Stati delle attività o progetti - Lettura
,'mw_302' -- Menu Portale: Stati delle attività o progetti - Scrittura
,'mr_478' -- Menu Portale: Stati delle schede - Lettura
,'mw_478' -- Menu Portale: Stati delle schede - Scrittura
,'mr_440' -- Menu Portale: Stato avanzamento lavori - Lettura
,'mw_440' -- Menu Portale: Stato avanzamento lavori - Scrittura
,'mr_268' -- Menu Portale: Stato dei tirocini - Lettura
,'mw_268' -- Menu Portale: Stato dei tirocini - Scrittura
,'mr_504' -- Menu Portale: Strumenti di finanziamento - Lettura
,'mw_504' -- Menu Portale: Strumenti di finanziamento - Scrittura
,'mr_215' -- Menu Portale: Struttura / Unità organizzativa - Lettura
,'mw_215' -- Menu Portale: Struttura / Unità organizzativa - Scrittura
,'mr_474' -- Menu Portale: Strutture - Lettura
,'mw_474' -- Menu Portale: Strutture - Scrittura
,'mr_174' -- Menu Portale: Studenti - Lettura
,'mw_174' -- Menu Portale: Studenti - Scrittura
,'mr_365' -- Menu Portale: Tipi di accredito in una richiesta di partecipazione al bando per il diritto allo stud
,'mw_365' -- Menu Portale: Tipi di accredito in una richiesta di partecipazione al bando per il diritto allo stud
,'mr_290' -- Menu Portale: Tipi di dichiarazione - Lettura
,'mw_290' -- Menu Portale: Tipi di dichiarazione - Scrittura
,'mr_503' -- Menu Portale: Tipi di indicatore - Lettura
,'mw_503' -- Menu Portale: Tipi di indicatore - Scrittura
,'mr_505' -- Menu Portale: Tipi di partnership - Lettura
,'mw_505' -- Menu Portale: Tipi di partnership - Scrittura
,'mr_307' -- Menu Portale: Tipi di ritenuta - Lettura
,'mw_307' -- Menu Portale: Tipi di ritenuta - Scrittura
,'mr_470' -- Menu Portale: Tipi di soglie - Lettura
,'mw_470' -- Menu Portale: Tipi di soglie - Scrittura
,'mr_305' -- Menu Portale: Tipo di attività o progetto - Lettura
,'mw_305' -- Menu Portale: Tipo di attività o progetto - Scrittura
,'mr_311' -- Menu Portale: Tipo di cambiamenti - Lettura
,'mw_311' -- Menu Portale: Tipo di cambiamenti - Scrittura
,'mr_286' -- Menu Portale: Tipo di documento di riferimento - Lettura
,'mw_286' -- Menu Portale: Tipo di documento di riferimento - Scrittura
,'mr_285' -- Menu Portale: Tipo di documento protocollato - Lettura
,'mw_285' -- Menu Portale: Tipo di documento protocollato - Scrittura
,'mr_345' -- Menu Portale: Tipo di durata - Lettura
,'mw_345' -- Menu Portale: Tipo di durata - Scrittura
,'mr_508' -- Menu Portale: Tipo di interazione - Lettura
,'mw_508' -- Menu Portale: Tipo di interazione - Scrittura
,'mr_299' -- Menu Portale: Tipo di progetto o attività - Lettura
,'mw_299' -- Menu Portale: Tipo di progetto o attività - Scrittura
,'mr_357' -- Menu Portale: Tipologa del bando di mobilità internanzionale - Lettura
,'mw_357' -- Menu Portale: Tipologa del bando di mobilità internanzionale - Scrittura
,'mr_294' -- Menu Portale: Tipologia della scuola / classe di laurea - Lettura
,'mw_294' -- Menu Portale: Tipologia della scuola / classe di laurea - Scrittura
,'mr_382' -- Menu Portale: Tipologia delle altre dichiarazioni - Lettura
,'mr_383' -- Menu Portale: Tipologia delle altre dichiarazioni - Lettura
,'mw_383' -- Menu Portale: Tipologia delle altre dichiarazioni - Scrittura
,'mw_382' -- Menu Portale: Tipologia delle altre dichiarazioni - Scrittura
,'mr_139' -- Menu Portale: Tipologia delle attività da rendicontare oltre le lezioni  - Lettura
,'mw_139' -- Menu Portale: Tipologia delle attività da rendicontare oltre le lezioni  - Scrittura
,'mr_217' -- Menu Portale: Tipologia delle attività formative - Lettura
,'mw_217' -- Menu Portale: Tipologia delle attività formative - Scrittura
,'mr_424' -- Menu Portale: Tipologia delle aule - Lettura
,'mw_424' -- Menu Portale: Tipologia delle aule - Scrittura
,'mr_211' -- Menu Portale: Tipologia delle strutture - Lettura
,'mw_211' -- Menu Portale: Tipologia delle strutture - Scrittura
,'mr_267' -- Menu Portale: Tipologia di candidatura ad un tirocinio - Lettura
,'mw_267' -- Menu Portale: Tipologia di candidatura ad un tirocinio - Scrittura
,'mr_172' -- Menu Portale: Tipologia di istituto - Lettura
,'mw_172' -- Menu Portale: Tipologia di istituto - Scrittura
,'mr_401' -- Menu Portale: Tipologia di membro delle unità di personale - Lettura
,'mw_401' -- Menu Portale: Tipologia di membro delle unità di personale - Scrittura
,'mr_298' -- Menu Portale: Tipologia di ore - Lettura
,'mw_298' -- Menu Portale: Tipologia di ore - Scrittura
,'mr_452' -- Menu Portale: Tipologia di Relatori - Lettura
,'mw_452' -- Menu Portale: Tipologia di Relatori - Scrittura
,'mr_142' -- Menu Portale: Tipologia di studente durante la prenotazione - Lettura
,'mw_142' -- Menu Portale: Tipologia di studente durante la prenotazione - Scrittura
,'mr_453' -- Menu Portale: Tipologia di Tesi - Lettura
,'mw_453' -- Menu Portale: Tipologia di Tesi - Scrittura
,'mr_183' -- Menu Portale: Tipologia di valutazione di una attività didattica - Lettura
,'mr_221' -- Menu Portale: Tipologia di valutazione di una attività didattica - Lettura
,'mw_221' -- Menu Portale: Tipologia di valutazione di una attività didattica - Scrittura
,'mw_183' -- Menu Portale: Tipologia di valutazione di una attività didattica - Scrittura
,'mr_176' -- Menu Portale: Tipologia fiscale - Lettura
,'mw_176' -- Menu Portale: Tipologia fiscale - Scrittura
,'mr_262' -- Menu Portale: Tipologia tra Costo, Sconto, Mora, indennizzo - Lettura
,'mw_262' -- Menu Portale: Tipologia tra Costo, Sconto, Mora, indennizzo - Scrittura
,'mr_177' -- Menu Portale: Tipologie
,'mr_171' -- Menu Portale: Tipologie dei corsi di studio - Lettura
,'mw_171' -- Menu Portale: Tipologie dei corsi di studio - Scrittura
,'mr_223' -- Menu Portale: Tipologie delle aule - Lettura
,'mw_223' -- Menu Portale: Tipologie delle aule - Scrittura
,'mr_265' -- Menu Portale: Tipologie di  domande del questionario - Lettura
,'mw_265' -- Menu Portale: Tipologie di  domande del questionario - Scrittura
,'mr_225' -- Menu Portale: Tipologie di affidamento - Lettura
,'mw_225' -- Menu Portale: Tipologie di affidamento - Scrittura
,'mr_230' -- Menu Portale: Tipologie di appello - Lettura
,'mw_230' -- Menu Portale: Tipologie di appello - Scrittura
,'mr_135' -- Menu Portale: Tipologie di contratto - Lettura
,'mw_135' -- Menu Portale: Tipologie di contratto - Scrittura
,'mr_366' -- Menu Portale: Tipologie di convalida - Lettura
,'mw_366' -- Menu Portale: Tipologie di convalida - Scrittura
,'mr_376' -- Menu Portale: Tipologie di disabilità - Lettura
,'mw_376' -- Menu Portale: Tipologie di disabilità - Scrittura
,'mr_227' -- Menu Portale: Tipologie di erogazione della didattica - Lettura
,'mw_227' -- Menu Portale: Tipologie di erogazione della didattica - Scrittura
,'mr_263' -- Menu Portale: Tipologie di istanza - Lettura
,'mw_263' -- Menu Portale: Tipologie di istanza - Scrittura
,'mr_255' -- Menu Portale: Tipologie di pagamento - Lettura
,'mw_255' -- Menu Portale: Tipologie di pagamento - Scrittura
,'mr_137' -- Menu Portale: Tipologie di pubblicazione  - Lettura
,'mw_137' -- Menu Portale: Tipologie di pubblicazione  - Scrittura
,'mr_266' -- Menu Portale: Tipologie di questionario - Lettura
,'mw_266' -- Menu Portale: Tipologie di questionario - Scrittura
,'mr_229' -- Menu Portale: Tipologie di sessione - Lettura
,'mw_229' -- Menu Portale: Tipologie di sessione - Scrittura
,'mr_377' -- Menu Portale: Tipologie dichiarazioni disabilita - Lettura
,'mw_377' -- Menu Portale: Tipologie dichiarazioni disabilita - Scrittura
,'mr_313' -- Menu Portale: Tirocini
,'mr_178' -- Menu Portale: Titoli di studio ISTAT - Lettura
,'mw_178' -- Menu Portale: Titoli di studio ISTAT - Scrittura
,'mr_269' -- Menu Portale: Titologie di azione in appello - Lettura
,'mw_269' -- Menu Portale: Titologie di azione in appello - Scrittura
,'mr_264' -- Menu Portale: Titologie di obblighi formativi aggiuntivi - Lettura
,'mw_264' -- Menu Portale: Titologie di obblighi formativi aggiuntivi - Scrittura
,'mr_1' -- Menu Portale: Tutti i Menù
,'mr_186' -- Menu Portale: Unità previsionali di base - Lettura
,'mw_186' -- Menu Portale: Unità previsionali di base - Scrittura
,'mr_490' -- Menu Portale: Validatori - Lettura
,'mw_490' -- Menu Portale: Validatori - Scrittura
,'mr_397' -- Menu Portale: Valute - Lettura
,'mw_397' -- Menu Portale: Valute - Scrittura
,'mr_242' -- Menu Portale: Variabili delle graduatorie - Lettura
,'mw_242' -- Menu Portale: Variabili delle graduatorie - Scrittura
,'mr_249' -- Menu Portale: Voci dei dettaglio debito - Lettura
,'mw_249' -- Menu Portale: Voci dei dettaglio debito - Scrittura
,'missioni' -- Missioni
,'flag_escludidacu' -- Modifica 'Escludi da CU dei Redditi'
,'flag_authorizationfree' -- Modifica 'Esente ai fini dell'Autorizzazione dell'Agente di Riscossione'
,'edit_epaccresidui' -- Modifica Accertamenti di Budget(Residui)
,'mod_bollettino' -- Modifica Bollettino
,'upd_paymentcompetency' -- Modifica competenza ai fini della Liquidazione IVA
,'edit_limit' -- Modifica del Limite di Previsione Bilancio
,'edit_epexpresidui' -- Modifica Impegni di Budget(Residui)
,'notcreacontabilita' -- Modifica"Fatture da non creare in contabilità" 
,'mov_protettecomp' -- Movimentazione Voci protette c/Competenza.
,'movimprotetta' -- Operazioni su Voci Bilancio Protette
,'organigramma' -- Organigramma
,'pat' -- P.A.T.
,'econopatr' -- Partita Doppia
,'consolidamento' -- Procedure di Consolidamento
,'anag_procedure' -- Procedure su Anagrafiche
,'rev_ufficiale' -- Reversali Stampate Ufficialmente
,'ric_magazzino' -- Richieste di magazzino
,'rifiuta_fe' -- Rifiuta F.E.
,'multiprint' -- Ristampa di documenti Ufficiali
,'eco_entry' -- Scritture in Partita Doppia
,'storno_budget' -- Storni di budget 
,'ct_stornocompetenzaclass' -- Storno Impegno di Competenza, classificato Provenienza.
,'tipologiaincarichi_ap' -- Tipologia incarichi-Banca dati Incarichi
,'trasmissione' -- Tramissione di Mandati e Reversali
,'trasmissione_ap' -- Trasmissione incarichi Anagrafe delle Prestazioni
,'varentrata' -- Variazione dei movimenti di entrata
,'varspesa' -- Variazione dei movimenti di spesa
,'var_bilancio' -- Variazioni bilancio
,'var_budget' -- Variazioni budget (no storni)
,'trasmissione_abilita' -- Verifica e abilita la Trasmissione di Mandati e Reversali
,'anagrafica_read' -- Visione Anagrafica
,'bilancio_read' -- Visione del Bilancio
,'entrata_read' -- Visione Movimentazione Finanziaria di Entrata
,'spesa_read' -- Visione Movimentazione Finanziaria di Spesa
,'fondoec_read' -- Visione Operazioni Fondo Economale
,'cespiti_read' -- Visione Patrimonio
,'sitfinanziaria_read' -- Visione Situazione Finanziaria / Amministrativa
,'trasmissione_read' -- Visione Tramissione di Mandati e Reversali
,'sel_ca' -- Visualizza Contratto Attivo
,'sel_cp' -- Visualizza Contratto Passivo
,'sel_fatture' -- Visualizza Fatture
,'mr_526' -- Menu Portale: Direzione generale - Lettura
,'mr_516' -- Menu Portale: Direzione generale - Lettura
,'mr_517' -- Menu Portale: Analisi Indicatore dell''80% - Lettura
,'mw_517' -- Menu Portale: Analisi Indicatore dell''80% - Scrittura

)
and not exists(select *  FROM [flowchartrestrictedfunction] fcrf  WHERE fcrf.idflowchart = '222099' and  fcrf.idrestrictedfunction = rf.idrestrictedfunction)


--diritti Performance ateneo
INSERT INTO [flowchartrestrictedfunction]
           ([idflowchart]
           ,[idrestrictedfunction]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
           '222094'
           ,rf.idrestrictedfunction
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,CURRENT_TIMESTAMP
           ,'setup'
	 FROM [restrictedfunction] rf
	 WHERE rf.variablename in (
'all_upb' -- Accesso a tutti gli UPB
,'all_man' -- Accesso a tutti i Responsabili
,'all_mandatekind' -- Accesso a tutti i Tipi di Contratto Passivo
,'anag_config' -- Configurazione Anagrafiche
,'anagrafica' -- Gestione Anagrafica
,'cespiti' -- Gestione Patrimoniale
,'mr_400' -- Menu Portale: Amministrazione
,'mr_82' -- Menu Portale: Anagrafiche
,'mr_86' -- Menu Portale: Anagrafiche
,'mr_496' -- Menu Portale: Cambi di stato dei progetti - Lettura
,'mw_496' -- Menu Portale: Cambi di stato dei progetti - Scrittura
,'mr_479' -- Menu Portale: Cambi di stato delle schede - Lettura
,'mw_479' -- Menu Portale: Cambi di stato delle schede - Scrittura
,'mr_472' -- Menu Portale: Comportamenti - Lettura
,'mw_472' -- Menu Portale: Comportamenti - Scrittura
,'mr_143' -- Menu Portale: Configurazioni
,'mr_179' -- Menu Portale: Didattica
,'mr_466' -- Menu Portale: Diritti utenti - Lettura
,'mw_466' -- Menu Portale: Diritti utenti - Scrittura
,'mr_79' -- Menu Portale: Docenti - Lettura
,'mw_79' -- Menu Portale: Docenti - Scrittura
,'mr_405' -- Menu Portale: Funzioni di amministrazione - Lettura
,'mr_471' -- Menu Portale: Indicatori - Lettura
,'mw_471' -- Menu Portale: Indicatori - Scrittura
,'mr_243' -- Menu Portale: Istituto in gestione - Lettura
,'mw_243' -- Menu Portale: Istituto in gestione - Scrittura
,'mr_533' -- Menu Portale: Le mie attività sui progetti strategici - Lettura
,'mw_533' -- Menu Portale: Le mie attività sui progetti strategici - Scrittura
,'mr_510' -- Menu Portale: Mansioni - Lettura
,'mw_510' -- Menu Portale: Mansioni - Scrittura
,'mr_29' -- Menu Portale: Menù dell'applicazione delle segreterie
,'mr_489' -- Menu Portale: Missioni istituzionali - Lettura
,'mw_489' -- Menu Portale: Missioni istituzionali - Scrittura
,'mr_468' -- Menu Portale: Parametrizzazione
,'mr_467' -- Menu Portale: Performance di ateneo
,'mr_300' -- Menu Portale: Personale Amministrativo - Lettura
,'mw_300' -- Menu Portale: Personale Amministrativo - Scrittura
,'mr_482' -- Menu Portale: Progetti Strategici
,'mr_483' -- Menu Portale: Progetti strategici - Lettura
,'mw_483' -- Menu Portale: Progetti strategici - Scrittura
,'mr_515' -- Menu Portale: Richiesta di inserimento di un obiettivo individuale - Lettura
,'mw_515' -- Menu Portale: Richiesta di inserimento di un obiettivo individuale - Scrittura
,'mr_514' -- Menu Portale: Richiesta di inserimento di un obiettivo una tantum - Lettura
,'mw_514' -- Menu Portale: Richiesta di inserimento di un obiettivo una tantum - Scrittura
,'mr_495' -- Menu Portale: Scheda di valutazione di Ateneo - Lettura
,'mw_495' -- Menu Portale: Scheda di valutazione di Ateneo - Scrittura
,'mr_491' -- Menu Portale: Schede di valutazione
,'mr_493' -- Menu Portale: Schede di valutazione del personale - Lettura
,'mw_493' -- Menu Portale: Schede di valutazione del personale - Scrittura
,'mr_494' -- Menu Portale: Schede di valutazione delle Unità organizzative - Lettura
,'mw_494' -- Menu Portale: Schede di valutazione delle Unità organizzative - Scrittura
,'mr_212' -- Menu Portale: Sedi - Lettura
,'mw_212' -- Menu Portale: Sedi - Scrittura
,'mr_83' -- Menu Portale: Segreteria amministrativa
,'mr_81' -- Menu Portale: Segreteria didattica
,'mr_469' -- Menu Portale: Soglie - Lettura
,'mw_469' -- Menu Portale: Soglie - Scrittura
,'mr_480' -- Menu Portale: Stati dei progetti - Lettura
,'mw_480' -- Menu Portale: Stati dei progetti - Scrittura
,'mr_478' -- Menu Portale: Stati delle schede - Lettura
,'mw_478' -- Menu Portale: Stati delle schede - Scrittura
,'mr_474' -- Menu Portale: Strutture - Lettura
,'mw_474' -- Menu Portale: Strutture - Scrittura
,'mr_503' -- Menu Portale: Tipi di indicatore - Lettura
,'mw_503' -- Menu Portale: Tipi di indicatore - Scrittura
,'mr_470' -- Menu Portale: Tipi di soglie - Lettura
,'mw_470' -- Menu Portale: Tipi di soglie - Scrittura
,'mr_508' -- Menu Portale: Tipo di interazione - Lettura
,'mw_508' -- Menu Portale: Tipo di interazione - Scrittura
,'mr_490' -- Menu Portale: Validatori - Lettura
,'mw_490' -- Menu Portale: Validatori - Scrittura
,'missioni' -- Missioni
,'anagrafica_read' -- Visione Anagrafica
,'cespiti_read' -- Visione Patrimonio

)
and not exists(select *  FROM [flowchartrestrictedfunction] fcrf  WHERE fcrf.idflowchart = '222094' and  fcrf.idrestrictedfunction = rf.idrestrictedfunction)

--diritti Amministratori progetti
INSERT INTO [flowchartrestrictedfunction]
           ([idflowchart]
           ,[idrestrictedfunction]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
           '222098'
           ,rf.idrestrictedfunction
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,CURRENT_TIMESTAMP
           ,'setup'
	 FROM [restrictedfunction] rf
	 WHERE rf.variablename in (

 'all_upb' -- Accesso a tutti gli UPB
,'all_man' -- Accesso a tutti i Responsabili
,'all_mandatekind' -- Accesso a tutti i Tipi di Contratto Passivo
,'anag_config' -- Configurazione Anagrafiche
,'anagrafica' -- Gestione Anagrafica
,'cespiti' -- Gestione Patrimoniale
,'mr_400' -- Menu Portale: Amministrazione
,'mr_86' -- Menu Portale: Anagrafiche
,'mr_82' -- Menu Portale: Anagrafiche
,'mr_348' -- Menu Portale: Classificazione inventariale - Lettura
,'mr_143' -- Menu Portale: Configurazioni
,'mr_438' -- Menu Portale: Dettaglio dei costi - Lettura
,'mw_438' -- Menu Portale: Dettaglio dei costi - Scrittura
,'mr_179' -- Menu Portale: Didattica
,'mr_466' -- Menu Portale: Diritti utenti - Lettura
,'mw_466' -- Menu Portale: Diritti utenti - Scrittura
,'mr_79' -- Menu Portale: Docenti - Lettura
,'mw_79' -- Menu Portale: Docenti - Scrittura
,'mr_41' -- Menu Portale: Elenchi
,'mr_51' -- Menu Portale: Enti e Aziende - Lettura
,'mw_51' -- Menu Portale: Enti e Aziende - Scrittura
,'mr_304' -- Menu Portale: Fonti degli indici bibliometrici - Lettura
,'mw_304' -- Menu Portale: Fonti degli indici bibliometrici - Scrittura
,'mr_405' -- Menu Portale: Funzioni di amministrazione - Lettura
,'mr_52' -- Menu Portale: Istituti - Lettura
,'mw_52' -- Menu Portale: Istituti - Scrittura
--,'mr_53' -- Menu Portale: Istituti esteri - Lettura
--,'mw_53' -- Menu Portale: Istituti esteri - Scrittura
,'mr_243' -- Menu Portale: Istituto in gestione - Lettura
,'mw_243' -- Menu Portale: Istituto in gestione - Scrittura
,'mr_272' -- Menu Portale: Master - Lettura
,'mr_29' -- Menu Portale: Menù dell'applicazione delle segreterie
,'mr_300' -- Menu Portale: Personale Amministrativo - Lettura
,'mw_300' -- Menu Portale: Personale Amministrativo - Scrittura
,'mr_296' -- Menu Portale: Progetti di ricerca e attività istituzionali
,'mr_297' -- Menu Portale: Progetti e attività - Lettura
,'mw_297' -- Menu Portale: Progetti e attività - Scrittura
--,'mr_283' -- Menu Portale: Protocollo
,'mr_136' -- Menu Portale: Pubblicazioni - Lettura
,'mw_136' -- Menu Portale: Pubblicazioni - Scrittura
--,'mr_284' -- Menu Portale: Registrazioni di protocollo - Lettura
--,'mw_284' -- Menu Portale: Registrazioni di protocollo - Scrittura
,'mr_212' -- Menu Portale: Sedi - Lettura
,'mw_212' -- Menu Portale: Sedi - Scrittura
,'mr_83' -- Menu Portale: Segreteria amministrativa
,'mr_81' -- Menu Portale: Segreteria didattica
,'mr_303' -- Menu Portale: Settori dell'European Research Council - Lettura
,'mw_303' -- Menu Portale: Settori dell'European Research Council - Scrittura
,'mr_302' -- Menu Portale: Stati delle attività o progetti - Lettura
,'mw_302' -- Menu Portale: Stati delle attività o progetti - Scrittura
,'mr_440' -- Menu Portale: Stato avanzamento lavori - Lettura
,'mw_440' -- Menu Portale: Stato avanzamento lavori - Scrittura
,'mr_504' -- Menu Portale: Strumenti di finanziamento - Lettura
,'mw_504' -- Menu Portale: Strumenti di finanziamento - Scrittura
,'mr_215' -- Menu Portale: Struttura / Unità organizzativa - Lettura
,'mw_215' -- Menu Portale: Struttura / Unità organizzativa - Scrittura
,'mr_505' -- Menu Portale: Tipi di partnership - Lettura
,'mw_505' -- Menu Portale: Tipi di partnership - Scrittura
,'mr_307' -- Menu Portale: Tipi di ritenuta - Lettura
,'mr_305' -- Menu Portale: Tipo di attività o progetto - Lettura
,'mw_305' -- Menu Portale: Tipo di attività o progetto - Scrittura
--,'mr_286' -- Menu Portale: Tipo di documento di riferimento - Lettura
--,'mw_286' -- Menu Portale: Tipo di documento di riferimento - Scrittura
--,'mr_285' -- Menu Portale: Tipo di documento protocollato - Lettura
--,'mw_285' -- Menu Portale: Tipo di documento protocollato - Scrittura
,'mr_299' -- Menu Portale: Tipo di progetto o attività - Lettura
,'mw_299' -- Menu Portale: Tipo di progetto o attività - Scrittura
,'mr_139' -- Menu Portale: Tipologia delle attività da rendicontare oltre le lezioni  - Lettura
,'mw_139' -- Menu Portale: Tipologia delle attività da rendicontare oltre le lezioni  - Scrittura
,'mr_211' -- Menu Portale: Tipologia delle strutture - Lettura
,'mw_211' -- Menu Portale: Tipologia delle strutture - Scrittura
,'mr_401' -- Menu Portale: Tipologia di membro delle unità di personale - Lettura
,'mw_401' -- Menu Portale: Tipologia di membro delle unità di personale - Scrittura
,'mr_176' -- Menu Portale: Tipologia fiscale - Lettura
,'mr_177' -- Menu Portale: Tipologie
,'mr_135' -- Menu Portale: Tipologie di contratto - Lettura
,'mw_135' -- Menu Portale: Tipologie di contratto - Scrittura
,'mr_137' -- Menu Portale: Tipologie di pubblicazione  - Lettura
,'mw_137' -- Menu Portale: Tipologie di pubblicazione  - Scrittura
,'mr_397' -- Menu Portale: Valute - Lettura
,'missioni' -- Missioni
,'anagrafica_read' -- Visione Anagrafica
,'cespiti_read' -- Visione Patrimonio

)
and not exists(select *  FROM [flowchartrestrictedfunction] fcrf  WHERE fcrf.idflowchart = '222098' and  fcrf.idrestrictedfunction = rf.idrestrictedfunction)

--diritti Direzione generale
INSERT INTO [flowchartrestrictedfunction]
           ([idflowchart]
           ,[idrestrictedfunction]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
           '222091'
           ,rf.idrestrictedfunction
           ,CURRENT_TIMESTAMP
           ,'setup'
           ,CURRENT_TIMESTAMP
           ,'setup'
	 FROM [restrictedfunction] rf
	 WHERE rf.variablename in (

 'all_upb' -- Accesso a tutti gli UPB
,'all_man' -- Accesso a tutti i Responsabili
,'all_mandatekind' -- Accesso a tutti i Tipi di Contratto Passivo
,'anag_config' -- Configurazione Anagrafiche
,'anagrafica' -- Gestione Anagrafica
,'mr_400' -- Menu Portale: Amministrazione
,'mr_86' -- Menu Portale: Anagrafiche
,'mr_82' -- Menu Portale: Anagrafiche
,'mr_143' -- Menu Portale: Configurazioni
,'mr_179' -- Menu Portale: Didattica
,'mr_79' -- Menu Portale: Docenti - Lettura
,'mw_79' -- Menu Portale: Docenti - Scrittura
,'mr_41' -- Menu Portale: Elenchi
--,'mr_405' -- Menu Portale: Funzioni di amministrazione - Lettura
,'mr_29' -- Menu Portale: Menù dell'applicazione delle segreterie
,'mr_300' -- Menu Portale: Personale Amministrativo - Lettura
,'mw_300' -- Menu Portale: Personale Amministrativo - Scrittura
,'mr_83' -- Menu Portale: Segreteria amministrativa
,'mr_81' -- Menu Portale: Segreteria didattica
,'mr_215' -- Menu Portale: Struttura / Unità organizzativa - Lettura
,'mw_215' -- Menu Portale: Struttura / Unità organizzativa - Scrittura
,'mr_211' -- Menu Portale: Tipologia delle strutture - Lettura
,'mw_211' -- Menu Portale: Tipologia delle strutture - Scrittura
,'mr_176' -- Menu Portale: Tipologia fiscale - Lettura
,'mr_177' -- Menu Portale: Tipologie
,'mr_135' -- Menu Portale: Tipologie di contratto - Lettura
,'mw_135' -- Menu Portale: Tipologie di contratto - Scrittura
,'anagrafica_read' -- Visione Anagrafica

,'mr_526' -- Menu Portale: Direzione generale - Lettura
,'mr_516' -- Menu Portale: Direzione generale - Lettura
,'mr_517' -- Menu Portale: Analisi Indicatore dell''80% - Lettura
,'mw_517' -- Menu Portale: Analisi Indicatore dell''80% - Scrittura
,'mr_391' -- Menu Portale: Riepilogo dei costi degli affidamenti - Lettura
,'mw_391' -- Menu Portale: Riepilogo dei costi degli affidamenti - Scrittura

)
and not exists(select *  FROM [flowchartrestrictedfunction] fcrf  WHERE fcrf.idflowchart = '222091' and  fcrf.idrestrictedfunction = rf.idrestrictedfunction)

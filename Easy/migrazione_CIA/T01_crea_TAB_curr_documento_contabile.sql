
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


-- Crea la tabella fisica curr_documento_contabile
-- sullo schema della vista curr_documento_contabile creata da Nino
drop table curr_documento_contabile
go


SELECT        CHIAVE_COMPLETA_DOCUMENTO, CHIAVE_PIANO, CHIAVE_PADRE_TIPOLOGIA, ESERCIZIO, CHIAVE_CONTO, DESCRIZIONE, CHIAVE, 
                         CHIAVE_PRIMO_DOCUMENTO, CHIAVE_PRECEDENTE_ASSOCIATO, CHIAVE_SUCCESSIVO_ASSOCIATO, CHIAVE_ALTRO_DOCUMENTO, TIPO, NUMERO_VERSIONE, 
                         CHIAVE_DOCUMENTO_ORIGINALE, CAUSALE, CODICE_ANAG, NOME, COGNOME, RAGIONE_SOCIALE, PARTITA_IVA, CODICE_FISCALE, CODICE_BENE_SERVIZIO, 
                         CODICE_PROVENTI_RICAVI, CODICE_UBICAZIONE, DESCRIZIONE_TRANSAZIONE, NUMERO_BOLLA, NUMERO_DELIBERA_AUTORIZZAZIONE, 
                         NUMERO_PROTOCOLLO, NUMERO_FATTURA_ATTIVA, NUMERO_FATTURA_PASSIVA, TIPO_IVA, NUMERO_QUIETANZA, NUMERO_CONTRATTO, 
                         MODALITA_PAGAMENTO, TERMINI_PAGAMENTO, NUMERO_PREVENTIVO_FORNITORE, ABI_UNIVERSITA, CAB_UNIVERSITA, NUMERO_CONTO_UNIVERSITA, 
                         DESCRIZIONE_BANCA_UNIVERSITA, ABI_CLIENTE_FORNITORE, CAB_CLIENTE_FORNITORE, NUMERO_CONTO_CLIENTE_FORNITORE, 
                         DESCRIZIONE_BANCA_CLI_FOR, BILANCIO, UNITA_ORGANIZZATIVA, COMPETENZA_RESIDUI, CODICE_VALUTA_ESTERA, CODICE_CARICO_INVENTARIO, 
                         NUMERO_CONTO_CONTABILE, SCADENZA_TASSATIVA, STATO, INVIARE_CASSIERE, ATTIVA, AUTORIZZATORIO, RIPORTATO, ENTRATA_SPESA, POSIZIONE, PIU, 
                         ALIQUOTA_IVA, AMMONTARE_IVA, AMMONTARE, AMMONTARE_VALUTA_ESTERA, QUANTITA_BENE_SERVIZIO, RITENUTA_ACCONTO, 
                         IMPORTO_RITENUTA_ACCONTO, IMPONIBILE_IVA, IMPORTO_UNITARIO, PREVENTIVO_ASSESTATO, CONSUNTIVO_PRIMI_DOCUMENTI, IMPORTO_RESIDUO, 
                         DATA_SCADENZA, INIZIO_ANNO_ACCADEMICO, FINE_ANNO_ACCADEMICO, DATA_FATTURA, DATA_INCASSO, DATA_REGOLARIZZAZIONE, 
                         DATA_CONTABILIZZAZIONE, DATA_TRASMISSIONE, DATA_ULTIMA, DATA_VERSIONE, DATA_STORNO, DATA_INVIO_STORNO, DATA_CANCELLAZIONE, 
                         DATA_PAGAMENTO, DACR, DUVA, UTUV, NOME_UNITA_ORGANIZZATIVA, DATA_TRASMISSIONE_STORNO, CHIAVE_CATEGORIA, DATA_ESTINZIONE, 
                         DESCRIZIONE_CAUSALE, NUMERO_PAGAMENTO_PROVVISORIO, CESSIONARIO, INTESTAZIONE_CONTO, TIPO_CONTO, UNITA_ORGANIZZATIVA_BENEF, 
                         NUMERO_VERSIONE_TIPOLOGIA, RESIDUO_UTILIZZATO, PROGETTO, ARROTONDAMENTO, TIPO_ANAGRAFICO, AMMONTARE_RESIDUO_DOCUMENTO, 
                         CHIAVE_PRECEDENTE_PROCEDURA, IMPORTO_BOLLO, DESCRIZIONE_BOLLO, RIPORTATO_CHIUSURA, DATA_STAMPA, REGOLARIZZAZIONE, 
                         RICLASSIFICAZIONE, UTCR, STATO_MODIFICA_RESIDUO, RICLASSIFICAZIONE_MURST, CIN, IBAN, BIC, CODICE_GESTIONALE, TIPO_PROVVEDIMENTO, 
                         DATA_PROVVEDIMENTO, NUMERO_PROVVEDIMENTO, SEZIONE_CASSA, PROGETTO_DESTINAZIONE, CUP, INVIARE_FIRMA, INESTINTO, CDR_DESTINAZIONE, 
                         AMBITO, INVIARE_VARIAZIONE, DATA_TRASMISSIONE_VARIAZIONE, TIPO_IMPUTAZIONE, NOTE, CIG 
                         

INTO curr_documento_contabile
FROM       dbo.DOCUMENTO_CONTABILE AS D

WHERE     (NOT EXISTS
                             (SELECT *
                               FROM            dbo.DOCUMENTO_CONTABILE AS D2
                               WHERE        (ESERCIZIO = D.ESERCIZIO) AND (BILANCIO = D.BILANCIO) AND (CHIAVE_COMPLETA_DOCUMENTO = D.CHIAVE_COMPLETA_DOCUMENTO) AND 
                                                         (NUMERO_VERSIONE = D.NUMERO_VERSIONE+1)))
                                                         
                                                         
GO                                                         
--------------------------------
 --- curr_documento_contabile ---
 --------------------------------
 
/****** Object:  Index [IX_curr_documento_contabile]    Script Date: 18/12/2013 07.51.37 ******/
CREATE NONCLUSTERED INDEX [IX_curr_documento_contabile] ON [dbo].[curr_documento_contabile]
(
	[CHIAVE_COMPLETA_DOCUMENTO] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [NonClusteredIndex-20131217-160654]    Script Date: 18/12/2013 07.52.19 ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20131217-160654] ON [dbo].[curr_documento_contabile]
(
	[TIPO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO



/****** Object:  Index [NonClusteredIndex-20131217-161805]    Script Date: 18/12/2013 07.52.48 ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20131217-161805] ON [dbo].[curr_documento_contabile]
(
	[BILANCIO] ASC,
	[CHIAVE_COMPLETA_DOCUMENTO] ASC,
	[ESERCIZIO] ASC,
	[TIPO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO



/****** Object:  Index [xi1_documento_generico]    Script Date: 18/12/2013 07.53.12 ******/
CREATE NONCLUSTERED INDEX [xi1_documento_generico] ON [dbo].[curr_documento_contabile]
(
	[CHIAVE_COMPLETA_DOCUMENTO] ASC,
	[ESERCIZIO] ASC,
	[NUMERO_VERSIONE] ASC,
	[BILANCIO] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
GO



 
/****** Object:  Index [PK__curr_doc__65AD6BDA5FBE24CE]    Script Date: 15/11/2013 14.01.37 ******/
ALTER TABLE [dbo].[curr_documento_contabile] ADD PRIMARY KEY CLUSTERED 
(
	[ESERCIZIO] ASC,
	[CHIAVE_COMPLETA_DOCUMENTO] ASC,
	[BILANCIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

       
alter table curr_documento_contabile add     residuo_corretto decimal(19,2)
go     
--alter table curr_documento_contabile add     chiave_conto_padre varchar(90)
--go      

--alter table curr_documento_contabile add     unita_organizzativa_padre varchar(90)
--go      


update  curr_documento_contabile 
set RESIDUO_CORRETTO = isnull(ammontare,0) -
	isnull( (select sum(RDD.ammontare) 
				from relazione_dcont_dcont RDD 
					join curr_documento_contabile D2 
							 on RDD.chiave_completa_doc_figlio  = D2.chiave_completa_documento
							and RDD.bilancio= D2.bilancio 
							and RDD.esercizio=D2.esercizio					
					where  RDD.chiave_completa_doc_padre	= curr_documento_contabile.chiave_completa_documento
							and RDD.bilancio				= curr_documento_contabile.bilancio 
							and RDD.esercizio				=curr_documento_contabile.esercizio
							and RDD.stato='A'
   						    and D2.data_storno is null

			 ),0)							
  where curr_documento_contabile.tipo in  ( 'ACCERTAMENTO','IMPEGNO')
  /*  and not exists (select *  from documento_contabile_delta DD 
				    where  DD.chiave_completa_documento  = D.chiave_completa_documento
							and DD.bilancio= D.bilancio and DD.esercizio=D.esercizio
							and DD.numero_versione=D.numero_versione )
  */							
  and curr_documento_contabile.data_storno is null
  and curr_documento_contabile.esercizio <>2001
  and not exists (select *  from curr_documento_contabile D2 
				    where  D2.chiave_completa_documento  = curr_documento_contabile.chiave_completa_documento
							and D2.bilancio= curr_documento_contabile.bilancio
							 and D2.esercizio=curr_documento_contabile.esercizio+1
							)
GO
/*
update curr_documento_contabile set CHIAVE_CONTO=L.CHIAVE_CONTO,
							UNITA_ORGANIZZATIVA= L.UNITA_ORGANIZZATIVA

		from curr_documento_contabile
		join DOCUMENTO_CONTABILE L on L.BILANCIO=curr_documento_contabile.BILANCIO
								and L.CHIAVE_COMPLETA_DOCUMENTO=curr_documento_contabile.CHIAVE_COMPLETA_DOCUMENTO
								and L.ESERCIZIO=curr_documento_contabile.ESERCIZIO							
		where not exists (select * from DOCUMENTO_CONTABILE L2 where
							 L.BILANCIO=L2.BILANCIO
								and L.CHIAVE_COMPLETA_DOCUMENTO=l2.CHIAVE_COMPLETA_DOCUMENTO
								and L.ESERCIZIO=l2.ESERCIZIO
								and L.numero_versione<l2.numero_versione)

*/
				


/*                                         
update 	curr_documento_contabile set 
	chiave_conto_padre =
	(select top 1 chiave_conto from curr_documento_contabile Dparent
			join relazione_dcont_dcont RDD
				on  RDD.esercizio= Dparent.esercizio
					and RDD.bilancio = Dparent.bilancio
					and RDD.chiave_completa_doc_padre = Dparent.chiave_completa_documento
			where RDD.esercizio=curr_documento_contabile.esercizio
				and RDD.bilancio=curr_documento_contabile.bilancio
				and RDD.chiave_completa_doc_figlio=curr_documento_contabile.chiave_completa_documento
	)

 



                                    
update 	curr_documento_contabile set 
	unita_organizzativa_padre =
	(select top 1 unita_organizzativa from curr_documento_contabile Dparent
			join relazione_dcont_dcont RDD
				on  RDD.esercizio= Dparent.esercizio
					and RDD.bilancio = Dparent.bilancio
					and RDD.chiave_completa_doc_padre = Dparent.chiave_completa_documento
			where RDD.esercizio=curr_documento_contabile.esercizio
				and RDD.bilancio=curr_documento_contabile.bilancio
				and RDD.chiave_completa_doc_figlio=curr_documento_contabile.chiave_completa_documento
	)

 
*/

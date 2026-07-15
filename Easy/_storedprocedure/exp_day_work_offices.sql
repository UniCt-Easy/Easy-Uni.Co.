/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

if exists (select * from dbo.sysobjects where id = object_id(N'[exp_day_work_offices]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_day_work_offices]
GO

 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amministrazione'
--[exp_day_work_offices] '2024-01-01', '2024-06-13',null,null,null,null,null
CREATE  PROCEDURE [exp_day_work_offices]


(
	@start DATE,
	@end DATE,
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int
)
AS

BEGIN


 ----DICHIARAZIONE VARIABILE PER CONTROLLO CLASSIFICAZIONE----


 DECLARE @idsorkind INT
SELECT @idsorkind = idsorkind FROM sortingkind WHERE codesorkind = 'Control_DOC'

 ----CREAZIONE TABELLA TEMPORANEA PER CALCOLO DATI----

CREATE TABLE #expDayWorkOffices (
	Codice_IPA_Destinatario VARCHAR(20),
	Anagrafica VARCHAR(200),
	Tipo_Documento_Fattura VARCHAR(200),
	Numero_Esercizio_Fattura INT,
	Numero_Fattura INT,
	Documento varchar(35),
	Data_Documento datetime,
	Imponibile decimal(19,2),
	Iva decimal(19,2),
	Totale_Fattura decimal(19,2),
	Annotazioni varchar(max),
	Data_Ricezione_SDI DATE,
	Numero_Esercizio_Compenso INT,
	Numero_Compenso INT,
	Data_Ricezione_Ufficio_Compensi DATE,
	Data_Ricezione_Ufficio_Contabilità DATE,
	Numero_Esercizio_Mandato_di_Pagamento INT,
	Numero_Mandato_di_Pagamento INT,
	Data_Contabile_Mandato_di_Pagamento DATE,
	Data_Distinta DATE,
	Numero_Distinta INT,
	Data_Inizio_Sospensione DATE,
    Data_Fine_Sospensione DATE
)

INSERT INTO #expDayWorkOffices (
	Codice_IPA_Destinatario,
	Anagrafica, 
	Tipo_Documento_Fattura, 
	Numero_Esercizio_Fattura, 
	Numero_Fattura,
	Documento,
	Data_Documento,
	Imponibile,
	Iva,
	Totale_Fattura,
	Annotazioni,
	Data_Ricezione_SDI,
	Numero_Esercizio_Compenso,
	Numero_Compenso,
	Data_Ricezione_Ufficio_Compensi,
	Data_Ricezione_Ufficio_Contabilità,
	Numero_Esercizio_Mandato_di_Pagamento,
	Numero_Mandato_di_Pagamento,
	Data_Contabile_Mandato_di_Pagamento,
	Data_Distinta,
	Numero_Distinta,
	Data_Inizio_Sospensione,
    Data_Fine_Sospensione
)
SELECT
	i.sdi_codice_ipa AS Codice_IPA_Destinatario,
	i.registry AS Anagrafica,
    i.invoicekind AS Tipo_Documento_Fattura,
    i.yinv AS Numero_Esercizio_Fattura,
    i.ninv AS Numero_Fattura,
	i.doc AS Documento,
	i.docdate as Data_Documento,
	i.taxable as Imponibile,
	i.tax as Iva,
	i.total as Totale_Fattura,
	convert(varchar(max),i.txt) as Annotazioni,
    i.protocoldate AS Data_Ricezione_SDI,
	pr.ycon AS Numero_Esercizio_Compenso,
	pr.ncon AS Numero_Compenso,
    ps.valued1 AS Data_Ricezione_Ufficio_Compensi,
    i1.valued1 AS Data_Ricezione_Ufficio_Contabilità,
    elv.ypay AS Numero_Esercizio_Mandato_di_Pagamento,
    elv.npay AS Numero_Mandato_di_Pagamento,
    elv.paymentadate AS Data_Contabile_Mandato_di_Pagamento,
	elv.transmissiondate AS Data_Distinta,
	elv.kpaymenttransmission AS Numero_Distinta,

	--(SELECT MIN(start_sosp_contenzioso)  
	--   FROM  pccdebitstatusdetail pc
	--  WHERE ev.yinv = pc.yinv
	--		 AND ev.idinvkind = pc.idinvkind
	--		 AND ev.ninv = pc.ninv 
	--		 AND pc.imp_sosp_contenzioso IS NOT NULL
	--) AS Data_Inizio_Sospensione,
	sospensioni_start.Data_Inizio_Sospensione AS Data_Inizio_Sospensione,

	-- 	(SELECT MIN(start_sosp_contenzioso)  
	--   FROM  pccdebitstatusdetail pc
	--  WHERE  ev.yinv = pc.yinv
	--		 AND ev.idinvkind = pc.idinvkind
	--		 AND ev.ninv = pc.ninv 
	--		 AND pc.imp_sosp_contenzioso IS NULL
	--) AS Data_Fine_Sospensione
	--sospensioni_stop.Data_Inizio_Sospensione,

	CASE 
		WHEN sospensioni_start.Data_Inizio_Sospensione IS NULL 
			THEN NULL
		WHEN sospensioni_stop.Data_Inizio_Sospensione > sospensioni_stop.Data_Inizio_Sospensione
			THEN NULL
		ELSE sospensioni_stop.Data_Inizio_Sospensione
	END AS Data_Fine_Sospensione

FROM invoiceview i
	JOIN expenseinvoice ev
		ON ev.idinvkind = i.idinvkind
			AND ev.yinv = i.yinv
			AND ev.ninv = i.ninv
	JOIN invoicekind ik
		ON i.idinvkind = ik.idinvkind
	LEFT OUTER JOIN expenselastview elv
		ON ev.idexp = elv.idexp
	
	LEFT OUTER JOIN profservice pr
		ON i.idinvkind = pr.idinvkind
			AND i.yinv = pr.yinv
			AND i.ninv = pr.ninv
 ----NOMI CLASSIFICAZIONI VARIABILI----
	LEFT OUTER JOIN sorting s1 
		ON  s1.idsorkind = @idsorkind 
			AND s1.sortcode = 'Ufficio contabilità'
	LEFT OUTER JOIN sorting s2
		ON  s2.idsorkind = @idsorkind 
			AND s2.sortcode = 'Ufficio Compensi'
	LEFT OUTER JOIN profservicesorting ps
        ON s2.idsor = ps.idsor 
            AND pr.ncon = ps.ncon
			AND pr.ycon = ps.ycon
    LEFT OUTER JOIN invoicesorting i1 
        ON s1.idsor = i1.idsor
			AND i.ninv = i1.ninv 
            AND i.yinv = i1.yinv 
            AND i.idinvkind = i1.idinvkind

	CROSS APPLY (
		SELECT MIN(start_date) AS Data_Inizio_Sospensione
		FROM (
			SELECT CASE 
					 WHEN pc.imp_sosp_contenzioso IS NOT NULL 
						  AND pc.imp_sosp_contenzioso <> 0
					 THEN pc.start_sosp_contenzioso 
				   END
			FROM pccdebitstatusdetail pc
			WHERE pc.yinv = ev.yinv 
			  AND pc.idinvkind = ev.idinvkind 
			  AND pc.ninv = ev.ninv

			UNION ALL
			SELECT CASE 
					 WHEN pc.imp_sosp_contestazione IS NOT NULL 
						  AND pc.imp_sosp_contestazione <> 0
					 THEN pc.start_sosp_contestazione 
				   END
			FROM pccdebitstatusdetail pc
			WHERE pc.yinv = ev.yinv 
			  AND pc.idinvkind = ev.idinvkind 
			  AND pc.ninv = ev.ninv

			UNION ALL
			SELECT CASE 
					 WHEN pc.imp_sosp_regolareverifica IS NOT NULL 
						  AND pc.imp_sosp_regolareverifica <> 0
					 THEN pc.start_sosp_regolareverifica 
				   END
			FROM pccdebitstatusdetail pc
			WHERE pc.yinv = ev.yinv 
			  AND pc.idinvkind = ev.idinvkind 
			  AND pc.ninv = ev.ninv
		) v(start_date)
	) sospensioni_start

	CROSS APPLY (
		SELECT MIN(start_date) AS Data_Inizio_Sospensione
		FROM (
			SELECT CASE WHEN pc.imp_sosp_contenzioso IS NULL 
						 OR pc.imp_sosp_contenzioso = 0
						THEN pc.start_sosp_contenzioso END
			FROM pccdebitstatusdetail pc
			WHERE pc.yinv = ev.yinv 
			  AND pc.idinvkind = ev.idinvkind 
			  AND pc.ninv = ev.ninv

			UNION ALL
			SELECT CASE WHEN pc.imp_sosp_contestazione IS NULL 
						 OR pc.imp_sosp_contestazione = 0
						THEN pc.start_sosp_contestazione END
			FROM pccdebitstatusdetail pc
			WHERE pc.yinv = ev.yinv 
			  AND pc.idinvkind = ev.idinvkind 
			  AND pc.ninv = ev.ninv

			UNION ALL
			SELECT CASE WHEN pc.imp_sosp_regolareverifica IS NULL 
						 OR pc.imp_sosp_regolareverifica = 0
						THEN pc.start_sosp_regolareverifica END
			FROM pccdebitstatusdetail pc
			WHERE pc.yinv = ev.yinv 
			  AND pc.idinvkind = ev.idinvkind 
			  AND pc.ninv = ev.ninv
		) v(start_date)
	) sospensioni_stop

WHERE i.protocoldate >= @start AND i.protocoldate <= @end 	
AND (@idsor01 IS NULL OR ik.idsor01 = @idsor01)	
AND (@idsor02 IS NULL OR ik.idsor02 = @idsor02)
AND (@idsor03 IS NULL OR ik.idsor03 = @idsor03) 
AND (@idsor04 IS NULL OR ik.idsor04 = @idsor04) 
AND (@idsor05 IS NULL OR ik.idsor05 = @idsor05)


--SELECT * FROM #expDayWorkOffices
SELECT
	ex.Codice_IPA_Destinatario AS 'Codice IPA Destinatario',
	ex.Anagrafica,
	ex.Tipo_Documento_Fattura AS 'Tipo Fattura',
	ex.Numero_Esercizio_Fattura AS 'Anno Fattura',
	ex.Numero_Fattura AS 'Numero Fattura',
	ex.Documento AS 'Numero Documento',
	ex.Data_Documento as 'Data Documento',
	ex.Imponibile,
	ex.Iva,
	ex.Totale_Fattura AS 'Totale Fattura',
	ex.Annotazioni,
	ex.Data_Ricezione_SDI AS 'Data Ricezione SDI',
	---casi d'uso per il calcolo della data dell'ufficio titolare della procedura d'acquisto---
    MAX(CASE
			WHEN ex.Data_Ricezione_Ufficio_Compensi IS NOT NULL THEN
				CASE
					WHEN ex.Data_Fine_Sospensione <= ex.Data_Ricezione_Ufficio_Compensi THEN DATEDIFF(DAY, ex.Data_Ricezione_SDI, ex.Data_Ricezione_Ufficio_Compensi) - DATEDIFF(DAY, ex.Data_Inizio_Sospensione, ex.Data_Fine_Sospensione)
					ELSE DATEDIFF(DAY, ex.Data_Ricezione_SDI, ex.Data_Ricezione_Ufficio_Compensi)
				END
			WHEN ex.Data_Ricezione_Ufficio_Compensi IS NULL THEN 
				CASE 
					WHEN ex.Data_Ricezione_Ufficio_Contabilità IS NOT NULL THEN
						CASE 
							WHEN ex.Data_Fine_Sospensione <= ex.Data_Ricezione_Ufficio_Contabilità THEN DATEDIFF(DAY, ex.Data_Ricezione_SDI, ex.Data_Ricezione_Ufficio_Contabilità) - DATEDIFF(DAY, ex.Data_Inizio_Sospensione, ex.Data_Fine_Sospensione)
							ELSE DATEDIFF(DAY, ex.Data_Ricezione_SDI, ex.Data_Ricezione_Ufficio_Contabilità)
						END 
					WHEN ex.Data_Ricezione_Ufficio_Contabilità IS NULL THEN
						CASE
							WHEN ex.Data_Fine_Sospensione <= ex.Data_Contabile_Mandato_di_Pagamento THEN DATEDIFF(DAY, ex.Data_Ricezione_SDI, ex.Data_Contabile_Mandato_di_Pagamento) - DATEDIFF(DAY, ex.Data_Inizio_Sospensione, ex.Data_Fine_Sospensione)
							ELSE DATEDIFF(DAY, ex.Data_Ricezione_SDI, ex.Data_Contabile_Mandato_di_Pagamento)
						END
				END
		END) AS 'Giorni trascorsi di lavorazione Ufficio Titolare della Procedura di Acquisto',
	ex.Numero_Esercizio_Compenso AS 'Anno Parcella',
	ex.Numero_Compenso AS 'Numero Parcella',
	ex.Data_Ricezione_Ufficio_Compensi AS 'Data Ricez. Ufficio Compensi',
	---casi d'uso per il calcolo della data dell'ufficio compensi---
    MAX(CASE
        	WHEN ex.Data_Fine_Sospensione <= ex.Data_Ricezione_Ufficio_Contabilità AND ex.Data_Fine_Sospensione >= ex.Data_Ricezione_Ufficio_Compensi THEN DATEDIFF(DAY, ex.Data_Ricezione_Ufficio_Compensi, ex.Data_Ricezione_Ufficio_Contabilità) - DATEDIFF(DAY, ex.Data_Inizio_Sospensione, ex.Data_Fine_Sospensione)
    		ELSE DATEDIFF(DAY, ex.Data_Ricezione_Ufficio_Compensi, ex.Data_Ricezione_Ufficio_Contabilità)
    	END) AS 'Giorni trascorsi di lavorazione Ufficio Compensi',
	ex.Data_Ricezione_Ufficio_Contabilità AS 'Data Ricez. Ufficio Contabilità',
	---casi d'uso per il calcolo della data dell'ufficio contabilità---
	MAX(CASE
        	WHEN ex.Data_Fine_Sospensione <= ex.Data_Contabile_Mandato_di_Pagamento AND ex.Data_Fine_Sospensione >= ex.Data_Ricezione_Ufficio_Contabilità THEN DATEDIFF(DAY, ex.Data_Ricezione_Ufficio_Contabilità, ex.Data_Contabile_Mandato_di_Pagamento) - DATEDIFF(DAY, ex.Data_Inizio_Sospensione, ex.Data_Fine_Sospensione)
    		ELSE DATEDIFF(DAY, ex.Data_Ricezione_Ufficio_Contabilità, ex.Data_Contabile_Mandato_di_Pagamento)
    	END) AS 'Giorni trascorsi di lavorazione Ufficio Contabilità',
	ex.Numero_Esercizio_Mandato_di_Pagamento AS 'Anno Mandato',
	ex.Numero_Mandato_di_Pagamento AS 'Numero Mandato',
	ex.Data_Contabile_Mandato_di_Pagamento AS 'Data Contabile Mandato',
	ex.Data_Distinta AS 'Data Trasmissione',
	ex.Numero_Distinta AS 'Numero Distinta',
	---CALCOLO GIORNI DI LAVORAZIONE DA MANDATO A DISTINTA---
	DATEDIFF(DAY, ex.Data_Contabile_Mandato_di_Pagamento, ex.Data_Distinta) AS 'Giorni Trascorsi da Mandato a Trasmissione',
	---CALCOLO GIORNI DI SOSPENSIONE---
	DATEDIFF(DAY, ex.Data_Inizio_Sospensione, ex.Data_Fine_Sospensione) AS 'Giorni di Sospensione',
	ex.Data_Inizio_Sospensione AS 'Data Inizio sospensione',
	ex.Data_Fine_Sospensione AS 'Data Fine sospensione',
	---CALCOLO GIORNI DI LAVORAZIONE TOTALI---
	MAX(CASE
			WHEN ex.Data_Fine_Sospensione IS NOT NULL THEN
				DATEDIFF(DAY, ex.Data_Ricezione_SDI, ex.Data_Distinta) - DATEDIFF(DAY, ex.Data_Inizio_Sospensione, ex.Data_Fine_Sospensione) 
				ELSE DATEDIFF(DAY, ex.Data_Ricezione_SDI, ex.Data_Distinta)
		END) AS 'Giorni di Lavorazione Totali'
FROM #expDayWorkOffices ex
GROUP BY
	ex.Codice_IPA_Destinatario,
	ex.Anagrafica,
	ex.Tipo_Documento_Fattura,
	ex.Numero_Esercizio_Fattura,
	ex.Numero_Fattura,
	ex.Documento,
	ex.Data_Documento,
	ex.Imponibile,
	ex.Iva,
	ex.Totale_Fattura,
	ex.Annotazioni,
	ex.Data_Ricezione_SDI,
	ex.Numero_Esercizio_Compenso,
	ex.Numero_Compenso,
	ex.Data_Ricezione_Ufficio_Compensi,
	ex.Data_Ricezione_Ufficio_Contabilità,
	ex.Numero_Esercizio_Mandato_di_Pagamento,
	ex.Numero_Mandato_di_Pagamento,
	ex.Data_Contabile_Mandato_di_Pagamento,
	ex.Data_Distinta,
	ex.Numero_Distinta,
	ex.Data_Inizio_Sospensione,
	ex.Data_Fine_Sospensione


DROP TABLE #expDayWorkOffices;
END;

GO
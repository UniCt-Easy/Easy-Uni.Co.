
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


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[exp_upb_pluriennale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_upb_pluriennale]
GO

CREATE PROCEDURE [exp_upb_pluriennale]
@idupb varchar(36)='%'
AS BEGIN

	DECLARE @SnphaseMax int = (SELECT MAX(nphase) FROM Expensephase )
	DECLARE @EnphaseMax int = (SELECT MAX(nphase) FROM Incomephase )
	SELECT 
		E.phase	AS	'Fase',
		E.ymov	AS	'Eserc.Mov.',
		E.nmov	AS	'Num.Mov.',
		E.codefin	AS	'Voce Bil.',
		E.finance	AS	'Denom. Bil.',
		E.codeupb	AS	'Cod. U.P.B.',
		E.upb	AS	'U.P.B.',
		E.registry	AS	'Percipiente',
		E.p_iva	AS	'Partita iva',
		E.cf AS 'Codice Fiscale',
		E.manager	AS	'Responsabile',
		E.doc	AS	'Num. Documento',
		E.docdate	AS	'Data Documento',
		'Mandato '+Convert(Varchar(10),E.ypay)	AS	'Eserc.Ordinativo',
		'Mandato '+Convert(Varchar(10),E.npay)	AS	'Num.Ordinativo',
		E.paymentadate	AS	'Data Cont. Ordinativo',
		'Trasmissione Mandati '+Convert(Varchar(10),E.npaymenttransmission)	AS	'Distinta Trasmissione',
		E.transmissiondate	AS	'Data Trasmissione',
		E.description	AS	'Descrizione',
		E.curramount	AS	'Importo Lordo',
		E.netamount	AS	'Importo Netto',
		IDF.ivatotalpayed AS 'IVA Liquidata',
		IP.nivapay AS 'Numero Liq. Iva',
		IP.start AS 'Data Inizio Liq. Iva',
		IP.stop AS 'Data Fine Liq. Iva',
		P.npay AS 'Mandato Versamento Iva',
		P.adate	AS	'Data Mandato Versamento Iva',
		E.iban	AS	'Iban Pagamento',
		E.biccode	AS	'Codice BIC/SWIFT',
		E.service	AS	'Prestazione',
		E.servicestart	AS	'Data Inizio Prest.',
		E.servicestop	AS	'Data Fine Prest.'
	FROM expenseview E
	LEFT OUTER JOIN invoicedetail ID ON (ID.idexp_taxable= E.idexp OR ID.idexp_iva = E.idexp )
	LEFT OUTER JOIN invoicedeferred IDF  ON IDF.idinvkind = ID.idinvkind AND IDF.yinv = ID.yinv AND IDF.ninv =ID.ninv
	LEFT OUTER JOIN ivapay IP ON IP.yivapay = IDF.yivapay AND IP.nivapay = IDF.nivapay
	LEFT OUTER JOIN ivapayexpenseview IE ON IP.yivapay = IE.yivapay AND IP.nivapay = IE.nivapay and IE.nphase = 2
	LEFT OUTER JOIN expense E3 ON IE.idexp = E3.parentidexp
	LEFT OUTER JOIN expenselast EL3 ON EL3.idexp = E3.idexp
	LEFT OUTER JOIN payment P ON EL3.kpay = P.kpay
	WHERE E.idupb = @idupb 
		AND E.nphase = (@SnphaseMax)
		AND E.curramount > 0
	UNION
	SELECT 
		I.phase	AS	'Fase',
		I.ymov	AS	'Eserc.Mov.',
		I.nmov	AS	'Num.Mov.',
		I.codefin	AS	'Voce Bil.',
		I.finance	AS	'Denom. Bil.',
		I.codeupb	AS	'Cod. U.P.B.',
		I.upb	AS	'U.P.B.',
		I.registry	AS	'Percipiente',
		I.p_iva	AS	'Partita iva',
		I.cf AS 'Codice Fiscale',
		I.manager	AS	'Responsabile',
		I.doc	AS	'Documento',
		I.docdate	AS	'Data Doc.',
		'Reversale '+Convert(Varchar(10),I.ypro)	AS	'Eserc.Reversale',
		'Reversale '+Convert(Varchar(10),I.npro)	AS	'Num.Reversale',
		I.adate	AS	'Data Contabile',
		'Trasmissione Reversale '+Convert(Varchar(10),I.nproceedstransmission)	AS	'Distinta Trasmissione',
		I.transmissiondate	AS	'Data Trasmissione',
		I.description	AS	'Descrizione',
		I.curramount	AS	'Importo Lordo',
		I.curramount	AS	'Importo Netto',
		IDF.ivatotalpayed AS 'IVA Liquidata',
		IP.nivapay AS 'Numero Liq. Iva',
		IP.start AS 'Data Inizio Liq. Iva',
		IP.stop AS 'Data Fine Liq. Iva',
		P.npay AS 'Mandato Versamento Iva',
		P.adate	AS	'Data Mandato Versamento Iva',
		NULL	AS	'Iban Pagamento',
		NULL	AS	'Codice BIC/SWIFT',
		NULL	AS	'Prestazione',
		NULL	AS	'Data Inizio Prest.',
		NULL	AS	'Data Fine Prest.'
	FROM incomeview I
	LEFT OUTER JOIN invoicedetail ID ON (ID.idinc_taxable = I.idinc OR ID.idinc_iva = I.idinc)
	LEFT OUTER JOIN invoicedeferred IDF  ON IDF.idinvkind = ID.idinvkind AND IDF.yinv = ID.yinv AND IDF.ninv =ID.ninv
	LEFT OUTER JOIN ivapay IP ON IP.yivapay = IDF.yivapay AND IP.nivapay = IDF.nivapay
	LEFT OUTER JOIN ivapayexpenseview IE ON IP.yivapay = IE.yivapay AND IP.nivapay = IE.nivapay and IE.nphase = 2
	LEFT OUTER JOIN expense E3 ON IE.idexp = E3.parentidexp
	LEFT OUTER JOIN expenselast EL3 ON EL3.idexp = E3.idexp
	LEFT OUTER JOIN payment P ON EL3.kpay = P.kpay
	WHERE I.idupb = @idupb 
		AND I.nphase = (@EnphaseMax)
		AND I.curramount > 0
	ORDER BY transmissiondate


END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_incomelast_no_doc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_incomelast_no_doc]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

 

CREATE                     PROCEDURE [exp_incomelast_no_doc]
@ayear int
AS 
BEGIN
--[exp_incomelast_no_doc] 2015
DECLARE @incomephase tinyint
SELECT  @incomephase = incomephase FROM config WHERE 	ayear = @ayear
 

DECLARE @maxincomephase tinyint 
DECLARE @phasecassa varchar(50)
SELECT  @maxincomephase = MAX(nphase) FROM 	incomephase
 
 --sp_help income

--sp_help incomelink
SELECT 
I.phase as 'Fase',
I.ymov as 'Eserc.',
I.nmov as 'Num.',
I.flagarrear as 'Comp./Res.',
I.parentymov as 'Eserc. padre ',
I.parentnmov as 'Num. padre',
I.idreg as '# Anagr.',
I.registry as 'Anagr.',
I.codefin as 'Cod. Bilancio',
I.finance as 'Bilancio',
I.codeupb as 'Cod. UPB',
I.upb as 'UPB',
I.doc as 'Doc. coll.',
I.docdate as 'Data doc. coll.',
I.description as 'Descrizione',
I.nbill as 'Num. sospeso',
I.ayearstartamount as 'Importo iniziale eserc.',
I.curramount as 'Importo corrente',
I.ypro as 'Eserc. Reversale',
I.npro as 'Num. Reversale',
I.nproceedstransmission as 'Num. elenco trasm.',
I.transmissiondate as 'Data Trasm.'
 from incomeview I
JOIN  incomelink IL ON IL.idchild = I.idinc AND IL.nlevel =  @incomephase -- fase contabilizzazione documenti
where I.nphase = @maxincomephase -- incassi
and I.ymov= @ayear -- ANNO CREAZIONE
and I.idpayment is null -- non è un automatismo
and I.autokind is null
and I.idinc not in (select EI.idinc from incomeinvoice EI) -- non è incasso di fattura attiva
 
and IL.idparent not in (select idinc from incomeestimate )

and I.curramount > 0
order by I.ymov, I.nmov

 

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

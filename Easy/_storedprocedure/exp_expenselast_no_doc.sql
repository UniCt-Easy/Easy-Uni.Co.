if exists (select * from dbo.sysobjects where id = object_id(N'[exp_expenselast_no_doc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_expenselast_no_doc]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

 

CREATE                     PROCEDURE [exp_expenselast_no_doc]
@ayear int
AS 
BEGIN
--[exp_expenselast_no_doc] 2015
DECLARE @expensephase tinyint
SELECT  @expensephase = expensephase FROM config WHERE 	ayear = @ayear
 

DECLARE @maxexpensephase tinyint 
DECLARE @phasecassa varchar(50)
SELECT  @maxexpensephase = MAX(nphase) FROM 	expensephase
 
--sp_help expenselink
SELECT 
E.phase as 'Fase',
E.ymov as 'Eserc.',
E.nmov as 'Num.',
E.flagarrear as 'Comp./Res.',
E.parentymov as 'Eserc. padre ',
E.parentnmov as 'Num. padre',
E.idreg as '# Anagr.',
E.registry as 'Anagr.',
E.codefin as 'Cod. Bilancio',
E.finance as 'Bilancio',
E.codeupb as 'Cod. UPB',
E.upb as 'UPB',
E.doc as 'Doc. coll.',
E.docdate as 'Data doc. coll.',
E.description as 'Descrizione',
E.nbill as 'Num. sospeso',
E.ayearstartamount as 'Importo iniziale eserc.',
E.curramount as 'Importo corrente',
E.ypay as 'Eserc. Mandato',
E.npay as 'Num. Mandato',
E.npaymenttransmission as 'Num. elenco trasm.',
E.transmissiondate as 'Data Trasm.'
 from expenseview E
JOIN expenselink EL ON EL.idchild = E.idexp AND EL.nlevel =  @expensephase -- fase contabilizzazione documenti
where E.nphase = @maxexpensephase -- liquidazioni
and E.ymov= @ayear -- ANNO CREAZIONE
and E.idpayment is null -- contributi a carico ente
and E.autokind is null
and E.idexp not in (select EI.idexp from expenseinvoice EI)
and E.idexp not in (select ET.idexp from expensetax ET)--compensi con ritenute
and E.idexp not in (select EL.idexp from expenselast EL where EL.idser is not null)--compensi senza ritenute
and EL.idparent not in (select idexp from expensemandate )
and EL.idparent not in (select idexp from expensecasualcontract)
and EL.idparent not in (select idexp from expenseprofservice)
and EL.idparent not in (select idexp from expensepayroll)
and EL.idparent not in (select idexp from expenseitineration)
and EL.idparent not in (select idexp from expensewageaddition)
and E.curramount > 0
order by E.ymov, E.nmov

 

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

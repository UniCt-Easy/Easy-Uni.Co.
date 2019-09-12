if exists (select * from dbo.sysobjects where id = object_id(N'[exp_csa_expense_config]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)

drop procedure [exp_csa_expense_config]

GO

SET QUOTED_IDENTIFIER ON

GO

SET ANSI_NULLS ON

GO
 
-- exec [exp_csa_expense_config] 2012, null, null, null

CREATE PROCEDURE  [exp_csa_expense_config]
	(
		@ayear int,
		@nphase int,
		@ymov int,
		@nmov int
	)

AS BEGIN

DECLARE @idexp int

SET @idexp = (SELECT idexp FROM expense 
              WHERE nphase = @nphase AND
					ymov = @ymov AND
					nmov = @nmov )

print  @idexp
 
 select

 phase + ' n ' + convert(varchar(10),nmov) + '/' +
 convert(varchar(4),ymov) as 'Movimento',

 codefin + '-' + finance as 'Bilancio',

 codeupb + '-' + upb as 'UPB',

 registry as 'Anagrafica',

 curramount as 'Importo Corrente',

 available as 'Importo Disponibile',

 flagarrear as 'C/R',

 'Tipo Contr. ' + csa_contractkind.contractkindcode + '-'+
 csa_contractkind.description +

 ' Contr. n°' + Convert(varchar(10),csa_contract.ncontract) + '/' +
 Convert(varchar(4),csa_contract.ycontract) + '-' + csa_contract.title
 as 'Imputazione Costo Lordo',

 NULL as 'Imputazione Costo Contributo CSA',

 NULL as 'Ripartizione Costo Lordo',

 NULL as 'Ripartizione Costo Contributo CSA'

 FROM expenseview

 join csa_contract on expenseview.idexp = csa_contract.idexp_main and
 expenseview.ayear = csa_contract.ayear

 join csa_contractkind on csa_contractkind.idcsa_contractkind =
 csa_contract.idcsa_contractkind

 WHERE (expenseview.nphase = @nphase or @nphase is null)
 and (expenseview.ayear = @ayear)
 and (expenseview.idexp = @idexp or @idexp is null)
 and (expenseview.ymov  = @ymov or @ymov is null)

 UNION ALL

 SELECT

 phase + ' n ' + convert(varchar(10),nmov) + '/' +
 convert(varchar(4),ymov) as 'Movimento',

 codefin + '-' + finance as 'Bilancio',

 codeupb + '-' + upb as 'UPB',

 registry as 'Anagrafica',

 curramount as 'Importo Corrente',

 available as 'Importo Disponibile',

 flagarrear as 'C/R',

 NULL as 'Imputazione Costo Lordo',

 'Tipo Contr. ' + CK1.contractkindcode + '-'+ CK1.description +

 ' Contr. n°' + Convert(varchar(10),C1.ncontract) + '/' +
 Convert(varchar(4),C1.ycontract) + '-' + C1.title + ' Voce CSA:' +
 csa_contracttax.vocecsa as 'Imputazione Costo Contributo CSA',

 NULL as 'Ripartizione Costo Lordo',

 NULL as 'Ripartizione Costo Contr. CSA'

 FROM expenseview

 join csa_contracttax on expenseview.idexp = csa_contracttax.idexp and
 expenseview.ayear = csa_contracttax.ayear

 join csa_contract C1 on csa_contracttax.idcsa_contract =
 C1.idcsa_contract and csa_contracttax.ayear = C1.ayear

 join csa_contractkind CK1 on CK1.idcsa_contractkind = C1.idcsa_contractkind

 WHERE (expenseview.nphase = @nphase or @nphase is null)
 and (expenseview.ayear = @ayear)
 and (expenseview.idexp = @idexp or @idexp is null)
 and (expenseview.ymov  = @ymov or @ymov is null)
 

 UNION ALL

 SELECT

 phase + ' n ' + convert(varchar(10),nmov) + '/' +
 convert(varchar(4),ymov) as 'Movimento',

 codefin + '-' + finance as 'Bilancio',

 codeupb + '-' + upb as 'UPB',

 registry as 'Anagrafica',

 curramount as 'Importo Corrente',

 available as 'Importo Disponibile',

 flagarrear as 'C/R',

 NULL as 'Imputazione Costo Lordo',

 NULL as 'Imputazione Costo Contributo CSA',

 'Tipo Contr. ' + CK2.contractkindcode + '-'+ CK2.description +

 ' Contr. n°' + Convert(varchar(10),C2.ncontract) + '/' +
 Convert(varchar(4),C2.ycontract) + '-' + C2.title + ' Quota Rip. ' +

 Convert(varchar(15),csa_contractexpense.quota * 100) + ' %' as
 'Ripartizione Costo Lordo',

 NULL as 'Ripartizione Costo Contr. CSA'

 FROM expenseview

 join csa_contractexpense on expenseview.idexp =
 csa_contractexpense.idexp and csa_contractexpense.ayear =
 expenseview.ayear

 join csa_contract C2 on csa_contractexpense.idcsa_contract =
 C2.idcsa_contract and csa_contractexpense.ayear = C2.ayear

 join csa_contractkind CK2 on CK2.idcsa_contractkind = C2.idcsa_contractkind

 WHERE (expenseview.nphase = @nphase or @nphase is null)
 and (expenseview.ayear = @ayear)
 and (expenseview.idexp = @idexp or @idexp is null)
 and (expenseview.ymov  = @ymov or @ymov is null)

 UNION ALL

 select

 phase + ' n ' + convert(varchar(10),nmov) + '/' +
 convert(varchar(4),ymov) as 'Movimento',

 codefin + '-' + finance as 'Bilancio',

 codeupb + '-' + upb as 'UPB',

 registry as 'Anagrafica',

 curramount as 'Importo Corrente',

 available as 'Importo Disponibile',

 flagarrear as 'C/R',

 NULL as 'Imputazione Costo Lordo',

 NULL as 'Imputazione Costo Contributo CSA',

 NULL as 'Ripartizione Costo Lordo',

 'Tipo Contr. ' + CK3.contractkindcode + '-'+ CK3.description +

 ' Contr. n°' + Convert(varchar(10),C3.ncontract) + '/' +
 Convert(varchar(4),C3.ycontract) + '-' + C3.title + ' Voce CSA:' +
 CT3.vocecsa + ' Quota Rip.' +

 Convert(varchar(15),csa_contracttaxexpense.quota * 100) + ' %' as
 'Ripartizione Costo Contr. CSA'

 from expenseview

 join csa_contracttaxexpense on expenseview.idexp = csa_contracttaxexpense.idexp

 join csa_contracttax CT3 on CT3.idcsa_contracttax=
 csa_contracttaxexpense.idcsa_contracttax and

         CT3.idcsa_contract = csa_contracttaxexpense.idcsa_contract and
 csa_contracttaxexpense.ayear = expenseview.ayear

 join csa_contract C3 on csa_contracttaxexpense.idcsa_contract =
 C3.idcsa_contract and csa_contracttaxexpense.ayear = C3.ayear

 join csa_contractkind CK3 on CK3.idcsa_contractkind = C3.idcsa_contractkind

 WHERE (expenseview.nphase = @nphase or @nphase is null)
 and (expenseview.ayear = @ayear)
 and (expenseview.idexp = @idexp or @idexp is null)
 and (expenseview.ymov  = @ymov or @ymov is null)

END


GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 ----where exists (select * from csa_contract where ayear =
 --expenseview.ayear and csa_contract.idexp_main = expenseview.idexp and
 --(idexp_main = @idexp or @idexp is null))

 ----or exists (select * from csa_contracttax where ayear =
 --expenseview.ayear and csa_contracttax.idexp = expenseview.idexp and
 --(idexp = @idexp or @idexp is null))

 ----or exists (select * from csa_contractexpense where ayear =
 --expenseview.ayear and csa_contractexpense.idexp = expenseview.idexp
 --AND (idexp = @idexp or @idexp is null))

 ----or exists (select * from csa_contracttaxexpense where ayear =
 --expenseview.ayear and csa_contracttaxexpense.idexp = expenseview.idexp
 --and (idexp = @idexp or @idexp is null))

 ----and (expenseview.nphase = @nphase or @nphase is null)

 ----and (expenseview.ayear = @ayear)

 
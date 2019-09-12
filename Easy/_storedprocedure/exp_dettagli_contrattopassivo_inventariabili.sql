--setuser'amm'
if exists (select * from dbo.sysobjects where id = object_id(N'[exp_dettagli_contrattopassivo_inventariabili]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_dettagli_contrattopassivo_inventariabili]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE         PROCEDURE [exp_dettagli_contrattopassivo_inventariabili]
(
	@ayear int,
	@idmankind varchar(20)
)

AS BEGIN
-- [exp_dettagli_contrattopassivo_inventariabili] 2017, null
 
DECLARE @idmankind_detail varchar(50)
DECLARE @yman int
DECLARE @nman int
DECLARE @npackage decimal(19,2)
DECLARE @idgroup int
 
 

CREATE TABLE #mandate_detail 
( idmankind varchar(50), mandatekind varchar(150), yman int, nman int, registry varchar(100),
  detaildescription varchar(150), codeinv varchar(50), inventorytree varchar(150), ordered decimal(19,2), loaded decimal(19,2), residual decimal(19,2), taxable decimal(19,2), 
  taxrate decimal(19,2), discount varchar(20), idgroup int, assetkind char(1))

	INSERT INTO #mandate_detail (idmankind, mandatekind,yman, nman, registry, detaildescription, codeinv, inventorytree, ordered, loaded, residual, taxable, 
					taxrate, discount, idgroup, assetkind)
	SELECT MD.idmankind, MD.mankind, MD.yman, MD.nman, MD.registry,  MD.detaildescription,	MD.codeinv,MD.inventorytree,
		MD.ordered, MD.loaded, MD.residual, MD.taxable,
		isnull(MD.taxrate * 100 , 0), convert(varchar(10),isnull( MD.discount * 100, 0))+ '%', 
		MD.idgroup, MD.assetkind
	FROM mandatedetailavailable MD
	 
	WHERE MD.assetkind IN ('A', 'P') --- INVENTARIABILE O AUMENTO DI VALORE 
	AND MD.residual > 0 and MD.idinv is not null and MD.linktoasset = 'S' and MD.stop is null
	AND MD.yman = @ayear AND ( MD.idmankind = @idmankind OR @idmankind IS NULL)
 
 



SELECT mandatekind as 'Tipo Contratto',yman AS 'Esercizio', nman AS 'N.ordine', idgroup as '#Dettaglio',case assetkind 
		when 'A' then 'Inventariabile'
		when 'P' then 'Aumento di valore'
		when 'S' then 'Servizi'
		when 'M' then 'Magazzino'
		else 'Altro'
	end 'Tipo bene', 
	registry AS 'Nome fornitore',detaildescription AS 'Descrizione dettaglio', codeinv as 'Cod. Classificazione', inventorytree as 'Classificazione', 
	taxable AS 'Imponibile', taxrate AS 'Iva %', discount AS 'Sconto', 
	ordered as 'Quantità',  loaded as 'Quantità caricata', residual as 'Quantità residua'
	
FROM #mandate_detail order by mandatekind, yman, nman

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


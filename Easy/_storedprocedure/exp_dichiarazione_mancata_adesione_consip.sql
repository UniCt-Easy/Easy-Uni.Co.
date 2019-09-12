if exists (select * from dbo.sysobjects where id = object_id(N'[exp_dichiarazione_mancata_adesione_consip]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_dichiarazione_mancata_adesione_consip]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE      PROCEDURE [exp_dichiarazione_mancata_adesione_consip]
	@idmankind varchar(20),
	@yman int,
	@startnman int,
	@stopnman  int,
	@idsor01 int,
	@idsor02 int,
	@idsor03 int,
	@idsor04 int,
	@idsor05 int
AS BEGIN
-- exec exp_dichiarazione_mancata_adesione_consip  'CP_PCC', 2015, 1,10,null,null,null,null,null
SELECT 
mandatekind.description as 'Tipo',
mandate.nman as 'Numero',
mandate.yman as 'Esercizio',
mandate.adate as 'Data Registrazione Ordine',
[dbo].[estrai_valore_token](consipkind.description, mandate.consipmotive,'Categoria') as 'Categoria merceologica',
ISNULL(consipkind.flagpurchaseperformed,'S') as 'Acquisto Effettuato su CONSIP',
[dbo].[estrai_valore_token](consipkind.description, mandate.consipmotive,'Convenzione') as 'Numero Convenzione',
mandate.consipmotive as 'Motivazione mancata adesione CONSIP',
CASE consipkind_ext.idconsipkind_header
	WHEN 1 then 'S'
	WHEN 4 then 'N'
	ELSE 'N'
END as 'adesione MEPA'
FROM mandate 
JOIN mandatekind on mandate.idmankind = mandatekind.idmankind
LEFT OUTER JOIN consipkind on mandate.idconsipkind = consipkind.idconsipkind
LEFT OUTER JOIN consipkind_ext on mandate.idconsipkind_ext = consipkind_ext.idconsipkind
WHERE (mandate.idmankind = @idmankind OR @idmankind IS NULL)
AND mandate.yman = @yman
AND ((mandate.nman BETWEEN @startnman and 	@stopnman) OR(@startnman IS NULL AND @stopnman IS NULL) )
--AND consipkind.flagpurchaseperformed = 'N'
	AND (isnull(mandate.idsor01,mandatekind.idsor01) = @idsor01 OR @idsor01 IS NULL)
	AND (isnull(mandate.idsor02,mandatekind.idsor02) = @idsor02 OR @idsor02 IS NULL)
	AND (isnull(mandate.idsor03,mandatekind.idsor03) = @idsor03 OR @idsor03 IS NULL)
	AND (isnull(mandate.idsor04,mandatekind.idsor04) = @idsor04 OR @idsor04 IS NULL)
	AND (isnull(mandate.idsor05,mandatekind.idsor05) = @idsor05 OR @idsor05 IS NULL)
END
 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


 

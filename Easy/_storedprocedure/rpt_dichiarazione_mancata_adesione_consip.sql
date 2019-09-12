if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_dichiarazione_mancata_adesione_consip]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_dichiarazione_mancata_adesione_consip]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE      PROCEDURE [rpt_dichiarazione_mancata_adesione_consip]
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
-- exec rpt_dichiarazione_mancata_adesione_consip  'CP_PCC', 2015, 1,10,null,null,null,null,null
SELECT
	mandate.idmankind,
	mandate.yman,
	mandate.nman,
	mandatekind.description AS 'mandatekind',
	mandate.adate,
	consipkind.idconsipkind,
	consipkind_header.idconsipkind as 'idconsipkind_header',
	consipkind_header.description as 'consipkind_header',
	mandate.consipmotive, -- motivazione compilata
	consipkind_ext.idconsipkind as 'idconsipkind_ext',
	consipkind_ext.description as 'consipkind_ext',
    consipkind_ext_header.idconsipkind as 'idconsipkiond_ext_header',
    consipkind_ext_header.description as 'consipkind_ext_header'
FROM   mandate
JOIN mandatekind  
	ON mandate.idmankind = mandatekind.idmankind 
JOIN consipkind
	ON consipkind.idconsipkind = mandate.idconsipkind
JOIN consipkind as consipkind_header
	ON consipkind_header.idconsipkind = (SELECT MAX(idconsipkind) FROM consipkind as consipkind_1 
										 WHERE consipkind_1.flagheader = 'S' 
										 AND consipkind_1.position <= consipkind.position)
LEFT OUTER JOIN consipkind_ext
	ON consipkind_ext.idconsipkind = mandate.idconsipkind_ext
LEFT OUTER JOIN consipkind_ext as consipkind_ext_header
	ON consipkind_ext_header.idconsipkind = consipkind_ext.idconsipkind_header  
WHERE (mandate.idmankind = @idmankind OR @idmankind IS NULL)
AND mandate.yman = @yman
AND ((mandate.nman BETWEEN @startnman and 	@stopnman) OR(@startnman IS NULL AND @stopnman IS NULL) )
AND (isnull(mandate.idsor01,mandatekind.idsor01) = @idsor01 OR @idsor01 IS NULL)
AND (isnull(mandate.idsor02,mandatekind.idsor02) = @idsor02 OR @idsor02 IS NULL)
AND (isnull(mandate.idsor03,mandatekind.idsor03) = @idsor03 OR @idsor03 IS NULL)
AND (isnull(mandate.idsor04,mandatekind.idsor04) = @idsor04 OR @idsor04 IS NULL)
AND (isnull(mandate.idsor05,mandatekind.idsor05) = @idsor05 OR @idsor05 IS NULL)
AND consipkind.flagpurchaseperformed = 'N'
ORDER BY mandate.idmankind, mandate.yman, mandate.nman 
END
 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
 


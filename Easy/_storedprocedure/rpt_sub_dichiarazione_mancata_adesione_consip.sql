
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_sub_dichiarazione_mancata_adesione_consip]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_sub_dichiarazione_mancata_adesione_consip]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE      PROCEDURE [rpt_sub_dichiarazione_mancata_adesione_consip]
	@idmankind varchar(20),
	@yman int,
	@nman int
AS BEGIN
-- exec rpt_sub_dichiarazione_mancata_adesione_consip  'CP_PCC', 2015, 1
SELECT
	mandate.idmankind,
	mandate.yman,
	mandate.nman,
	mandatekind.description AS 'mandatekind',
	CONVERT(datetime, mandate.adate)  as adate, 
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
WHERE mandate.idmankind = @idmankind
AND mandate.yman = @yman
AND mandate.nman = @nman
AND consipkind.flagpurchaseperformed = 'N'
END
 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 
 


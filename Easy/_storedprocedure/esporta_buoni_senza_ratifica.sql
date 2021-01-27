
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[esporta_buoni_senza_ratifica]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [esporta_buoni_senza_ratifica]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE   PROCEDURE [esporta_buoni_senza_ratifica]
-- exec [esporta_buoni_senza_ratifica]
AS BEGIN
SELECT
	assetloadview.codeassetloadkind as 'Cod. Tipo Buono Carico',
	assetloadview.assetloadkind 'Tipo Buono carico',
	assetloadview.yassetload 'Eserc.Buono',
	assetloadview.nassetload 'Num.Buono',
	assetloadview.adate 'Data Contabile',
	assetloadview.totalassetacquire as 'Totale carichi',
	assetloadview.assetamortizationamount as 'Totale rivalutazioni',
	assetloadview.totalassetload as 'Totale Buono'

FROM 	assetloadview 
WHERE 	assetloadview.ratificationdate is null
ORDER BY assetloadview.codeassetloadkind,
	 assetloadview.yassetload desc,
	 assetloadview.nassetload  			
			
END





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


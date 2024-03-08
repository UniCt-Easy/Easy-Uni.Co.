
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


if exists (select * from dbo.sysobjects where id = object_id(N'[esporta_variazioni_diminuzione_ente]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [esporta_variazioni_diminuzione_ente]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE       PROCEDURE [esporta_variazioni_diminuzione_ente]
@year	int,
@codinventoryagency int,
@date			smalldatetime,
@idinv int
AS BEGIN
	declare @firstlevelidinv int
	select @firstlevelidinv = idparent
		from inventorytreelink
		where idchild = @idinv
		and nlevel = 1

--Considera le variazioni patrimoniale in aumento di tipo <> 'I'
SELECT 		ROUND(ISNULL(assetvardetail.amount, 0),2) as 'Importo Variazioni Diminuzione',
		assetvar.yvar		as 'Eserc. Variazione',
		assetvar.nvar		as 'Num. Variazione',
		inventorytree.codeinv	as 'Class. inventariale' 
		FROM assetvardetail 
		join inventorytree
			on inventorytree.idinv = assetvardetail.idinv
		JOIN assetvar
			ON assetvardetail.idassetvar = assetvar.idassetvar
		join inventorytreelink as linkcategoria
			on linkcategoria.idchild = assetvardetail.idinv and linkcategoria.nlevel = 1
		WHERE assetvar.flag&1 <> 0
		AND assetvar.yvar = @year
		AND assetvar.adate <= @date
		AND assetvardetail.amount < 0
		AND linkcategoria.idparent = isnull(@firstlevelidinv, linkcategoria.idparent)
		AND assetvar.idinventoryagency = isnull(@codinventoryagency, assetvar.idinventoryagency)
	
END
SET QUOTED_IDENTIFIER ON 



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

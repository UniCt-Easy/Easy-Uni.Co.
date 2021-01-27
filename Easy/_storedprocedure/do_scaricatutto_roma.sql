
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


if exists (select * from dbo.sysobjects where id = object_id(N'[do_scaricatutto_roma]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [do_scaricatutto_roma]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



CREATE      PROCEDURE [do_scaricatutto_roma](
	@adate datetime,
    @codeinventory varchar(20)
)
as 
BEGIN

 --crea un buono scarico per l'inventario in ingresso con tutti i cespiti in carico e non scaricati dello stesso inventario
declare @idinventory int
select @idinventory= idinventory from inventory where codeinventory=@codeinventory

declare @ayear int
set @ayear= year(@adate)

declare @nassetunload int
declare @idassetunload int

set @idassetunload = isnull( (select max(idassetunload) from assetunload),0)+1
set @nassetunload = isnull( (select max(nassetunload) from assetunload where yassetunload=@ayear),0)+1

declare @idmot int
select @idmot= idmot from assetunloadmotive where codemot='07_EASY'

if (@idmot is null) begin
	SET  @idmot= (select top 1 idmot from assetunloadmotive where active='S')
end

-- tipo buono scarico = quello di codice pari all'inventario oppure uno qualsiasi applicabile a quell'inventario
declare @idassetunloadkind int
select @idassetunloadkind = idassetunloadkind from assetunloadkind where idinventory=@idinventory and codeassetunloadkind=@codeinventory

if (@idassetunloadkind is null) BEGIN
	SET @idassetunloadkind= (select top 1 idassetunloadkind from assetunloadkind where idinventory=@idinventory )
END

insert into assetunload(yassetunload,nassetunload,adate,ct,cu,description,lt,lu,ratificationdate,idmot,idassetunloadkind,idassetunload)
values (@ayear, @nassetunload, @adate, getdate(), 'scaricatutto',
 'Consolidamento patrimonio',getdate(),'scaricatutto',@adate,@idmot,@idassetunloadkind,@idassetunload)



update asset set idassetunload = @idassetunload 
		from asset 
		join assetview AC on asset.idasset=AC.idasset and asset.idpiece= AC.idpiece
		where AC.is_loaded='S' and AC.is_unloaded='N' and AC.idinventory=@idinventory 
					and asset.idassetunload is null


END




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


if exists (select * from dbo.sysobjects where id = object_id(N'[check_patrimonio_unified]') 
and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_patrimonio_unified]
GO

--check_patrimonio_unified 2012,'N',null

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
CREATE         PROCEDURE check_patrimonio_unified
(
	@ayear smallint,
	@check_group char(1),
    @unified char(1),    
    @codicesol varchar(100)
)
AS
BEGIN
CREATE TABLE #check (
	 idasset int,
	 idpiece int,
	 lifestart datetime ,
	 codeinventory varchar(20),
	 ninventory int,
	 codeinv varchar(50),
	 nassetacquire int,
	 codeassetloadkind varchar(20),
	 yassetload smallint,
	 nassetload int,
	 codeassetunloadkind varchar(20),
	 yassetunload smallint,
	 nassetunload int,
	 err varchar(400),
	 sol varchar(400),
	 departmentname			varchar(200)
	)


-- exec check_patrimonio_unified 2012,'S',null
	IF (@unified ='N') 
	Begin
		insert into #check(
			 idasset,
			 idpiece,
			 lifestart,
			 codeinventory,
			 ninventory,
			 codeinv,
			 nassetacquire,
			 codeassetloadkind,
			 yassetload,
			 nassetload,
			 codeassetunloadkind,
			 yassetunload,
			 nassetunload,
			 err,
			 sol                         
			)
		EXEC check_patrimonio @ayear, @check_group, @unified, @codicesol
		
		SELECT 
	idasset as 'Num.cespite',
	case when	 (idpiece=1) then 'C'
		else 'A'
	end as 'Cespite/Accessorio',	
	lifestart as 'Inizio esistenza',
	codeinventory as 'Cod.Inv.',
	ninventory as 'N.Inv.',
	codeinv as 'Class.Inv.',
	nassetacquire as 'N.Carico',
	codeassetloadkind as 'Tipo buono Carico',
	yassetload as 'Eserc.Buono Carico',
	nassetload as 'N.Buono Carico',
	codeassetunloadkind  as 'Tipo buono Scarico',
	yassetunload 'Eserc.Buono Carico',
	nassetunload as 'N.Buono Carico',
	err as 'Errore',
	sol as 'Soluzione'
	FROM #check

	RETURN
	End
		
	

	declare @iddbdepartment varchar(50)
	declare @crsdepartment cursor
	set 	@crsdepartment = cursor for select  iddbdepartment from dbdepartment
	 where (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear) 
	open 	@crsdepartment
	fetch next from @crsdepartment into @iddbdepartment
	while @@fetch_status=0 begin
		declare @dip_nomesp varchar(300)
		set @dip_nomesp = @iddbdepartment + '.check_patrimonio'
		insert into #check(
			 idasset,
			 idpiece,
			 lifestart,
			 codeinventory,
			 ninventory,
			 codeinv,
			 nassetacquire,
			 codeassetloadkind,
			 yassetload,
			 nassetload,
			 codeassetunloadkind,
			 yassetunload,
			 nassetunload,
			 err,
			 sol,
			 departmentname	                         
			)

			exec @dip_nomesp @ayear, @check_group, @unified, null
			
		fetch next from @crsdepartment into @iddbdepartment
	END
	
SELECT 
	departmentname as 'Dipartimento',
	idasset as 'Num.cespite',
	case when	 (idpiece=1) then 'C'
		else 'A'
	end as 'Cespite/Accessorio',	
	lifestart as 'Inizio esistenza',
	codeinventory as 'Cod.Inv.',
	ninventory as 'N.Inv.',
	codeinv as 'Class.Inv.',
	nassetacquire as 'N.Carico',
	codeassetloadkind as 'Tipo buono Carico',
	yassetload as 'Eserc.Buono Carico',
	nassetload as 'N.Buono Carico',
	codeassetunloadkind  as 'Tipo buono Scarico',
	yassetunload 'Eserc.Buono Carico',
	nassetunload as 'N.Buono Carico',
	err as 'Errore',
	sol as 'Soluzione'
 FROM #check


END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

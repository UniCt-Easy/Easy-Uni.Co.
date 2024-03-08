
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


if exists (select * from dbo.sysobjects where id = object_id(N'[check_patrimonio]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_patrimonio]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- check_patrimonio 2011,'M','N',null
--setuser 'amm'

CREATE         PROCEDURE [check_patrimonio]  
(
	@ayear smallint,
	@check_group char(1), -- C = carico cespiti e accessori;  B= Buoni di carico; S = Scarico;  M = ammortamenti; I = Piano ammortamenti ;
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
 amount decimal(19,2),
 err varchar(400),
 sol varchar(400)
 
)

declare @err varchar(400)
declare @sol varchar(400)

if (substring(@codicesol,1,1)<>'§')
 set @codicesol=null
else 
 set @codicesol=substring(@codicesol,2,20)



if (@codicesol='K121' ) 
BEGIN
 update assetacquire set flag = flag & 0xFE 
    WHERE idassetload is null AND (flag&1 <> 0)
		and exists (select * from asset A where A.nassetacquire = assetacquire.nassetacquire 
								and ( (A.idassetunload is not null) OR (A.flag&1 = 0) ) 
					)
END

IF (  @check_group in ('C','*') )
Begin
	set @err='carichi cespite e accessori senza buoni di carico (con flag ''da inserire in buono'') , scaricati'
	set @sol='marcare i carichi come ''da non inserire in buono carico'' cod.K121'
	insert into #check(idasset, idpiece , lifestart ,codeinventory,ninventory, nassetacquire ,codeinv,
							codeassetloadkind , yassetload , nassetload , codeassetunloadkind , yassetunload , nassetunload , err,sol)
	SELECT 
		A.idasset, 	A.idpiece, A.lifestart, I.codeinventory,A.ninventory,A.nassetacquire,ITREE.codeinv,ALK.codeassetloadkind ,
		AL.yassetload 	,AL.nassetload 	,AUK.codeassetunloadkind,AU.yassetunload,AU.nassetunload ,@err,@sol
	FROM  asset A
	join assetacquire B					on A.nassetacquire=B.nassetacquire
	join inventorytree ITREE			on B.idinv= ITREE.idinv
	LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory
	left outer join assetload AL		on AL.idassetload=B.idassetload
	left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind
	left outer join assetunload AU		on AU.idassetunload=A.idassetunload
	left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind
	WHERE 
		( (B.idassetload is null) AND (B.flag&1 <> 0) )  --non in carico
		AND
		( (A.idassetunload is not null) OR (A.flag&1 = 0) ) 	--scaricato
End

if (@codicesol='K129') 
BEGIN
 update assetacquire set flag = flag | 0x01
    WHERE idassetload is not null AND (flag&1 = 0)				
END

IF (@check_group in ('C','*'))
Begin
	set @err='carichi cespite e accessori inseriti in buoni di carico (senza flag ''da inserire in buono'') '
	set @sol='marcare i carichi come ''da inserire in buono carico'' cod.K129'
	insert into #check(idasset, idpiece , lifestart ,codeinventory,ninventory, nassetacquire ,codeinv,
							codeassetloadkind , yassetload , nassetload , codeassetunloadkind , yassetunload , nassetunload , err,sol)
	SELECT 
		A.idasset, 	A.idpiece, A.lifestart, I.codeinventory,A.ninventory,A.nassetacquire,ITREE.codeinv,ALK.codeassetloadkind ,
		AL.yassetload 	,AL.nassetload 	,AUK.codeassetunloadkind,AU.yassetunload,AU.nassetunload ,@err,@sol
	FROM  asset A
	join assetacquire B					on A.nassetacquire=B.nassetacquire
	join inventorytree ITREE			on B.idinv= ITREE.idinv
	LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory
	left outer join assetload AL		on AL.idassetload=B.idassetload
	left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind
	left outer join assetunload AU		on AU.idassetunload=A.idassetunload
	left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind
	WHERE 
		( (B.idassetload is not null) AND (B.flag&1 = 0) )  
End

-- 

if (@codicesol='Q290') 
BEGIN
 update assetacquire set flag = isnull(flag,0) | 0x02
    WHERE  (flag&4 <> 0) AND							--accessorio
			idassetload is  null AND ( (flag&1) <> 0)   --non in carico		
			AND ( (flag& 2)  = 0)                      --nuova acquisizione	
END


IF (@check_group in ('C','*')	)
Begin
	set @err='carichi accessori senza buoni di carico (senza flag ''da inserire in buono'') e al contempo nuove acquisizioni '
	set @sol='marcare i carichi come carichi di accessori posseduti cod.Q290'
	insert into #check(idasset, idpiece , lifestart ,codeinventory,ninventory, nassetacquire ,codeinv,
							codeassetloadkind , yassetload , nassetload , codeassetunloadkind , yassetunload , nassetunload , err,sol)
	SELECT 
		A.idasset, 	A.idpiece, A.lifestart, I.codeinventory,A.ninventory,A.nassetacquire,ITREE.codeinv,ALK.codeassetloadkind ,
		AL.yassetload 	,AL.nassetload 	,AUK.codeassetunloadkind,AU.yassetunload,AU.nassetunload ,@err ,@sol
	FROM  asset A
	join assetacquire B					on A.nassetacquire=B.nassetacquire
	join inventorytree ITREE			on B.idinv= ITREE.idinv
	LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory
	left outer join assetload AL		on AL.idassetload=B.idassetload
	left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind
	left outer join assetunload AU		on AU.idassetunload=A.idassetunload
	left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind
	WHERE 
		A.idpiece > 1		--accessorio
		AND ( (B.idassetload is null) AND ( (B.flag&1) <> 0) )  --non in carico
		AND ( (B.flag& 2)  = 0) --nuova acquisizione
End


if(@check_group in ('M','*'))
Begin
	set @err='cespiti/accessori ammortizzati in data successiva allo scarico'
	-- AMMORTAMENTI SENZA BUONO SCARICO
	insert into #check(idasset, idpiece , lifestart ,codeinventory,ninventory, nassetacquire ,codeinv,
							codeassetloadkind , yassetload , nassetload , codeassetunloadkind , yassetunload , nassetunload , err)
	SELECT 
		A.idasset, 	A.idpiece, A.lifestart, I.codeinventory,A.ninventory,A.nassetacquire,ITREE.codeinv,ALK.codeassetloadkind ,
		AL.yassetload 	,AL.nassetload 	,AUK.codeassetunloadkind,AU.yassetunload,AU.nassetunload ,@err 
	FROM  asset A
	join assetacquire B					on A.nassetacquire=B.nassetacquire
	join inventorytree ITREE			on B.idinv= ITREE.idinv
	LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory
	left outer join assetload AL		on AL.idassetload=B.idassetload
	left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind
	left outer join assetunload AU		on AU.idassetunload=A.idassetunload
	left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind
	WHERE 
		(A.idassetunload is null) 
		AND exists (
			select * from assetamortization AA where AA.idasset= A.idasset and AA.idpiece=A.idpiece
						AND (AA.flag&1) = 0				/* non includere in un buono di scarico */
						 AND  year(AA.adate) > year(AU.adate)
				)
End


if(@check_group in ('M','*'))
Begin
	set @err='cespiti/accessori ammortizzati in data successiva allo scarico'
	-- AMMORTAMENTI SENZA BUONO SCARICO
	insert into #check(idasset, idpiece , lifestart ,codeinventory,ninventory, nassetacquire ,codeinv,
							codeassetloadkind , yassetload , nassetload , codeassetunloadkind , yassetunload , nassetunload , err)
	SELECT 
		A.idasset, 	A.idpiece, A.lifestart, I.codeinventory,A.ninventory,A.nassetacquire,ITREE.codeinv,ALK.codeassetloadkind ,
		AL.yassetload 	,AL.nassetload 	,AUK.codeassetunloadkind,AU.yassetunload,AU.nassetunload ,@err 
	FROM  asset A
	join assetacquire B					on A.nassetacquire=B.nassetacquire
	join inventorytree ITREE			on B.idinv= ITREE.idinv
	LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory
	left outer join assetload AL		on AL.idassetload=B.idassetload
	left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind
	left outer join assetunload AU		on AU.idassetunload=A.idassetunload
	left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind
	WHERE 
		(A.idassetunload is null) 
		AND exists (
			select * from assetamortization AA 
						join assetunload AAU on AA.idassetunload = AAU.idassetunload
						where AA.idasset= A.idasset and AA.idpiece=A.idpiece
						AND (AA.flag&1) <> 0				 /*  includi in buono scarico */
						 AND  year(AAU.adate) > year(AU.adate)
				)
End



if (@codicesol='S018') 
BEGIN
-- marca  gli accessori come Nuova acquisizione, se gli acessori hanno ammortamenti e sono senza flag 'nuova acquisizione'   
    update assetacquire set flag = flag & 0xFD 
    WHERE (flag & 4 <> 0) -- accessorio
		and (flag&2 <> 0) -- posseduto
		and exists (select * from assetamortization AA 
					join asset A
						on AA.idasset= A.idasset and AA.idpiece=A.idpiece 
					where  A.nassetacquire=assetacquire.nassetacquire
					)
END

if(@check_group in ('M','*')			)
Begin
	set @err='accessori con AMMORTAMENTI ma senza flag ''nuova acquisizione'''
	set @sol='marcare gli accessori come nuova acquisizione cod.S018'
	insert into #check(idasset, idpiece , lifestart ,codeinventory,ninventory, nassetacquire ,codeinv,
							codeassetloadkind , yassetload , nassetload , codeassetunloadkind , yassetunload , nassetunload , err,sol)
	SELECT 
		A.idasset, 	A.idpiece, A.lifestart, I.codeinventory,A.ninventory,A.nassetacquire,ITREE.codeinv,ALK.codeassetloadkind ,
		AL.yassetload 	,AL.nassetload 	,AUK.codeassetunloadkind,AU.yassetunload,AU.nassetunload ,@err,@sol
	FROM  asset A
	join assetacquire B					on A.nassetacquire=B.nassetacquire
	LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory
	join inventorytree ITREE			on B.idinv= ITREE.idinv
	left outer join assetload AL		on AL.idassetload=B.idassetload
	left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind
	left outer join assetunload AU		on AU.idassetunload=A.idassetunload
	left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind
	WHERE 
		A.idpiece> 1 
		and ( (B.flag & 2) <> 0)
		AND exists(	select * from assetamortization AA 
						where AA.idasset= A.idasset and AA.idpiece=A.idpiece
				)
End
			
			



--


if (@codicesol='F012') 
BEGIN
	update assetamortization set flag = flag | 0x01
    WHERE  (flag&1 = 0)	
		and assetamortization.idassetunload is not null
END

if(@check_group in ('M','*'))
Begin
	set @err='cespiti o accessori con AMMORTAMENTI senza flag ''includi in buono scarico'', ma inclusi in buono scarico'
	set @sol='marcare gli ammortamenti come da includere in buono di scarico cod.F012'
	insert into #check(idasset, idpiece , lifestart ,codeinventory,ninventory, nassetacquire ,codeinv,
							codeassetloadkind , yassetload , nassetload , codeassetunloadkind , yassetunload , nassetunload , err)
	SELECT 
		A.idasset, 	A.idpiece, A.lifestart, I.codeinventory,A.ninventory,A.nassetacquire,ITREE.codeinv,ALK.codeassetloadkind ,
		AL.yassetload 	,AL.nassetload 	,AUK.codeassetunloadkind,AU.yassetunload,AU.nassetunload ,@err 
	FROM  asset A
	join assetacquire B					on A.nassetacquire=B.nassetacquire
	LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory
	join inventorytree ITREE			on B.idinv= ITREE.idinv
	left outer join assetload AL		on AL.idassetload=B.idassetload
	left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind
	left outer join assetunload AU		on AU.idassetunload=A.idassetunload
	left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind
	WHERE exists 
	  (	select * from assetamortization AA 
						where  AA.idassetunload is not null 
							AND AA.idasset= A.idasset and AA.idpiece=A.idpiece
						AND (AA.flag&1) = 0				 /*  non includere in buono scarico */					 
				)
End


--

if (@codicesol='F320') 
BEGIN
	update assetamortization set flag = flag & 0xFE
    WHERE  (flag&1 <> 0)	
		and assetamortization.idassetunload is null  
		and assetamortization.idassetload is null  
END

if(@check_group in ('M','*')			)
Begin
	set @err='cespiti o accessori con AMMORTAMENTI aventi flag ''includi in buono scarico'' ma senza buono scarico'
	set @sol='marcare gli AMMORTAMENTI come da non includere in buono di scarico cod. F320'
	insert into #check(idasset, idpiece , lifestart ,codeinventory,ninventory, nassetacquire ,codeinv,
							codeassetloadkind , yassetload , nassetload , codeassetunloadkind , yassetunload , nassetunload , err,sol)
	SELECT 
		A.idasset, 	A.idpiece, A.lifestart, I.codeinventory,A.ninventory,A.nassetacquire,ITREE.codeinv,ALK.codeassetloadkind ,
		AL.yassetload 	,AL.nassetload 	,AUK.codeassetunloadkind,AU.yassetunload,AU.nassetunload ,@err,@sol
	FROM  asset A
	join assetacquire B					on A.nassetacquire=B.nassetacquire
	join inventorytree ITREE			on B.idinv= ITREE.idinv
	LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory
	left outer join assetload AL		on AL.idassetload=B.idassetload
	left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind
	left outer join assetunload AU		on AU.idassetunload=A.idassetunload
	left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind
	WHERE exists 
	  (	select * from assetamortization AA 					
						where AA.idasset= A.idasset and AA.idpiece=A.idpiece
						AND AA.idassetunload is null AND AA.idassetload is null
						AND (AA.flag&1) <> 0				 /*  includi in buono scarico (o carico)*/					 
				)
End
			
--buoni di carico senza data

if (@codicesol='P843') 
BEGIN
	update assetload set ratificationdate= adate
    WHERE   ratificationdate is null 
			AND
			adate is not null    
END

if(@check_group in ('B','*')						)
Begin
	set @err='cespiti o accessori con buoni di carico senza data ratifica'
	set @sol='impostare la data ratifica uguale alla data contabile dei buoni, ove presente cod. P843'
	insert into #check(idasset, idpiece , lifestart ,codeinventory,ninventory, nassetacquire ,codeinv,
							codeassetloadkind , yassetload , nassetload , codeassetunloadkind , yassetunload , nassetunload , err,sol)
	SELECT 
		A.idasset, 	A.idpiece, A.lifestart, I.codeinventory,A.ninventory,A.nassetacquire,ITREE.codeinv,ALK.codeassetloadkind ,
		AL.yassetload 	,AL.nassetload 	,AUK.codeassetunloadkind,AU.yassetunload,AU.nassetunload ,@err,@sol 
	FROM  asset A
	join assetacquire B					on A.nassetacquire=B.nassetacquire
	join inventorytree ITREE			on B.idinv= ITREE.idinv
	LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory
	left outer join assetload AL		on AL.idassetload=B.idassetload
	left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind
	left outer join assetunload AU		on AU.idassetunload=A.idassetunload
	left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind
	WHERE 
		AL.idassetload is not null and AL.ratificationdate is null
End

--buoni di scarico senza data
if (@codicesol='X801') 
BEGIN
	update assetunload set adate= ratificationdate
    WHERE   adate is null 

	update assetunload set adate= CONVERT(datetime, '31-12-' + CONVERT(char(4),assetunload.yassetunload), 105)
    WHERE   adate is null 
			
END

if(@check_group in ('S','*')			)
Begin
	set @err='cespiti o accessori con buoni di scarico senza data contabile'
	set @sol='impostare la data del buono scarico alla data ratifica oppure al 31 12 dell''anno del buono cod. X801'
	-- CONVERT(datetime, '01-01-' + CONVERT(char(4),@year), 105)
	insert into #check(idasset, idpiece , lifestart ,codeinventory,ninventory, nassetacquire ,codeinv,
							codeassetloadkind , yassetload , nassetload , codeassetunloadkind , yassetunload , nassetunload , err,sol)
	SELECT 
		A.idasset, 	A.idpiece, A.lifestart, I.codeinventory,A.ninventory,A.nassetacquire,ITREE.codeinv,ALK.codeassetloadkind ,
		AL.yassetload 	,AL.nassetload 	,AUK.codeassetunloadkind,AU.yassetunload,AU.nassetunload ,@err,@sol
	FROM  asset A
	join assetacquire B					on A.nassetacquire=B.nassetacquire
	join inventorytree ITREE			on B.idinv= ITREE.idinv
	LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory
	left outer join assetload AL		on AL.idassetload=B.idassetload
	left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind
	left outer join assetunload AU		on AU.idassetunload=A.idassetunload
	left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind
	WHERE 
		AU.idassetunload is not null and AU.adate is null
End


--ammortamenti senza data e senza buono
if(@check_group in ('M','*')			)
Begin
	set @err='cespiti o accessori con ammortamenti non inclusi in buono di scarico e senza data contabile'
	insert into #check(idasset, idpiece , lifestart ,codeinventory,ninventory, nassetacquire ,codeinv,
							codeassetloadkind , yassetload , nassetload , codeassetunloadkind , yassetunload , nassetunload , err)
	SELECT 
		A.idasset, 	A.idpiece, A.lifestart, I.codeinventory,A.ninventory,A.nassetacquire,ITREE.codeinv,ALK.codeassetloadkind ,
		AL.yassetload 	,AL.nassetload 	,AUK.codeassetunloadkind,AU.yassetunload,AU.nassetunload ,@err 
	FROM  asset A
	join assetacquire B					on A.nassetacquire=B.nassetacquire
	join inventorytree ITREE			on B.idinv= ITREE.idinv
	LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory
	left outer join assetload AL		on AL.idassetload=B.idassetload
	left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind
	left outer join assetunload AU		on AU.idassetunload=A.idassetunload
	left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind
	WHERE 
		exists(select * from assetamortization AA 
					where AA.idasset=A.idasset and AA.idpiece=A.idpiece
						AND ((AA.flag&1)  = 0) 
						AND (AA.adate is null)
			)
End		

if(@check_group in ('C','*')			  )
Begin
--cespiti/accessori caricati in data successivo allo scarico
	set @err='cespiti/accessori caricati in data successivo allo scarico'
	--caso senza buono di carico
	insert into #check(idasset, idpiece , lifestart ,codeinventory,ninventory, nassetacquire ,codeinv,
							codeassetloadkind , yassetload , nassetload , codeassetunloadkind , yassetunload , nassetunload , err)
	SELECT 
		A.idasset, 	A.idpiece, A.lifestart, I.codeinventory,A.ninventory,A.nassetacquire,ITREE.codeinv,ALK.codeassetloadkind ,
		AL.yassetload 	,AL.nassetload 	,AUK.codeassetunloadkind,AU.yassetunload,AU.nassetunload ,@err 
	FROM  asset A
	join assetacquire B					on A.nassetacquire=B.nassetacquire
	join inventorytree ITREE			on B.idinv= ITREE.idinv
	LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory
	left outer join assetload AL		on AL.idassetload=B.idassetload
	left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind
	left outer join assetunload AU		on AU.idassetunload=A.idassetunload
	left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind
	WHERE 
	  ( (B.idassetload is null) AND (B.flag&1 = 0) )  --non includere in buono carico, e senza buono
	  AND
	  AU.idassetunload is not null
	  AND
	  year(AU.adate) < year(B.adate)

  
	--caso con buono di carico
	insert into #check(idasset, idpiece , lifestart ,codeinventory,ninventory, nassetacquire ,codeinv,
							codeassetloadkind , yassetload , nassetload , codeassetunloadkind , yassetunload , nassetunload , err)
	SELECT 
		A.idasset, 	A.idpiece, A.lifestart, I.codeinventory,A.ninventory,A.nassetacquire,ITREE.codeinv,ALK.codeassetloadkind ,
		AL.yassetload 	,AL.nassetload 	,AUK.codeassetunloadkind,AU.yassetunload,AU.nassetunload ,@err 
	FROM  asset A
	join assetacquire B					on A.nassetacquire=B.nassetacquire
	join inventorytree ITREE			on B.idinv= ITREE.idinv
	LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory
	left outer join assetload AL		on AL.idassetload=B.idassetload
	left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind
	left outer join assetunload AU		on AU.idassetunload=A.idassetunload
	left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind
	WHERE 
	  ( (B.idassetload is not null) AND (B.flag&1 <> 0) )  /* includi in buono carico, e con buono */
	  AND
		AU.idassetunload is not null
	  AND
	   year(AU.adate) < year(AL.adate)
End		  

if(@check_group in ('M','*')			  )
Begin
	--cespiti/accessori ammortizzati oltre il valore iniziale
	set @err='cespiti/accessori ammortizzati oltre il valore iniziale'
	insert into #check(idasset, idpiece , lifestart ,codeinventory,ninventory, nassetacquire ,codeinv,
							codeassetloadkind , yassetload , nassetload , codeassetunloadkind , yassetunload , nassetunload , err)
	SELECT 
		A.idasset, 	A.idpiece, A.lifestart, I.codeinventory,A.ninventory,A.nassetacquire,ITREE.codeinv,ALK.codeassetloadkind ,
		AL.yassetload 	,AL.nassetload 	,AUK.codeassetunloadkind,AU.yassetunload,AU.nassetunload ,@err 
	FROM  asset A
	join assetacquire B					on A.nassetacquire=B.nassetacquire
	join inventorytree ITREE			on B.idinv= ITREE.idinv
	join assetview_current ACURR	    on A.idasset= ACURR.idasset and A.idpiece=ACURR.idpiece
	LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory
	left outer join assetload AL		on AL.idassetload=B.idassetload
	left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind
	left outer join assetunload AU		on AU.idassetunload=A.idassetunload
	left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind
	WHERE 
	 ACURR.currentvalue<0
End
 



--cespiti scaricati con accessori non scaricati 

if (@codicesol='H614')
BEGIN

 --caso cespite principale con buono scarico
 update asset set idassetunload = (select idassetunload from asset A_MAIN where A_MAIN.idasset=asset.idasset and 
																A_MAIN.idpiece=1)
	where asset.idpiece > 1  /* accessorio*/ 
		  AND
		  asset.idassetunload is null AND ( (asset.flag & 1) <>0)  /* non ascaricato */
		  AND
		  (select idassetunload from asset A_MAIN where A_MAIN.idasset=asset.idasset and ( (A_MAIN.flag& 1)<>0)
															and A_MAIN.idpiece=1 ) IS NOT NULL

 --caso cespite principale senza buono scarico ma con flag 'non inserire in buono scarico
 update asset set flag = flag & 0xFE   /*  azzera il bit ' inserire in buono scarico dell'accessorio  */
	where asset.idpiece > 1  /* accessorio*/ 
		  AND
		  asset.idassetunload is null AND ( (asset.flag & 1) <>0)  /* non ascaricato */
		  AND
		  (select flag & 1  from asset A_MAIN where A_MAIN.idasset=asset.idasset AND A_MAIN.idpiece=1 ) =0

 
END

if(@check_group in ('S','*')			  )
Begin

	set @err='cespiti scaricati con accessori non scaricati'
	set @sol= 'includere anche gli accessori ancora non scaricati nel buono di scarico col cespite principale. cod.H614'
	insert into #check(idasset, idpiece , lifestart ,codeinventory,ninventory, nassetacquire ,codeinv,
							codeassetloadkind , yassetload , nassetload , codeassetunloadkind , yassetunload , nassetunload , err,sol)
	SELECT 
		A.idasset, 	A.idpiece, A.lifestart, I.codeinventory,A.ninventory,A.nassetacquire,ITREE.codeinv,ALK.codeassetloadkind ,
		AL.yassetload 	,AL.nassetload 	,AUK.codeassetunloadkind,AU.yassetunload,AU.nassetunload ,@err ,@sol
	FROM  asset A
	join assetacquire B					on A.nassetacquire=B.nassetacquire
	join inventorytree ITREE			on B.idinv= ITREE.idinv
	LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory
	left outer join assetload AL		on AL.idassetload=B.idassetload
	left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind
	left outer join assetunload AU		on AU.idassetunload=A.idassetunload
	left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind
	WHERE 
	 A.idpiece = 1              /* cespite */
	 AND	( A.idassetunload is not null OR ( (A.flag & 1) =0)  )   /* scaricato  */
	 AND EXISTS(	
		select * from asset ACC 
				where ACC.idasset=A.idasset and ACC.idpiece>1
					and 	( ACC.idassetunload is null AND ( (ACC.flag & 1) <>0)  )	/* non scaricato */		 
		) 
End

if(@check_group in ('S','*')			  )
Begin
	--cespiti scaricati con accessori scaricati in data successiva al cespite
	set @err='cespiti scaricati con accessori scaricati in data successiva al cespite'
	insert into #check(idasset, idpiece , lifestart ,codeinventory,ninventory, nassetacquire ,codeinv,
							codeassetloadkind , yassetload , nassetload , codeassetunloadkind , yassetunload , nassetunload , err)
	SELECT 
		A.idasset, 	A.idpiece, A.lifestart, I.codeinventory,A.ninventory,A.nassetacquire,ITREE.codeinv,ALK.codeassetloadkind ,
		AL.yassetload 	,AL.nassetload 	,AUK.codeassetunloadkind,AU.yassetunload,AU.nassetunload ,@err 	
	FROM  asset A
	join assetacquire B					on A.nassetacquire=B.nassetacquire
	join inventorytree ITREE			on B.idinv= ITREE.idinv
	LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory
	left outer join assetload AL		on AL.idassetload=B.idassetload
	left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind
	left outer join assetunload AU		on AU.idassetunload=A.idassetunload
	left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind
	WHERE 
	 A.idpiece = 1              /* cespite */
	 AND	( A.idassetunload is not null OR ( (A.flag & 1) =0)  )   /* scaricato  */
	 AND EXISTS(	
		select * from asset ACC 
			join assetunload ACC_U on ACC.idassetunload = ACC_U.idassetunload
				where  ACC.idasset=A.idasset and ACC.idpiece>1
						AND year(ACC_U.adate)  > year(AU.adate)
		) 
End

declare  @anno_prima_var int
select @anno_prima_var= min(yvar) from assetvar
if (@anno_prima_var is null) set @anno_prima_var = @ayear
--carichi cespiti ed accessori non in buono di carico ma da inserire in buono carico
if (@codicesol='Z754')
BEGIN
 
 update assetacquire set flag = flag & 0xFE /* non inserire in buono carico */
 where 
	 ( idassetload is  null )  /* non in buono carico */
	  AND
	 ( (flag & 1) <>0 )
	 AND 
	 ( (flag & 2) = 0) /* nuova acquisizione, ossia non posseduto */
	 AND 
	 YEAR(adate) < @anno_prima_var
END

if(@check_group in ('C','B','*')			  )
Begin
	set @err='carichi cespiti ed accessori nuove acquisizioni non in buono di carico ma da inserire in buono carico'
	set @sol='marcare i carichi come ''da non inserire in un buono carico'', ma attenzione: usare solo se PREGRESSI cod.Z754'
	insert into #check(idasset, idpiece , lifestart ,codeinventory,ninventory, nassetacquire ,codeinv,
							codeassetloadkind , yassetload , nassetload , codeassetunloadkind , yassetunload , nassetunload , err,sol)
	SELECT 
		A.idasset, 	A.idpiece, A.lifestart, I.codeinventory,A.ninventory,A.nassetacquire,ITREE.codeinv,ALK.codeassetloadkind ,
		AL.yassetload 	,AL.nassetload 	,AUK.codeassetunloadkind,AU.yassetunload,AU.nassetunload ,@err ,@sol
	FROM  asset A
	join assetacquire B					on A.nassetacquire=B.nassetacquire
	join inventorytree ITREE			on B.idinv= ITREE.idinv
	LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory
	left outer join assetload AL		on AL.idassetload=B.idassetload
	left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind
	left outer join assetunload AU		on AU.idassetunload=A.idassetunload
	left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind
	WHERE 
	  ( B.idassetload is  null )  /* non in buono carico */
	  AND
	  ( (B.flag & 1) <>0 )
	  AND 
	  ( (B.flag & 2) = 0) /* nuova acquisizione, ossia non posseduto */
End



--cespiti ed accessori senza data inizio esistenza
if (@codicesol = 'J699')
BEGIN
 update asset set lifestart = (select COALESCE(B.adate,AL.adate,AL.ratificationdate) 
									from assetacquire B 	
									left outer join assetload AL    on AL.idassetload= B.idassetload
									WHERE B.nassetacquire = asset.nassetacquire
							  )
				WHERE 
						lifestart is null
						and 	( idassetunload is null AND ( (flag & 1) <>0)  )  /* ancora in carico */
						AND (select COALESCE(B.adate,AL.adate,AL.ratificationdate) 
									from 	assetacquire B 
									left outer join    assetload AL  on AL.idassetload= B.idassetload
									WHERE B.nassetacquire = asset.nassetacquire
							  ) IS NOT NULL
END

if(@check_group in ('C','S','*'))
Begin
	set @err='cespiti ed accessori senza data inizio esistenza, ancora in carico'
	set @sol='valorizzare la data inizio esistenza in base al carico od al buono di carico ove presente. cod. J699'
	insert into #check(idasset, idpiece , lifestart ,codeinventory,ninventory, nassetacquire ,codeinv,
							codeassetloadkind , yassetload , nassetload , codeassetunloadkind , yassetunload , nassetunload , err,sol)
	SELECT 
		A.idasset, 	A.idpiece, A.lifestart, I.codeinventory,A.ninventory,A.nassetacquire,ITREE.codeinv,ALK.codeassetloadkind ,
		AL.yassetload 	,AL.nassetload 	,AUK.codeassetunloadkind,AU.yassetunload,AU.nassetunload ,@err ,@sol

	FROM  asset A
	join assetacquire B					on A.nassetacquire=B.nassetacquire
	join inventorytree ITREE			on B.idinv= ITREE.idinv
	LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory
	left outer join assetload AL		on AL.idassetload=B.idassetload
	left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind
	left outer join assetunload AU		on AU.idassetunload=A.idassetunload
	left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind
	WHERE 
	  A.lifestart is null
	  and 	( A.idassetunload is null AND ( (A.flag & 1) <>0)  )
End

--cespiti/accessori in carico con un valore di ammortamento non corretto (complessivamente, non anno per anno)
--devo calcolare, per ogni class.inventariale e per ogni età, la somma degli ammortamenti che sarebbero dovuti essere applicati in 
-- base all'età 
--poi per ogni bene il valore attuale ed il valore teorico che avrebbe dovuto avere con un piano di ammortamento corretto
-- ed infine segnalare i beni che hanno un valore teorico diverso da quello attuale

--calcola per ogni class.inventariale e per ogni età il totale ammortamenti da applicare in base a quell'età
-- se per un class.inventariale ci sono ammortamenti "per anno", non sono valutati ammortamenti "senza anno"


if(@check_group in ('I','M','*'))
Begin

		create table #all_amm (
			idinv int,
			amortizationquota float,
			eta_min int,
			eta_max int,
			valuemin decimal(19,2),
			valuemax decimal(19,2)
		) 

				
		insert into #all_amm (idinv, eta_min,eta_max,valuemin,valuemax,amortizationquota)
		SELECT C.idinv, 
			tr.age,	tr.agemax,tr.valuemin,tr.valuemax,
			-ISNULL(t4.amortizationquota,ISNULL(t3.amortizationquota,ISNULL(t2.amortizationquota,t1.amortizationquota)))
		from inventorytree C
		  
			LEFT OUTER JOIN inventorytreelink IL1  
					ON IL1.idchild = C.idinv AND IL1.nlevel  = 1 
			LEFT OUTER JOIN inventorytreelink IL2  
					ON IL2.idchild = C.idinv  AND IL2.nlevel = 2
			LEFT OUTER JOIN inventorytreelink IL3 
					ON IL3.idchild = C.idinv  AND IL3.nlevel = 3 
			LEFT OUTER JOIN inventorytreelink IL4  
					ON IL4.idchild = C.idinv  AND IL4.nlevel = 4 
			LEFT OUTER JOIN inventorysortingamortizationyear t1
				ON t1.idinv = IL1.idparent AND t1.ayear = @ayear
			LEFT OUTER JOIN inventorysortingamortizationyear t2
				ON t2.idinv = IL2.idparent  AND t2.ayear = @ayear
			LEFT OUTER JOIN inventorysortingamortizationyear t3
				ON t3.idinv = IL3.idparent AND t3.ayear = @ayear
			LEFT OUTER JOIN inventorysortingamortizationyear t4
				ON t4.idinv = IL4.idparent AND t4.ayear = @ayear 
			LEFT OUTER JOIN inventoryamortization tr
				ON tr.idinventoryamortization = 
				ISNULL(t4.idinventoryamortization,ISNULL(t3.idinventoryamortization,
				ISNULL(t2.idinventoryamortization,t1.idinventoryamortization)))
			where 
				(C.idinv NOT IN (SELECT  IT.paridinv FROM   inventorytree IT WHERE  (IT.paridinv IS NOT NULL))) /* foglia */
				AND
				ISNULL(t4.amortizationquota,ISNULL(t3.amortizationquota,ISNULL(t2.amortizationquota,t1.amortizationquota))) < 0
				AND tr.active='S'
				AND  ((tr.flag & 2)<>0)



		--attenzione: se è tutto null potrebbe stare bene, perché si potrebbero usare gli ammortamenti senza età



		if(@check_group in ('I','*'))
		Begin
			--classificazioni aventi dei buchi nel piano degli ammortamenti
			--Attenzione: non scatta se tutto null, perché potrebbero voler ammortizzare "senza età", è una cosa VOLUTA
			set @err='classificazioni aventi dei buchi TEMPORALI nel piano degli ammortamenti'
			set @sol='correggere il piano degli ammortamenti'
			insert into #check(codeinv , err,sol)
			SELECT 
				ITREE.codeinv ,@err ,@sol
			FROM  inventorytree ITREE			
			WHERE 
			  exists (select * from #all_amm S 
							where S.idinv=ITREE.idinv
									AND isnull(S.eta_min,0)>2
									AND NOT EXISTS(select * from #all_amm S2 
														where S2.idinv=ITREE.idinv AND isnull(S2.eta_max,99)= S.eta_min-1
												   )
					 )
			  AND (ITREE.idinv NOT IN (SELECT     IT.paridinv FROM   inventorytree IT WHERE (IT.paridinv IS NOT NULL))) /* foglia */ 
			  
			 		 
			set @err='classificazioni aventi dei buchi negli IMPORTI nel piano degli ammortamenti'
			set @sol='correggere il piano degli ammortamenti'
			insert into #check(codeinv , err,sol)
			SELECT 
				ITREE.codeinv ,@err ,@sol
			FROM  inventorytree ITREE			
			WHERE 
			  exists (select * from #all_amm S 
							where S.idinv=ITREE.idinv
									AND isnull(S.valuemin,0)>0
									AND NOT EXISTS(select * from #all_amm S2 
														where S2.idinv=ITREE.idinv AND isnull(S2.valuemax,0)= S.valuemin
												   )
					 )
			  AND (ITREE.idinv NOT IN (SELECT     IT.paridinv FROM   inventorytree IT WHERE (IT.paridinv IS NOT NULL))) /* foglia */ 
				   		 
					
			set @err='classificazioni aventi dei buchi negli IMPORTI nel piano degli ammortamenti'
			set @sol='correggere il piano degli ammortamenti'
			insert into #check(codeinv , err,sol)
			SELECT 
				ITREE.codeinv ,@err ,@sol
			FROM  inventorytree ITREE			
			WHERE 
			  NOT EXISTS(select * from #all_amm S  where S.idinv=ITREE.idinv AND S.valuemax is null)
			  AND EXISTS(select * from #all_amm S  where S.idinv=ITREE.idinv )
			  AND (ITREE.idinv NOT IN (SELECT     IT.paridinv FROM   inventorytree IT WHERE (IT.paridinv IS NOT NULL))) /* foglia */ 

					

			--classificazioni aventi sovrapposizioni nel piano degli ammortamenti
			--Attenzione: non scatta se tutto null, perché potrebbero voler ammortizzare "senza età", è una cosa VOLUTA
			set @err='classificazioni sovrapposizioni nel piano degli ammortamenti'
			set @sol='correggere il piano degli ammortamenti'
			insert into #check(codeinv , err,sol)
			SELECT 
				ITREE.codeinv ,@err ,@sol
			FROM  inventorytree ITREE			
			WHERE 
			  exists (select * from #all_amm S 
							where S.idinv=ITREE.idinv
									AND EXISTS(select * from #all_amm S2 
														where S2.idinv=ITREE.idinv 
														   AND isnull(S2.eta_min,0)>= isnull(S.eta_min,0)
														   AND isnull(S2.eta_min,0)<= isnull(S.eta_max,99)	
														   AND  ( ( isnull(S2.valuemin,0)> isnull(S.valuemin,0)
																	  AND (S.valuemax is null OR isnull(S2.valuemin,0)< S.valuemax)
																   )
																   OR
																   ( isnull(S.valuemin,0)> isnull(S2.valuemin,0)
																	  AND (S2.valuemax is null OR isnull(S.valuemin,0)<  S2.valuemax)
																   )
																)
															AND /* non sono la stessa cosa  */
															 ( (isnull(s2.eta_min,0)<>isnull(s.eta_min,0)) OR
															   (isnull(s2.eta_max,99)<>isnull(s.eta_max,99)) OR
															   (isnull(s2.valuemin,0)<>isnull(s.valuemin,0)) OR
															   (isnull(s2.valuemax,-1)<>isnull(s.valuemax,-1))
															  )
												   )
					 )
			  AND (ITREE.idinv NOT IN (SELECT     IT.paridinv FROM   inventorytree IT WHERE (IT.paridinv IS NOT NULL))) /* foglia */ 
			 

			--classificazioni miste con e senza eta
			set @err='classificazioni con piano di ammortamento misto con e senza eta'
			set @sol='correggere il piano degli ammortamenti'
			insert into #check(codeinv , err,sol)
			SELECT 
				ITREE.codeinv ,@err ,@sol
			FROM  inventorytree ITREE			
			WHERE 
			  exists (select * from #all_amm S 
							where S.idinv=ITREE.idinv AND S.eta_min is null AND S.eta_max is null
									AND EXISTS(select * from #all_amm S2 
														where S2.idinv=ITREE.idinv 
														   AND (S2.eta_min is not null OR  S2.eta_max is not null)	
												   )
					 )
			  AND (ITREE.idinv NOT IN (SELECT     IT.paridinv FROM   inventorytree IT WHERE (IT.paridinv IS NOT NULL))) /* foglia */ 
				     


			--categorie con classificazioni senza corrispondenti piani di amm.
			set @err='categorie con classificazioni senza corrispondenti piani di amm.'
			set @sol='correggere il piano degli ammortamenti se non si tratta di libri o immobili o terreni'
			insert into #check(codeinv , err,sol)
			SELECT 
				distinct IPAR.codeinv ,@err ,@sol
			FROM  inventorytree ITREE			
			  join inventorytreelink IL on IL.idchild=ITREE.idinv AND IL.nlevel=1
			  join inventorytree IPAR ON IL.idparent= IPAR.idinv
			WHERE 
				(ITREE.idinv NOT IN (SELECT     IT.paridinv FROM   inventorytree IT WHERE (IT.paridinv IS NOT NULL))) /* foglia */ 
			  AND
				not exists (select * from #all_amm S  where S.idinv=ITREE.idinv)
		End		  

		if(@check_group in ('M','*'))	
		Begin		

			create table #sum_amm (
				idinv int,
				sum_quota float,
				valuemin decimal(19,2),
				valuemax decimal(19,2),
				eta int
			) 
			declare @curr_eta int
			set @curr_eta=1
			while (@curr_eta<=50) 
			BEGIN
						 insert into #sum_amm(idinv,sum_quota,valuemin,valuemax,eta)
						  select Itree.idinv,
								isnull(A.amortizationquota,0)+ isnull(S.sum_quota,0),A.valuemin,A.valuemax,
								@curr_eta
						  from inventorytree Itree
						  left outer join #all_amm A on A.idinv = Itree.idinv 
										AND   @curr_eta >= isnull(A.eta_min,0)    AND	   @curr_eta <= isnull(A.eta_max,99)
						  left outer join #sum_amm S on S.idinv = Itree.idinv 
													AND S.eta= @curr_eta-1 
													AND isnull(S.valuemin,0)= isnull(A.valuemin,0) 
													AND isnull(S.valuemax,-1) = isnull(A.valuemax,-1)
													
						   where        
							   (ITREE.idinv NOT IN (SELECT     IT.paridinv FROM   inventorytree IT WHERE (IT.paridinv IS NOT NULL))) /* foglia */ 
							   
						 set @curr_eta= @curr_eta+1  
			END


			update #sum_amm set sum_quota=1  where sum_quota>1







			--Attenzione: non scatta se è tutto null visto che la somma restituisce null. E' una cosa VOLUTA.
			set @err='classificazioni aventi una somma di ammortamenti negli anni minore del 100%'
			set @sol='correggere il piano degli ammortamenti'
			insert into #check(codeinv ,err,sol)
			SELECT 
				ITREE.codeinv ,@err ,@sol
			FROM  #all_amm A	
				join inventorytree ITREE on A.idinv=ITREE.idinv		
			WHERE 
			   ((SELECT MAX(S.sum_quota ) from #sum_amm S where S.idinv=ITREE.idinv 
								AND isnull(S.valuemin,0)= isnull(A.valuemin,0) 
										AND isnull(S.valuemax,-1) = isnull(A.valuemax,-1)
						)) < 0.99999
				  					
											



			/*
			select I.codeinv,#all_amm.* from #all_amm join inventorytree I on #all_amm.idinv=I.idinv
			select I.codeinv,#sum_amm.* from #sum_amm join inventorytree I on #sum_amm.idinv=I.idinv
			*/

			--per i cespiti ancora in carico: controllo se ammortizzati a dovere
			set @err='cespiti e accessori in carico ma non coerentemente ammortizzati'
			set @sol='effettuare nuovi ammortamenti o correggerli'
			insert into #check(idasset, idpiece , lifestart ,codeinventory,ninventory, nassetacquire ,codeinv,
									codeassetloadkind , yassetload , nassetload , codeassetunloadkind , yassetunload , nassetunload , err,sol)
			SELECT 
			/*
			  isnull ( (SELECT SUM(CONVERT(DECIMAL(19,2),
													ROUND(isnull(AA.amortizationquota,0)*isnull(AA.assetvalue,0),2)
												)) from assetamortization AA
									LEFT OUTER JOIN assetunload AU  ON  AA.idassetunload = AU.idassetunload
											where 
										AA.idasset=A.idasset and AA.idpiece=A.idpiece 
									  AND
									  ( ((AA.flag & 1 = 0) 	AND YEAR(AA.adate)<=@ayear AND AA.adate is not null) 
										OR 
										((AA.flag & 1 <> 0)    AND YEAR(AU.adate)<=@ayear AND AU.adate is not null)
				      				  )			
				      				  -- AND AA.amortizationquota<0
								)
								,0),
				- ACURR.start,
				
			 isnull( (select top 1 S.sum_quota from #sum_amm S where S.idinv=B.idinv 
											AND S.eta=  1+(@ayear - YEAR(A.lifestart)) 
											AND (S.valuemin is null OR S.valuemin< ACURR.start)
											AND (S.valuemax is null OR S.valuemax>=ACURR.start)
							  )
							,0),
				ACURR.start,
				A.lifestart,
				1+(@ayear - YEAR(A.lifestart)),
				*/
				A.idasset, 	A.idpiece, A.lifestart, I.codeinventory,A.ninventory,A.nassetacquire,ITREE.codeinv,ALK.codeassetloadkind ,
				AL.yassetload 	,AL.nassetload 	,AUK.codeassetunloadkind,AU.yassetunload,AU.nassetunload ,@err ,@sol
			FROM  asset A
			join assetacquire B					on A.nassetacquire=B.nassetacquire
			join inventorytree ITREE			on B.idinv= ITREE.idinv
			join assetview_current ACURR	    on A.idasset= ACURR.idasset and A.idpiece=ACURR.idpiece
			LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory
			left outer join assetload AL		on AL.idassetload=B.idassetload
			left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind
			left outer join assetunload AU		on AU.idassetunload=A.idassetunload
			left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind
			WHERE 
			 ACURR.is_loaded='S' AND ACURR.is_unloaded='N'
			 AND ABS( isnull ( (SELECT SUM(AA.amortizationquota) from assetamortization AA
									LEFT OUTER JOIN assetunload AU  ON  AA.idassetunload = AU.idassetunload
											where 
										AA.idasset=A.idasset and AA.idpiece=A.idpiece 
									  AND
									  ( ((AA.flag & 1 = 0) 	AND YEAR(AA.adate)<=@ayear AND AA.adate is not null) 
										OR 
										((AA.flag & 1 <> 0)    AND YEAR(AU.adate)<=@ayear AND AU.adate is not null)
				      				  )			
				      				  --AND  AA.amortizationquota<0
								)
						,0)
						+
					 isnull( (select top 1 S.sum_quota from #sum_amm S where S.idinv=B.idinv 
											AND S.eta=  1+(@ayear - YEAR(A.lifestart)) 
											AND (S.valuemin is null OR S.valuemin< ACURR.start)
											AND (S.valuemax is null OR S.valuemax>=ACURR.start)
							  )
							,0)

					)>0.00001
			 AND NOT (  
								isnull ( (SELECT SUM(CONVERT(DECIMAL(19,2),
													ROUND(isnull(AA.amortizationquota,0)*isnull(AA.assetvalue,0),2)
												)) from assetamortization AA
									LEFT OUTER JOIN assetunload AU  ON  AA.idassetunload = AU.idassetunload
											where 
										AA.idasset=A.idasset and AA.idpiece=A.idpiece 
									  AND
									  ( ((AA.flag & 1 = 0) 	AND YEAR(AA.adate)<=@ayear AND AA.adate is not null) 
										OR 
										((AA.flag & 1 <> 0)    AND YEAR(AU.adate)<=@ayear AND AU.adate is not null)
				      				  )			
				      				  -- AND AA.amortizationquota<0
								)
								,0)= - ACURR.start
								AND
								 isnull( (select  top 1 S.sum_quota from #sum_amm S where S.idinv=B.idinv 
											AND S.eta=  1+(@ayear - YEAR(A.lifestart)) 
											AND (S.valuemin is null OR S.valuemin< ACURR.start)
											AND (S.valuemax is null OR S.valuemax>=ACURR.start)
							  )
							,0)=1
					) 
				AND exists(select * from #all_amm where #all_amm.idinv = B.idinv)
					  

			drop table #sum_amm
		End
	
	drop table #all_amm
End


DECLARE @nomedipartimento varchar(500)
SET  @nomedipartimento  = ISNULL( (SELECT top 1 paramvalue from
    generalreportparameter where idparam='DenominazioneDipartimento' 
    and  (ISNULL(start, {d '1900-01-01'}) = {d '1900-01-01'} or year(start) <= @ayear) 
    and  (ISNULL(stop, {d '2079-06-06'}) = {d '2079-06-06'}  or year(stop) >= @ayear)
    order by ISNULL(stop, {d '2079-06-06'}) desc
    ),'Manca Cfg. Parametri Tutte le stampe')


IF (@unified='S')
BEGIN
 
      SELECT idasset , idpiece , lifestart , codeinventory , ninventory , codeinv , nassetacquire ,
				codeassetloadkind , yassetload , nassetload , codeassetunloadkind , yassetunload , nassetunload ,
				err , sol , @nomedipartimento as department
        FROM #check
END
ELSE
BEGIN
        SELECT idasset , idpiece , lifestart , codeinventory , ninventory , codeinv , nassetacquire ,
				codeassetloadkind , yassetload , nassetload , codeassetunloadkind , yassetunload , nassetunload ,
				err , sol 
        FROM #check

END

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

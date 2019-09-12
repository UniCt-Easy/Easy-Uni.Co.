if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_verbale_consegna_beni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_verbale_consegna_beni]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE [rpt_verbale_consegna_beni]
(
	@ayear int,
	@idinventory int,
	@startninventory int,
	@stopninventory int,
	@nassetload int,
	@idman int,
	@datebegin datetime,
	@dateend datetime
)
AS BEGIN

--- exec rpt_verbale_consegna_beni 2003, 1, 96000, 96080, null, null, null, null

if (@datebegin is null)
set @datebegin = {d '1900-01-01'}

if (@dateend is null)
set @dateend = {d '2079-01-01'}

CREATE TABLE #asset
(
	nassetload int,
	description varchar(150),
	adate smalldatetime,	
	operationorder int,
	kind varchar(50),
	idinventory int,
	startnumber int,
	number decimal (19,2),
	nassetacquire int,
	idinv int,
	assetdescription varchar(150),
	idlastlocation int,
	lastlocationdate datetime,
	location varchar(800),--> ubicazioni concatenate
	idman int,
	doc varchar(35),
	docdate smalldatetime,
	enactment varchar(150),
	enactmentdate smalldatetime,
	idasset int,
	idsubman int,
	assetloadkind varchar(50)
)

INSERT INTO #asset(
	idasset,
	nassetload,	adate,	doc,docdate,enactment,enactmentdate,
	operationorder,	kind,	idinventory,
	startnumber,	number,	nassetacquire,	
	idinv,	assetdescription,	idlastlocation, lastlocationdate,	idman,
	idsubman, assetloadkind
	)
SELECT
	asset.idasset,
	assetload.nassetload, assetload.adate,	assetload.doc,	assetload.docdate,	assetload.enactment,assetload.enactmentdate,
	1,	'Carico bene',
	assetacquire.idinventory,	
	asset.ninventory,	--startnumber 
	1, -- era assetacquire.number,	ma non serviva a nulla	
	assetacquire.nassetacquire,
	assetacquire.idinv,	assetacquire.description,
	(SELECT TOP 1 l.idlocation FROM assetlocation l WHERE l.idasset = asset.idasset and (l.start is null or l.start between @datebegin and @dateend) order by start desc),-->prende solo la più recente
	(SELECT TOP 1 l.start FROM assetlocation l WHERE l.idasset = asset.idasset and (l.start is null or l.start between @datebegin and @dateend) order by start desc),
	R.idman,
	(SELECT TOP 1 s.idmanager FROM assetsubmanager s WHERE s.idasset = asset.idasset and (s.start is null or s.start between @datebegin and @dateend) order by start desc),
	assetloadkind.description
FROM asset  
JOIN assetacquire on assetacquire.nassetacquire = asset.nassetacquire
JOIN assetload on assetload.idassetload = assetacquire.idassetload
JOIN assetloadkind on assetloadkind.idassetloadkind = assetload.idassetloadkind
LEFT OUTER JOIN manager R ON R.idman = (select top 1 idman from assetmanager where idasset=asset.idasset and (start is null or start between @datebegin and @dateend) order by start desc)-->prende solo la più recente
WHERE  asset.idpiece=1		
	AND assetacquire.idinventory= @idinventory
	AND assetload.yassetload = @ayear
	AND (assetload.nassetload = @nassetload OR @nassetload is null)
	AND (asset.ninventory >= @startninventory OR @startninventory is null)
	AND (asset.ninventory <= @stopninventory OR @stopninventory is null)
	AND (R.idman = @idman OR @idman IS NULL)
	
	 

INSERT INTO #asset(
	idasset,
	nassetload,	adate,	doc,docdate,enactment,enactmentdate,
	operationorder,	kind,	idinventory,	
	startnumber, 	number,	nassetacquire,	
	idinv, assetdescription,	idlastlocation,	lastlocationdate,idman,
	idsubman, assetloadkind
)
SELECT
	asset.idasset,
	assetload.nassetload,	assetload.adate,	assetload.doc,	assetload.docdate,	assetload.enactment,assetload.enactmentdate,
	2,	'Carico accessorio',
	assetacquire.idinventory,	
	assetmain.ninventory,	1, --era assetacquire.number,	
	assetacquire.nassetacquire,	
	assetacquire.idinv, assetacquire.description,
	(SELECT TOP 1 l.idlocation FROM assetlocation l WHERE l.idasset = asset.idasset and (l.start is null or l.start between @datebegin and @dateend) order by start desc),-->prende solo la più recente
	(SELECT TOP 1 l.start FROM assetlocation l WHERE l.idasset = asset.idasset and (l.start is null or l.start between @datebegin and @dateend) order by start desc),
	R.idman,
	(SELECT TOP 1 s.idmanager FROM assetsubmanager s WHERE s.idasset = asset.idasset and (s.start is null or s.start between @datebegin and @dateend) order by start desc),
	assetloadkind.description
FROM  asset  
JOIN asset as assetmain ON asset.idasset=assetmain.idasset
JOIN assetacquire on assetacquire.nassetacquire = asset.nassetacquire
JOIN assetload on assetload.idassetload = assetacquire.idassetload
JOIN assetloadkind on assetloadkind.idassetloadkind = assetload.idassetloadkind
JOIN inventory on assetacquire.idinventory = inventory.idinventory
LEFT OUTER JOIN manager R ON R.idman = (select top 1 idman from assetmanager where idasset=asset.idasset and (start is null or start between @datebegin and @dateend) order by start desc)-->prende solo la più recente
JOIN inventorykind 	ON inventorykind.idinventorykind = inventory.idinventorykind
WHERE asset.idpiece>1		
	AND assetacquire.idinventory= @idinventory
	AND assetload.yassetload = @ayear
	AND (assetload.nassetload = @nassetload OR @nassetload is null)
	AND assetmain.idpiece=1
	AND (assetmain.ninventory >= @startninventory OR @startninventory is null)
	AND (assetmain.ninventory <= @stopninventory OR @stopninventory is null)
	AND (R.idman = @idman OR @idman IS NULL)

 

create table #assetlocation (
	location varchar(800),
	datalocation varchar(800),
	idasset int
)
insert into #assetlocation(location, datalocation,idasset)
select distinct
	' Ubicazione: ' + location.description,
	case 
		when start is null then ''
		else CHAR(13) + ' Data inizio:' + convert(varchar(4),day(assetlocation.start))+'/'+convert(varchar(2),month(assetlocation.start))+'/'+convert(varchar(4),year(assetlocation.start)) 
	end,
	#asset.idasset
FROM #asset
join assetlocation on assetlocation.idasset = #asset.idasset
JOIN location 	ON location.idlocation = assetlocation.idlocation
where assetlocation.start is null or assetlocation.start between @datebegin and @dateend

 
DECLARE @idasset int
DECLARE @location varchar(400)
DECLARE @datalocation varchar(400)
-- Concatena tutte le ubicazioni per mostrale tutte nel report. 
DECLARE cursore CURSOR FORWARD_ONLY for 
	SELECT location, idasset, datalocation FROM #assetlocation
		OPEN cursore
	FETCH NEXT FROM cursore 
	INTO @location, @idasset, @datalocation
	WHILE (@@fetch_status=0) BEGIN
	
	UPDATE 	#asset set
	  location = isnull(location,'') + @datalocation + @location   + '; '
	 WHERE idasset = @idasset
		FETCH NEXT FROM cursore 
		INTO @location, @idasset,@datalocation
	END
CLOSE cursore
DEALLOCATE cursore


declare @oldcount int
declare @newcount int

set @oldcount = 0
select @newcount=  count(*)  from #asset

--set @oldcount = @newcount

while (@oldcount<>@newcount) begin
	--select * from #asset

	set @oldcount=@newcount
	update #asset set number= #asset.number+Asucc.number from #asset
		join #asset Asucc on #asset.nassetload = Asucc.nassetload
				and #asset.assetdescription=Asucc.assetdescription
				and #asset.idinv = ASucc.idinv
				and #asset.idinventory = ASucc.idinventory
				and #asset.kind = ASucc.kind
				and #asset.adate = ASucc.adate
				and isnull(#asset.idman,0) = isnull(ASucc.idman,0)
				and isnull(#asset.idlastlocation,0) = isnull(ASucc.idlastlocation,0)
				and Asucc.startnumber = #asset.startnumber+#asset.number
		left outer join #asset APrev on #asset.nassetload = APrev.nassetload
				and #asset.assetdescription=APrev.assetdescription
				and #asset.idinv = APrev.idinv
				and #asset.idinventory = APrev.idinventory
				and #asset.kind = APrev.kind
				and #asset.adate = APrev.adate
				and isnull(#asset.idman,0) = isnull(APrev.idman,0)
				and isnull(#asset.idlastlocation,0) = isnull(APrev.idlastlocation,0)
				and #asset.startnumber = APrev.startnumber+APrev.number
	where  APREV.startnumber is null
 

	delete from #asset where exists (
		 select * from #asset par  where  #asset.idinventory=par.idinventory and  #asset.kind=par.kind and 
						#asset.startnumber > par.startnumber and
						#asset.startnumber < par.startnumber + par.number
		)

	select @newcount= count(*) from #asset
end

 
SELECT 
	#asset.nassetload,	
	inventoryagency.idinventoryagency,	
	inventoryagency.description as inventoryagency,
	inventorykind.idinventorykind,	
	inventorykind.description as inventorykind ,		
	isnull(#asset.lastlocationdate, #asset.adate) as adate,	
	#asset.doc,	
	#asset.docdate,	
	#asset.enactment,
	#asset.enactmentdate,
	operationorder,	
	kind,
	#asset.idinv,	inventory.codeinventory,	inventorytree.description as descrizioneclassif,	
	inventorytree.codeinv,	
	assetdescription, 
	#asset.idlastlocation,	
	#asset.location,
	#asset.idman,	
	manager.title as manager,
	ISNULL(#asset.number, 1) as 'number' ,
	#asset.startnumber as aq_startnumber,
	#asset.idsubman,
	submanager.title as submanager,
	#asset.assetloadkind
FROM #asset
JOIN inventory			on #asset.idinventory = inventory.idinventory
JOIN inventoryagency	ON inventoryagency.idinventoryagency = inventory.idinventoryagency
JOIN inventorykind		ON inventorykind.idinventorykind = inventory.idinventorykind
LEFT OUTER JOIN inventorytree 		ON inventorytree.idinv = #asset.idinv
LEFT OUTER JOIN manager  			ON manager.idman = #asset.idman
LEFT OUTER JOIN manager  submanager			ON submanager.idman = #asset.idsubman
ORDER BY #asset.nassetload, #asset.startnumber, #asset.operationorder
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


 

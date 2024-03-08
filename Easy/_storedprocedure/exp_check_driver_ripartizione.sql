
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_check_driver_ripartizione]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_check_driver_ripartizione]
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

-- setuser 'amm'
-- setuser 'amministrazione'
-- exec exp_check_driver_ripartizione 2023, '7' 
 
CREATE PROCEDURE exp_check_driver_ripartizione
(
	@ayear int,
	@exp_kind varchar(1)
	-- C:
		-- 1) Che non contenga le classificazioni configurate nell'anno corrente in config.idsorkind 1, 2, 3
		-- 2) Se i nodi non esistono
		-- 3) Se non sono foglie ecc, 
		-- 4) Se sono scaduti o fuori range (start e stop)
		-- 6) Tutte le incoerenze sulle classificazioni -- al momento non la mostriamo
		-- 7) Driver disattivi ma utilizzati nell'esercizio
	-- P:
		-- 5) La somma delle percentuali di ripartizione diverso da 100
)
AS 
BEGIN

	declare @idsorkind1 int
	declare @idsorkind2 int
	declare @idsorkind3 int
	
	select 
		@idsorkind1 = idsortingkind1,
		@idsorkind2 = idsortingkind2,
		@idsorkind3 = idsortingkind3
	from config where ayear = @ayear

	create table #driver
	(
		costpartitioncode varchar(50),
		title varchar(200),
		idsor1 int,
		codesorkind1 varchar(20),
		sorkind1 varchar(50),
		sorkind1_inyear varchar(1),
		sortcode1 varchar(50),
		description1 varchar(200),
		idsor1_exist varchar(1),
		idsor1_lastlevel varchar(1),
		idsor1_activeyear varchar(1),
		idsor2 int,
		codesorkind2 varchar(20),
		sorkind2 varchar(50),
		sorkind2_inyear varchar(1),
		sortcode2 varchar(50),
		description2 varchar(200),
		idsor2_exist varchar(1),
		idsor2_lastlevel varchar(1),
		idsor2_activeyear varchar(1),
		idsor3 int,
		codesorkind3 varchar(20),
		sorkind3 varchar(50),
		sorkind3_inyear varchar(1),
		sortcode3 varchar(50),
		description3 varchar(200),
		idsor3_exist varchar(1),
		idsor3_lastlevel varchar(1),
		idsor3_activeyear varchar(1)
	)

-- 1) Che non contenga le classificazioni configurate nell'anno corrente in config.idsorkind 1, 2, 3
if @exp_kind = '1'
begin
	
	insert into #driver
	(
		costpartitioncode
		,title
		,codesorkind1
		,sorkind1
		,sorkind1_inyear
		,sortcode1
		,description1
		,codesorkind2
		,sorkind2
		,sorkind2_inyear
		,sortcode2
		,description2
		,codesorkind3
		,sorkind3
		,sorkind3_inyear
		,sortcode3
		,description3
	)
	select 
		c.costpartitioncode,-- as [Cod. Ripartizione],
		c.title,-- as [Denominazione],

		-- Classificazione 1
		(select codesorkind from sortingkind where idsorkind = s1.idsorkind),
		(select description from sortingkind where idsorkind = s1.idsorkind),
		-- 1)
		case
			when cd.idsor1 is null then null
			when isnull(s1.idsorkind, 0) = isnull(@idsorkind1, 0) then 'S'
			else 'N'
		end,-- as [Tipo Class. 1 configurata nell'anno],
		
		s1.sortcode,-- as [Codice Nodo 1],
		s1.description,-- as [Descrizione Nodo 1],

		-- Classificazione 2
		(select codesorkind from sortingkind where idsorkind = s2.idsorkind),
		(select description from sortingkind where idsorkind = s2.idsorkind),
		-- 1)
		case
			when cd.idsor2 is null then null
			when isnull(s2.idsorkind, 0) = isnull(@idsorkind2, 0) then 'S'
			else 'N'
		end,-- as [Tipo Class. 2 configurata nell'anno],

		s2.sortcode,-- as [Codice Nodo 2],
		s2.description,-- as [Descrizione Nodo 2],

		-- Classificazione 3
		(select codesorkind from sortingkind where idsorkind = s3.idsorkind),
		(select description from sortingkind where idsorkind = s3.idsorkind),
		-- 1)
		case
			when cd.idsor3 is null then null
			when isnull(s3.idsorkind, 0) = isnull(@idsorkind3, 0) then 'S'
			else 'N'
		end,-- as [Tipo Class. 3 configurata nell'anno],

		s3.sortcode,-- as [Codice Nodo 3],
		s3.description-- as [Descrizione Nodo 3],

	from costpartition c
	join costpartitiondetail cd on c.idcostpartition = cd.idcostpartition
	left join sorting s1 on isnull(cd.idsor1, 0) = isnull(s1.idsor, 0)
	left join sorting s2 on isnull(cd.idsor2, 0) = isnull(s2.idsor, 0)
	left join sorting s3 on isnull(cd.idsor3, 0) = isnull(s3.idsor, 0)
	where isnull(c.active, 'S') = 'S'

	select
		costpartitioncode as [Cod. Ripartizione]
		,title  as [Denominazione]
		,codesorkind1 as [Codice Tipo Rilevanza 1]
		,sorkind1 as [Descrizione Tipo Rilevanza 1]
		,sorkind1_inyear as [Tipo Rilevanza 1 configurata nell'anno]
		,sortcode1 as [Codice Class. 1]
		,description1 as [Descrizione Class. 1]
		,codesorkind2 as [Codice Tipo Rilevanza 2]
		,sorkind2 as [Descrizione Tipo Rilevanza 2]
		,sorkind2_inyear as [Tipo Rilevanza 2 configurata nell'anno]
		,sortcode2 as [Codice Class. 2]
		,description2 as [Descrizione Class. 2]
		,codesorkind3 as [Codice Tipo Rilevanza 3]
		,sorkind3 as [Tipo Rilevanza 3]
		,sorkind3_inyear as [Tipo Rilevanza 3 configurata nell'anno]
		,sortcode3 as [Codice Class. 3]
		,description3 as [Descrizione Class. 3]
	from #driver
	where 
		sorkind1_inyear = 'N' or
		sorkind2_inyear = 'N' or
		sorkind3_inyear = 'N'
	order by costpartitioncode

end

-- 2) Se i nodi non esistono
if @exp_kind = '2'
begin
	
	insert into #driver
	(
		costpartitioncode
		,title
		,codesorkind1
		,sorkind1
		,idsor1
		,sortcode1
		,description1
		,idsor1_exist
		,codesorkind2
		,sorkind2
		,idsor2
		,sortcode2
		,description2
		,idsor2_exist
		,codesorkind3
		,sorkind3
		,idsor3
		,sortcode3
		,description3
		,idsor3_exist
	)
	select 
		c.costpartitioncode,-- as [Cod. Ripartizione],
		c.title,-- as [Denominazione],

		-- Classificazione 1
		(select codesorkind from sortingkind where idsorkind = s1.idsorkind),
		(select description from sortingkind where idsorkind = s1.idsorkind),
		
		cd.idsor1, -- #idsor1
		s1.sortcode,-- as [Codice Nodo 1],
		s1.description,-- as [Descrizione Nodo 1],
		
		-- 2)
		case
			when cd.idsor1 is null then null
			when isnull(s1.idsor, 0) = isnull(cd.idsor1, 0) then 'S'
			else 'N'
		end,-- as [Nodo 1 esistente],
		
		-- Classificazione 2
		(select codesorkind from sortingkind where idsorkind = s2.idsorkind),
		(select description from sortingkind where idsorkind = s2.idsorkind),
		cd.idsor2,
		s2.sortcode,-- as [Codice Nodo 2],
		s2.description,-- as [Descrizione Nodo 2],
		
		-- 2)
		case
			when cd.idsor2 is null then null
			when isnull(s2.idsor, 0) = isnull(cd.idsor2, 0) then 'S'
			else 'N'
		end,-- as [Nodo 2 esistente],
		
		-- Classificazione 3
		(select codesorkind from sortingkind where idsorkind = s3.idsorkind),
		(select description from sortingkind where idsorkind = s3.idsorkind),
		cd.idsor3,
		s3.sortcode,-- as [Codice Nodo 3],
		s3.description,-- as [Descrizione Nodo 3],
		
		-- 2)
		case
			when cd.idsor3 is null then null
			when isnull(s3.idsor, 0) = isnull(cd.idsor3, 0) then 'S'
			else 'N'
		end-- as [Nodo 3 esistente],
		
	from costpartition c
	join costpartitiondetail cd on c.idcostpartition = cd.idcostpartition
	left join sorting s1 on isnull(cd.idsor1, 0) = isnull(s1.idsor, 0)
	left join sorting s2 on isnull(cd.idsor2, 0) = isnull(s2.idsor, 0)
	left join sorting s3 on isnull(cd.idsor3, 0) = isnull(s3.idsor, 0)
	where isnull(c.active, 'S') = 'S'

	select
		costpartitioncode as [Cod. Ripartizione]
		,title  as [Denominazione]
		,codesorkind1 as [Codice Tipo Rilevanza 1]
		,sorkind1 as [Descrizione Tipo Rilevanza 1]
		,idsor1 as [#idsor1 Inesistente]
		,sortcode1 as [Codice Class. 1]
		,description1 as [Descrizione Class. 1]
		,idsor1_exist as [Class. 1 esistente]
		,codesorkind2 as [Codice Tipo Rilevanza 2]
		,sorkind2 as [Descrizione Tipo Rilevanza 2]
		,idsor2 as [#idsor2 Inesistente]
		,sortcode2 as [Codice Class. 2]
		,description2 as [Descrizione Class. 2]
		,idsor2_exist as [Class. 2 esistente]
		,codesorkind3 as [Codice Tipo Rilevanza 3]
		,sorkind3 as [Descrizione Tipo Rilevanza 3]
		,idsor3 as [#idsor3 Inesistente]
		,sortcode3 as [Codice Class. 3]
		,description3 as [Descrizione Class. 3]
		,idsor3_exist as [Class. 3 esistente]
	from #driver
	where 
		idsor1_exist = 'N' or
		idsor2_exist = 'N' or
		idsor3_exist = 'N'
	order by costpartitioncode

end

-- 3) Se non sono foglie ecc,
if @exp_kind = '3'
begin
	
	insert into #driver
	(
		costpartitioncode
		,title
		,codesorkind1
		,sorkind1
		,sortcode1
		,description1
		,idsor1_lastlevel
		,codesorkind2
		,sorkind2
		,sortcode2
		,description2
		,idsor2_lastlevel
		,codesorkind3
		,sorkind3
		,sortcode3
		,description3
		,idsor3_lastlevel
	)
	select 
		c.costpartitioncode,-- as [Cod. Ripartizione],
		c.title,-- as [Denominazione],

		-- Classificazione 1
		(select codesorkind from sortingkind where idsorkind = s1.idsorkind),
		(select description from sortingkind where idsorkind = s1.idsorkind),
		
		s1.sortcode,-- as [Codice Nodo 1],
		s1.description,-- as [Descrizione Nodo 1],
				
		-- 3)
		case 
			when s1.idsor is null then null
			when exists (select * from sorting where paridsor = s1.idsor) then 'N'
			else 'S' 
		end,-- as [Ultimo Livello Nodo 1],
		
		-- Classificazione 2
		(select codesorkind from sortingkind where idsorkind = s2.idsorkind),
		(select description from sortingkind where idsorkind = s2.idsorkind),
		
		s2.sortcode,-- as [Codice Nodo 2],
		s2.description,-- as [Descrizione Nodo 2],
		
		-- 3)
		case 
			when s2.idsor is null then null
			when exists (select * from sorting where paridsor = s2.idsor) then 'N'
			else 'S' 
		end, -- as [Ultimo Livello Nodo 2],
		
		-- Classificazione 3
		(select codesorkind from sortingkind where idsorkind = s3.idsorkind),
		(select description from sortingkind where idsorkind = s3.idsorkind),
		
		s3.sortcode,-- as [Codice Nodo 3],
		s3.description,-- as [Descrizione Nodo 3],
		
		-- 3)
		case 
			when s3.idsor is null then null
			when exists (select * from sorting where paridsor = s3.idsor) then 'N'
			else 'S' 
		end-- as [Ultimo Livello Nodo 3],
		
	from costpartition c
	join costpartitiondetail cd on c.idcostpartition = cd.idcostpartition
	left join sorting s1 on isnull(cd.idsor1, 0) = isnull(s1.idsor, 0)
	left join sorting s2 on isnull(cd.idsor2, 0) = isnull(s2.idsor, 0)
	left join sorting s3 on isnull(cd.idsor3, 0) = isnull(s3.idsor, 0)
	where isnull(c.active, 'S') = 'S'

	select
		costpartitioncode as [Cod. Ripartizione]
		,title  as [Denominazione]
		,codesorkind1 as [Codice Tipo Rilevanza 1]
		,sorkind1 as [Descrizione Tipo Rilevanza 1]
		,sortcode1 as [Codice Class. 1]
		,description1 as [Descrizione Class. 1]
		,idsor1_lastlevel as [Ultimo Livello Class. 1]
		,codesorkind2 as [Codice Tipo Rilevanza 2]
		,sorkind2 as [Descrizione Tipo Rilevanza 2]
		,sortcode2 as [Codice Class. 2]
		,description2 as [Descrizione Class. 2]
		,idsor2_lastlevel as [Ultimo Livello Class. 2]
		,codesorkind3 as [Codice Tipo Rilevanza 3]
		,sorkind3 as [Descrizione Tipo Rilevanza 3]
		,sortcode3 as [Codice Class. 3]
		,description3 as [Descrizione Class. 3]
		,idsor3_lastlevel as [Ultimo Livello Class. 3]
	from #driver
	where 
		idsor1_lastlevel = 'N' or
		idsor2_lastlevel = 'N' or
		idsor3_lastlevel = 'N'
	order by costpartitioncode

end

-- 4) Se sono scaduti o fuori range (start e stop)
if @exp_kind = '4'
begin
	
	insert into #driver
	(
		costpartitioncode
		,title
		,codesorkind1
		,sorkind1
		,sortcode1
		,description1
		,idsor1_activeyear
		,codesorkind2
		,sorkind2
		,sortcode2
		,description2
		,idsor2_activeyear
		,codesorkind3
		,sorkind3
		,sortcode3
		,description3
		,idsor3_activeyear
	)
	select 
		c.costpartitioncode,-- as [Cod. Ripartizione],
		c.title,-- as [Denominazione],

		-- Classificazione 1
		(select codesorkind from sortingkind where idsorkind = s1.idsorkind),
		(select description from sortingkind where idsorkind = s1.idsorkind),
		
		s1.sortcode,-- as [Codice Nodo 1],
		s1.description,-- as [Descrizione Nodo 1],
		
		-- 4)
		case
			when cd.idsor1 is null then null
			when isnull(s1.start, @ayear) <= @ayear and isnull(s1.stop, @ayear) >= @ayear then 'S'
			else 'N'
		end, -- as [Nodo 1 Attivo nell'anno],

		-- Classificazione 2
		(select codesorkind from sortingkind where idsorkind = s2.idsorkind),
		(select description from sortingkind where idsorkind = s2.idsorkind),
		
		s2.sortcode,-- as [Codice Nodo 2],
		s2.description,-- as [Descrizione Nodo 2],
		
		-- 4)
		case
			when cd.idsor2 is null then null
			when isnull(s2.start, @ayear) <= @ayear and isnull(s2.stop, @ayear) >= @ayear then 'S'
			else 'N'
		end,-- as [Nodo 2 Attivo nell'anno],

		-- Classificazione 3
		(select codesorkind from sortingkind where idsorkind = s3.idsorkind),
		(select description from sortingkind where idsorkind = s3.idsorkind),
		
		s3.sortcode,-- as [Codice Nodo 3],
		s3.description,-- as [Descrizione Nodo 3],

		-- 4)
		case
			when cd.idsor3 is null then null
			when isnull(s3.start, @ayear) <= @ayear and isnull(s3.stop, @ayear) >= @ayear then 'S'
			else 'N'
		end-- as [Nodo 3 Attivo nell'anno]
	from costpartition c
	join costpartitiondetail cd on c.idcostpartition = cd.idcostpartition
	left join sorting s1 on isnull(cd.idsor1, 0) = isnull(s1.idsor, 0)
	left join sorting s2 on isnull(cd.idsor2, 0) = isnull(s2.idsor, 0)
	left join sorting s3 on isnull(cd.idsor3, 0) = isnull(s3.idsor, 0)
	where isnull(c.active, 'S') = 'S'

	select
		costpartitioncode as [Cod. Ripartizione]
		,title  as [Denominazione]
		,codesorkind1 as [Codice Tipo Rilevanza 1]
		,sorkind1 as [Descrizione Tipo Rilevanza 1]
		,sortcode1 as [Codice Class. 1]
		,description1 as [Descrizione Class. 1]
		,idsor1_activeyear as [Class. 1 Attivo nell'anno]
		,codesorkind2 as [Codice Tipo Rilevanza 2]
		,sorkind2 as [Descrizione Tipo Rilevanza 2]
		,sortcode2 as [Codice Class. 2]
		,description2 as [Descrizione Class. 2]
		,idsor2_activeyear as [Class. 2 Attivo nell'anno]
		,codesorkind3 as [Codice Tipo Rilevanza 3]
		,sorkind3 as [Descrizione Tipo Rilevanza 3]
		,sortcode3 as [Codice Class. 3]
		,description3 as [Descrizione Class. 3]
		,idsor3_activeyear as [Class. 3 Attivo nell'anno]
	from #driver
	where 
		idsor1_activeyear = 'N' or
		idsor2_activeyear = 'N' or
		idsor3_activeyear = 'N'
	order by costpartitioncode
end

-- 5) La somma delle percentuali di ripartizione diverso da 100
if @exp_kind = '5'
begin
	select
		c.costpartitioncode as [Cod. Ripartizione],
		c.title as [Denominazione],
		-- 5)
		concat(format(sum(cd.rate) * 100, 'N2'), ' %') as [% Totale]
	from costpartition c
	join costpartitiondetail cd on c.idcostpartition = cd.idcostpartition
	where c.kind = 'P' and c.active = 'S'
	group by c.idcostpartition, c.costpartitioncode, c.title, c.active
	having sum(cd.rate) <> 1
end

-- 7) Driver disattivi ma utilizzati nell'esercizio
if @exp_kind = '7'
begin
	select 
		c.costpartitioncode as [Cod. Ripartizione],
		c.title as [Denominazione],
		c.active as [Driver Attivo],
		'S' as [Driver Utilizzato in Scritture di esercizio]
	from costpartition c
	left join invoicedetail i on i.idcostpartition = c.idcostpartition
	left join entrydetailview e on e.idrelateddetail = 'inv§'+convert(varchar(10),i.idinvkind)+'§'+convert(varchar(10),i.yinv)+'§'+convert(varchar(10),i.ninv)+'§'+convert(varchar(10),i.rownum)
	where 
		isnull(c.active, 'S') = 'N' and 
		e.yentry = @ayear and
		e.idrelateddetail is not null and 
		e.idrelateddetail like 'inv%'
	group by 
		c.costpartitioncode,
		c.title,
		c.active

	union

	select 
		c.costpartitioncode as [Cod. Ripartizione],
		c.title as [Denominazione],
		c.active as [Driver Attivo],
		'S' as [Driver Utilizzato in Scritture di esercizio]
	from costpartition c
	left join mandatedetail i on i.idcostpartition = c.idcostpartition
	left join entrydetailview e on e.idrelateddetail = 'man§'+convert(varchar(10),i.idmankind)+'§'+convert(varchar(10),i.yman)+'§'+convert(varchar(10),i.nman)+'§'+convert(varchar(10),i.idgroup)
	where 
		isnull(c.active, 'S') = 'N' and 
		e.yentry = @ayear and
		e.idrelateddetail is not null and 
		e.idrelateddetail like 'man%' and
		e.idrelated  like 'inv%'
	group by 
		c.costpartitioncode,
		c.title,
		c.active

	union

	select 
		c.costpartitioncode as [Cod. Ripartizione],
		c.title as [Denominazione],
		c.active as [Driver Attivo],
		'S' as [Driver Utilizzato in Scritture di esercizio]
	from costpartition c
	left join mandatedetail i on i.idcostpartition = c.idcostpartition
	left join entrydetailview e on e.idrelateddetail = 'man§'+convert(varchar(10),i.idmankind)+'§'+convert(varchar(10),i.yman)+'§'+convert(varchar(10),i.nman)+'§'+convert(varchar(10),i.idgroup)
	where 
		isnull(c.active, 'S') = 'N' and 
		e.yentry = @ayear and
		e.idrelateddetail is not null and 
		e.idrelateddetail like 'man%' and
		e.idrelated  like 'man%'
	group by 
		c.costpartitioncode,
		c.title,
		c.active
	order by c.costpartitioncode
end

END 

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

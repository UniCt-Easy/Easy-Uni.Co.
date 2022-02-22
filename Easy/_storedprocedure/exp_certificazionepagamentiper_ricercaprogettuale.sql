
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


--setuser 'amministrazione'
if exists (select * from dbo.sysobjects where id = object_id(N'[exp_certificazionepagamentiper_ricercaprogettuale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_certificazionepagamentiper_ricercaprogettuale]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser 'amministrazione'
--setuser 'amm'

--exec exp_certificazionepagamentiper_ricercaprogettuale 2021, 13

CREATE procedure exp_certificazionepagamentiper_ricercaprogettuale( 
	@ayear int,
	/*@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null*/
	@idsorkind int
	) 
as begin
 

create table #siopeES (
	idsor int, 
	e_s  char(1)
)
declare @maxexpensephase varchar(50)
set @maxexpensephase  = ( select top 1 description from expensephase order by nphase desc )

DECLARE @idsorkindS int

create table #missprogr (
		idupb varchar(40),
		ymov int,
		nmov int,	
		codeupb varchar(50),
		title varchar(150),
		amount decimal(19,2),
		idsordescr varchar(100),
		npay int,
		sortcode varchar(100),
		descriptionsort varchar(200),
		cofogmpcode varchar(50),
		uesiopecode varchar(50),
		flagkind varchar(50),
		movdescription varchar(200),
		descriptionupb varchar(500),
		codemp varchar(500)
	)

-- COPIARE LA CLASSIFICAZIONE MISSIONI E PROGRAMMI DEGLI UPB UTILIZZATI
	create table #outputmissprog (
		idsorkind int,
		idsorsorting int, 		
		descriptions varchar(500), 
		descriptionkind varchar(150), 
		idsorupbsorting int, 
		idupb varchar(50), 
		quota decimal(19,6)
	)

-- VALIDA SOLTANTO PER IL 2018 E ANNI SUCCESSIVI
if (@ayear >= 2018)
begin

	SELECT  @idsorkindS = idsorkind FROM sortingkind  WHERE codesorkind ='SIOPE_U_18' 

	insert into #siopeES (idsor, e_s)
	select idsor, 's' from sorting
	where idsorkind = @idsorkindS
	and sortcode in (
	'1030207006','1030207007','2020201001','2020201002','2020109019','2020109999','2020109005','2020110009','2020109007','2020109016','2020201999','2020305001','2020306001','2020306999','2020101001','2020101003','2020401001','2020401003','2020103001',
	'2020103003','2020403001','2020107004','2020107999','2020407999','2020104001','2020105001','2020105002','2020105999','2020106001','2020404001','2020405001','2020405002','2020405999','2020406001','2020107001','2020407001','2020107002','2020107005',
	'2020407002','2020199001','2020103002','2020403002','2020104002','2020107004','2020107003','2020407003','2020407004','2020404002','2020302001','2020302002','2020111001','2020399001','2020103999','2020199002','2020199999','2020403999','2020499999','
	2020303001','2020304001','2020409999','2059999999')

	-- D: pagamenti con Siope compreso nell'insieme allegato e senza COFOG	
	insert into #missprogr (idupb, ymov, nmov, codeupb, title, amount, idsordescr, npay, sortcode, descriptionsort, cofogmpcode, uesiopecode, flagkind, movdescription, descriptionupb, codemp)
	SELECT
		U.idupb,
		I.ymov,
		I.nmov 'Num. Movimento',		
		U.codeupb 'Codice Upb',U.title 'Descrizione UPB',
		ES.amount 'Importo',
		CASE  WHEN TS.idsor IS NULL THEN  'Spesa Corrente'
							ELSE 'Investimento' 
		END 'Tipo Siope per Fabbisogno',
		P.npay 'Num. Mandato',
		S.sortcode 'Codice Siope',S.description 'Descrizione Siope', 
		U.cofogmpcode 'Cofog su UPB',  U.uesiopecode 'Codice UE su UPB',
		CASE WHEN (flagkind & 2) <> 0 THEN 'Ricerca' ELSE '' END 'Attività UPB',
 		@maxexpensephase +' n.'+ convert(varchar(10),I.nmov) +'. '+I.description 'Descrizione Movimento',
		UK.description 'Tipo UPB', 
		null--(select top 1 s2.sortcode+' - '+s2.description from Upbsorting US JOIN sorting S2  ON S2.idsor = US.idsor JOIN sortingkind SK ON Sk.idsorkind = S2.idsorkind 
		--	WHERE US.idupb = U.idupb and SK.description like '%Missioni%programm%' order by quota asc)  'Codice M/P DL.394/2017'
	FROM expense I
		join expenselast IL on I.idexp = IL.idexp
		join expenseyear IY on IL.idexp = IY.idexp
		JOIN upb U						ON IY.idupb = U.idupb
		left JOIN epupbkind uk ON uk.idepupbkind = u.idepupbkind
		JOIN expensesorted ES				ON ES.idexp = IY.idexp
		join sorting S on ES.idsor = S.idsor
		join payment P on IL.kpay = P.kpay
		left join #siopeES TS on TS.idsor = ES.idsor and TS.e_s='S'
	WHERE IY.ayear = @ayear
			AND S.idsorkind = @idsorkindS
			order by 1
--select * from #missprogr
--select * from #outputmissprog

End

-- VALIDA PER IL 2016 e 2017
if (@ayear =2016 or @ayear = 2017)
Begin
	SELECT  @idsorkindS = idsorkind FROM sortingkind  WHERE codesorkind ='07U_SIOPE' 

	insert into #siopeES (idsor, e_s)
	select idsor, 's' from sorting
	where idsorkind = @idsorkindS
	--and sortcode in ( <<elenco dei codiici siope preso dall'allegato 1 al DM facendo attenzione a non confondersi con quelli del 2018>>)
	and sortcode in ('2450','7111','7112','7114','7212','7214','7113',
			'7116','7213','7216','7115','7215','7117','7217','7118','7211','7218','7311','7313',
			'7315','7317','7319','7321','7323','7325','7327','7329','7331','7333')
	-- D: pagamenti con Siope compreso nell'insieme allegato e senza COFOG
	insert into #missprogr (idupb, ymov, nmov, codeupb, title, amount, idsordescr, npay, sortcode, descriptionsort, cofogmpcode, uesiopecode, flagkind, movdescription, descriptionupb, codemp)
	SELECT
		U.idupb,
		I.ymov as 'Esercizio',
		I.nmov as 'Num. Movimento',
		U.codeupb 'Codice Upb',U.title 'Descrizione UPB',
		ES.amount 'Importo',
		CASE  WHEN TS.idsor IS NULL THEN  'Spesa Corrente'
		ELSE 'Investimento' END 'Tipo Siope per Fabbisogno',
		P.npay 'Num. Mandato',
		S.sortcode 'Codice Siope',S.description 'Descrizione Siope', 
		U.cofogmpcode 'Cofog su UPB',  U.uesiopecode 'Codice UE su UPB',
		CASE WHEN (flagkind & 2) <> 0 THEN 'Ricerca' ELSE '' END 'Attività UPB',
 		@maxexpensephase +' n.'+ convert(varchar(10),I.nmov) +'. '+I.description 'Descrizione Movimento',
		UK.description 'Tipo UPB', 
		null--(select top 1 s2.sortcode+' - '+s2.description from Upbsorting US JOIN sorting S2  ON S2.idsor = US.idsor JOIN sortingkind SK ON Sk.idsorkind = S2.idsorkind 
		--	WHERE US.idupb = U.idupb and SK.description like '%Missioni%programm%' order by quota asc)  'Codice M/P DL.394/2017'
	FROM expense I
		join expenselast IL on I.idexp = IL.idexp
		join expenseyear IY on IL.idexp = IY.idexp
		JOIN upb U						ON IY.idupb = U.idupb
		left JOIN epupbkind uk ON uk.idepupbkind = u.idepupbkind
		JOIN expensesorted ES				ON ES.idexp = IY.idexp
		join sorting S on ES.idsor = S.idsor
		join payment P on IL.kpay = P.kpay
		left join #siopeES TS on TS.idsor = ES.idsor and TS.e_s='S'
	WHERE IY.ayear = @ayear
			AND S.idsorkind = @idsorkindS
			order by 1

End

	if (@idsorkind is not null)
	begin		
		insert into #outputmissprog(idsorkind, idsorsorting, descriptions, descriptionkind, idsorupbsorting, idupb, quota)
		select DISTINCT S.idsorkind,S.idsor, S.sortcode + '-' + S.description, SK.description, US.idsor, US.idupb, US.quota 
		from upbsorting US
		join sorting S ON US.idsor = S.idsor
		join sortingkind  SK on S.idsorkind = S.idsorkind
		join #missprogr ON #missprogr.idupb = US.idupb
		where S.idsorkind = @idsorkind and SK.description like '%MISSION%'
	end




	select 
		#missprogr.ymov as 'Esercizio',
		#missprogr.nmov as 'Num. movimento',
		#missprogr.movdescription as 'Descrizione movimento',
		#missprogr.npay as 'Num. mandato',
		#missprogr.idupb as 'ID UPB',
		#missprogr.codeupb as 'Codice Upb',
		#missprogr.title as 'Descrizione Upb',		
		#missprogr.amount as 'Importo corrente', 
		--#outputmissprog.descriptionkind as 'Tipo Class. UPB',
		#outputmissprog.descriptions as 'Codice M/P DL.394/2017',
		(#outputmissprog.quota * #missprogr.amount) as 'Importo ripartito MP', 
		(#outputmissprog.quota * 100) as 'Quota', 		
		#missprogr.idsordescr as 'Tipo siope per fabbisogno',		
		#missprogr.sortcode as 'Codice Siope',
		#missprogr.descriptionsort as 'Descrizione Siope',
		#missprogr.cofogmpcode as 'Cofog su UPB',
		#missprogr.uesiopecode as 'Codice UE su UPB',
		#missprogr.flagkind as 'Attività UPB',		
		#missprogr.descriptionupb as 'Tipo UPB'
	from #missprogr
	left join #outputmissprog on #missprogr.idupb = #outputmissprog.idupb

drop table #siopeES
drop table #missprogr
drop table #outputmissprog

end

GO


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



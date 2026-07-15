/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

/*--------------------------------------------------------------------------------------------------------------------------

			Questa stored procedure legge dal DB utunitus e scrive nella tabella  "entrydetailfact" del db  >> DataWareHouse_ENTE. <<				 
			!!! ATTENZIONE !!! Prima di eseguire/installare questa SP sul Database di Easy verificare il nome corretto del database DataWareHouse_ENTE._XXXX
			Questa sp prevede che già esistano le tabelle sul DB DataWareHouse_ENTE._

---------------------------------------------------------------------------------------------------------------------------*/

--USE [unitus_easy]	

-- setuser'amministrazione'
-- exec compute_dw_entrydetailfact

--select * from DataWareHouse_ENTE.dbo.entrydetailfact where number = 3438 and ayear = 2023
--select top 1000 * from DataWareHouse_ENTE.dbo.entrydetailfact;


if exists (select * from dbo.sysobjects where id = object_id(N'compute_dw_entrydetailfact') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure compute_dw_entrydetailfact
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


Create PROCEDURE compute_dw_entrydetailfact

AS
  BEGIN
  
	DELETE DataWareHouse_ENTE.dbo.entrydetailfact;

 	       
      DECLARE @esercizioini INT
	  IF MONTH(GETDATE()) > 5 -- Siamo a Giugno, quindi è stato chiuso l'esercizio precedunitus
		SET @esercizioini= YEAR(GETDATE())-6 -- Prendo soltanto due esercizi chiusi e l'anno in corso
	  ELSE					-- Siamo nei primi mesi dell'anno, quindi NON è stato chiuso l'esercizio precedunitus
		SET @esercizioini= YEAR(GETDATE())-7 -- Prendo due esercizi chiusi, l'anno precedunitus non ancora chiuso e l'anno in corso

	create table #sorkindyear(
		idsorkind1 int,
		idsorkind2 int,
		idsorkind3 int,
		ayear int)

	insert into #sorkindyear(idsorkind1, idsorkind2, idsorkind3, ayear)
	select idsortingkind1, idsortingkind2, idsortingkind3, ayear
	from config
	where ayear >= @esercizioini
		and ( idsortingkind1 is not null OR idsortingkind2 is not null OR  idsortingkind3 is not null)


declare @codesorkind01 varchar(20)
declare @sortingkind01 varchar(50)

select @codesorkind01 = codesorkind ,
		@sortingkind01 = description
		from sortingkind where idsorkind = (select idsorkind01 from uniconfig)

----------------------------------------------------------------------------------------------------------------------------------------
--- 									PARTE BUDGET ----------------------------------------------------------------------------------- 
----------------------------------------------------------------------------------------------------------------------------------------

     -- VARIAZIONI NON INIZIALI (tutte, escluse : "Iniziale" e "Non operativa")
    INSERT INTO DataWareHouse_ENTE.dbo.entrydetailfact 
    (
        ayear,
        number,
        rownumber,
        description ,
		detaildescription,
		idacc,
        idupb,
        idsor1,idsor2,idsor3,
		adate,
        amount, --budgetvar,
		rowkind,
		idsor01 ,
		idsorkind1, idsorkind2, idsorkind3,
		codesorkind01, sortingkind01
    )
    SELECT yvar,
           nvar,
           rownum,
           variationdescription,description,
           idacc,
           idupb,
			idsor1,idsor2,idsor3,
			adate,
           isnull(amount, 0) ,
		   'PrevisioneVariazione',
		   idsor01 ,
		   K.idsorkind1 ,		K.idsorkind2 ,		K.idsorkind3,
		    @codesorkind01, @sortingkind01
    FROM accountvardetailview
		left outer join #sorkindyear K on accountvardetailview.yvar = K.ayear
    WHERE variationkind NOT IN ( 5, 6 ) -- not "Iniziale" e "Non operativa", inserisce:	1	Normale, 2	Ripartizione, 3	Assestamento, 4	Storno
          AND idaccountvarstatus = 5
 		  AND yvar >= @esercizioini 


    -- VARIAZIONI  INIZIALI (solo Iniziali)
    INSERT INTO DataWareHouse_ENTE.dbo.entrydetailfact 
    (
        ayear,
        number,
        rownumber,
         description ,
		detaildescription,
		idacc,
        idupb,
        idsor1,idsor2,idsor3,
		adate,
        amount, --budgetvar,
		rowkind,
		idsor01,
		idsorkind1, idsorkind2, idsorkind3,
		codesorkind01, sortingkind01
    )

    SELECT yvar,
           nvar,
           rownum,
           variationdescription,description,
           idacc,
           idupb,
			idsor1,idsor2,idsor3,
			adate,
           ISNULL(amount, 0) ,
		   'PrevisioneIniziale',
		   idsor01,
		   K.idsorkind1 ,		K.idsorkind2 ,		K.idsorkind3,
			@codesorkind01, @sortingkind01
       FROM accountvardetailview
	   left outer join #sorkindyear K on accountvardetailview.yvar = K.ayear
    WHERE variationkind = 5				-->	Iniziale
          AND idaccountvarstatus = 5
          AND yvar > @esercizioini


----------------------------------------------------------------------------------------------------------------------------------------
--- 									PARTE SCRITTURE	 ----------------------------------------------------------------------------------- 
----------------------------------------------------------------------------------------------------------------------------------------



create table #dettaglioscrittura(
	yentry	smallint,
	number int, -- nentry
	rownumber int,-- ndetail
	adate date,
	amount	decimal(19,2),
	idacc	varchar	(38),
	idreg	int	,
	idsor1	int	,idsorkind1 int,
	idsor2	int	,idsorkind2 int,
	idsor3	int	,idsorkind3 int,
	idupb	varchar	(36),
	description	varchar	(150),
	detaildescription	varchar	(400),
	rowkind varchar(150),
	idsor01 int
)
insert into #dettaglioscrittura(
	yentry	,
	number		,
	rownumber		,
	adate,
	amount	,
	idacc	,
	idreg		,
	idsor1		,
	idsor2		,
	idsor3		,
	idupb	,
	description	,
	detaildescription	,
	rowkind ,
	idsor01)
select 
	e.yentry	,
	e.nentry	,
	d.ndetail	,
	e.adate,
	d.amount	,
	d.idacc	,
	d.idreg	,
	d.idsor1		, 
	d.idsor2		, 
	d.idsor3		, 
	d.idupb	,
	e.description,
	d.description,

	accountkind.description,
	e.idsor01
from entrydetail d
    JOIN entry e
    ON e.nentry = d.nentry AND e.yentry = d.yentry
    JOIN account a
		ON d.idacc = a.idacc AND d.yentry = a.ayear
	LEFT OUTER JOIN accountkind	(NOLOCK)	
		ON accountkind.idaccountkind = A.idaccountkind
where  e.yentry >= @esercizioini
        AND e.identrykind NOT IN ( 6, 7, 11, 12 )

UPdate #dettaglioscrittura
set rowkind = 'Costi'
where rowkind = 'Amm.to e Svalut.ne' 

-- insert into tabella dei fatti
insert into  DataWareHouse_ENTE.dbo.entrydetailfact(
	ayear,
	number, --nentry,
	rownumber, --ndetail,
	amount ,
	adate,
	idacc	,
	idreg ,
	idsor1 ,
	idsor2 ,
	idsor3 ,
	Key_idsor1 ,
	Key_idsor2 ,
	Key_idsor3 ,
	idupb ,
	description 	,
	detaildescription,
	rowkind ,
	idsorkind1 ,
	idsorkind2 ,
	idsorkind3,
	codesorkind01, sortingkind01,
	idsor01
)

	select 
		yentry	,
		E.number,--E.nentry		,
		E.rownumber, --E.ndetail		,
		E.amount	,
		E.adate,
		E.idacc	,
		E.idreg		,
		E.idsor1		,
		E.idsor2		,
		E.idsor3		,
		CASE WHEN E.idsor1 IS NOT NULL THEN CAST(yentry AS varchar(4)) + RIGHT('000000' + CAST(E.idsor1 AS varchar(6)), 6) ELSE NULL END AS KEY_idsor1,
		CASE WHEN E.idsor2 IS NOT NULL THEN CAST(yentry AS varchar(4)) + RIGHT('000000' + CAST(E.idsor2 AS varchar(6)), 6) ELSE NULL END AS KEY_idsor2,
		CASE WHEN E.idsor3 IS NOT NULL THEN CAST(yentry AS varchar(4)) + RIGHT('000000' + CAST(E.idsor3 AS varchar(6)), 6) ELSE NULL END AS KEY_idsor3,
		E.idupb	,
		E.description	,
		E.detaildescription	,
		E.rowkind,
		K.idsorkind1 ,
		K.idsorkind2 ,
		K.idsorkind3,
		 @codesorkind01, @sortingkind01,
		 idsor01
	from #dettaglioscrittura E
		left outer join #sorkindyear K on E.yentry = K.ayear


		DROP TABLE #sorkindyear
		DROP TABLE #dettaglioscrittura


 END; 


 
 
  GO

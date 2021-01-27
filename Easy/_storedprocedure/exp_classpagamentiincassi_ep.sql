
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_classpagamentiincassi_ep]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_classpagamentiincassi_ep]
GO
 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE    PROCEDURE [exp_classpagamentiincassi_ep]
(
	@ayear smallint,
	@date datetime,
	@part char(1),
	@suppressifblank char(1)
)
AS
BEGIN
--	exec exp_classpagamentiincassi_ep 2016, {d '2016-09-20'}, 'X', 'N'
DECLARE @maxphaseexpense tinyint
SELECT @maxphaseexpense = MAX(nphase) FROM expensephase

DECLARE @maxphaseincome tinyint
SELECT @maxphaseincome= MAX(nphase) FROM incomephase

DECLARE @E_SIOPE INT
DECLARE @U_SIOPE INT


DECLARE @codesorkind_siopespese varchar(20)
DECLARE @codesorkind_siopeentrate varchar(20)

IF (@ayear<= 2017) 
	BEGIN
		 SET @codesorkind_siopeentrate = '07E_SIOPE'
		 SET @codesorkind_siopespese   = '07U_SIOPE'
	END
ELSE
	BEGIN
		 SET @codesorkind_siopeentrate = 'SIOPE_E_18'
		 SET @codesorkind_siopespese   = 'SIOPE_U_18'
	END


SELECT @E_SIOPE = idsorkind from sortingkind where codesorkind = @codesorkind_siopeentrate
SELECT @U_SIOPE = idsorkind from sortingkind where codesorkind = @codesorkind_siopespese
	
	CREATE TABLE #situazione(
		idsor int,
		part char(1),
		payment decimal(19,2),
		proceeeds decimal(19,2),
		costi decimal(19,2),
		ricavi decimal(19,2)
	)  

-- Pagamenti 
if (@part ='S' or @part ='X')
Begin
	INSERT INTO #situazione(part, idsor,  payment) 
	select 'S', ES.idsor,  sum(HPV.curramount)
	from expensesorted ES
	join sorting S
		on S.idsor = ES.idsor
	join historypaymentview HPV
		on ES.idexp = HPV.idexp
	where S.idsorkind = @U_SIOPE
			and HPV.ymov = @ayear
			AND HPV.competencydate <= @date
	group by ES.idsor

	-- COSTI
	INSERT INTO #situazione(part,idsor, costi)
	select'S', AC.idsor, sum(amount) 
	FROM entry E
	join  entrydetail ED
		on E.yentry = ED.yentry and E.nentry = ED.nentry
	join account A
		on ED.idacc = A.idacc
	join accmotive M
		on M.idaccmotive = ED.idaccmotive
	join accmotivesorting AC
		on AC.idaccmotive = M.idaccmotive
	join sorting S
		on S.idsor = AC.idsor	
	where  S.idsorkind = @U_SIOPE
		and E.yentry = @ayear
		and E.adate <= @date
		AND E.identrykind not in (6,7, 11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO E APERTURA
		and ( (A.flagaccountusage & 64)<> 0				-- Conto di costo	 
			OR		( A.flagaccountusage & 256)<> 0	)	--  Immobilizzazioni
			
	group by  AC.idsor
End

-- Incassi 
if (@part ='E' or @part ='X')
Begin
	INSERT INTO #situazione(part, idsor, proceeeds)  
	select 'E', ES.idsor,  sum(HPV.curramount)
	from incomesorted ES
	join sorting S
		on S.idsor = ES.idsor	
	join historyproceedsview HPV
		on ES.idinc = HPV.idinc
	where S.idsorkind = @E_SIOPE
			and HPV.ymov = @ayear
			AND HPV.competencydate <= @date
	group by ES.idsor

	-- RICAVI
	INSERT INTO #situazione(part, idsor, ricavi)
	select 'E', AC.idsor, sum(amount) 
	FROM entry E
	join  entrydetail ED
		on E.yentry = ED.yentry and E.nentry = ED.nentry
	join account A
		on ED.idacc = A.idacc
	join accmotive M
		on M.idaccmotive = ED.idaccmotive
	join accmotivesorting AC
		on AC.idaccmotive = M.idaccmotive
	join sorting S
		on S.idsor = AC.idsor	
	where  S.idsorkind = @E_SIOPE
		and E.yentry = @ayear
		and E.adate <= @date
		AND E.identrykind not in (6,7, 11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO E APERTURA
		and (( A.flagaccountusage & 128)<> 0) -- Conto di ricavo
	group by  AC.idsor
End


if (@suppressifblank ='S')
Begin
	INSERT INTO #situazione(part,		idsor,		payment,		proceeeds,		costi,		ricavi	)
	SELECT 'S',idsor,0,0,0,0
	FROM sortingusable
	WHERE idsorkind = @U_SIOPE
	AND (start IS NULL OR start <= @ayear) 
	AND (stop IS NULL OR stop >= @ayear)
	AND NOT EXISTS(SELECT idsor FROM #situazione WHERE #situazione.idsor = sortingusable.idsor)

	INSERT INTO #situazione(part,		idsor,		payment,		proceeeds,		costi,		ricavi	)
	SELECT 'E',idsor,0,0,0,0
	FROM sortingusable
	WHERE idsorkind = @E_SIOPE
	AND (start IS NULL OR start <= @ayear) 
	AND (stop IS NULL OR stop >= @ayear)
	AND NOT EXISTS(SELECT idsor FROM #situazione WHERE #situazione.idsor = sortingusable.idsor)

End

select 
		T.part as 'E/S',
		S.sortcode as 'Cod.Class.',
		S.description as 'Classificazione',
		T.payment as 'Pagamenti',
		T.proceeeds as 'Incassi',
		T.costi as 'Costi',
		T.ricavi as 'Ricavi'
from #situazione T
join sorting S
	on T.idsor = S.idsor			
ORDER BY T.part,  S.sortcode

END

GO






SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

 

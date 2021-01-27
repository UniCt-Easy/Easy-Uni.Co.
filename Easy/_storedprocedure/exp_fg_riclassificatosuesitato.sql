
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_fg_riclassificatosuesitato]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_fg_riclassificatosuesitato]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE procedure exp_fg_riclassificatosuesitato(
	@idsorkindmaster int,--class origine
    	@idsorkindchild int,-- class destinazione
	@start datetime, 
	@stop datetime,
	@ayear smallint
) as 
begin
DECLARE @finexpensephase tinyint
DECLARE @finincomephase tinyint
SELECT @finexpensephase = expensefinphase, @finincomephase = incomefinphase FROM uniconfig

	SELECT 
		CASE banktransaction.kind 
			WHEN 'C' THEN 'Entrate' 
			WHEN 'D' THEN 'Spese' 
		END	as 'Tipo mov.',
		sortingkind.description as 'Tipo class.',
		SIRGS.sortcode as 'Codice class.', 
		SIRGS.description as 'Classificazione', 
		sum(banktransactionsorting.amount) as 'Importo',
		-- Previsione alla data
		ISNULL((select sum(FY.prevision * FS.quota) 
		from finyear FY	
		join finsorting FS
			on FY.idfin = FS.idfin
		where FY.ayear = @ayear
			AND FS.idsor = SIRGS.idsor),0)
		+
		ISNULL((select sum(FVD.amount * FS.quota)
		from finvar FV
		join finvardetail FVD
			ON FV.yvar = FVD.yvar
			AND FV.nvar = FVD.nvar
		join finsorting FS
			on FVD.idfin = FS.idfin
		where FS.idsor = SIRGS.idsor
			AND FV.adate <= @stop 
			AND FV.idfinvarstatus = 5),0)
		+
		-- Residui Spesa
		ISNULL((SELECT SUM(EY.amount * FS.quota)
		FROM expenseyear EY
		JOIN expense E
			ON E.idexp = EY.idexp AND EY.ayear = @ayear
		JOIN expensetotal ET
			ON ET.idexp = EY.idexp AND ET.ayear = EY.ayear
		JOIN finsorting FS
			ON EY.idfin = FS.idfin
		WHERE ((ET.flag & 1) <> 0) 
			AND E.nphase = @finexpensephase
			AND E.adate <= @stop
			AND FS.idsor = SIRGS.idsor
			AND banktransaction.kind = 'D'-- è un filtro in più, sarebbe sufficiente l'idsor che intrinsicamente è associato a entrate o a spese.
			),0)
		+
		-- Residui Entrata
		ISNULL((SELECT SUM(EY.amount * FS.quota)
		FROM incomeyear EY
		JOIN income E
			ON E.idinc = EY.idinc AND EY.ayear = @ayear
		JOIN incometotal ET
			ON ET.idinc = EY.idinc AND ET.ayear = EY.ayear
		JOIN finsorting FS
			ON EY.idfin = FS.idfin
		WHERE ((ET.flag & 1) <> 0) 
			AND E.nphase = @finincomephase
			AND E.adate <= @stop
			AND FS.idsor = SIRGS.idsor
			AND banktransaction.kind = 'C'
			),0)
		 as 'Previsione alla data '
	from banktransactionsorting 
	join banktransaction 
                on banktransaction.yban = banktransactionsorting.yban 
                and banktransaction.nban = banktransactionsorting.nban
	join sortingtranslation 
                on sortingtranslation.idsortingchild = banktransactionsorting.idsor 
	join sorting SIRGS 
                on SIRGS.idsor = sortingtranslation.idsortingmaster -- SIRGS
	join sortingkind 
                on sortingkind.idsorkind = SIRGS.idsorkind
	join sorting SIOPE 
                on SIOPE.idsor = sortingtranslation.idsortingchild -- SIOPE
	where banktransaction.transactiondate between @start and @stop
        	AND SIRGS.idsorkind = @idsorkindmaster
            AND SIOPE.idsorkind = @idsorkindchild
	group by banktransaction.kind, sortingkind.description, SIRGS.sortcode, SIRGS.description,
			SIRGS.idsorkind, SIRGS.idsor
	order by banktransaction.kind, sortingkind.description, SIRGS.sortcode
end




GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

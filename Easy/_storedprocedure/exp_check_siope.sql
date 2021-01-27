
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_check_siope]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_check_siope]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE procedure exp_check_siope(
	@ayear int,
	@kind char(1),		-- Expense / Income
	@userkind char(1)	-- D = dipartimento; A = amministrazione 
) as 
begin

DECLARE @iSIOPE INT
DECLARE @eSIOPE INT
DECLARE @iSIOPEtitle varchar(50)
DECLARE @eSIOPEtitle varchar(50)

IF (@userkind = 'A')
Begin
-- Amministrazione
	SELECT @iSIOPE = idsorkind, @iSIOPEtitle = description from sortingkind where codesorkind = '10E_MACROSIOPE_AMMIN'
	SELECT @eSIOPE = idsorkind, @eSIOPEtitle = description from sortingkind where codesorkind = '10S_MACROSIOPE_AMMIN'
end
Else
Begin
-- Dipartimento
	SELECT @iSIOPE = idsorkind, @iSIOPEtitle = description from sortingkind where codesorkind = '10E_MACROSIOPE_DIP'
	SELECT @eSIOPE = idsorkind, @eSIOPEtitle = description from sortingkind where codesorkind = '10S_MACROSIOPE_DIP'
End

DECLARE @minoplevel tinyint
SELECT @minoplevel = min(nlevel)
FROM finlevel
WHERE ayear = @ayear and (flag&2)<>0

CREATE TABLE #error (msg varchar(1000))

-- CONTROLLO N.1
INSERT INTO #error
SELECT 'La voce di bilancio Entrata: ' + F.codefin + ', pur avendo un valore di previsione, NON è stata classificata con alcun codice "' + @iSIOPEtitle + '"'
FROM fin F 
JOIN finyear FY
	ON F.idfin = FY.idfin
WHERE F.codefin NOT IN (SELECT Fcap.codefin
				FROM fin Fpar -- All
				JOIN finlink FLK 
					ON FLK.idparent = Fpar.idfin 
				JOIN finlink FLK2
					ON FLK2.idchild = FLK.idchild AND FLK2.nlevel = 3
				JOIN Fin Fcap
					ON Fcap.idfin = FLK2.idchild
				JOIN finyear FY2
					ON FY2.idfin = Fcap.idfin	
				JOIN finsorting FSp
					ON FSp.idfin = Fpar.idfin 
				JOIN sorting Sp
					ON Sp.idsor = FSp.idsor
				WHERE ISNULL(FY2.prevision,0) > 0
					AND Sp.idsorkind = @iSIOPE
					AND Fcap.nlevel = F.nlevel
					AND Fcap.idfin =  F.idfin)
 	AND ((F.flag&1) = 0) -- solo la parte Entrata
	AND ISNULL(FY.prevision,0) > 0 -- Potrebbero anche essere in finyear perchè hanno una var. a noi interessa solo se la previsione è >0
	AND FY.ayear = @ayear
	AND @kind = 'I'
	AND (F.flag & 16 =0)
	AND F.nlevel = @minoplevel
GROUP BY F.codefin

INSERT INTO #error
SELECT 'La voce di bilancio Spesa: ' + F.codefin + ', pur avendo un valore di previsione, NON è stata classificata con alcun codice "'+ @eSIOPEtitle +'"'
FROM fin F 
JOIN finyear FY
	ON F.idfin = FY.idfin
WHERE F.codefin NOT IN (SELECT Fcap.codefin
				FROM fin Fpar -- All
				JOIN finlink FLK 
					ON FLK.idparent = Fpar.idfin 
				JOIN finlink FLK2
					ON FLK2.idchild = FLK.idchild AND FLK2.nlevel = @minoplevel
				JOIN Fin Fcap
					ON Fcap.idfin = FLK2.idchild
				JOIN finyear FY2
					ON FY2.idfin = Fcap.idfin	
				JOIN finsorting FSp
					ON FSp.idfin = Fpar.idfin 
				JOIN sorting Sp
					ON Sp.idsor = FSp.idsor
				WHERE ISNULL(FY2.prevision,0) > 0
					AND Sp.idsorkind = @eSIOPE
					AND Fcap.nlevel = F.nlevel
					AND Fcap.idfin =  F.idfin)
 	AND ((F.flag&1) <> 0) -- solo la parte Spesa
	AND ISNULL(FY.prevision,0) > 0 -- Potrebbero anche essere in finyear perchè hanno una var. a noi interessa solo se la previsione è >0
	AND FY.ayear = @ayear
	AND @kind = 'E'
	AND F.nlevel = @minoplevel
GROUP BY F.codefin

-- CONTROLLO N.2
-- Sta prendendo tutto ciò che è classificato. Verifica se la SUM del class sul Macro Siope è < 100% , se la voce
-- è presente in FINYEAR (quindi parliamo di un capitolo) oppure in FINYEAR è presente un suo figlio, e quidi ci riferiamo alla categoria,
-- nel senso, la class. della catagoria, per cui esitse un figlio in FY con previsione, è < 100%.. 
INSERT INTO #error
SELECT 'La voce di bilancio Entrata: ' + F.codefin + ' non è stata interamente classificata con la Class. "' + @iSIOPEtitle + '"'
FROM fin F 
JOIN finsorting FS 
	ON FS.idfin = F.idfin
JOIN sorting S
    ON S.idsor = FS.idsor 
WHERE ((F.flag&1) = 0) -- solo la parte Entrata
	AND S.idsorkind = @iSIOPE
	AND @kind = 'I'
	AND EXISTS (SELECT * FROM finyear FY
				JOIN FINLINK Fp
					ON FY.idfin = Fp.idchild
				WHERE ISNULL(FY.prevision,0) > 0 AND (FY.idfin = F.idfin OR Fp.idparent = F.idfin)
				)
	AND F.ayear= @ayear
GROUP BY F.codefin
HAVING ISNULL( convert(decimal(19,2), round(SUM (FS.quota),2)),0) < 1

INSERT INTO #error
SELECT 'La voce di bilancio Spesa: ' + F.codefin + ' non è stata interamente classificata con la Class. "' + @eSIOPEtitle + '"'
FROM fin F 
JOIN finsorting FS 
	ON FS.idfin = F.idfin
JOIN sorting S
    ON S.idsor = FS.idsor 
WHERE ((F.flag&1) <> 0) -- solo la parte Spesa
	AND S.idsorkind = @eSIOPE
	AND @kind = 'E'
	AND EXISTS (SELECT * 
				FROM finyear FY
				JOIN FINLINK Fp
					ON FY.idfin = Fp.idchild
				WHERE ISNULL(FY.prevision,0) > 0 AND (FY.idfin = F.idfin OR Fp.idparent = F.idfin )
				)
	AND F.ayear= @ayear
GROUP BY F.codefin
HAVING ISNULL( convert(decimal(19,2), round(SUM (FS.quota),2)),0) < 1

-- CONTROLLO N.3
-- Sta prendendo tutto ciò che è classificato. Verifica se la SUM del class sul Macro Siope è < 100% , se la voce
-- è presente in FINYEAR (quindi parliamo di un capitolo) oppure in FINYEAR è presente un suo figlio, e quidi ci riferiamo alla categoria,
-- nel senso, la class. della catagoria, per cui esitse un figlio in FY con previsione, è < 100%.. 
INSERT INTO #error
SELECT 'La voce di bilancio Entrata: ' + F.codefin + ' è stata classificata con la Class. "' + @iSIOPEtitle + '" con una percentuale superiore a 100%'
FROM fin F 
JOIN finsorting FS 
	ON FS.idfin = F.idfin
JOIN sorting S
    ON S.idsor = FS.idsor 
WHERE ((F.flag&1) = 0) -- solo la parte Entrata
	AND S.idsorkind = @iSIOPE
	AND @kind = 'I'
	AND EXISTS (SELECT * FROM finyear FY
				JOIN FINLINK Fp
					ON FY.idfin = Fp.idchild
				WHERE ISNULL(FY.prevision,0) > 0 AND (FY.idfin = F.idfin OR Fp.idparent = F.idfin)
				)
	AND F.ayear= @ayear
GROUP BY F.codefin
HAVING ISNULL( convert(decimal(19,2), round(SUM (FS.quota),2)),0) > 1

INSERT INTO #error
SELECT 'La voce di bilancio Spesa: ' + F.codefin + ' è stata classificata con la Class. "' + @eSIOPEtitle + '" con una percentuale superiore a 100%'
FROM fin F 
JOIN finsorting FS 
	ON FS.idfin = F.idfin
JOIN sorting S
    ON S.idsor = FS.idsor 
WHERE ((F.flag&1) <> 0) -- solo la parte Spesa
	AND S.idsorkind = @eSIOPE
	AND @kind = 'E'
	AND EXISTS (SELECT * 
				FROM finyear FY
				JOIN FINLINK Fp
					ON FY.idfin = Fp.idchild
				WHERE ISNULL(FY.prevision,0) > 0 AND  (FY.idfin = F.idfin OR Fp.idparent = F.idfin)
				)
	AND F.ayear= @ayear
GROUP BY F.codefin
HAVING ISNULL( convert(decimal(19,2), round(SUM (FS.quota),2)),0) > 1

SELECT * FROM #error
ORDER BY msg

DROP TABLE #error
end



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


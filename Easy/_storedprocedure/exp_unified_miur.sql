
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_unified_miur]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_unified_miur]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE   PROCEDURE [exp_unified_miur] 
(
	@ayear int,
	@finpart char(1),
    @flagresearchagency char(1),
    @unified char(1)
)
AS BEGIN
-- @flagresearchagency :è visibile SOLO per le amministrazioni perchè è legato al consolidamento
-- @unified : consolidamento dei dati

-- [exp_unified_miur] 2011, 'S', 'S','S'
IF (@unified <> 'S')
BEGIN
        CREATE TABLE #error_notunified (Errore varchar(1000))
        INSERT INTO #error_notunified (Errore)
        EXEC  exp_check_miur @ayear, @finpart,@unified
        IF (SELECT COUNT(*) FROM #error_notunified) > 0
                BEGIN
                	SELECT * FROM #error_notunified
                	RETURN
                END

        EXEC exp_miur @ayear, @finpart
        RETURN

END
 
CREATE TABLE #unified (
	sortcode varchar(20),
        description varchar(200),
	tot_Imp decimal(19,2),
	tot_Imp_Comp decimal(19,2), 
	tot_Pag decimal(19,2),
	tot_Pag_Comp decimal(19,2),

	tot_Imp_A decimal(19,2),
	tot_Imp_Comp_A decimal(19,2), 
	tot_Pag_A decimal(19,2),
	tot_Pag_Comp_A decimal(19,2),

	tot_Imp_C decimal(19,2),
	tot_Imp_Comp_C decimal(19,2), 
	tot_Pag_C decimal(19,2),
	tot_Pag_Comp_C decimal(19,2),

	tot_Imp_D decimal(19,2),
	tot_Imp_Comp_D decimal(19,2), 
	tot_Pag_D decimal(19,2),
	tot_Pag_Comp_D decimal(19,2),

	tot_Imp_R decimal(19,2),
	tot_Imp_Comp_R decimal(19,2), 
	tot_Pag_R decimal(19,2),
	tot_Pag_Comp_R decimal(19,2),

	tot_Imp_I decimal(19,2),
	tot_Imp_Comp_I decimal(19,2), 
	tot_Pag_I decimal(19,2),
	tot_Pag_Comp_I decimal(19,2),

	Tot_Res_01_01 decimal(19,2),
	Tot_Res_31_12 decimal(19,2),
	Diff_Tot_Imp decimal(19,2),
	Diff_Tot_Imp_Comp decimal(19,2),
	Diff_Tot_Pag decimal(19,2),
	Diff_Tot_Pag_Comp decimal(19,2)
)

CREATE TABLE #error (Errore varchar(1000), Dipartimento varchar(200))

DECLARE @iddbdepartment varchar(50)
DECLARE @crsdepartment cursor

DECLARE @dip_nomesp varchar(300)
DECLARE @department varchar(150)


DECLARE @query nvarchar(300)
CREATE TABLE #flag(flag char(1))

-------- Sezione di controllo: esegue la "exp_check_miur"  -----------------------------------------------

SET @crsdepartment = cursor FOR SELECT iddbdepartment FROM dbdepartment
								where (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
OPEN @crsdepartment

FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
WHILE @@fetch_status=0 begin

	SET @dip_nomesp = @iddbdepartment + '.exp_check_miur'

        SET  @query = ' SELECT flagresearchagency FROM '+ @iddbdepartment + '.uniconfig'
        DELETE FROM #flag
        INSERT INTO #flag EXEC (@query)
-- Legge flagresearchagency del dipartimento corrente: se è uguale @flag allora esegua la sp interna
-- altrimenti passa al dipartimeto successivo
		IF (@flagresearchagency = 'A' AND @iddbdepartment='amministrazione') OR 
			(@flagresearchagency <> 'A' AND @iddbdepartment<>'amministrazione' AND (SELECT flag FROM #flag)=@flagresearchagency)
        Begin
                INSERT INTO #error (Errore,Dipartimento)
                EXEC  @dip_nomesp @ayear, @finpart,@unified
        End
	FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
END

IF (SELECT COUNT(*) FROM #error) > 0
        BEGIN
        	SELECT * FROM #error 
        	RETURN
        END

--------- Esegue la "exp_miur"   -----------------------------------------------------------------------------
SET @crsdepartment = cursor FOR SELECT iddbdepartment FROM dbdepartment
					 where (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)

OPEN @crsdepartment

FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
WHILE @@fetch_status=0 begin

	SET @dip_nomesp = @iddbdepartment + '.exp_miur'
        SET  @query = ' SELECT flagresearchagency FROM '+ @iddbdepartment + '.uniconfig'
        -- Come prima: deve consolidare solo gli enti di ricerca o non di ricerca
        DELETE FROM #flag
        INSERT INTO #flag EXEC ( @query )
		IF (@flagresearchagency = 'A' AND @iddbdepartment='amministrazione') OR 
			(@flagresearchagency <> 'A' AND @iddbdepartment<>'amministrazione' AND (SELECT flag FROM #flag)=@flagresearchagency)
        Begin

			INSERT INTO #unified (
        		sortcode,description,
        		tot_Imp,tot_Imp_Comp,tot_Pag,tot_Pag_Comp,
                tot_Imp_A,tot_Imp_Comp_A, tot_Pag_A,tot_Pag_Comp_A,
                tot_Imp_C,tot_Imp_Comp_C, tot_Pag_C,tot_Pag_Comp_C,
                tot_Imp_D,tot_Imp_Comp_D, tot_Pag_D,tot_Pag_Comp_D,
                tot_Imp_R,tot_Imp_Comp_R, tot_Pag_R,tot_Pag_Comp_R,
                tot_Imp_I,tot_Imp_Comp_I,tot_Pag_I,tot_Pag_Comp_I,
                Tot_Res_01_01,Tot_Res_31_12,
                Diff_Tot_Imp,Diff_Tot_Imp_Comp,
                Diff_Tot_Pag,Diff_Tot_Pag_Comp

	)
		EXEC @dip_nomesp @ayear, @finpart
        End
print @iddbdepartment

	FETCH NEXT FROM @crsdepartment INTO @iddbdepartment
END


IF @finpart = 'S'
BEGIN
	SELECT sortcode AS Codice, 
                description AS Descrizione, 
                ISNULL(SUM(tot_Imp),0)         AS 'Tot. Imp.',
                ISNULL(SUM(tot_Imp_Comp),0) AS 'Tot. Imp. Comp.',
                ISNULL(SUM(tot_Pag),0) AS 'Tot. Pag.',
                ISNULL(SUM(tot_Pag_Comp),0) AS 'Tot. Pag. Comp.',
                
                ISNULL(SUM(tot_Imp_A),0) AS 'Tot. Imp.  ASSISTENZIALE', 
                ISNULL(SUM(tot_Imp_Comp_A),0) AS 'Tot. Imp. Comp. ASSISTENZIALE',
                ISNULL(SUM(tot_Pag_A),0) AS 'Tot. Pag. ASSISTENZIALE', 
                ISNULL(SUM(tot_Pag_Comp_A),0) AS 'Tot. Pag. Comp. ASSISTENZIALE',
                
                ISNULL(SUM(tot_Imp_C),0) AS 'Tot. Imp. ALTRI SERVIZI DI SUPPORTO', 
                ISNULL(SUM(tot_Imp_Comp_C),0) AS 'Tot. Imp. Comp. ALTRI SERVIZI DI SUPPORTO',
                ISNULL(SUM(tot_Pag_C),0) AS 'Tot. Pag.ALTRI SERVIZI DI SUPPORTO', 
                ISNULL(SUM(tot_Pag_Comp_C),0) AS 'Tot. Pag. Comp.ALTRI SERVIZI DI SUPPORTO',
                
                ISNULL(SUM(tot_Imp_D),0) AS 'Tot. Imp. SERVIZI FORMATIVI ISTITUZIONALI',
                ISNULL(SUM(tot_Imp_Comp_D),0) AS 'Tot. Imp. Comp.SERVIZI FORMATIVI ISTITUZIONALI',
                ISNULL(SUM(tot_Pag_D),0) AS 'Tot. Pag.SERVIZI FORMATIVI ISTITUZIONALI',
                ISNULL(SUM(tot_Pag_Comp_D),0) AS 'Tot. Pag. Comp. SERVIZI FORMATIVI ISTITUZIONALI',
                
                ISNULL(SUM(tot_Imp_R),0) AS 'Tot. Imp.RICERCA', 
                ISNULL(SUM(tot_Imp_Comp_R),0) AS 'Tot. Imp. Comp.RICERCA',
                ISNULL(SUM(tot_Pag_R),0) AS 'Tot. Pag.RICERCA ', 
                ISNULL(SUM(tot_Pag_Comp_R),0) AS 'Tot. Pag. Comp.RICERCA',
                
                ISNULL(SUM(tot_Imp_I),0) AS 'Tot. Imp.INTERVENTI DIRITTO ALLO STUDIO', 
                ISNULL(SUM(tot_Imp_Comp_I),0) AS 'Tot. Imp. Comp.INTERVENTI DIRITTO ALLO STUDIO',
                ISNULL(SUM(tot_Pag_I),0) AS 'Tot. Pag. INTERVENTI DIRITTO ALLO STUDIO', 
                ISNULL(SUM(tot_Pag_Comp_I),0) AS 'Tot. Pag. Comp. INTERVENTI DIRITTO ALLO STUDIO',
                
                ISNULL(SUM(Tot_Res_01_01),0) AS 'Tot. Residui al 01/01', 
                ISNULL(SUM(Tot_Res_31_12),0) AS 'Tot. Residui al 31/12',
                ISNULL(SUM(Diff_Tot_Imp),0) AS 'Diff. Tot. Imp.',
                ISNULL(SUM(Diff_Tot_Imp_Comp),0) AS 'Diff. Tot. Imp. Comp.',
                ISNULL(SUM(Diff_Tot_Pag),0) AS 'Diff. Tot. Pag.',
                ISNULL(SUM(Diff_Tot_Pag_Comp),0) AS 'Diff. Tot. Pag. Comp.'
	FROM #unified 
        GROUP BY sortcode,description 
                ORDER BY sortcode
END
ELSE
BEGIN
	SELECT sortcode AS Codice, 
                description AS Descrizione, 
                ISNULL(SUM(tot_Imp),0) AS 'Tot. Acc.',
                ISNULL(SUM(tot_Imp_Comp),0) AS 'Tot. Acc. Comp.',
                ISNULL(SUM(tot_Pag),0) AS 'Tot. Inc.',
                ISNULL(SUM(tot_Pag_Comp),0) AS 'Tot. Inc. Comp.',
                
                ISNULL(SUM(tot_Imp_A),0) AS 'Tot. Acc.  ASSISTENZIALE', 
                ISNULL(SUM(tot_Imp_Comp_A),0) AS 'Tot. Acc. Comp. ASSISTENZIALE',
                ISNULL(SUM(tot_Pag_A),0) AS 'Tot. Inc. ASSISTENZIALE', 
                ISNULL(SUM(tot_Pag_Comp_A),0) AS 'Tot. Inc. Comp. ASSISTENZIALE',
                
                ISNULL(SUM(tot_Imp_C),0) AS 'Tot. Acc. ALTRI SERVIZI DI SUPPORTO', 
                ISNULL(SUM(tot_Imp_Comp_C),0) AS 'Tot. Acc. Comp. ALTRI SERVIZI DI SUPPORTO',
                ISNULL(SUM(tot_Pag_C),0) AS 'Tot. Inc.ALTRI SERVIZI DI SUPPORTO', 
                ISNULL(SUM(tot_Pag_Comp_C),0) AS 'Tot. Inc. Comp.ALTRI SERVIZI DI SUPPORTO',
                
                ISNULL(SUM(tot_Imp_D),0) AS 'Tot. Acc. SERVIZI FORMATIVI ISTITUZIONALI',
                ISNULL(SUM(tot_Imp_Comp_D),0) AS 'Tot. Acc. Comp.SERVIZI FORMATIVI ISTITUZIONALI',
                ISNULL(SUM(tot_Pag_D),0) AS 'Tot. Inc.SERVIZI FORMATIVI ISTITUZIONALI',
                ISNULL(SUM(tot_Pag_Comp_D),0) AS 'Tot. Inc. Comp. SERVIZI FORMATIVI ISTITUZIONALI',
                
                ISNULL(SUM(tot_Imp_R),0) AS 'Tot. Acc.RICERCA', 
                ISNULL(SUM(tot_Imp_Comp_R),0) AS 'Tot. Acc. Comp.RICERCA',
                ISNULL(SUM(tot_Pag_R),0) AS 'Tot. Inc.RICERCA ', 
                ISNULL(SUM(tot_Pag_Comp_R),0) AS 'Tot. Inc. Comp.RICERCA',
                
                ISNULL(SUM(tot_Imp_I),0) AS 'Tot. Acc.INTERVENTI DIRITTO ALLO STUDIO', 
                ISNULL(SUM(tot_Imp_Comp_I),0) AS 'Tot. Acc. Comp.INTERVENTI DIRITTO ALLO STUDIO',
                ISNULL(SUM(tot_Pag_I),0) AS 'Tot. Inc. INTERVENTI DIRITTO ALLO STUDIO', 
                ISNULL(SUM(tot_Pag_Comp_I),0) AS 'Tot. Inc. Comp. INTERVENTI DIRITTO ALLO STUDIO',
                
                ISNULL(SUM(Tot_Res_01_01),0) AS 'Tot. Residui al 01/01', 
                ISNULL(SUM(Tot_Res_31_12),0) AS 'Tot. Residui al 31/12',
                ISNULL(SUM(Diff_Tot_Imp),0) AS 'Diff. Tot. Acc.',
                ISNULL(SUM(Diff_Tot_Imp_Comp),0) AS 'Diff. Tot. Acc. Comp.',
                ISNULL(SUM(Diff_Tot_Pag),0) AS 'Diff. Tot. Inc.',
                ISNULL(SUM(Diff_Tot_Pag_Comp),0) AS 'Diff. Tot. Inc. Comp.'
	FROM #unified 
        GROUP BY sortcode,description 
        ORDER BY sortcode

END


END





GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

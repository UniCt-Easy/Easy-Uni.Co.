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

if exists (select * from dbo.sysobjects where id = object_id(N'[check_import_inquadramenti_csa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_import_inquadramenti_csa]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE [check_import_inquadramenti_csa](
	@LinkedServer varchar(200),
	@dbservername varchar(200),
	@matricolastart int,
	@matricolastop int
)
AS BEGIN

DECLARE @istance nvarchar(200)

DECLARE @EASY_INQUADRAMENTI nvarchar(4000)  -- Nome della vista degli inquadramenti


IF(@LinkedServer is not null)
-- Si connette usando il LINKEDSERVER
Begin
	if ((select isnull(istance,'') from linkedserveraccess)<>'')
	Begin
		SET @istance = (SELECT istance FROM linkedserveraccess)+'.'
	End
	Else
	Begin
		SET @istance=''
	End

	DECLARE @OPENQUERY nvarchar(4000)
	SET @OPENQUERY = ' OPENQUERY('+ @LinkedServer + ','''

	SET @EASY_INQUADRAMENTI = @OPENQUERY + 'SELECT * FROM '+@istance+'EASY_INQUADRAMENTI'')' 
End
Else
-- Si connette usando il DB / SERVER
Begin
	-- SET @dbservername='[LILITH].[LKUGOVEASY].[DBO]'

	SET @EASY_INQUADRAMENTI = @dbservername +'.EASY_INQUADRAMENTI'
End


DECLARE @query_EASY_INQUADRAMENTI nvarchar(4000)
DECLARE @query_PAGAMENTI nvarchar(4000)


CREATE TABLE #INQUADRAMENTI
(
	matricola varchar(40),
	---------------------------------------------------------------
	------------INQUADRAMENTO E REDDITO ANNUO PRESUNTO-------------
	---------------------------------------------------------------
	datadecorrenza datetime,		-- --in_vigore_Econ, inizio validità inquadramento
	in_vigore_giur datetime, 
	imponpresunto decimal(19,2),	-- reddito annuo presunto
	classestipendiale int,			-- classe stipendiale
	codicequalifica	varchar(20),	-- codice qualifica in Easy
	codiceinquadramento int,		-- id inquadramento in Easy
	livello int,
	codicequalifica_bdm	varchar(20),	-- codice qualifica
	iddaliaposition int,
	ruolo	varchar(4),				-- valore che arriva da CSA
	inquadramento varchar(20),		-- valore che arriva da CSA
	comparto	char (1),			-- valore che arriva da CSA
	termine datetime, 
	------------------------ note per l'utente ---------------------
	dettaglio varchar(300)
)

DECLARE @where_ANAGRAFICA nvarchar(1000)

IF (ISNULL(@matricolastart,0) <> 0 AND ISNULL(@matricolastop,0) <> 0)
BEGIN 
	SET @where_ANAGRAFICA = 
	' WHERE (XXX.matricola >= ' +  CONVERT(varchar(20),@matricolastart) + ' ) AND ' +
	'       (XXX.matricola <= ' +  CONVERT(varchar(20),@matricolastop)  + ' ) '
END
ELSE
 IF (ISNULL(@matricolastart,0) <> 0 )
	BEGIN
		SET @where_ANAGRAFICA = 
		' WHERE (XXX.matricola >= ' +  CONVERT(varchar(20),@matricolastart) + ' ) '
	END
	ELSE
		 IF (ISNULL(@matricolastop,0) <> 0 )
	BEGIN
		SET @where_ANAGRAFICA = 
		' WHERE (XXX.matricola <= ' +  CONVERT(varchar(20),@matricolastop) + ' ) '
	END


------------------
DECLARE @COL_Inquadramento int

BEGIN TRY

	DECLARE @SqlQuery NVARCHAR(MAX) = 
	'declare @x varchar(50)
	set @x = (select top 1 Inquadramento 
	FROM ' + @EASY_INQUADRAMENTI + ' ) ' 

--print @SqlQuery
	EXEC sp_executesql @SqlQuery
  -- PRINT 'La colonna esiste sulla tabella.';
	set @COL_Inquadramento=1
END TRY
BEGIN CATCH
	--PRINT 'Errore durante la verifica della colonna o linked server non disponibile.';
	set @COL_Inquadramento=0
    
END CATCH;
--------------------------------------------------------------------- Verifica presenza colonna INIZIO_INQ ---------------------------------------------------------------

DECLARE @COL_INIZIO_INQ int

BEGIN TRY

	DECLARE @SqlQuery2 NVARCHAR(MAX) = 
	'declare @x varchar(50)
	set @x = (select top 1 INIZIO_INQ 
	FROM ' + @EASY_INQUADRAMENTI + ' ) ' 

	EXEC sp_executesql @SqlQuery2

	set @COL_INIZIO_INQ=1
END TRY
BEGIN CATCH
	--PRINT 'Errore durante la verifica della colonna o linked server non disponibile.';
	set @COL_INIZIO_INQ=0
    
END CATCH;

---------------------------------------------------------------------------------------------------


if (@COL_Inquadramento <> 0) and (@COL_INIZIO_INQ=0)    -- colonna INQUADRAMENTO presente e colonna INIZIO_INQ assente
Begin
 
	-- Viste che hanno anche la colonna inquadramento
	SET @query_EASY_INQUADRAMENTI = '
	 INSERT INTO #INQUADRAMENTI(
		matricola,
		ruolo,
		comparto,
		datadecorrenza,
		termine,
		in_vigore_giur,
		imponpresunto,
		inquadramento,
		classestipendiale
	)
	
	SELECT 
		I.matricola, 
		I.ruolo,
		I.comparto,
		I.datadecorrenza,
		I.termine,
		isnull(I.datadelibera,I.datadecorrenza),
		null, --	I.imponibilepresunto
		I.inquadramento,
		CASE 
			WHEN SUBSTRING(I.inquadramento,0,3) in (''PN'',''PV'',''DN'',''DV'') THEN CAST(SUBSTRING(I.inquadramento,5,2)as int) 
			WHEN SUBSTRING(I.inquadramento,4,3) in ('' ND'','' NP'') THEN CAST(SUBSTRING(I.inquadramento,2,2)as int) 
		ELSE 0
		END
	FROM ' + @EASY_INQUADRAMENTI + ' as I ' +
	ISNULL(REPLACE(@where_ANAGRAFICA,'XXX.','I.'),'')  + 
	' GROUP BY I.matricola,I.ruolo,I.inquadramento, I.comparto,I.datadecorrenza,
		I.termine,
		I.datadelibera' 
-- IMPORTANTE: lo spazio presente davanti a (' ND',' NP') non va rimosso.

	EXEC (@query_EASY_INQUADRAMENTI) 
	print @query_EASY_INQUADRAMENTI
	-- UPDATE per valorizzare EVENTUALMENTE idposition
	UPDATE #INQUADRAMENTI SET codicequalifica = CSA_P.idposition, 
			codiceinquadramento = CSA_P.idinquadramento, 
			livello = CSA_P.livello,
			imponpresunto = CSA_P.supposedtaxable
			FROM csapositionlookup CSA_P
			WHERE CSA_P.csa_compartment = #INQUADRAMENTI.comparto /* fa il match fra la tripla che arriva dalla view e la tripla presente nel LookUp, e prende il valore corrispondente in Easy di idposition e idinquadramento*/
				AND CSA_P.csa_role = #INQUADRAMENTI.Ruolo 
				AND CSA_P.csa_class = #INQUADRAMENTI.Inquadramento
				
End

if ( (@COL_Inquadramento = 0) and (@COL_INIZIO_INQ=0) )  -- colonna INQUADRAMENTO assente e colonna INIZIO_INQ assente
Begin
	-- Viste che NON hanno anche la colonna inquadramento
	SET @query_EASY_INQUADRAMENTI = '
	 INSERT INTO #INQUADRAMENTI(
		matricola,
		ruolo,
		comparto,
		datadecorrenza,
		termine,
		in_vigore_giur,
		imponpresunto,
		classestipendiale
	)
	--
	SELECT 
		I.matricola, 
		I.ruolo,
		I.comparto,
		I.datadecorrenza,
		I.termine,
		I.datadelibera,
		null,--	I.imponibilepresunto
		0
	FROM ' + @EASY_INQUADRAMENTI + ' as I ' +
	ISNULL(REPLACE(@where_ANAGRAFICA,'XXX.','I.'),'')  + 
	' GROUP BY I.matricola,I.ruolo,I.comparto,I.datadecorrenza,
		I.termine,
		I.datadelibera' 

	EXEC (@query_EASY_INQUADRAMENTI) 

	-- UPDATE per valorizzare EVENTUALMENTE idposition
UPDATE #INQUADRAMENTI SET codicequalifica = idposition, 
				imponpresunto = supposedtaxable
			FROM csapositionlookup CSA_P
			WHERE CSA_P.csa_compartment = #INQUADRAMENTI.comparto 
				AND CSA_P.csa_role = #INQUADRAMENTI.Ruolo 
End


-- UPDATE per valorizzare EVENTUALMENTE iddaliaposition
UPDATE #INQUADRAMENTI SET iddaliaposition = dalia_position.iddaliaposition 
			FROM dalia_position 
			WHERE dalia_position.codedaliaposition = #INQUADRAMENTI.codicequalifica_bdm 
				 





SELECT 
	C.matricola,
	---------------------------------------------------------------
	------------INQUADRAMENTO E REDDITO ANNUO PRESUNTO-------------
	---------------------------------------------------------------
	C.datadecorrenza,
	case when (year(isnull(termine,1900))='2222') 
		then {d '2078-12-31'}
		else C.termine
	end AS termine,
	C.in_vigore_giur,
	C.classestipendiale,

	C.codicequalifica ,-- è l'idposition di Easy
	C.codiceinquadramento, -- è l'idinquadramento di Easy
	C.livello,
	C.iddaliaposition ,-- è l'iddaliaposition di Easy
	C.imponpresunto	,  -- è l'imponibile presunto di Easy
	'N' as avviso,
	null as dettaglio,
	C.comparto,
	C.ruolo,
	C.inquadramento,
	'I' as rowkind
FROM #INQUADRAMENTI C
where C.codicequalifica  is  null


END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




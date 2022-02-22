
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_bilprevisionesorting_mpsiope]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_bilprevisionesorting_mpsiope]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 

GO

CREATE  PROCEDURE [exp_bilprevisionesorting_mpsiope]
	@ayear				int,

	@idsorkind_siope	int, --> Classificazione Siope
	@idsorkind_missprog	int, --> Classificazione Missioni Programmi

	@idupb				varchar(36),
	@showupb			char(1)='N',
	@showchildupb		char(1),

	@idsor01			int=null,
	@idsor02			int=null,
	@idsor03			int=null,
	@idsor04			int=null,
	@idsor05			int=null 
AS
BEGIN

--DROP TABLE IF EXISTS #reporttotrim
CREATE TABLE #reporttotrim (
	levelparent_mp varchar(MAX),
	levelchild_mp varchar(MAX),
	codeupb varchar(MAX),
	idupb varchar(MAX),
	upb varchar(MAX),
	upbprintingorder varchar(MAX),
	code_mp varchar(MAX),
	sorting_mp varchar(MAX),
	sortingparent_mp varchar(MAX),
	codeparent_mp varchar(MAX),
	code_siope varchar(MAX),
	sorting_siope varchar(MAX),
	previsione_prec decimal(19,6),
	previsione_curr decimal(19,6)
)

INSERT INTO #reporttotrim
EXEC rpt_bilprevisionesorting_mpsiope
	@ayear,
	@idsorkind_siope,
	@idsorkind_missprog,
	@idupb,
	'N', --@showupb,
	'N',  --@showchildupb,
	@idsor01,
	@idsor02,
	@idsor03,
	@idsor04,
	@idsor05

update #reporttotrim set sorting_mp=replace(sorting_mp,'’', '''')

SELECT	code_siope,
		sorting_siope,
--		code_mp,
		sorting_mp,
		previsione_curr
INTO	#data
FROM	#reporttotrim

DECLARE	@columnlist AS NVARCHAR(MAX),
		@columnlistselect AS NVARCHAR(MAX),
		@columnlisttoadd AS NVARCHAR(MAX),
		@output AS NVARCHAR(MAX)

-- SELECT * FROM #reporttotrim
-- SELECT * FROM #data

-- tabella valori trovati
/*
SELECT DISTINCT description AS id INTO #sorting_mp_sortcodes
FROM #data
*/

-- tabella valori estratti
/*
SELECT description AS id INTO #sorting_mp_sortcodes
FROM sorting 
WHERE paridsor IN (
	SELECT idsor
	FROM sorting
	WHERE idsorkind = @idsorkind_missprog and paridsor IS NULL
)
*/

--tabella valori inseriti manualmente

--DROP TABLE IF EXISTS #sorting_mp_sortcodes
CREATE TABLE #sorting_mp_sortcodes(id varchar(max), description varchar(max))

INSERT INTO #sorting_mp_sortcodes VALUES ('RI_RB', 'Ricerca scientifica e tecnologica di base (COFOG 01.4)')
INSERT INTO #sorting_mp_sortcodes VALUES ('RI_RA', 'Ricerca scientifica e tecnologica applicata (COFOG 04.8)')
INSERT INTO #sorting_mp_sortcodes VALUES ('RI_SA', 'Ricerca scientifica e tecnologica applicata (COFOG 07.5)')
INSERT INTO #sorting_mp_sortcodes VALUES ('IU_SUF', 'Sistema universitario e formazione post universitaria (COFOG 09.4)')
INSERT INTO #sorting_mp_sortcodes VALUES ('IU_DS', 'Diritto allo studio nell''istruzione universitaria (COFOG 09.6)')
INSERT INTO #sorting_mp_sortcodes VALUES ('TS_AS', 'Assistenza in materia sanitaria (COFOG 07.3)')
INSERT INTO #sorting_mp_sortcodes VALUES ('TS_AV', 'Assistenza in materia veterinaria (COFOG 07.4)')
INSERT INTO #sorting_mp_sortcodes VALUES ('SIG_IP', 'Indirizzo politico (COFOG 09.8)')
INSERT INTO #sorting_mp_sortcodes VALUES ('SIG_SAG', 'Servizi e affari generali per le amministrazioni (COFOG 09.8)')
INSERT INTO #sorting_mp_sortcodes VALUES ('FA1', 'Fondi da ripartire (COFOG 09.8)')


-- creazione stringhe valori possibili per sorting_mp per query dinamica finale
SELECT @columnlist = ISNULL(@columnlist + ',','') + QUOTENAME(description) FROM #sorting_mp_sortcodes
SELECT @columnlistselect = ISNULL(@columnlistselect + ',','') + 'ISNULL(' + QUOTENAME(description) + ', 0) AS ' + QUOTENAME(description) FROM #sorting_mp_sortcodes
SELECT @columnlisttoadd = ISNULL(@columnlisttoadd + ' + ','') + 'ISNULL(' + QUOTENAME(description) + ', 0)' FROM #sorting_mp_sortcodes

-- DEBUG
/*
SELECT * from #sorting_mp_sortcodes
SELECT @columnlist
SELECT @columnlistselect
SELECT @columnlisttoadd
*/

/*
DECLARE @codice NVARCHAR(MAX) = '123456789'
DECLARE @temp NVARCHAR(MAX) = reverse(@codice)
DECLARE @i int = 3
WHILE @i <= LEN(@temp)
BEGIN
    SET @temp = STUFF(@temp, @i, 0, '.')
    SET @i = @i + 3
END
SET @codice = reverse(@temp)
SELECT @codice
*/

SET @output = N'
	SELECT ''SX.U.'' + 

		CASE
			WHEN LEN(code_siope) = 2 THEN
				code_siope
			WHEN LEN(code_siope) = 3 THEN
				SUBSTRING(code_siope, 1,1) + ''.'' + 
				SUBSTRING(code_siope, 2,2)
			WHEN LEN(code_siope) = 4 THEN
				SUBSTRING(code_siope, 1,2) + ''.'' + 
				SUBSTRING(code_siope, 3,2)
			WHEN LEN(code_siope) = 5 THEN
				SUBSTRING(code_siope, 1,1) + ''.'' + 
				SUBSTRING(code_siope, 2,2) + ''.'' +
				SUBSTRING(code_siope, 4,2)
			WHEN LEN(code_siope) = 6 THEN
				SUBSTRING(code_siope, 1,2) + ''.'' + 
				SUBSTRING(code_siope, 3,2) + ''.'' +
				SUBSTRING(code_siope, 5,2)
			WHEN LEN(code_siope) = 7 THEN
				SUBSTRING(code_siope, 1,1) + ''.'' + 
				SUBSTRING(code_siope, 2,2) + ''.'' +
				SUBSTRING(code_siope, 4,2) + ''.'' +
				SUBSTRING(code_siope, 6,2)
			WHEN LEN(code_siope) = 8 THEN
				SUBSTRING(code_siope, 1,2) + ''.'' + 
				SUBSTRING(code_siope, 3,2) + ''.'' +
				SUBSTRING(code_siope, 5,2) + ''.'' +
				SUBSTRING(code_siope, 7,2)
			WHEN LEN(code_siope) = 9 THEN
				SUBSTRING(code_siope, 1,1) + ''.'' + 
				SUBSTRING(code_siope, 2,2) + ''.'' +
				SUBSTRING(code_siope, 4,2) + ''.'' +
				SUBSTRING(code_siope, 6,2) + ''.'' +
				SUBSTRING(code_siope, 8,2)
			WHEN LEN(code_siope) = 10 THEN
				SUBSTRING(code_siope, 1,2) + ''.'' + 
				SUBSTRING(code_siope, 3,2) + ''.'' +
				SUBSTRING(code_siope, 5,2) + ''.'' +
				SUBSTRING(code_siope, 7,2) + ''.'' +
				SUBSTRING(code_siope, 9,2)
			ELSE ''''
		END AS CODICE,

		sorting_siope AS DESCRIZIONE,
		' + @columnlisttoadd + ' AS ''IMPORTO PAGAMENTI'',
		' + @columnlistselect + '

	FROM #data
    PIVOT(
		SUM(previsione_curr)
        FOR sorting_mp IN (' + @columnlist + ')
	) AS pivottable
	ORDER BY code_siope
'

EXEC (@output)

END

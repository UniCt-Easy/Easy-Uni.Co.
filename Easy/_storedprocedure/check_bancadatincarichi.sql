
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


if exists (select * from dbo.sysobjects where id = object_id(N'[check_bancadatincarichi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [check_bancadatincarichi]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
--setuser 'amministrazione'
-- setuser 'amm'
 
CREATE    PROCEDURE [check_bancadatincarichi]

(
 
	@yservreg int,
	@fromnservreg  int,
	@tonservregfine int 
)
AS BEGIN
--        exec check_bancadatincarichi  2011, 1, 1000
 
--sp_help serviceregistry

--select * from serviceregistry
CREATE TABLE #logerror(
	cod_errore int,
	severity char(1),
	yservreg int,
	nservreg int,
	employkind char(1),
    title varchar(200),
	cf varchar(50),
	description varchar(1000),
	errore varchar(1000),
	soluzione varchar(1000)
)

--referencerule

--CREATE TABLE #mittente(
--	cfpersonamittente varchar(16),
--	ragsocmittente varchar(50),
--	cfmittente varchar(16),
--	cfsoftwarehouse varchar(16),
--	flagesisteresponsabile char(1)
--)

--INSERT INTO #mittente
--EXEC emens_getdatimittente @anno

--DECLARE @curr_departmentname varchar(500)
--SET  @curr_departmentname = ISNULL( (SELECT paramvalue from
--			 generalreportparameter where idparam='DenominazioneDipartimento' and 
--				(start is null or start <= @datacontabile) and
--				(stop is null or stop >= @datacontabile)
--				),'Manca Cfg. Parametri Tutte le stampe')


-- Controllo degli errori su #mittente
INSERT INTO #logerror
(cod_errore, severity,yservreg,nservreg,employkind, title,cf,description,errore,soluzione)
SELECT 1, 'E', s.yservreg, s.nservreg,
s.employkind, s.title, s.cf, s.description, 
'Codice Tipologia Norma attivo per l''incarico  ' + convert(varchar(10), s.yservreg) + '/n°' + convert(varchar(10), s.nservreg) ,
'Andare in ''Compensi--> Banca Dati incarichi --> Scheda Altro'', ed inserire un codice Tipologia Norma  in sostituzione di ' +  referencerule.idreferencerule + ' ' + referencerule.description
FROM serviceregistry s
JOIN referencerule on referencerule.idreferencerule = s.idreferencerule
WHERE  s.yservreg = @yservreg and s.nservreg between @fromnservreg   and @tonservregfine and
isnull(referencerule.active,'N') = 'N'

 

--INSERT INTO #logerror
--SELECT 'S',@curr_departmentname,'Non è stato inserito il codice fiscale del mittente',
--'Andare in ''Configurazione - Informazioni Ente'' ed inserire il codice fiscale'
--FROM #mittente WHERE (cfmittente = '' OR cfmittente IS NULL)
 
 
 

SELECT 
	cod_errore,
	severity ,
	yservreg as 'esercizio',
	nservreg 'numero',
	CASE  employkind 
		WHEN 'C' THEN 'Consulente'
		ELSE 'Dipendente'
	END as 'Tipo Incarico',
    title as 'Incaricato',
	cf,
	description as 'Descrizione',
	errore,
	soluzione 
FROM #logerror
ORDER BY yservreg, nservreg
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

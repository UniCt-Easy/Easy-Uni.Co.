
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


if exists (select * from dbo.sysobjects where id = object_id(N'[unify_registry_monodipartimento]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [unify_registry_monodipartimento]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser'amministrazione'
/****** Object:  StoredProcedure [unify_registry_monodipartimento]    Script Date: 23/09/2014 09.23.45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
 

CREATE   PROCEDURE [unify_registry_monodipartimento]
/*
Gianni 22-09-2014
Integrazione di alcune tabelle che non vengono aggiornate
--config idreg_csa	Anagrafica per CSA
--csa_importver	idreg_agency	
--wageaddition	idreg_distrained	
*/


AS
BEGIN

CREATE TABLE #registrytoredirect(
	idreg int,
	newidreg int
)


INSERT INTO #registrytoredirect (idreg,newidreg)
SELECT idreg, toredirect
FROM   [dbo].registry
WHERE  toredirect is not null

IF (SELECT COUNT(idreg) FROM #registrytoredirect) = 0
BEGIN
	DROP TABLE #registrytoredirect
	PRINT 'Non ci sono anagrafiche marcate come unificabili'
	RETURN
END

CREATE TABLE #tables	
	(
		tablename varchar(80),
		colname   varchar(80),
		dbo 	  char(1),
		ownertablename varchar(200)
	)


--elenco tabelle con chiave esterna su registry
INSERT INTO #tables 
(tablename,colname,dbo, ownertablename)
SELECT DISTINCT 
	o.name, 
	c.name,
	CASE
 		WHEN o.uid = USER_ID('dbo')
 		THEN 'S'
	 	ELSE 'N'
	END,
	'['+ u.name + ']' + '.'+ '[' +o.name + ']'
FROM  columntypes  cl
JOIN  customobject co
	ON co.objectname=cl.tablename
JOIN sysobjects o
	ON co.objectname = o.name
JOIN syscolumns c
 	ON o.id = c.id
	AND cl.field = C.name
JOIN sysusers u ON u.uid = o.uid
WHERE cl.field = 'idreg' 
AND o.xtype = 'U'
AND (o.uid = USER_ID() OR o.uid = USER_ID('dbo'))
AND co.isreal  = 'S' 
AND cl.iskey   = 'N'

INSERT INTO #tables 
(tablename, colname, dbo, ownertablename)
SELECT o.name, c.name,
CASE
 WHEN o.uid = USER_ID('dbo')
 THEN 'S'
 ELSE 'N'
END,
'['+ u.name + ']' + '.'+ '[' +o.name + ']'
FROM sysobjects o
JOIN syscolumns c
 ON o.id = c.id
JOIN sysusers u ON u.uid = o.uid
WHERE o.xtype = 'U'
 AND
 (
  (
   c.name IN ('idreg', 'iddeputy', 'idsorreg', 'registrymanager', 'idregauto', 'paymentagency', 'refundagency','regionalagency','idreg_distrained','idreg_agency','idreg_csa')
   AND o.name NOT IN ('registry', 'registryaddress', 'registryreference', 'registrypaymethod', 'registrylegalstatus','registrycvattachment','registryattachment', 
   'registrytaxablestatus', 'registrycf', 'registrypiva', 'registryrole','registrydurc','registrysorting', 
   'registry_amministrativi','registry_aziende','registry_docenti','registry_istituti', 'registry_istitutiesteri',	'registry_studenti'	 )
  )
  OR (o.name = 'registrypaymethod' AND c.name = 'iddeputy')
 )
 AND (o.uid = USER_ID() OR o.uid = USER_ID('dbo'))
 AND NOT EXISTS 
	(SELECT * FROM #tables WHERE #tables.tablename = o.name
	 AND  #tables.colname = c.name)
	
--select * from #tables
--where dbo = 'S'
-- CICLO SU TUTTI I DIPARTIMENTI PER LE TABELLE DI TIPO NON DBO

DECLARE @command 	varchar(2000)
DECLARE @select		varchar(2000)
DECLARE @tablename 	varchar(80)
DECLARE @colname 	varchar(80)
DECLARE @ownertablename varchar(200)
-- CICLO PER LE TABELLE DI TIPO DBO E AMMINISTRAZIONE
DECLARE tabellecursor INSENSITIVE CURSOR FOR
	SELECT tablename, colname, ownertablename FROM #tables
	JOIN   sysobjects ON sysobjects.name = #tables.tablename 
	WHERE (dbo = 'N' AND  sysobjects.xtype = 'U') or 
	(dbo = 'S')
	FOR READ ONLY
OPEN 	tabellecursor 
FETCH NEXT FROM tabellecursor into @tablename, @colname, @ownertablename
WHILE   @@FETCH_STATUS = 0
BEGIN 
PRINT '--TABELLA ' + @ownertablename + ': campo ' + @colname 
/*
SET   @select  = ' select * from ' + @ownertablename +
		 ' where ' + @ownertablename+ '.' + @colname +
		 ' in (select idreg from #registrytoredirect) ' */

SET   @command = ' update '+  @ownertablename +
		 ' set '   +  @colname   +  '  = ' +
 		 ' 	(select newidreg from #registrytoredirect as MT ' + 
		    	 'where '+ @ownertablename + '.' + @colname + '  = MT.idreg) ' + 
		 ' where ' + @ownertablename + '.' + @colname +
		 ' in (select idreg from #registrytoredirect) '
PRINT @command
PRINT @select
EXECUTE(@command)
execute(@select)
FETCH NEXT FROM tabellecursor INTO @tablename, @colname, @ownertablename
END 
DEALLOCATE tabellecursor


UPDATE registry SET toredirect = null
WHERE  idreg in (select idreg FROM #registrytoredirect)

DROP TABLE #tables		
DROP TABLE #registrytoredirect
END


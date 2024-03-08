
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


if exists (select * from dbo.sysobjects where id = object_id(N'[emens_getListaCollaboratori]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [emens_getListaCollaboratori]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
CREATE    PROCEDURE emens_getListaCollaboratori
(
	@ycommunication int,
	@mcommunication int,
	@cf_enterprise varchar(16),
        @adate datetime,
	@cap varchar(5) output,
	@istat varchar(5) output
)
AS BEGIN
CREATE TABLE #collaboratoremain
(
    departmentname varchar(500),
	cfcollaboratore varchar(16),
	cognome varchar(50),
	nome varchar(20),
	tiporapporto varchar(2),
	codiceattivita varchar(2),
	imponibile decimal(19,2),
	aliquota decimal(19,6) NOT NULL,
	altraass varchar(3),
	dal smalldatetime,
	al smalldatetime,
	codicecomune varchar(20),
	codcalamita varchar(2),
	codcertificazione varchar(3),
	servicemodule varchar(20),
	taxref varchar(20),
	esiste_DIS_COLL_N char(1)
)
DECLARE @parentsp char(1)
SET @parentsp = 'E'
INSERT INTO #collaboratoremain
EXEC emens_daticollaboratore @ycommunication,@mcommunication,@mcommunication,@parentsp, @adate 
SELECT @cap = cap FROM license
-- Il codice ISTAT è stato preso dalla classificazione per le attività produttive ATECO 2002 
-- (consultabile presso il sito www.istat.it)
SET @istat = '80301'
SELECT
	cfcollaboratore,
	cognome,
	nome,
	codicecomune,
	tiporapporto,
	codiceattivita,
	imponibile,
	aliquota,
	altraass,
	dal,
	al,
	codcalamita,
	codcertificazione
FROM #collaboratoremain
END



GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


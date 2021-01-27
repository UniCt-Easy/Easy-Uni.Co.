
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


if exists (select * from dbo.sysobjects where id = object_id(N'[sp_getcustomrelationdefault]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [sp_getcustomrelationdefault]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE             PROCEDURE [sp_getcustomrelationdefault]  @FromTable varchar(50), @ToTable varchar(50), @EditType varchar(50)  AS
BEGIN
	CREATE TABLE #tabfiltro
			(
			fieldname	varchar(50)	NULL,
			defaultvalue	varchar(50)	NULL
			)
	
		
	DECLARE @phasecreddebs	tinyint
	DECLARE @phasecreddebe	tinyint)
	
	SELECT @phasecreddebs = expenseregphase from uniconfig
	SELECT @phasecreddebe = incomeregphase from uniconfig
		IF ((@FromTable='registry')  and  (@ToTable='expense')  and  (@EditType='default'))
		BEGIN
			INSERT INTO #tabfiltro 
			VALUES ('nphase', @phasecreddebs)	
		END
		IF ((@FromTable='registry')  and  (@ToTable='income')  and  (@EditType='default'))
		BEGIN
			INSERT INTO #tabfiltro 
			VALUES ('nphase',@phasecreddebe)	
		END
			
		--M. Smaldino 07 09 2005
		--Dopo la traduzione del modulo Patrimonio, 
		--bisogna tradurre anche le variabili di sistema utilizzate nelle Insert seguenti 
		
	
		IF ((@FromTable='assetload') AND (@ToTable='assetacquire') AND (@EditType='default')) BEGIN
			INSERT INTO #tabfiltro
			VALUES ('idmot', '<%usr[frmbuonodicarico_causale]%>')
			INSERT INTO #tabfiltro
			VALUES ('idreg', '<%usr[frmbuonodicarico_codicecreddeb]%>')
			INSERT INTO #tabfiltro
			VALUES ('idinventory', '<%usr[frmbuonodicarico_idinventory]%>')
		END
	
		
		
	SELECT * FROM #tabfiltro 
			ORDER BY fieldname
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


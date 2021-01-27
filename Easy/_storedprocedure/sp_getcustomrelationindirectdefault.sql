
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


if exists (select * from dbo.sysobjects where id = object_id(N'[sp_getcustomrelationindirectdefault]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [sp_getcustomrelationindirectdefault]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO





CREATE              PROCEDURE [sp_getcustomrelationindirectdefault]  @FromTable varchar(50), @ToTable varchar(50), @EditType varchar(50)  AS
BEGIN
	CREATE TABLE #tabfiltro
			(
			tablename	varchar(50)  	NULL,
			fieldname	varchar(50)	NULL,
			defaultvalue	varchar(50)	NULL
			)
		IF ((@FromTable='fin')  and  (@ToTable='expense')  and  (@EditType='default'))
		BEGIN
			INSERT INTO #tabfiltro 
			VALUES ('expense','nphase', '<%sys[expensefinphase]%>')	
			INSERT INTO #tabfiltro 
			VALUES ('expenseyear','nphase', '<%sys[expensefinphase]%>')	
		END
		IF ((@FromTable='fin')  and  (@ToTable='income')  and  (@EditType='default'))
		BEGIN
			INSERT INTO #tabfiltro 
			VALUES ('income','nphase', '<%sys[incomefinphase]%>')	
			INSERT INTO #tabfiltro 
			VALUES ('incomeyear','nphase', '<%sys[incomefinphase]%>')	
		END
		
		IF ((@FromTable='itineration')  and  (@ToTable='expense')  and  (@EditType='default')) BEGIN
			INSERT INTO #tabfiltro 
			VALUES ('expense', 'nphase', '<%sys[itinerationphase]%>')	
			INSERT INTO #tabfiltro 
			VALUES ('expenseyear', 'nphase', '<%sys[itinerationphase]%>')	
		END
		IF ((@FromTable='casualcontract')  and  (@ToTable='expense')  and  (@EditType='default')) BEGIN
			INSERT INTO #tabfiltro 
			VALUES ('expense', 'nphase', '<%sys[itinerationphase]%>')	
			INSERT INTO #tabfiltro 
			VALUES ('expenseyear', 'nphase', '<%sys[itinerationphase]%>')	
		END
		IF ((@FromTable='profservice')  and  (@ToTable='expense')  and  (@EditType='default')) BEGIN
			INSERT INTO #tabfiltro 
			VALUES ('expense', 'nphase', '<%sys[itinerationphase]%>')	
			INSERT INTO #tabfiltro 
			VALUES ('expenseyear', 'npahse', '<%sys[itinerationphase]%>')	
		END
		
		IF ((@FromTable='wageaddition')  and  (@ToTable='expense')  and  (@EditType='default')) BEGIN
			INSERT INTO #tabfiltro 
			VALUES ('expense', 'nphase', '<%sys[itinerationphase]%>')	
			INSERT INTO #tabfiltro 
			VALUES ('expenseyear', 'nphase', '<%sys[itinerationphase]%>')	
		END
		IF ((@FromTable='mandate')  and  (@ToTable='expense')  and  (@EditType='default')) BEGIN
			INSERT INTO #tabfiltro 
			VALUES ('expense', 'nphase', '<%sys[itinerationphase]%>')	
			INSERT INTO #tabfiltro 
			VALUES ('expenseyear', 'nphase', '<%sys[itinerationphase]%>')	
		END
		--M. Smaldino 07 09 2005
		--Dopo la traduzione del modulo Patrimonio, 
		--tradurre anche le Insert seguenti 
 
		IF ((@FromTable='asset')  and  (@ToTable='assetaccretion')  and  (@EditType='default')) BEGIN
			INSERT INTO #tabfiltro 
			VALUES ('assetacquire', 'invtreecode', '''<%usr[frmbeneinventariabile_codiceinventario]%>''')	
			INSERT INTO #tabfiltro 
			VALUES ('asset', 'ninventory', '<%usr[frmbeneinventariabile_numinventario]%>')	
			INSERT INTO #tabfiltro 
			VALUES ('assetacquire', 'description', '''<%usr[frmbeneinventariabile_descrizione]%>''')	
		END
--sostituire il valore numerico con la variabile fasemissone
			
		SELECT * FROM #tabfiltro 
			ORDER BY tablename
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


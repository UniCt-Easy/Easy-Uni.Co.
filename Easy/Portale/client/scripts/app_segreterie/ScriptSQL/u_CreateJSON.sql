
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


-- CREAZIONE FUNZIONE [dbo].[CreateJSON]
-- CONTROLLARE SE SUL SISTEMA E' NECESSARIO SETTARE PRIMA QUOTED_QLCS AD OFF (ES: UNIPO)
IF EXISTS (select  * from sysobjects where id = object_id(N'[dbo].[CreateJSON]') and OBJECTPROPERTY(id, N'IsScalarFunction') = 1)
	DROP FUNCTION [dbo].[CreateJSON]
GO
CREATE FUNCTION [dbo].[CreateJSON] (@XMLResult XML)
RETURNS NVARCHAR(MAX)
WITH EXECUTE AS CALLER
AS
BEGIN
DECLARE  @JSONVersion NVARCHAR(MAX), @Rowcount INT
DECLARE @InputJson NVARCHAR(MAX) 
SELECT @JSONVersion = '', @rowcount=COUNT(*) FROM @XMLResult.nodes('/root/*') x(a)

SET @InputJson = 
	  (SELECT TOP 1 (SELECT COALESCE(b.c.value('text()[1]','NVARCHAR(MAX)'),'')	  
     FROM x.a.nodes('*') b(c) 
     FOR XML PATH(''),TYPE).value('(./text())[1]','NVARCHAR(MAX)')	
   FROM @XMLResult.nodes('/root/*') x(a))

SET @InputJson = Replace(Replace(@InputJson,'[',''),']','')

SELECT @JSONVersion=@JSONVersion+
STUFF(
  (SELECT TheLine FROM 
    (SELECT ',{'+
      STUFF((SELECT ',"'+COALESCE(REPLACE(b.c.value('local-name(.)', 'NVARCHAR(255)'), '_', ' '),'')+'":"'+
       REPLACE( --escape tab properly within a value
         REPLACE( --escape return properly
		   REPLACE(--linefeed must be escaped
           --REPLACE( --escape string
             REPLACE( --backslash too
               REPLACE(COALESCE(b.c.value('text()[1]','NVARCHAR(MAX)'),''),--forwardslash
               '\', '\\'),   
              '/', '\/'),  
			  -- '"','\"'),
          CHAR(10),'\n'),   
         CHAR(13),'\r'),   
       CHAR(09),'\t')   
     +'"'   
     FROM x.a.nodes('*') b(c) 
     FOR XML PATH(''),TYPE).value('(./text())[1]','NVARCHAR(MAX)'),1,1,'')+'}'
   FROM @XMLResult.nodes('/root/*') x(a)
   ) JSONResult(theLine)
  FOR XML PATH(''),TYPE).value('.','NVARCHAR(MAX)' )
,1,1,'')

SET @InputJson = (SELECT Replace(@InputJson,'\"','"'))
SET @JSONVersion = (SELECT Replace(@JSONVersion,'\"','"'))

DECLARE @OUTPUT NVARCHAR(MAX)
SET @OUTPUT= (SELECT 
CASE
    WHEN CHARINDEX(@InputJson, @JSONVersion) > 0  THEN @InputJson 	
    ELSE @JSONVersion  
END) 

RETURN (
SELECT 
CASE
    WHEN @OUTPUT like '{%},{%}'  THEN '['+ @OUTPUT+']'	
    ELSE @OUTPUT  
END)

END
GO




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



IF EXISTS (select * from sysobjects where id = object_id(N'[dbo].[Split]') and OBJECTPROPERTY(id, N'IsTableFunction') = 1)
	DROP FUNCTION [dbo].[Split]
GO

CREATE FUNCTION [dbo].[Split] (@String VARCHAR (MAX), @Delimiter CHAR (1))
   RETURNS @results TABLE (items VARCHAR (MAX))
AS
   BEGIN
     DECLARE @index   INT
     DECLARE @slice   VARCHAR (8000)
     SELECT @index = 1
     IF len (@String) < 1 OR @String IS NULL
         RETURN
     WHILE @index != 0
     BEGIN
         SET @index = charindex (@Delimiter, @String)
         IF @index != 0
           SET @slice = left (@String, @index-1)
         ELSE
           SET @slice = @String
         IF (len (@slice) > 0)
           INSERT INTO @results (Items)
           VALUES (@slice)
         SET @String = right (@String, len (@String)-@index)
         IF len (@String) = 0
           BREAK
     END
     RETURN
   END;

GO


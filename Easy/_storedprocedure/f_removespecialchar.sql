
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


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[f_removespecialchar]') )
DROP FUNCTION [dbo].[f_removespecialchar]
GO
 

CREATE FUNCTION [dbo].[f_removespecialchar](@s VARCHAR(max))
RETURNS varchar(max)
AS
BEGIN
        IF @s IS NULL
            RETURN NULL
        DECLARE @s2 VARCHAR(max) = '',
                @l INT = LEN(@s),
                @p INT = 1

        WHILE @p <= @l
            BEGIN
                DECLARE @c INT
                SET @c = ASCII(SUBSTRING(@s, @p, 1))
                IF ( @c BETWEEN 32 AND 125 ) 

                SET @s2 = @s2 + CHAR(@c)
                SET @p = @p + 1
      END

        IF LEN(@s2) = 0
            RETURN NULL

        RETURN @s2
END

go
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO




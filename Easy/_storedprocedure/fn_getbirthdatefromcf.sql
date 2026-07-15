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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetBirthDateFromCF]') )
drop function [dbo].[GetBirthDateFromCF]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--setuser 'amministrazione'

CREATE FUNCTION [dbo].[GetBirthDateFromCF](@CF VARCHAR(16))
RETURNS DATE
AS
BEGIN
    DECLARE 
        @YY   INT,
        @MM   INT,
        @DD   INT,
        @Century INT,
        @Date DATE;
	IF @CF IS NULL RETURN NULL;

    -- Estrae anno (pos 7-8), mese (pos 9), giorno (pos 10-11)
    SET @YY = TRY_CONVERT(INT, SUBSTRING(@CF, 7, 2));
    
    -- Mappa il mese dal carattere
    SET @MM = 
        CASE SUBSTRING(@CF, 9, 1)
            WHEN 'A' THEN 1
            WHEN 'B' THEN 2
            WHEN 'C' THEN 3
            WHEN 'D' THEN 4
            WHEN 'E' THEN 5
            WHEN 'H' THEN 6
            WHEN 'L' THEN 7
            WHEN 'M' THEN 8
            WHEN 'P' THEN 9
            WHEN 'R' THEN 10
            WHEN 'S' THEN 11
            WHEN 'T' THEN 12
            ELSE NULL
        END;

    -- Giorno con gestione femminile (+40)
    SET @DD = TRY_CONVERT(INT, SUBSTRING(@CF, 10, 2));
    IF @DD > 40 SET @DD = @DD - 40;

    -- Determinazione del secolo
    -- Regola comune: se YY > anno attuale -> 1900, altrimenti 2000
    SET @Century = CASE WHEN @YY > (YEAR(GETDATE()) % 100) 
                        THEN 1900 
                        ELSE 2000 
                   END;

    -- Componi la data
    SET @Date = TRY_CONVERT(DATE, CONCAT(@Century + @YY, '-', @MM, '-', @DD));

    RETURN @Date;
END;
GO



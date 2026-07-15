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

if exists (select * from dbo.sysobjects where id = object_id(N'[count_registrylegalstatus]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [count_registrylegalstatus]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE   procedure count_registrylegalstatus (
@StartMissione datetime,
@StopMissione datetime,
@idreg int,
@res int out
) as
BEGIN


WITH RLS_ordinati AS (
    SELECT top 100 start, isnull(stop,'2078-12-31') as stop
    FROM registrylegalstatus
    WHERE ((idreg=@idreg)AND(active='S'))
			and start <= @StopMissione AND isnull(stop,'2078-12-31') >= @StartMissione
    ORDER BY start 
),
Coverage AS (
    SELECT 
        SUM(CASE 
            WHEN start <= @StartMissione THEN 1 
            ELSE 0 
        END) AS CoversStart,
        MAX(isnull(stop,'2078-12-31')) AS MaxEnd
    FROM RLS_ordinati
	)

 SELECT 
    @res= CASE 
        WHEN CoversStart > 0 AND MaxEnd >= @StopMissione THEN 0 --'COPERTO'
        ELSE 1  --'NOT COPERTO'
    END --AS StatoCopertura
FROM Coverage;


--SET @res= ISNULL((SELECT max(nrows) from #mytable), 0)

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


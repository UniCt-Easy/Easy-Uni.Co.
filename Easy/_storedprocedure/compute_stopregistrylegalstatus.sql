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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_stopregistrylegalstatus]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_stopregistrylegalstatus]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE       PROCEDURE compute_stopregistrylegalstatus(
	@matricolastart int,
	@matricolastop int
)
AS BEGIN


;WITH OrderedData AS (
    SELECT 
        RLS.idregistrylegalstatus,
        RLS.idreg,
        RLS.start,
		RLS.stop,
        LEAD(RLS.start) OVER (PARTITION BY RLS.idreg ORDER BY RLS.start) AS next_start
    FROM 
        registrylegalstatus RLS
		join registry R on RLS.idreg = R.idreg
	where ISNUMERIC(extmatricula) =1 
	and  isnull(r.extmatricula,0) >= isnull(@matricolastart,0) 
	and RLS.active='S'
	and ( @matricolastop is null or	isnull(r.extmatricula,0) <= isnull(@matricolastop,0) )
),
StopCalcolato AS (
    SELECT 
        idregistrylegalstatus,
        idreg,
        start,
        COALESCE(DATEADD(DAY, -1, next_start), stop) AS stop_calcolato
    FROM 
        OrderedData
)

SELECT 
    t.idregistrylegalstatus,
    t.idreg,
    t.start,
	t.stop,
    c.stop_calcolato 
into #tempregistrylegalstatus
FROM 
    registrylegalstatus t
JOIN 
    (SELECT idreg, start, MAX(stop_calcolato) AS stop_calcolato
     FROM StopCalcolato
     GROUP BY idreg, start) c
ON 
    t.idreg = c.idreg 
    AND t.start = c.start
where (t.stop in ('2078-12-31','2079-06-06') or year(t.stop) = 2222 OR stop is null)
and t.active='S'

delete from #tempregistrylegalstatus where stop_calcolato is null


update u
set u.stop = s.stop_calcolato, u.lu='scriptlead', u.lt=getdate()
from registrylegalstatus u
    inner join #tempregistrylegalstatus s 
	on  u.idreg = s.idreg and   u.idregistrylegalstatus = s.idregistrylegalstatus

drop table #tempregistrylegalstatus

end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 

GO




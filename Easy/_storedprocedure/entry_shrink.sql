
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


if exists (select * from dbo.sysobjects where id = object_id(N'[entry_shrink]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [entry_shrink]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--setuser 'amm'
--setuser 'amministrazione'
-- entry_shrink 2019
-- select * from entry where yentry=2017
CREATE PROCEDURE [entry_shrink]
(
	@esercizio int
)
AS BEGIN

CREATE TABLE #lookup (
	nentry_old int,
	nentry_new int
)
begin transaction
INSERT INTO #lookup
SELECT nentry, ROW_NUMBER() OVER (ORDER BY adate asc, ct asc, lt asc)
FROM [entry]
WHERE yentry = @esercizio;

UPDATE	[entry]
SET 	nentry = nentry_new
FROM	#lookup
WHERE 	nentry = nentry_old AND yentry = @esercizio;

DISABLE TRIGGER [trigger_u_entrydetail] ON [entrydetail];

UPDATE	[entrydetail]
SET 	yentry = 9999, nentry = nentry_new
FROM	#lookup
WHERE 	nentry = nentry_old AND yentry = @esercizio;


UPDATE	[entrydetail]
SET 	yentry = @esercizio
WHERE 	yentry = 9999;

ENABLE TRIGGER [trigger_u_entrydetail] ON [entrydetail];

UPDATE	[entrydetailaccrual]
SET 	yentry = 9999, nentry = nentry_new
FROM	#lookup
WHERE 	nentry = nentry_old AND yentry = @esercizio;

UPDATE	[entrydetailaccrual]
SET 	yentry = @esercizio
WHERE 	yentry = 9999;

UPDATE	[entrydetailaccrual]
SET 	nentrylinked = nentry_new
FROM	#lookup
WHERE	nentrylinked = nentry_old AND yentrylinked = @esercizio;


UPDATE	[entrytotal]
SET 	yentry = 9999, nentry = nentry_new
FROM	#lookup
WHERE 	nentry = nentry_old AND yentry = @esercizio;

UPDATE	[entrytotal]
SET 	yentry = @esercizio
WHERE 	yentry = 9999;

DROP TABLE #lookup;
commit transaction

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


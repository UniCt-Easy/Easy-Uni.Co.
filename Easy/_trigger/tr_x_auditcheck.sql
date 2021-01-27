
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


SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[tr_x_auditcheck]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [tr_x_auditcheck]
GO

CREATE    TRIGGER [tr_x_auditcheck] ON auditcheck
FOR INSERT,UPDATE, DELETE 
AS 
BEGIN
	DECLARE @dbtable	VARCHAR(50)
	DECLARE @dboperation	CHAR(1)

	CREATE TABLE #a_check
	(
		tablename varchar(150),
		opkind char(1)
	)
	declare @dd datetime 
	set @dd= GETDATE()
	if (select count(*) from inserted)>0 
		insert into #a_check(tablename,opkind) select distinct tablename,opkind from  inserted

	if (select count(*) from deleted)>0 
		insert into #a_check(tablename,opkind) select distinct tablename,opkind from  deleted
	
	if (select count(*) from #a_check)>0 
	BEGIN
		INSERT INTO sptocompile(tablename, opkind, lt) 
			SELECT DISTINCT tablename,opkind,@dd from #a_check WHERE
				NOT EXISTS (SELECT * FROM sptocompile WHERE tablename = #a_check.tablename 
										AND opkind = #a_check.opkind)
	END
	
	DROP TABLE #a_check

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


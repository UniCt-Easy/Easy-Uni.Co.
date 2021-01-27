
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_check_serviceregistry_unified]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_check_serviceregistry_unified]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE exp_check_serviceregistry_unified (
	@ayear int,
	@unified char(1)
	)
AS 
BEGIN

IF (@unified <> 'S')
BEGIN
        EXEC exp_check_serviceregistry_single @ayear
        RETURN
END 

CREATE TABLE #AllCompensi(
		departmentname varchar(200),
		nservreg	int,
		yservreg	int,
		title		varchar(150),
		kind		varchar(50),
		ncon		int,
		ycon		int
		)
	declare @iddbdepartment varchar(50)
	declare @crsdepartment cursor
	set 	@crsdepartment = cursor for select  iddbdepartment from dbdepartment
	open 	@crsdepartment
	fetch next from @crsdepartment into @iddbdepartment
	while @@fetch_status=0 begin
		declare @dip_nomesp varchar(300)
											  
		set @dip_nomesp = @iddbdepartment + '.exp_check_serviceregistry_single'

		INSERT INTO #AllCompensi(
			departmentname,
			title,
			nservreg,
			yservreg,
			kind,
			ncon,
			ycon
			)
		exec @dip_nomesp  @ayear
		fetch next from @crsdepartment into @iddbdepartment
	
	END

SELECT 
	departmentname as 'Dipartimento',
	title as 'Anagrafica',
	yservreg as 'Eserc.Incarico',
	nservreg as 'Nun.Incarico',
	kind as 'Compenso',
	ycon as 'Eserc.Compenso',
	ncon as 'Nun.Compenso'
FROM #AllCompensi 
ORDER BY departmentname, title, yservreg, nservreg


END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO





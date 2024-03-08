
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


if exists (select * from dbo.sysobjects where id = object_id(N'[unified_esporta_fatture_dateincoerenti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [unified_esporta_fatture_dateincoerenti]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE  [unified_esporta_fatture_dateincoerenti]
	@ayear	int,
	@stop	smalldatetime,
	@idinvkind int,
	@unified char(1)  
AS BEGIN
	IF (@unified <> 'S')
	BEGIN
			EXEC esporta_fatture_dateincoerenti @ayear,@stop,@idinvkind,@unified 
			RETURN
	END 
	--[unified_esporta_fatture_dateincoerenti] 2011,  {d '2011-12-31'},4,'S'
	CREATE TABLE #fatture(
		invoicekind varchar(50),
		yinv smallint,
		ninv int,
		adate smalldatetime,
		department varchar(50)	
	)

	declare @iddbdepartment varchar(50)
	declare @crsdepartment cursor
	set 	@crsdepartment = cursor for select  iddbdepartment from dbdepartment
	where (start is null or start <= @ayear ) AND ( stop is null or stop >= @ayear)
	open 	@crsdepartment
	fetch next from @crsdepartment into @iddbdepartment
	while @@fetch_status=0 begin
		declare @s varchar(300)
		set @s = @iddbdepartment + '.esporta_fatture_dateincoerenti'
		insert into #fatture (		
				department,
				invoicekind,
				yinv,
				ninv,
				adate
			)
			exec @s @ayear,@stop,@idinvkind,@unified 

		fetch next from @crsdepartment into @iddbdepartment
	end

	SELECT
		department as 'Dipartimento', 
		invoicekind 'Tipo Documento',
		yinv 'Eserc.Documento',
		ninv 'Num. Documento',
		adate as 'Data Registrazione'
	FROM #fatture
	ORDER BY department, invoicekind
end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

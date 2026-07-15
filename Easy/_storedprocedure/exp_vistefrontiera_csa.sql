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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_vistefrontiera_csa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_vistefrontiera_csa]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- setuser'amministrazione'
-- exec amministrazione.exp_vistefrontiera_csa 'I', null, null

CREATE PROCEDURE [exp_vistefrontiera_csa](
	@kind char(1), --> A: legge da EASY_ANAGRAFICA. I : legge da EASY_INQUADRAMENTI. P : legge da EASY_MODALITA_PAGAMENTO_ANAGRAFICA
	@matricolastart varchar(10),
	@matricolastop varchar(10)
)
AS BEGIN

declare @LinkedServer nvarchar(4000)
declare @dbservername  varchar(200)
select @LinkedServer = linkedservername,
	@dbservername = DBServerName
	from linkedserveraccess

DECLARE @istance nvarchar(200)
DECLARE @ViewName nvarchar(4000)  -- Nome della vista delle Anagrafiche

if @kind = 'A'
	begin
		set @ViewName = 'EASY_ANAGRAFICA'
	end
if @kind = 'I'
begin
	set @ViewName = 'EASY_INQUADRAMENTI'
end
if @kind = 'P'
	begin
		set @ViewName = 'EASY_MODALITA_PAGAMENTO_ANAGRAFICA'
	end

----------------------------------------------
DECLARE @From_query nvarchar(1000)

IF(@LinkedServer is not null)
-- Si connette usando il LINKEDSERVER
Begin
	if ((select isnull(istance,'') from linkedserveraccess)<>'')
	Begin
		SET @istance = (SELECT istance FROM linkedserveraccess)+'.'
	End
	Else
	Begin
		SET @istance=''
	End

	DECLARE @OPENQUERY nvarchar(4000)
	SET @OPENQUERY = ' OPENQUERY('+ @LinkedServer + ','''

	SET @From_query = @OPENQUERY + 'SELECT * FROM '+@istance+ @ViewName +')'
	End
Else
-- Si connette usando il DB / SERVER
Begin
	SET @From_query = @dbservername +'.'+@ViewName+''
End



DECLARE @query_ANAGRAFICA nvarchar(4000)
DECLARE @where_query nvarchar(1000)

IF (ISNULL(@matricolastart,0) <> 0 AND ISNULL(@matricolastop,0) <> 0)
BEGIN 
	SET @where_query = 
	' WHERE (XXX.matricola >= ' +  CONVERT(varchar(20),@matricolastart) + ' ) AND ' +
	'       (XXX.matricola <= ' +  CONVERT(varchar(20),@matricolastop)  + ' ) '
END
ELSE
 IF (ISNULL(@matricolastart,0) <> 0 )
	BEGIN
		SET @where_query = 
		' WHERE (XXX.matricola >= ' +  CONVERT(varchar(20),@matricolastart) + ' ) '
	END
	ELSE
		 IF (ISNULL(@matricolastop,0) <> 0 )
	BEGIN
		SET @where_query = 
		' WHERE (XXX.matricola <= ' +  CONVERT(varchar(20),@matricolastop) + ' ) '
	END


SET @query_ANAGRAFICA = '
SELECT * 			
FROM ' + @From_query + ' as A ' + 
ISNULL(REPLACE(@where_query,'XXX.','A.'),'') +
' ORDER BY A.matricola '

EXEC (@query_ANAGRAFICA)

print (@query_ANAGRAFICA)





END

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

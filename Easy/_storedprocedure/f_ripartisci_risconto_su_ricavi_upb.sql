
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


--/* Create a table type. */
if not exists (select * from systypes where name = 'RevenueTableType')
begin 
	CREATE TYPE dbo.RevenueTableType -- ricavi UPB ripartiti per conto
	   AS TABLE
		  ( idupb varchar(36),	 	
			idacc varchar(38),			
			amount decimal(19,2),
			accountkind char(1) ); -- SEMPRE R--> RICAVI
end
GO
--setuser'amministrazione'
if exists (select * from dbo.sysobjects where id = object_id(N'[f_ripartisci_risconto_su_ricavi_upb]') )
drop function [f_ripartisci_risconto_su_ricavi_upb]
GO
 
 
 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 

CREATE  FUNCTION [f_ripartisci_risconto_su_ricavi_upb] 
(	
	@importo_risconto decimal(19,2),
	@tab_ricavi RevenueTableType READONLY
)
RETURNS @result TABLE (idupb varchar(36),	idacc varchar(38), importo decimal(19,2), ndetail int identity(1,1))
AS
begin
 

	DECLARE @sommaRicavi    decimal(19,2)
	DECLARE @sommaDaRipartire decimal(19,2) 
	SELECT @sommaRicavi =   sum(amount) from @tab_ricavi 
	SET @sommaDaRipartire = @importo_risconto 
	
	IF (@sommaDaRipartire = 0) OR (@sommaRicavi = 0) return
	DECLARE @idupb varchar(36) 
	DECLARE @idacc varchar(38)  
	DECLARE @amount decimal(19,2)

	DECLARE @importo_ripartito decimal(19,2)
	DECLARE @quota decimal(19,2)

	BEGIN
		DECLARE cursore  INSENSITIVE CURSOR FOR
			SELECT  idupb,idacc, amount FROM @tab_ricavi    
			FOR READ ONLY
			OPEN cursore
		FETCH NEXT FROM cursore INTO @idupb, @idacc, @amount 
		WHILE (@@FETCH_STATUS = 0)
		BEGIN
				if (@amount = 0   ) set @importo_ripartito = 0
				if (@sommaRicavi = 0   ) set @importo_ripartito = 0
			
				SET @quota = ROUND(@sommaDaRipartire * (@amount / @sommaRicavi),2);
				--print '@quota'
				--print @quota
				SET @importo_ripartito = @quota
				SET @sommaRicavi = @sommaRicavi - @amount;
				SET @sommaDaRipartire =  @sommaDaRipartire - @quota;
				if (@importo_ripartito != 0)
		 			insert into @result(idupb, idacc,importo )	values(@idupb, @idacc,@importo_ripartito )
							
		FETCH NEXT FROM cursore INTO  @idupb, @idacc, @amount 
		END

		END
		DEALLOCATE cursore
		
return;

end

GO


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


-- setuser 'amministrazione'
if not exists (select * from systypes where name = 'idrelated_list') begin 
	CREATE TYPE dbo.idrelated_list AS TABLE      ( idrel varchar(150))  
end
GO	
	
if exists (select * from dbo.sysobjects where id = object_id(N'[fn_decode_idrelated_tab_substring]') )
drop function [fn_decode_idrelated_tab_substring]
GO
 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--declare @lista_id dbo.idrelated_list 
--insert into  @lista_id values ('estim§CA_SISEST§2021§7§34')
--insert into  @lista_id values ('inv§283§2017§29§8')
--insert into  @lista_id values ('inv§283§2017§29§1')
--insert into @lista_id  select 'inv§283§2017§29§2' 
--insert into @lista_id  select 'cascon§2016§1'
----insert into @lista_id  select 'cascon§2016§14§RITEN§17'
----insert into @lista_id  select 'cascon§2016§15§RITEN§17§21552'
----insert into @lista_id  select 'payroll§556'
----insert into @lista_id  select 'man§SOFRE_GEN§2021§37§1'
----insert into @lista_id  select 'payroll§26100§RITEN§14'
----insert into @lista_id  select 'payroll§26100§RITEN§14'
--insert into @lista_id  select 'csaimport§1§RIEP§5'
--insert into @lista_id  select 'csaimport§1§RIEP§4'
--insert into @lista_id  select 'csaimport§1§RIEP§6'
--insert into @lista_id  select 'csaimport§1§RIEP§7'
--insert into @lista_id  select 'csaimport§1§RIEP§8'

 --select * from [fn_decode_idrelated_tab_substring] (@lista_id)
CREATE FUNCTION  [fn_decode_idrelated_tab_substring]
(
	@lista_id dbo.idrelated_list  READONLY -- = 'inv§283§2017§29§8',
) 
  RETURNS   @result_set TABLE (idrelated varchar(150) NOT NULL PRIMARY KEY WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON), 
  col1 varchar(50), col2 varchar(50), col3 varchar(50), col4 varchar(50), col5 varchar(50), col6 varchar(50), col7 varchar(50),col8 varchar(50))
-- RETURNS  @result_set TABLE (idrelated varchar(150) PRIMARY KEY WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON), col1 varchar(20), col2 varchar(20), col3 varchar(20), col4 varchar(20), col5 varchar(20), col6 varchar(20), col7 varchar(20),col8 varchar(20))
  AS BEGIN
  DECLARE   @string_value varchar(150)

  DECLARE	@delimiter_character CHAR(1) = '§'
  DECLARE	@start_position INT,
			@ending_position INT
  DECLARE	@col1 varchar(50)  
  DECLARE	@col2 varchar(50)  
  DECLARE	@col3 varchar(50)  
  DECLARE	@col4 varchar(50)  
  DECLARE	@col5 varchar(50)  
  DECLARE	@col6 varchar(50)  
  DECLARE	@col7 varchar(50)
  DECLARE	@col8 varchar(50)

 
  DECLARE	cursore CURSOR FOR 
  SELECT  idrel FROM @lista_id  -- where idrel NOT like '%estim%' AND  idrel NOT  like '%man%'

	OPEN cursore
	FETCH NEXT FROM cursore
		INTO @string_value   
	
	WHILE @@FETCH_STATUS = 0
		BEGIN

		   
		   SELECT  @start_position = 1,
			@ending_position = CHARINDEX(@delimiter_character, @string_value)

		   DECLARE @indice int = 1
 
		   WHILE @start_position < LEN(@string_value) + 1
           BEGIN
				IF @ending_position = 0 
					SET @ending_position = LEN(@string_value) + 1
 
					DECLARE @item varchar(20)
					SET @item =  SUBSTRING(@string_value, @start_position,  @ending_position - @start_position ) 
					IF (@indice = 1)  SET  @col1 =   @item
					IF (@indice = 2)  SET  @col2 =   @item
					IF (@indice = 3)  SET  @col3 =   @item
					IF (@indice = 4)  SET  @col4 =   @item
					IF (@indice = 5)  SET  @col5 =   @item
					IF (@indice = 6)  SET  @col6 =   @item
					IF (@indice = 7)  SET  @col7 =   @item 
					IF (@indice = 8)  SET  @col8 =   @item 
					SET @start_position = @ending_position + 1
					SET @ending_position = CHARINDEX(@delimiter_character, @string_value, @start_position)
					SET @indice = @indice +1
		  END
 
		  INSERT INTO  @result_set (idrelated,col1,col2,col3,col4,col5,col6,col7,col8) VALUES (@string_value,@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8)

		  FETCH NEXT FROM cursore INTO @string_value 

	END
CLOSE cursore
DEALLOCATE cursore
	
    RETURN;
	END   		

GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
 
 

--GO

--SET QUOTED_IDENTIFIER OFF 
--GO
--SET ANSI_NULLS ON 
--GO

--EXEC [decode_idrelated] 'csaimport§4§VER§8220', '§'

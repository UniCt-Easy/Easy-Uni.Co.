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

if exists (select * from dbo.sysobjects where id = object_id(N'[fn_decode_idrelated]') )
drop function [fn_decode_idrelated]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--setuser 'amministrazione'
---- SOLO PER CONTRATTI ATTIVI, PASSIVI, FATTURE
CREATE FUNCTION  [fn_decode_idrelated]
(
	@kind      varchar(10),
	@idrelated varchar(200),  -- = 'man§CP_AffGenerali§2022§1§1',
	@separator char(1) = '§'  -- §
) 
RETURNS @result TABLE (idrelated varchar(150) NOT NULL PRIMARY KEY WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON), 
  col1 varchar(50), col2 varchar(50), col3 varchar(50), col4 varchar(50), col5 varchar(50), col6 varchar(50), col7 varchar(50),col8 varchar(50))

  AS BEGIN
  DECLARE   @string_value varchar(150)
  DECLARE   @result_set TABLE (idrelated varchar(150) NOT NULL PRIMARY KEY WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON), 
  col1 varchar(50), col2 varchar(50), col3 varchar(50), col4 varchar(50), col5 varchar(50), col6 varchar(50), col7 varchar(50),col8 varchar(50))
  DECLARE	@delimiter_character CHAR(1) = @separator
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
 
  IF (NOT(@idrelated LIKE @kind+'§%') OR (ISNULL(@idrelated,'') = ''))
  BEGIN
		RETURN
  END

  SET @string_value = @idrelated
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
 
INSERT INTO @result (idrelated,  col1, col2 , col3, col4, col5, col6, col7,col8)   
SELECT @string_value,   @col1, @col2 , @col3, @col4, @col5, @col6, @col7,@col8
RETURN
END
GO
--select isnull(M.epkind,'N'),* from [fn_decode_idrelated_mandate_tab] ('man§CP_AffGenerali§2022§1§1', '§' ) F
--join mandatedetail M  on M.idmankind = F.col2 and M.yman = F.col3 and M.nman = F.col4 and M.rownum=  F.col5
--WHERE isnull(M.epkind,'N') ='S'
--F	Fattura da ricevere
--N	Non generare ratei o scritture automatiche a fine anno
--S	Genera rateo

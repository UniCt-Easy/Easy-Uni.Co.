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

-- setuser 'amministrazione'
if not exists (select * from systypes where name = 'idrelated_list') begin 
	CREATE TYPE dbo.idrelated_list AS TABLE      ( idrel varchar(150))  
end
GO	
	
if exists (select * from dbo.sysobjects where id = object_id(N'[fn_decode_idrelated_csa]') )
drop function [fn_decode_idrelated_csa]
GO
 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--declare @lista_id dbo.idrelated_list 
----insert into  @lista_id values ('estim§CA_SISEST§2021§7§34')
----insert into @lista_id  select 'inv§283§2017§29§2' 

--select * from [fn_decode_idrelated_csa] (2024, 1, null)
CREATE FUNCTION  [fn_decode_idrelated_csa]
(
	@yimport int,
	@nimport int,
	@matricola varchar(40)
) 
RETURNS @result TABLE (idrelated varchar(150) NOT NULL,	
	kind varchar(max), rifdoc varchar(max), docdate datetime, daterif datetime, 
	matricola varchar(max),
	yentry int,
	nentry int,
	ndetail int,
	amount decimal(19,2),
	give decimal(19,2),
	have decimal(19,2),
	idacc varchar(38),
	codeacc varchar(50),
	account varchar(150),
	idupb varchar(36),
	codeupb varchar(50),
	upb varchar(150),
	idreg int,
	registry varchar(100),
	detaildescription	varchar(400),
	idepacc	int,
	yepacc int,
	nepacc int,
	idepexp	int,
	yepexp int,
	nepexp int--,
	--idexp int, 
	--yexp int,
	--nexp int,
	--idinc int,
	--yinc int,
	--ninc int 
) 
-- RETURNS  @result_set TABLE (idrelated varchar(150) PRIMARY KEY WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON), col1 varchar(20), col2 varchar(20), col3 varchar(20), col4 varchar(20), col5 varchar(20), col6 varchar(20), col7 varchar(20),col8 varchar(20))
  AS BEGIN
  DECLARE	@lista_id dbo.idrelated_list   -- = 'inv§283§2017§29§8',
  DECLARE   @string_value varchar(150)
  DECLARE   @result_set TABLE (idrelated varchar(150) NOT NULL PRIMARY KEY WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON), col1 varchar(50), col2 varchar(50), col3 varchar(50), col4 varchar(50), col5 varchar(50), col6 varchar(50), col7 varchar(50),col8 varchar(50))
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

  DECLARE	@kind varchar(max)
  DECLARE	@rifdoc varchar(max)
  DECLARE	@adate datetime
  DECLARE	@daterif datetime
  DECLARE	@csamatricola varchar(max)
 
  DECLARE   @idrelated varchar(100)
  DECLARE   @yentry int --= 2024 
  DECLARE	@nentry int --= 1
  SET  @idrelated = 'csa_import'+ '§' + convert(varchar(4),@yimport) + + '§' + convert(varchar(4),@nimport)   -- csa_import§2023§1
 
  DECLARE @ndetail int 
  DECLARE @amount decimal(19,2) 
  DECLARE @give decimal(19,2) 
  DECLARE @have decimal(19,2) 
  DECLARE @idacc varchar(38) 
  DECLARE @codeacc varchar(50) 
  DECLARE @account varchar(150) 
  DECLARE @idupb varchar(36) 
  DECLARE @codeupb varchar(50) 
  DECLARE @upb varchar(150) 
  DECLARE @idreg int 
  DECLARE @registry varchar(100) 
  DECLARE @detaildescription	varchar(400) 
  DECLARE @idepacc int 
  DECLARE @yepacc int 
  DECLARE @nepacc int 
  DECLARE @idepexp int 
  DECLARE @yepexp int 
  DECLARE @nepexp int 
  --DECLARE @idexp int  
  --DECLARE @yexp int 
  --DECLARE @nexp int 
  --DECLARE @idinc int 
  --DECLARE @yinc int 
  --DECLARE @ninc int 

  SELECT @yentry = yentry, 
		 @nentry = nentry 
  FROM   entry
  WHERE  idrelated = @idrelated
 
  DECLARE @maxincomephase tinyint
  SELECT  @maxincomephase = MAX(nphase) FROM   incomephase 
		
  DECLARE @maxexpensephase tinyint
  SELECT  @maxexpensephase = MAX(nphase) FROM   expensephase 

  --SP_HELP entrydetailview
  IF (@yentry IS NULL) return
	DECLARE @entrydetail TABLE (idrelated varchar(150) NOT NULL,
	yentry int,
	nentry int,
	ndetail int,
	amount decimal(19,2),
	give decimal(19,2),
	have decimal(19,2),
	idacc varchar(38),
	codeacc varchar(50),
	account varchar(150),
	idupb varchar(36),
	codeupb varchar(50),
	upb varchar(150),
	idreg int,
	registry varchar(100),
	detaildescription	varchar(400),
	idepacc	int,
	yepacc int,
	nepacc int,
	idepexp	int,
	yepexp int,
	nepexp int--,
	--idexp int, 
	--yexp int,
	--nexp int,
	--idinc int,
	--yinc int,
	--ninc int 
	)

	INSERT INTO @entrydetail
	SELECT /*top 5000*/ idrelateddetail, yentry, nentry, ndetail, amount,give, have,
	idacc,codeacc, account, idupb,codeupb, upb, EV.idreg,registry, detaildescription,
	idepacc,yepacc, nepacc, idepexp, yepexp, nepexp--,
	--EV.idexp, E.ymov, E.nmov, EV.idinc, I.ymov, I.nmov
	FROM entrydetailview EV
	--LEFT OUTER JOIN expense E ON EV.idexp = E.idexp
	--LEFT OUTER JOIN income I ON EV.idinc = I.idinc 
	WHERE yentry = @yentry AND nentry = @nentry

	insert into @lista_id  
	select distinct idrelated 
	from entrydetail 
	where yentry = @yentry AND nentry = @nentry 
  --SELECT * from @lista_id
 
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
		  --DECLARE	@kind varchar(50)
		  --DECLARE	@rifdoc varchar(100)
		  --DECLARE	@daterif datetime
		  --select * from  @result_set
		

			  IF ((@col1 = 'csaimport') AND (@col3 = 'VER'))
			  BEGIN
 				  SELECT @kind = 'Importazione CSA Stipendi',
				  @rifdoc = 'Import. CSA Stipendi ' +  convert (varchar(4),D.yimport) + '/ n° ' + convert (varchar(10),D.nimport )+ ' ' + D.description + 
							+ ' ' + isnull(@col3,'') + ' n° ' + isnull(@col4,'')  +
							+ ' #' + isnull(@col5,'')   , -- + ' ' +  isnull(@col3,'') + ' #' +isnull(@col4,''), 
				  @adate = D.adate, @daterif = D.adate, @csamatricola = V.matricola 
				  FROM @result_set R
				  JOIN csa_import D ON idcsa_import = isnull(R.col2,'')  
				  JOIN csa_importver V 
					ON V.idcsa_import = D.idcsa_import AND
					   V.idver = isnull(R.col4,'') 
				  WHERE R.idrelated = @string_value AND R.col1 = 'csaimport'
				 -- AND V.matricola = '10133495'
				 -- SET @string_value = isnull(@col1,'') + @delimiter_character + isnull(@col2,'')
		     END
		 
		   IF ((@col1 = 'csaimport') AND (@col3 = 'RIEP'))
			  BEGIN
 				  SELECT @kind = 'Importazione CSA Stipendi',
				  @rifdoc = 'Import. CSA Stipendi ' +  convert (varchar(4),D.yimport) + '/ n° ' + convert (varchar(10),D.nimport )+ ' ' + D.description + 
							+ ' ' + isnull(@col3,'') + ' n° ' + isnull(@col4,'')  +
							+ ' #' + isnull(@col5,'')   , -- + ' ' +  isnull(@col3,'') + ' #' +isnull(@col4,''), 
				  @adate = D.adate, @daterif = D.adate, 
				   @csamatricola = RP.matricola 
				  FROM @result_set R
				  JOIN csa_import D ON idcsa_import = isnull(R.col2,'') 
				  JOIN csa_importriep RP 
					ON RP.idcsa_import = D.idcsa_import AND
					   RP.idriep = isnull(R.col4,'') 
				  WHERE R.idrelated = @string_value AND R.col1 = 'csaimport'
				  	  --AND RP.matricola = '10133495'
				 -- SET @string_value = isnull(@col1,'') + @delimiter_character + isnull(@col2,'')
		     END
	 
		  IF (@kind is not null)	
		  BEGIN 
			  SET @col1 = null SET @col2 = null SET @col3 = null SET @col4 = null 
			  SET @col5 = null SET @col6 = null SET @col7 = null SET @col8 = null
			  INSERT INTO @result (idrelated,kind,rifdoc,docdate, daterif,matricola,
			  yentry,nentry, ndetail,amount,give,have, idacc, codeacc,account,
			  idupb, codeupb, upb, idreg,registry, detaildescription, idepacc,
			  yepacc,nepacc,idepexp, yepexp, nepexp
			  --, idexp, yexp,nexp,idinc,yinc,ninc
			  )   
			  SELECT @string_value, @kind, @rifdoc, @adate,@daterif,@csamatricola,
			   ED.yentry,ED.nentry, ED.ndetail,ED.amount,ED.give,ED.have, ED.idacc, ED.codeacc,ED.account,
			   ED.idupb, ED.codeupb, ED.upb, ED.idreg,ED.registry, ED.detaildescription, ED.idepacc,
			   ED.yepacc,ED.nepacc,ED.idepexp, ED.yepexp, ED.nepexp
			   --, ED.idexp, ED.yexp,ED.nexp,ED.idinc,ED.yinc,ED.ninc
			   FROM @entrydetail ED WHERE ED.idrelated = @string_value
			  SET @kind = NULL   SET @string_value = NULL  SET @rifdoc = NULL SET @adate = NULL 
			  SET @daterif = NULL SET @csamatricola = NULL
		  END
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
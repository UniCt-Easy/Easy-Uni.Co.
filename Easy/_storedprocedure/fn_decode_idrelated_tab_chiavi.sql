
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
	
if exists (select * from dbo.sysobjects where id = object_id(N'[fn_decode_idrelated_tab]') )
drop function [fn_decode_idrelated_tab_chiavi]
GO
 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--declare @lista_id dbo.idrelated_list 
----insert into  @lista_id values ('estim§CA_SISEST§2021§7§34')
----insert into  @lista_id values ('inv§283§2017§29§8')
----insert into  @lista_id values ('inv§283§2017§29§1')
----insert into @lista_id  select 'inv§283§2017§29§2' 
----insert into @lista_id  select 'cascon§2016§1'
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

--select * from [fn_decode_idrelated_tab] (@lista_id)
CREATE FUNCTION  [fn_decode_idrelated_tab_chiavi]
(
	@lista_id dbo.idrelated_list  READONLY -- = 'inv§283§2017§29§8',
) 
RETURNS @result TABLE (idrelated varchar(150) NOT NULL PRIMARY KEY WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),	
kind varchar(100), rifdoc varchar(200), docdate datetime, daterif datetime,
  col1 varchar(50), col2 varchar(50), col3 varchar(50), col4 varchar(50), col5 varchar(50), col6 varchar(50), col7 varchar(50),col8 varchar(50)) 
-- RETURNS  @result_set TABLE (idrelated varchar(150) PRIMARY KEY WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON), col1 varchar(20), col2 varchar(20), col3 varchar(20), col4 varchar(20), col5 varchar(20), col6 varchar(20), col7 varchar(20),col8 varchar(20))
  AS BEGIN
  DECLARE   @string_value varchar(150)
  DECLARE   @result_set TABLE (idrelated varchar(150) NOT NULL PRIMARY KEY WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON), 
  col1 varchar(50), col2 varchar(50), col3 varchar(50), col4 varchar(50), col5 varchar(50), col6 varchar(50), col7 varchar(50),col8 varchar(50))
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

  DECLARE	@kind varchar(100)
  DECLARE	@rifdoc varchar(200)
  DECLARE	@adate datetime
  DECLARE	@daterif datetime
  DECLARE   @maxincomephase  int
  DECLARE   @maxexpensephase  int

  DECLARE	@incomephase  varchar(50)
  DECLARE   @expensephase  varchar(50)

 
  SELECT @maxincomephase =  MAX(nphase) FROM incomephase 
  SELECT @maxexpensephase =  MAX(nphase) FROM expensephase

  SELECT @incomephase = description from incomephase where nphase =  @maxincomephase
  SELECT @expensephase = description from expensephase where nphase =  @maxexpensephase
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

		  IF (@string_value  is null) 
		  BEGIN
		  --print 1
 				  SELECT @kind = 'Tipo documento ', @rifdoc = 'Imputazione generica ', -- + ' ' +  isnull(@col3,'') + ' #' +isnull(@col4,''), 
			      @adate =  null, @daterif =  null
				  FROM @result_set R
				  WHERE R.idrelated is null
				 -- SET @string_value = isnull(@col1,'') + @delimiter_character + isnull(@col2,'')
		  END

		  --DECLARE	@kind varchar(50)
		  --DECLARE	@rifdoc varchar(100)
		  --DECLARE	@daterif datetime
		  --select * from  @result_set
		  IF (@kind is   null)	 BEGIN
		  --print 2
				  SELECT @kind = 'Contratto occasionale',@rifdoc = 'Contratto occasionale n° ' + isnull(R.col2,'') + '/' + isnull(R.col3,''), 
				  @adate = D.adate, @daterif = D.datecompleted
				  FROM @result_set R
				  JOIN casualcontract D ON ycon = isnull(R.col2,'') AND ncon = isnull(R.col3,'')
				  WHERE R.idrelated = @string_value AND R.col1 = 'cascon'
		  END
		 	 
		  IF (@kind = 'Contratto occasionale')	
		  --print 3
		  BEGIN
			  SELECT @kind = 'Contratto occasionale',@rifdoc =  'Riten ' + T.taxref + ' su contr. occas. n° ' + isnull(R.col2,'') + '/' + isnull(R.col3,''), 
			  @adate = D.adate, @daterif = D.datecompleted
			  FROM @result_set R
			  JOIN casualcontract D ON ycon = isnull(R.col2,'') AND ncon = isnull(R.col3,'')
			  JOIN tax T ON T.taxcode = isnull(R.col5,'')
			  WHERE R.idrelated = @string_value AND R.col1 = 'cascon' AND R.col4 = 'RITEN'
		  END

		  IF (@kind is   null)	
		 --print 4
		  BEGIN
			  SELECT @kind = 'Parcella',@rifdoc = 'Parcella n° ' + isnull(R.col2,'') + '/' + isnull(R.col3,''), 
			  @adate = D.adate, @daterif = D.adate
			  FROM @result_set R
			  JOIN profservice D ON ycon = isnull(R.col2,'') AND ncon = isnull(R.col3,'')
			  WHERE R.idrelated = @string_value AND R.col1 = 'profservice'
		  END

		  IF (@kind is   null)	
		  --print 5
		  BEGIN
			  SELECT @kind = 'Altri compensi',@rifdoc = 'Altri Compensi-Contr. n° ' + isnull(R.col2,'') + '/' + isnull(R.col3,''), 
			  @adate = D.adate, @daterif = D.adate
			  FROM @result_set R
			  JOIN wageaddition D ON ycon = isnull(R.col2,'') AND ncon = isnull(R.col3,'')
			  WHERE R.idrelated = @string_value AND R.col1 = 'wageadd' 
		  END


		    IF (@kind= 'Altri compensi')	
		 --print 6
		  BEGIN
			  SELECT @kind = 'Altri compensi',@rifdoc = 'Riten ' + T.taxref + ' su Altri Compensi - Contr. n° ' +  isnull(R.col2,'') + '/' + isnull(R.col3,''), 
			  @adate = D.adate, @daterif = D.adate
			  FROM @result_set R
			  JOIN wageaddition D ON ycon = isnull(R.col2,'') AND ncon = isnull(R.col3,'')
			  JOIN tax T ON T.taxcode = isnull(R.col5,'')
			  WHERE R.idrelated = @string_value AND R.col1 = 'wageadd' AND R.col4 = 'RITEN'
		  END
		  IF (@kind is   null)	
		  --print 7
		  BEGIN
			  SELECT @kind = 'Missione',@rifdoc = 'Missione n° ' +convert(varchar(14), D.nitineration)+ '/' + convert(varchar(4), D.yitineration), 
			  @adate = D.adate, @daterif = D.datecompleted
			  FROM @result_set R
			  JOIN itineration D ON D.iditineration = isnull(R.col2,'') 
			  WHERE R.idrelated = @string_value AND R.col1 = 'itineration'
		  END

		  IF (@kind is   null)
		  --print 8
		  BEGIN
			  SELECT @kind = 'Cedolino parasub',@rifdoc = 'Cedolino parasub n° ' + convert(varchar(14), D.npayroll) + ' anno fisc.' + convert(varchar(4), D.fiscalyear) + '- Contr. ' + convert (varchar(4),P.ncon) +   '/' + convert (varchar(4), P.ycon), 
			  @adate = P.start, @daterif = D.disbursementdate
			  FROM @result_set R
			  JOIN payroll D ON idpayroll = isnull(R.col2,'')
			  JOIN parasubcontract P ON P.idcon = D.idcon
			  WHERE R.idrelated = @string_value AND R.col1 = 'payroll'
		  END
		  IF (@kind = 'Cedolino parasub')	
		  BEGIN
			  SELECT @kind = 'Cedolino parasub',@rifdoc = 'Riten. ' + T.taxref + ' su cedolino parasub. n° ' + convert(varchar(14), D.npayroll) + ' anno fisc.' + 
							 convert(varchar(4), D.fiscalyear) + '- Contr. ' + convert (varchar(4),P.ncon) +   '/' + convert (varchar(4), P.ycon), 
			  @adate = P.start, @daterif = D.disbursementdate
			  FROM @result_set R
			  JOIN payroll D ON idpayroll = isnull(R.col2,'')
			  JOIN parasubcontract P ON P.idcon = D.idcon
			  JOIN tax T ON T.taxcode = isnull(R.col4,'')
			  WHERE R.idrelated = @string_value AND R.col1 = 'payroll' and R.col3 = 'RITEN'
		  END
		  IF (@kind is   null)	
		  BEGIN
			  SELECT @kind = 'Fattura', @rifdoc = 'Fatt. ' + IK.description +' n° ' +  convert (varchar(4),I.ninv) +   '/' + convert (varchar(4), I.yinv ) +  
			  CASE WHEN isnull(R.col5,'') <>'' THEN ' dett.' + isnull(R.col5,'')  ELSE '' END  ,  
			  @adate = I.adate, @daterif =  I.adate
			  FROM @result_set R
			  LEFT OUTER JOIN invoicedetail D ON D.idinvkind =  isnull(R.col2,'') and yinv =isnull(R.col3,'') and ninv = isnull(R.col4,'')   and rownum = isnull(R.col5,'') 
			  JOIN invoice I  ON I.idinvkind =  isnull(R.col2,'') and I.yinv =isnull(R.col3,'') and I.ninv = isnull(R.col4,'')  
			  JOIN invoicekind IK  ON IK.idinvkind =  isnull(R.col2,'') 
			  WHERE R.idrelated = @string_value AND R.col1 = 'inv'
		  END
		  IF (@kind is   null)	
		  BEGIN
			  SELECT @kind = 'Contratto Passivo', @rifdoc =   'C. Passivo ' + isnull(R.col2,'') + '-' + MK.description + '/' +  isnull(R.col3,'') + ' n° ' + isnull(R.col4,'') + 
			  CASE WHEN isnull(R.col5,'') <>'' THEN ' dett.' + isnull(R.col5,'')  ELSE '' END  , 
			  @adate = M.adate,@daterif = isnull(D.start,M.adate)
			  FROM @result_set R
			  LEFT OUTER JOIN  mandatedetail D ON D.idmankind =  isnull(R.col2,'') and D.yman =isnull(R.col3,'') and D.nman = isnull(R.col4,'')   and D.rownum = isnull(R.col5,'') 
			  JOIN mandate M  ON M.idmankind =  isnull(R.col2,'') and M.yman =isnull(R.col3,'') and M.nman = isnull(R.col4,'')  
			  JOIN mandatekind MK  ON MK.idmankind =  isnull(R.col2,'')  
			  WHERE R.idrelated = @string_value AND R.col1 = 'man'
		  END
		  IF (@kind is   null)	
		 
		  BEGIN
			  SELECT @kind = 'Contratto Attivo', @rifdoc =  'C. Attivo ' + isnull(R.col2,'') + '-' + EK.description + '/'  +  isnull(R.col3,'') + ' n° ' + isnull(R.col4,'') + CASE WHEN isnull(R.col5,'') <>'' THEN ' dett.' + isnull(R.col5,'')  ELSE '' END , 
			  @adate = E.adate, @daterif = isnull(D.start,E.adate)
			  FROM @result_set R
			  LEFT OUTER JOIN estimatedetail D ON D.idestimkind =  isnull(R.col2,'') and D.yestim =isnull(R.col3,'') and D.nestim = isnull(R.col4,'')   and D.rownum = isnull(R.col5,'') 
			  JOIN estimate E  ON E.idestimkind =  isnull(R.col2,'') and E.yestim =isnull(R.col3,'') and E.nestim = isnull(R.col4,'')  
			  JOIN estimatekind EK  ON EK.idestimkind =  isnull(R.col2,'')  
			  WHERE R.idrelated = @string_value AND R.col1 = 'estim'
		  END
		  IF (@kind   IS  null)	
 
 
		  BEGIN
			  SELECT @kind = 'Liquidazione IVA ',@rifdoc = 'Liquid.IVA n° ' + isnull(R.col2,'') + '/' + isnull(R.col3,''), 
			  @adate = D.dateivapay, @daterif = D.dateivapay
			  FROM @result_set R
			  JOIN ivapay D ON yivapay = isnull(R.col2,'') AND nivapay = isnull(R.col3,'')
			  WHERE R.idrelated = @string_value AND R.col1 = 'ivapay'
		  END
		  IF (@kind is null)
		  BEGIN
			  SELECT @kind = 'Fondo economale ',@rifdoc = 'Op. Fondo econ. ' + D.pettycode + ' ' + D.description, 
			  @adate = null, @daterif = null
			  FROM @result_set R
			  JOIN pettycash D ON idpettycash = isnull(R.col2,'')  
			  WHERE R.idrelated = @string_value AND R.col1 = 'foeco'
		  END

		 IF (@kind is null)	
		  BEGIN
			  IF (@col1 = 'csaimport') 
 				  SELECT @kind = 'Importazione CSA Stipendi',@rifdoc = 'Import. CSA Stipendi ' +  convert (varchar(4),D.yimport) + '/ n° ' + convert (varchar(10),D.nimport )+ ' ' + D.description + 
																		+ ' ' + isnull(@col3,'') + ' n° ' + isnull(@col4,'') , -- + ' ' +  isnull(@col3,'') + ' #' +isnull(@col4,''), 
				  @adate = D.adate, @daterif = D.adate
				  FROM @result_set R
				  JOIN csa_import D ON idcsa_import = isnull(R.col2,'')  
				  WHERE R.idrelated = @string_value AND R.col1 = 'csaimport'
				 -- SET @string_value = isnull(@col1,'') + @delimiter_character + isnull(@col2,'')
		  END
		  DECLARE @transmissiondate datetime
		  DECLARE @doc varchar(200)
		  DECLARE @description  varchar(200)
		  IF (@kind is null)	
		  BEGIN
			  IF (@col1 = 'ritenuta') 
			  --- selezione data trasmissione dell'incasso ritenuta
 
			  	  SELECT @transmissiondate =  adate, @doc = doc,@description = description FROM ENTRY WHERE idrelated  like '%protrans%' AND EXISTS(SELECT * FROM  entrydetail 
				  WHERE entry.yentry = entrydetail.yentry and entry.nentry = entrydetail.nentry and 
				  entrydetail.idrelated = @string_value)

 				  SELECT @kind = 'Ritenuta/Contr. ', @rifdoc = @description  + '- Riten./Contr. ' + T.taxref + ' su ' +  EL.phase  + 
																										 convert (varchar(4), EL.ymov ) + ' /n° ' +  convert (varchar(10),EL.nmov) 																			 ,  
				  @adate =  @transmissiondate, @daterif =  @transmissiondate
				  FROM @result_set R
				  JOIN tax T ON T.taxcode = isnull(R.col3,'')
				  JOIN expenselastview EL ON EL.idexp = isnull(R.col2,'')
				  WHERE R.idrelated = @string_value AND R.col1 = 'ritenuta'
				 -- SET @string_value = isnull(@col1,'') + @delimiter_character + isnull(@col2,'')
		  END
		  	  
		  IF (@kind is null)	
		  BEGIN
			  IF (@col1 = 'income') 
			
				 
				  SELECT @transmissiondate =  adate, @doc = doc FROM ENTRY WHERE idrelated  like '%protrans%' AND EXISTS(SELECT * FROM  entrydetail 
				  WHERE entry.yentry = entrydetail.yentry and entry.nentry = entrydetail.nentry and 
				  entrydetail.idrelated = @string_value)

 				  SELECT @kind = 'Distinta trasmissione pagamento/incasso ', @rifdoc = @doc + ' ' + @incomephase + ' '  + convert (varchar(4), T.ymov ) + ' /n° ' +  convert (varchar(10),T.nmov), -- + ' ' +  isnull(@col3,'') + ' #' +isnull(@col4,''), 
				  @adate =  @transmissiondate, @daterif =  @transmissiondate
				  FROM @result_set R
				  JOIN income T ON T.idinc = isnull(R.col2,'')
				  WHERE R.idrelated = @string_value AND R.col1 = 'income'
				 -- SET @string_value = isnull(@col1,'') + @delimiter_character + isnull(@col2,'')
		  END

		  IF (@kind is null)	
		  BEGIN
			  IF (@col1 = 'expense')	
				  SELECT @transmissiondate =  adate, @doc = doc FROM ENTRY WHERE idrelated  like '%paytrans%' AND EXISTS(SELECT * FROM  entrydetail 
				  WHERE entry.yentry = entrydetail.yentry and entry.nentry = entrydetail.nentry and 
				  entrydetail.idrelated = @string_value)

 				  SELECT @kind = 'Distinta trasmissione pagamento/incasso', @rifdoc = @doc + ' ' + @expensephase + ' '   + convert (varchar(4), T.ymov ) + ' /n° ' +  convert (varchar(10),T.nmov) , -- + ' ' +  isnull(@col3,'') + ' #' +isnull(@col4,''), 
			      @adate =  @transmissiondate, @daterif =  @transmissiondate
				  FROM @result_set R
				  JOIN expense T ON T.idexp = isnull(R.col2,'')
				  WHERE R.idrelated = @string_value AND R.col1 = 'expense'
 
		  END

		  IF (@kind is null)	
		  BEGIN
			  IF (@col1 = 'pgiro') 
 				  SELECT @kind = 'Partita di giro libera ', @rifdoc = @expensephase + ' '   + convert (varchar(4), T.ymov ) + ' /n° ' +  convert (varchar(10),T.nmov), -- + ' ' +  isnull(@col3,'') + ' #' +isnull(@col4,''), 
			      @adate =  null, @daterif =  null
				  FROM @result_set R
				  JOIN income T ON T.idinc = isnull(R.col2,'')
				  WHERE R.idrelated = @string_value AND R.col1 = 'pgiro'
				 -- SET @string_value = isnull(@col1,'') + @delimiter_character + isnull(@col2,'')
		  END


		  IF (@kind is null)	
		  BEGIN
			  IF (@col1 = 'upbcommessa') 
				  --declare @31dic20XX datetime
				  --set @31dic20XX = dateadd(yy, isnull(R.col3,'') - 2000, {d '2000-12-31'})
 				  SELECT @kind = 'UPB Commessa Completata ', @rifdoc = 'UPB Commessa completata: '   + convert (varchar(36), U.codeupb ) + ' eserc. ' +  isnull(R.col3,''), -- + ' ' +  isnull(@col3,'') + ' #' +isnull(@col4,''), 
			      @adate =  dateadd(yy, isnull(R.col3,'') - 2000, {d '2000-12-31'}), @daterif =  dateadd(yy, isnull(R.col3,'') - 2000, {d '2000-12-31'})
				  FROM @result_set R
				  JOIN upbcommessa T ON T.idupb = isnull(R.col2,'') AND T.ayear = isnull(R.col3,'') 
				   JOIN upb U ON U.idupb = isnull(R.col2,'')  
				  WHERE R.idrelated = @string_value AND R.col1 = 'upbcommessa'
				 -- SET @string_value = isnull(@col1,'') + @delimiter_character + isnull(@col2,'')
		  END

	 
		  IF (@kind is not null)	
		  BEGIN 

			  INSERT INTO @result (idrelated,kind,rifdoc,docdate, daterif, col1, col2 , col3, col4, col5, col6, col7,col8)   
			  SELECT @string_value, @kind, @rifdoc, @adate,@daterif,  @col1, @col2 , @col3, @col4, @col5, @col6, @col7,@col8
			  SET @col1 = null SET @col2 = null SET @col3 = null SET @col4 = null SET @col5 = null SET @col6 = null SET @col7 = null SET @col8 = null
			  SET @kind = NULL   SET @string_value = NULL  SET @rifdoc = NULL SET @adate = NULL SET @daterif = NULL
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

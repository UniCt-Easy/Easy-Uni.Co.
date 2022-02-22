
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_contoeconomico_coordanal_dm2012]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_contoeconomico_coordanal_dm2012]
GO
	
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

--setuser 'amministrazione'
--exec rpt_contoeconomico_coordanal_dm2012 2018, {ts '2018-01-01 00:00:00'}, {ts '2018-12-31 00:00:00'}, '0001','S',null,'N',null,null
	/*
	se scelgo l'idsor1 e totalizzo i figli
	*/
CREATE PROCEDURE rpt_contoeconomico_coordanal_dm2012
	(
	@ayear int,
	@start datetime,
	@stop datetime,
	@idupb		varchar(36),
	@showchildupb	char(1),
	@idsor1 int,
	@showidsor1child char(1),
	@idsor2 int,
	@idsor3 int ,
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
	)
	AS BEGIN

	DECLARE @idupboriginal varchar(36)
	SET @idupboriginal= @idupb
	IF (@showchildupb = 'S')  AND ISNULL(@idupb,'') <> '%'
	BEGIN
	SET @idupb=@idupb+'%'
	END
	-- Conto Economico Anno Precedente
	DECLARE @firstdayPY datetime
	DECLARE @lastdayPY datetime
	SET @firstdayPY = CONVERT(datetime,'01-01-' + CONVERT(varchar(4),@ayear-1),105)
	SET @lastdayPY = CONVERT(datetime,'31-12-' + CONVERT(varchar(4),@ayear-1),105)
	

	declare @ayearPrec int
	set @ayearPrec = @ayear - 1
	-- Sezione COSTI
	CREATE TABLE #table(
		idsor1 int,
	 PY_C_BVIII1a  	decimal(19,2),
	 PY_C_BVIII1b  		 decimal(19,2),
	 PY_C_BVIII1c  		  decimal(19,2),
	 PY_C_BVIII1d  		 decimal(19,2),
	 PY_C_BVIII1e  		  decimal(19,2),
	 PY_C_BVIII2  		  decimal(19,2),
	 PY_C_BVIII  		  decimal(19,2),
	 PY_C_BIX1  		decimal(19,2),
	 PY_C_BIX2  		  decimal(19,2),
	 PY_C_BIX3  		 decimal(19,2),
	 PY_C_BIX4  		decimal(19,2),
	 PY_C_BIX5  		 decimal(19,2),
	 PY_C_BIX6  		 decimal(19,2),
	 PY_C_BIX7  		  decimal(19,2),
	 PY_C_BIX8  		 decimal(19,2),
	 PY_C_BIX9  		 decimal(19,2),
	 PY_C_BIX10  		 decimal(19,2),
	 PY_C_BIX11  		  decimal(19,2),
	 PY_C_BIX12  		  decimal(19,2),
	 PY_C_BIX  		 decimal(19,2),
	 PY_C_BX1  		  decimal(19,2),
	 PY_C_BX2  		 decimal(19,2),
	 PY_C_BX3  		  decimal(19,2),
	 PY_C_BX4  		  decimal(19,2),
	 PY_C_BX  		 decimal(19,2),
	 PY_C_BXI  		  decimal(19,2),
	 PY_C_BXII  		 decimal(19,2),
	 PY_C_B  		 decimal(19,2),
	 PY_C_C2  		  decimal(19,2),
	 PY_C_C3  		 decimal(19,2),
	 PY_C_C  		 decimal(19,2),
	 PY_C_D2  		 decimal(19,2),
	 PY_C_D  		  decimal(19,2),
	 PY_C_E2  		  decimal(19,2),
	 PY_C_E  		  decimal(19,2),
	 PY_C_F  		  decimal(19,2),
	 PY_TOTCOSTI  		  decimal(19,2),
	 PY_R_AI1  		  decimal(19,2),
	 PY_R_AI2  		 decimal(19,2),
	 PY_R_AI3  		  decimal(19,2),
	 PY_R_AI  		  decimal(19,2),
	 PY_R_AII1  		 decimal(19,2),
	 PY_R_AII2  		 decimal(19,2),
	 PY_R_AII3  		 decimal(19,2),
	 PY_R_AII4  		 decimal(19,2),
	 PY_R_AII5  		 decimal(19,2),
	 PY_R_AII6  		  decimal(19,2),
	 PY_R_AII7  		 decimal(19,2),
	 PY_R_AII  		 decimal(19,2),
	 PY_R_AIII  		  decimal(19,2),
	 PY_R_AIV  		  decimal(19,2),
	 PY_R_AV  		  decimal(19,2),
	 PY_R_AVI  		 decimal(19,2),
	 PY_R_AVII  		decimal(19,2),
	 PY_R_A  		 decimal(19,2),
	 PY_R_C1  		 decimal(19,2),
	 PY_R_C3  		  decimal(19,2),
	 PY_R_C  		  decimal(19,2),
	 PY_R_D1  		  decimal(19,2),
	 PY_R_D  		decimal(19,2),
	 PY_R_E1  		  decimal(19,2),
	 PY_R_E  		  decimal(19,2),
	 PY_TOTRICAVI  		 decimal(19,2),
	
	 C_BVIII1a  	   decimal(19,2),
	 C_BVIII1b  	   decimal(19,2),
	 C_BVIII1c  	   decimal(19,2),
	 C_BVIII1d  	   decimal(19,2),
	 C_BVIII1e  	   decimal(19,2),
	 C_BVIII2  	   decimal(19,2),
	 C_BVIII  	   decimal(19,2),
	 C_BIX1  	   decimal(19,2),
	 C_BIX2  	  decimal(19,2),
	 C_BIX3  	  decimal(19,2),
	 C_BIX4  	   decimal(19,2),
	 C_BIX5  	  decimal(19,2),
	 C_BIX6  	 decimal(19,2),
	 C_BIX7  	  decimal(19,2),
	 C_BIX8  	  decimal(19,2),
	 C_BIX9  	 decimal(19,2),
	 C_BIX11  	  decimal(19,2),
	 C_BIX10  	  decimal(19,2),
	 C_BIX12  	  decimal(19,2),
	 C_BIX  	  decimal(19,2),
	 C_BX1  	  decimal(19,2),
	 C_BX2  	  decimal(19,2),
	 C_BX3  	   decimal(19,2),
	 C_BX4  	  decimal(19,2),
	 C_BX  	   decimal(19,2),
	 C_BXI  	  decimal(19,2),
	 C_BXII  	   decimal(19,2),
	 C_B  	  decimal(19,2),
	 C_C2  	  decimal(19,2),
	 C_C3  	  decimal(19,2),
	 C_C  	   decimal(19,2),
	 C_D2  	  decimal(19,2),
	 C_D  	  decimal(19,2),
	 C_E2  	  decimal(19,2),
	 C_E  	   decimal(19,2),
	 C_F  	  decimal(19,2),
	 TOTCOSTI   decimal(19,2),
	 R_AI1  	  decimal(19,2),
	 R_AI2  	  decimal(19,2),
	 R_AI3  	   decimal(19,2),
	 R_AI  	   decimal(19,2),
	 R_AII1  	   decimal(19,2),
	 R_AII2  	  decimal(19,2),
	 R_AII3  	  decimal(19,2),
	 R_AII4  	  decimal(19,2),
	 R_AII5  	   decimal(19,2),
	 R_AII6  	  decimal(19,2),
	 R_AII7  	  decimal(19,2),
	 R_AII  	  decimal(19,2),
	 R_AIII  	   decimal(19,2),
	 R_AIV  	   decimal(19,2),
	 R_AV  	  decimal(19,2), 	
	 R_AVI  	  decimal(19,2),
	 R_AVII  	   decimal(19,2),
	 R_A  	  decimal(19,2),
	 R_C1  	   decimal(19,2),
	 R_C3  	  decimal(19,2),
	 R_C  	   decimal(19,2),
	 R_D1  	  decimal(19,2),
	 R_D  	   decimal(19,2),
	 R_E1  	   decimal(19,2),
	 R_E  	  decimal(19,2),
	 TOTRICAVI  	   decimal(19,2),
	 C_BVIII1  decimal(19,2)
	
	)

	-->	B) VIII - COSTI DEL PERSONALE
	INSERT INTO #table (PY_C_BVIII1a, idsor1)
	SELECT -SUM(amount),entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	--left outer join sortinglink SLK1
				--on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND	 (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) VIII 1) a)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1

	INSERT INTO #table (PY_C_BVIII1b, idsor1)
	SELECT -SUM(amount),entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) VIII 1) b)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1

	INSERT INTO #table (PY_C_BVIII1c, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount

	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) VIII 1) c)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	
	INSERT INTO #table (PY_C_BVIII1d, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) VIII 1) d)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	INSERT INTO #table (PY_C_BVIII1e, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) VIII 1) e)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	INSERT INTO #table (PY_C_BVIII2, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) VIII 2)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	INSERT INTO #table (PY_C_BVIII, idsor1) 
	SELECT sum(isnull(PY_C_BVIII1a,0) + isnull(PY_C_BVIII1b,0) + isnull(PY_C_BVIII1c,0) + isnull(PY_C_BVIII1d,0) + isnull(PY_C_BVIII1e,0) + isnull(PY_C_BVIII2,0)), 
		idsor1
	from #table
	group by idsor1
	
	--> B) IX - COSTI DELLA GESTIONE CORRENTE
	INSERT INTO #table (PY_C_BIX1, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 1)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	
	INSERT INTO #table (PY_C_BIX2, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 2)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	INSERT INTO #table (PY_C_BIX3, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 3)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1

	INSERT INTO #table (PY_C_BIX4, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 4)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1

	INSERT INTO #table (PY_C_BIX5, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 5)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	INSERT INTO #table (PY_C_BIX6, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 6)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	INSERT INTO #table (PY_C_BIX7, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 7)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
		 
	INSERT INTO #table (PY_C_BIX8, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12)  -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 8)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1

	INSERT INTO #table (PY_C_BIX9, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 9)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	
	INSERT INTO #table (PY_C_BIX10, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 10)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
		 
	INSERT INTO #table (PY_C_BIX11, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 11)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	INSERT INTO #table (PY_C_BIX12, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 12)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	
	
	INSERT INTO #table (PY_C_BIX, idsor1)
	select sum(isnull(PY_C_BIX1,0) + isnull(PY_C_BIX2,0) + isnull(PY_C_BIX3,0) + isnull(PY_C_BIX4,0) + isnull(PY_C_BIX5 ,0)+ isnull(PY_C_BIX6,0)
	+ isnull(PY_C_BIX7,0) + isnull(PY_C_BIX8,0) + isnull(PY_C_BIX9,0)+ isnull(PY_C_BIX10,0) + isnull(PY_C_BIX11,0) + isnull(PY_C_BIX12,0))
	, idsor1
	from #table
	group by idsor1

	-->	B) X - AMMORTAMENTI E SVALUTAZIONI
	
	INSERT INTO #table (PY_C_BX1, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) X 1)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	INSERT INTO #table (PY_C_BX2, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) X 2)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	INSERT INTO #table (PY_C_BX3, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) X 3)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	INSERT INTO #table (PY_C_BX4, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) X 4)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	INSERT INTO #table (PY_C_BX, idsor1)
	select sum(isnull(PY_C_BX1,0) + isnull(PY_C_BX2,0) + isnull(PY_C_BX3,0) + isnull(PY_C_BX4,0) ), idsor1
	from #table
	group by idsor1
	
	--> B) XI - ACCANTONAMENTI PER RISCHI E ONERI
	INSERT INTO #table (PY_C_BXI, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) XI'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	--> B) XII - ONERI DIVERSI DI GESTIONE
	INSERT INTO #table (PY_C_BXII, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) XII'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	
	
	INSERT INTO #table (PY_C_B, idsor1)
	select sum(isnull(PY_C_BVIII,0) + isnull(PY_C_BIX,0) + isnull(PY_C_BX,0) + isnull(PY_C_BXI,0) + isnull(PY_C_BXII,0)), idsor1
	from #table
	group by idsor1
	--> C - PROVENTI E ONERI FINANZIARI
	
	INSERT INTO #table (PY_C_C2, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'C) 2)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	
	INSERT INTO #table (PY_C_C3, idsor1) 
	SELECT SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'C) 3)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	
	 
	INSERT INTO #table (PY_C_C, idsor1)
	select sum(isnull(PY_C_C2,0) + isnull(PY_C_C3,0) ), idsor1
	from #table
	group by idsor1
	
	-->  D - RETTIFICHE DI VALORE DI ATTIVITA' FINANZIARIE
	 
	INSERT INTO #table (PY_C_D2, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'D) 2)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	
	DECLARE @PY_C_D decimal(19,2)
	
	--- il valore viene mostrato positivo in stampa
	-- SET @PY_C_D = @PY_C_D2
	INSERT INTO #table (PY_C_D, idsor1)
	select sum(PY_C_D2), idsor1
	from #table
	group by idsor1

	--> E - PROVENTI E ONERI STRAORDINARI
	 
	INSERT INTO #table (PY_C_E2, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'E) 2)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	DECLARE @PY_C_E decimal(19,2)
	--- il valore viene mostrato positivo in stampa
	-- SET @PY_C_E = @PY_C_E2
	INSERT INTO #table (PY_C_E, idsor1)
	select sum(PY_C_E2), idsor1
	from #table
	group by idsor1
	--> F - IMPOSTE SUL REDDITO DELL'ESERCIZIO CORRENTI, DIFFERITE, ANTICIPATE
 
	INSERT INTO #table (PY_C_F, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'F)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	--DECLARE @PY_TOTCOSTI decimal(19,2)
	--SET @PY_TOTCOSTI = @PY_C_BVIII + @PY_C_BIX + @PY_C_BX +  @PY_C_BXI  + @PY_C_BXII +
	--@PY_C_C + @PY_C_D + @PY_C_E + @PY_C_F -->

	INSERT INTO #table (PY_TOTCOSTI, idsor1) 
	SELECT -SUM(isnull(PY_C_BVIII,0) + isnull(PY_C_BIX,0) + isnull(PY_C_BX ,0)+  isnull(PY_C_BXI,0)  + isnull(PY_C_BXII,0) +
	isnull(PY_C_C,0) + isnull(PY_C_D,0) + isnull(PY_C_E,0) + isnull(PY_C_F,0)  ), idsor1
	from #table
	group by idsor1

	-- Sezione RICAVI
	--> A) I - PROVENTI PROPRI
	
	INSERT INTO #table ( PY_R_AI1, idsor1) SELECT SUM(amount), entrydetail.idsor1	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) I 1)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
		 
	INSERT INTO #table ( PY_R_AI2, idsor1) SELECT SUM(amount), entrydetail.idsor1	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) I 2)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	 
	INSERT INTO #table (PY_R_AI3 , idsor1) SELECT SUM(amount), entrydetail.idsor1	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) I 3)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	--DECLARE @PY_R_AI decimal(19,2)
	--SET @PY_R_AI = @PY_R_AI1 + @PY_R_AI2 + @PY_R_AI3
	INSERT INTO #table (PY_R_AI , idsor1) 
	SELECT sum(isnull(PY_R_AI1,0) + isnull(PY_R_AI2,0) + isnull(PY_R_AI3,0)) , idsor1	
	FROM #table
	group by idsor1

	--> A) II - CONTRIBUTI
	INSERT INTO #table ( PY_R_AII1, idsor1) SELECT SUM(amount), entrydetail.idsor1	
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 1)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
		 
	INSERT INTO #table (PY_R_AII2 , idsor1) SELECT SUM(amount), entrydetail.idsor1	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 2)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 

	INSERT INTO #table (PY_R_AII3 , idsor1) SELECT SUM(amount), entrydetail.idsor1	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 3)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	INSERT INTO #table (PY_R_AII4 , idsor1) SELECT SUM(amount), entrydetail.idsor1	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 4)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
 
	INSERT INTO #table (PY_R_AII5 , idsor1) SELECT SUM(amount), entrydetail.idsor1	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 5)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	 
	INSERT INTO #table ( PY_R_AII6, idsor1) SELECT SUM(amount), entrydetail.idsor1	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 6)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	 
	INSERT INTO #table (PY_R_AII7 , idsor1) SELECT SUM(amount), entrydetail.idsor1	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 7)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	--DECLARE @PY_R_AII decimal(19,2)
	INSERT INTO #table (PY_R_AII, idsor1)
	select sum(isnull(PY_R_AII1,0) + isnull(PY_R_AII2,0) + isnull(PY_R_AII3,0) 
	+ isnull(PY_R_AII4,0) + isnull(PY_R_AII5,0) + isnull(PY_R_AII6,0) + isnull(PY_R_AII7,0)), idsor1
	from #table
	group by idsor1
	
	--> A) III - PROVENTI PER ATTIVITA’ ASSISTENZIALE E SERVIZIO SANITARIO NAZIONALE
 
	INSERT INTO #table (PY_R_AIII , idsor1) SELECT SUM(amount), entrydetail.idsor1	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) III'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	--> A) IV  - PROVENTI PER LA GESTIONE DIRETTA INTERVENTI DIRITTO ALLO STUDIO
	 
	INSERT INTO #table (PY_R_AIV , idsor1) SELECT SUM(amount), entrydetail.idsor1	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) IV'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	--> A) V - ALTRI PROVENTI
 
	INSERT INTO #table (PY_R_AV , idsor1) SELECT SUM(amount), entrydetail.idsor1	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) V'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	--> A) VI VARIAZIONE LAVORI IN CORSO

	INSERT INTO #table (PY_R_AVI , idsor1) SELECT SUM(amount), entrydetail.idsor1	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) VI'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	--> A) VII - INCREMENTO IMMOBILIZZAZIONI PER LAVORI INTERNI
	INSERT INTO #table (PY_R_AVII , idsor1) SELECT SUM(amount), entrydetail.idsor1	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) VII'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	--DECLARE @PY_R_A decimal(19,2)
	--SET @PY_R_A = @PY_R_AI + @PY_R_AII + @PY_R_AIII + @PY_R_AIV + @PY_R_AV + @PY_R_AVI + @PY_R_AVII
	INSERT INTO #table (PY_R_A, idsor1)
	select sum(isnull(PY_R_AI,0) + isnull(PY_R_AII,0) + isnull(PY_R_AIII,0)
	 + isnull(PY_R_AIV,0) + isnull(PY_R_AV,0) + isnull(PY_R_AVI,0) + isnull(PY_R_AVII,0) ), idsor1
	from #table
	group by idsor1
	
	--> C - PROVENTI E ONERI FINANZIARI
	 
	INSERT INTO #table (PY_R_C1 , idsor1) SELECT SUM(amount), entrydetail.idsor1	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'C) 1)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
 
	INSERT INTO #table (PY_R_C3 , idsor1) SELECT SUM(amount), entrydetail.idsor1	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'C) 3)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	INSERT INTO #table (PY_R_C, idsor1)
	select sum(isnull(PY_R_C1,0) + isnull(PY_R_C3,0) ), idsor1
	from #table
	group by idsor1

	--> D - RETTIFICHE DI VALORE DI ATTIVITA' FINANZIARIE
	 
	INSERT INTO #table (PY_R_D1 , idsor1) SELECT SUM(amount), entrydetail.idsor1	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'D) 1)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	
	--DECLARE @PY_R_D decimal(19,2)
	--SET @PY_R_D = @PY_R_D1
	INSERT INTO #table ( PY_R_D, idsor1)
	select sum(PY_R_D1), idsor1
	from #table
	group by idsor1
	--> E - PROVENTI E ONERI STRAORDINARI
 
	INSERT INTO #table ( PY_R_E1, idsor1) SELECT SUM(amount), entrydetail.idsor1	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @firstdayPY AND @lastdayPY
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'E) 1)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayearPrec
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	--DECLARE @PY_R_E decimal(19,2)
	--SET @PY_R_E = @PY_R_E1
	INSERT INTO #table (PY_R_E, idsor1)
	select sum (PY_R_E1), idsor1
	from #table
	group by idsor1

	--DECLARE @PY_TOTRICAVI decimal(19,2)
	--SET @PY_TOTRICAVI = @PY_R_AI + @PY_R_AII + @PY_R_AIII + @PY_R_AIV + @PY_R_AV +@PY_R_AVI + @PY_R_AVII
	--+ @PY_R_C + @PY_R_D + @PY_R_E
	INSERT INTO #table (PY_TOTRICAVI, idsor1)
	select sum( isnull(PY_R_AI,0) + isnull(PY_R_AII,0) + isnull(PY_R_AIII,0) + isnull(PY_R_AIV,0) + isnull(PY_R_AV,0)
	 + isnull(PY_R_AVI,0) + isnull(PY_R_AVII,0)	+ isnull(PY_R_C,0) + isnull(PY_R_D,0) + isnull(PY_R_E,0))
	 , idsor1
	from #table
	group by idsor1
	-- Conto Economico Anno Corrente
	
	-- Sezione COSTI
	
	-->	B) VIII - COSTI DEL PERSONALE
 
	INSERT INTO #table (C_BVIII1a, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	from entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) VIII 1) a)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	INSERT INTO #table (C_BVIII1b, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) VIII 1) b)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	 
	INSERT INTO #table (C_BVIII1, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) VIII 1) c)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 

	
	INSERT INTO #table (C_BVIII1d, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) VIII 1) d)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
 
	INSERT INTO #table (C_BVIII1e, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) VIII 1) e)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	 
	INSERT INTO #table (C_BVIII2, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) VIII 2)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	--DECLARE @C_BVIII decimal(19,2)
	--SET @C_BVIII = @C_BVIII1a + @C_BVIII1b + @C_BVIII1c +@C_BVIII1d + @C_BVIII1e + @C_BVIII2
	INSERT INTO #table (C_BVIII, IDSOR1)
	SELECT SUM( isnull(C_BVIII1a ,0)+ isnull(C_BVIII1b,0) + isnull(C_BVIII1c,0) + isnull(C_BVIII1d,0)
	 + isnull(C_BVIII1e,0) + isnull(C_BVIII2,0) ), idsor1
	FROM #table
	group by idsor1
	
	--> B) IX - COSTI DELLA GESTIONE CORRENTE
 
	INSERT INTO #table (C_BIX1, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 1)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	 
	INSERT INTO #table (C_BIX2, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 2)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	INSERT INTO #table (C_BIX, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 3)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	INSERT INTO #table (C_BIX4, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 4)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	 
	INSERT INTO #table (C_BIX5, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 5)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	 
	INSERT INTO #table (C_BIX6, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 6)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	INSERT INTO #table (C_BIX7, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 7)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	INSERT INTO #table (C_BIX8, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 8)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	INSERT INTO #table (C_BIX9, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 9)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	INSERT INTO #table (C_BIX10, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 10)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	
	INSERT INTO #table (C_BIX11, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 11)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	INSERT INTO #table (C_BIX12, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) IX 12)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	
	-- DECLARE @C_BIX decimal(19,2)
	-- SET @C_BIX = @C_BIX1 + @C_BIX2 + @C_BIX3 + @C_BIX4 + @C_BIX5 + @C_BIX6
	-- + @C_BIX7 + @C_BIX8 + @C_BIX9+ @C_BIX10 + @C_BIX11 + @C_BIX12
	INSERT INTO #table (C_BIX,idsor1)
	select sum( isnull(C_BIX1,0) + isnull(C_BIX2,0) + isnull(C_BIX3,0) + isnull(C_BIX4,0) + isnull(C_BIX5,0) + isnull(C_BIX6,0)
	+ isnull(C_BIX7,0) + isnull(C_BIX8,0) + isnull(C_BIX9,0)+ isnull(C_BIX10,0) + isnull(C_BIX11,0) + isnull(C_BIX12,0) ), idsor1
	from #table
	group by idsor1
	-->	B) X - AMMORTAMENTI E SVALUTAZIONI
	
	INSERT INTO #table (C_BX1, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) X 1)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	INSERT INTO #table (C_BX2, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) X 2)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	INSERT INTO #table (C_BX3, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) X 3)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	INSERT INTO #table (C_BX4, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) X 4)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	--DECLARE @C_BX decimal(19,2)
	--SET @C_BX = @C_BX1 + @C_BX2 + @C_BX3 + @C_BX4
	INSERT INTO #table (C_BX, idsor1)
	select sum (isnull(C_BX1,0) + isnull(C_BX2,0) + isnull(C_BX3,0) + isnull(C_BX4,0)), idsor1
	from #table
	group by idsor1
	--> B) XI - ACCANTONAMENTI PER RISCHI E ONERI
	INSERT INTO #table (C_BXI, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) XI'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	--> B) XII - ONERI DIVERSI DI GESTIONE
	INSERT INTO #table (C_BXII, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'B) XII'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	--DECLARE @C_B decimal(19,2)
	--SET @C_B = @C_BVIII + @C_BIX + @C_BX + @C_BXI + @C_BXII
	
	INSERT INTO #table (C_B, idsor1)
	select sum(isnull(C_BVIII,0) + isnull(C_BIX,0) + isnull(C_BX,0) + isnull(C_BXI,0) + isnull(C_BXII,0) ),idsor1
	from #table
	group by idsor1

	--> C - PROVENTI E ONERI FINANZIARI
	INSERT INTO #table (C_C2, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'C) 2)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	INSERT INTO #table (C_C3, idsor1)
	SELECT SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'C) 3)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	--DECLARE @C_C decimal(19,2)
	--SET @C_C = @C_C2 + @C_C3
	INSERT INTO #table (C_C, idsor1)
	select sum(isnull(C_C2,0) + isnull(C_C3,0) ), idsor1
	from #table
	group by idsor1

	-->  D - RETTIFICHE DI VALORE DI ATTIVITA' FINANZIARIE

	INSERT INTO #table (C_D2, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'D) 2)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	
	--DECLARE @C_D decimal(19,2)
	--SET @C_D = @C_D2
	insert into #table(C_D, idsor1)
	select sum(C_D2), idsor1
	from #table
	group by idsor1

	--> E - PROVENTI E ONERI STRAORDINARI
	INSERT INTO #table (C_E2, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'E) 2)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	--DECLARE @C_E decimal(19,2)
	--SET @C_E = @C_E2
	insert into #table(C_E, idsor1)
	select sum(C_E2),idsor1
	from #table
	group by idsor1

	--> F - IMPOSTE SUL REDDITO DELL'ESERCIZIO CORRENTI, DIFFERITE, ANTICIPATE
	INSERT INTO #table (C_F, idsor1) SELECT -SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount =  'F)'
	AND placcount.placcpart = 'C'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	--DECLARE @TOTCOSTI decimal(19,2)
	--SET @TOTCOSTI = @C_BVIII + @C_BIX + @C_BX +  @C_BXI  + @C_BXII +
	--@C_C + @C_D + @C_E + @C_F
	INSERT INTO #table (TOTCOSTI, idsor1)
	select sum(isnull(C_BVIII,0) + isnull(C_BIX,0) + isnull(C_BX,0) +  isnull(C_BXI,0)  
	+ isnull(C_BXII,0) + isnull(C_C,0) + isnull(C_D,0) + isnull(C_E,0) + isnull(C_F,0) ), idsor1
	from #table
	group by idsor1

	-- Sezione RICAVI
	--> A) I - PROVENTI PROPRI
	
	INSERT INTO #table (R_AI1, idsor1)
	SELECT SUM(amount), entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) I 1)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	INSERT INTO #table (R_AI2, idsor1)
	SELECT SUM(amount),entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) I 2)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	INSERT INTO #table (R_AI3 , idsor1)
	SELECT SUM(amount),entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) I 3)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	--DECLARE @R_AI decimal(19,2)
	--SET @R_AI = @R_AI1 + @R_AI2 + @R_AI3
	INSERT INTO #table (R_AI , idsor1)
	select sum(isnull(R_AI1,0) + isnull(R_AI2,0) + isnull(R_AI3,0) ),idsor1
	from #table
	group by idsor1

	--> A) II - CONTRIBUTI

	INSERT INTO #table (R_AII1 , idsor1)
	SELECT SUM(amount),entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 1)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	INSERT INTO #table (R_AII2 , idsor1)
	SELECT SUM(amount),entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 2)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 

	INSERT INTO #table (R_AII3 , idsor1)
	SELECT SUM(amount),entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 3)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	INSERT INTO #table (R_AII4 , idsor1)
	SELECT SUM(amount),entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 4)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	INSERT INTO #table (R_AII5 , idsor1)
	SELECT SUM(amount),entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 5)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 

	INSERT INTO #table (R_AII6 , idsor1)
	SELECT SUM(amount),entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 6)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	INSERT INTO #table (R_AII7 , idsor1)
	SELECT SUM(amount),entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) II 7)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	--DECLARE @R_AII decimal(19,2)
	--SET @R_AII = @R_AII1 + @R_AII2 + @R_AII3 + @R_AII4 + @R_AII5 + @R_AII6 + @R_AII7
	INSERT INTO #table (R_AII , idsor1)
	select sum( isnull(R_AII1,0) + isnull(R_AII2,0) + isnull(R_AII3,0) + isnull(R_AII4,0) 
	+ isnull(R_AII5,0) + isnull(R_AII6,0) + isnull(R_AII7,0) ), idsor1
	from #table
	group by idsor1

	--> A) III - PROVENTI PER ATTIVITA’ ASSISTENZIALE E SERVIZIO SANITARIO NAZIONALE
	INSERT INTO #table (R_AIII , idsor1)
	SELECT SUM(amount),entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) III'
	AND placcount.placcpart = 'R'
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	--> A) IV  - PROVENTI PER LA GESTIONE DIRETTA INTERVENTI DIRITTO ALLO STUDIO
	INSERT INTO #table (R_AIV , idsor1)
	SELECT SUM(amount),entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) IV'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	--> A) V - ALTRI PROVENTI
	INSERT INTO #table (R_AV , idsor1)
	SELECT SUM(amount),entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) V'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	--> A) VI VARIAZIONE LAVORI IN CORSO
	INSERT INTO #table (R_AVI , idsor1)
	SELECT SUM(amount),entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) VI'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	--> A) VII - INCREMENTO IMMOBILIZZAZIONI PER LAVORI INTERNI
	INSERT INTO #table (R_AVII , idsor1)
	SELECT SUM(amount),entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'A) VII'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	--DECLARE @R_A decimal(19,2)
	--SET @R_A = @R_AI + @R_AII + @R_AIII + @R_AIV + @R_AV + @R_AVI + @R_AVII
	INSERT INTO #table (R_A , idsor1)
	select sum(isnull(R_AI,0) + isnull(R_AII,0) + isnull(R_AIII,0) + isnull(R_AIV,0) 
	+ isnull(R_AV,0) + isnull(R_AVI,0) + isnull(R_AVII,0)), idsor1
	from #table
	group by idsor1
	--> C - PROVENTI E ONERI FINANZIARI
	INSERT INTO #table (R_C1 , idsor1)
	SELECT SUM(amount)	,entrydetail.idsor1		--> RIMOSSO IL SEGNO MENO
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'C) 1)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	INSERT INTO #table (R_C3  , idsor1)
	SELECT SUM(amount),entrydetail.idsor1
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'C) 3)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	
	--DECLARE @R_C decimal(19,2)
	--SET @R_C = @R_C1 + @R_C3
	INSERT INTO #table (R_C , idsor1)
	select sum(isnull(R_C1 ,0)+ isnull(R_C3,0) ), idsor1
	from #table
	group by idsor1

	--> D - RETTIFICHE DI VALORE DI ATTIVITA' FINANZIARIE
	INSERT INTO #table (R_D1 , idsor1)
	SELECT SUM(amount)	,entrydetail.idsor1			--> RIMOSSO IL SEGNO MENO
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'D) 1)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	--DECLARE @R_D decimal(19,2)
	--SET @R_D = @R_D1
	INSERT INTO #table (R_D , idsor1)
	select sum(R_D1), idsor1
	from #table
	group by idsor1

	---qua
	--> E - PROVENTI E ONERI STRAORDINARI
	INSERT INTO #table ( R_E1, idsor1)
	SELECT SUM(amount)	,entrydetail.idsor1			--> RIMOSSO IL SEGNO MENO
	FROM entrydetail
	JOIN entry
	ON entry.yentry = entrydetail.yentry
	AND entry.nentry = entrydetail.nentry
	JOIN account
	ON account.idacc = entrydetail.idacc
	-- left outer JOIN upb
	-- ON upb.idupb  = entrydetail.idupb
	JOIN placcount
	ON placcount.idplaccount = account.idplaccount
	-- left outer join sortinglink SLK1 on SLK1.idchild = entrydetail.idsor1 
	WHERE entry.adate BETWEEN @start AND @stop
	AND  (entrydetail.idupb like @idupb  OR @idupb = '%')
	AND entry.identrykind  not in (6,11,12) -- DEVO ESCLUDERE LE SCRITTURE DI EPILOGO
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE
	AND placcount.codeplaccount = 'E) 1)'
	AND placcount.placcpart = 'R'
	AND (@idsor2 IS NULL OR entrydetail.idsor2 = @idsor2)AND (@idsor3 IS NULL OR entrydetail.idsor3 = @idsor3)
	AND placcount.ayear = @ayear
	AND (@idsor01 IS NULL OR entry.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR entry.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR entry.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR entry.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR entry.idsor05 = @idsor05)
	group by entrydetail.idsor1
	 
	--DECLARE @R_E decimal(19,2)
	--SET @R_E = @R_E1
	INSERT INTO #table (R_E , idsor1)
	select sum(R_E1), idsor1
	from #table
	group by idsor1

	--DECLARE @TOTRICAVI decimal(19,2)
	--SET @TOTRICAVI = @R_AI + @R_AII + @R_AIII + @R_AIV + @R_AV +@R_AVI + @R_AVII
	--+ @R_C + @R_D + @R_E
	INSERT INTO #table (TOTRICAVI , idsor1)
	select sum(isnull(R_AI,0) + isnull(R_AII,0) + isnull(R_AIII,0) + isnull(R_AIV,0) + isnull(R_AV,0) +isnull(R_AVI,0)
	 + isnull(R_AVII,0)	+ isnull(R_C ,0)+ isnull(R_D,0) + isnull(R_E,0) ), idsor1
	from #table
	group by idsor1

	DECLARE @codeupb	varchar(50)
	DECLARE @title		varchar(150)
	
	SELECT	@codeupb = codeupb,
	@title = title
	FROM	upb
	WHERE	idupb = @idupboriginal
	
	SELECT
	@ayear				  AS ayear         ,
	@idupboriginal		  as idupb         ,
	@codeupb				  as codeupb	   ,
	@title				  as upb		   ,
	 isnull( sum(PY_C_BVIII1a),0)  	  as PY_C_BVIII1a,
	 isnull( sum(PY_C_BVIII1b),0)  	 as PY_C_BVIII1b,
	 isnull( sum(PY_C_BVIII1c),0)  	 as PY_C_BVIII1c,
	 isnull( sum(PY_C_BVIII1d),0)  	 as PY_C_BVIII1d,
	 isnull( sum(PY_C_BVIII1e),0)  	 as PY_C_BVIII1e,
	 isnull( sum(PY_C_BVIII2),0)  	 as PY_C_BVIII2,
	 isnull( sum(PY_C_BVIII),0)  	 as PY_C_BVIII,
	 isnull( sum(PY_C_BIX1),0)  	 as PY_C_BIX1,  		 
	 isnull( sum(PY_C_BIX2),0)  	 as PY_C_BIX2,
	 isnull( sum(PY_C_BIX3),0)  	 as PY_C_BIX3,
	 isnull( sum(PY_C_BIX4),0)  	 as PY_C_BIX4,
	 isnull( sum(PY_C_BIX5),0)  	 as PY_C_BIX5,
	 isnull( sum(PY_C_BIX6),0)  	 as PY_C_BIX6,
	 isnull( sum(PY_C_BIX7),0)  	 as PY_C_BIX7,
	 isnull( sum(PY_C_BIX8),0)  	 as PY_C_BIX8,
	 isnull( sum(PY_C_BIX9),0)  	 as PY_C_BIX9,
	 isnull( sum(PY_C_BIX10),0)  	 as PY_C_BIX10,
	 isnull( sum(PY_C_BIX11),0)  	 as PY_C_BIX11,
	 isnull( sum(PY_C_BIX12),0)  	 as PY_C_BIX12,
	 isnull( sum(PY_C_BIX),0)  	 as PY_C_BIX,
	 isnull( sum(PY_C_BX1),0)  	 as PY_C_BX1,
	 isnull( sum(PY_C_BX2),0)  	 as PY_C_BX2,
	 isnull( sum(PY_C_BX3),0)  	 as PY_C_BX3,
	 isnull( sum(PY_C_BX4),0)  	as PY_C_BX4 ,
	 isnull( sum(PY_C_BX),0)  	as PY_C_BX ,
	 isnull( sum(PY_C_BXI),0)  	 as PY_C_BXI,
	 isnull( sum(PY_C_BXII),0)  as PY_C_BXII	 ,
	 isnull( sum(PY_C_B),0)  	as PY_C_B ,
	 isnull( sum(PY_C_C2),0)  	as PY_C_C2 ,
	 isnull( sum(PY_C_C3),0)  	as PY_C_C3 ,
	 isnull( sum(PY_C_C),0)  as PY_C_C	 ,
	 isnull( sum(PY_C_D2),0)  as PY_C_D2	 ,
	 isnull( sum(PY_C_D),0)  as PY_C_D	 ,
	 isnull( sum(PY_C_E2),0)  as PY_C_E2	 ,
	 isnull( sum(PY_C_E),0)  as PY_C_E	 ,
	 isnull( sum(PY_C_F),0)  as PY_C_F	 ,
	 isnull( sum(PY_TOTCOSTI),0) as PY_TOTCOSTI 	 ,
	 isnull( sum(PY_R_AI1),0)  	 as PY_R_AI1,
	 isnull( sum(PY_R_AI2),0) as PY_R_AI2 	 ,
	 isnull( sum(PY_R_AI3),0)  as PY_R_AI3	 ,
	 isnull( sum(PY_R_AI),0) as PY_R_AI 	 ,
	 isnull( sum(PY_R_AII1),0)  	as PY_R_AII1 ,
	 isnull( sum(PY_R_AII2),0)  as PY_R_AII2	 ,
	 isnull( sum(PY_R_AII3),0)  as PY_R_AII3	 ,
	 isnull( sum(PY_R_AII4),0)  as PY_R_AII4	 ,
	 isnull( sum(PY_R_AII5),0)  as PY_R_AII5	 ,
	 isnull( sum(PY_R_AII6),0)  as PY_R_AII6	 ,
	 isnull( sum(PY_R_AII7),0)  as PY_R_AII7	 ,
	 isnull( sum(PY_R_AII),0)  as PY_R_AII	 ,
	 isnull( sum(PY_R_AIII),0) as PY_R_AIII 	 ,
	 isnull( sum(PY_R_AIV),0)  	as PY_R_AIV ,
	 isnull( sum(PY_R_AV),0)  as 	PY_R_AV ,
	 isnull( sum(PY_R_AVI),0) as PY_R_AVI 	 ,
	 isnull( sum(PY_R_AVII),0) as PY_R_AVII 	 ,
	 isnull( sum(PY_R_A),0)  	as PY_R_A ,
	 isnull( sum(PY_R_C1),0)  	as PY_R_C1 ,
	 isnull( sum(PY_R_C3),0)  	as PY_R_C3 ,
	 isnull( sum(PY_R_C),0)  	as PY_R_C ,
	 isnull( sum(PY_R_D1),0)  	as PY_R_D1 ,
	 isnull( sum(PY_R_D),0)  as PY_R_D	 ,
	 isnull( sum(PY_R_E1),0)  as PY_R_E1	 ,
	 isnull( sum(PY_R_E),0)  	as PY_R_E ,
	 isnull( sum(PY_TOTRICAVI),0)  as PY_TOTRICAVI	 ,
	
	 isnull( sum(C_BVIII1a),0)  as C_BVIII1a	 ,
	 isnull( sum(C_BVIII1b),0)  as C_BVIII1b	 ,
	 isnull( sum(C_BVIII1c),0) as C_BVIII1c 	 ,
	 isnull( sum(C_BVIII1d),0)  as C_BVIII1d	 ,
	 isnull( sum(C_BVIII1e),0) as C_BVIII1e 	 ,
	 isnull( sum(C_BVIII2),0) as C_BVIII2 	 ,
	 isnull( sum(C_BVIII),0)  as C_BVIII	 ,
	 isnull( sum(C_BIX1),0)  	 as C_BIX1,
	 isnull( sum(C_BIX2),0)  	as C_BIX2 ,
	 isnull( sum(C_BIX3),0)  	as C_BIX3 ,
	 isnull( sum(C_BIX4),0)  	as C_BIX4 ,
	 isnull( sum(C_BIX5),0) as	C_BIX5 ,
	 isnull( sum(C_BIX6),0)  as	C_BIX6 ,
	 isnull( sum(C_BIX7),0)  as	C_BIX7 ,
	 isnull( sum(C_BIX8),0)  as	C_BIX8 ,
	 isnull( sum(C_BIX9),0)  as	C_BIX9 ,
	 isnull( sum(C_BIX11),0) as 	 C_BIX11,
	 isnull( sum(C_BIX10),0) as 	C_BIX10 ,
	 isnull( sum(C_BIX12),0) as 	 C_BIX12,
	 isnull( sum(C_BIX),0)  as	 C_BIX,
	 isnull( sum(C_BX1),0)  as	 C_BX1,
	 isnull( sum(C_BX2),0)  as	 C_BX2,
	 isnull( sum(C_BX3),0)  as	 C_BX3,
	 isnull( sum(C_BX4),0)  as	C_BX4 ,
	 isnull( sum(C_BX),0)  as	 C_BX,
	 isnull( sum(C_BXI),0)  as	 C_BXI,
	 isnull( sum(C_BXII),0) as 	C_BXII ,
	 isnull( sum(C_B),0) as 	C_B ,
	 isnull( sum(C_C2),0)  as	C_C2 ,
	 isnull( sum(C_C3),0) as 	C_C3 ,
	 isnull( sum(C_C),0) as 	 C_C,
	 isnull( sum(C_D2),0) as 	C_D2 ,
	 isnull( sum(C_D),0)  as	 C_D,
	 isnull( sum(C_E2),0) as 	C_E2 ,
	 isnull( sum(C_E),0)  as	C_E ,
	 isnull( sum(C_F),0)  as	 C_F,
	 isnull( sum(TOTCOSTI),0)  as	 TOTCOSTI,
	 isnull( sum(R_AI1),0)  	as R_AI1 ,
	 isnull( sum(R_AI2),0)  as	R_AI2 ,
	 isnull( sum(R_AI3),0) as 	R_AI3 ,
	 isnull( sum(R_AI),0)  as	R_AI ,
	 isnull( sum(R_AII1),0)  as	R_AII1 ,
	 isnull( sum(R_AII2),0)  as	R_AII2 ,
	 isnull( sum(R_AII3),0) as  R_AII3	 ,
	 isnull( sum(R_AII4),0) as 	R_AII4 ,
	 isnull( sum(R_AII5),0) as 	R_AII5 ,
	 isnull( sum(R_AII6),0)  as	R_AII6 ,
	 isnull( sum(R_AII7),0) as 	R_AII7 ,
	 isnull( sum(R_AII),0)  as	R_AII ,
	 isnull( sum(R_AIII),0) as 	 R_AIII,
	 isnull( sum(R_AIV),0)  as	 R_AIV,
	 isnull( sum(R_AV),0) as 	R_AV ,
	 isnull( sum(R_AVI),0)  	as R_AVI,
	 isnull( sum(R_AVII),0)  as	 R_AVII,
	 isnull( sum(R_A),0) as 	 R_A ,
	 isnull( sum(R_C1),0) as  	R_C1 ,
	 isnull( sum(R_C3 ),0)  as	R_C3 ,
	 isnull( sum(R_C),0) as	R_C ,
	 isnull( sum(R_D1),0)as  R_D1	 ,
	 isnull( sum(R_D),0) as 	R_D ,
	 isnull( sum(R_E1),0)as  	R_E1 ,
	 isnull( sum(R_E),0) as 	 R_E,
	 isnull( sum(TOTRICAVI),0)  	as TOTRICAVI ,
	 S1.sortcode as sortcode1,
	 S1.description as titlecode1
	 from #table T
	 left outer join sorting S1
	 on T.idsor1 = S1.idsor
	group by  S1.sortcode,
	 S1.description
	
	
	
	
	
	
	
	END
	GO
	
	SET QUOTED_IDENTIFIER OFF
	GO
	SET ANSI_NULLS ON
	GO
	
	
	
	
	--exec rpt_contoeconomico_coordanal_dm2012 2018, {ts '2018-01-01 00:00:00'}, {ts '2018-12-31 00:00:00'}, '0001','S',null,'N',null,null

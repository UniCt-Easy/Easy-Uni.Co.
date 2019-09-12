if exists (select * from dbo.sysobjects where id = object_id(N'[exp_unified_invoicedet_prorata]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_unified_invoicedet_prorata]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
CREATE  PROCEDURE [exp_unified_invoicedet_prorata] 
(
		@year int
)
AS
BEGIN

-- [compute_unified_prorata] 2011
CREATE TABLE #invoicedet
	(
		iddbdepartment varchar(50),
		dbdepartment varchar(150),
		idinvkind int,
		yinv int,
		ninv int,
		rownum int,
		adate datetime,
		registerclass char(1), --tipo registro A/V
		kind char(1), --tipo fattura A/V
		flagvariation char(1),
		flagintracom char(1),
		taxabletotal decimal(19,2),
		idivaregisterkindunified int, 
		codeivaregisterkind varchar(20),
		codeivakind varchar(20)
	)
	
	CREATE TABLE #groupbyivakind
	(
		iddbdepartment varchar(50),
		dbdepartment varchar(150),
		codeivakind varchar(20),
		description varchar(50),
		numerator char(1),
		denominator char(1),
		taxabletotal decimal(19,2)
	)
	
	-------------------------------------------------------
	------------ LETTURA DAI DIPARTIMENTI -----------------
	-------------------------------------------------------
	
	declare @iddbdepartment varchar(50)
	declare @dbdepartment varchar(200)
	declare @crsdepartment cursor
	set 	@crsdepartment = cursor for select  iddbdepartment,description from dbdepartment
	where (start is null or start <= @year ) AND ( stop is null or stop >= @year)
	open 	@crsdepartment
	fetch next from @crsdepartment into @iddbdepartment, @dbdepartment
	while @@fetch_status=0 begin
		declare @dip_nomesp varchar(300)
		set @dip_nomesp = @iddbdepartment + '.[exp_invoicedet_prorata]'
		
		INSERT INTO #invoicedet
		(	
			iddbdepartment,
			dbdepartment,
			idinvkind,
			yinv,
			ninv,
			rownum,
			adate,
			registerclass, --tipo registro A/V
			kind, --tipo fattura A/V
			flagvariation,
			flagintracom,
			taxabletotal,
			idivaregisterkindunified, 
			codeivaregisterkind,
			codeivakind
		)

		exec @dip_nomesp @year 
		
		update  #invoicedet set iddbdepartment = @iddbdepartment, dbdepartment = @dbdepartment
		where iddbdepartment is null
		fetch next from @crsdepartment into @iddbdepartment,@dbdepartment
	END
	
	-- A questo punto devo cambiare il segno dell'imponibile di alcuni dettagli fattura
	-- in base a registerclass/kind/flagvariation
		update #invoicedet set taxabletotal=-taxabletotal 
		where registerclass<>kind AND flagintracom = 'N'

		update #invoicedet set taxabletotal=-taxabletotal 
		where flagvariation='S'
		
	SELECT 
	iddbdepartment, 
	#invoicedet.codeivakind,
	ivakind.description,
	CASE
		WHEN ((ivakind.flag&8)<>0) THEN 'S' 
		ELSE 'N'
	END,
	CASE
		WHEN ((ivakind.flag&16)<>0) THEN 'S' 
		ELSE 'N'
	END,
	SUM(taxabletotal)
	FROM #invoicedet 
	JOIN ivakind -- fa fede la configurazione dell'amministrazione
		ON ivakind.codeivakind = #invoicedet.codeivakind
	GROUP BY iddbdepartment,
	#invoicedet.codeivakind,ivakind.flag,ivakind.description
	order by  iddbdepartment,
	#invoicedet.codeivakind,ivakind.flag,ivakind.description
DROP TABLE #invoicedet
DROP TABLE #groupbyivakind
END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

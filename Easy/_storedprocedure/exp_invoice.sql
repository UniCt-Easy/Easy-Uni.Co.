
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


if exists (select * from dbo.sysobjects where id = object_id(N'[exp_invoice]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_invoice]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  PROCEDURE exp_invoice(
	@year 			int,
	@start 			smalldatetime,
	@stop 			smalldatetime,
	@idivaregisterkind 	int,
	@idinvkind 		int,
	@deferred 		char(1) --(D = Solo fatture ad iva Differita, I = solo fatture ad iva Immediata, T = Tutte)
) 
AS BEGIN
-- exec exp_invoice '2015', {ts '2015-01-01 00:00:00.000'}, {ts '2015-12-31 00:00:00.000'}, null, null, 'T'

	CREATE TABLE #invoice
	(	
		idinvkind int,
		invoicekind varchar(50),
		yinv int,
		ninv int,
		flagdeferred char(1),
		flagbuysell char(1),
		doc varchar(35),
		docdate smalldatetime,	
		registry varchar(100),
		description varchar(150),
		taxabletotal decimal(19,2),
		ivatotal decimal(19,2),
		linked decimal(19,2),
		residual decimal(19,2),
		ivatotalpayed decimal(19,2),
		ivaregister varchar (2000),
		movlinked varchar(2000),
		active  char(1),
		invoice_main varchar(800),
		stampkind varchar(200)
	)
	

	CREATE TABLE #invoicecontab
	(	
		idinvkind int,
		yinv int,
		ninv int,
		ymov int,
		nmov int,
		phase varchar(50),
		ypaypro int,
		npaypro int
	)
 	-- insert dei movimenti finanziari che contabilizzano le fatture
	
	
	CREATE TABLE #invoiceregister
	(	
		idinvkind int,
		yinv int,
		ninv int,
		ivaregisterkind varchar (50),
		yivaregister int,
		nivaregister int,
		protocolnum int
	)
	
	INSERT INTO #invoice
	(
		idinvkind,
		invoicekind,
		yinv,
		ninv,
		flagdeferred,
		flagbuysell,
		doc,
		docdate,	
		registry,
		description,
		taxabletotal,
		ivatotal,
		linked,
		residual,
		ivatotalpayed,
		active,
		stampkind
	)
	SELECT 
		I.idinvkind,
		IK.description,
		I.yinv,
		I.ninv,
		I.flagdeferred, 
		CASE
			WHEN ((IK.flag&1)=0) THEN 'A'--flagbuysell
			WHEN ((IK.flag&1)<>0) THEN 'V'
		END,  
		I.doc,
		I.docdate,
		MAX(IR.registry),
		I.description,
		SUM(IR.taxabletotal), 
		SUM(IR.ivatotal), 
		SUM(ISNULL(IR.linkeddocum,0) + ISNULL(IR.linkedimpon,0) + ISNULL(IR.linkedimpos,0)),
		SUM(IR.residual),
		SUM(IDF.ivatotalpayed),
		I.active,
		case when (idstampkind = 'no') then 'Fattura non soggetta a bollo'
			when (idstampkind = 'dm19_2014')  then 'Fattura soggetta ad imposta di bollo € 2,00'
			else null end 
		FROM invoiceresidual  IR
		JOIN invoiceview I 
			ON  I.idinvkind = IR.idinvkind
			AND I.yinv = IR.yinv
			AND I.ninv = IR.ninv 
		JOIN invoicekind  IK
			ON I.idinvkind = IK.idinvkind
		LEFT OUTER JOIN invoicedeferred IDF 
			ON IDF.idinvkind = I.idinvkind
			AND IDF.yinv = I.yinv
			AND IDF.ninv = I.ninv 
		WHERE I.yinv = @year 
		AND I.adate between @start AND @stop 
		AND (I.idinvkind = @idinvkind OR @idinvkind is null)
		AND ((EXISTS (SELECT * FROM ivaregister IRG 
			      WHERE IRG.idinvkind = I.idinvkind
				AND IRG.yinv = I.yinv
				AND IRG.ninv = I.ninv 
				AND IRG.idivaregisterkind = @idivaregisterkind
				AND @idivaregisterkind IS NOT NULL))  
		     OR (@idivaregisterkind is null))
		AND ((I.flagdeferred = 'S' AND @deferred = 'D') OR 
	             (I.flagdeferred = 'N' AND @deferred = 'I') OR 
		     (@deferred = 'T'))
		GROUP BY IR.idinvkind, IR.yinv, IR.ninv, 
			 I.idinvkind,IK.description,I.yinv,I.ninv,
			 I.flagdeferred, IK.flag,I.doc,I.docdate,
			 I.description, IDF.idinvkind,IDF.yinv,IDF.ninv,I.active, I.idstampkind
			
update  #invoice set   linked=isnull(taxabletotal,0)+isnull(ivatotal,0), 
			residual=0 
		where active='N'

create table #InvoiceMain(ninv	int,yinv smallint, idinvkind int, ninv_main	int,yinv_main	smallint, idinvkind_main int, invkind_main varchar(50))
insert into #InvoiceMain(ninv, yinv, idinvkind, ninv_main, yinv_main, idinvkind_main, invkind_main)
select ID.ninv, ID.yinv, ID.idinvkind, ID.ninv_main, ID.yinv_main, ID.idinvkind_main, IK.description
from invoicedetail ID
JOIN 	#invoice I
	ON ID.idinvkind = I.idinvkind
	AND ID.yinv = I.yinv
	AND ID.ninv = I.ninv  
join invoicekind IK
	on ID.idinvkind_main = IK.idinvkind
group by ID.ninv, ID.yinv, ID.idinvkind, ID.ninv_main, ID.yinv_main, ID.idinvkind_main, IK.description

DECLARE @ninv01	int
declare @yinv01 smallint
declare @idinvkind01 int
DECLARE @ninv01_main	int
declare @yinv01_main smallint
declare @idinvkind01_main int
declare @invkind01_main varchar(50)

DECLARE cursore CURSOR FORWARD_ONLY for 
	SELECT ninv, yinv, idinvkind, ninv_main, yinv_main, idinvkind_main, invkind_main
	FROM #InvoiceMain
	where yinv_main is not null
	order by ninv, yinv, idinvkind
		OPEN cursore
	FETCH NEXT FROM cursore 
	INTO @ninv01, @yinv01, @idinvkind01, @ninv01_main, @yinv01_main, @idinvkind01_main, @invkind01_main
 
	WHILE (@@fetch_status=0) BEGIN
	
	UPDATE 	#invoice set
	  invoice_main = isnull(invoice_main,'') + @invkind01_main +  ' N.'+isnull(convert(varchar(10),@ninv01_main),'') +  ' Eserc.'+ isnull(convert(varchar(10),@yinv01_main),'')+'. '
	 WHERE ninv = @ninv01 and yinv = @yinv01 and idinvkind = @idinvkind01
		FETCH NEXT FROM cursore 
		INTO @ninv01, @yinv01, @idinvkind01, @ninv01_main, @yinv01_main,@idinvkind01_main, @invkind01_main
	END
CLOSE cursore


-- insert se fattura di acquisto
	INSERT INTO #invoicecontab
	(
		idinvkind,
		yinv,
		ninv,
		ymov,
		nmov,
		phase,
		ypaypro,
		npaypro
	 )
	SELECT 
		EIV.idinvkind,
		EIV.yinv,
		EIV.ninv,
		EIV.ymov,
		EIV.nmov,
		EIV.phase,
		EIV.ypay,
		EIV.npay
	FROM 	expenseinvoiceview EIV
	JOIN 	#invoice I
		ON EIV.idinvkind = I.idinvkind
		AND EIV.yinv = I.yinv
		AND EIV.ninv = I.ninv  
	WHERE 	I.flagbuysell = 'A'

	-- Insert se fattura di vendita
	INSERT INTO #invoicecontab
	(
		idinvkind,
		yinv,
		ninv,
		ymov,
		nmov,
		phase,
		ypaypro,
		npaypro
	 )
	SELECT 
		EIV.idinvkind,
		EIV.yinv,
		EIV.ninv,
		EIV.ymov,
		EIV.nmov,
		EIV.phase,
		EIV.ypro,
		EIV.npro
	FROM 	incomeinvoiceview EIV
	JOIN 	#invoice I
		ON EIV.idinvkind = I.idinvkind
		AND EIV.yinv = I.yinv
		AND EIV.ninv = I.ninv  
	WHERE 	I.flagbuysell = 'V'
	
	INSERT INTO #invoiceregister
	(
		idinvkind,
		yinv,
		ninv,
		ivaregisterkind,
		yivaregister,
		nivaregister,
		protocolnum
	)
	SELECT 
		EIV.idinvkind,
		EIV.yinv,
		EIV.ninv,
		EIV.ivaregisterkind,
		EIV.yivaregister,
		EIV.nivaregister,
		EIV.protocolnum
	FROM 	ivaregisterview EIV
	JOIN 	#invoice I
		ON EIV.idinvkind = I.idinvkind
		AND EIV.yinv = I.yinv
		AND EIV.ninv = I.ninv  

	DECLARE @invkind int
	DECLARE @yinv int
	DECLARE @ninv int
	DECLARE @idinvkindprev int
	DECLARE @yinvprev int
	DECLARE @ninvprev int
	DECLARE @ymov int
	DECLARE @nmov int
	DECLARE @ypaypro int
	DECLARE @npaypro int
	DECLARE @phase varchar(50)
	DECLARE @movlinked varchar(2000)
	
	SET @movlinked = space(1)
	DECLARE rowcursor INSENSITIVE CURSOR FOR
	SELECT  idinvkind, yinv,ninv, 
		ymov,nmov,ypaypro,npaypro,phase
	FROM    #invoicecontab
	ORDER BY idinvkind,yinv,ninv,ymov,nmov asc
	FOR READ ONLY
	
	OPEN rowcursor
	FETCH NEXT FROM rowcursor
	INTO @invkind, @yinv, @ninv, 
	     @ymov, @nmov, @ypaypro, @npaypro, @phase
	WHILE @@FETCH_STATUS = 0
	BEGIN 
		IF ((@invkind <> isnull(@idinvkindprev,-1)) OR 
		    (@yinv <> ISNULL(@yinvprev,-1)) OR 
		    (@ninv <> ISNULL(@ninvprev,-1)))
		BEGIN
			IF (@movlinked <> '' AND @idinvkindprev IS NOT NULL)
			BEGIN
				UPDATE #invoice 
				SET movlinked = @movlinked
				WHERE idinvkind = @idinvkindprev AND
				yinv = @yinvprev AND
				ninv = @ninvprev 
				--print 'update movlinked'
			END
			 
			SET @movlinked = @phase + ': ' +  convert(varchar(10),@nmov) + '/' + 
					 convert(varchar(4),@ymov)  
				        -- + CHAR(13) + CHAR(10)-- aggiungere ritorno a capo
		END
			ELSE
		BEGIN
			SET @movlinked = @movlinked + ' - ' + convert(varchar(10),@nmov) + '/' + 
					 convert(varchar(4),@ymov) 
					-- + CHAR(13) + CHAR(10)-- aggiungere ritorno a capo
		END

		SET @idinvkindprev = @invkind
		SET @yinvprev = @yinv
		SET @ninvprev = @ninv
		FETCH NEXT FROM rowcursor
		INTO @invkind, @yinv, @ninv, 
	     	@ymov, @nmov, @ypaypro, @npaypro, @phase
	END 
	CLOSE rowcursor
	DEALLOCATE rowcursor
	
	IF (@movlinked <> '' AND @idinvkindprev IS NOT NULL)
	BEGIN
		UPDATE #invoice 
		SET movlinked = @movlinked
		WHERE idinvkind = @idinvkindprev AND
		yinv = @yinvprev AND
		ninv = @ninvprev 
		--print 'update movlinked'
	END
	
	
	DECLARE @yivaregister int
	DECLARE @nivaregister int
	DECLARE @protocolnum int
	DECLARE @ivaregisterkind varchar(20)
	DECLARE @ivaregister varchar(2000)
	
	SET @ivaregister = space(1)
	DECLARE rowcursor INSENSITIVE CURSOR FOR
	SELECT  idinvkind, yinv,ninv, 
		yivaregister,nivaregister,protocolnum,ivaregisterkind
	FROM    #invoiceregister
	ORDER BY idinvkind,yinv,ninv,ivaregisterkind, yivaregister,nivaregister asc
	FOR READ ONLY
	
	SET @idinvkindprev = NULL
	SET @yinvprev = NULL
	SET @ninvprev = NULL 
	
	OPEN rowcursor
	FETCH NEXT FROM rowcursor
	INTO @invkind, @yinv, @ninv, 
	     @yivaregister,@nivaregister,@protocolnum,@ivaregisterkind
	WHILE @@FETCH_STATUS = 0
	BEGIN 
		IF ((@invkind <> isnull(@idinvkindprev,-1)) OR 
		    (@yinv <> ISNULL(@yinvprev,-1)) OR 
		    (@ninv <> ISNULL(@ninvprev,-1)))
		BEGIN
			IF (@ivaregister <> ''  AND @idinvkindprev IS NOT NULL)
			BEGIN
				UPDATE #invoice 
				SET ivaregister = @ivaregister
				WHERE idinvkind = @idinvkindprev AND
				yinv = @yinvprev AND
				ninv = @ninvprev 
				print 'update ivaregister'
			END
			 
			SET @ivaregister = @ivaregisterkind +  ' ' + convert(varchar(10),@nivaregister) + '/' + 
					   convert(varchar(4),@yivaregister)  
					   + ' prot. ' + convert(varchar(10),@protocolnum)
					  -- + CHAR(13) + CHAR(10)-- aggiungere ritorno a capo
		END
			ELSE
		BEGIN
			SET @ivaregister = @ivaregister + ' - ' + @ivaregisterkind + ' ' + convert(varchar(10),@nivaregister) + '/' + 
					   convert(varchar(4),@yivaregister)
					   + ' prot. ' + convert(varchar(10),@protocolnum) 
					 --  + CHAR(13) + CHAR(10) -- aggiungere ritorno a capo
					  	
		END
		
		SET @idinvkindprev = @invkind
		SET @yinvprev = @yinv
		SET @ninvprev = @ninv
		FETCH NEXT FROM rowcursor
		INTO @invkind, @yinv, @ninv, 
	    	@yivaregister,@nivaregister,@protocolnum,@ivaregisterkind
	END 
	DEALLOCATE rowcursor
	IF (@ivaregister <> ''  AND @idinvkindprev IS NOT NULL)
		BEGIN
			UPDATE #invoice 
			SET ivaregister = @ivaregister
			WHERE idinvkind = @idinvkindprev AND
			yinv = @yinvprev AND
			ninv = @ninvprev 
			print 'update ivaregister'
		END

	SELECT 
		invoicekind AS 'Tipo', 
		yinv AS 'Esercizio', 
		ninv AS 'Numero', 
		flagdeferred AS 'IVA Differita', 
		CASE flagbuysell
			WHEN 'A' THEN 'Acquisto'
			WHEN 'V' THEN 'Vendita'
			ELSE null
		END AS 'A/V', 
		ivaregister AS 'Registri',
		doc AS  'Num. Doc. Coll.',
		docdate AS  'Data Doc. Coll.',
		registry AS 'Cliente/Fornitore',
		description AS 'Descrizione',
		taxabletotal AS 'Tot.Imponibile', 
		ivatotal AS 'Tot.IVA', 
		linked AS 'Tot.Contabilizzato',
		movlinked AS 'Mov. Finanziari',
		residual AS 'Totale da Contabilizzare',
		ivatotalpayed AS 'Totale Iva Liquid.' ,
		invoice_main as 'Fattura di riferimento',
		stampkind as 'Trattamento Bollo'
	FROM #invoice order by idinvkind, yinv, ninv
		
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


 

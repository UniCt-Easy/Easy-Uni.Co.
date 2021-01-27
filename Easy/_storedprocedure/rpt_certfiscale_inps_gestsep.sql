
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_certfiscale_inps_gestsep]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_certfiscale_inps_gestsep]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE    PROCEDURE [rpt_certfiscale_inps_gestsep]
	@ayear int,
	@idreg int
AS BEGIN	
	
--	 exec rpt_certfiscale_inps_gestsep 2007, 6390
 
CREATE TABLE #sendingaddress
(
	idaddresskind int,
	idreg int,
	officename varchar(50),
	sendaddress varchar(100),
	sendlocation varchar(120),
	sendcap varchar(20),
	sendprovince varchar(2),
	sendnation varchar(65)
)

CREATE TABLE #fiscaldeclaration
(
	idreg int,
	registry varchar(100),
	service varchar(50),
	causale varchar(250),
	birthdate datetime,
	b_place varchar(120),
	b_province varchar(2),
	b_nation varchar(65),
	cf varchar(16),
	cfestero varchar(40),
	taxable decimal(19,2),
	adminretension decimal(19,2),
	employretension decimal(19,2),
	amountgross decimal(19,2),
	workperiod varchar(200)
)
	
CREATE TABLE #residenceaddress
(
	idaddresskind int,
	idreg int,
	officename varchar(50),
	residaddress varchar(100),
	residlocation varchar(120),
	residcap varchar(20),
	residprovince varchar(2),
	residnation varchar(65)	
)

IF @ayear  = 0
BEGIN
	SET @ayear='1900'
END

DECLARE @filter varchar(50)
IF @idreg = 0
BEGIN
	SELECT @filter = '%'
END
ELSE
BEGIN
	SELECT @filter = title FROM registry WHERE idreg = @idreg
END

INSERT INTO #fiscaldeclaration
(
	idreg,
	registry,
	service,
	birthdate,
	b_place,
	b_province,  
	b_nation,
	cf
)
SELECT
	expense.idreg,
	registry.title,
	service.description,
	registry.birthdate,
	ISNULL(geo_city.title, '') + ' ' + ISNULL(registry.location,''),
	ISNULL(geo_country.province, ''),
	ISNULL(geo_nation.title, 'ITALIA'),
	registry.cf
FROM expense 
JOIN expenselast
	ON expense.idexp = expenselast.idexp
JOIN payment 
	ON payment.kpay = expenselast.kpay
JOIN paymenttransmission
	ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
JOIN service
	ON service.idser = expenselast.idser				
JOIN registry
	ON registry.idreg = expense.idreg
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = registry.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON geo_nation.idnation = registry.idnation
WHERE service.certificatekind = 'I' AND  
EXISTS (SELECT * FROM expensetaxofficial D 
            JOIN tax t
	      	 ON t.taxcode= D.taxcode 
           WHERE D.idexp = expense.idexp
		AND D.stop IS NULL) AND
	registry.title LIKE @filter AND 
	YEAR(paymenttransmission.transmissiondate) = @ayear
GROUP BY expense.idreg, registry.title, registry.birthdate,
	ISNULL(geo_city.title, '') + ' ' + ISNULL(registry.location,''),
	ISNULL(geo_country.province, ''), ISNULL(geo_nation.title, 'ITALIA'),
	service.description, registry.cf
	
CREATE TABLE #period
(
	idreg int,
	start datetime,
	stop datetime
)

INSERT INTO #period
SELECT
	expense.idreg,
	ISNULL(expenselast.servicestart, expense.adate),
	ISNULL(expenselast.servicestop, expense.adate)
FROM expense 
JOIN #fiscaldeclaration
        ON #fiscaldeclaration.idreg = expense.idreg
JOIN expenselast
	ON expense.idexp = expenselast.idexp
JOIN payment 
	ON payment.kpay = expenselast.kpay
JOIN paymenttransmission
	ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
JOIN service
	ON service.idser = expenselast.idser				
WHERE service.certificatekind = 'I' AND  
EXISTS (SELECT * FROM expensetaxofficial D 
            JOIN tax t
	      	 ON t.taxcode= D.taxcode 
           WHERE D.idexp = expense.idexp
		AND D.stop IS NULL) AND
	YEAR(paymenttransmission.transmissiondate) = @ayear
ORDER BY expense.idreg, expenselast.servicestart, expenselast.servicestop


declare @somethdone int
set @somethdone=1
while (@somethdone>0) 
BEGIN
	--cancella periodi inclusi in altri
	delete from #period where exists (select * from #period p2 where p2.idreg=#period.idreg and p2.start>#period.start and p2.stop<=#period.stop)
	delete from #period where exists (select * from #period p2 where p2.idreg=#period.idreg and p2.start>=#period.start and p2.stop<#period.stop)


	set @somethdone=0
	--concatena periodi adiacenti ad intersezione nulla
	if exists(select * from #period P1 where 
		exists(select * from #period P2 where (P1.idreg=P2.idreg and P1.start<P2.start and DATEADD(DAY, 1, P1.stop)=P2.start) )
		 )
	BEGIN
	   set @somethdone=1
	   update #period set stop= (select max(P2.stop) from #period P2 where #period.idreg=P2.idreg and
				DATEADD(DAY,1, #period.stop)=P2.start and #period.start<P2.start)
		where exists(select * from #period P2 where (#period.idreg=P2.idreg and #period.start<P2.start and DATEADD(DAY, 1, #period.stop)=P2.start) )
	END

	--concatena periodi ad intersezione non nulla
	if exists(select * from #period P1 where 
		exists(select * from #period P2 where P1.idreg=P2.idreg and P1.start<P2.start and p1.stop<p2.stop and p1.stop>=p2.start
		 	)
		)
	BEGIN
	   set @somethdone=1
	   update #period set stop= (select max(P2.stop) from #period P2 where 
				#period.idreg=P2.idreg and  #period.start<P2.start and #period.stop<p2.stop and #period.stop>=p2.start )
		where exists(select * from #period P2 where
				 #period.idreg=P2.idreg and #period.start<P2.start and #period.stop<p2.stop and #period.stop>=p2.start
		 	)
	END


END





/*




CREATE TABLE #periodgrouped
(
	idreg int, 
	start datetime,
	stop datetime
)

DECLARE @reg int
DECLARE @reg1 int
DECLARE @start datetime
DECLARE @stop datetime
DECLARE @start1 datetime
DECLARE @stop1 datetime
DECLARE #period_crs INSENSITIVE CURSOR FOR
SELECT idreg, start, stop FROM #period
ORDER BY idreg, start, stop
FOR READ ONLY

OPEN #period_crs
FETCH NEXT FROM #period_crs INTO @reg, @start, @stop
IF @@FETCH_STATUS = 0
BEGIN 
	FETCH NEXT FROM #period_crs INTO @reg1, @start1, @stop1

	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		IF (@reg1 <> @reg)
		BEGIN
			INSERT INTO #periodgrouped (idreg, start, stop)
			VALUES(@reg, @start, @stop)
		END
		ELSE
		BEGIN
			IF (DATEADD(DAY, 1, @stop) = @start1)
			BEGIN
				SET @stop = @stop1
				SET @start1 = @start
			END
			ELSE
			BEGIN
				IF (@stop BETWEEN @start1 AND @stop1)
				BEGIN
					SET @stop = @stop1
					SET @start1 = @start
				END
				ELSE
				BEGIN
					INSERT INTO #periodgrouped (idreg, start, stop)
					VALUES(@reg, @start, @stop)
				END
			END		
		END
		SET @reg = @reg1
		SET @start = @start1
		SET @stop = @stop1

		FETCH NEXT FROM #period_crs INTO @reg1, @start1, @stop1
	END
	INSERT INTO #periodgrouped (idreg, start, stop)
	VALUES(@reg, @start, @stop)
END
CLOSE #period_crs
DEALLOCATE #period_crs

*/

DECLARE @codesendaddresskind varchar(20)
SELECT 	@codesendaddresskind = '07_SW_DOM'

DECLARE @coderesidaddresskind varchar(20)
SELECT  @coderesidaddresskind = '07_SW_DOM'

DECLARE @codestandardaddresskind varchar(20)
SELECT  @codestandardaddresskind = '07_SW_DEF'

DECLARE @sendaddresskind int
SELECT  @sendaddresskind = idaddress FROM address WHERE codeaddress = @codesendaddresskind

DECLARE @residaddresskind int
SELECT  @residaddresskind = idaddress FROM address WHERE codeaddress = @coderesidaddresskind

DECLARE @standardaddresskind int
SELECT  @standardaddresskind = idaddress FROM address WHERE codeaddress = @codestandardaddresskind

DECLARE @validityaddress datetime
SELECT  @validityaddress = CONVERT(datetime, '31-12-' + CONVERT(varchar(4),@ayear), 105)
	
INSERT INTO #sendingaddress
SELECT 	idaddresskind,
	registryaddress.idreg, 
	officename, 
	address,
	ISNULL(geo_city.title,'') + ' ' + ISNULL(registryaddress.location,'') ,
	registryaddress.cap, 
	geo_country.province,
	CASE 
		when flagforeign = 'N' then 'Italia'
		else geo_nation.title
	END
FROM registryaddress
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = registryaddress.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry
LEFT OUTER JOIN geo_nation
	ON geo_nation.idnation = registryaddress.idnation
WHERE (
registryaddress.active <>'N' 
AND (idreg IN (select idreg from  #fiscaldeclaration))
AND registryaddress.start = 
	(SELECT MAX(cdi.start) 
	FROM registryaddress cdi 
	WHERE cdi.idaddresskind = registryaddress.idaddresskind
		AND cdi.active <>'N' 
		AND cdi.start <= @validityaddress
		and cdi.idreg = registryaddress.idreg)
)
	delete #sendingaddress
	where #sendingaddress.idaddresskind != @sendaddresskind
	and exists (
		select * from #sendingaddress r2 
		where #sendingaddress.idreg=r2.idreg
		and r2.idaddresskind = @sendaddresskind
		)
	delete #sendingaddress
	where #sendingaddress.idaddresskind not in (@sendaddresskind, @standardaddresskind)
	and exists (
		select * from #sendingaddress r2 
		where #sendingaddress.idreg=r2.idreg
		and r2.idaddresskind = @standardaddresskind
		)
	delete #sendingaddress
	where (
		select count(*) from #sendingaddress r2 
		where #sendingaddress.idreg=r2.idreg
	)>1

	 UPDATE #fiscaldeclaration 
 		SET taxable = 
  			(SELECT ISNULL(SUM(tabella.taxablelordo),0)
 		 	 FROM 
				  (select max(E.taxablegross) as 'taxablelordo',E.idexp
				     from expensetaxofficial as E
				     JOIN tax
				      ON tax.taxcode = E.taxcode
				     JOIN expense
				      ON expense.idexp = E.idexp
					JOIN expenselast
					ON expense.idexp = expenselast.idexp	
				   JOIN payment
				      ON payment.kpay = expenselast.kpay
				     JOIN paymenttransmission
				      ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
				     JOIN service
				      ON service.idser=expenselast.idser
				     JOIN registry
				      ON registry.idreg = expense.idreg
				     WHERE 
				     service.certificatekind = 'I' AND
				     tax.taxkind=3 AND  
					E.stop IS NULL AND
				     registry.idreg = #fiscaldeclaration.idreg AND
				     YEAR(paymenttransmission.transmissiondate) = @ayear
				     group by E.idexp
				     ) as tabella)
 
	UPDATE #fiscaldeclaration 
	SET adminretension =
		(SELECT ISNULL(SUM(E.admintax),0) 
		   	FROM expensetaxofficial as E
		   	JOIN expense
		   		ON expense.idexp = E.idexp
			JOIN tax 
				ON tax.taxcode = E.taxcode
			JOIN expenselast
				ON expense.idexp = expenselast.idexp	
		   	JOIN payment
			      ON payment.kpay = expenselast.kpay
		  	JOIN paymenttransmission
		  	 	ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
		   	JOIN service
		   		ON service.idser=expenselast.idser
		   	JOIN registry
		  	 	ON registry.idreg = expense.idreg
		  	 WHERE 
		  		 service.certificatekind = 'I' AND
				 tax.taxkind=3 AND
				E.stop IS NULL AND
		   		 registry.idreg = #fiscaldeclaration.idreg AND
		   		 YEAR(paymenttransmission.transmissiondate) = @ayear
	           	)

	UPDATE #fiscaldeclaration 
	SET employretension =
		(SELECT ISNULL(SUM(E.employtax),0) 
		   	FROM expensetaxofficial as E
		   	JOIN expense
		   		ON expense.idexp = E.idexp
			JOIN tax 
				ON tax.taxcode = E.taxcode
			JOIN expenselast
				ON expense.idexp = expenselast.idexp	
			  JOIN payment
				      ON payment.kpay = expenselast.kpay
		  	JOIN paymenttransmission
		  	 	ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission
		   	JOIN service
		   		ON service.idser=expenselast.idser
		   	JOIN registry
		  	 	ON registry.idreg = expense.idreg
		  	 WHERE 
		  		 service.certificatekind = 'I' AND
				 tax.taxkind=3 AND
				E.stop IS NULL AND
		   		 registry.idreg = #fiscaldeclaration.idreg AND
		   		 YEAR(paymenttransmission.transmissiondate) = @ayear
	         )

	DECLARE @service varchar(50)
	DECLARE @service1 varchar(50)
	DECLARE @idreg2   int
	DECLARE @idreg3   int
	DECLARE @causale varchar(250)
	-- Costruzione della causale
	DECLARE rowcursor INSENSITIVE CURSOR FOR
		SELECT  service,idreg
		FROM 	#fiscaldeclaration
		ORDER BY idreg,service asc
		FOR READ ONLY
		OPEN rowcursor
		FETCH NEXT FROM rowcursor
		INTO  @service, @idreg2
		SET @causale = @service
		print @service
		print @idreg2
		IF @@FETCH_STATUS = 0
		BEGIN 
			FETCH NEXT FROM rowcursor
			INTO  @service1, @idreg3
			print @service1
			print @idreg3
			WHILE (@@FETCH_STATUS = 0)
			BEGIN
				
				IF  @idreg3 <> @idreg2 
					BEGIN   
						DECLARE @startdate datetime
						DECLARE @stopdate datetime
						DECLARE @stringa varchar(200)
						DECLARE #per_crs INSENSITIVE CURSOR FOR
						SELECT start, stop FROM #period WHERE idreg = @idreg2 ORDER BY start, stop
	
						FOR READ ONLY

						OPEN #per_crs
						FETCH NEXT FROM #per_crs INTO @startdate, @stopdate
						WHILE (@@FETCH_STATUS = 0)
						BEGIN
							IF (@stringa IS NULL)
							BEGIN
								SET @stringa = 'dal ' + CONVERT(varchar(16), @startdate, 105) + ' al ' +
								CONVERT(varchar(16), @stopdate, 105) + ';'
							END
							ELSE
							BEGIN
								SET @stringa = ISNULL(@stringa,'') +
								' dal ' + CONVERT(varchar(16), @startdate, 105) + ' al ' +
								CONVERT(varchar(16), @stopdate, 105) + ';'
							END

							FETCH NEXT FROM #per_crs INTO @startdate, @stopdate
						END
						CLOSE #per_crs
						DEALLOCATE #per_crs

						IF (@stringa IS NOT NULL)
						BEGIN
							SET @stringa = SUBSTRING(@stringa, 1, LEN(@stringa) - 1)
						END

						UPDATE 	#fiscaldeclaration
						SET causale = @causale,
						workperiod = @stringa
						WHERE 	idreg   = @idreg2

						SET @stringa = NULL
						SET @causale  = @service1
					END
				ELSE	
					BEGIN
						IF  @causale  is null 
						BEGIN
							SET @causale = @service
						END
					
						IF  @service1 <> @service
						SET @causale  = @causale + ' / ' + @service1
						PRINT   @causale
					END
				SELECT @idreg2 = @idreg3, @service = @service1
				FETCH NEXT FROM rowcursor
				INTO  @service1, @idreg3
				print @service1
				print @idreg3
			END

			DECLARE #per_crs INSENSITIVE CURSOR FOR
			SELECT start, stop FROM #period WHERE idreg = @idreg2 ORDER BY start, stop

			FOR READ ONLY

			OPEN #per_crs
			FETCH NEXT FROM #per_crs INTO @startdate, @stopdate
			WHILE (@@FETCH_STATUS = 0)
			BEGIN
				IF (@stringa IS NULL)
				BEGIN
					SET @stringa = 'dal ' + CONVERT(varchar(16), @startdate, 105) + ' al ' +
					CONVERT(varchar(16), @stopdate, 105) + ';'
				END
				ELSE
				BEGIN
					SET @stringa = ISNULL(@stringa,'') +
					' dal ' + CONVERT(varchar(16), @startdate, 105) + ' al ' +
					CONVERT(varchar(16), @stopdate, 105) + ';'
				END

				FETCH NEXT FROM #per_crs INTO @startdate, @stopdate
			END
			CLOSE #per_crs
			DEALLOCATE #per_crs

			IF (@stringa IS NOT NULL)
			BEGIN
				SET @stringa = SUBSTRING(@stringa, 1, LEN(@stringa) - 1)
			END

			UPDATE 	#fiscaldeclaration
			SET causale = @causale,
			workperiod = @stringa
			WHERE 	idreg   = @idreg2
		END 
		DEALLOCATE rowcursor
------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------
DECLARE @departmentname varchar(500)

SET  @departmentname  = ISNULL( (SELECT top 1 paramvalue from
    generalreportparameter where idparam='DenominazioneDipartimento' 
    and  (ISNULL(start, {d '1900-01-01'}) = {d '1900-01-01'} or year(start) <= @ayear) 
    and  (ISNULL(stop, {d '2079-06-06'}) = {d '2079-06-06'}  or year(stop) >= @ayear)
    order by ISNULL(stop, {d '2079-06-06'}) desc
    ),'Manca Cfg. Parametri Tutte le stampe')


SELECT DISTINCT
        @departmentname as departmentname,
	#fiscaldeclaration.idreg,
	#fiscaldeclaration.registry,
	#fiscaldeclaration.causale,
	#fiscaldeclaration.birthdate,
	#fiscaldeclaration.b_place,
	#fiscaldeclaration.b_province,
	#fiscaldeclaration.b_nation,
	#fiscaldeclaration.cf,
	#fiscaldeclaration.cfestero,
	#fiscaldeclaration.taxable,
	#fiscaldeclaration.adminretension,
	#fiscaldeclaration.employretension,
	#sendingaddress.officename,
	#sendingaddress.sendaddress 	as 'spedaddress',
	#sendingaddress.sendlocation 	as 'spedlocation',
	#sendingaddress.sendcap		as 'spedcap',
	#sendingaddress.sendprovince 	as 'spedprovince',
	#sendingaddress.sendnation 	as 'spednation',
	#fiscaldeclaration.workperiod
	FROM #fiscaldeclaration
	LEFT OUTER JOIN #sendingaddress
		ON #sendingaddress.idreg = #fiscaldeclaration.idreg
	LEFT OUTER JOIN #residenceaddress
		ON #residenceaddress.idreg  = #fiscaldeclaration.idreg
ORDER BY #fiscaldeclaration.registry ASC
	
DROP TABLE #sendingaddress
DROP TABLE #fiscaldeclaration
DROP TABLE #residenceaddress

END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

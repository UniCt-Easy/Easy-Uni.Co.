if exists (select * from dbo.sysobjects where id = object_id(N'[exp_interscambio_csa_missioni_single]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_interscambio_csa_missioni_single]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE exp_interscambio_csa_missioni_single
 (
	@datagenerazione datetime,
	@ayear int,
	@ateneo varchar(5),
	@tipoCompenso char(1),-- Assume valori T = Conto Terzi, C = CO.CO.CO. , B = Borse di studio, M = Missioni
	@start datetime,
	@stop datetime
)
AS 
-- testare il caso in cui una persona fa due missioni con due inquadramenti diversi.
-- Per esempio una missione a gennaio e una a marzo 
BEGIN
DECLARE @mask int -- Filtro Ritenute

IF (@tipoCompenso = 'C') SET  @mask = 1 --Parasubordinati/Cococo
IF (@tipoCompenso = 'T') SET  @mask = 2 --Compensi a dipendenti/ Conto Terzi
IF (@tipoCompenso = 'B') SET  @mask = 4 --Borse di Studio
IF (@tipoCompenso = 'M') SET  @mask = 8 --Missioni

-- ATTENZIONE: Questa sp è chiamata anche da 'exp_interscambio_csa_dipendentiassimilato_dati'. Quest'ultima mostra i dati che stiamo comunicando attraverso il file.
--exec exp_interscambio_csa_missioni_single {ts '2011-12-31 01:02:03'} ,2011, '70136','M',{ts '2011-01-01 01:02:03'},{ts '2011-12-31 01:02:03'}
DECLARE @annoredditi int
SET @annoredditi = @ayear

--------------------------------------------------------------------------------------------------- CALCOLI MISSIONE -----------------------------------------------------------------------
DECLARE @italianexemption decimal(19,6)	-- imp. esente Italia
DECLARE @foreignexemption decimal(19,6) -- imp. esente Estero

SELECT @italianexemption = italianexemption, @foreignexemption = foreignexemption 
FROM itinerationparameter
WHERE itinerationparameter.start =
	(SELECT MAX(IP2.start)
	FROM itinerationparameter IP2)

DECLARE @QuotaEsente decimal (19,6)
DECLARE @QuotaEsenteTot decimal (19,6)
DECLARE @QuotaImponibile decimal (19,6)
DECLARE @QuotaImponibileTot decimal (19,6)

DECLARE @ggfraz float 
DECLARE @QuotaEsTappa decimal (19,6)
DECLARE @IndennitaTotaleNonRidotta float
DECLARE @IndennitaTotale decimal (19,6)

DECLARE @iditineration int
DECLARE @grossfactor float
DECLARE @idreg int

DECLARE @lapnumber int
DECLARE @flagitalian char
DECLARE @percquotaesentegg float
DECLARE @allowance decimal (19,2)
DECLARE @days float
DECLARE @hours float
DECLARE @idexp INT

CREATE TABLE #Missione(
		iditineration int, 
		idexp int,
		idregistrylegalstatus int,
		voce8000 varchar(4),
		importo decimal(19,2),
		idreg int/*, 
		flagitalian char*/
		)

INSERT INTO #Missione
(
	iditineration,
	idexp,
	idreg,
	voce8000
)
SELECT 	
	I.iditineration,
	EL.idexp,
	I.idreg,
	S.voce8000
FROM itineration I
JOIN expenseitineration E
	ON E.iditineration = I.iditineration
join expenselink ELK
	ON ELK.idparent = E.idexp
join expenselast EL
	on EL.idexp = ELK.idchild
join payment P
	on P.kpay = EL.kpay
JOIN service S
	ON S.idser = I.idser
WHERE E.movkind = 4 --> Considero solo le missioni per cui è stato pagato il Saldo.
	AND S.voce8000 is not null --> Solole missioni da comunicare
	AND I.yitineration = @ayear
	AND P.adate between @start and @stop
	AND P.kpaymenttransmission IS NOT NULL


-- Inserisce le ritenute c/Amm
INSERT INTO #Missione
(
	iditineration,
	idreg,
	importo,
	voce8000
)
SELECT 	
	I.iditineration,
	I.idreg,
	SUM(IT.admintax),
	V.voce
FROM itineration I
JOIN expenseitineration E
	ON E.iditineration = I.iditineration
JOIN itinerationtax IT 
	ON I.iditineration = IT.iditineration
JOIN voce8000lookup V
	ON V.taxcode = IT.taxcode
WHERE E.movkind = 4 --> Considero solo le missioni per cui è stato pagato il Saldo.
	AND V.conto  = 'A' AND isnull(IT.admintax,0) >=0 
	AND (( V.flagcsausability & @mask) <>0 )
	AND I.yitineration = @ayear
	and I.iditineration in (select iditineration from #Missione )
GROUP BY I.iditineration,I.idreg, V.voce

-- Inserisce le ritenute c/Dip
INSERT INTO #Missione
(
	iditineration,
	idreg,
	importo,
	voce8000
)
SELECT 	
	I.iditineration,
	I.idreg,
	SUM(IT.employtax),
	V.voce
FROM itineration I
JOIN expenseitineration E
	ON E.iditineration = I.iditineration
JOIN itinerationtax IT 
	ON I.iditineration = IT.iditineration
JOIN voce8000lookup V
	ON V.taxcode = IT.taxcode
WHERE E.movkind = 4 --> Considero solo le missioni per cui è stato pagato il Saldo.
	AND V.conto  = 'D' AND isnull(IT.employtax,0) >= 0
	AND (( V.flagcsausability & @mask) <>0 )
	AND I.yitineration = @ayear
	and I.iditineration in (select iditineration from #Missione )
GROUP BY I.iditineration,I.idreg, V.voce


DECLARE curr_missione INSENSITIVE CURSOR FOR
SELECT I.iditineration, I.grossfactor, I.idreg, L.flagitalian,  M.idexp
FROM itineration I
JOIN #missione M
	ON M.iditineration = I.iditineration
JOIN itinerationlap L
	ON I.iditineration = L.iditineration
WHERE I.yitineration = @ayear
GROUP BY I.iditineration,  I.grossfactor, I.idreg, L.flagitalian, M.idexp

FOR READ ONLY
OPEN curr_missione
FETCH NEXT FROM curr_missione INTO @iditineration, @grossfactor,  @idreg, @flagitalian, @idexp 
WHILE (@@FETCH_STATUS = 0)
BEGIN
			SELECT @QuotaEsenteTot = 0, @QuotaImponibileTot = 0

			DECLARE curr_tappa INSENSITIVE CURSOR FOR
			SELECT lapnumber, isnull(reductionpercentage,0), ISNULL(allowance,0), days, hours 
			FROM itinerationlap
			WHERE iditineration = @iditineration and flagitalian = @flagitalian

			FOR READ ONLY
			OPEN curr_tappa
			FETCH NEXT FROM curr_tappa INTO @lapnumber,  @percquotaesentegg, @allowance, @days, @hours
			WHILE (@@FETCH_STATUS = 0)
			BEGIN

					SELECT @QuotaEsente = 0, @QuotaImponibile = 0
			-- Calcolo della quota esente
					IF (@flagitalian = 'S')
					begin
						SET @QuotaEsente = @italianexemption 
					end
					ELSE
					begin	
						SET @QuotaEsente = @foreignexemption
					end

					SET @ggfraz = (@days + (@hours/24.0))

					IF (@percquotaesentegg>1) 
					begin
						SET @percquotaesentegg = 1
					end
					
					SET @QuotaEsTappa = ROUND(( ( ((1 - @percquotaesentegg)* @ggfraz) * @QuotaEsente) ),2)

					SET @IndennitaTotaleNonRidotta = ( @allowance * @ggfraz )

					SET @IndennitaTotale = ( @IndennitaTotaleNonRidotta * (1-@percquotaesentegg) ) 

					IF ( @QuotaEsTappa > @IndennitaTotale )
					begin
						SET @QuotaEsTappa = @IndennitaTotale
					end
		-- Calcolo Quota imponibile Tappa:
					IF ( (@IndennitaTotale - @QuotaEsTappa) >0 )
					begin
						SET @QuotaImponibile =  (@IndennitaTotale - @QuotaEsTappa) * @grossfactor;
					end
					else 
					begin
						SET @QuotaImponibile = 0
					end

					SET @QuotaEsenteTot = @QuotaEsenteTot + @QuotaEsTappa
					SET @QuotaImponibileTot = @QuotaImponibileTot + @QuotaImponibile

				FETCH NEXT FROM curr_tappa INTO @lapnumber, @percquotaesentegg, @allowance, @days, @hours
			END

			CLOSE curr_tappa
			DEALLOCATE curr_tappa

			IF (@flagitalian = 'S')
			Begin	
				-- 8158: quota esente per le missioni in Italia
				 INSERT INTO #Missione(iditineration, importo, voce8000, idreg,idexp /*,flagitalian*/)	
				 SELECT @iditineration, @QuotaEsenteTot, '8158', @idreg, @idexp /*, @flagitalian*/
				 -- 8159 :Imponibile per le missioni in Italia
				 INSERT INTO #Missione(iditineration, importo, voce8000,idreg,idexp /* ,flagitalian*/)	
				 SELECT @iditineration, @QuotaImponibileTot, '8159',@idreg, @idexp /*, @flagitalian*/
			End
			Else
			begin
				-- 8054: quota esente per le misisoni all'estero
				 INSERT INTO #Missione(iditineration, importo, voce8000,idreg,idexp /* ,flagitalian*/)	
				 SELECT @iditineration, @QuotaEsenteTot, '8054',@idreg, @idexp /*, @flagitalian*/
				 -- 8055 : Imponibile per le missioni all'estero
				 INSERT INTO #Missione(iditineration, importo, voce8000,idreg,idexp /* ,flagitalian*/)	
				 SELECT @iditineration, @QuotaImponibileTot, '8055', @idreg, @idexp /*, @flagitalian*/
			end

	FETCH NEXT FROM curr_missione INTO @iditineration, @grossfactor, @idreg, @flagitalian, @idexp
END
CLOSE curr_missione
DEALLOCATE curr_missione

-- Calcola l'importo della spesa. Vanno comunicate le spese per le missioni all'estero e le spese per le missioni in italia
-- Potrebbero esserci missioni con Tappe in Italia e tappe all'estero, per discriminare la spesa è stato utilizzato il "flag_geo" 
-- della tabella delle spese delle missioni

INSERT INTO #Missione(iditineration, importo, voce8000/*, flagitalian*/)	
SELECT S.iditineration, 
	S.amount, 
	CASE 
		WHEN S.flag_geo = 'I' THEN '8160'-- 8160	Mem. missioni Italia (spese)
		ELSE '8161'						 -- 8161	Mem. missioni estero (spese)
	END
	 /*, 
	CASE 
		WHEN S.flag_geo = 'I' THEN 'S'
		ELSE 'N'						
	END*/	
FROM itinerationrefund	S		
WHERE S.iditineration in (select iditineration from #Missione )
and S.flagadvancebalance = 'S'

update #missione set idreg = (select top 1 idreg from #Missione M2 where M2.iditineration = #missione.iditineration and M2.idreg is not null ) where idreg is null
update #missione set idexp = (select top 1 idexp from #Missione M2 where M2.iditineration = #missione.iditineration and M2.idexp is not null) where idexp is null

UPDATE #Missione SET idregistrylegalstatus = ( SELECT idregistrylegalstatus FROM itineration WHERE itineration.iditineration = #Missione.iditineration )


-- Corregge l'idregistrylegalstatus. Se facciamo l'importazione delle anagrafiche, e queste sono state già usate nei contratti, nelle tabelle dei contratti il campo
-- idregistrlegal status non sarà valorizzato, quindi dobbiamo cercare di leggerlo adesso.
UPDATE #Missione SET idregistrylegalstatus = 
									(select TOP 1 R1.idregistrylegalstatus -- ci sono anagrafiche con lo stesso ruolo ma aventi data decorrenza diversa
										from registrylegalstatus R1
										where R1.idreg = #Missione.idreg
											and R1.csa_compartment is not null
											and R1.csa_role is not null
											and 
											(select count(distinct R2.csa_role) FROM registrylegalstatus R2
												where R2.idreg = r1.idreg
												and R2.csa_compartment is not null
												and R2.csa_role is not null)= 1
										)
WHERE idregistrylegalstatus IS NULL


DECLARE @departmentname varchar(500)
SET  @departmentname  = ISNULL( (SELECT paramvalue from
			 generalreportparameter where idparam='DenominazioneDipartimento' 
				and  (start is null or year(start) <= @ayear) 
				and (stop is null or year(stop) >= @ayear)
				),'Manca Cfg. Parametri Tutte le stampe')
				
DECLARE @iddb varchar(50)
SET @iddb = (select user)

-- In Out forniamo anche idexp perchè il file deve comunicare un record per pagamento
-- Ma l'idexp non basta, perchè è univoco nel dipartimento non nel DB, quindi vi concateniamo anche lo user per avere una chiave
-- univoca del mov. di spesa all'interno del DB consolidato
SELECT  P.idreg,
		@departmentname,
		@iddb+convert(varchar(10),P.idexp),
		P.idregistrylegalstatus,
		P.voce8000,
		sum(P.importo),
		E.ymov,
		E.nmov,
		M.adate
FROM #Missione P
JOIN expense E	
	On P.idexp = E.idexp
JOIN expenselast EL
	ON El.idexp = E.idexp
JOIN payment M
	ON EL.kpay = M.kpay
where idregistrylegalstatus is not null --	<<
and P.importo <> 0
GROUP BY  P.idreg,P.idexp, P.idregistrylegalstatus,P.voce8000,	-- metto la GROUP BY perchè sono solo spese, classificate tutte allo stesso modo,
																				-- credo non vi sia la necessita di fornirel su righe separate.
		E.ymov,	E.nmov,	M.adate
ORDER BY P.idreg, P.idexp, P.voce8000

END


GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


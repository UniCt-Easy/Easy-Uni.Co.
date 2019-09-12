if OBJECTPROPERTY(object_id('rpt_journal_sum'), 'IsProcedure') = 1
	drop procedure rpt_journal_sum
go

CREATE	PROCEDURE rpt_journal_sum
	@ayear 			int,
	@start 			datetime,
	@codphase_proceeds 	varchar(20),
	@codphase_payment 	varchar(20),
	@descphase_proceeds 	varchar(50),
	@descphase_payment 	varchar(50),
	@floatfund 		decimal(19,2) OUTPUT,
	@tot_proceeds_comp 	decimal(19,2) OUTPUT,
	@var_proceeds_comp 	decimal(19,2) OUTPUT,
	@tot_proceeds_resid 	decimal(19,2) OUTPUT,
	@var_proceeds_resid 	decimal(19,2) OUTPUT,
	@tot_payment_comp 	decimal(19,2) OUTPUT,
	@var_payment_comp 	decimal(19,2) OUTPUT,
	@tot_payment_resid 	decimal(19,2) OUTPUT,
	@var_payment_resid 	decimal(19,2) OUTPUT
AS
	BEGIN
		DECLARE @cashvaliditykind tinyint
		SELECT	@cashvaliditykind = cashvaliditykind
		FROM 	config
		WHERE 	ayear = @ayear

		SELECT 	@tot_proceeds_comp = SUM(amount)
		FROM 	historyproceedsview 
		WHERE 	competencydate < @start
			AND ( (totflag & 1) =0) -- Competenza
			AND ymov = @ayear
		
		SELECT 	@tot_payment_comp = SUM(amount)
		FROM 	historypaymentview 
		WHERE 	competencydate < @start
			AND ymov = @ayear
			AND ( (totflag & 1) =0) -- Competenza
		
		IF @cashvaliditykind <> 4
		BEGIN
			SELECT 	@var_proceeds_comp = SUM(IV.amount)
	    		FROM 	incomevar IV
			JOIN historyproceedsview HPV
					ON HPV.idinc = IV.idinc
		   	WHERE   IV.yvar = @ayear
				AND HPV.ymov = @ayear
				AND ( (totflag & 1) =0) -- Competenza
		    		AND (
					(HPV.competencydate < @start
				  		AND ( 
							((IV.autokind <> 11) AND(IV.autokind <> 10)  ) 
							OR IV.autokind is null
				          		         )
					)
					OR
					(IV.adate < @start
						AND (   (IV.autokind = 11)OR(IV.autokind = 10)  ) 
					) 
				)
			
		   	SELECT @var_payment_comp = SUM(EV.amount)
		    	FROM   expensevar EV
	  	    	JOIN historypaymentview HPV
				ON  HPV.idexp = EV.idexp
		    	WHERE EV.yvar = @ayear
				AND HPV.ymov = @ayear
				AND ( (totflag & 1) =0) -- Competenza 
				AND (
				(HPV.competencydate < @start
			  		AND ( 
						((EV.autokind <> 11) AND(EV.autokind <> 10)) 
						OR EV.autokind is null
			          		         )
				)
				OR
				(EV.adate < @start
					AND ((EV.autokind = 11)OR(EV.autokind = 10)) 
				) 
				)
		END
		SELECT 	@tot_proceeds_resid = SUM(amount)
		FROM 	historyproceedsview 
		WHERE  competencydate < @start
			AND ( (totflag & 1) = 1) -- Residuo
			AND ymov = @ayear
	
		SELECT 	@tot_payment_resid = SUM(amount)
		FROM 	historypaymentview 
		WHERE 	competencydate < @start
			AND ( (totflag & 1) = 1) -- Residuo
			AND ymov = @ayear
		
		IF @cashvaliditykind <> 4
		BEGIN
			SELECT 	@var_proceeds_resid = SUM(IV.amount)
		    	FROM 	incomevar IV
			JOIN 	historyproceedsview HPV
				ON  HPV.idinc = IV.idinc
		    	WHERE IV.yvar = @ayear
			AND ( (totflag & 1) = 1) -- Residuo
			AND HPV.ymov = @ayear
		    	AND (
				(HPV.competencydate < @start
			  		AND ( 
						(   (IV.autokind <> 11) AND(IV.autokind <> 10)) 
						OR IV.autokind is null
			          		)
				)
				OR
				(IV.adate < @start
					AND ((IV.autokind = 11)OR(IV.autokind = 10)  ) 
				) 
			)
	
		    SELECT @var_payment_resid = SUM(EV.amount)
			FROM expensevar EV
			JOIN historypaymentview HPV
	  			ON HPV.idexp = EV.idexp
		    WHERE EV.yvar = @ayear
			AND HPV.ymov = @ayear
			AND ( (totflag & 1) = 1) -- Residuo
	    			AND (
				(HPV.competencydate < @start
			  		AND ( 
						(   (EV.autokind <> 11) AND(EV.autokind <> 10)  ) 
						OR EV.autokind is null
			          		         )
				)
				OR
				(EV.adate  < @start
					AND (   (EV.autokind = 11)OR(EV.autokind = 10)  ) 
				) 
			)
		END
		SELECT @tot_proceeds_comp  = ISNULL(@tot_proceeds_comp, 0) + ISNULL(@var_proceeds_comp, 0)
		SELECT @tot_proceeds_resid = ISNULL(@tot_proceeds_resid, 0) + ISNULL(@var_proceeds_resid, 0)
		SELECT @tot_payment_comp 	= ISNULL(@tot_payment_comp,0) + ISNULL(@var_payment_comp, 0)
		SELECT @tot_payment_resid 	= ISNULL(@tot_payment_resid,0) + ISNULL(@var_payment_resid, 0)

-- Per ulteriori dettagli in merito a questa modifica leggere la Documentazione del task n.4077	    	
		SELECT @floatfund = ISNULL(startfloatfund, 0)
		FROM surplus
		WHERE ayear = @ayear 
END

go
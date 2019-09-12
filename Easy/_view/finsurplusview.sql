-- CREAZIONE VISTA finsurplusview
IF EXISTS(select * from sysobjects where id = object_id(N'[finsurplusview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [finsurplusview]
GO




CREATE      VIEW [finsurplusview]
(
ayear,
creditsurplus,
floatfund
)
AS 
SELECT --DISTINCT
p.ayear,
-- Algoritmo applicato per campo avanzoamministrazione
-- Controllo Previsione Principale:
-- SE 'C' ALLORA Calcola Avanzo di Amministrazione
-- SE 'S' ALLORA Controlla la Previsione Secondaria:
-- SE 'C' ALLORA Calcola Avanzo di Amministrazione
(SELECT 
	CASE  
	WHEN  (p.fin_kind in (1,3)) THEN 
		ISNULL(
			ISNULL(
				(
				SELECT(SUM(upbtotal.currentprev) + SUM(upbtotal.previsionvariation))
		 		FROM fin b 
				JOIN upbtotal ON b.idfin = upbtotal.idfin
				WHERE  b.ayear = p.ayear AND p.idfinincomesurplus = b.idfin
				),
				(SELECT 
				((ISNULL(s.startfloatfund,0.0) +
		  		ISNULL(s.competencyproceeds,0.0) +
				ISNULL(s.residualproceeds,0.0)-
		  		(ISNULL(s.competencypayments,0.0) + ISNULL(s.residualpayments,0.0))) +
		  		(ISNULL(s.previousrevenue,0.0) + ISNULL(s.currentrevenue,0.0)) -
		  		(ISNULL(s.previousexpenditure,0.0) + ISNULL(s.currentexpenditure,0.0)))
		 		FROM surplus s WHERE s.ayear = (p.ayear-1))
			)
		,0.0)
	WHEN  (p.fin_kind = 2) THEN
	(
		
			ISNULL(
				ISNULL(
					(
					SELECT(SUM(upbtotal.currentprev) + SUM(upbtotal.previsionvariation))
			 		FROM fin b 
			 		JOIN upbtotal ON b.idfin = upbtotal.idfin
					WHERE  b.ayear = p.ayear AND p.idfinincomesurplus = b.idfin
					),
					(SELECT 
						(ISNULL(s.startfloatfund,0.0) +
				  		ISNULL(s.competencyproceeds,0.0) +
						ISNULL(s.residualproceeds,0.0)-
				  		(ISNULL(s.competencypayments,0.0) + ISNULL(s.residualpayments,0.0))
						)
			 		FROM surplus s WHERE s.ayear = (p.ayear-1)
					)
				)
			,0.0)
		)
	END
	)
	,
-- Algoritmo applicato per campo fondocassa
-- Controllo Previsione Principale:
-- SE 'S' ALLORA Calcola Fondo di Cassa
-- SE 'C' ALLORA Controlla la Previsione Secondaria:
-- SE 'S' ALLORA Calcola Fondo di Cassa
(SELECT 
	CASE  
	WHEN (p.fin_kind = 2) THEN
		ISNULL( 
			ISNULL(
				(
				 SELECT(SUM(upbtotal.currentprev) + SUM(upbtotal.previsionvariation))
				 FROM fin b 
				 JOIN upbtotal ON b.idfin = upbtotal.idfin
		 		 WHERE  b.ayear = p.ayear AND p.idfinincomesurplus = b.idfin
				),
				(SELECT 
				 (ISNULL(s.startfloatfund,0.0) +
				  ISNULL(s.competencyproceeds,0.0) +
				  ISNULL(s.residualproceeds,0.0) - 
				  (ISNULL(s.competencypayments,0) + ISNULL(s.residualpayments,0.0)))
				 FROM surplus s WHERE s.ayear = (p.ayear-1))
			)
		,0.0)
	WHEN p.fin_kind IN (1,3) THEN
		(
		CASE p.fin_kind
			WHEN 3 THEN
				ISNULL(
					ISNULL(
						(
						 SELECT(SUM(upbtotal.currentsecondaryprev) + SUM(upbtotal.secondaryvariation))
						 FROM fin b
						 JOIN upbtotal ON b.idfin = upbtotal.idfin
						 WHERE  b.ayear = p.ayear AND p.idfinincomesurplus = b.idfin
						),
						(SELECT 
							(ISNULL(s.startfloatfund,0.0) +
							  ISNULL(s.competencyproceeds,0.0) +
							  ISNULL(s.residualproceeds,0.0) - 
							  (ISNULL(s.competencypayments,0) + ISNULL(s.residualpayments,0.0))
							)
							FROM surplus s WHERE s.ayear = (p.ayear-1)
						)
					)
				,0.0)
			ELSE
				ISNULL(
					ISNULL(
						(SELECT 
				 			(ISNULL(s.startfloatfund,0.0) +
							  ISNULL(s.competencyproceeds,0.0) +
				  			  ISNULL(s.residualproceeds,0.0) - 
				  			  (ISNULL(s.competencypayments,0) + ISNULL(s.residualpayments,0.0))
							)
						 	FROM surplus s WHERE s.ayear = (p.ayear-1)
						)
					,0.0)
				,0.0)
			END
		)
		END 
)
FROM config p


GO

-- VERIFICA DI finsurplusview IN COLUMNTYPES --
DELETE FROM columntypes WHERE tablename = 'finsurplusview'
IF exists(SELECT * FROM columntypes WHERE tablename = 'finsurplusview' AND field = 'ayear')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '',sqltype = 'smallint',defaultvalue = '',allownull = 'N',systemtype = 'System.Int16',sqldeclaration = 'smallint',iskey = 'N',tablename = 'finsurplusview',denynull = 'S',format = '',col_len = '2',field = 'ayear',col_precision = '' where tablename = 'finsurplusview' AND field = 'ayear'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','','smallint','','N','System.Int16','smallint','N','finsurplusview','S','','2','ayear','')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finsurplusview' AND field = 'creditsurplus')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(38,2)',iskey = 'N',tablename = 'finsurplusview',denynull = 'N',format = '',col_len = '17',field = 'creditsurplus',col_precision = '38' where tablename = 'finsurplusview' AND field = 'creditsurplus'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(38,2)','N','finsurplusview','N','','17','creditsurplus','38')
GO

IF exists(SELECT * FROM columntypes WHERE tablename = 'finsurplusview' AND field = 'floatfund')
UPDATE columntypes set createuser = 'SARA',lastmoduser = '''SARA''',col_scale = '2',sqltype = 'decimal',defaultvalue = '',allownull = 'S',systemtype = 'System.Decimal',sqldeclaration = 'decimal(38,2)',iskey = 'N',tablename = 'finsurplusview',denynull = 'N',format = '',col_len = '17',field = 'floatfund',col_precision = '38' where tablename = 'finsurplusview' AND field = 'floatfund'
ELSE
INSERT INTO columntypes (createuser,lastmoduser,col_scale,sqltype,defaultvalue,allownull,systemtype,sqldeclaration,iskey,tablename,denynull,format,col_len,field,col_precision) VALUES('SARA','''SARA''','2','decimal','','S','System.Decimal','decimal(38,2)','N','finsurplusview','N','','17','floatfund','38')
GO

-- VERIFICA DI finsurplusview IN CUSTOMOBJECT --
IF EXISTS(select * from customobject where objectname = 'finsurplusview')
UPDATE customobject set isreal = 'N' where objectname = 'finsurplusview'
ELSE
INSERT INTO customobject (objectname, isreal) values('finsurplusview', 'N')
GO
-- FINE GENERAZIONE SCRIPT --


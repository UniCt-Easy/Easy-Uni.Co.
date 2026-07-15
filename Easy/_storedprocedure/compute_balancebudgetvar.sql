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

IF  exists (SELECT * FROM  dbo.sysobjects WHERE id = object_id(N'[compute_balancebudgetvar]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_balancebudgetvar]
GO

--setuser'amministrazione'
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
 -- exec [compute_balancebudgetvar] 2023, '12-31-2023', 'S' /*assestamento*/
CREATE      PROCEDURE [compute_balancebudgetvar]
(
	@ayear int,
	@adate date,
	@assestamento char(1)='N',
	@generatevar char(1) ='N',
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
AS 
BEGIN

DECLARE  @minlevel int 
SELECT @minlevel = min(nlevel) FROM  accountlevel WHERE ayear =@ayear AND flagusable='S'

DECLARE  @lenaccount int
SET @lenaccount =2+@minlevel*4

DECLARE  @nextayear int
SET	@nextayear = @ayear + 1

CREATE TABLE #situazione_upb_account
(
	idupb varchar(36),	idacc varchar(38),
	prev decimal(19,2),	
	prev2 decimal(19,2),	
	prev3 decimal(19,2),	
	prev4 decimal(19,2),
	prev5 decimal(19,2),	
	pre_mov decimal(19,2),
	pre_mov2 decimal(19,2),
	pre_mov3 decimal(19,2),
	pre_mov4 decimal(19,2),
	pre_mov5 decimal(19,2),
	scritture decimal(19,2),
	variazioni_esistenti decimal(19,2),
	variazioni_esistenti2 decimal(19,2),
	variazioni_esistenti3 decimal(19,2),
	variazioni_esistenti4 decimal(19,2),
	variazioni_esistenti5 decimal(19,2)
)

-- PREVISIONI INIZIALI COSTI RICAVI E IMMOBILIZZAZIONI E AMMORTAMENTI
-- IMPORTI CORRENTI PREIMPEGNI, per le upb con tipo upb

-- 1) Per le UPB che NON HANNO un Tipo UPB valorizzato e per quelle che hanno un Tipo UPB valorizzato, 
-- e nel Tipo UPB il flag "Considera preimpegni di budget ai fini dell'assestamento" NON è valorizzato, Easy applica la seguente formula:
-- Budget anno X+1 = (Budget corrente alla Data contabile -Scritture Costo\Ricavo alla Data contabile) + Budget corrente anno X+1 desumibile dalle Variazioni di budget anno X
INSERT INTO #situazione_upb_account(
 	idupb,	idacc,
	prev,prev2,prev3,prev4,prev5
)
	 
SELECT
	AY.idupb, AL.newidacc,
	SUM(AY.prevision), SUM(AY.prevision2), SUM(AY.prevision3), SUM(AY.prevision4), SUM(AY.prevision5)
	FROM  accountyear AY
	JOIN account A on AY.idacc=A.idacc 
	JOIN upb  ON upb.idupb = AY.idupb  
	JOIN accountlookup AL  	on AL.oldidacc = A.idacc
	LEFT OUTER JOIN epupbkind ON Upb.idepupbkind = epupbkind.idepupbkind
	WHERE AY.ayear= @ayear
		--AND Upb.idepupbkind is not null /* VINCOLATO */
		AND (epupbkind.idepupbkind IS NULL or (epupbkind.flag &1) = 0) /* NON CONSIDERA MOVIMENTI DI BUDGET*/
		AND (A.flagaccountusage & (64+128+256+131072 ))<>0  /*costi, ricavi, immobilizzazioni, ammortamenti*/
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
		AND len(AY.idacc)=@lenaccount
GROUP BY AY.idupb,AL.newidacc


-- 1) Per le UPB che NON HANNO un Tipo UPB valorizzato e per quelle che hanno un Tipo UPB valorizzato, 
-- e nel Tipo UPB il flag "Considera preimpegni di budget ai fini dell'assestamento" NON è valorizzato, Easy applica la seguente formula:
-- Budget anno X+1 = (Budget corrente alla Data contabile -Scritture Costo\Ricavo alla Data contabile) + Budget corrente anno X+1 desumibile dalle Variazioni di budget anno X

INSERT INTO #situazione_upb_account(
 	idupb,	idacc,
	prev,prev2,prev3,prev4,prev5
)
	 
SELECT
	AVD.idupb, SUBSTRING(AL.newidacc,1,@lenaccount),
	SUM(AVD.amount), SUM(AVD.amount2), SUM(AVD.amount3), SUM(AVD.amount4), SUM(AVD.amount5)
	FROM  accountvardetail AVD
	JOIN accountvar AV on AV.yvar=AVD.yvar AND AV.nvar=AVD.nvar
	JOIN account A on AVD.idacc=A.idacc 
	JOIN upb  ON upb.idupb = AVD.idupb  
	JOIN accountlookup AL  	on AL.oldidacc = A.idacc
	LEFT OUTER JOIN epupbkind ON Upb.idepupbkind = epupbkind.idepupbkind
	WHERE AV.yvar= @ayear
		AND AV.adate <= @adate 
		--AND Upb.idepupbkind is not null /* VINCOLATO */
		AND (epupbkind.idepupbkind IS NULL or (epupbkind.flag &1) = 0) /* NON CONSIDERA MOVIMENTI DI BUDGET*/
		AND AV.idaccountvarstatus=5 
		AND av.variationkind<>5
		AND (A.flagaccountusage & (64+128+256+131072 ))<>0  /*costi, ricavi, immobilizzazioni, ammortamenti*/
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 
GROUP BY AVD.idupb,SUBSTRING(AL.newidacc,1,@lenaccount)
 

-- 2) Per le UPB che HANNO un Tipo UPB valorizzato, e nel Tipo UPB il flag "Considera preimpegni di budget ai fini dell'assestamento" è valorizzato, Easy applica la seguente formula:
-- Budget anno X+1 = (Importo alla Data contabile dei Premovimenti di budget -Scritture Costo\Ricavo alla Data contabile) + Importo anno X+1 alla Data contabile dei Premovimenti di budget anno X (vedi immagine)

-- IMPORTI CORRENTI PREIMPEGNI, per le upb senza tipo upb
INSERT INTO #situazione_upb_account(
 	idupb,
	idacc,
	pre_mov,pre_mov2,pre_mov3,pre_mov4,pre_mov5
	)
SELECT EY.idupb, SUBSTRING(AL.newidacc,1,@lenaccount),
	SUM(CASE WHEN E.flagvariation='N' THEN  EY.amount ELSE -EY.amount END),
	SUM(CASE WHEN E.flagvariation='N' THEN  EY.amount2 ELSE -EY.amount2 END),
	SUM(CASE WHEN E.flagvariation='N' THEN  EY.amount3 ELSE -EY.amount3 END),
	SUM(CASE WHEN E.flagvariation='N' THEN  EY.amount4 ELSE -EY.amount4 END),
	SUM(CASE WHEN E.flagvariation='N' THEN  EY.amount5 ELSE -EY.amount5 END)
	FROM  epexpyear EY				
	JOIN upb			ON upb.idupb = EY.idupb  
	JOIN epexp E		ON E.idepexp = EY.idepexp
	JOIN account A		on EY.idacc=A.idacc 
	JOIN accountlookup AL  	on AL.oldidacc = EY.idacc
	JOIN epupbkind ON Upb.idepupbkind = epupbkind.idepupbkind
	WHERE E.nphase = 1 AND EY.ayear = @ayear
		AND E.adate <= @adate
		AND ((epupbkind.flag &1 <> 0) )/* Considera i movimenti di Budget */
		AND (A.flagaccountusage & (64+128+256+131072 ))<>0  /*costi, ricavi, immobilizzazioni, ammortamenti*/
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 			
GROUP BY EY.idupb, SUBSTRING(AL.newidacc,1,@lenaccount)



-- 2) Per le UPB che HANNO un Tipo UPB valorizzato, e nel Tipo UPB il flag "Considera preimpegni di budget ai fini dell'assestamento" è valorizzato, Easy applica la seguente formula:
-- Budget anno X+1 = (Importo alla Data contabile dei Premovimenti di budget -Scritture Costo\Ricavo alla Data contabile) + Importo anno X+1 alla Data contabile dei Premovimenti di budget anno X (vedi immagine)

INSERT INTO #situazione_upb_account(
 	idupb,
	idacc,
	pre_mov,pre_mov2,pre_mov3,pre_mov4,pre_mov5
	)
SELECT EY.idupb, SUBSTRING(AL.newidacc,1,@lenaccount),
	SUM(CASE WHEN E.flagvariation='N' THEN  EV.amount ELSE -EV.amount END),
	SUM(CASE WHEN E.flagvariation='N' THEN  EV.amount2 ELSE -EV.amount2 END),
	SUM(CASE WHEN E.flagvariation='N' THEN  EV.amount3 ELSE -EV.amount3 END),
	SUM(CASE WHEN E.flagvariation='N' THEN  EV.amount4 ELSE -EV.amount4 END),
	SUM(CASE WHEN E.flagvariation='N' THEN  EV.amount5 ELSE -EV.amount5 END)
	FROM  epexpyear EY				
	JOIN epexpvar EV on EV.idepexp=EY.idepexp
	JOIN upb			ON upb.idupb = EY.idupb  
	JOIN epexp E		ON E.idepexp = EY.idepexp
	JOIN account A		on EY.idacc=A.idacc 
	JOIN accountlookup AL  	on AL.oldidacc = EY.idacc
	JOIN epupbkind ON Upb.idepupbkind = epupbkind.idepupbkind
	WHERE E.nphase = 1 AND EY.ayear = @ayear
		AND EV.yvar=@ayear  AND EV.adate <= @adate
		AND ((epupbkind.flag &1 <> 0)) /* Considera Movimenti di Budget ai fini dell'assestamento */
		AND (A.flagaccountusage & (64+128+256+131072 ))<>0  /*costi, ricavi, immobilizzazioni, ammortamenti*/
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 			
GROUP BY EY.idupb,  SUBSTRING(AL.newidacc,1,@lenaccount)




-- 2) Per le UPB che HANNO un Tipo UPB valorizzato, e nel Tipo UPB il flag "Considera preimpegni di budget ai fini dell'assestamento" è valorizzato, Easy applica la seguente formula:
-- Budget anno X+1 = (Importo alla Data contabile dei Premovimenti di budget -Scritture Costo\Ricavo alla Data contabile) + Importo anno X+1 alla Data contabile dei Premovimenti di budget anno X (vedi immagine)

--importi correnti PREACCERTAMENTI
INSERT INTO #situazione_upb_account(
 	idupb,	idacc,
	pre_mov,pre_mov2,pre_mov3,pre_mov4,pre_mov5
	)
SELECT AY.idupb, SUBSTRING(AL.newidacc,1,@lenaccount),
	SUM(CASE WHEN AA.flagvariation='N' THEN  AY.amount ELSE -AY.amount END),
	SUM(CASE WHEN AA.flagvariation='N' THEN  AY.amount2 ELSE -AY.amount2 END),
	SUM(CASE WHEN AA.flagvariation='N' THEN  AY.amount3 ELSE -AY.amount3 END),
	SUM(CASE WHEN AA.flagvariation='N' THEN  AY.amount4 ELSE -AY.amount4 END),
	SUM(CASE WHEN AA.flagvariation='N' THEN  AY.amount5 ELSE -AY.amount5 END)
FROM  epaccyear AY			
	JOIN upb				ON upb.idupb = AY.idupb  
	JOIN epacc AA			ON AA.idepacc = AY.idepacc
	JOIN account A		on AY.idacc=A.idacc 
	JOIN accountlookup AL  	on AL.oldidacc = AY.idacc
	JOIN epupbkind ON Upb.idepupbkind = epupbkind.idepupbkind
WHERE   AA.nphase = 1 AND AY.ayear = @ayear
		AND AA.adate <= @adate
		AND ((epupbkind.flag &1) <> 0) /* Considera movimenti di Budget */
		AND (A.flagaccountusage & (64+128+256+131072 ))<>0  /*costi, ricavi, immobilizzazioni, ammortamenti*/
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 			
GROUP BY AY.idupb,SUBSTRING(AL.newidacc,1,@lenaccount)



-- 2) Per le UPB che HANNO un Tipo UPB valorizzato, e nel Tipo UPB il flag "Considera preimpegni di budget ai fini dell'assestamento" è valorizzato, Easy applica la seguente formula:
-- Budget anno X+1 = (Importo alla Data contabile dei Premovimenti di budget -Scritture Costo\Ricavo alla Data contabile) + Importo anno X+1 alla Data contabile dei Premovimenti di budget anno X (vedi immagine)


INSERT INTO #situazione_upb_account(
 	idupb,
	idacc,
	pre_mov,pre_mov2,pre_mov3,pre_mov4,pre_mov5
	)
SELECT EY.idupb,SUBSTRING(AL.newidacc,1,@lenaccount),
	SUM(CASE WHEN E.flagvariation='N' THEN  EV.amount ELSE -EV.amount END),
	SUM(CASE WHEN E.flagvariation='N' THEN  EV.amount2 ELSE -EV.amount2 END),
	SUM(CASE WHEN E.flagvariation='N' THEN  EV.amount3 ELSE -EV.amount3 END),
	SUM(CASE WHEN E.flagvariation='N' THEN  EV.amount4 ELSE -EV.amount4 END),
	SUM(CASE WHEN E.flagvariation='N' THEN  EV.amount5 ELSE -EV.amount5 END)
	FROM  epaccyear EY				
	JOIN epaccvar EV	on EV.idepacc=EY.idepacc
	JOIN upb			ON upb.idupb = EY.idupb  
	JOIN epacc E		ON E.idepacc = EY.idepacc	
	JOIN account A		on EY.idacc=A.idacc 
	JOIN accountlookup AL  	on AL.oldidacc = EY.idacc
	JOIN epupbkind ON Upb.idepupbkind = epupbkind.idepupbkind
	WHERE E.nphase = 1 AND EY.ayear = @ayear
		AND EV.yvar=@ayear  AND EV.adate <= @adate
		AND ((epupbkind.flag &1) <> 0 )/* Considera movimenti di Budget */
		AND (A.flagaccountusage & (64+128+256+131072 ))<>0  /*costi, ricavi, immobilizzazioni, ammortamenti*/
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 			
GROUP BY EY.idupb,SUBSTRING(AL.newidacc,1,@lenaccount)

-- 1) Per le UPB che NON HANNO un Tipo UPB valorizzato e per quelle che hanno un Tipo UPB valorizzato, 
-- e nel Tipo UPB il flag "Considera preimpegni di budget ai fini dell'assestamento" NON è valorizzato, Easy applica la seguente formula:
-- Budget anno X+1 = (Budget corrente alla Data contabile -Scritture Costo\Ricavo alla Data contabile) + Budget corrente anno X+1 desumibile dalle Variazioni di budget anno X

-- 2) Per le UPB che HANNO un Tipo UPB valorizzato, e nel Tipo UPB il flag "Considera preimpegni di budget ai fini dell'assestamento" è valorizzato, Easy applica la seguente formula:
-- Budget anno X+1 = (Importo alla Data contabile dei Premovimenti di budget -Scritture Costo\Ricavo alla Data contabile) + Importo anno X+1 alla Data contabile dei Premovimenti di budget anno X (vedi immagine)
INSERT INTO #situazione_upb_account( 	idupb,	idacc,	scritture	)
SELECT ED.idupb,SUBSTRING(AL.newidacc,1,@lenaccount),
	SUM(CASE WHEN (A.flagaccountusage & 128) <> 0 THEN  ED.amount ELSE -ED.amount END)  --i costi si movimentano normalmente in dare quindi li cambiamo di segno
FROM  entrydetail ED
	JOIN entry E			on ED.yentry=E.yentry AND ED.nentry=E.nentry
	JOIN upb				ON upb.idupb = ED.idupb  
	JOIN account A			ON A.idacc = SUBSTRING(ED.idacc,1,@lenaccount)	
	JOIN accountlookup AL  	on AL.oldidacc = ED.idacc
WHERE   E.yentry = @ayear
		AND E.adate <= @adate
		AND (A.flagaccountusage & (64+128+256+131072 ))<>0  /*costi, ricavi, immobilizzazioni, ammortamenti*/
		AND E.identrykind <> 7
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 			
GROUP BY ED.idupb, SUBSTRING(AL.newidacc,1,@lenaccount)

DECLARE  @tipovariazione int
IF  (@assestamento='S') BEGIN
	SET @tipovariazione=3		--assestamento


	INSERT INTO  #situazione_upb_account( 	idupb,	idacc,
		variazioni_esistenti,variazioni_esistenti2,variazioni_esistenti3,variazioni_esistenti4,variazioni_esistenti5	)
	SELECT  AVD.idupb, AVD.idacc, 
	SUM(AVD.amount),SUM(AVD.amount2),SUM(AVD.amount3),SUM(AVD.amount4),SUM(AVD.amount5)
	FROM  accountvardetail AVD
	JOIN accountvar AV			on AVD.yvar=AV.yvar AND AVD.nvar=AV.nvar
	JOIN upb				ON upb.idupb = AVD.idupb  
	WHERE  AVD.yvar = @nextayear
		--AND E.adate <= @adate
		AND AV.variationkind = 3
		AND  AV.idaccountvarstatus=5
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 			
GROUP BY AVD.idupb, AVD.idacc


END
ELSE BEGIN
	SET @tipovariazione=5		--iniziale
END

--da sottrarre comunque
INSERT INTO  #situazione_upb_account( 	idupb,	idacc,
	variazioni_esistenti,variazioni_esistenti2,variazioni_esistenti3,variazioni_esistenti4,variazioni_esistenti5	)
	SELECT  AVD.idupb, AVD.idacc, 
	SUM(AVD.amount),SUM(AVD.amount2),SUM(AVD.amount3),SUM(AVD.amount4),SUM(AVD.amount5)
	FROM  accountvardetail AVD
	JOIN accountvar AV			on AVD.yvar=AV.yvar AND AVD.nvar=AV.nvar
	JOIN upb				ON upb.idupb = AVD.idupb  
	JOIN account A			ON A.idacc = SUBSTRING(AVD.idacc,1,@lenaccount)	
	WHERE  AVD.yvar = @nextayear
		--AND E.adate <= @adate
		AND AV.variationkind = 5
		AND (AV.idaccountvarstatus=5 )
		AND (AV.flag & 1)<>0
		AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01) 
		AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02) 
		AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03) 
		AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04) 
		AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05) 		
	GROUP BY AVD.idupb, AVD.idacc

DECLARE  @nMAXvar int
SELECT @nMAXvar = MAX(nvar) FROM  accountvar WHERE yvar=@nextayear
IF  @nMAXvar is null  SET @nMAXvar=0
 
DECLARE  @oggi date
SET @oggi= getdate();

DECLARE  @day1 date
SET @day1 =  CONVERT(date, '01-01-' + CONVERT(char(4), @nextayear), 105)

 IF  ( (SELECT count(*) FROM  #situazione_upb_account )<>0 AND @generatevar='S')
 BEGIN
	SET @nMAXvar = @nMAXvar + 1
	INSERT INTO accountvar(yvar, nvar, adate, description,  idaccountvarstatus, idman, 
				idsor01, idsor02, idsor03, idsor04,idsor05, variationkind,flag,
				ct, cu, lt, lu)
				
	VALUES (@nextayear, @nMAXvar,
				CASE WHEN @assestamento='S' THEN  @oggi ELSE @day1 END, 
				CASE WHEN @assestamento='S' THEN  'Assestamento di Budget' ELSE 'Budget presunto' END, 
				4 /* Inserita */, null,
				@idsor01,@idsor02,@idsor03,@idsor04,@idsor05, @tipovariazione, /*Assestamento*/
				CASE WHEN @assestamento='S' THEN  0 ELSE 1 END, 
				GETDATE(),'compute_balancebudgetvar',GETDATE(),'compute_balancebudgetvar')
	
	INSERT INTO accountvardetail(yvar, nvar, rownum, idacc, idupb,
						amount, 
						amount2, amount3, amount4, amount5, description,
						ct, cu, lt, lu)
	
	SELECT @nextayear, @nMAXvar, ROW_NUMBER()OVER (ORDER BY T.idacc, T.idupb) AS rownum,
				T.idacc,T.idupb,
				 --per upb con tipo upb: prev. anno corr. + prev. anno succ - scritture
				 --per upb senza tipo upb: preimpegni anno corr. + preimpegni anno succ - scritture
				 ISNULL(SUM(T.prev),0)  + ISNULL(SUM(T.prev2),0) +  ISNULL(SUM(T.pre_mov),0)+  ISNULL(SUM(T.pre_mov2),0) 
								- ISNULL(SUM(T.scritture),0) - ISNULL(SUM(T.variazioni_esistenti),0),				
					  ISNULL(SUM(prev3),0)+  ISNULL(SUM(T.pre_mov3),0)- ISNULL(SUM(T.variazioni_esistenti2),0),
					  ISNULL(SUM(prev4),0)+  ISNULL(SUM(T.pre_mov4),0)- ISNULL(SUM(T.variazioni_esistenti3),0),
					  ISNULL(SUM(prev5),0)+  ISNULL(SUM(T.pre_mov5),0)- ISNULL(SUM(T.variazioni_esistenti4),0),
					   0- ISNULL(SUM(T.variazioni_esistenti5),0),
						CASE WHEN @assestamento='S' THEN  'Assestamento di Budget' ELSE 'Budget presunto' END,
					GETDATE(),'compute_balancebudgetvar',GETDATE(),'compute_balancebudgetvar'
	 FROM  #situazione_upb_account T 		
		JOIN account A on A.idacc = T.idacc
		--WHERE  (A.flagaccountusage & 64+128+256+4096)<>0 -- DA VALUTARE
	GROUP BY  T.idacc, T.idupb
			HAVING
		(ISNULL(SUM(T.prev),0)  +  ISNULL(SUM(T.prev2),0) +  ISNULL(SUM(T.pre_mov),0)+  ISNULL(SUM(T.pre_mov2),0) 
								-  ISNULL(SUM(T.scritture),0) - ISNULL(SUM(T.variazioni_esistenti),0) ) <> 0 OR
		(ISNULL(SUM(prev3),0)	+  ISNULL(SUM(T.pre_mov3),0)- ISNULL(SUM(T.variazioni_esistenti2),0)  ) <> 0 OR
		(ISNULL(SUM(prev4),0)	+  ISNULL(SUM(T.pre_mov4),0)- ISNULL(SUM(T.variazioni_esistenti3),0)  ) <> 0 OR
		(ISNULL(SUM(prev5),0)	+  ISNULL(SUM(T.pre_mov5),0)- ISNULL(SUM(T.variazioni_esistenti4),0)  ) <> 0 OR
		( 0 - ISNULL(SUM(T.variazioni_esistenti5),0)  ) <> 0  
END



IF (@generatevar<>'S')
BEGIN
	SELECT @nextayear AS Esercizio,
	A.codeacc AS 'Codice Conto',
	A.title AS 'Conto',
	U.codeupb AS 'Codice UPB',
	U.title AS 'UPB',
	CASE WHEN epupbkind.flag&1<>0 THEN 'S' ELSE 'N' END AS 'Considera preimpegni di budget per assestamento',
	ISNULL(SUM(T.prev),0) AS 'Previsione corrente',
	ISNULL(SUM(T.prev2),0) AS 'Previsione corrente anno +2',
	ISNULL(SUM(T.prev3),0) AS 'Previsione corrente anno +3',
	ISNULL(SUM(T.prev4),0) AS 'Previsione corrente anno +4',
	ISNULL(SUM(T.prev5),0) AS 'Previsione corrente anno +5',
	ISNULL(SUM(T.pre_mov),0) AS 'Pre-Movimenti budget',
	ISNULL(SUM(T.pre_mov2),0) AS 'Pre-Movimenti budget anno +2',
	ISNULL(SUM(T.pre_mov3),0) AS 'Pre-Movimenti budget anno +3',
	ISNULL(SUM(T.pre_mov4),0) AS 'Pre-Movimenti budget anno +4',
	ISNULL(SUM(T.pre_mov5),0) AS 'Pre-Movimenti budget anno +5',
	ISNULL(SUM(T.scritture),0) AS 'costi o ricavi',
	ISNULL(SUM(T.variazioni_esistenti),0) AS 'Variazioni esistenti',
	ISNULL(SUM(T.variazioni_esistenti2),0) AS 'Variazioni esistenti anno +2',
	ISNULL(SUM(T.variazioni_esistenti3),0) AS 'Variazioni esistenti anno +3',
	ISNULL(SUM(T.variazioni_esistenti4),0) AS 'Variazioni esistenti anno +4',
	ISNULL(SUM(T.variazioni_esistenti5),0) AS 'Variazioni esistenti anno +5',
	ISNULL(SUM(T.prev),0)  + ISNULL(SUM(T.prev2),0) +  ISNULL(SUM(T.pre_mov),0)+  ISNULL(SUM(T.pre_mov2),0) 
	- ISNULL(SUM(T.scritture),0) - ISNULL(SUM(T.variazioni_esistenti),0) AS 'assestamento',				
	ISNULL(SUM(prev3),0)-ISNULL(SUM(T.variazioni_esistenti2),0)  AS 'assestamento anno +2',
	ISNULL(SUM(prev4),0)-ISNULL(SUM(T.variazioni_esistenti3),0) AS 'assestamento anno +3',
	ISNULL(SUM(prev5),0)-ISNULL(SUM(T.variazioni_esistenti4),0) AS 'assestamento anno +4', 
	0-ISNULL(SUM(T.variazioni_esistenti5),0) AS 'assestamento anno +5'
	FROM  #situazione_upb_account T 
		JOIN account A on A.idacc = T.idacc
		JOIN UPB U		on T.idupb = U.idupb
		left outer JOIN epupbkind ON U.idepupbkind = epupbkind.idepupbkind
	GROUP BY T.idacc, T.idupb,	A.codeacc, A.codeacc, A.title,	U.codeupb, U.title,epupbkind.flag
END


END

GO
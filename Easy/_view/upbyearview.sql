
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


-- CREAZIONE VISTA upbyearview
IF EXISTS(select * from sysobjects where id = object_id(N'[upbyearview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [upbyearview]
GO



--clear_table_info'upbyearview'
--setuser 'amm'
--setuser 'amministrazione'
--select * from upbyearview
CREATE     VIEW  upbyearview 
(
	idupb,
	codeupb,
	upb,
	paridupb,
	idman,
	manager,
	iddivision,
	codedivision,
	division,
	requested,
	granted,
	assured,
	ayear,
	initialprevision,
	incomeinitialprevision,
	currentprevision,
	incomecurrentprevision,
	initialsecondaryprev,
	incomeinitialsecondaryprev,
	currentsecondaryprev,
	incomecurrentsecondaryprev,
	incomeprevavailable,
	expenseprevavailable,
	appropriation,
	assessment,
	payment,
	proceeds,
	active,
	cupcode,
	printingorder,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	flagactivity,
	activity,
	flagkind,
	kindd,
	kindr,
	idtreasurer,
	treasurer,	
	start,
	stop,
	cigcode,
	cu,
	ct,
	lu,
	lt,
	idepupbkind,
	epupbkind,
	expiration,
	newcodeupb,
	revenueprevision,
	costprevision,
	cofogmpcode,
	uesiopecode,
	idunderwriter,
	ri_ra_quota,
	ri_rb_quota,
	ri_sa_quota,
	idupb_capofila,
	codeupb_capofila,
	upb_capofila,
	locked,
	blocca_cont_gen,
	blocca_cont_fin,
	soggetto_limitecosto
)

AS SELECT
	upb.idupb,
	upb.codeupb,
	upb.title,
	upb.paridupb,
	upb.idman,
	manager.title,
	division.iddivision,
	division.codedivision,
	division.description,
	upb.requested,
	upb.granted,
	upb.assured,
	accountingyear.ayear,
	-- initialprevision
	ISNULL(
		(SELECT SUM(upbtotal.currentprev)
		FROM    upbtotal (nolock)
		JOIN    fin (nolock)			ON fin.idfin = upbtotal.idfin
		WHERE   upbtotal.idupb = upb.idupb
		AND     ( (fin.flag & 1) <>0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND  flag&2 <> 0)
		AND     fin.ayear = accountingyear.ayear
		GROUP BY upbtotal.idupb)
	,0),
	-- incomeinitialprevision
	ISNULL( 
		(SELECT SUM(upbtotal.currentprev)
		FROM    upbtotal (nolock)
		JOIN    fin		(nolock)		ON fin.idfin = upbtotal.idfin
		WHERE   upbtotal.idupb = upb.idupb
		AND     ( (fin.flag & 1) = 0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND  flag&2 <> 0)
		AND     fin.ayear = accountingyear.ayear
		GROUP BY upbtotal.idupb)
	,0),
	-- currentprevision
	ISNULL(
		(SELECT SUM(upbtotal.currentprev)
		FROM    upbtotal (nolock)
		JOIN    fin (nolock)			ON fin.idfin = upbtotal.idfin
		WHERE   upbtotal.idupb = upb.idupb
		AND     ( (fin.flag & 1) <>0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND  flag&2 <> 0)
		AND     fin.ayear = accountingyear.ayear
		GROUP BY upbtotal.idupb)
	,0)
	+
	ISNULL(
		(SELECT SUM(upbtotal.previsionvariation)
		FROM    upbtotal (nolock)
		JOIN    fin (nolock)			ON fin.idfin = upbtotal.idfin
		WHERE   upbtotal.idupb = upb.idupb
		AND     ( (fin.flag & 1) <>0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND  flag&2 <> 0)
		AND     fin.ayear = accountingyear.ayear
		GROUP BY upbtotal.idupb)
	,0),
	-- incomecurrentprevision
	ISNULL(
		(SELECT SUM(upbtotal.currentprev)
		FROM    upbtotal (nolock)
		JOIN    fin (nolock)			ON fin.idfin = upbtotal.idfin
		WHERE   upbtotal.idupb = upb.idupb
		AND     ( (fin.flag & 1) = 0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND  flag&2 <> 0)
		AND     fin.ayear = accountingyear.ayear
		GROUP BY upbtotal.idupb)
	,0)
	+
	ISNULL(
		(SELECT SUM(upbtotal.previsionvariation)
		FROM    upbtotal (nolock)
		JOIN    fin (nolock)			ON fin.idfin = upbtotal.idfin
		WHERE   upbtotal.idupb = upb.idupb
		AND     ( (fin.flag & 1) = 0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND  flag&2 <> 0)
		AND     fin.ayear = accountingyear.ayear
		GROUP BY upbtotal.idupb)
	,0),
	-- initialsecondaryprev
	CASE
		WHEN config.fin_kind = 3
		THEN
			ISNULL(
				(SELECT SUM(upbtotal.currentsecondaryprev)
				FROM    upbtotal (nolock)
				JOIN    fin (nolock)					ON fin.idfin = upbtotal.idfin
				WHERE   upbtotal.idupb = upb.idupb
				AND     ( (fin.flag & 1) <>0)
				AND     fin.nlevel  = (SELECT MIN(nlevel) 
							 FROM finlevel 
							WHERE ayear = fin.ayear AND  flag&2 <> 0)
				AND     fin.ayear = accountingyear.ayear
				GROUP BY upbtotal.idupb)
			,0)
		ELSE NULL
	END,
	-- incomeinitialsecondaryprev
	CASE
		WHEN config.fin_kind = 3
		THEN
			ISNULL(
				(SELECT SUM(upbtotal.currentsecondaryprev)
				FROM    upbtotal (nolock)
				JOIN    fin (nolock)					ON fin.idfin = upbtotal.idfin
				WHERE   upbtotal.idupb = upb.idupb
				AND     ( (fin.flag & 1)  = 0)
				AND     fin.nlevel  = (SELECT MIN(nlevel) 
							 FROM finlevel 
							WHERE ayear = fin.ayear AND  flag&2 <> 0)
				AND     fin.ayear = accountingyear.ayear
				GROUP BY upbtotal.idupb)
			,0)
		ELSE NULL
	END,
	-- currentsecondaryprev
	CASE
		WHEN config.fin_kind = 3
		THEN
			ISNULL(
				(SELECT SUM(upbtotal.currentsecondaryprev)
				FROM    upbtotal (nolock)
				JOIN    fin (nolock)					ON fin.idfin = upbtotal.idfin
				WHERE   upbtotal.idupb = upb.idupb
				AND     ( (fin.flag & 1) <>0)
				AND     fin.nlevel  = (SELECT MIN(nlevel) 
							 FROM finlevel 
							WHERE ayear = fin.ayear AND  flag&2 <> 0)
				AND     fin.ayear = accountingyear.ayear
				GROUP BY upbtotal.idupb)
			,0)
			+ 
			ISNULL(
				(SELECT SUM(upbtotal.secondaryvariation)
				FROM    upbtotal (nolock)
				JOIN    fin (nolock)					ON fin.idfin = upbtotal.idfin
				WHERE   upbtotal.idupb = upb.idupb
				AND     ( (fin.flag & 1) <>0)
				AND     fin.nlevel  = (SELECT MIN(nlevel) 
							 FROM finlevel 
							WHERE ayear = fin.ayear AND  flag&2 <> 0)
				AND     fin.ayear = accountingyear.ayear
				GROUP BY upbtotal.idupb)
			,0)
		ELSE NULL
	END,

	-- incomecurrentsecondaryprev
	CASE
		WHEN config.fin_kind = 3
		THEN
			ISNULL(
				(SELECT SUM(upbtotal.currentsecondaryprev)
				FROM    upbtotal (nolock)
				JOIN    fin (nolock)		ON fin.idfin = upbtotal.idfin
				WHERE   upbtotal.idupb = upb.idupb
				AND     ( (fin.flag & 1)  = 0)
				AND     fin.nlevel  = (SELECT MIN(nlevel) 
							 FROM finlevel 
							WHERE ayear = fin.ayear AND  flag&2 <> 0)
				AND     fin.ayear = accountingyear.ayear
				GROUP BY upbtotal.idupb)
			,0)
			+ 
			ISNULL(
				(SELECT SUM(upbtotal.secondaryvariation)
				FROM    upbtotal (nolock)
				JOIN    fin (nolock)	ON fin.idfin = upbtotal.idfin
				WHERE   upbtotal.idupb = upb.idupb
				AND     ( (fin.flag & 1) = 0)
				AND     fin.nlevel  = (SELECT MIN(nlevel) 
							 FROM finlevel 
							WHERE ayear = fin.ayear AND  flag&2 <> 0)
				AND     fin.ayear = accountingyear.ayear
				GROUP BY upbtotal.idupb)
			,0)
		ELSE NULL
	END,
	-- incomeprevavailable
	ISNULL(
		(SELECT SUM(upbtotal.currentprev)
		FROM    upbtotal (nolock)
		JOIN    fin (nolock)	ON fin.idfin = upbtotal.idfin
		WHERE   upbtotal.idupb = upb.idupb
		AND     ( (fin.flag & 1) =0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND  flag&2 <> 0)
		AND     fin.ayear = accountingyear.ayear
		GROUP BY upbtotal.idupb)
	,0)
	+
	ISNULL(
		(SELECT SUM(upbtotal.previsionvariation)
		FROM    upbtotal (nolock)
		JOIN    fin (nolock)	ON fin.idfin = upbtotal.idfin
		WHERE   upbtotal.idupb = upb.idupb
		AND     ( (fin.flag & 1) =0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND  flag&2 <> 0)
		AND     fin.ayear = accountingyear.ayear
		GROUP BY upbtotal.idupb)
	,0)
	-
	ISNULL(
		(SELECT
			ISNULL(SUM(upbincometotal.totalcompetency),0) + 
			CASE
				WHEN config.fin_kind = 2
				THEN ISNULL(SUM(upbincometotal.totalarrears),0)
				ELSE 0
			END
		FROM    upbincometotal (nolock)
			JOIN    fin (nolock)	ON fin.idfin = upbincometotal.idfin
		JOIN 	uniconfig (nolock)	ON upbincometotal.nphase = uniconfig.incomefinphase
		WHERE   upbincometotal.idupb = upb.idupb
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear  AND  flag&2 <> 0)
		AND     fin.ayear = accountingyear.ayear
		GROUP BY upbincometotal.idupb)
	,0),
	--expenseprevavailable
	ISNULL(
		(SELECT SUM(upbtotal.currentprev)
		FROM    upbtotal (nolock)
			JOIN    fin (nolock)	ON fin.idfin = upbtotal.idfin
		WHERE   upbtotal.idupb = upb.idupb
		AND     ( (fin.flag & 1) <> 0)
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND     fin.ayear = accountingyear.ayear
		GROUP BY upbtotal.idupb)
	,0)
	+
	ISNULL(
		(SELECT SUM(upbtotal.previsionvariation)
		FROM    upbtotal (nolock)
		JOIN    fin (nolock)	ON fin.idfin = upbtotal.idfin
		WHERE   upbtotal.idupb = upb.idupb
		AND     ( (fin.flag & 1) <>0 )
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel 
					WHERE ayear = fin.ayear  AND  flag&2 <> 0)
		AND     fin.ayear = accountingyear.ayear
		GROUP BY upbtotal.idupb)
	,0)
	-
	ISNULL(
		(SELECT
			ISNULL(SUM(upbexpensetotal.totalcompetency),0)  +
			CASE
				WHEN config.fin_kind = 2
				THEN ISNULL(SUM(upbexpensetotal.totalarrears),0)
				ELSE 0
			END
		FROM upbexpensetotal (nolock)
		JOIN fin (nolock)		ON fin.idfin = upbexpensetotal.idfin
		JOIN uniconfig  (nolock) ON upbexpensetotal.nphase = uniconfig.expensefinphase
		WHERE upbexpensetotal.idupb = upb.idupb
		AND fin.nlevel  =
			(SELECT MIN(nlevel) 
			FROM finlevel 
			WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND fin.ayear = accountingyear.ayear
		GROUP BY upbexpensetotal.idupb)
	,0),
	-- appropriation
	ISNULL(
		(SELECT
			ISNULL(SUM(upbexpensetotal.totalcompetency),0)  +
			CASE
				WHEN config.fin_kind = 2
				THEN ISNULL(SUM(upbexpensetotal.totalarrears),0)
				ELSE 0
			END
		FROM upbexpensetotal (nolock)
		JOIN fin (nolock)	ON fin.idfin = upbexpensetotal.idfin
		JOIN uniconfig  (nolock) ON upbexpensetotal.nphase = uniconfig.expensefinphase
		WHERE upbexpensetotal.idupb = upb.idupb
		AND fin.nlevel  =
			(SELECT MIN(nlevel) 
			FROM finlevel (nolock)
			WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND fin.ayear = accountingyear.ayear
		GROUP BY upbexpensetotal.idupb)
	,0),
	-- assessment
	ISNULL(
		(SELECT
			ISNULL(SUM(upbincometotal.totalcompetency),0) + 
			CASE
				WHEN config.fin_kind = 2
				THEN ISNULL(SUM(upbincometotal.totalarrears),0)
				ELSE 0
			END
		FROM    upbincometotal (nolock)
		JOIN    fin (nolock)	ON fin.idfin = upbincometotal.idfin
		JOIN 	uniconfig  (nolock)
			ON upbincometotal.nphase = uniconfig.incomefinphase
		WHERE   upbincometotal.idupb = upb.idupb
		AND     fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel  (nolock)
					WHERE ayear = fin.ayear  AND  flag&2 <> 0)
		AND     fin.ayear = accountingyear.ayear
		GROUP BY upbincometotal.idupb)
	,0),
	-- payment
	ISNULL(
		(SELECT
			ISNULL(SUM(upbexpensetotal.totalcompetency),0)  +
			ISNULL(SUM(upbexpensetotal.totalarrears),0)
		FROM upbexpensetotal (nolock)
		JOIN fin 	ON fin.idfin = upbexpensetotal.idfin
		WHERE upbexpensetotal.idupb = upb.idupb
		AND fin.nlevel  =
			(SELECT MIN(nlevel) 
			FROM finlevel  (nolock)
			WHERE ayear = fin.ayear AND flag&2 <> 0)
		AND fin.ayear = accountingyear.ayear
		AND upbexpensetotal.nphase = (SELECT MAX(nphase) FROM expensephase)
		GROUP BY upbexpensetotal.idupb)
	,0),
	-- proceeds
	ISNULL(
		(SELECT
			ISNULL(SUM(upbincometotal.totalcompetency),0) + 
			ISNULL(SUM(upbincometotal.totalarrears),0)
		FROM    upbincometotal (nolock)
		JOIN    fin (nolock)	ON fin.idfin = upbincometotal.idfin
		WHERE upbincometotal.idupb = upb.idupb
		AND fin.nlevel  = (SELECT MIN(nlevel) 
					 FROM finlevel  (nolock)
					WHERE ayear = fin.ayear  AND  flag&2 <> 0)
		AND fin.ayear = accountingyear.ayear
		AND upbincometotal.nphase = (SELECT MAX(nphase) FROM incomephase)
		GROUP BY upbincometotal.idupb)
	,0),
	upb.active,
	upb.cupcode,
	upb.printingorder,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	upb.flagactivity,
--	activity,
	case
	when upb.flagactivity ='1' then 'Istituzionale'
	when upb.flagactivity ='2' then 'Commerciale'
	-- when upb.flagactivity ='3' then 'p': l'upb non ha il promiscuo
	when upb.flagactivity ='4' then 'Qualsiasi/Non specificata'
	end,
	upb.flagkind,
--	kindd,
	CASE
		when (( upb.flagkind & 1)<> 0) then 'S'
	End,
--	kindr,
	CASE
		when (( upb.flagkind & 2)<>0) then 'S'
	End,
	upb.idtreasurer,
	treasurer.description,
	upb.start,
	upb.stop,
	upb.cigcode,
	upb.cu,
	upb.ct,
	upb.lu,
	upb.lt,
	upb.idepupbkind,
	epupbkind.title,
	upb.expiration,
	upb.newcodeupb,
	upbyear.revenueprevision,
	upbyear.costprevision,
	upb.cofogmpcode,
	upb.uesiopecode,
	upb.idunderwriter,
	null,
	null,
	null,
	upb.idupb_capofila,
	upb_capofila.codeupb,
	upb_capofila.title,
	upbyear.locked,
	CASE when (( isnull(upbyear.locked, 0) & 1) = 0)  then 'N' ELSE 'S' END, 
	CASE when (( isnull(upbyear.locked, 0) & 2) = 0)  then 'N' ELSE 'S' END, 
	CASE when (( isnull(upbyear.locked, 0) & 4) = 0)  then 'N' ELSE 'S' END
FROM upb (nolock)
CROSS JOIN accountingyear (nolock)
JOIN config (nolock)				ON config.ayear = accountingyear.ayear
LEFT OUTER JOIN manager	(nolock)	ON upb.idman = manager.idman
LEFT OUTER JOIN division (nolock)	ON division.iddivision = manager.iddivision
LEFT OUTER JOIN treasurer (nolock)	ON treasurer.idtreasurer = upb.idtreasurer
LEFT OUTER JOIN epupbkind (nolock)	ON epupbkind.idepupbkind = upb.idepupbkind
LEFT OUTER JOIN upbyear	(nolock)	on upbyear.idupb = upb.idupb and upbyear.ayear = accountingyear.ayear
LEFT OUTER JOIN upb upb_capofila (nolock)	on upb.idupb_capofila = upb_capofila.idupb  


GO
 

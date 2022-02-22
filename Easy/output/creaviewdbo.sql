
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


IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'inventorytreeview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW inventorytreeview
GO



CREATE      VIEW [DBO].inventorytreeview
(
	idinv,
	codeinv,
	nlevel,
	leveldescr,
	paridinv,
	description, 
	idinv_lev1,
	codeinv_lev1,
	lookupcode,
	cu, ct, lu, lt
)
AS SELECT 
	inventorytree.idinv,
	inventorytree.codeinv,
	inventorytree.nlevel,
	inventorysortinglevel.description, 
	inventorytree.paridinv,
	inventorytree.description, 
	i1.idinv,
	i1.codeinv,
	inventorytree.lookupcode,
	inventorytree.cu,inventorytree.ct, inventorytree.lu, inventorytree.lt
FROM inventorytree
JOIN inventorysortinglevel
	ON inventorysortinglevel.nlevel = inventorytree.nlevel
JOIN inventorytreelink ilk
	ON  ilk.idchild=inventorytree.idinv
	AND ilk.nlevel=1
JOIN inventorytree i1
	ON ilk.idparent= i1.idinv



GO

print '[DBO].inventorytreeview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'accmotivedetailview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW accmotivedetailview
GO

CREATE      VIEW [DBO].[accmotivedetailview]
		(
		idaccmotive,
		idacc,
		cu,
		ct,
		lu,
		lt,
		codeacc,
		account,
		ayear,
		idaccountkind,
		flagregistry,
		flagupb
		)
	AS SELECT
		accmotivedetail.idaccmotive,
		accmotivedetail.idacc,
		accmotivedetail.cu,
		accmotivedetail.ct,
		accmotivedetail.lu,
		accmotivedetail.lt,
		account.codeacc,
		account.title,
		account.ayear,
		account.idaccountkind,
		account.flagregistry,
		account.flagupb
		FROM accmotivedetail (NOLOCK)
		JOIN account  on account.idacc= accmotivedetail.idacc

GO

print '[DBO].[accmotivedetailview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'accmotiveepoperationview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW accmotiveepoperationview
GO

CREATE       VIEW [DBO].[accmotiveepoperationview]
	(
		idaccmotive,
		codemotive,
		motive,
		idepoperation,
		epoperation,
		cu,
		ct,
		lu,
		lt
	)
	AS
	SELECT
		accmotiveepoperation.idaccmotive,
		accmotive.codemotive,
		accmotive.title,
		accmotiveepoperation.idepoperation,
		epoperation.title,
		accmotiveepoperation.cu,
		accmotiveepoperation.ct,
		accmotiveepoperation.lu,
		accmotiveepoperation.lt
		FROM accmotiveepoperation
		JOIN accmotive
		ON accmotive.idaccmotive = accmotiveepoperation.idaccmotive
		JOIN epoperation
		ON epoperation.idepoperation = accmotiveepoperation.idepoperation

GO

print '[DBO].[accmotiveepoperationview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'accmotiveunusable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW accmotiveunusable
GO

CREATE       VIEW [DBO].[accmotiveunusable]
	(
		idaccmotive,
		paridaccmotive,
		codemotive,
		title,
		active,
		cu,
		ct,
		lu,
		lt
	)
	AS SELECT
		accmotive.idaccmotive,
		accmotive.paridaccmotive,
		accmotive.codemotive,
		accmotive.title,
		accmotive.active,
		accmotive.cu,
		accmotive.ct,
		accmotive.lu,
		accmotive.lt
		FROM accmotive (NOLOCK)
		WHERE (SELECT count(*) FROM accmotive b1
		WHERE b1.paridaccmotive = accmotive.idaccmotive )>0

GO

print '[DBO].[accmotiveunusable] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'accmotiveusable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW accmotiveusable
GO

CREATE       VIEW [DBO].[accmotiveusable]
	(
		idaccmotive,
		paridaccmotive,
		codemotive,
		title,
		active,
		cu,
		ct,
		lu,
		lt
	)
	AS SELECT
		accmotive.idaccmotive,
		accmotive.paridaccmotive,
		accmotive.codemotive,
		accmotive.title,
		accmotive.active,
		accmotive.cu,
		accmotive.ct,
		accmotive.lu,
		accmotive.lt
		FROM accmotive (NOLOCK)
		WHERE (SELECT count(*) FROM accmotive b1
		WHERE b1.paridaccmotive = accmotive.idaccmotive )=0

GO

print '[DBO].[accmotiveusable] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'accountlookupview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW accountlookupview
GO

CREATE       VIEW [DBO].[accountlookupview] 
	(
		oldidacc,
		oldayear,
		oldcodeacc,
		oldtitle,
		newidacc,
		newayear,
		newcodeacc,
		newtitle,
		cu, 
		ct, 
		lu, 
		lt
	)
	AS SELECT
		accountlookup.oldidacc,
		oldconto.ayear,
		oldconto.codeacc,
		oldconto.title,
		accountlookup.newidacc,
		newconto.ayear,
		newconto.codeacc,
		newconto.title,
		accountlookup.cu,
		accountlookup.ct,
		accountlookup.lu,
		accountlookup.lt
		FROM accountlookup (NOLOCK)
		JOIN account oldconto (NOLOCK)
		ON oldconto.idacc = accountlookup.oldidacc
		JOIN account newconto (NOLOCK)
		ON newconto.idacc = accountlookup.newidacc

GO

print '[DBO].[accountlookupview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'accountunusable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW accountunusable
GO

CREATE      VIEW [DBO].[accountunusable]
	(
		idacc,
		ayear,
		codeacc,
		paridacc,
		nlevel,
		printingorder,
		title,
		idaccountkind,
		accountkind,
		flagda,
		flagregistry,
		flagupb,
		flagtransitory,
		cu,
		ct,
		lu,
		lt
	)
	AS SELECT
		account.idacc,
		account.ayear,
		account.codeacc,
		account.paridacc,
		account.nlevel,
		account.printingorder,
		account.title,
		account.idaccountkind,
		accountkind.description,
		accountkind.flagda,
		account.flagregistry,
		account.flagupb,
		account.flagtransitory,
		account.cu,
		account.ct,
		account.lu,
		account.lt
		FROM account (NOLOCK)
		JOIN accountlevel (NOLOCK) 
		ON accountlevel.ayear = account.ayear
		AND accountlevel.nlevel = account.nlevel
		LEFT OUTER JOIN accountkind (NOLOCK) 
		on  accountkind.idaccountkind=account.idaccountkind
		WHERE accountlevel.flagusable = 'N'	OR
		(SELECT count(*) FROM account b1
		WHERE b1.paridacc = account.idacc )>0

GO

print '[DBO].[accountunusable] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'accountusable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW accountusable
GO

CREATE      VIEW [DBO].[accountusable]
	(
		idacc,
		ayear,
		codeacc,
		paridacc,
		nlevel,
		printingorder,
		title,
		idaccountkind,
		accountkind,
		flagda,
		flagregistry,
		flagupb,
		flagtransitory,
		cu,
		ct,
		lu,
		lt
	)
	AS SELECT
		account.idacc,
		account.ayear,
		account.codeacc,
		account.paridacc,
		account.nlevel,
		account.printingorder,
		account.title,
		account.idaccountkind,
		accountkind.description,
		accountkind.flagda,
		account.flagregistry,
		account.flagupb,
		account.flagtransitory,
		account.cu,
		account.ct,
		account.lu,
		account.lt
		FROM account (NOLOCK)
		JOIN accountlevel (NOLOCK) 
		ON accountlevel.ayear = account.ayear
		AND accountlevel.nlevel = account.nlevel
		JOIN accountkind (NOLOCK) 
		on  accountkind.idaccountkind=account.idaccountkind
		WHERE accountlevel.flagusable = 'S' and
		(SELECT count(*) FROM account b1
		WHERE b1.paridacc = account.idacc )=0

GO

print '[DBO].[accountusable] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'inventorytreeunusable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW inventorytreeunusable
GO

CREATE                   VIEW [DBO].inventorytreeunusable 
(
	idinv,
	codeinv,
	nlevel,
	leveldescr,
	paridinv,
	description,
	cu, 
	ct, 
	lu, 
	lt
)
AS SELECT
	inventorytree.idinv,
	inventorytree.codeinv,
	inventorytree.nlevel,
	inventorysortinglevel.description,
	inventorytree.paridinv,
	inventorytree.description,
	inventorytree.cu, 
	inventorytree.ct, 
	inventorytree.lu,
	inventorytree.lt 
FROM inventorytree
JOIN inventorysortinglevel
	ON inventorysortinglevel.nlevel = inventorytree.nlevel
WHERE (inventorysortinglevel.flag & 2 <> 2)
	OR inventorytree.idinv IN
		(SELECT paridinv FROM inventorytree
		WHERE paridinv IS NOT NULL)

GO

print '[DBO].inventorytreeunusable OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'inventorytreeusable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW inventorytreeusable
GO

CREATE                   VIEW [DBO].inventorytreeusable 
(
	idinv,
	codeinv,
	nlevel,
	leveldescr,
	paridinv,
	description,
	cu, 
	ct, 
	lu, 
	lt
)
AS SELECT
	inventorytree.idinv,
	inventorytree.codeinv,
	inventorytree.nlevel,
	inventorysortinglevel.description,
	inventorytree.paridinv,
	inventorytree.description,
	inventorytree.cu, 
	inventorytree.ct, 
	inventorytree.lu,
	inventorytree.lt 
FROM inventorytree
JOIN inventorysortinglevel
	ON inventorysortinglevel.nlevel = inventorytree.nlevel
WHERE (inventorysortinglevel.flag & 2 <> 0)
	AND inventorytree.idinv NOT IN
		(SELECT paridinv FROM inventorytree
		WHERE paridinv IS NOT NULL)



GO

print '[DBO].inventorytreeusable OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'patrimonylookupview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW patrimonylookupview
GO

CREATE       VIEW [DBO].[patrimonylookupview] 
	(
		oldidpatrimony,
		oldayear,
		oldcodepatrimony,
		oldtitle,
		oldpatpart,
		newidpatrimony,
		newayear,
		newcodepatrimony,
		newtitle,
		newpatpart,
		cu, 
		ct, 
		lu, 
		lt
	)
	AS SELECT
		patrimonylookup.oldidpatrimony,
		oldstatopat.ayear,
		oldstatopat.codepatrimony,
		oldstatopat.title,
		oldstatopat.patpart,
		patrimonylookup.newidpatrimony,
		newstatopat.ayear,
		newstatopat.codepatrimony,
		newstatopat.title,
		newstatopat.patpart,
		patrimonylookup.cu,
		patrimonylookup.ct,
		patrimonylookup.lu,
		patrimonylookup.lt
		FROM patrimonylookup (NOLOCK)
		JOIN patrimony oldstatopat (NOLOCK)
		ON oldstatopat.idpatrimony = patrimonylookup.oldidpatrimony
		JOIN patrimony newstatopat (NOLOCK)
		ON newstatopat.idpatrimony = patrimonylookup.newidpatrimony

GO

print '[DBO].[patrimonylookupview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'patrimonyview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW patrimonyview
GO

	CREATE      VIEW [DBO].[patrimonyview]
	(
		idpatrimony,
		ayear,
		patpart,
		codepatrimony,
		nlevel,
		leveldescr,
		paridpatrimony,
		printingorder,
		title,
		active,
		cu, 
		ct, 
		lu, 
		lt
	)
	AS 
	SELECT patrimony.idpatrimony, 
		patrimony.ayear, 
		patrimony.patpart,
		patrimony.codepatrimony, 
		patrimony.nlevel,
		patrimonylevel.description, 
		patrimony.paridpatrimony,
		patrimony.printingorder,
		patrimony.title,
		patrimony.active,
		patrimony.cu, 
		patrimony.ct, patrimony.lu, 
		patrimony.lt
	FROM patrimony 
	(NOLOCK) INNER JOIN patrimonylevel
	ON patrimonylevel.ayear = patrimony.ayear
	AND patrimonylevel.nlevel = patrimony.nlevel

GO

print '[DBO].[patrimonyview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'placcountlookupview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW placcountlookupview
GO

CREATE       VIEW [DBO].[placcountlookupview] 
	(
		oldidplaccount,
		oldayear,
		oldcodeplaccount,
		oldtitle,
		oldplaccpart,
		newidplaccount,
		newayear,
		newcodeplaccount,
		newtitle,
		newplaccpart,
		cu, 
		ct, 
		lu, 
		lt
	)
	AS SELECT
		placcountlookup.oldidplaccount,
		oldcontoecon.ayear,
		oldcontoecon.codeplaccount,
		oldcontoecon.title,
		oldcontoecon.placcpart,
		placcountlookup.newidplaccount,
		newcontoecon.ayear,
		newcontoecon.codeplaccount,
		newcontoecon.title,
		newcontoecon.placcpart,
		placcountlookup.cu,
		placcountlookup.ct,
		placcountlookup.lu,
		placcountlookup.lt
		FROM placcountlookup (NOLOCK)
		JOIN placcount oldcontoecon (NOLOCK)
		ON oldcontoecon.idplaccount = placcountlookup.oldidplaccount
		JOIN placcount newcontoecon (NOLOCK)
		ON newcontoecon.idplaccount = placcountlookup.newidplaccount

GO

print '[DBO].[placcountlookupview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'placcountview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW placcountview
GO

CREATE       VIEW [DBO].[placcountview] 
	(
		idplaccount,
		ayear,
		placcpart,
		codeplaccount,
		nlevel,
		leveldescr,
		paridplaccount,
		printingorder,
		title,
		active,
		cu, 
		ct, 
		lu, 
		lt
	)
	AS 
	SELECT  placcount.idplaccount, 
		placcount.ayear, 
		placcount.placcpart,
		placcount.codeplaccount, 
		placcount.nlevel,
		placcountlevel.description, 
		placcount.paridplaccount,
		placcount.printingorder,
		placcount.title,
		placcount.active, 
		placcount.cu, 
		placcount.ct, 
		placcount.lu, 
		placcount.lt
	FROM placcount 
	(NOLOCK) INNER JOIN placcountlevel
	ON placcountlevel.ayear = placcount.ayear
	AND placcountlevel.nlevel = placcount.nlevel

GO

print '[DBO].[placcountview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'taxratestartview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW taxratestartview
GO


CREATE                       VIEW [DBO].taxratestartview 
(
	taxcode,
	tax,
	taxref,
	idtaxratestart,
	start,
	taxkind,
	taxablenumerator,
	taxabledenominator,
	enforcement,
	lu,
	lt
)
AS SELECT
	S.taxcode,
	T.description,
	T.taxref,
	S.idtaxratestart,
	S.start,
	T.taxkind,
	S.taxablenumerator,
	S.taxabledenominator,
	CASE
	WHEN S.enforcement = 'P' then 'Progressiva'
	WHEN S.enforcement = 'F' then 'Fascia Fissa'
	ELSE NULL
	END, 
	S.lu,
	S.lt
FROM  taxratestart S
JOIN  tax T
	ON T.taxcode = S.taxcode

GO

print '[DBO].taxratestartview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'taxratebracketview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW taxratebracketview
GO




CREATE                       VIEW [DBO].taxratebracketview 
(
	taxcode,
	tax,
	taxref,
	idtaxratestart,
	nbracket,
	start,
	taxkind,
	minamount,
	maxamount,
	taxablenumerator,
	taxabledenominator,
	adminrate,
	adminnumerator,
	admindenominator,
	employrate,
	employnumerator,
	employdenominator,
	lu,
	lt
)
AS SELECT
	B.taxcode,
	T.description,
	T.taxref,
	B.idtaxratestart,
	B.nbracket,
	S.start,
	T.taxkind,
	B.minamount,
	B.maxamount,
	S.taxablenumerator,
	S.taxabledenominator,
	B.adminrate,
	B.adminnumerator,
	B.admindenominator,
	B.employrate,
	B.employnumerator,
	B.employdenominator,
	B.lu,
	B.lt
FROM taxratebracket B
JOIN taxratestart S
	ON B.taxcode = S.taxcode
	AND B.idtaxratestart = S.idtaxratestart
JOIN tax T
	ON T.taxcode = B.taxcode





GO

print '[DBO].taxratebracketview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'abatementview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW abatementview
GO

CREATE                       VIEW [DBO].abatementview
AS
SELECT     abatement.idabatement, abatementcode.ayear, abatementcode.code AS abatementcode,--codicedetrazione, 
		      abatement.calculationkind, 
                      abatement.taxcode, abatement.description, abatementcode.longdescription, abatement.validitystart, 
                      abatement.validitystop, abatement.evaluatesp, abatement.evaluationorder, 
                      abatementcode.description AS abatementtitle, --desccodicedetrazione, 
		      abatementcode.exemption, abatementcode.maximal, 
                      abatementcode.rate, abatement.appliance, abatement.flagabatableexpense,
		      tax.taxref
FROM         abatement INNER JOIN abatementcode 
				ON abatement.idabatement = abatementcode.idabatement
			INNER JOIN  TAX
				ON TAX.taxcode= abatement.taxcode

GO

print '[DBO].abatementview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'geo_nation_agencyview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW geo_nation_agencyview
GO

CREATE      VIEW [DBO].[geo_nation_agencyview]
(
	idnation, 
	title,
	newnation,
	oldnation,
	idagency,
	agencyname,
	agencywebsite,
	idcode,
	version,
	codename,
	value,
	start,
	stop
)
AS
SELECT
	geo_nation_agency.idnation,
	geo_nation.title, 
	geo_nation.newnation,
	geo_nation.oldnation,
	geo_nation_agency.idagency, 
	geo_agency.title,
	geo_agency.website,
	geo_nation_agency.idcode, 
	geo_nation_agency.version,
	geo_code.codename,
	geo_nation_agency.value,
	geo_nation_agency.start, 
	geo_nation_agency.stop
FROM geo_code
JOIN geo_nation_agency
	ON geo_code.idagency = geo_nation_agency.idagency
	AND geo_code.idcode = geo_nation_agency.idcode
JOIN geo_nation
	ON geo_nation_agency.idnation = geo_nation.idnation
JOIN geo_agency
	ON geo_code.idagency = geo_agency.idagency



GO

print '[DBO].[geo_nation_agencyview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'registrydurcview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW registrydurcview
GO




CREATE        VIEW [DBO].[registrydurcview] 
(
	idreg,
	registry,
	idregistrydurc,
	iddurckind,
	durckinddescr,
	start,
	stop,
	adate,
	selfcertification,
	durccertification,
	doc,
	docdate,
	inpscode,
	inailcode,
	buildingcode,
	otherinsurancecode,
	cu, 
	ct, 
	lu,
	lt
)
AS 
SELECT
	registrydurc.idreg, 
	registry.title, 
	registrydurc.idregistrydurc,
	registrydurc.iddurckind,
	durckind.description,
	registrydurc.start,
	registrydurc.stop,
	registrydurc.adate,
	registrydurc.selfcertification,
	registrydurc.durccertification,
	registrydurc.doc,
	registrydurc.docdate,
	registrydurc.inpscode,
	registrydurc.inailcode,
	registrydurc.buildingcode,
	registrydurc.otherinsurancecode,
	registrydurc.cu, 
	registrydurc.ct, 
	registrydurc.lu, 
	registrydurc.lt
FROM registrydurc (NOLOCK)
JOIN durckind
	ON registrydurc.iddurckind = durckind.iddurckind
JOIN registry (NOLOCK)
	ON registrydurc.idreg = registry.idreg


GO

print '[DBO].[registrydurcview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'servicetaxview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW servicetaxview
GO


CREATE                   VIEW [DBO].servicetaxview
(
	taxcode,
	tax,
	taxref,
	idser, 
	servicedescription,
	codeser,
	cu,
	ct,
	lu, 
	lt,
	appliancebasis,
	geoappliance, 
	taxablecode,
	taxkind,
	module
)
AS
SELECT
	servicetax.taxcode,
	tax.description,
	tax.taxref,
	servicetax.idser, 
	service.description,
	service.codeser,
	servicetax.cu,
	servicetax.ct,
	servicetax.lu, 
	servicetax.lt,
	tax.appliancebasis,
	tax.geoappliance, 
	tax.taxablecode,
	tax.taxkind,
	service.module
FROM servicetax
JOIN tax
	ON tax.taxcode = servicetax.taxcode
JOIN service
	ON service.idser = servicetax.idser


GO

print '[DBO].servicetaxview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'geo_cityfiscalview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW geo_cityfiscalview
GO

CREATE          VIEW [DBO].geo_cityfiscalview
(
	idcity,
	city,
	idcountry,
	provincecode,
	idregion,
	region,
	idfiscaltaxregion,
	newcity,
	oldcity,
	start,
	stop,
	lt,
	lu
)
AS SELECT
	geo_city.idcity,
	geo_city.title,
	geo_city.idcountry,
	geo_country.province,
	geo_country.idregion,
	geo_region.title,
	ISNULL(fc.idfiscaltaxregion, fr.idfiscaltaxregion),
	geo_city.newcity,
	geo_city.oldcity,
	geo_city.start,
	geo_city.stop,
	geo_city.lt,
	geo_city.lu
FROM geo_city
JOIN geo_country
	ON geo_country.idcountry = geo_city.idcountry
JOIN geo_region
	ON geo_region.idregion = geo_country.idregion
LEFT OUTER JOIN fiscaltaxregion fr
	ON fr.idregion = geo_region.idregion
LEFT OUTER JOIN fiscaltaxregion fc
	ON fc.idcountry = geo_city.idcountry


GO

print '[DBO].geo_cityfiscalview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'geo_cityusable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW geo_cityusable
GO
--Pino Rana, elaborazione del 10/08/2005 15:18:02
CREATE                                                                view [DBO].[geo_cityusable] as 
	select * from geo_city g1 where newcity is null and stop is null
	and not exists (select * from geo_city g2 where g1.idcity=g2.oldcity)


GO

print '[DBO].[geo_cityusable] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'registryreferenceview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW registryreferenceview
GO




CREATE                     VIEW [DBO].registryreferenceview 
(
	idreg,
	idregistryreference,
	registry, 
	referencename, 
	registryreferencerole, 
	phonenumber,
	faxnumber, 
	mobilenumber,
	skypenumber,
	msnnumber,
	email,
	userweb,
	passwordweb,
	flagdefault,
	cu, 
	ct, 
	lu,
	lt
)
AS SELECT
	registryreference.idreg, 
	registryreference.idregistryreference,
	registry.title, 
	registryreference.referencename, 
	registryreference.registryreferencerole, 
	registryreference.phonenumber, 
	registryreference.faxnumber, 
	registryreference.mobilenumber,
	registryreference.skypenumber,
	registryreference.msnnumber,
	registryreference.email, 
	registryreference.userweb,
	registryreference.passwordweb,
	registryreference.flagdefault,
	registryreference.cu, 
	registryreference.ct, 
	registryreference.lu, 
	registryreference.lt
FROM registryreference (NOLOCK)
JOIN registry (NOLOCK)
	ON registryreference.idreg = registry.idreg





GO

print '[DBO].registryreferenceview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'deductionview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW deductionview
GO

--Pino Rana, elaborazione del 10/08/2005 15:18:06
CREATE                                                                 VIEW [DBO].deductionview
AS
SELECT     deduction.iddeduction, deductioncode.ayear, deductioncode.code AS deductioncode,--codicededuzione, 
			deduction.calculationkind, 
                      deduction.taxablecode, deduction.description, deductioncode.longdescription, deduction.validitystart, 
                      deduction.validitystop, deduction.evaluatesp, deduction.evaluationorder, 
                      deductioncode.description AS deductiontitle,--desccodicededuzione,
			 deductioncode.exemption, deductioncode.maximal, 
                      deductioncode.rate, deduction.flagdeductibleexpense
FROM         deduction INNER JOIN
                      deductioncode ON deduction.iddeduction = deductioncode.iddeduction INNER JOIN
                      taxablekind ON deduction.taxablecode = taxablekind.taxablecode AND 
                      deductioncode.ayear = taxablekind.ayear


GO

print '[DBO].deductionview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'geo_country_view') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW geo_country_view
GO
--Pino Rana, elaborazione del 10/08/2005 15:18:07
-- Inserire la CREATE VIEW qui--
CREATE                                                                VIEW [DBO].[geo_country_view]
(
idcountry, 
province, 
title, 
oldcountry, 
newcountry, 
start, 
stop, 
idregion, 
region, 
regiondatestart, 
regiondatestop, 
oldregion, 
newregion, 
idnation, 
idcontinent, 
nation, 
nationdatestart, 
nationdatestop, 
oldnation, 
newnation
)
AS
SELECT     geo_country.idcountry, geo_country.province, 
                      geo_country.title, geo_country.oldcountry, geo_country.newcountry, 
                      geo_country.start, geo_country.stop, geo_region.idregion, 
                      geo_region.title AS regione, geo_region.start AS datainizioregione, geo_region.stop AS datafineregione, 
                      geo_region.oldregion, geo_region.newregion, geo_nation.idnation, geo_nation.idcontinent, 
                      geo_nation.title AS nazione, geo_nation.start AS datainizionazione, geo_nation.stop AS datafinenazione, 
                      geo_nation.oldnation, geo_nation.newnation
FROM       geo_country INNER JOIN
                      geo_region ON geo_country.idregion = geo_region.idregion INNER JOIN
                      geo_nation ON geo_region.idnation = geo_nation.idnation


GO

print '[DBO].[geo_country_view] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'geo_region_view') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW geo_region_view
GO
--Pino Rana, elaborazione del 10/08/2005 15:18:07
-- Inserire la CREATE VIEW qui--
CREATE                                                                VIEW [DBO].[geo_region_view]
(
idregion, 
title, 
start, 
stop, 
oldregion, 
newregion, 
idnation, 
idcontinent, 
nation, 
nationdatestart, 
nationdatestop, 
oldnation, 
newnation
)
AS
SELECT     geo_region.idregion, 
                      geo_region.title, geo_region.start, geo_region.stop, 
                      geo_region.oldregion, geo_region.newregion, geo_nation.idnation, geo_nation.idcontinent, 
                      geo_nation.title AS nazione, geo_nation.start AS datainizionazione, geo_nation.stop AS datafinenazione, 
                      geo_nation.oldnation, geo_nation.newnation
FROM       geo_region INNER JOIN
                      geo_nation ON geo_region.idnation = geo_nation.idnation


GO

print '[DBO].[geo_region_view] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'registrytaxablestatusview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW registrytaxablestatusview
GO

--Pino Rana, elaborazione del 10/08/2005 15:18:07
-- Inserire la ALTER  VIEW qui--
CREATE                                                                 VIEW [DBO].[registrytaxablestatusview]
	(
	idreg,
	registry, 
	start,
  supposedincome,
	active,
	cu, 
	ct, 
	lu,
	lt
	)
	AS SELECT
	registrytaxablestatus.idreg, 
	registry.title, 
	registrytaxablestatus.start, 
	registrytaxablestatus.supposedincome, 
	registrytaxablestatus.active,
	registrytaxablestatus.cu, 
	registrytaxablestatus.ct, 
	registrytaxablestatus.lu,
	registrytaxablestatus.lt
	FROM registrytaxablestatus (NOLOCK)
	JOIN registry (NOLOCK)
	ON registrytaxablestatus.idreg = registry.idreg


GO

print '[DBO].[registrytaxablestatusview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'registrypaymethodview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW registrypaymethodview
GO





CREATE  VIEW [DBO].[registrypaymethodview]
(
	idreg, 
	idregistrypaymethod,
	regmodcode, 
	registry, 
	idpaymethod, 
	paymethod, 
	allowdeputy,
	iban,
	cin, 
	idbank, 
	banktitle, 
	idcab, 
	cabtitle, 
	cc, 
	biccode,
	paymentdescr, 
	paymentexpiring, 
	idexpirationkind, 
	flagstandard, 
	active, 
	iddeputy,
	deputy,
	idcurrency,
	codecurrency,
	currency,
        extracode,
	cu, ct, lu, lt
)
AS SELECT 
	registrypaymethod.idreg, 
	registrypaymethod.idregistrypaymethod,
	registrypaymethod.regmodcode, 
	registry.title, 
	registrypaymethod.idpaymethod, 
	paymethod.description, 
	paymethod.allowdeputy,
	registrypaymethod.iban,
	registrypaymethod.cin, 
	registrypaymethod.idbank, 
	bank.description, 
	registrypaymethod.idcab, 
	cab.description, 
	registrypaymethod.cc, 
	registrypaymethod.biccode,
	registrypaymethod.paymentdescr, 
	registrypaymethod.paymentexpiring, 
	registrypaymethod.idexpirationkind, 
	registrypaymethod.flagstandard, 
	registrypaymethod.active, 
	registrypaymethod.iddeputy,
	deputy.title,
	registrypaymethod.idcurrency,
	currency.codecurrency,
	currency.description,
        registrypaymethod.extracode,
	registrypaymethod.cu, registrypaymethod.ct, registrypaymethod.lu, registrypaymethod.lt
FROM registrypaymethod
JOIN registry
	ON registrypaymethod.idreg = registry.idreg 
LEFT OUTER JOIN registry deputy
	ON deputy.idreg = registrypaymethod.iddeputy
LEFT OUTER JOIN paymethod
	ON paymethod.idpaymethod = registrypaymethod.idpaymethod 
LEFT OUTER JOIN bank
	ON bank.idbank = registrypaymethod.idbank 
LEFT OUTER JOIN cab
	ON cab.idbank = registrypaymethod.idbank 
	AND cab.idcab = registrypaymethod.idcab 
LEFT OUTER JOIN currency
	ON currency.idcurrency = registrypaymethod.idcurrency



GO

print '[DBO].[registrypaymethodview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'geo_nationusable') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW geo_nationusable
GO
--Pino Rana, elaborazione del 10/08/2005 15:18:01
CREATE                                                                 view [DBO].[geo_nationusable] as 
	select * from geo_nation g1 where newnation is null and stop is null
	and not exists (select * from geo_nation g2 where g1.idnation=g2.oldnation)


GO

print '[DBO].[geo_nationusable] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'accmotiveapplied') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW accmotiveapplied
GO



CREATE    VIEW [DBO].[accmotiveapplied]
(
	idaccmotive,
	paridaccmotive,
	codemotive,
	motive,
	cu,
	ct,
	lu,
	lt,
	active,
	idepoperation,
	epoperation,
	in_use,
	flagamm,
	flagdep
)
AS SELECT
accmotive.idaccmotive,
accmotive.paridaccmotive,
accmotive.codemotive,
accmotive.title,
accmotive.cu,
accmotive.ct,
accmotive.lu,
accmotive.lt,
accmotive.active,
epoperation.idepoperation,
epoperation.title,
CASE
WHEN (SELECT COUNT(*) FROM accmotiveepoperation acc1 WHERE acc1.idaccmotive LIKE accmotive.idaccmotive + '%'
	AND acc1.idepoperation = epoperation.idepoperation)>0 THEN 'S'
ELSE 'N'
END
,
accmotive.flagamm,
accmotive.flagdep
FROM accmotive
CROSS JOIN epoperation
--WHERE 
--EXISTS
	--(SELECT * FROM accmotiveepoperation acc1 WHERE acc1.idaccmotive LIKE accmotive.idaccmotive + '%'
	--AND acc1.idepoperation = epoperation.idepoperation)
UNION 
SELECT
accmotive.idaccmotive,
accmotive.paridaccmotive,
accmotive.codemotive,
accmotive.title,
accmotive.cu,
accmotive.ct,
accmotive.lu,
accmotive.lt,
accmotive.active,
null,
null,
'S',
accmotive.flagamm,
accmotive.flagdep
FROM accmotive


GO

print '[DBO].[accmotiveapplied] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'taxratecitystartview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW taxratecitystartview
GO


CREATE                     VIEW [DBO].[taxratecitystartview]
AS
SELECT DISTINCT 
a1.taxcode,
tax.taxref,
a1.idcity,
a1.idtaxratecitystart,
c1.title as city,
p1.idcountry,
p1.title as country,
a1.start,
a1.enforcement,
a1.annotations
FROM taxratecitystart a1
JOIN geo_city c1
ON a1.idcity = c1.idcity
JOIN geo_country p1
ON c1.idcountry = p1.idcountry
JOIN tax
ON tax.taxcode = a1.taxcode


GO

print '[DBO].[taxratecitystartview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'taxrateregioncitystartview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW taxrateregioncitystartview
GO


CREATE                    VIEW [DBO].[taxrateregioncitystartview]
AS
SELECT DISTINCT 
a1.taxcode,
tax.taxref,
a1.idcity,
a1.idtaxrateregioncitystart,
c1.title as city,
p1.idcountry,
p1.title as country,
a1.start,
a1.enforcement
FROM taxrateregioncitystart a1
JOIN geo_city c1
ON a1.idcity = c1.idcity
JOIN geo_country p1
ON c1.idcountry = p1.idcountry
JOIN tax
ON tax.taxcode = a1.taxcode


GO

print '[DBO].[taxrateregioncitystartview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'taxrateregionstartview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW taxrateregionstartview
GO


CREATE                           VIEW [DBO].[taxrateregionstartview]
AS
SELECT DISTINCT 
a1.taxcode,
tax.taxref,
a1.idregion,
a1.idtaxrateregionstart,
c1.title as region,
a1.start,
a1.enforcement
FROM taxrateregionstart a1
JOIN geo_region c1
ON a1.idregion = c1.idregion
JOIN tax
ON tax.taxcode = a1.taxcode



GO

print '[DBO].[taxrateregionstartview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'legalstatuscontract') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW legalstatuscontract
GO

CREATE       VIEW [DBO].[legalstatuscontract]
	(
	idreg,
	idregistrylegalstatus,
	idposition,
	codeposition,
	position,
	incomeclass,
	incomeclassvalidity,
	maxincomeclass,
	start,
	stop,
	csa_compartment,csa_role, csa_class,csa_description
	)
	AS 
SELECT 
	registrylegalstatus.idreg,
	registrylegalstatus.idregistrylegalstatus,
	registrylegalstatus.idposition,
	position.codeposition,
	position.description,
	isnull(registrylegalstatus.incomeclass,0),
	registrylegalstatus.incomeclassvalidity,
	position.maxincomeclass,
	registrylegalstatus.start,
	registrylegalstatus.stop,
	registrylegalstatus.csa_compartment, 
	registrylegalstatus.csa_role, 
	registrylegalstatus.csa_class,
	csapositionlookup.csa_description
	FROM registrylegalstatus (NOLOCK)
	JOIN position (NOLOCK)
		ON position.idposition = registrylegalstatus.idposition
	LEFT OUTER JOIN csapositionlookup
		ON registrylegalstatus.idposition = csapositionlookup.idposition
		AND registrylegalstatus.csa_compartment = csapositionlookup.csa_compartment
		AND registrylegalstatus.csa_role = csapositionlookup.csa_role
		AND registrylegalstatus.csa_class = csapositionlookup.csa_class
	




GO

print '[DBO].[legalstatuscontract] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'registrylegalstatusregview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW registrylegalstatusregview
GO

CREATE         VIEW [DBO].[registrylegalstatusregview]
(
	idreg,
	registry,
	idregistrylegalstatus,
	start,
	idposition,
	codeposition,
	position,
	incomeclass,
	incomeclassvalidity,
	cu, 
	ct, 
	lu,
	lt,
	active,
	stop,
	csa_compartment,csa_role, csa_class
)
AS SELECT
	registrylegalstatus.idreg, 
	registry.title, 
	registrylegalstatus.idregistrylegalstatus,
	registrylegalstatus.start,
	registrylegalstatus.idposition, 
	position.codeposition,
	position.description,
	registrylegalstatus.incomeclass,
	registrylegalstatus.incomeclassvalidity,
	registrylegalstatus.cu, 
	registrylegalstatus.ct, 
	registrylegalstatus.lu,
	registrylegalstatus.lt,
	registrylegalstatus.active,
	registrylegalstatus.stop,
	registrylegalstatus.csa_compartment, 
	registrylegalstatus.csa_role, 
	registrylegalstatus.csa_class
FROM registrylegalstatus 
JOIN registry 
	ON registrylegalstatus.idreg = registry.idreg
LEFT OUTER JOIN position 
	ON registrylegalstatus.idposition = position.idposition 




GO

print '[DBO].[registrylegalstatusregview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'registrylegalstatusview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW registrylegalstatusview
GO

CREATE       VIEW [DBO].registrylegalstatusview 
(
	idreg,
	title, 
	start,
	idposition,
	codeposition,
	position,
	incomeclass,
	incomeclassvalidity,
	cu, 
	ct, 
	lu,
	lt,
	idregistrylegalstatus,
	stop,
	csa_compartment,csa_role, csa_class
)
	AS SELECT
	registrylegalstatus.idreg, 
	registry.title, 
	registrylegalstatus.start,
	registrylegalstatus.idposition, 
	position.codeposition,
	position.description,
	registrylegalstatus.incomeclass,
	registrylegalstatus.incomeclassvalidity,
	registrylegalstatus.cu, 
	registrylegalstatus.ct, 
	registrylegalstatus.lu,
	registrylegalstatus.lt,
	registrylegalstatus.idregistrylegalstatus,
 	registrylegalstatus.stop,
	registrylegalstatus.csa_compartment, 
	registrylegalstatus.csa_role, 
	registrylegalstatus.csa_class
FROM registrylegalstatus 
JOIN registry 
	ON registrylegalstatus.idreg = registry.idreg
JOIN position 
	ON registrylegalstatus.idposition = position.idposition 
	



GO

print '[DBO].registrylegalstatusview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'registrymainview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW registrymainview
GO


-- CREAZIONE VISTA registrymainview
CREATE     VIEW [DBO].[registrymainview]
(
	idreg, 
	title, 
	idregistryclass, 
	registryclass,
	surname, 
	forename, 
	cf, 
	p_iva, 
	residence, coderesidence,
	residencekind,
	annotation, 
	birthdate, 
	idcity, 
	city, 
	gender, 
	foreigncf, 
	idtitle,
	qualification, 
	idmaritalstatus, 
	maritalstatus, 
	idregistrykind, 
	sortcode,
	registrykind,
	human, 
	active, 
	badgecode,
	maritalsurname, 
	idcategory,
	category, 
	extmatricula, 
	idcentralizedcategory,
	cu,
	ct,
	lu,
	lt,
	location,
	idnation,
	nation,
	authorization_free,
	multi_cf,
	toredirect,
	idaccmotivedebit,
	codemotivedebit,
	idaccmotivecredit,
	codemotivecredit,
	ccp,
	flagbankitaliaproceeds
)
AS
SELECT
	registry.idreg, registry.title, 
	registry.idregistryclass, 
	registryclass.description, 
	registry.surname, registry.forename, 
	registry.cf, registry.p_iva, 
	registry.residence, residence.coderesidence,
	residence.description, 
	registry.annotation, 
	registry.birthdate, 
	registry.idcity, geo_city.title,
	registry.gender, registry.foreigncf, 
	registry.idtitle, 
	title.description, 
	registry.idmaritalstatus, 
	maritalstatus.description, 
	registry.idregistrykind,
	registrykind.sortcode, 
	registrykind.description, 
	registryclass.flaghuman, registry.active, 
	registry.badgecode, 
	registry.maritalsurname, 
	registry.idcategory, 
	category.description,
	registry.extmatricula, 
	registry.idcentralizedcategory,
	registry.cu, 
	registry.ct, 
	registry.lu, 
	registry.lt,
	registry.location,
	registry.idnation,
	geo_nation.title,
	registry.authorization_free,
	registry.multi_cf,
	registry.toredirect,
	registry.idaccmotivedebit,
	DB.codemotive,
	registry.idaccmotivecredit,
	CR.codemotive,
	registry.ccp,
	registry.flagbankitaliaproceeds
FROM registry
LEFT OUTER JOIN registrykind
	ON registrykind.idregistrykind = registry.idregistrykind
LEFT OUTER JOIN residence
	ON residence.idresidence = registry.residence
LEFT OUTER JOIN registryclass
	ON registryclass.idregistryclass = registry.idregistryclass
LEFT OUTER JOIN title
	ON title.idtitle = registry.idtitle
LEFT OUTER JOIN maritalstatus
	ON maritalstatus.idmaritalstatus = registry.idmaritalstatus
LEFT OUTER JOIN geo_city
	ON geo_city.idcity = registry.idcity
LEFT OUTER JOIN geo_nation
	ON geo_nation.idnation = registry.idnation
LEFT OUTER JOIN category
	ON category.idcategory = registry.idcategory
LEFT OUTER JOIN accmotive DB
	ON DB.idaccmotive =  registry.idaccmotivedebit
LEFT OUTER JOIN accmotive CR
	ON CR.idaccmotive =  registry.idaccmotivecredit



GO

print '[DBO].[registrymainview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'allowanceruledetailview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW allowanceruledetailview
GO


CREATE                   VIEW [DBO].allowanceruledetailview
(
	idallowancerule,
	iddetail,
	start,
	idposition,
	codeposition,
	position,
	minincomeclass,
	maxincomeclass,
	amount,
	advancepercentage,
	ct, cu, lt, lu
)
AS SELECT 
	DET.idallowancerule,
	DET.iddetail,
	F.start,
	DET.idposition,
	P.codeposition,
	P.description,
	DET.minincomeclass,
	DET.maxincomeclass,
	DET.amount,
	DET.advancepercentage,
	DET.ct, DET.cu, DET.lt, DET.lu
FROM allowanceruledetail DET
JOIN allowancerule F
	ON F.idallowancerule = DET.idallowancerule
LEFT OUTER JOIN position P
	ON P.idposition = DET.idposition


GO

print '[DBO].allowanceruledetailview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'capview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW capview
GO

CREATE           VIEW [DBO].capview
AS
SELECT     geo_city.title, geo_city_agency.*
FROM         geo_city INNER JOIN
                      geo_city_agency ON geo_city.idcity = geo_city_agency.idcity
WHERE     (geo_city_agency.idagency = 3) AND (geo_city_agency.idcode = 1) AND (geo_city_agency.stop IS NULL)

GO

print '[DBO].capview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'geo_cityview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW geo_cityview
GO

/*Pino Rana, elaborazione del 10/08/2005 15:18:07
 Inserire la CREATE VIEW qui--
*/
CREATE       VIEW [DBO].geo_cityview
AS
SELECT     geo_city.idcity, geo_city.title, geo_city.oldcity, geo_city.newcity, geo_city.start, geo_city.stop, geo_country.idcountry, 
                      geo_country.province AS provincecode, geo_country.title AS country, geo_country.oldcountry, geo_country.newcountry, 
                      geo_country.start AS countrydatestart, geo_country.stop AS countrydatestop, geo_region.idregion, geo_region.title AS region, 
                      geo_region.start AS regiondatestart, geo_region.stop AS regiondatestop, geo_region.oldregion, geo_region.newregion, 
                      geo_nation.idnation, geo_nation.idcontinent, geo_nation.title AS nation, geo_nation.start AS nationdatestart, 
                      geo_nation.stop AS nationdatestop, geo_nation.oldnation, geo_nation.newnation
FROM         geo_city LEFT OUTER  JOIN
                      geo_country ON geo_city.idcountry = geo_country.idcountry LEFT OUTER JOIN
                      geo_region ON geo_country.idregion = geo_region.idregion LEFT OUTER JOIN
                      geo_nation ON geo_region.idnation = geo_nation.idnation


GO

print '[DBO].geo_cityview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'geo_city_agencyview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW geo_city_agencyview
GO

CREATE      VIEW [DBO].[geo_city_agencyview]
(
	idcity, 
	title,
	provincecode,
	newcity,
	oldcity,
	idagency,
	agencyname,
	agencywebsite,
	idcode,
	version,
	codename,
	value,
	start,
	stop
)
AS
SELECT
	geo_city_agency.idcity,
	geo_city.title, 
	geo_country.province,
	geo_city.newcity,
	geo_city.oldcity,
	geo_city_agency.idagency, 
	geo_agency.title,
	geo_agency.website,
	geo_city_agency.idcode, 
	geo_city_agency.version,
	geo_code.codename,
	geo_city_agency.value,
	geo_city_agency.start, 
	geo_city_agency.stop
FROM geo_code
JOIN geo_city_agency
	ON geo_code.idagency = geo_city_agency.idagency
	AND geo_code.idcode = geo_city_agency.idcode
JOIN geo_city
	ON geo_city_agency.idcity = geo_city.idcity
JOIN geo_agency
	ON geo_code.idagency = geo_agency.idagency
LEFT OUTER JOIN geo_country
	ON geo_country.idcountry = geo_city.idcountry



GO

print '[DBO].[geo_city_agencyview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'accmotiveview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW accmotiveview
GO

CREATE     VIEW [DBO].[accmotiveview]
(
	idaccmotive,
	active,
	codemotive,
	paridaccmotive,
	title,
	flagdep,
	flagamm,
	idaccmotive1,
	codemotive1,
	title1,
	idaccmotive2,
	codemotive2,
	title2,
	idaccmotive3,
	codemotive3,
	title3,
	idaccmotive4,
	codemotive4,
	title4,
	idaccmotive5,
	codemotive5,
	title5,
	idaccmotive6,
	codemotive6,
	title6,
	mergecode,
	cu,
	ct,
	lu,
	lt
)
AS
SELECT
	accmotive.idaccmotive,
	accmotive.active,
	accmotive.codemotive,
	accmotive.paridaccmotive,
	accmotive.title,
	accmotive.flagdep,
	accmotive.flagamm,
	accmotive1.idaccmotive,
	accmotive1.codemotive,
	accmotive1.title,
	accmotive2.idaccmotive,
	accmotive2.codemotive,
	accmotive2.title,
	accmotive3.idaccmotive,
	accmotive3.codemotive,
	accmotive3.title,
	accmotive4.idaccmotive,
	accmotive4.codemotive,
	accmotive4.title,
	accmotive5.idaccmotive,
	accmotive5.codemotive,
	accmotive5.title,
	accmotive6.idaccmotive,
	accmotive6.codemotive,
	accmotive6.title,
	ISNULL(accmotive6.codemotive,'') + ISNULL(accmotive5.codemotive,'') +
	ISNULL(accmotive4.codemotive,'') + ISNULL(accmotive3.codemotive,'') +
	ISNULL(accmotive2.codemotive,'') + ISNULL(accmotive1.codemotive,'') + 
	ISNULL(accmotive.codemotive,''),
	accmotive.cu,
	accmotive.ct,
	accmotive.lu,
	accmotive.lt
FROM accmotive
LEFT OUTER JOIN accmotive accmotive1
	ON accmotive1.idaccmotive = accmotive.paridaccmotive
LEFT OUTER JOIN accmotive accmotive2
	ON accmotive2.idaccmotive = accmotive1.paridaccmotive
LEFT OUTER JOIN accmotive accmotive3
	ON accmotive3.idaccmotive = accmotive2.paridaccmotive
LEFT OUTER JOIN accmotive accmotive4
	ON accmotive4.idaccmotive = accmotive3.paridaccmotive
LEFT OUTER JOIN accmotive accmotive5
	ON accmotive5.idaccmotive = accmotive4.paridaccmotive
LEFT OUTER JOIN accmotive accmotive6
	ON accmotive6.idaccmotive = accmotive5.paridaccmotive

GO

print '[DBO].[accmotiveview] OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'foreigngroupruledetailview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW foreigngroupruledetailview
GO


CREATE                   VIEW [DBO].foreigngroupruledetailview
(
	idforeigngrouprule,
	iddetail,
	start,
	idposition,
	codeposition,
	position,
	minincomeclass,
	maxincomeclass,
	foreigngroupnumber,
	ct, cu, lt, lu
)
AS SELECT 
	DET.idforeigngrouprule,
	DET.iddetail,
	F.start,
	DET.idposition,
	P.codeposition,
	P.description,
	DET.minincomeclass,
	DET.maxincomeclass,
	DET.foreigngroupnumber,
	DET.ct, DET.cu, DET.lt, DET.lu
FROM foreigngroupruledetail DET
JOIN foreigngrouprule F
	ON F.idforeigngrouprule = DET.idforeigngrouprule
JOIN position P
	ON P.idposition = DET.idposition


GO

print '[DBO].foreigngroupruledetailview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'cabview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW cabview
GO


CREATE      VIEW [DBO].cabview
(
	idbank,
	idcab,
	description,
	address,
	cap,
	country,
	cu,
	ct,
	lu,
	lt,
	location,
	idcity,
	city,
	flagusable
)
AS SELECT
	cab.idbank,
	cab.idcab,
	cab.description,
	cab.address,
	cab.cap,
	geo_country.title,
	cab.cu,
	cab.ct,
	cab.lu,
	cab.lt,
	cab.location,
	cab.idcity,
	geo_city.title,
	cab.flagusable
FROM cab 
LEFT OUTER JOIN geo_city
	ON cab.idcity = geo_city.idcity
LEFT OUTER JOIN geo_country
	ON geo_city.idcountry = geo_country.idcountry


GO

print '[DBO].cabview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'registryroleview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW registryroleview
GO

--Pino Rana, elaborazione del 10/08/2005 15:17:45
CREATE                                                     VIEW [DBO].registryroleview
AS
SELECT     registryrole.idreg, 
	   registryrole.idrole, registryrole.start, registryrole.ct, 
                      registryrole.cu, registryrole.stop, registryrole.active, registryrole.lt, registryrole.lu, 
                      registryrole.txt, registry.title as registry, role.description AS role
FROM       registryrole INNER JOIN
                      role ON registryrole.idrole = role.idrole  INNER JOIN
                      registry ON registryrole.idreg = registry.idreg



GO

print '[DBO].registryroleview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'reductionruledetailview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW reductionruledetailview
GO

CREATE                         VIEW [DBO].reductionruledetailview
(
	idreductionrule,
	iddetail,
	start,
	idreduction,
	reduction,
	reductionpercentage,
	ct, cu, lt, lu
)
AS SELECT 
	DET.idreductionrule,
	DET.iddetail,
	F.start,
	DET.idreduction,
	R.description,
	DET.reductionpercentage,
	DET.ct, DET.cu, DET.lt, DET.lu
FROM reductionruledetail DET
JOIN reductionrule F
	ON F.idreductionrule = DET.idreductionrule
JOIN reduction R
	ON R.idreduction = DET.idreduction

GO

print '[DBO].reductionruledetailview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'itinerationrefundruledetailview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW itinerationrefundruledetailview
GO


CREATE                   VIEW [DBO].itinerationrefundruledetailview
(
	iditinerationrefundrule,
	ruledescr,
	iddetail,
	start,
	iditinerationrefundkindgroup,
	itinerationrefundkindgroup,
	idposition,
	codeposition,
	position,
	minincomeclass,
	maxincomeclass,
	flag_italy,
	flag_eu,
	flag_extraeu,
	nhour_min,
	nhour_max,
	limit,
	advancepercentage,
	ct, cu, lt, lu
)
AS SELECT 
	DET.iditinerationrefundrule,
	F.description,
	DET.iddetail,
	F.start,
	DET.iditinerationrefundkindgroup,
	G.description,
	DET.idposition,
	P.codeposition,
	P.description,
	DET.minincomeclass,
	DET.maxincomeclass,
	DET.flag_italy,
	DET.flag_eu,
	DET.flag_extraeu,
	DET.nhour_min,
	DET.nhour_max,
	DET.limit,
	DET.advancepercentage,
	DET.ct, DET.cu, DET.lt, DET.lu
FROM itinerationrefundruledetail DET
JOIN itinerationrefundrule F
	ON F.iditinerationrefundrule = DET.iditinerationrefundrule
JOIN position P
	ON P.idposition = DET.idposition
JOIN itinerationrefundkindgroup G
	ON G.iditinerationrefundkindgroup = DET.iditinerationrefundkindgroup


GO

print '[DBO].itinerationrefundruledetailview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'foreignallowanceruledetailview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW foreignallowanceruledetailview
GO


CREATE                    VIEW [DBO].foreignallowanceruledetailview
(
	idforeignallowancerule,
	iddetail,
	idforeigncountry,
	codeforeigncountry,
	foreigncountry,
	start,
	minforeigngroupnumber,
	maxforeigngroupnumber,
	amount,
	advancepercentage,
	ct, cu, lt, lu
)
AS SELECT 
	DET.idforeignallowancerule,
	DET.iddetail,
	F.idforeigncountry,
	FC.codeforeigncountry,
	FC.description,
	F.start,
	DET.minforeigngroupnumber,
	DET.maxforeigngroupnumber,
	DET.amount,
	DET.advancepercentage,
	DET.ct, DET.cu, DET.lt, DET.lu
FROM foreignallowanceruledetail DET
JOIN foreignallowancerule F
	ON F.idforeignallowancerule = DET.idforeignallowancerule
JOIN foreigncountry FC
	ON FC.idforeigncountry = F.idforeigncountry


GO

print '[DBO].foreignallowanceruledetailview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'foreignallowanceruleview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW foreignallowanceruleview
GO


CREATE                    VIEW [DBO].foreignallowanceruleview
AS
SELECT     foreignallowancerule.idforeignallowancerule, foreignallowancerule.idforeigncountry, 
 foreigncountry.codeforeigncountry,
	foreigncountry.description AS foreigncountry, 
                      foreignallowancerule.start
FROM         foreignallowancerule INNER JOIN
                      foreigncountry ON foreignallowancerule.idforeigncountry = foreigncountry.idforeigncountry


GO

print '[DBO].foreignallowanceruleview OK'

GO
IF EXISTS(select * from [dbo].[sysobjects] where id = object_id(N'registryaddressview') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW registryaddressview
GO

--Pino Rana, elaborazione del 10/08/2005 15:17:44
-- Inserire la CREATE VIEW qui--
CREATE                    VIEW [DBO].[registryaddressview]
(
idreg,
registry,
start,
stop,
idaddresskind,
codeaddress,
addresskind,
officename,
address,
idcity,
city,
location,
active,
annotations,
ct,
cu,
lt,
lu,
cap,
flagforeign,
idnation,
nation
)
AS
SELECT     
	registryaddress.idreg, 
	registry.title, 
	registryaddress.start, 
	registryaddress.stop, 
	registryaddress.idaddresskind, 
	address.codeaddress,
	address.description AS descrtipoindirizzo,
	registryaddress.officename, 
	registryaddress.address, 
	registryaddress.idcity, 
	geo_city.title AS comune, 
	registryaddress.location, 
	registryaddress.active, 
	registryaddress.annotations, 
	registryaddress.ct, 
	registryaddress.cu, 
	registryaddress.lt, 
	registryaddress.lu, 
	registryaddress.cap,
	registryaddress.flagforeign,
	registryaddress.idnation,
	geo_nation.title
FROM         registryaddress INNER JOIN
                      address ON registryaddress.idaddresskind = address.idaddress INNER JOIN
                      registry ON registryaddress.idreg = registry.idreg LEFT OUTER JOIN
                      geo_city ON registryaddress.idcity = geo_city.idcity LEFT OUTER JOIN
                      geo_nation ON registryaddress.idnation = geo_nation.idnation



GO

print '[DBO].[registryaddressview] OK'

GO

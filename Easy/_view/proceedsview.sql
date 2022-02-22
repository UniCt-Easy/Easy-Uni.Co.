
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


-- CREAZIONE VISTA proceedsview
IF EXISTS(select * from sysobjects where id = object_id(N'[proceedsview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [proceedsview]
GO



--setuser 'amm'
--clear_table_info 'proceedsview'
CREATE  VIEW [proceedsview]
	(
	kpro,
	ypro,
	npro,
	npro_treasurer,
	idstamphandling,
	stamphandling,
	idtreasurer,
	codetreasurer,
	flag,
	kind,
	accountkind,
	idreg,
	registry,
	idfin,
	codefin,
	finance,
	idman,
	manager,
	kproceedstransmission,
	yproceedstransmission,
	nproceedstransmission,
	transmissiondate,
	adate,
	printdate,
	annulmentdate,
	cu,
	ct,
	lu,
	lt,	
	total,
	performed,
	notperformed,
	idsor01,idsor02,idsor03,idsor04,idsor05,
	external_reference,streamdate
	)
	AS 

	SELECT
	proceeds.kpro,
	proceeds.ypro,
	proceeds.npro,
	proceeds.npro_treasurer,
	proceeds.idstamphandling,
	stamphandling.description,
	proceeds.idtreasurer,
	treasurer.codetreasurer,
	proceeds.flag,
	CASE
		WHEN ((proceeds.flag&1) <>0) THEN 'C'
		WHEN ((proceeds.flag&2) <>0) THEN 'R'
		WHEN ((proceeds.flag&4) <>0) THEN 'M'
	END, 
	CASE
		WHEN ((proceeds.flag&8)=0)  THEN 'I'
		WHEN ((proceeds.flag&8)<>0) THEN 'F'
	END, 
        --treasurer.flagfruitful, 
	proceeds.idreg,
	registry.title,
	proceeds.idfin,
	fin.codefin,
	fin.title,
	proceeds.idman,
	manager.title,
	proceedstransmission.kproceedstransmission,
	proceedstransmission.yproceedstransmission,
	proceedstransmission.nproceedstransmission,
	proceedstransmission.transmissiondate,
	proceeds.adate,
	proceeds.printdate,
	proceeds.annulmentdate,
	proceeds.cu,
	proceeds.ct,
	proceeds.lu,
	proceeds.lt,
	(SELECT SUM(curramount) 
	from incometotal I 
	join income S 
		on I.idinc=S.idinc
	join incomelast ST
		on S.idinc = ST.idinc
	WHERE ST.kpro=proceeds.kpro
			AND I.ayear = proceeds.ypro
	),
	ISNULL( (SELECT SUM(amount) from banktransaction P where
					P.kpro=proceeds.kpro),0),
	(SELECT SUM(curramount)	
	from incometotal I 
	join income S 
		on I.idinc=S.idinc 
	join incomelast ST
		on S.idinc = ST.idinc
	WHERE ST.kpro=proceeds.kpro AND I.ayear = proceeds.ypro)
	-
	 ISNULL( (SELECT SUM(amount) from banktransaction P where
					P.kpro=proceeds.kpro),0)                ,
	COALESCE(proceeds.idsor01,treasurer.idsor01),COALESCE(proceeds.idsor02,treasurer.idsor02),COALESCE(proceeds.idsor03,treasurer.idsor03),
	COALESCE(proceeds.idsor04,treasurer.idsor04),COALESCE(proceeds.idsor05,treasurer.idsor05),    
	proceeds.external_reference, proceedstransmission.streamdate 
	FROM proceeds  with (NOLOCK)
	LEFT OUTER JOIN registry  with (NOLOCK)
		ON registry.idreg = proceeds.idreg
	LEFT OUTER JOIN fin  with (NOLOCK)
		ON fin.idfin = proceeds.idfin
	LEFT OUTER JOIN manager with (NOLOCK)
		ON manager.idman = proceeds.idman
	LEFT OUTER JOIN stamphandling with (NOLOCK)
		ON stamphandling.idstamphandling = proceeds.idstamphandling
	LEFT OUTER JOIN proceedstransmission  with (NOLOCK)
		ON proceedstransmission.kproceedstransmission = proceeds.kproceedstransmission
 	LEFT OUTER JOIN treasurer with (NOLOCK)
		ON treasurer.idtreasurer = proceeds.idtreasurer





GO



 

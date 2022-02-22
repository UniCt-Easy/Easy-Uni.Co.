
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


-- CREAZIONE VISTA upbview
IF EXISTS(select * from sysobjects where id = object_id(N'[upbview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [upbview]
GO

--setuser 'amm'
--clear_table_info 'upb,upbview'
--select * from upbview

CREATE VIEW [upbview]
(
	idupb,
	codeupb,
	title,
	paridupb,
	idunderwriter,
	idman,
	manager,
	underwriter,
	printingorder,
	requested,
	granted,
	previousappropriation,
	previousassessment,
	expiration,
	assured,
	active,
	cupcode,
	idsor01,
	idsor02,
	idsor03,
	idsor04,
	idsor05,
	flagactivity,
	flagkind,
	newcodeupb,
	start,
	stop,
	cigcode,
	idtreasurer,
	codetreasurer,
	idepupbkind,
	flag,
	cofogmpcode,
	uesiopecode,
	ri_ra_quota,
	ri_rb_quota,
	ri_sa_quota,
	idupb_capofila,
	codeupb_capofila,
	upb_capofila,
	cu, 
	ct, 
	lu, 
	lt
)
AS 
SELECT 
	upb.idupb,
	upb.codeupb,
	upb.title,
	upb.paridupb,
	upb.idunderwriter,
	upb.idman,
	manager.title,
	underwriter.description,
	upb.printingorder,
	upb.requested,
	upb.granted,
	upb.previousappropriation,
	upb.previousassessment,
	upb.expiration,
	upb.assured,
	upb.active,
	upb.cupcode,
	upb.idsor01,
	upb.idsor02,
	upb.idsor03,
	upb.idsor04,
	upb.idsor05,
	upb.flagactivity,
	upb.flagkind,
	upb.newcodeupb,
	upb.start,
	upb.stop,
	upb.cigcode,
	upb.idtreasurer,
	treasurer.codetreasurer,
	upb.idepupbkind,
	upb.flag,
	upb.cofogmpcode,
	upb.uesiopecode,
	null,
	null,
	null,
	upb.idupb_capofila,
	upb_capofila.codeupb,
	upb_capofila.title,
	upb.cu, 
	upb.ct, 
	upb.lu, 
	upb.lt
FROM 	upb with (nolock)
LEFT OUTER JOIN manager with (nolock)	ON manager.idman = upb.idman
LEFT OUTER JOIN underwriter with (nolock)	ON underwriter.idunderwriter = upb.idunderwriter
LEFT OUTER JOIN treasurer 	ON upb.idtreasurer=treasurer.idtreasurer
LEFT OUTER JOIN upb upb_capofila (nolock)	on upb.idupb_capofila = upb_capofila.idupb  

GO

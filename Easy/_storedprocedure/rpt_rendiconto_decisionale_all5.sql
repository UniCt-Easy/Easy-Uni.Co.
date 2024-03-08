
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[rpt_rendiconto_decisionale_all5]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [rpt_rendiconto_decisionale_all5]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
-- setuser 'amministrazione'
-- setuser 'amm'
-- exec rpt_rendiconto_decisionale_all5 2020, {ts '2020-12-31 00:00:00'}, 'S', 3, '%', 'N', 'S', 'S', 'S', NULL, NULL, NULL, NULL, NULL
-- exec rpt_bilconsuntivo 2018,{ts '2018-07-30 00:00:00'},'E',5,'%','N','N','S','N', null, null, null, null, null

CREATE       PROCEDURE [rpt_rendiconto_decisionale_all5]
(
	@ayear int,
	@date datetime,
	@finpart char(1)='S',
	@levelusable tinyint=3,
	@idupb varchar(36)='%',
	@showupb char(1)='N',
	@showchildupb char(1)='S',
	@suppressifblank char(1)='S',
	@officialvar  char(1)='S',
	@idsor01 int=null,
	@idsor02 int=null,
	@idsor03 int=null,
	@idsor04 int=null,
	@idsor05 int=null
)
AS BEGIN

DECLARE @ayear_prec INT
SET @ayear_prec = @ayear -1

CREATE TABLE #data_curr
(
	code1 varchar(50),
	desc1 varchar(150),
	descliv1 varchar(150),
	order1 varchar(50),
	code2 varchar(50),
	desc2 varchar(150),
	descliv2 varchar(50),
	order2 varchar(50),
	code3 varchar(50),
	desc3 varchar(150),
	descliv3 varchar(50),
	order3 varchar(50),
	code4 varchar(50),
	desc4 varchar(150),
	descliv4 varchar(50),
	order4 varchar(50),
	code5 varchar(50),
	desc5 varchar(150),
	descliv5 varchar(50),
	order5 varchar(50),
	codeupb varchar(50),
	idupb varchar(50),
	upb varchar(150),
	upbprintingorder varchar(50),
	initialprevision decimal(19,2),
	variation_A decimal(19,2),
	variation_D decimal(19,2),
	secondaryprevision decimal(19,2),
	secondaryvariation decimal(19,2),
	currentarrears decimal(19,2),
	mov_finphase_C decimal(19,2),
	var_finphase_C decimal(19,2),
	mov_maxphase_C decimal(19,2),
	var_maxphase_C decimal(19,2),
	mov_finphase_R decimal(19,2),
	var_finphase_R_P decimal(19,2),
	var_finphase_R_N decimal(19,2),
	mov_maxphase_R decimal(19,2),
	var_maxphase_R decimal(19,2),
	previsionkind char(1),
	showincomesurplus char(1),
	flagadvance char(1),
	supposed_ff_jan01 decimal(19,2),
	supposed_aa_jan01 decimal(19,2),
	ff_jan01 decimal(19,2),
	aa_jan01 decimal(19,2),
	tosuppress char(1),
	nlevel tinyint,
	floatfund_01_jan_used decimal(19,2),
	supposed_aa_01_jan_used decimal(19,2),
	aa_01_jan_used decimal(19,2),
	supposed_ff_01_jan_used decimal(19,2)
)

CREATE TABLE #data_prec
(
	code1 varchar(50),
	desc1 varchar(150),
	descliv1 varchar(150),
	order1 varchar(50),
	code2 varchar(50),
	desc2 varchar(150),
	descliv2 varchar(50),
	order2 varchar(50),
	code3 varchar(50),
	desc3 varchar(150),
	descliv3 varchar(50),
	order3 varchar(50),
	code4 varchar(50),
	desc4 varchar(150),
	descliv4 varchar(50),
	order4 varchar(50),
	code5 varchar(50),
	desc5 varchar(150),
	descliv5 varchar(50),
	order5 varchar(50),
	codeupb varchar(50),
	idupb varchar(50),
	upb varchar(150),
	upbprintingorder varchar(50),
	initialprevision decimal(19,2),
	variation_A decimal(19,2),
	variation_D decimal(19,2),
	secondaryprevision decimal(19,2),
	secondaryvariation decimal(19,2),
	currentarrears decimal(19,2),
	mov_finphase_C decimal(19,2),
	var_finphase_C decimal(19,2),
	mov_maxphase_C decimal(19,2),
	var_maxphase_C decimal(19,2),
	mov_finphase_R decimal(19,2),
	var_finphase_R_P decimal(19,2),
	var_finphase_R_N decimal(19,2),
	mov_maxphase_R decimal(19,2),
	var_maxphase_R decimal(19,2),
	previsionkind char(1),
	showincomesurplus char(1),
	flagadvance char(1),
	supposed_ff_jan01 decimal(19,2),
	supposed_aa_jan01 decimal(19,2),
	ff_jan01 decimal(19,2),
	aa_jan01 decimal(19,2),
	tosuppress char(1),
	nlevel tinyint,
	floatfund_01_jan_used decimal(19,2),
	supposed_aa_01_jan_used decimal(19,2),
	aa_01_jan_used decimal(19,2),
	supposed_ff_01_jan_used decimal(19,2)
)

insert into #data_curr
exec rpt_bilconsuntivo_gestionale_all6 @ayear, @date, @finpart, @levelusable, @idupb, @showupb,	@showchildupb, @suppressifblank, @officialvar, @idsor01, @idsor02, @idsor03, @idsor04, @idsor05

insert into #data_prec
exec rpt_bilconsuntivo_gestionale_all6 @ayear_prec, @date, @finpart, @levelusable, @idupb, @showupb, @showchildupb, @suppressifblank, @officialvar, @idsor01, @idsor02, @idsor03, @idsor04, @idsor05

select
	-- esercizio corrente
	c.code1 as 'code1',
	c.desc1 as 'desc1',
	c.descliv1 as 'descliv1',
	c.order1 as 'order1',
	c.code2 as 'code2',
	c.desc2 as 'desc2',
	c.descliv2 as 'descliv2',
	c.order2 as 'order2',
	c.code3 as 'code3',
	c.desc3 as 'desc3',
	c.descliv3 as 'descliv3',
	c.order3 as 'order3',
	c.code4 as 'code4',
	c.desc4 as 'desc4',
	c.descliv4 as 'descliv4',
	c.order4 as 'order4',
	c.code5 as 'code5',
	c.desc5 as 'desc5',
	c.descliv5 as 'descliv5',
	c.order5 as 'order5',
	c.codeupb as 'codeupb',
	c.idupb as 'idupb',
	c.upb as 'upb',
	c.upbprintingorder as 'upbprintingorder',
	c.initialprevision as 'initialprevision',
	c.variation_A as 'variation_A',
	c.variation_D as 'variation_D',
	c.secondaryprevision as 'secondaryprevision',
	c.secondaryvariation as 'secondaryvariation',
	c.currentarrears as 'currentarrears',
	c.mov_finphase_C as 'mov_finphase_C',
	c.var_finphase_C as 'var_finphase_C',
	c.mov_maxphase_C as 'mov_maxphase_C',
	c.var_maxphase_C as 'var_maxphase_C',
	c.mov_finphase_R as 'mov_finphase_R',
	c.var_finphase_R_P as 'var_finphase_R_P',
	c.var_finphase_R_N as 'var_finphase_R_N',
	c.mov_maxphase_R as 'mov_maxphase_R',
	c.var_maxphase_R as 'var_maxphase_R',
	c.previsionkind as 'previsionkind',
	c.showincomesurplus as 'showincomesurplus',
	c.flagadvance as 'flagadvance',
	c.supposed_ff_jan01 as 'supposed_ff_jan01',
	c.supposed_aa_jan01 as 'supposed_aa_jan01',
	c.ff_jan01 as 'ff_jan01',
	c.aa_jan01 as 'aa_jan01',
	c.tosuppress as 'tosuppress',
	c.nlevel as 'nlevel',
	c.floatfund_01_jan_used as 'floatfund_01_jan_used',
	c.supposed_aa_01_jan_used as 'supposed_aa_01_jan_used',
	c.aa_01_jan_used as 'aa_01_jan_used',
	c.supposed_ff_01_jan_used as 'supposed_ff_01_jan_used',
	-- esercizio precedente
	p.code1 as 'code1_prec',
	p.desc1 as 'desc1_prec',
	p.descliv1 as 'descliv1_prec',
	p.order1 as 'order1_prec',
	p.code2 as 'code2_prec',
	p.desc2 as 'desc2_prec',
	p.descliv2 as 'descliv2_prec',
	p.order2 as 'order2_prec',
	p.code3 as 'code3_prec',
	p.desc3 as 'desc3_prec',
	p.descliv3 as 'descliv3_prec',
	p.order3 as 'order3_prec',
	p.code4 as 'code4_prec',
	p.desc4 as 'desc4_prec',
	p.descliv4 as 'descliv4_prec',
	p.order4 as 'order4_prec',
	p.code5 as 'code5_prec',
	p.desc5 as 'desc5_prec',
	p.descliv5 as 'descliv5_prec',
	p.order5 as 'order5_prec',
	p.codeupb as 'codeupb_prec',
	p.idupb as 'idupb_prec',
	p.upb as 'upb_prec',
	p.upbprintingorder as 'upbprintingorder_prec',
	p.initialprevision as 'initialprevision_prec',
	p.variation_A as 'variation_A_prec',
	p.variation_D as 'variation_D_prec',
	p.secondaryprevision as 'secondaryprevision_prec',
	p.secondaryvariation as 'secondaryvariation_prec',
	p.currentarrears as 'currentarrears_prec',
	p.mov_finphase_C as 'mov_finphase_C_prec',
	p.var_finphase_C as 'var_finphase_C_prec',
	p.mov_maxphase_C as 'mov_maxphase_C_prec',
	p.var_maxphase_C as 'var_maxphase_C_prec',
	p.mov_finphase_R as 'mov_finphase_R_prec',
	p.var_finphase_R_P as 'var_finphase_R_P_prec',
	p.var_finphase_R_N as 'var_finphase_R_N_prec',
	p.mov_maxphase_R as 'mov_maxphase_R_prec',
	p.var_maxphase_R as 'var_maxphase_R_prec',
	p.previsionkind as 'previsionkind_prec',
	p.showincomesurplus as 'showincomesurplus_prec',
	p.flagadvance as 'flagadvance_prec',
	p.supposed_ff_jan01 as 'supposed_ff_jan01_prec',
	p.supposed_aa_jan01 as 'supposed_aa_jan01_prec',
	p.ff_jan01 as 'ff_jan01_prec',
	p.aa_jan01 as 'aa_jan01_prec',
	p.tosuppress as 'tosuppress_prec',
	p.nlevel as 'nlevel_prec',
	p.floatfund_01_jan_used as 'floatfund_01_jan_used_prec',
	p.supposed_aa_01_jan_used as 'supposed_aa_01_jan_used_prec',
	p.aa_01_jan_used as 'aa_01_jan_used_prec',
	p.supposed_ff_01_jan_used as 'supposed_ff_01_jan_used_prec'
from #data_curr c
left join #data_prec p on (c.code1 = p.code1 or c.code1 is null or p.code1 is null) and 
(c.code2 = p.code2 or c.code2 is null or p.code2 is null) and 
(c.code3 = p.code3 or c.code3 is null or p.code3 is null) and 
(c.code4 = p.code4 or c.code4 is null or p.code4 is null) and 
(c.code5 = p.code5 or c.code5 is null or p.code5 is null)
where (@suppressifblank = 'N' ) or
(@suppressifblank = 'S' and not( ISNULL(c.mov_finphase_C,0)  = 0 and		ISNULL(c.var_finphase_C,0)  = 0 and 	ISNULL(c.mov_maxphase_C,0)  = 0 and 	ISNULL(c.var_maxphase_C,0)  = 0 and 	
ISNULL(c.mov_finphase_R,0)  = 0 and 	ISNULL(c.var_finphase_R_P,0)  = 0 and ISNULL(c.var_finphase_R_N,0) = 0 and	ISNULL(c.mov_maxphase_R,0)  = 0 and 	ISNULL(c.var_maxphase_R,0) = 0 and
ISNULL(p.mov_finphase_C,0)  = 0 and		ISNULL(p.var_finphase_C,0)  = 0 and 	ISNULL(p.mov_maxphase_C,0)  = 0 and 	ISNULL(p.var_maxphase_C,0)  = 0 and 	
ISNULL(p.mov_finphase_R,0)  = 0 and 	ISNULL(p.var_finphase_R_P,0)  = 0 and ISNULL(p.var_finphase_R_N,0) = 0 and	ISNULL(p.mov_maxphase_R,0)  = 0 and 	ISNULL(p.var_maxphase_R,0) = 0))

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

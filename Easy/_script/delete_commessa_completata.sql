/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿ 
setuser 'amministrazione'
declare @ayear int
set @ayear = ----
delete from epexpyear/* where nphase = 1 and idrelated like'%commessa%' and yepexp = 2018 */
where idepexp in  (select idepexp from entrydetailview where idrelated like'%commessa%' and yentry = @ayear  and identrykind = 8) --and identrykind = 8

delete from epexptotal   /* nphase = 1 and idrelated like'%commessa%' and yepacc = 2018 */ --and identrykind = 8
/*and*/ where idepexp in  (select idepexp from entrydetailview where idrelated like'%commessa%' and yentry = @ayear  and identrykind = 8)

delete from epaccyear/* where nphase = 1 and idrelated like'%commessa%' and yepexp = 2018 */
where idepacc in (select idepacc from entrydetailview where idrelated like'%commessa%' and yentry = @ayear  and identrykind = 8) --and identrykind = 8

delete from epacctotal   /* nphase = 1 and idrelated like'%commessa%' and yepacc = 2018 */ --and identrykind = 8
/*and*/ where idepacc in (select idepacc from entrydetailview where idrelated like'%commessa%' and yentry = @ayear  and identrykind = 8) 


delete from epexpvar where idepexp in (select idepexp from entrydetailview where idrelated like'%commessa%' and yentry = @ayear  and identrykind = 8)
delete from epaccvar where idepacc in (select idepacc from entrydetailview where idrelated like'%commessa%' and yentry = @ayear  and identrykind = 8)


delete from epexp  where idepexp in (select idepexp from entrydetailview where idrelated like'%commessa%' and yentry = @ayear  and identrykind = 8)
delete from epacc  where idepacc in (select idepacc from entrydetailview where idrelated like'%commessa%' and yentry = @ayear  and identrykind = 8)


-------------------------------------------------------------------------
-------------------------------------------------------------------------
--select * from epexp where idepexp in (select paridepexp from epexp  where idepexp in (select idepexp from entrydetailview where idrelated like'%commessa%' and yentry = 2018  and identrykind = 8))
--select * from epacc where idepacc in (select paridepacc from epacc  where idepacc in (select idepacc from entrydetailview where idrelated like'%commessa%' and yentry = 2018  and identrykind = 8))

--select * from epexpvar where idepexp in (select paridepexp from epexp  where idepexp in (select idepexp from entrydetailview where idrelated like'%commessa%' and yentry = 2018  and identrykind = 8))
--select * from epaccvar where idepacc in (select paridepacc from epacc  where idepacc in (select idepacc from entrydetailview where idrelated like'%commessa%' and yentry = 2018  and identrykind = 8))


--delete from epexp where nphase = 1 and idrelated like'%commessa%' and yepexp = @ayear 
--and not exists (select * from epexp CH where CH.paridepexp = epexp.idepexp) --and identrykind = 8
--delete from epacc where nphase = 1 and idrelated like'%commessa%' and yepacc = @ayear  --and identrykind = 8
--and not exists (select * from epacc CH where CH.paridepacc = epacc.idepacc) 


--delete from epexpvar /* where nphase = 1 and idrelated like'%commessa%' and yepexp = 2018 */
--where not exists (select * from epexp CH where CH.idepexp = epexpvar.idepexp) --and identrykind = 8
--delete from epaccvar   /* nphase = 1 and idrelated like'%commessa%' and yepacc = 2018 */ --and identrykind = 8
--/*and*/ where not exists (select * from epacc CH where CH.idepacc = epaccvar.idepacc) 





delete from epexpyear/* where nphase = 1 and idrelated like'%commessa%' and yepexp = 2018 */
where idepexp in  (select idepexp from epexp where nphase = 1 and idrelated like'%commessa%' and yepexp = @ayear ) --and identrykind = 8

delete from epexptotal   /* nphase = 1 and idrelated like'%commessa%' and yepacc = 2018 */ --and identrykind = 8
/*and*/ where idepexp in  (select idepexp from epexp where nphase = 1 and idrelated like'%commessa%' and yepexp = @ayear ) --and identrykind = 8

delete from epaccyear/* where nphase = 1 and idrelated like'%commessa%' and yepexp = 2018 */
where idepacc in (select idepacc from epacc where nphase = 1 and idrelated like'%commessa%' and yepacc = @ayear ) --and identrykind = 8

delete from epacctotal   /* nphase = 1 and idrelated like'%commessa%' and yepacc = 2018 */ --and identrykind = 8
/*and*/ where idepacc in (select idepacc  from epacc where nphase = 1 and idrelated like'%commessa%' and yepacc = @ayear ) 


delete from epexpvar where idepexp in (select idepexp from epexp where nphase = 1 and idrelated like'%commessa%' and yepexp = @ayear )
delete from epaccvar where idepacc in (select idepacc  from epacc where nphase = 1 and idrelated like'%commessa%' and yepacc = @ayear )


delete from epexp  where    nphase = 1 and idrelated like'%commessa%' and yepexp = @ayear 
delete from epacc  where    nphase = 1 and idrelated like'%commessa%' and yepacc = @ayear 

delete from entry  where idrelated like'%commessa%' and yentry = @ayear and identrykind = 8
delete from entrydetail   where not exists (select * from entry where entrydetail.yentry = entry.yentry and entrydetail.nentry = entry.nentry )
delete from entrytotal where not exists (select * from entry where entrytotal.yentry = entry.yentry and entrytotal.nentry = entry.nentry )
 
delete from upbcommessa where ayear = @ayear

declare @ayear int
set @ayear = ----
exec rebuild_epexpyear  @ayear
go
declare @ayear int
set @ayear = ----
exec rebuild_epexptotal @ayear
go
declare @ayear int
set @ayear = ----
exec rebuild_epaccyear  @ayear
go
declare @ayear int
set @ayear = ----
exec rebuild_epacctotal	@ayear
go
declare @ayear int
set @ayear = ----
exec rebuild_upbepexptotal @ayear
go
declare @ayear int
set @ayear = ----
exec rebuild_upbepacctotal @ayear
go
 
	
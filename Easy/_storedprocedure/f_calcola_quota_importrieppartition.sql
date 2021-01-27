
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


-- ================================================
-- Template generated from Template Explorer using:
-- Create Inline Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter  setuser
if exists (select * from dbo.sysobjects where id = object_id(N'[f_calcola_quota_importrieppartition]') )
drop function f_calcola_quota_importrieppartition
GO

CREATE  FUNCTION f_calcola_quota_importrieppartition 
(	@idcsa_import int,
	@idriep int,
	@ndetail int
)
RETURNS @result TABLE (ndetail int,quota float, importo decimal(19,2))
AS
begin

declare @quotaapplicata float
declare @totaleresiduo decimal (19,2)
declare @ultimaquota float
declare @ultimoimporto decimal(19,2)
declare @quotadaapplicare float


if (@ndetail  is null) begin
	select @ultimoimporto= CV.importo
		from csa_importriep CV
		where CV.idcsa_import=@idcsa_import and CV.idriep=@idriep
	insert into @result(ndetail,quota,importo)
		values(1,1,@ultimoimporto)
	return
end


select --IV.idcsa_import,IV.idver,CE.ndetail, 
	@totaleresiduo = case when @totaleresiduo is null then IV.importo else @totaleresiduo-@ultimoimporto end, --totale_residuo
	--CE.quota,		--quota
	@quotaapplicata = case when @quotaapplicata is null then 0 else  @quotaapplicata+@ultimaquota end ,	--quota_applicata
	@ultimaquota= CE.quota, 
	@quotadaapplicare = case when @quotaapplicata= 1 then 0 else  CE.quota / (1-@quotaapplicata) end,
	@ultimoimporto =  round(@quotadaapplicare*@totaleresiduo,2)   --totresidual		
from csa_importriep IV
	join csa_contract C on C.idcsa_contract=IV.idcsa_contract and IV.ayear=C.ayear
	join csa_contract_partition CE on C.idcsa_contract=CE.idcsa_contract and CE.ayear=C.ayear
	where IV.idcsa_import=@idcsa_import and IV.idriep=@idriep and CE.ndetail<=@ndetail
	order by CE.ndetail

	insert into @result(ndetail,quota,importo)	values(@ndetail,@ultimaquota,@ultimoimporto)
return;

end
GO

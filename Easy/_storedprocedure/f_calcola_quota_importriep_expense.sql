-- ================================================
-- Template generated from Template Explorer using:
-- Create Inline Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter  setuser
if exists (select * from dbo.sysobjects where id = object_id(N'[f_calcola_quota_importriep_expense]') )
drop function f_calcola_quota_importriep_expense
GO

CREATE  FUNCTION f_calcola_quota_importriep_expense
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
	@quotadaapplicare = CE.quota / (1-@quotaapplicata),
	@ultimoimporto =  round(@quotadaapplicare*@totaleresiduo,2)   --totresidual		
from csa_importriep IV
	join csa_contract C on C.idcsa_contract=IV.idcsa_contract and IV.ayear=C.ayear
	join csa_contractexpense CE on C.idcsa_contract=CE.idcsa_contract and CE.ayear=C.ayear
	where IV.idcsa_import=@idcsa_import and IV.idriep=@idriep and CE.ndetail<=@ndetail
	order by CE.ndetail

	insert into @result(ndetail,quota,importo)	values(@ndetail,@ultimaquota,@ultimoimporto)
return;

end
GO

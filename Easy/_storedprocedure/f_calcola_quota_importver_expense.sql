if exists (select * from dbo.sysobjects where id = object_id(N'[f_calcola_quota_importver_expense]') )
drop function f_calcola_quota_importver_expense
GO

CREATE  FUNCTION f_calcola_quota_importver_expense 
(	@idcsa_import int,
	@idcsa_contracttax int,
	@idver int,
	@ndetail int
)
RETURNS @result TABLE (ndetail int,idcsa_contracttax int, quota float, importo decimal(19,2))
AS
begin

declare @quotaapplicata float
declare @totaleresiduo decimal (19,2)
declare @ultimaquota float
declare @ultimoimporto decimal(19,2)
declare @quotadaapplicare float


if (@ndetail  is null) begin
	select @ultimoimporto= CV.importo
		from csa_importver CV
		where CV.idcsa_import=@idcsa_import and CV.idver=@idver
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
from csa_importver IV
	join csa_contract C on C.idcsa_contract=IV.idcsa_contract and IV.ayear=C.ayear
	join csa_contracttaxexpense CE on C.idcsa_contract=CE.idcsa_contract and CE.ayear=C.ayear
			where	IV.idcsa_import=@idcsa_import and IV.idver=@idver  and CE.ndetail<=@ndetail
						and CE.idcsa_contracttax= @idcsa_contracttax
	order by CE.ndetail

	insert into @result(idcsa_contracttax,ndetail,quota,importo)	values(@idcsa_contracttax,@ndetail,@ultimaquota,@ultimoimporto)
return;

end
GO

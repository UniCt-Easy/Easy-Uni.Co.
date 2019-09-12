if exists (select * from dbo.sysobjects where id = object_id(N'[exp_riepilogo_coep_upb]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_riepilogo_coep_upb]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
--setuser 'amm'
--exp_riepilogo_coep_upb  2017, {ts '2017-01-01 00:00:00'},{ts '2017-12-31 00:00:00'},'%','S','N'

CREATE  PROCEDURE [exp_riepilogo_coep_upb]
(
	@ayear int,
	@start datetime,
	@stop datetime,
	@idupb varchar(36),
	@showupb char(1),
	@showchildupb char(1),
	@filteraccount varchar(50),
	@flag_noassestamentoprogp char(1)='S',  -- no assestamento progetti pluriennali
	@idsor01 int = null,
	@idsor02 int = null,
	@idsor03 int = null,
	@idsor04 int = null,
	@idsor05 int  = null
)
AS BEGIN


DECLARE @idupboriginal varchar(36)
SET @idupboriginal= @idupb
IF (@showchildupb = 'S' and @idupb<>'%')
BEGIN
	SET @idupb=@idupb+'%' 
END


		-- Calcola la lunghezza del filtro in base ad nlevel		
SET @filteraccount = RTRIM(@filteraccount) PRINT @filteraccount
IF  @filteraccount = ''
BEGIN
	SELECT @filteraccount = NULL
END

DECLARE @lenfilteracc int
SET @lenfilteracc = DATALENGTH(RTRIM(ISNULL(@filteraccount,''))) PRINT @lenfilteracc
CREATE TABLE #data
(
	idupb varchar(36),
	dare_ratei_attivi decimal(19,2),	avere_ratei_attivi decimal(19,2),
	dare_ratei_passivi decimal(19,2),	avere_ratei_passivi decimal(19,2),
	dare_risconti_attivi decimal(19,2),	avere_risconti_attivi decimal(19,2), 
	dare_risconti_passivi decimal(19,2),	avere_risconti_passivi decimal(19,2), 
	dare_debito decimal(19,2),	avere_debito decimal(19,2),
	dare_credito decimal(19,2),	avere_credito decimal(19,2),
	dare_costi decimal(19,2),	avere_costi decimal(19,2),
	dare_ricavi decimal(19,2),	avere_ricavi decimal(19,2),
	dare_immobilizzazioni decimal(19,2),	avere_immobilizzazioni decimal(19,2),
	dare_avanzo_libero decimal(19,2),	avere_avanzo_libero decimal(19,2),
	dare_avanzo_vincolato decimal(19,2),	avere_avanzo_vincolato decimal(19,2),
	dare_riserva decimal(19,2),	avere_riserva decimal(19,2), 
	dare_fondo_accantonamento decimal(19,2),	avere_fondo_accantonamento decimal(19,2), 
	dare_disponibilita_liquide decimal (19,2), avere_disponibilita_liquide decimal (19,2),
	dare_altre_voci_attivo decimal (19,2), avere_altre_voci_attivo decimal (19,2),
	dare_fondo_ammortamento decimal (19,2), avere_fondo_ammortamento decimal (19,2),	
	dare_altre_voci_passivo decimal (19,2), avere_altre_voci_passivo decimal (19,2),
	tosuppress char(1)
)


INSERT INTO #data
(
	idupb,
	dare_ratei_attivi,	avere_ratei_attivi,
	dare_ratei_passivi,	avere_ratei_passivi,
	dare_risconti_attivi,	avere_risconti_attivi, 
	dare_risconti_passivi,	avere_risconti_passivi, 
	dare_debito,	avere_debito,
	dare_credito,	avere_credito,
	dare_costi,	avere_costi,
	dare_ricavi,	avere_ricavi,
	dare_immobilizzazioni,	avere_immobilizzazioni,
	dare_avanzo_libero,	avere_avanzo_libero,
	dare_avanzo_vincolato,	avere_avanzo_vincolato,
	dare_riserva,	avere_riserva,
	dare_fondo_accantonamento,avere_fondo_accantonamento,
	dare_disponibilita_liquide, avere_disponibilita_liquide ,
	dare_altre_voci_attivo , avere_altre_voci_attivo ,
	dare_fondo_ammortamento , avere_fondo_ammortamento ,	
	dare_altre_voci_passivo , avere_altre_voci_passivo 
)
select entrydetail.idupb, 	
		sum(case when(( account.flagaccountusage & 1)<> 0 and amount<0) then -amount else 0 end), -- 'Dare(Ratei Attivi)'
		sum(case when(( account.flagaccountusage & 1)<> 0 and amount>0) then amount else 0 end), -- 'Avere(Ratei Attivi)'

		sum(case when(( account.flagaccountusage & 2)<> 0 and amount<0) then -amount else 0 end), -- 'Dare(Ratei Passivi)'
		sum(case when(( account.flagaccountusage & 2)<> 0 and amount>0) then amount else 0 end), -- 'Avere(Ratei Passivi)'

		sum(case when(( account.flagaccountusage & 4)<> 0 and amount<0) then -amount else 0 end), -- 'Dare(Risconti Attivi)'
		sum(case when(( account.flagaccountusage & 4)<> 0 and amount>0) then amount else 0 end), -- 'Avere(Risconti Attivi)'

		sum(case when(( account.flagaccountusage & 8)<> 0 and amount<0) then -amount else 0 end), -- 'Dare(Risconti Passivi)'
		sum(case when(( account.flagaccountusage & 8)<> 0 and amount>0) then amount else 0 end), -- 'Avere(Risconti Passivi)'

		sum(case when(( account.flagaccountusage & 16)<> 0 and amount<0) then -amount else 0 end), -- 'Dare(Debito)'
		sum(case when(( account.flagaccountusage & 16)<> 0 and amount>0) then amount else 0 end), -- 'Avere(Debito)'

		sum(case when(( account.flagaccountusage & 32)<> 0 and amount<0) then -amount else 0 end), -- 'Dare(Credito)'
		sum(case when(( account.flagaccountusage & 32)<> 0 and amount>0) then amount else 0 end), -- 'Avere(Credito)'

		sum(case when(( account.flagaccountusage & 64)<> 0 and amount<0) then -amount else 0 end), -- 'Dare(Costi)'
		sum(case when(( account.flagaccountusage & 64)<> 0 and amount>0) then amount else 0 end), -- 'Avere(Costi)'

		sum(case when(( account.flagaccountusage & 128)<> 0 and amount<0) then -amount else 0 end), -- 'Dare(Ricavi)'
		sum(case when(( account.flagaccountusage & 128)<> 0 and amount>0) then amount else 0 end), -- 'Avere(Ricavi)'

		sum(case when(( account.flagaccountusage & 256)<> 0 and amount<0) then -amount else 0 end), -- 'Dare(Immobilizzazioni)'
		sum(case when(( account.flagaccountusage & 256)<> 0 and amount>0) then amount else 0 end), -- 'Avere(Immobilizzazioni)'

		sum(case when(( account.flagaccountusage & 512)<> 0 and amount<0) then -amount else 0 end), -- 'Dare(Avanzo libero)'
		sum(case when(( account.flagaccountusage & 512)<> 0 and amount>0) then amount else 0 end), -- 'Avere(Avanzo libero)'

		sum(case when(( account.flagaccountusage & 1024)<> 0 and amount<0) then -amount else 0 end), -- 'Dare(Avanzo vincolato)'
		sum(case when(( account.flagaccountusage & 1024)<> 0 and amount>0) then amount else 0 end), -- 'Avere(Avanzo vincolato)'

		sum(case when(( account.flagaccountusage & 2048)<> 0 and amount<0) then -amount else 0 end), -- 'Dare(Riserva)'
		sum(case when(( account.flagaccountusage & 2048)<> 0 and amount>0) then amount else 0 end), -- 'Avere(Riserva)'

		sum(case when(( account.flagaccountusage & 4096)<> 0 and amount<0) then -amount else 0 end), -- 'Dare(Fondo accantonamento)'
		sum(case when(( account.flagaccountusage & 4096)<> 0 and amount>0) then amount else 0 end), -- 'Avere(Fondo accantonamento)'

		sum(case when(( account.flagaccountusage & 8192)<> 0 and amount<0) then -amount else 0 end), -- 'Dare(Disponibilita liquide)'
		sum(case when(( account.flagaccountusage & 8192)<> 0 and amount>0) then amount else 0 end), -- 'Avere(Disponibilita liquide)'

		sum(case when(( account.flagaccountusage & 16384)<> 0 and amount<0) then -amount else 0 end), -- 'Dare(Altre voci dell'attivo)'
		sum(case when(( account.flagaccountusage & 16384)<> 0 and amount>0) then amount else 0 end), -- 'Avere(Altre voci dell'attivo)'

		sum(case when(( account.flagaccountusage & 32768)<> 0 and amount<0) then -amount else 0 end), -- 'Dare( Fondo ammortamento)'
		sum(case when(( account.flagaccountusage & 32768)<> 0 and amount>0) then amount else 0 end), -- 'Avere( Fondo ammortamento)'

		sum(case when(( account.flagaccountusage & 65536)<> 0 and amount<0) then -amount else 0 end), -- 'Dare(Altre voci del passivo)'
		sum(case when(( account.flagaccountusage & 65536)<> 0 and amount>0) then amount else 0 end) -- 'Avere(Altre voci del passivo)'
		
from entrydetail
 join entry on entry.yentry =  entrydetail.yentry and  entry.nentry =  entrydetail.nentry
  join account  on entrydetail.idacc = account.idacc 
  left outer join upb on upb.idupb=entrydetail.idupb
where entry.identrykind not in (6,11,12)	
	AND ((account.flag&4)= 0)	-- ESCLUDO I CONTI D'ORDINE 
	AND (@filteraccount IS NULL OR SUBSTRING(account.codeacc, 1,@lenfilteracc) = @filteraccount)
	AND (@flag_noassestamentoprogp='N' or entry.identrykind NOT IN (8,13) ) -- s  no assestamento progetti pluriennali
	AND account.ayear = @ayear
	AND entry.adate between @start and @stop
	AND (@idsor01 IS NULL OR upb.idsor01 = @idsor01)
	AND (@idsor02 IS NULL OR upb.idsor02 = @idsor02)
	AND (@idsor03 IS NULL OR upb.idsor03 = @idsor03)
	AND (@idsor04 IS NULL OR upb.idsor04 = @idsor04)
	AND (@idsor05 IS NULL OR upb.idsor05 = @idsor05)
	AND (@idupb='%' OR upb.idupb like @idupb)
	group by  entrydetail.idupb,upb.printingorder
	ORDER BY upb.printingorder ASC

	

if (@idupboriginal <>'%') AND (@showupb = 'N')  -- totalizzo su upb original
begin
	 UPDATE #data SET idupb = @idupboriginal
end

if (@idupboriginal ='%') AND (@showupb = 'N')  -- totalizzo su upb original
begin
	 UPDATE #data SET idupb = null
end

--select * from #data
SELECT   
	upb.codeupb as 'Cod. Upb',
	upb.title as 'Upb',
	treasurer.description as 'Cassiere',
	case 
		when upb.flagactivity = 1 then 'Istituzionale'
		when upb.flagactivity = 2 then 'Commerciale'
		when  upb.flagactivity = 4 then 'Qualsiasi\Non specificata'
		else null
		end as 'Tipo Attività',
	upb.start as 'Data Inizio',
	upb.stop as 'Data Fine',
	(isnull(sum(avere_ricavi),0)-isnull(sum(dare_ricavi),0))-(isnull(sum(dare_costi),0)-isnull(sum(avere_costi),0)) as 'Utile',
	isnull(sum(dare_costi),0) as 'Dare(Costi)',
	isnull(sum(avere_costi),0) as 'Avere(Costi)',
	isnull(sum(dare_ricavi),0) as 'Dare(Ricavi)',
	isnull(sum(avere_ricavi),0) as 'Avere(Ricavi)',
	isnull(sum(dare_ratei_attivi),0) as 'Dare(Ratei Attivi)',
	isnull(sum(avere_ratei_attivi),0) as 'Avere(Ratei Attivi)',
	isnull(sum(dare_ratei_passivi),0) as 'Dare(Ratei Passivi)',
	isnull(sum(avere_ratei_passivi),0) as 'Avere(Ratei Passivi)',
	isnull(sum(dare_risconti_attivi),0) as 'Dare(Risconti Attivi)',
	isnull(sum(avere_risconti_attivi),0) as 'Avere(Risconti Attivi)', 
	isnull(sum(dare_risconti_passivi),0) as 'Dare(Risconti Passivi)',
	isnull(sum(avere_risconti_passivi),0) as 'Avere(Risconti Passivi)', 
	isnull(sum(dare_debito),0) as 'Dare(Debito)',
	isnull(sum(avere_debito),0) as 'Avere(Debito)',
	isnull(sum(dare_credito),0) as 'Dare(Credito)',
	isnull(sum(avere_credito),0) as 'Avere(Credito)',
	isnull(sum(dare_immobilizzazioni),0) as 'Dare(Immobilizzazioni)',
	isnull(sum(avere_immobilizzazioni),0) as 'Avere(Immobilizzazioni)' ,
	isnull(sum(dare_avanzo_libero),0) as 'Dare(Avanzo Libero)',
	isnull(sum(avere_avanzo_libero),0) as 'Avere(Avanzo Libero)',
	isnull(sum(dare_avanzo_vincolato),0) as 'Dare(Avanzo Vincolato)',
	isnull(sum(avere_avanzo_vincolato),0) as 'Avere(Avanzo vincolato)',
	isnull(sum(dare_riserva),0) as 'Dare(Riserva)',
	isnull(sum(avere_riserva),0) as 'Avere(Riserva)',
	isnull(sum(dare_fondo_accantonamento),0) as 'Dare(Fondo accantonamento)',
	isnull(sum(avere_fondo_accantonamento),0) as 'Avere(Fondo accantonamento)',
	isnull(sum(dare_disponibilita_liquide),0) as 'Dare(Disponibilità liquide)',
	isnull(sum(avere_disponibilita_liquide),0) as 'Avere(Disponibilità liquide)',
	isnull(sum(dare_altre_voci_attivo),0) as 'Dare(Altre voci dell''attivo)',
	isnull(sum(avere_altre_voci_attivo),0) as 'Avere(Altre voci dell''attivo)',
	isnull(sum(dare_fondo_ammortamento),0) as 'Dare(Fondo ammortamento)',
	isnull(sum(avere_fondo_ammortamento),0) as 'Avere(Fondo ammortamento)',
	isnull(sum(dare_altre_voci_passivo),0) as 'Dare(Altre voci del passivo)',
	isnull(sum(avere_altre_voci_passivo),0) as 'Avere(Altre voci del passivo)',
	manager.title as 'Respons.',
	upb.printingorder as 'Ord. Stampa',
	#data.idupb as '#idupb',
	epupbkind.title as 'Tipo upb',
	case when epupbkindyear.adjustmentkind='C' then 'Commessa completata'
		 when epupbkindyear.adjustmentkind='P' then 'Perc. completamento'
		 else null
	end as 'tipo assestamento'
FROM #data
left outer JOIN upb on #data.idupb = upb.idupb 
left outer JOIN treasurer  on upb.idtreasurer = treasurer.idtreasurer
LEFT OUTER JOIN manager 	 ON manager.idman = upb.idman 
LEFT OUTER JOIN epupbkind ON epupbkind.idepupbkind = upb.idepupbkind
LEFT OUTER JOIN epupbkindyear ON epupbkindyear.idepupbkind = upb.idepupbkind and epupbkindyear.ayear=@ayear
GROUP BY #data.idupb,	upb.codeupb,	upb.title,upb.start,upb.stop,
	upb.printingorder ,treasurer.description,
	manager.title,epupbkind.title, upb.flagactivity,epupbkindyear.adjustmentkind
ORDER BY upb.printingorder 
 



END
GO


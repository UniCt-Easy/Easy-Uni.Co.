-- CREAZIONE VISTA voce8000lookupview
IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[voce8000lookupview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [dbo].[voce8000lookupview]
GO
 

CREATE     VIEW [dbo].voce8000lookupview
(
idvoce,
conto,
servicekind,
taxref,
voce,
taxcode,
voceimponibile,
vocequotaesente,
voce8000,
voce8000imponibile,
voce8000quotaesente,
flagcsausability,
active,
kind,
tax
)
AS
SELECT  
voce8000lookup.idvoce,
case when voce8000lookup.conto = 'A' then 'c/amministrazione'
	when voce8000lookup.conto = 'D' then 'c/dipendente'
	else voce8000lookup.conto
end	,
voce8000lookup.servicekind,
voce8000lookup.taxref,
voce8000lookup.voce,
voce8000lookup.taxcode,
voce8000lookup.voceimponibile,
voce8000lookup.vocequotaesente,
voce8000.description,
voce8000_imponibile.description,
voce8000_quotaesente.description,
voce8000lookup.flagcsausability,
voce8000.active,
voce8000.kind,
tax.description
FROM  voce8000lookup
join voce8000
	on voce8000lookup.voce = voce8000.voce
LEFT OUTER JOIN voce8000 voce8000_imponibile
	on voce8000_imponibile.voce = voce8000lookup.voceimponibile
LEFT OUTER JOIN voce8000 voce8000_quotaesente
	on voce8000_quotaesente.voce = voce8000lookup.vocequotaesente
join tax
	on voce8000lookup.taxcode = tax.taxcode
GO


 
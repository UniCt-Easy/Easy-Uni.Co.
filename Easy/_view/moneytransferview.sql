
-- CREAZIONE VISTA moneytransferview
IF EXISTS(select * from sysobjects where id = object_id(N'[moneytransferview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [moneytransferview]
GO





CREATE     VIEW [moneytransferview]
(
ytransfer,
ntransfer,
idtreasurersource,
treasurersource,
idtreasurerdest,
treasurerdest,
amount,
adate,
description,
nproceedspart,
yproceedspart,
yvar,
nvar,
rownum,
cu,
ct,
lu,
lt,
idsor01,
idsor02,
idsor03,
idsor04,
idsor05,
transferkind,
transferkinddescription

)
AS SELECT
moneytransfer.ytransfer,
moneytransfer.ntransfer,
moneytransfer.idtreasurersource,
TRS.description,
moneytransfer.idtreasurerdest,
TRD.description,
moneytransfer.amount,
moneytransfer.adate,
moneytransfer.description,
moneytransfer.nproceedspart,
moneytransfer.yproceedspart,
moneytransfer.yvar,
moneytransfer.nvar,
moneytransfer.rownum,
moneytransfer.cu,
moneytransfer.ct,
moneytransfer.lu,
moneytransfer.lt,
TRS.idsor01,
TRS.idsor02,
TRS.idsor03,
TRS.idsor04,
TRS.idsor05,
moneytransfer.transferkind,
case 
	when moneytransfer.transferkind = 'N' then 'Altro'	
	when moneytransfer.transferkind = 'R' then 'per Ritenute/Contributi'
	when moneytransfer.transferkind = 'I' then 'per Versamento IVA'
	when moneytransfer.transferkind = 'P' then 'Prestiti'
	when moneytransfer.transferkind = 'G' then 'Pagamenti o Incassi da girofondare'
	when moneytransfer.transferkind = 'V' then 'per Variazione di cassa'
end
FROM moneytransfer
JOIN treasurer TRS
	ON moneytransfer.idtreasurersource = TRS.idtreasurer
JOIN treasurer TRD
	ON moneytransfer.idtreasurerdest = TRD.idtreasurer



GO


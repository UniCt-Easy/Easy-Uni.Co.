-- CREAZIONE VISTA epexpview
IF EXISTS(select * from sysobjects where id = object_id(N'[epexpsortingview]') and OBJECTPROPERTY(id, N'IsView') = 1)
DROP VIEW [epexpsortingview]
GO



CREATE    VIEW [epexpsortingview]
AS 
SELECT      
 epexp.idepexp,epexpsorting.rownum,epexp.yepexp,epexp.nepexp,epexp.nphase,epexpsorting.kind,
 epexpsorting.description,epexpsorting.amount,epexpsorting.ayear,epexpsorting.adate,
  sorting.idsorkind, 
   epexpsorting.idsor, sortingkind.description AS sortingkind, sorting.sortcode, 
                         sorting.description AS sorting, epexpsorting.lt, epexpsorting.lu, epexpsorting.ct, epexpsorting.cu,
 epexp.idrelated
FROM            epexpsorting 
			INNER JOIN epexp (NOLOCK) ON epexp.idepexp = epexpsorting.idepexp 
			INNER JOIN sorting (NOLOCK) ON epexpsorting.idsor = sorting.idsor 
			INNER JOIN sortingkind (NOLOCK) ON sortingkind.idsorkind = sorting.idsorkind




GO




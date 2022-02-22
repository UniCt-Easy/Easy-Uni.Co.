
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


 

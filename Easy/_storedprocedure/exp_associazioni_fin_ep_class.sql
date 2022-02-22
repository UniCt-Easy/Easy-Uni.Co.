
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


 if exists (select * from dbo.sysobjects where id = object_id(N'[exp_associazioni_fin_ep_class]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [exp_associazioni_fin_ep_class]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
/****** Object:  StoredProcedure [exp_associazioni_fin_ep_class]    Script Date: 14/10/2020 11:03:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- setuser 'amministrazione'
-- select * from sortingkind sk  where sk.flag & 4 = 4
-- sp_help 'accmotivedetailview'

-- exp_associazioni_fin_ep_class 2016, 't'
CREATE    PROCEDURE [exp_associazioni_fin_ep_class]
(
	@ayear smallint,
	@tipo char(1)
)
AS BEGIN
	If @tipo = 'T'  -- Esporta tutte le associazioni tra la classificazione e le voci di bilancio e il piano dei conti
	BEGIN
		select	CASE WHEN ((f.flag & 1) = 0) THEN 'E' WHEN ((f.flag & 1) = 1) THEN 'S' END AS 'Parte Bil.' ,
				f.codefin as 'Codice Bilancio' , f.title as 'Denominazione Bilancio',
				a.codeacc as 'Codice Coep', a.title as 'Denominazione Coep',
				S.sortcode as 'Codice Class', S.description as 'Descrizione Class.',SK.codesorkind as 'Tipo Class.',
				AC.codemotive
		from sortingkind sk
		Join sorting S on s.idsorkind = sk.idsorkind
		join finsorting fs on fs.idsor = s.idsor
		join fin f on f.idfin = fs.idfin
		join accountsorting aso on aso.idsor = s.idsor
		join account a on a.idacc = aso.idacc
		left outer join accmotivedetail ACV ON a.idacc = ACV.idacc 		and ACV.ayear = @ayear
		left outer join accmotive AC ON ACV.idaccmotive = AC.idaccmotive
		where sk.flag & 4 = 4
		and  f.ayear = @ayear
		and a.ayear = @ayear
		order by S.sortcode 
	END
 	If @tipo = 'F'  -- Esporta tutte le associazioni tra la classificazione e le voci di bilancio e il piano dei conti
	BEGIN
		select  CASE WHEN ((f.flag & 1) = 0) THEN 'E' WHEN ((f.flag & 1) = 1) THEN 'S' END AS 'Parte Bil.' ,
		f.codefin as 'Codice Bilancio', f.title as 'Denominazione Bilancio'
		from finusable f 		
		where f.ayear = @ayear 
		and f.idfin not in (select idfin from finsorting fs 
							where fs.idsor in (select idsor from sorting s 
												join sortingkind sk  on s.idsorkind = sk.idsorkind 
												Where sk.flag & 4 = 4)
							)
		order by f.flag, f.codefin
	END
	If @tipo = 'E'  -- Esporta tutte le associazioni tra la classificazione e le voci di bilancio e il piano dei conti
	BEGIN
		select  a.codeacc as 'Codice Coep', a.title as 'Denominazione Coep'
		from accountusable a 		
		where a.ayear = @ayear 
		and a.idacc not in (select idacc from accountsorting aso
							where aso.idsor in (select idsor from sorting s 
												join sortingkind sk  on s.idsorkind = sk.idsorkind 
												Where sk.flag & 4 = 4)
							)
		order by a.codeacc
	END
 END 




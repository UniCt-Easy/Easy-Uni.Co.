
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


--[DBO]--
-- CREAZIONE PROCEDURE [dbo].[GenerateProgettoDetail]
IF EXISTS (select * from sysobjects where id = object_id(N'[dbo].[GenerateProgettoDetail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[GenerateProgettoDetail]
GO
CREATE PROCEDURE [dbo].[GenerateProgettoDetail]
	@idprogettokind int ,
	@idprogetto int,
	@user varchar(64)
AS
BEGIN
	SET NOCOUNT ON;

	-----------test-------------------------
	--declare @idprogettokind int = 2
	--declare @idprogetto int = 1
	--declare @user varchar(64) = 'utentetest'
	----------------------------------------
	
	--WORKPACKAGE
	INSERT INTO [dbo].[workpackage]
           ([idworkpackage]
           ,[idprogetto]
           ,[title]
           ,[description]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
	SELECT 
		(select isnull(max(idworkpackage),0)   from workpackage) + ROW_NUMBER() OVER(ORDER BY wpk.idworkpackagekind ASC) as idworkpackage,
		@idprogetto as idprogetto,
		wpk.title,
		'' as [description],
		getdate() as ct,
		@user as cu,
		getdate() as lt,
		@user as lu
	FROM workpackagekind wpk
	WHERE idprogettokind = @idprogettokind and not exists (	select x.title 
															from workpackage x 
															where x.idprogetto = @idprogetto and x.title = wpk.title)

	--VOCI COSTO
	INSERT INTO [dbo].[progettotipocosto]
           ([idprogettotipocosto]
           ,[idprogettotipocostokind]
           ,[idprogetto]
           ,[sortcode]
           ,[ammissibilita]
		   ,[title]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
	SELECT 
		(select isnull(max(idprogettotipocosto),0)   from progettotipocosto) + ROW_NUMBER() OVER(ORDER BY ptcck.idprogettotipocostokind ASC) as idprogettotipocosto,
		ptcck.idprogettotipocostokind,
		@idprogetto as idprogetto,
		null as sortcode,
		100 as ammissibilita,
		ptcck.title,
		getdate() as ct,
		@user as cu,
		getdate() as lt,
		@user as lu
		--,title
	FROM progettotipocostokind ptcck
	WHERE idprogettokind = @idprogettokind and not exists (	select x.idprogettotipocostokind 
															from progettotipocosto x 
															where x.idprogetto = @idprogetto and x.idprogettotipocostokind = ptcck.idprogettotipocostokind)

	--progettotipocostokindaccmotive: causali economico patrimoniali

	INSERT INTO [dbo].[progettotipocostoaccmotive]
           ([idprogetto]
           ,[idprogettotipocosto]
           ,[idaccmotive]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
			@idprogetto as idprogetto
			,ptc.idprogettotipocosto
			,ptcka.idaccmotive
			,getdate() as ct
			,@user as cu
			,getdate() as lt
			,@user as lu
	FROM progettotipocostokindaccmotive ptcka
	inner join progettotipocosto ptc on ptc.idprogettotipocostokind = ptcka.idprogettotipocostokind 
									and ptc.idprogetto = @idprogetto
	WHERE ptcka.idprogettokind = @idprogettokind 
	and not exists (select * 
					from progettotipocostoaccmotive x 
					where x.idprogetto = @idprogetto 
					and x.[idprogettotipocosto] = ptc.idprogettotipocosto 
					and x.idaccmotive = ptcka.idaccmotive)

	--progettotipocostokindcontrattokind: tipologia di contratti

	INSERT INTO [dbo].[progettotipocostocontrattokind]
           ([idprogettotipocosto]
           ,[idcontrattokind]
           ,[idprogetto]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
			 ptc.idprogettotipocosto
			,ptcka.idcontrattokind
			,@idprogetto as idprogetto
			,getdate() as ct
			,@user as cu
			,getdate() as lt
			,@user as lu
	FROM progettotipocostokindcontrattokind ptcka
	inner join progettotipocosto ptc on ptc.idprogettotipocostokind = ptcka.idprogettotipocostokind 
									and ptc.idprogetto = @idprogetto
	WHERE ptcka.idprogettokind = @idprogettokind 
	and not exists (select * 
					from progettotipocostocontrattokind x 
					where x.idprogetto = @idprogetto 
					and x.[idprogettotipocosto] = ptc.idprogettotipocosto 
					and x.idcontrattokind = ptcka.idcontrattokind)

	--progettotipocostokindinventorytree: classificazioni inventariali

	INSERT INTO [dbo].[progettotipocostoinventorytree]
           ([idprogettotipocosto]
           ,[idinv]
           ,[idprogetto]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
			 ptc.idprogettotipocosto
			,ptcka.idinv
			,@idprogetto as idprogetto
			,getdate() as ct
			,@user as cu
			,getdate() as lt
			,@user as lu
	FROM progettotipocostokindinventorytree ptcka
	inner join progettotipocosto ptc on ptc.idprogettotipocostokind = ptcka.idprogettotipocostokind 
									and ptc.idprogetto = @idprogetto
	WHERE ptcka.idprogettokind = @idprogettokind 
	and not exists (select * 
					from progettotipocostoinventorytree x 
					where x.idprogetto = @idprogetto 
					and x.[idprogettotipocosto] = ptc.idprogettotipocosto 
					and x.idinv = ptcka.idinv)

	--progettotipocostokindtax: tipi di ritenuta

	INSERT INTO [dbo].[progettotipocostotax]
           ([idprogettotipocosto]
           ,[taxcode]
           ,[idprogetto]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
     SELECT
			 ptc.idprogettotipocosto
			,ptcka.taxcode
			,@idprogetto as idprogetto
			,getdate() as ct
			,@user as cu
			,getdate() as lt
			,@user as lu
	FROM progettotipocostokindtax ptcka
	inner join progettotipocosto ptc on ptc.idprogettotipocostokind = ptcka.idprogettotipocostokind 
									and ptc.idprogetto = @idprogetto
	WHERE ptcka.idprogettokind = @idprogettokind 
	and not exists (select * 
					from progettotipocostotax x 
					where x.idprogetto = @idprogetto 
					and x.[idprogettotipocosto] = ptc.idprogettotipocosto 
					and x.taxcode = ptcka.taxcode)

	--CATEGORIE COSTO
	INSERT INTO [dbo].[progettobudget]
           ([idprogettobudget]
           ,[idprogetto]
           ,[idworkpackage]
           ,[idprogettotipocosto]
           ,[budget]
           ,[sortcode]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
	SELECT 
		(select isnull(max(idprogettobudget),0) from [progettobudget]) + ROW_NUMBER() OVER(ORDER BY ptcc.idprogettotipocostokind ASC) as [idprogettobudget],
		@idprogetto as idprogetto,
		wp.idworkpackage,
		ptcc.idprogettotipocosto,
		0 as budget,
		ROW_NUMBER() OVER(ORDER BY ptcc.sortcode ASC) as sortcode,
		getdate() as ct,
		@user as cu,
		getdate() as lt,
		@user as lu
	from workpackage wp inner join progettotipocosto ptcc on wp.idprogetto = ptcc.idprogetto
	where wp.idprogetto = @idprogetto and ptcc.idprogetto = @idprogetto and not exists (select x.idprogettobudget 
																						from progettobudget x 
																						where x.idprogetto = @idprogetto and x.idworkpackage = wp.idworkpackage and x.idprogettotipocosto = ptcc.idprogettotipocosto)
	order by wp.idworkpackage,ptcc.sortcode

	--TESTI
	INSERT INTO [dbo].[progettotesto]
           ([idprogettotesto]
           ,[idprogetto]
           ,[title]
           ,[description]
           ,[sortcode]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
	SELECT 
		(select isnull(max(idprogettotesto),0) from progettotesto) + ROW_NUMBER() OVER(ORDER BY ptk.idprogettotestokind ASC) as idprogettotesto,
        @idprogetto as idprogetto,
        ptk.titolo,
        '' as [description],
        ptk.sortcode,
		getdate() as ct,
		@user as cu,
		getdate() as lt,
		@user as lu
	FROM progettotestokind ptk
	WHERE ptk.idprogettokind = @idprogettokind and not exists (	select x.title 
																from progettotesto x 
																where x.idprogetto = @idprogetto and x.title = ptk.titolo)

	--ALLEGATI
	INSERT INTO [dbo].[progettoattach]
           ([idprogettoattach]
		   ,[idattach]
           ,[idprogetto]
           ,[title]
           ,[ct]
           ,[cu]
           ,[lt]
           ,[lu])
	SELECT 
		(select isnull(max(idprogettoattach),0) from progettoattach) + ROW_NUMBER() OVER(ORDER BY ptk.idprogettoattachkind ASC) as idprogettoattach,
		null as idattach,
        @idprogetto as idprogetto,
        ptk.title,
		getdate() as ct,
		@user as cu,
		getdate() as lt,
		@user as lu
	FROM progettoattachkind ptk
	WHERE ptk.idprogettokind = @idprogettokind and not exists (	select x.title 
																from progettoattach x 
																where x.idprogetto = @idprogetto and x.title = ptk.title)


END
GO

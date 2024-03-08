
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


if exists (select * from dbo.sysobjects where id = object_id(N'[compute_flowchartcopy]') 
and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [compute_flowchartcopy]
GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE  PROCEDURE [compute_flowchartcopy]
(
    @source	varchar(50),
	@dest	varchar(50),
	@startayear int,
	@stopayear  int
	
)
AS BEGIN
CREATE TABLE #log (messaggio varchar(255))
CREATE TABLE #ayearDipDest(ayear int )
/*
IF (@source <> @dest)
BEGIN
	INSERT INTO #log(messaggio)
	VALUES('Il dipartimento di partenza deve essere uguale a quello di destinazione')
	
	SELECT * FROM #log
	RETURN
END
*/

-- Inserisce in #ayearDipDest tutti gli esercizi in cui deve copiare la config. dell'organigramma. 
-- Prende tutti gli esercizi per cui è stata fatta la fase "Creazione nuovo esercizio"
-- Se non ho specificato l'esercizio di destinazione, e quindi '@stopayear IS NULL' devo copiare la config. in tutti gli esercizi (sia precedenti che successivi),
-- tranne quello di origine.
SET @stopayear = ISNULL(@stopayear,0)

DECLARE @query nvarchar(4000)
IF (@source = @dest)
BEGIN
-- se dipartimneto parteza = dipartimneto arrivo => esclude l'esercizio di partenza @startayear.
	SET @query =
	'SELECT ayear FROM '+ @dest+'.accountingyear'+
	' WHERE ( '+ CONVERT(varchar(4),@stopayear) +' = 0 AND ((flag&0x0F)>=1) AND ayear <> '+ CONVERT(varchar(4),@startayear) +' ) 
			OR
		 ( ayear = '+ CONVERT(varchar(4),@stopayear) +' ) '
END
ELSE
BEGIN
	SET @query =
	'SELECT ayear FROM '+ @dest+'.accountingyear'+
	' WHERE ( '+ CONVERT(varchar(4),@stopayear) +' = 0 AND ((flag&0x0F)>=1)  ) 
			OR
		 ( ayear = '+ CONVERT(varchar(4),@stopayear) +' ) '
END
 
INSERT INTO #ayearDipDest(ayear)
EXEC (@query)

-- Controlla che nel Dip. di partenza ci sia l'esercizio che vogliamo copiare
SET @query =
	'IF NOT EXISTS (SELECT * FROM ' + @source+'.accountingyear WHERE ayear = '+CONVERT(varchar(4),@startayear)+') 
	BEGIN	INSERT INTO #log(messaggio)
			VALUES(''Non esiste nel dipartimento : ' + @source+', l''''esercizio '' + ''' + CONVERT(varchar(4),@startayear) +''' )
	END'
EXEC (@query)

IF (SELECT COUNT(*) FROM #log) > 0
BEGIN
	SELECT * FROM #log
	RETURN
END

DECLARE @ayearcopying int
DECLARE crsayear INSENSITIVE CURSOR FOR
	SELECT ayear FROM #ayearDipDest
ORDER BY ayear
OPEN crsayear 
FETCH NEXT FROM crsayear INTO @ayearcopying

        WHILE @@fetch_status=0 begin

-- Se nel dip. di destinazione non ci sono righe nelle tab. dei livelli - struttura dell'organigrammam - funzioni,
-- allora fa la copia, anche se i dip. sono diversi.
 
				SET @query =
				'IF ( NOT EXISTS (SELECT * FROM ' +@dest+'.flowchartlevel WHERE ayear = '+CONVERT(varchar(4),@ayearcopying)+') 
				AND 
					NOT EXISTS (SELECT * FROM '+@dest+'.flowchart WHERE ayear = '+CONVERT(varchar(4),@ayearcopying)+')
				AND 
					NOT EXISTS (SELECT * FROM  '+@dest+'.flowchartrestrictedfunction WHERE idflowchart like SUBSTRING('''
					+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + ''%'') 
					)
				BEGIN
					INSERT INTO '+@dest+'.flowchartlevel(ayear, nlevel, description, flagusable,cu, ct, lu, lt)
					SELECT '+CONVERT(varchar(4),@ayearcopying)+', nlevel, description,flagusable,''compute_flowchartcopy'', GETDATE(), lu, GETDATE()
					FROM '+@source+'.flowchartlevel
					WHERE ayear = '+CONVERT(varchar(4),@startayear)+'

					INSERT INTO #log
					VALUES(''Trasferiti livelli organigramma annuale per esercizio '' + ''' + CONVERT(varchar(4),@ayearcopying) +''' )

					INSERT INTO '+@dest+'.flowchart
							(
								idflowchart,
								ayear, codeflowchart,
								nlevel, paridflowchart, printingorder, title, 
								fax, phone, address, idcity, cap, location,
								cu, ct, lu, lt
							)
						SELECT
							SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + SUBSTRING(idflowchart, 3, 32),'+CONVERT(varchar(4),@ayearcopying)+', codeflowchart, nlevel,
							SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + SUBSTRING(paridflowchart, 3, 32),printingorder, title,
							fax, phone, address, idcity, cap, location,
							''compute_flowchartcopy'', GETDATE(), lu, GETDATE()
						FROM '+@source+'.flowchart
						WHERE ayear = '+CONVERT(varchar(4),@startayear)+'
					INSERT INTO #log
					VALUES(''Trasferito Struttura Oganigramma annuale per esercizio '' + ''' + CONVERT(varchar(4),@ayearcopying) +''' )

					INSERT INTO  '+@dest+'.flowchartrestrictedfunction
						(
							idflowchart,
							idrestrictedfunction,
							ct,cu,lt,lu
						)
					SELECT
							SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + SUBSTRING(idflowchart, 3, 32),
							idrestrictedfunction,
							GETDATE(), ''compute_flowchartcopy'', GETDATE(), lu
					FROM '+@source+'.flowchartrestrictedfunction
					WHERE idflowchart like SUBSTRING('''+CONVERT(varchar(4),@startayear)+''', 3, 2) + ''%''

					INSERT INTO #log
					VALUES(''Trasferita restrizioni sicurezza esportazioni nel nuovo esercizio '' + ''' + CONVERT(varchar(4),@ayearcopying)+''' )
				END'
				print @query
				EXEC (@query)

-- Questi trasferimenti li fa solo se è l'operazione la si sta facendo all'interno dello stesso dipartimento, perchè
-- le tabelle hanno dei riferimenti esterni a tabelle NON dbo.
	if(@source = @dest)
	begin
				SET @query =
					'IF NOT EXISTS (SELECT * FROM '+@dest+'.flowchartexportmodule WHERE idflowchart like SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + ''%'')
					BEGIN
						INSERT INTO '+@dest+'.flowchartexportmodule
							(
								idflowchart,
								modulename,
								lu,
								lt
							)
						SELECT
								SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + SUBSTRING(idflowchart, 3, 32),
								modulename,
								lu, GETDATE()
							FROM '+@source+'.flowchartexportmodule
							WHERE idflowchart like SUBSTRING('''+CONVERT(varchar(4),@startayear)+''', 3, 2) + ''%''

							INSERT INTO #log
							VALUES(''Trasferite configurazioni sicurezza stampe nel nuovo esercizio '' + ''' + CONVERT(varchar(4),@ayearcopying)+''' )
					END'

				print @query
				EXEC (@query)

				SET @query =
					'IF NOT EXISTS (SELECT * FROM '+@dest+'.flowchartmanager WHERE idflowchart like SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + ''%'')
					BEGIN
						INSERT INTO '+@dest+'.flowchartmanager
							(
								idflowchart,
								idman,
								cu, ct, lu, lt
							)
						SELECT
							SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + SUBSTRING(idflowchart, 3, 32),
							idman,
							''compute_flowchartcopy'', GETDATE(), lu, GETDATE()
						FROM '+@source+'.flowchartmanager
						WHERE idflowchart like SUBSTRING('''+CONVERT(varchar(4),@startayear)+''', 3, 2) + ''%''

						INSERT INTO #log
						VALUES(''Trasferiti responsabili organigramma nel nuovo esercizio '' + ''' + CONVERT(varchar(4),@ayearcopying)+''' )
					END'

				print @query
				EXEC (@query)

				SET @query =
					'IF NOT EXISTS (SELECT * FROM  '+@dest+'.flowchartmodulegroup WHERE idflowchart like SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + ''%'')
					BEGIN
						INSERT INTO  '+@dest+'.flowchartmodulegroup
							(
								idflowchart,
								modulename,
								groupname,
								lu,
								lt

							)
						SELECT
								SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + SUBSTRING(idflowchart, 3, 32),
								modulename,
								groupname,
								lu, GETDATE()
						FROM '+@source+'.flowchartmodulegroup
						WHERE idflowchart like SUBSTRING('''+CONVERT(varchar(4),@startayear)+''', 3, 2) + ''%''
							INSERT INTO #log
							VALUES(''Trasferita configurazione sicurezza stampe nel nuovo esercizio '' + ''' + CONVERT(varchar(4),@ayearcopying)+''' )
					END'
					print @query
					EXEC (@query)


				SET @query =
					'IF NOT EXISTS (SELECT * FROM ' +@dest+'.flowchartsorting WHERE idflowchart like SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + ''%'')
					BEGIN
						INSERT INTO ' +@dest+'.flowchartsorting
							(
								idflowchart,
								quota,
								idsor,
								ct,cu,lt,lu
							)
						SELECT
								SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + SUBSTRING(idflowchart, 3, 32),
								quota,
								idsor,
								GETDATE(), ''compute_flowchartcopy'', GETDATE(), lu
						FROM '+@source+'.flowchartsorting
						WHERE idflowchart like SUBSTRING('''+CONVERT(varchar(4),@startayear)+''', 3, 2) + ''%''

						INSERT INTO #log
						VALUES(''Trasferita Classificazione organigramma nel nuovo esercizio '' + ''' + CONVERT(varchar(4),@ayearcopying)+''' )
					END'
					print @query
					EXEC (@query)

				SET @query =
					'IF NOT EXISTS (SELECT * FROM ' +@dest+'.flowchartupb WHERE idflowchart like SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + ''%'')
					BEGIN
						INSERT INTO ' +@dest+'.flowchartupb
							(
								idflowchart,
								idupb,
								ct,cu,lt,lu
							)
						SELECT
							SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + SUBSTRING(idflowchart, 3, 32),
							idupb,
							GETDATE(), ''compute_flowchartcopy'', GETDATE(), lu
						FROM '+@source+'.flowchartupb
						WHERE idflowchart like SUBSTRING('''+CONVERT(varchar(4),@startayear)+''', 3, 2) + ''%''

						INSERT INTO #log
						VALUES(''Trasferita associazione UPB organigramma nel nuovo esercizio '' + ''' + CONVERT(varchar(4),@ayearcopying)+''' )
					END'
					print @query
					EXEC (@query)



				SET @query =
					'IF NOT EXISTS (SELECT * FROM ' +@dest+'.flowchartmandatekind WHERE idflowchart like SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + ''%'')
					BEGIN
						INSERT INTO ' +@dest+'.flowchartmandatekind
							(
								idflowchart,
								idmankind,
								cu, ct, lu, lt
							)
						SELECT
							SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + SUBSTRING(idflowchart, 3, 32),
							idmankind,
							''compute_flowchartcopy'', GETDATE(), lu, GETDATE()
						FROM '+@source+'.flowchartmandatekind
						WHERE idflowchart like SUBSTRING('''+CONVERT(varchar(4),@startayear)+''', 3, 2) + ''%''

						INSERT INTO #log
						VALUES(''Trasferita associazione Tipi Contratto passivo  organigramma nel nuovo esercizio '' + ''' + CONVERT(varchar(4),@ayearcopying)+''' )
					END'
					print @query
					EXEC (@query)

				SET @query =
					'IF NOT EXISTS (SELECT * FROM ' +@dest+'.flowchartestimatekind WHERE idflowchart like SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + ''%'')
					BEGIN
						INSERT INTO ' +@dest+'.flowchartestimatekind
							(
								idflowchart,
								idestimkind,
								cu, ct, lu, lt
							)
						SELECT
							SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + SUBSTRING(idflowchart, 3, 32),
							idestimkind,
							''compute_flowchartcopy'', GETDATE(), lu, GETDATE()
						FROM '+@source+'.flowchartestimatekind
						WHERE idflowchart like SUBSTRING('''+CONVERT(varchar(4),@startayear)+''', 3, 2) + ''%''

						INSERT INTO #log
						VALUES(''Trasferita associazione Tipi Contratto attivo organigramma nel nuovo esercizio '' + ''' + CONVERT(varchar(4),@ayearcopying)+''' )
					END'
					print @query
					EXEC (@query)


				SET @query =
					'IF NOT EXISTS (SELECT * FROM ' +@dest+'.flowchartinvoicekind WHERE idflowchart like SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + ''%'')
					BEGIN
						INSERT INTO ' +@dest+'.flowchartinvoicekind
							(
								idflowchart,
								idinvkind,
								cu, ct, lu, lt
							)
						SELECT
							SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + SUBSTRING(idflowchart, 3, 32),
							idinvkind,
							''compute_flowchartcopy'', GETDATE(), lu, GETDATE()
						FROM '+@source+'.flowchartinvoicekind
						WHERE idflowchart like SUBSTRING('''+CONVERT(varchar(4),@startayear)+''', 3, 2) + ''%''

						INSERT INTO #log
						VALUES(''Trasferita associazione Documenti IVA organigramma nel nuovo esercizio '' + ''' + CONVERT(varchar(4),@ayearcopying)+''' )
					END'
					print @query
					EXEC (@query)

				SET @query =
					'IF NOT EXISTS (SELECT * FROM ' +@dest+'.flowchartauthagency WHERE idflowchart like SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + ''%'')
					BEGIN
						INSERT INTO ' +@dest+'.flowchartauthagency
							(
								idflowchart,
								idauthagency,
								lu, lt
							)
						SELECT
							SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + SUBSTRING(idflowchart, 3, 32),
							idauthagency,
						    ''compute_flowchartcopy'', GETDATE()
						FROM '+@source+'.flowchartauthagency
						WHERE idflowchart like SUBSTRING('''+CONVERT(varchar(4),@startayear)+''', 3, 2) + ''%''

						INSERT INTO #log
						VALUES(''Trasferita associazione Agenti autorizzatori Missioni organigramma nel nuovo esercizio '' + ''' + CONVERT(varchar(4),@ayearcopying)+''' )
					END'
						
				print @query
				EXEC (@query)
					
				SET @query =
					'IF NOT EXISTS (SELECT * FROM ' +@dest+'.flowchartauthmodel WHERE idflowchart like SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + ''%'')
					BEGIN
						INSERT INTO ' +@dest+'.flowchartauthmodel
							(
								idflowchart,
								idauthmodel,
								cu, ct, lu, lt
							)
						SELECT
							SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + SUBSTRING(idflowchart, 3, 32),
							idauthmodel,
							''compute_flowchartcopy'', GETDATE(), lu, GETDATE()
						FROM '+@source+'.flowchartauthmodel
						WHERE idflowchart like SUBSTRING('''+CONVERT(varchar(4),@startayear)+''', 3, 2) + ''%''

						INSERT INTO #log
						VALUES(''Trasferita associazione Modelli autorizzativi Missioni organigramma nel nuovo esercizio '' + ''' + CONVERT(varchar(4),@ayearcopying)+''' )
					END'
					
					print @query
					EXEC (@query)
									SET @query =
					'IF NOT EXISTS (SELECT * FROM ' +@dest+'.flowchartpettycash WHERE idflowchart like SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + ''%'')
					BEGIN
						INSERT INTO ' +@dest+'.flowchartpettycash
							(
								idflowchart,
								idpettycash,
								cu, ct, lu, lt
							)
						SELECT
							SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + SUBSTRING(idflowchart, 3, 32),
							idpettycash,
							''compute_flowchartcopy'', GETDATE(), lu, GETDATE()
						FROM '+@source+'.flowchartpettycash
						WHERE idflowchart like SUBSTRING('''+CONVERT(varchar(4),@startayear)+''', 3, 2) + ''%''

						INSERT INTO #log
						VALUES(''Trasferita associazione Fondi Economale organigramma nel nuovo esercizio '' + ''' + CONVERT(varchar(4),@ayearcopying)+''' )
					END'
					print @query
					EXEC (@query)

				----------------------------------------------------------------------------------
				----------------- FLOWCHARTFIN DOPO IL TRASFERIMENTO DEL BILANCIO-----------------
				----------------------------------------------------------------------------------
/* 
SE  ( @startayear < @ayearcopying ) vuol dire che stiamo trasferendo negli esercizio successivi, in avanti, 2006->2007,2008,...
		l'IF controlla che in allfinlookup esista la voce di bilancio come old nell'anno start (2006) e come new nell'anno copying(2007,2008,...)
		perchè deve fare	old = 2006 -> new = 2007
							old = 2006 -> new = 2008

SE  ( @startayear > @ayearcopying ) vuol dire che stiamo trasferendo negli esercizio precedenti, in dietro, 2006->2005,2004,...
		l'IF controlla che in allfinlookup esista la voce di bilancio come new nell'anno start (2006) e come old nell'anno copying(2004,2005,...)
		perchè deve fare new = 2006 -> old = 2004
						 new = 2006 -> old = 2005
*/
		IF(@startayear<@ayearcopying)
		begin
				SET @query =
					'IF (
						EXISTS (SELECT * 
										FROM '+@dest+'.allfinlookup FK
										JOIN '+@dest+'.fin Fold ON FK.oldidfin = Fold.idfin
										JOIN '+@dest+'.fin Fnew ON FK.newidfin = Fnew.idfin
										WHERE Fold.ayear = '+CONVERT(varchar(4),@startayear)+'
											AND Fnew.ayear = '+ CONVERT(varchar(4), @ayearcopying) +'	)		
							
						AND 
						NOT EXISTS (SELECT * 
							  FROM ' +@dest+'.flowchartfin 
								 WHERE idflowchart like SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + ''%'')
						)
					BEGIN
						INSERT INTO ' +@dest+'.flowchartfin
							(
								idflowchart,
								idfin,
								ct,cu,lt,lu
							)
						SELECT
							SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + SUBSTRING(FC.idflowchart, 3, 32),
							FL.newidfin,
							GETDATE(), ''compute_flowchartcopy'', GETDATE(), FC.lu
						FROM '+@source+'.flowchartfin FC
						JOIN '+@source+'.fin F 
								ON FC.idfin = F.idfin
						JOIN '+@source+'.allfinlookup FL 
								ON FC.idfin = FL.oldidfin
						JOIN '+@source+'.fin Fnew
							ON FL.newidfin = Fnew.idfin
						WHERE F.ayear = '+ CONVERT(varchar(4),@startayear) +'
							AND Fnew.ayear = '+ CONVERT(varchar(4), @ayearcopying) +'
							AND FC.idflowchart like SUBSTRING('''+CONVERT(varchar(4),@startayear)+''', 3, 2) + ''%''

					INSERT INTO #log
					VALUES(''Trasferita Sicurezza Bilancio nel nuovo esercizio '' + ''' + CONVERT(varchar(4),@ayearcopying)+''' )

					END'
					print @query
					EXEC (@query)
		End
		IF(@startayear > @ayearcopying)-- 2009 -> 2008
		Begin
				SET @query =
					'IF (
						EXISTS (SELECT * 
										FROM '+@dest+'.allfinlookup FK
										JOIN '+@dest+'.fin Fnew ON FK.newidfin = Fnew.idfin
										JOIN '+@dest+'.fin Fold ON FK.oldidfin = Fold.idfin
										WHERE Fnew.ayear = '+CONVERT(varchar(4),@startayear)+'
										AND Fold.ayear = '+ CONVERT(varchar(4), @ayearcopying) +'	)		
						AND 
						NOT EXISTS (SELECT * 
							  FROM ' +@dest+'.flowchartfin 
								 WHERE idflowchart like SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + ''%'')
						)
					BEGIN
						INSERT INTO ' +@dest+'.flowchartfin
							(
								idflowchart,
								idfin,
								ct,cu,lt,lu
							)
						SELECT
							SUBSTRING('''+CONVERT(varchar(4),@ayearcopying)+''', 3, 2) + SUBSTRING(FC.idflowchart, 3, 32),
							FL.oldidfin,
							GETDATE(), ''compute_flowchartcopy'', GETDATE(), FC.lu
						FROM '+@source+'.flowchartfin FC
						JOIN '+@source+'.fin F 
								ON FC.idfin=F.idfin
						JOIN '+@source+'.allfinlookup FL 
								ON FC.idfin = FL.newidfin
						JOIN '+@source+'.fin Fold
							ON FL.oldidfin = Fold.idfin
						WHERE F.ayear = '+ CONVERT(varchar(4), @startayear) +'
							AND Fold.ayear = '+ CONVERT(varchar(4), @ayearcopying) +'
							AND FC.idflowchart like SUBSTRING('''+CONVERT(varchar(4),@startayear)+''', 3, 2) + ''%''
						INSERT INTO #log
						VALUES(''Trasferita Sicurezza Bilancio nel nuovo esercizio '' + ''' + CONVERT(varchar(4),@ayearcopying)+''' )
					END'
					print @query
					EXEC (@query)
			end
	end

	FETCH NEXT FROM crsayear INTO @ayearcopying
end

deallocate crsayear
SELECT * FROM #log

DROP TABLE #log
DROP TABLE #ayearDipDest

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


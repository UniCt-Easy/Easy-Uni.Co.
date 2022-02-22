
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


if exists (select * from dbo.sysobjects where id = object_id(N'[show_unifiedf24ep]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [show_unifiedf24ep]
GO

 
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO
 
 
--show_unifiedf24ep 4
CREATE procedure [show_unifiedf24ep](@idunifiedf24ep int) as
begin

	create table #tributi (
		codicetributo varchar(20),
		descrizione   varchar(400),
		tipoente varchar(6),
		flagmese varchar(6)
	)
	insert into #tributi values ('384E','Addizionale comunale Irpef - saldo', 'CCCC','00MM')
	insert into #tributi values ('385E','Addizionale comunale Irpef - acconto', 'CCCC','00MM') 
	insert into #tributi values ('891E','Sanzioni per ravvedimento su Addizionale comunale Irpef','CCCC',  null) 
	insert into #tributi values ('380E','IRAP', 'RR','00MM')
	insert into #tributi values ('381E','Addizionale regionale Irpef', 'RR','00MM')
	insert into #tributi values ('892E','Sanzioni per ravvedimento su IRAP', 'RR',  null) 
	insert into #tributi values ('893E','Sanzioni per ravvedimento Addizionale regionale Irpef', 'RR',  null)
	insert into #tributi values ('100E','Ritenute sui redditi da lavoro dipendente ed assimilati', null,'00MM')
	insert into #tributi values ('104E','Ritenute sui redditi da lavoro autonomo', null,'00MM')
	insert into #tributi values ('105E','Ritenute sulle indennità di esproprio, occupazione', null,'00MM')
	insert into #tributi values ('106E','Ritenute sui contributi corrisposti alle imprese', null,'00MM') 
	insert into #tributi values ('107E','Altre ritenute alla fonte', null,'00MM')
	insert into #tributi values ('890E','Sanzioni per ravvedimento su ritenute erariali', null,  null) 
	insert into #tributi values ('C10',  'Gestione Committenti',  null,null) 
	insert into #tributi values ('CXX',  'Gestione Committenti',  null,null) 
	insert into #tributi values ('P101', 'Cassa C.T.P.S. - contributi obbligatori',  null,null) 
	insert into #tributi values ('P909', 'Cassa unica del credito',  null,null) 
	insert into #tributi values ('112E','Ritenuta alla fonte su somme pignorate ',null,null) 
	insert into #tributi values ('150E', 'SOMME A TITOLO DI IMPOSTE ERARIALI 
											  RIMBORSATE DAL SOSTITUTO D''IMPOSTA 
											  A SEGUITO DI ASSISTENZA FISCALE - ART.15, C.1,LETT.A)', null,'AAAA') --SOMME A TITOLO DI IMPOSTE ERARIALI RIMBORSATE DAL SOSTITUTO D''IMPOSTA A SEGUITO DI ASSISTENZA FISCALE - ART.15, C.1,LETT.A)
	insert into #tributi values ('134E', 'IRPEF A SALDO TRATTENUTA DAL
											 SOSTITUTO D''IMPOSTA', '00MM','AAAA') --IRPEF A SALDO TRATTENUTA DAL SOSTITUTO D''IMPOSTA
	insert into #tributi values ('126E', 'ADDIZIONALE REGIONALE ALL''IRPEF TRATTENUTA 
											 DAL SOSTITUTO D''IMPOSTA A SEGUITO
											 DI ASSISTENZA FISCALE',  '00MM','AAAA') --ADDIZIONALE REGIONALE ALL''IRPEF TRATTENUTA DAL SOSTITUTO D''IMPOSTA A SEGUITO DI ASSISTENZA FISCALE
	insert into #tributi values ('153E', 'SOMME A TITOLO DI ADDIZIONALE REGIONALE
											 ALL''IRPEF RIMBORSATE DAL SOSTITUTO D''IMPOSTA
											 A SEGUITO DI ASSISTENZA FISCALE - ART. 15, COMMA1,
											 LETT.A)D.LGS. N. 175/2014', null, 'AAAA') --SOMME A TITOLO DI ADDIZIONALE REGIONALE ALL''IRPEF RIMBORSATE DAL SOSTITUTO D''IMPOSTA A SEGUITO DI ASSISTENZA FISCALE - ART. 15, COMMA1,LETT.A)D.LGS. N. 175/2014
	insert into #tributi values ('127E', 'ADDIZIONALE COMUNALE ALL''IRPEF TRATTENUTA 
											 DAL SOSTITUTO D''IMPOSTA MOD. 730- ACCONTO – ', '00MM','AAAA') --ADDIZIONALE COMUNALE ALL''IRPEF TRATTENUTA DAL SOSTITUTO D''IMPOSTA MOD. 730- ACCONTO –
	insert into #tributi values ('128E', 'ADDIZIONALE COMUNALE ALL''IRPEF TRATTENUTA 
											 DAL SOSTITUTO D''IMPOSTA MOD. 730-', '00MM','AAAA') --ADDIZIONALE COMUNALE ALL''IRPEF TRATTENUTA DAL SOSTITUTO D''IMPOSTA MOD. 730- ACCONTO –
	insert into #tributi values ('154E', 'SOMME A TITOLO DI ADDIZIONALE 
											  COMUNALE ALL''IRPEF RIMBORSATE DAL SOSTITUTO 
											  D''IMPOSTA A SEGUITO DI ASSISTENZA 
											  FISCALE - ART. 15, COMMA1,LETT.A)D.LGS. N. 175/2014',  null,'AAAA') --SOMME A TITOLO DI ADDIZIONALE COMUNALE ALL'IRPEF RIMBORSATE DAL SOSTITUTO D'IMPOSTA A SEGUITO DI ASSISTENZA FISCALE - ART. 15, COMMA1,LETT.A)D.LGS. N. 175/2014
	insert into #tributi values ('133E', 'IRPEF IN ACCONTO TRATTENUTA
											  DAL SOSTITUTO D''IMPOSTA', '00MM','AAAA') --SOMME A TITOLO DI ADDIZIONALE COMUNALE ALL'IRPEF RIMBORSATE DAL SOSTITUTO D'IMPOSTA A SEGUITO DI ASSISTENZA FISCALE - ART. 15, COMMA1,LETT.A)D.LGS. N. 175/2014

-- inserire qui i codici tributo a credito
	
 
		
	insert into #tributi values ( '161E', 'Addizionale comunale Irpef trattenuta dai sostituti d’imposta -saldo','00MM','AAAA') -- Addizionale comunale Irpef trattenuta dai sostituti d’imposta -saldo  
	insert into #tributi values ( '160E', 'Addizionale regionale Irpef trattenuta dai sostituti d’imposta', '00MM','AAAA') -- Addizionale regionale Irpef trattenuta dai sostituti d’imposta  
	insert into #tributi values ( '156E', 'Ritenute sui redditi da lavoro autonomo', '00MM','AAAA') -- Ritenute sui redditi da lavoro autonomo  	
	insert into #tributi values ( '155E', 'Ritenute sui redditi da lavoro dipendente ed assimilati', '00MM','AAAA') -- Ritenute sui redditi da lavoro dipendente ed assimilati  
	insert into #tributi values ( '165E', 'Bonus fiscale', '00MM','AAAA') -- Bonus fiscale 


	CREATE TABLE #situation (value varchar(250), amount decimal(19,2), kind char(1))
	
	DECLARE	@departmentname varchar(150)
	SET     @departmentname =  (SELECT
		isnull(description,'') 
		FROM dbdepartment 
		WHERE rtrim(ltrim(lower(iddbdepartment))) = 'amministrazione')
	
	DECLARE @cf varchar(11)
	SELECT  @cf = cf from license

	
	DECLARE @ayear int
	DECLARE @datagenerazione datetime
	DECLARE @dataversamento  datetime
	DECLARE @totalpayed      decimal(19,2)
	DECLARE @totalrefund     decimal(19,2)

	SELECT  @ayear  = ayear,  
			@datagenerazione = adate ,
			@dataversamento  = paymentdate
	FROM    unifiedf24ep 
	WHERE   idunifiedf24ep = @idunifiedf24ep
	
	DECLARE @iban_contoaddebito   varchar(50)
	SELECT  @iban_contoaddebito = iban_f24 FROM config where ayear = @ayear
	
	INSERT INTO #situation VALUES ('Modello F24 EP di Ateneo', NULL, 'H')
	INSERT INTO #situation VALUES (@departmentname, NULL, 'H')
	INSERT INTO #situation VALUES ('Codice Fiscale: ' + CONVERT(char(20), @cf), NULL, 'H')
	INSERT INTO #situation VALUES ('Esercizio ' + CONVERT(char(4), @ayear) + ' Numero ' + CONVERT(char(10), @idunifiedf24ep)  , NULL, 'H')
	INSERT INTO #situation VALUES ('Data di generazione ' +  CONVERT(char(8), @datagenerazione, 3), NULL, 'H')
	INSERT INTO #situation VALUES ('', NULL, 'N')
	
	--info sul versamento
	INSERT INTO #situation VALUES ('Data di versamento ' + CONVERT(char(8), @dataversamento, 3), NULL, 'N')
	IF isnull(@iban_contoaddebito,'')<> '' 
	INSERT INTO #situation VALUES ('Conto di addebito ' + CONVERT(char(50), @iban_contoaddebito), NULL, 'N')
	INSERT INTO #situation VALUES ('', NULL, 'N')
	
	
	-- sezione generale
	
	CREATE TABLE #unifiedtax_or_corrige
	(
		fiscaltaxcode 		varchar(20),
		amount			decimal(19,2),
		correctamount		decimal(19,2)
	)
	
	INSERT INTO #unifiedtax_or_corrige
	(
		fiscaltaxcode 		,
		amount
	)
	SELECT
		U.fiscaltaxcode 	,
		isnull(sum(isnull(U.employtax,0) + isnull(U.admintax,0)),0)
	FROM  unifiedtaxview U
	WHERE U.idunifiedf24ep =  @idunifiedf24ep
	GROUP BY U.fiscaltaxcode 
	

	INSERT INTO #unifiedtax_or_corrige
	(
		fiscaltaxcode 		,
		amount
	)
	SELECT
		S.fiscaltaxcode 	,
		isnull(sum(amount),0)
	FROM  unifiedf24epsanction U
	JOIN  f24epsanctionkind S
	ON  S.idsanction = U.idsanction
	WHERE U.idunifiedf24ep = @idunifiedf24ep
	GROUP BY S.fiscaltaxcode 
	
	--select * from #unifiedtax_or_corrige

	
	UPDATE #unifiedtax_or_corrige
	SET correctamount = 
	(SELECT isnull(sum(isnull(U.employamount,0) + isnull(U.adminamount,0) ),0)
	   FROM    unifiedtaxcorrigeview U
	WHERE U.idunifiedf24ep =  @idunifiedf24ep
	AND   U.fiscaltaxcode= #unifiedtax_or_corrige.fiscaltaxcode
	--GROUP BY U.fiscaltaxcode 
	)
	
	--select * from #unifiedtax_or_corrige
	
	INSERT INTO #unifiedtax_or_corrige
	(
		fiscaltaxcode 		,
		correctamount		
	)
	SELECT
		U.fiscaltaxcode 	,
		isnull(sum(isnull(U.employamount,0) + isnull(U.adminamount,0) ),0)
	FROM    unifiedtaxcorrigeview U
	WHERE U.idunifiedf24ep =  @idunifiedf24ep
	AND   NOT EXISTS 
	(SELECT U.fiscaltaxcode FROM #unifiedtax_or_corrige  
		WHERE U.fiscaltaxcode = 
		      #unifiedtax_or_corrige.fiscaltaxcode)
	GROUP BY U.fiscaltaxcode 
	
	--select * from #unifiedtax_or_corrige

	DECLARE @fiscaltaxcode varchar(20)
	DECLARE @fiscaltax     varchar(150)
	DECLARE @importoadebito decimal(19,2)
	DECLARE @importoacredito decimal(19,2)
	DECLARE @importocorrezioni decimal(19,2)
 
	SET  @totalpayed = 0
	SET  @totalrefund = 0
 DECLARE cur CURSOR FOR 
	SELECT  U.fiscaltaxcode,
		T.descrizione,
		ISNULL(U.amount,0),
		ISNULL(U.correctamount,0)
	FROM    #unifiedtax_or_corrige U
	JOIN    #tributi T
		ON  U.fiscaltaxcode = T.codicetributo
			WHERE (ISNULL(U.amount,0)  + ISNULL(U.correctamount,0)) >= 0
	ORDER BY U.fiscaltaxcode
	
	OPEN cur
		FETCH next FROM cur INTO  @fiscaltaxcode, @fiscaltax, @importoadebito, @importocorrezioni		
		WHILE @@fetch_status = 0
		BEGIN
		print @fiscaltaxcode
		print @importoadebito
		print @importocorrezioni
		print @importoadebito +  @importocorrezioni 
			INSERT INTO #situation VALUES (@fiscaltaxcode + ' - ' + @fiscaltax ,@importoadebito + @importocorrezioni , '')
			SET  @totalpayed = @totalpayed + @importoadebito + @importocorrezioni
		FETCH next FROM cur INTO  @fiscaltaxcode, @fiscaltax, @importoadebito, @importocorrezioni
	END
	CLOSE cur
	DEALLOCATE cur
 
	DECLARE curcredit CURSOR FOR 
	SELECT  U.fiscaltaxcode,
		T.descrizione,
		-ISNULL(U.amount,0),
		-ISNULL(U.correctamount,0)
	FROM    #unifiedtax_or_corrige U
	JOIN    #tributi T
		ON  U.fiscaltaxcode = T.codicetributo
	WHERE (ISNULL(U.amount,0)  + ISNULL(U.correctamount,0)) < 0
	ORDER BY U.fiscaltaxcode
	
	OPEN curcredit
		FETCH next FROM curcredit INTO  @fiscaltaxcode, @fiscaltax, @importoacredito, @importocorrezioni		
		WHILE @@fetch_status = 0
		BEGIN
		print @fiscaltaxcode
		print @importoacredito
		print @importocorrezioni
		print @importoacredito +  @importocorrezioni 
			INSERT INTO #situation VALUES (@fiscaltaxcode + ' - ' + @fiscaltax ,- (@importoacredito + @importocorrezioni) , '')
			SET  @totalrefund = @totalrefund + @importoacredito + @importocorrezioni
		FETCH next FROM curcredit INTO  @fiscaltaxcode, @fiscaltax, @importoacredito, @importocorrezioni
	END
	CLOSE curcredit
	DEALLOCATE curcredit

	

		
	CREATE TABLE #unifiedclawback
	(
		fiscaltaxcode 		varchar(20),
		amount			decimal(19,2) 
	)
	
	INSERT INTO #unifiedclawback
		(fiscaltaxcode, amount)
	SELECT
		U.fiscaltaxcode,
		isnull(sum(amount),0) 
	FROM  unifiedclawback U
	WHERE U.idunifiedf24ep = @idunifiedf24ep
	GROUP BY U.fiscaltaxcode 
	
	IF ((SELECT COUNT(fiscaltaxcode) FROM #unifiedclawback) > 0) 
	BEGIN
		INSERT INTO #situation VALUES ('Interventi Sostitutivi', NULL, 'N')
			
		INSERT INTO #situation 
		SELECT
			U.fiscaltaxcode,
			amount,
			''
		FROM  #unifiedclawback U
	END
	
	INSERT INTO #situation VALUES ('', NULL, 'N')
	
	SELECT @totalpayed = @totalpayed + 
	isnull((SELECT isnull(sum(amount),0) 
	  FROM #unifiedclawback),0)
	
 

	INSERT INTO #situation VALUES ('Totale Addebito' , @totalpayed , 'S')
	INSERT INTO #situation VALUES ('Totale Credito'  , @totalrefund , 'S')

	SELECT value, amount, kind FROM #situation
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


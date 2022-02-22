
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


IF EXISTS(select * from sysobjects where id = object_id(N'[dbo].[GenerateUser]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[GenerateUser]
GO

CREATE PROCEDURE [dbo].[GenerateUser]
        @login varchar(60),
        @password varchar(100),
        @db varchar(100),
		@executor varchar(60),				-- utente che sta eseguento la procedura (per il log)
		@dipartimento varchar(60),
		@passwordalpha varchar(1024),		-- metaeasylibrary.Easy_DataAccess.getAlfaFromPassword(string userPassword)
		@passwordweb varchar(1024),			-- fc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations)
		@iterweb int,
		@saltweb varchar(50),
		@surname varchar(50),
		@forename varchar(49),
		@cf varchar(16),
		@email varchar(1024),
		@codeflowchart varchar(50) = NULL,	-- codice della voce dell'organigramma in cui inserire lutente
		@esercizio int = NULL,				-- esercizio dell'organigramma
		@usertype varchar(50), 				-- studenti, docenti, amministrativi 
		@matricola varchar(50) = NULL
AS
BEGIN

	declare @safe_login varchar(200);
	declare @safe_password varchar(200);
	declare @safe_db varchar(200);
	set @safe_login = replace(@login,'''', '''''');
	set @safe_password = replace(@password,'''', '''''');
	set @safe_db = replace(@db,'''', '''''');
	declare @sql nvarchar(max);
	declare @outmsg nvarchar(max) = '';

---------------------Utente SQL

IF NOT EXISTS (select loginname from master.dbo.syslogins where hasaccess = 1 and isntgroup=0 and loginname = @login)
BEGIN

	set @sql = --'use ' + @safe_db + ';' +
			   'create login [' + @safe_login + '] with password = ''' + @safe_password + ''', DEFAULT_DATABASE = ' + @safe_db + ', CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF; ' --+
			   --'create user DEV' + @safe_login + ' from login ' + @safe_login + ';'
	exec (@sql)

END
ELSE
BEGIN
	SET @outmsg = @outmsg + 'La login SQL esisteva già; ';
END


IF NOT EXISTS (select * from dbo.dbaccess where iddbdepartment = @dipartimento and [login] = @safe_login)
BEGIN

	exec sp_grantdbaccess @safe_login ,@safe_login;

	set @sql = 'exec sp_addrolemember  N''db_denydatawriter'', [' + @safe_login + '];
	GRANT  SELECT  ON [dbo].[dbaccess] TO [' + @safe_login + '];
	GRANT  SELECT  ON [' + @dipartimento + '].[customobject] TO [' + @safe_login + '];
	GRANT  SELECT  ON [' + @dipartimento + '].[columntypes] TO [' + @safe_login + '];'
	exec (@sql)

	INSERT [dbo].[dbaccess] ([alpha1], [iddbdepartment], [login], [lt], [lu], [pwdlastmod], [pwdmaxage], [pwdwarning]) 
	VALUES (@passwordalpha, @dipartimento, @safe_login, CURRENT_TIMESTAMP, @executor, NULL, NULL, NULL)

END
ELSE
BEGIN
	SET @outmsg = @outmsg + 'Il record in dbaccess esisteva già; ';
END


IF NOT EXISTS (select * from [dbo].[dbuser] where [login] = @safe_login)
BEGIN
	INSERT INTO [dbo].[dbuser] ([forename],[initpwd] ,[login],[lt],[lu],[start],[stop],[surname]) 
	VALUES (@forename , null, @safe_login, CURRENT_TIMESTAMP, @executor ,CURRENT_TIMESTAMP, null, @surname)
END
ELSE
BEGIN
	SET @outmsg = @outmsg + 'Il record in dbuser esisteva già; ';
END

-----------------Utente

--utente
IF NOT EXISTS (select * from [dbo].[customuser] where [username] = @safe_login)
BEGIN
	INSERT [dbo].[customuser] ([idcustomuser], [ct], [cu], [lastmodtimestamp], [lastmoduser], [lt], [lu], [username]) 
	VALUES (@safe_login, CURRENT_TIMESTAMP, @executor, NULL, NULL, CURRENT_TIMESTAMP, @executor, @safe_login)
END
ELSE
BEGIN
	SET @outmsg = @outmsg + 'Il record in customuser esisteva già; ';
END

--utente virtuale (serve a collegare un utente all'utente effettivo a cui sono agganciati i diritti)
IF NOT EXISTS (select * from [dbo].[virtualuser] where [username] = @safe_login)
BEGIN

	DECLARE @idvirtualuser int = (SELECT isnull(MAX([idvirtualuser]),0) + 1 FROM [dbo].[virtualuser]);

	INSERT [dbo].[virtualuser] ([idvirtualuser], [birthdate], [cf], [forename], [codicedipartimento], [lt], [lu], [surname], [sys_user], [userkind], [username], [email]) 
	VALUES (@idvirtualuser, NULL, @cf, @forename, @dipartimento, NULL, NULL, @surname, @safe_login, 3, @safe_login, @email);

END
ELSE
BEGIN
	SET @outmsg = @outmsg + 'Il record in virtualuser esisteva già; ';
END


--associo l'utente al gruppo principale di diritti
IF NOT EXISTS (select * from [dbo].[customusergroup] where [idcustomuser] = @safe_login)
BEGIN
	INSERT INTO [dbo].[customusergroup] ([idcustomgroup], [idcustomuser], [ct], [cu], [lastmodtimestamp], [lastmoduser], [lt], [lu])
	VALUES ('ORGANIGRAMMA', @safe_login, CURRENT_TIMESTAMP, @executor, CURRENT_TIMESTAMP, @executor, CURRENT_TIMESTAMP, @executor);
END
ELSE
BEGIN
	SET @outmsg = @outmsg + 'Il record in customusergroup esisteva già; ';
END

-----------------Utente organigramma e variabili di sicurezza

IF (@codeflowchart IS NOT NULL AND @esercizio IS NOT NULL)
BEGIN 
	
	DECLARE @idflowchart varchar(34) = (SELECT idflowchart FROM [amministrazione].[flowchart] where codeflowchart = @codeflowchart and ayear = @esercizio);

	--associo l'utente alla voce dell'organigramma
	IF NOT EXISTS (select * from [amministrazione].[flowchartuser] where [idcustomuser] = @safe_login and [idflowchart] = @idflowchart)
	BEGIN
		
		INSERT [amministrazione].[flowchartuser] ([idflowchart], [ndetail], [idcustomuser], [ct], [cu], [flagdefault], [lt], [lu], [start], [stop], [all_sorkind01], [all_sorkind02], [all_sorkind03], [all_sorkind04], [all_sorkind05], [idsor01], [idsor02], [idsor03], [idsor04], [idsor05], [sorkind01_withchilds], [sorkind02_withchilds], [sorkind03_withchilds], [sorkind04_withchilds], [sorkind05_withchilds], [title]) 
		VALUES (@idflowchart, 1, @safe_login, CURRENT_TIMESTAMP, @executor, N'N', CURRENT_TIMESTAMP, @executor, CAST(N'1900-01-01' AS Date), NULL, N'N', N'S', N'S', N'S', N'S', NULL, NULL, NULL, NULL, NULL, N'N', N'S', N'S', N'S', N'S', NULL);
	END
	ELSE
	BEGIN
		SET @outmsg = @outmsg + 'Il record in flowchartuser esisteva già; ';
	END



	--associo l'utente alle variabili di sicurezza che sono associate alla sua voce dell'organigramma
	DECLARE @uecount int = (select count([variablename]) from [amministrazione].[userenvironment] where [idcustomuser] = @safe_login);

	INSERT INTO [amministrazione].[userenvironment] ([idcustomuser], [variablename], [flagadmin], [kind], [lt], [lu], [value]) 
	SELECT  @safe_login, (	select top 1 sv.variablename 
							from [restrictedfunction] sv
							where sv.idrestrictedfunction = fcrf.idrestrictedfunction)
			, N'N', N'S', CURRENT_TIMESTAMP, @executor, N'compute_set' 
	FROM amministrazione.[FlowChartrestrictedfunction] fcrf
	WHERE idflowchart =  @idflowchart AND NOT EXISTS(select * 
													from [amministrazione].[userenvironment] ue
													where ue.[idcustomuser] =  @safe_login AND ue.variablename = (	select top 1 sv2.variablename 
																											from [restrictedfunction] sv2
																											where sv2.idrestrictedfunction = fcrf.idrestrictedfunction));
	
	SET @outmsg = @outmsg + 'Inserite in userenvironment ' + cast( (select  count([variablename]) - @uecount from [amministrazione].[userenvironment] where [idcustomuser] = @safe_login) as nvarchar(10)) + ' variabili; '
END

-------------------anagrafica dell'utente

	DECLARE @idreg int = (SELECT isnull(MAX([idreg]),0) + 1 FROM [dbo].[registry]);

IF NOT EXISTS (select * from registry where cf = @cf)
BEGIN

	DECLARE @datanascita date = (SELECT cast('19' + SUBSTRING(@cf,7,2) +
		CASE
		WHEN cast (SUBSTRING(@cf,9,1) as CHAR ) = 'A' THEN '01'
		WHEN cast (SUBSTRING(@cf,9,1) as CHAR ) = 'E' THEN '05'
		WHEN cast (SUBSTRING(@cf,9,1) as CHAR ) = 'P' THEN '09'
		WHEN cast (SUBSTRING(@cf,9,1) as CHAR ) = 'B' THEN '02'
		WHEN cast (SUBSTRING(@cf,9,1) as CHAR ) = 'H' THEN '06'
		WHEN cast (SUBSTRING(@cf,9,1) as CHAR ) = 'R' THEN '10'
		WHEN cast (SUBSTRING(@cf,9,1) as CHAR ) = 'C' THEN '03'
		WHEN cast (SUBSTRING(@cf,9,1) as CHAR ) = 'L' THEN '07'
		WHEN cast (SUBSTRING(@cf,9,1) as CHAR ) = 'S' THEN '11'
		WHEN cast (SUBSTRING(@cf,9,1) as CHAR ) = 'D' THEN '04'
		WHEN cast (SUBSTRING(@cf,9,1) as CHAR ) = 'M' THEN '08'
		WHEN cast (SUBSTRING(@cf,9,1) as CHAR ) = 'T' THEN '12'
		END +
		CASE 
		WHEN LEN(cast(CASE 
						WHEN cast(replace(replace(SUBSTRING (@cf,10,2),'O','0') ,'I','1') as int) < 35
						THEN cast(replace(replace(SUBSTRING (@cf,10,2),'O','0') ,'I','1') as int)
						ELSE (cast(replace(replace(SUBSTRING (@cf,10,2),'O','0') ,'I','1') as int) -40) END as nvarchar(255))) =1
		THEN '0' + cast(CASE 
						WHEN cast(replace(replace(SUBSTRING (@cf,10,2),'O','0') ,'I','1') as int) < 35
						THEN cast(replace(replace(SUBSTRING (@cf,10,2),'O','0') ,'I','1') as int)
						ELSE (cast(replace(replace(SUBSTRING (@cf,10,2),'O','0') ,'I','1') as int) -40) END as nvarchar(255))
		ELSE cast(CASE 
					WHEN cast(replace(replace(SUBSTRING (@cf,10,2),'O','0') ,'I','1') as int) < 35
					THEN cast(replace(replace(SUBSTRING (@cf,10,2),'O','0') ,'I','1') as int)
					ELSE (cast(replace(replace(SUBSTRING (@cf,10,2),'O','0') ,'I','1') as int) -40) END as nvarchar(255))
					END as date));

	DECLARE @comunenascita int = (select idcity FROM [dbo].[geo_city_agency] where [value] = SUBSTRING (@cf,12,4) );

	DECLARE @gender char(1) = (CASE WHEN CAST(SUBSTRING (@cf,10,2) as int) > 40 THEN 'F' ELSE 'M' END);

	--anagrafica generale
	INSERT [dbo].[registry] ([idreg], [active], [annotation], [badgecode], [birthdate], [cf], [ct], [cu], [extmatricula], [foreigncf], [forename], [gender], [idcategory], [idcentralizedcategory], [idcity], [idmaritalstatus], [idnation], [idregistryclass], [idtitle], [location], [lt], [lu], [maritalsurname], [p_iva], [rtf], [surname], [title], [txt], [residence], [idregistrykind], [authorization_free], [multi_cf], [toredirect], [idaccmotivecredit], [idaccmotivedebit], [ccp], [flagbankitaliaproceeds], [idexternal], [ipa_fe], [flag_pa], [sdi_defrifamm], [sdi_norifamm], [email_fe], [pec_fe], [extension], [ipa_perlapa]) 
	VALUES (@idreg, N'S', NULL, NULL, @datanascita, @cf, CURRENT_TIMESTAMP, @executor, @matricola, NULL, @forename, @gender, NULL, NULL, @comunenascita, NULL, NULL, N'22', NULL, NULL, CURRENT_TIMESTAMP, @executor, NULL, NULL, NULL, @surname, @surname + ' ' + @forename, NULL, 1, 5, N'N', N'N', NULL, NULL, NULL, NULL, N'N', NULL, NULL, N'N', NULL, N'N', @email, NULL, @usertype, NULL)

END
ELSE
BEGIN
	SET @outmsg = @outmsg + 'Il record in registry esisteva già; ';
	SET @idreg = (select top(1) idreg from registry where cf = @cf)
END 



	--credenziali web e email
IF NOT EXISTS (select * from [registryreference] where [userweb] = @safe_login AND idreg = @idreg)
BEGIN
	
	DECLARE @idregistryreference int = (SELECT isnull(MAX([idregistryreference]),0) + 1 FROM [dbo].[registryreference]);

	INSERT [dbo].[registryreference] ([referencename], [idreg], [ct], [cu], [email], [faxnumber], [flagdefault], [lt], [lu], [mobilenumber], [passwordweb], [phonenumber], [registryreferencerole], [rtf], [txt], [userweb], [idregistryreference], [msnnumber], [skypenumber], [activeweb], [iterweb], [saltweb], [pec], [website]) VALUES (N'Residenza', @idreg, CURRENT_TIMESTAMP, @executor, @email, NULL, N'S', CURRENT_TIMESTAMP, @executor, NULL, @passwordweb, NULL, NULL, NULL, NULL, @safe_login, @idregistryreference, NULL, NULL, NULL, @iterweb, @saltweb, NULL, NULL)

END
ELSE
BEGIN
	SET @outmsg = @outmsg + 'Il record in registryreference esisteva già; ';
END 

IF(@usertype = 'studenti')
BEGIN

	IF NOT EXISTS (select * from [registry_studenti] where idreg = @idreg)
	BEGIN

		INSERT INTO [dbo].[registry_studenti]
				   ([idreg]
				   ,[authinps]
				   ,[ct]
				   ,[cu]
				   ,[idstuddirittokind]
				   ,[idstudprenotkind]
				   ,[lt]
				   ,[lu])
			 VALUES
				   (@idreg
				   ,'N'
				   ,CURRENT_TIMESTAMP
				   ,@executor
				   ,null
				   ,0
				   ,CURRENT_TIMESTAMP
				   ,@executor)
	END
	ELSE
	BEGIN
		SET @outmsg = @outmsg + 'Il record in registry_studenti esisteva già; ';
	END 

END

IF(@usertype = 'docenti')
BEGIN

	IF NOT EXISTS (select * from [registry_docenti] where idreg = @idreg)
	BEGIN
		INSERT INTO [dbo].[registry_docenti]
				   ([idreg]
				   ,[ct]
				   ,[cu]
				   ,[cv]
				   ,[idclassconsorsuale]
				   ,[idcontrattokind]
				   ,[idfonteindicebibliometrico]
				   ,[idreg_istituti]
				   ,[idsasd]
				   ,[idstruttura]
				   ,[indicebibliometrico]
				   ,[lt]
				   ,[lu]
				   ,[matricola]
				   ,[ricevimento]
				   ,[soggiorno])
			 VALUES
				   (@idreg
				   ,CURRENT_TIMESTAMP
				   ,@executor
				   ,''
				   ,null
				   ,null
				   ,null
				   ,null
				   ,null
				   ,null
				   ,null
				   ,CURRENT_TIMESTAMP
				   ,@executor
				   ,@matricola
				   ,''
				   ,'')
	END
	ELSE
	BEGIN
		SET @outmsg = @outmsg + 'Il record in registry_docenti esisteva già; ';
	END 

END

IF(@usertype = 'amministrativi')
BEGIN

	IF NOT EXISTS (select * from [registry_amministrativi] where idreg = @idreg)
	BEGIN
		INSERT INTO [dbo].[registry_amministrativi]
				   ([idreg]
				   ,[ct]
				   ,[cu]
				   ,[cv]
				   ,[idcontrattokind]
				   ,[lt]
				   ,[lu])
			 VALUES
				   (@idreg
				   ,CURRENT_TIMESTAMP
				   ,@executor
				   ,''
				   ,null
				   ,CURRENT_TIMESTAMP
				   ,@executor)
	END
	ELSE
	BEGIN
		SET @outmsg = @outmsg + 'Il record in registry_amministrativi esisteva già; ';
	END 
END

------------------
select @outmsg;
------------------

END
GO


--Query di verifica
--declare @user varchar(50) = 'riccardotest'
----select * from dbo.customgroupoperation  where allowcondition like '%mw_%' or allowcondition like '%mr_%'
--select 'dbo.customusergroup' as tablename,* from dbo.customusergroup where [idcustomuser]= @user --è ORGANIGRAMMA per tutti
--select 'amministrazione.userenvironment' as tablename,* from amministrazione.userenvironment where [idcustomuser]= @user order by variablename --variabili e utenti senza invìfluenza dell'esercizio
--select 'amministrazione.FlowChartrestrictedfunction ' as tablename,* from amministrazione.FlowChartrestrictedfunction where idflowchart = (select top 1 idflowchart from amministrazione.FlowChartUser where [idcustomuser]= @user)--spunte tra in organigramma sulle singole varaibili
--select 'WebUser' as tablename,* from [WebUser] where [username]= @user
--select 'amministrazione.flowchart' as tablename,* from amministrazione.flowchart where idflowchart in (select idflowchart from amministrazione.FlowChartUser where [idcustomuser]= @user)
--select 'amministrazione.FlowChartUser' as tablename,* from amministrazione.FlowChartUser where [idcustomuser]= @user
--select 'customuser' as tablename,* from [customuser] where [username]= @user
--select 'dbuser' as tablename,* from dbo.[dbuser] where [login]= @user
--select 'dbaccess' as tablename,* from [dbaccess] where [login]= @user
--select 'virtualuser' as tablename,* from virtualuser where username = @user or sys_user = @user
--select 'registryreference' as tablename,* from registryreference where userweb = @user
--select 'registry' as tablename,* from registry where idreg = (select top 1 idreg from registryreference where userweb = @user)
--select 'registry_docenti' as tablename,* from registry_docenti where idreg = (select top 1 idreg from registryreference where userweb = @user)
--select 'registry_studenti' as tablename,* from registry_studenti where idreg = (select top 1 idreg from registryreference where userweb = @user)
--select 'registry_amministrativi' as tablename,* from registry_amministrativi where idreg = (select top 1 idreg from registryreference where userweb = @user)


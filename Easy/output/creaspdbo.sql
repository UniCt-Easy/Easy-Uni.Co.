if object_id('[trigger_i_inventorytree]') is not null
	drop TRIGGER [trigger_i_inventorytree]
go


CREATE          TRIGGER [DBO].[trigger_i_inventorytree] ON [inventorytree] FOR INSERT
AS BEGIN
IF (@@ROWCOUNT = 0) RETURN
DECLARE @nrowinserted int
SET @nrowinserted = ISNULL((SELECT COUNT(*) FROM inserted),0)
IF (@nrowinserted > 1)
BEGIN
	CREATE TABLE #inventorytree (idinv int, nlevel tinyint)
	
	INSERT INTO #inventorytree (idinv, nlevel)
	SELECT idinv, nlevel FROM inserted
	
	INSERT INTO inventorytreelink (idchild, nlevel, idparent)
	SELECT idinv, nlevel, idinv
	FROM #inventorytree
	
	WHILE(@@ROWCOUNT > 0)
	BEGIN
		INSERT INTO inventorytreelink (idchild, nlevel, idparent)
		SELECT IL.idchild, (I.nlevel - 1), I.paridinv
		FROM inventorytreelink IL
		JOIN inventorytree I
		ON IL.idparent = I.idinv
		WHERE IL.nlevel > 1
		AND NOT EXISTS(SELECT * FROM inventorytreelink IL2 WHERE IL2.idchild = IL.idchild AND IL2.nlevel = (IL.nlevel - 1))
		AND EXISTS(SELECT * FROM #inventorytree WHERE #inventorytree.idinv = IL.idchild)
	END
END
ELSE
BEGIN
	DECLARE @idinv int
	DECLARE @nlevel tinyint
	DECLARE @paridinv int
	SELECT @idinv = idinv, @nlevel = nlevel, @paridinv = paridinv FROM inserted
	INSERT INTO inventorytreelink (idchild, nlevel, idparent)
	VALUES(@idinv, @nlevel, @idinv)
	DECLARE @currlevel tinyint
	SET @currlevel = @nlevel - 1
	DECLARE @currpar int
	SET @currpar = @paridinv
	WHILE (@currlevel >= 1)
	BEGIN
		INSERT INTO inventorytreelink (idchild, nlevel, idparent)
		VALUES(@idinv, @currlevel, @currpar)
		SET @currpar = (SELECT paridinv FROM inventorytree WHERE idinv = @currpar)
		SET @currlevel = @currlevel - 1
	END
END
END


GO

print '[DBO].[trigger_i_inventorytree] OK'

GO
if object_id('sp_upgraddiagrams') is not null
	drop PROCEDURE sp_upgraddiagrams
go

	CREATE     PROCEDURE [DBO].sp_upgraddiagrams
	AS
	BEGIN
		IF OBJECT_ID(N'dbo.sysdiagrams') IS NOT NULL
			return 0;
	
		CREATE TABLE dbo.sysdiagrams
		(
			name sysname NOT NULL,
			principal_id int NOT NULL,	-- we may change it to varbinary(85)
			diagram_id int PRIMARY KEY IDENTITY,
			version int,
	
			definition varbinary(max)
			CONSTRAINT UK_principal_name UNIQUE
			(
				principal_id,
				name
			)
		);


		/* Add this if we need to have some form of extended properties for diagrams */
		/*
		IF OBJECT_ID(N'dbo.sysdiagram_properties') IS NULL
		BEGIN
			CREATE TABLE dbo.sysdiagram_properties
			(
				diagram_id int,
				name sysname,
				value varbinary(max) NOT NULL
			)
		END
		*/

		IF OBJECT_ID(N'dbo.dtproperties') IS NOT NULL
		begin
			insert into dbo.sysdiagrams
			(
				[name],
				[principal_id],
				[version],
				[definition]
			)
			select	 
				convert(sysname, dgnm.[uvalue]),
				DATABASE_PRINCIPAL_ID(N'dbo'),			-- will change to the sid of sa
				0,							-- zero for old format, dgdef.[version],
				dgdef.[lvalue]
			from dbo.[dtproperties] dgnm
				inner join dbo.[dtproperties] dggd on dggd.[property] = 'DtgSchemaGUID' and dggd.[objectid] = dgnm.[objectid]	
				inner join dbo.[dtproperties] dgdef on dgdef.[property] = 'DtgSchemaDATA' and dgdef.[objectid] = dgnm.[objectid]
				
			where dgnm.[property] = 'DtgSchemaNAME' and dggd.[uvalue] like N'_EA3E6268-D998-11CE-9454-00AA00A3F36E_' 
			return 2;
		end
		return 1;
	END
	
GO

print '[DBO].sp_upgraddiagrams OK'

GO
if object_id('sp_helpdiagrams') is not null
	drop PROCEDURE sp_helpdiagrams
go

	CREATE     PROCEDURE [DBO].sp_helpdiagrams
	(
		@diagramname sysname = NULL,
		@owner_id int = NULL
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		DECLARE @user sysname
		DECLARE @dboLogin bit
		EXECUTE AS CALLER;
			SET @user = USER_NAME();
			SET @dboLogin = CONVERT(bit,IS_MEMBER('db_owner'));
		REVERT;
		SELECT
			[Database] = DB_NAME(),
			[Name] = name,
			[ID] = diagram_id,
			[Owner] = USER_NAME(principal_id),
			[OwnerID] = principal_id
		FROM
			sysdiagrams
		WHERE
			(@dboLogin = 1 OR USER_NAME(principal_id) = @user) AND
			(@diagramname IS NULL OR name = @diagramname) AND
			(@owner_id IS NULL OR principal_id = @owner_id)
		ORDER BY
			4, 5, 1
	END
	
GO

print '[DBO].sp_helpdiagrams OK'

GO
if object_id('sp_helpdiagramdefinition') is not null
	drop PROCEDURE sp_helpdiagramdefinition
go

	CREATE     PROCEDURE [DBO].sp_helpdiagramdefinition
	(
		@diagramname 	sysname,
		@owner_id	int	= null 		
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		set nocount on

		declare @theId 		int
		declare @IsDbo 		int
		declare @DiagId		int
		declare @UIDFound	int
	
		if(@diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner');
		if(@owner_id is null)
			select @owner_id = @theId;
		revert; 
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname;
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId ))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end

		select version, definition FROM dbo.sysdiagrams where diagram_id = @DiagId ; 
		return 0
	END
	
GO

print '[DBO].sp_helpdiagramdefinition OK'

GO
if object_id('sp_creatediagram') is not null
	drop PROCEDURE sp_creatediagram
go

	CREATE     PROCEDURE [DBO].sp_creatediagram
	(
		@diagramname 	sysname,
		@owner_id		int	= null, 	
		@version 		int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId int
		declare @retval int
		declare @IsDbo	int
		declare @userName sysname
		if(@version is null or @diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID(); 
		select @IsDbo = IS_MEMBER(N'db_owner');
		revert; 
		
		if @owner_id is null
		begin
			select @owner_id = @theId;
		end
		else
		begin
			if @theId <> @owner_id
			begin
				if @IsDbo = 0
				begin
					RAISERROR (N'E_INVALIDARG', 16, 1);
					return -1
				end
				select @theId = @owner_id
			end
		end
		-- next 2 line only for test, will be removed after define name unique
		if EXISTS(select diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @diagramname)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end
	
		insert into dbo.sysdiagrams(name, principal_id , version, definition)
				VALUES(@diagramname, @theId, @version, @definition) ;
		
		select @retval = @@IDENTITY 
		return @retval
	END
	
GO

print '[DBO].sp_creatediagram OK'

GO
if object_id('sp_renamediagram') is not null
	drop PROCEDURE sp_renamediagram
go

	CREATE     PROCEDURE [DBO].sp_renamediagram
	(
		@diagramname 		sysname,
		@owner_id		int	= null,
		@new_diagramname	sysname
	
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @DiagIdTarg		int
		declare @u_name			sysname
		if((@diagramname is null) or (@new_diagramname is null))
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT;
	
		select @u_name = USER_NAME(@owner_id)
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		-- if((@u_name is not null) and (@new_diagramname = @diagramname))	-- nothing will change
		--	return 0;
	
		if(@u_name is null)
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @new_diagramname
		else
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @owner_id and name = @new_diagramname
	
		if((@DiagIdTarg is not null) and  @DiagId <> @DiagIdTarg)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end		
	
		if(@u_name is null)
			update dbo.sysdiagrams set [name] = @new_diagramname, principal_id = @theId where diagram_id = @DiagId
		else
			update dbo.sysdiagrams set [name] = @new_diagramname where diagram_id = @DiagId
		return 0
	END
	
GO

print '[DBO].sp_renamediagram OK'

GO
if object_id('sp_alterdiagram') is not null
	drop PROCEDURE sp_alterdiagram
go

	CREATE     PROCEDURE [DBO].sp_alterdiagram
	(
		@diagramname 	sysname,
		@owner_id	int	= null,
		@version 	int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId 			int
		declare @retval 		int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @ShouldChangeUID	int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid ARG', 16, 1)
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();	 
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		revert;
	
		select @ShouldChangeUID = 0
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		
		if(@DiagId IS NULL or (@IsDbo = 0 and @theId <> @UIDFound))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end
	
		if(@IsDbo <> 0)
		begin
			if(@UIDFound is null or USER_NAME(@UIDFound) is null) -- invalid principal_id
			begin
				select @ShouldChangeUID = 1 ;
			end
		end

		-- update dds data			
		update dbo.sysdiagrams set definition = @definition where diagram_id = @DiagId ;

		-- change owner
		if(@ShouldChangeUID = 1)
			update dbo.sysdiagrams set principal_id = @theId where diagram_id = @DiagId ;

		-- update dds version
		if(@version is not null)
			update dbo.sysdiagrams set version = @version where diagram_id = @DiagId ;

		return 0
	END
	
GO

print '[DBO].sp_alterdiagram OK'

GO
if object_id('sp_dropdiagram') is not null
	drop PROCEDURE sp_dropdiagram
go

	CREATE     PROCEDURE [DBO].sp_dropdiagram
	(
		@diagramname 	sysname,
		@owner_id	int	= null
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT; 
		
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		delete from dbo.sysdiagrams where diagram_id = @DiagId;
	
		return 0;
	END
	
GO

print '[DBO].sp_dropdiagram OK'

GO
if object_id('fn_diagramobjects') is not null
	drop FUNCTION fn_diagramobjects
go

	CREATE     FUNCTION [DBO].fn_diagramobjects() 
	RETURNS int
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		declare @id_upgraddiagrams		int
		declare @id_sysdiagrams			int
		declare @id_helpdiagrams		int
		declare @id_helpdiagramdefinition	int
		declare @id_creatediagram	int
		declare @id_renamediagram	int
		declare @id_alterdiagram 	int 
		declare @id_dropdiagram		int
		declare @InstalledObjects	int

		select @InstalledObjects = 0

		select 	@id_upgraddiagrams = object_id(N'dbo.sp_upgraddiagrams'),
			@id_sysdiagrams = object_id(N'dbo.sysdiagrams'),
			@id_helpdiagrams = object_id(N'dbo.sp_helpdiagrams'),
			@id_helpdiagramdefinition = object_id(N'dbo.sp_helpdiagramdefinition'),
			@id_creatediagram = object_id(N'dbo.sp_creatediagram'),
			@id_renamediagram = object_id(N'dbo.sp_renamediagram'),
			@id_alterdiagram = object_id(N'dbo.sp_alterdiagram'), 
			@id_dropdiagram = object_id(N'dbo.sp_dropdiagram')

		if @id_upgraddiagrams is not null
			select @InstalledObjects = @InstalledObjects + 1
		if @id_sysdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 2
		if @id_helpdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 4
		if @id_helpdiagramdefinition is not null
			select @InstalledObjects = @InstalledObjects + 8
		if @id_creatediagram is not null
			select @InstalledObjects = @InstalledObjects + 16
		if @id_renamediagram is not null
			select @InstalledObjects = @InstalledObjects + 32
		if @id_alterdiagram  is not null
			select @InstalledObjects = @InstalledObjects + 64
		if @id_dropdiagram is not null
			select @InstalledObjects = @InstalledObjects + 128
		
		return @InstalledObjects 
	END
	
GO

print '[DBO].fn_diagramobjects OK'

GO
if object_id('[trigger_d_inventorytree]') is not null
	drop TRIGGER [trigger_d_inventorytree]
go


CREATE                   TRIGGER [DBO].[trigger_d_inventorytree] ON [inventorytree] FOR DELETE
AS BEGIN
IF @@ROWCOUNT > 0
BEGIN
	CREATE TABLE #inventorytree (idinv int)
	INSERT INTO #inventorytree (idinv)
	SELECT idinv FROM deleted
	DELETE FROM inventorytreelink
	WHERE idchild IN (SELECT idinv FROM #inventorytree)
END
END


GO

print '[DBO].[trigger_d_inventorytree] OK'

GO
if object_id('[trigger_u_inventorytree]') is not null
	drop TRIGGER [trigger_u_inventorytree]
go


CREATE                  TRIGGER [DBO].[trigger_u_inventorytree] ON inventorytree FOR UPDATE
AS BEGIN
DECLARE @idinv int
DECLARE @nlevel tinyint
IF UPDATE(paridinv)
BEGIN
	DECLARE @newidparent int
	SELECT @idinv = idinv, @newidparent = paridinv, @nlevel = nlevel FROM inserted
	
	IF (@newidparent IS NULL) RETURN
	CREATE TABLE #inventorytreelink (idchild int)
	
	INSERT INTO #inventorytreelink
	SELECT idchild
	FROM inventorytreelink
	WHERE inventorytreelink.idparent = @idinv
	
	UPDATE inventorytreelink
	SET idparent = (SELECT idparent FROM inventorytreelink EL2 WHERE EL2.idchild = @newidparent AND EL2.nlevel = inventorytreelink.nlevel)
	FROM #inventorytreelink T
	WHERE inventorytreelink.idchild = T.idchild
	AND nlevel < @nlevel
END
END
SET QUOTED_IDENTIFIER OFF


GO

print '[DBO].[trigger_u_inventorytree] OK'

GO
if object_id('GetImponibileNear') is not null
	drop FUNCTION GetImponibileNear
go


CREATE                      FUNCTION [DBO].GetImponibileNear(@taxable_test decimal(19,2), @taxable decimal(19,2), @number decimal(19,2), @discount decimal(19,6), @exchangerate decimal(19,6))
RETURNS decimal (19,2)
AS
BEGIN
declare @TotaleImponibile decimal(19,2)
--set @TotaleImponibile  = round((@taxable * @number * (1-@discount)* @exchangerate),2)
set @TotaleImponibile = ROUND(@taxable * @number *  CONVERT(decimal(19,6),@exchangerate)*(1 - CONVERT(decimal(19,6),ISNULL(@discount, 0.0))),2) 
declare @imponibilecomplementare decimal (19,2)
set @imponibilecomplementare = @taxable - @taxable_test;
declare @totale1  decimal (19,2)
set @totale1 = ROUND(@taxable_test * @number *  CONVERT(decimal(19,6),@exchangerate) * (1 - CONVERT(decimal(19,6),ISNULL(@discount, 0.0))),2) 
declare @totale2  decimal (19,2)
set @totale2 = ROUND(@imponibilecomplementare * @number *  CONVERT(decimal(19,6),@exchangerate) * (1 - CONVERT(decimal(19,6),ISNULL(@discount, 0.0))),2) 
if (@totale1+@totale2 = @TotaleImponibile) 
	return @taxable_test
declare @cent decimal(19,2)
set @cent = 0.01
while(@cent < 0.1)
begin 
	declare @imponibile_try decimal (19,2)
   	set @imponibile_try= @taxable_test + @cent;
	
	declare @imponibilecomplementare_try decimal(19,2)
	set @imponibilecomplementare_try = @taxable - @imponibile_try;
	
	set @totale1 = ROUND(@imponibile_try * @number *  CONVERT(decimal(19,6),@exchangerate)*(1 - CONVERT(decimal(19,6),ISNULL(@discount, 0.0))),2) 
	set @totale2 = ROUND(@imponibilecomplementare_try * @number *  CONVERT(decimal(19,6),@exchangerate)*(1 - CONVERT(decimal(19,6),ISNULL(@discount, 0.0))),2) 
	IF (@totale1 + @totale2 = @TotaleImponibile)
	begin
		 return @imponibile_try
	end	
	
	set @imponibile_try = @taxable_test - @cent
	set @imponibilecomplementare_try = @taxable - @imponibile_try
	set @totale1 = ROUND(@imponibile_try * @number *  CONVERT(decimal(19,6),@exchangerate)*(1 - CONVERT(decimal(19,6),ISNULL(@discount, 0.0))),2) 
    	set @totale2 = ROUND(@imponibilecomplementare_try * @number *  CONVERT(decimal(19,6),@exchangerate)*(1 - CONVERT(decimal(19,6),ISNULL(@discount, 0.0))),2) 
	IF (@totale1 + @totale2 = @TotaleImponibile) 
	begin
	     return @imponibile_try;
	end
	set @cent= @cent + 0.01;
end
return @taxable_test;
END


GO

print '[DBO].GetImponibileNear OK'

GO
if object_id('[getdata]') is not null
	drop FUNCTION [getdata]
go

CREATE    FUNCTION [DBO].[getdata](@adate datetime)
RETURNS VARCHAR (8)
AS
BEGIN
IF @adate IS NULL RETURN SPACE(8)
--restituisce una stringa di 8 caratteri nella forma GGMMAAAA
--print [DBO].InsertDateAsString(GetDate())
declare @stringDate varchar(8)
set @stringDate = 
	SUBSTRING('00',1,2 - LEN( CONVERT(varchar(2),DATEPART(DAY,@adate)))) +
	CONVERT(varchar(2),DATEPART(DAY,@adate)) +
	SUBSTRING('00',1,2 - LEN( CONVERT(varchar(2),DATEPART(MONTH,@adate)))) +
	CONVERT(varchar(2),DATEPART(MONTH,@adate)) +
	CONVERT (varchar(4), DATEPART(YEAR, @adate)) 
return @stringDate;
END

GO

print '[DBO].[getdata] OK'

GO
if object_id('[getint]') is not null
	drop FUNCTION [getint]
go

CREATE    FUNCTION [DBO].[getint](@number int, @len int)
RETURNS varchar(100)
AS
BEGIN
IF @len    IS NULL RETURN ''
IF @number IS NULL RETURN SPACE(@len)
--restituisce una stringa di @len caratteri
--print [DBO].InsertIntAsString(1980989,10)
DECLARE @stringNumber varchar(100)
IF (LEN(@number)<= @len)  
	SET @stringNumber = SUBSTRING(REPLICATE('0',@len), 1, @len - LEN(@number)) + CONVERT(varchar,@number)
ELSE 
	SET @stringNumber = REPLICATE('0',@len)
return @stringNumber
END

GO

print '[DBO].[getint] OK'

GO
if object_id('[getstringformatted_r]') is not null
	drop FUNCTION [getstringformatted_r]
go

CREATE    FUNCTION [DBO].[getstringformatted_r](@string varchar(8000), @len int)
RETURNS varchar(8000)
AS
BEGIN
IF ISNULL(@len,0) = 0 RETURN REPLICATE(' ',1)
IF @string IS NULL RETURN   REPLICATE(' ',@len)
--restituisce una stringa di @len caratteri
--print [DBO].InsertStringAsFormattedString('aa',2,'*')
DECLARE @stringFormatted varchar(8000)
DECLARE @trimString varchar(8000)
SET @trimString = rtrim(ltrim(@string))
IF (LEN(@trimString)<= @len)  
	SET @stringFormatted = @trimString + SUBSTRING(REPLICATE(' ',@len), 1, @len - LEN(@trimString))
ELSE 
	SET @stringFormatted =  REPLICATE(' ',@len)
return @stringFormatted
END


GO

print '[DBO].[getstringformatted_r] OK'

GO
if object_id('GetDecimal_19_2') is not null
	drop FUNCTION GetDecimal_19_2
go



CREATE       FUNCTION [DBO].GetDecimal_19_2(@number decimal(19,2), @len int)
RETURNS varchar(150)
AS
BEGIN
IF ISNULL(@len,0) = 0 RETURN '0'
IF @number IS NULL RETURN REPLICATE('0',@len)
--restituisce una stringa di @len caratteri
--print [DBO].InsertDecimalAsString(1.009,19,'*')
declare @stringNumber varchar(150)
IF (LEN(@number)<= @len)  
BEGIN
	declare @parteintera  int
	declare @partedecimale decimal(19,2)
	set @parteintera = CAST (@number as int)
	set @partedecimale = CONVERT(decimal(19,2),@number) - CAST(@parteintera as decimal(19,2))
	set @stringNumber  = SUBSTRING(REPLICATE('0',@len), 1, @len - LEN(@number)) 
	+ 
	SUBSTRING(CONVERT(varchar(20),@parteintera) + '.' +
	SUBSTRING(CONVERT(varchar(20),@partedecimale),3,LEN(@partedecimale)),1,@len)
END
ELSE 
	SET @stringNumber = REPLICATE('0',@len)
return @stringNumber
END





GO

print '[DBO].GetDecimal_19_2 OK'

GO
if object_id('GetDecimal_19_4') is not null
	drop FUNCTION GetDecimal_19_4
go



CREATE       FUNCTION [DBO].GetDecimal_19_4(@number decimal(19,4), @len int)
RETURNS varchar(150)
AS
BEGIN
IF ISNULL(@len,0) = 0 RETURN '0'
IF @number IS NULL RETURN REPLICATE('0',@len)
--restituisce una stringa di @len caratteri
--print [DBO].InsertDecimalAsString(1.009,19,'*')
declare @stringNumber varchar(150)
IF (LEN(@number)<= @len)  
BEGIN
	declare @parteintera  int
	declare @partedecimale decimal(19,4)
	set @parteintera = CAST (@number as int)
	set @partedecimale = CONVERT(decimal(19,4),@number) - CAST(@parteintera as decimal(19,4))
	set @stringNumber  = SUBSTRING(REPLICATE('0',@len), 1, @len - LEN(@number)) 
	+ 
	SUBSTRING(CONVERT(varchar(20),@parteintera) + '.' +
	SUBSTRING(CONVERT(varchar(20),@partedecimale),3,LEN(@partedecimale)),1,@len)
END
ELSE 
	SET @stringNumber = REPLICATE('0',@len)
return @stringNumber
END






GO

print '[DBO].GetDecimal_19_4 OK'

GO
if object_id('GetDecimal_19_6') is not null
	drop FUNCTION GetDecimal_19_6
go



CREATE       FUNCTION [DBO].GetDecimal_19_6(@number decimal(19,6), @len int)
RETURNS varchar(150)
AS
BEGIN
IF ISNULL(@len,0) = 0 RETURN '0'
IF @number IS NULL RETURN REPLICATE('0',@len)
--restituisce una stringa di @len caratteri
--print [DBO].InsertDecimalAsString(1.009,19,'*')
declare @stringNumber varchar(150)
IF (LEN(@number)<= @len)  
BEGIN
	declare @parteintera  int
	declare @partedecimale decimal(19,6)
	set @parteintera = CAST (@number as int)
	set @partedecimale = CONVERT(decimal(19,6),@number) - CAST(@parteintera as decimal(19,6))
	set @stringNumber  = SUBSTRING(REPLICATE('0',@len), 1, @len - LEN(@number)) 
	+ 
	SUBSTRING(CONVERT(varchar(20),@parteintera) + '.' +
	SUBSTRING(CONVERT(varchar(20),@partedecimale),3,LEN(@partedecimale)),1,@len)
END
ELSE 
	SET @stringNumber = REPLICATE('0',@len)
return @stringNumber
END





GO

print '[DBO].GetDecimal_19_6 OK'

GO
if object_id('GetStringFormatted') is not null
	drop FUNCTION GetStringFormatted
go


CREATE       FUNCTION [DBO].GetStringFormatted(@string varchar(8000), @len int)
RETURNS varchar(8000)
AS
BEGIN
IF ISNULL(@len,0) = 0 RETURN SPACE(1)
IF @string IS NULL RETURN  SPACE(@len)
--restituisce una stringa di @len caratteri
--print [DBO].InsertStringAsFormattedString('aa',2,'*')
DECLARE @stringFormatted varchar(8000)
DECLARE @trimString varchar(8000)
SET @trimString = rtrim(ltrim(@string))
IF (LEN(@trimString)<= @len)  
	SET @stringFormatted = SUBSTRING(SPACE(@len), 1, @len - LEN(@trimString)) + @trimString
ELSE 
	SET @stringFormatted = SPACE(@len)
return @stringFormatted
END










GO

print '[DBO].GetStringFormatted OK'

GO
if object_id('[getsplittedstring]') is not null
	drop FUNCTION [getsplittedstring]
go

CREATE      FUNCTION [DBO].[getsplittedstring](@name varchar(100), @string varchar(100), @len int)
RETURNS varchar(100)
AS
BEGIN
IF ISNULL(@len,0) = 0 RETURN SPACE(1)
IF @string IS NULL RETURN  NULL
DECLARE @trimString varchar(8000)
DECLARE @stringFormatted varchar(8000)
SET @trimString = rtrim(ltrim(@string))
IF (LEN(@trimString)<= @len)  
	SET @stringFormatted = @name + @trimString + SUBSTRING(SPACE(@len), 1, @len - LEN(@trimString)) 
ELSE 
SET @stringFormatted = @name + SUBSTRING(@trimString,1,@len) +
	[dbo].GetSplittedString(@name,'+' + SUBSTRING(@trimString,@len + 1,LEN(@trimString)),@len)
return @stringFormatted
END

GO

print '[DBO].[getsplittedstring] OK'

GO
if object_id('getsignedint') is not null
	drop FUNCTION getsignedint
go


CREATE      FUNCTION [DBO].getsignedint(@number int, @len int)
RETURNS varchar(100)
AS
BEGIN
IF @len    IS NULL RETURN ' '
IF ISNULL(@number,0) = 0 RETURN SPACE(@len)
--restituisce una stringa di @len caratteri
DECLARE @stringNumber varchar(100)
IF (LEN(@number)<= @len)  
	IF  (@number > 0)
		SET @stringNumber = SUBSTRING(REPLICATE(' ',@len), 1, @len - LEN(@number)) +
							CONVERT(varchar,@number)
	ELSE
		SET @stringNumber = SUBSTRING(REPLICATE(' ',@len), 1, @len - 1 - LEN(@number)) +
							'-' + CONVERT(varchar,@number) 
ELSE 
	SET @stringNumber = REPLICATE(' ',@len)
return @stringNumber
END

GO

print '[DBO].getsignedint OK'

GO

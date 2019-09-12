-- Script che imposta il flag active a S nel caso sia NULL
UPDATE registryaddress 
SET active = 'S' WHERE active IS NULL
GO

UPDATE registrylegalstatus
SET active = 'S' WHERE active IS NULL
GO

UPDATE registrytaxablestatus
SET active = 'S' WHERE active IS NULL

GO

update finvar set official='S' ,nofficial=nvar

GO




UPDATE finsetup 
SET    flagcredit = 'S'
WHERE  flagcredit is NULL
AND    ayear <= 2006
AND    (
	(select count(*) from creditpart
	  where ycreditpart = finsetup.ayear) 
	+
	(select count(*) from finvar
	  where flagcredit = 'S'
	    AND yvar = finsetup.ayear)
	) >1

GO
UPDATE finsetup 
SET    flagcredit = 'N'
WHERE  flagcredit is NULL
AND    ayear <= 2006
AND    (
	(select count(*) from creditpart
	  where ycreditpart = finsetup.ayear) 
	+
	(select count(*) from finvar
	  where flagcredit = 'S'
	    AND yvar = finsetup.ayear)
	) = 0

GO

UPDATE finsetup 
SET    flagproceeds = 'S'
WHERE  flagproceeds is NULL
AND    ayear <= 2006
AND    (
	(select count(*) from proceedspart
	  where yproceedspart = finsetup.ayear) 
	+
	(select count(*) from finvar
	  where flagproceeds = 'S'
	    AND yvar = finsetup.ayear)
	) > 1

GO

UPDATE finsetup 
SET    flagproceeds = 'N'
WHERE  flagproceeds is NULL
AND    ayear <= 2006
AND    (
	(select count(*) from proceedspart
	  where yproceedspart = finsetup.ayear) 
	+
	(select count(*) from finvar
	  where flagproceeds = 'S'
	    AND yvar = finsetup.ayear)
	) = 0
GO

UPDATE finsetup 
SET    flagcredit  = (SELECT F1.flagcredit FROM finsetup F1 where F1.ayear = 2006)
WHERE  ayear = 2007
AND    flagcredit is Null

UPDATE finsetup 
SET    flagproceeds  = (SELECT F1.flagproceeds FROM finsetup F1 where F1.ayear = 2006)
WHERE  ayear = 2007
AND    flagproceeds is Null

GO


DECLARE @maxexpensephase char(1)
SELECT @maxexpensephase = MAX(nphase) FROM expensephase

UPDATE expense
SET idregistrypaymethod =
	(SELECT TOP 1 idregistrypaymethod FROM registrypaymethod rpm
	WHERE rpm.idreg = expense.idreg
	AND rpm.regmodcode = expense.regmodcode)
WHERE idregistrypaymethod IS NULL
AND nphase = @maxexpensephase




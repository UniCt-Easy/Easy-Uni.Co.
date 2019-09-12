UPDATE registry SET residence =  CASE  WHEN residence IN ('E','U','R','T', 'A') THEN 'I'  WHEN residence IN ('C','F') THEN residence  ELSE 'I' END
GO
DELETE FROM residence WHERE idresidence NOT IN ('I','C','F')
GO

-- GENERAZIONE DATI PER residence --
IF exists(SELECT * FROM [residence] WHERE idresidence = 'C')
UPDATE [residence] SET active = 'S',description = 'Residente in altri paesi dell''UE',lt = null,lu = 'Software and more' WHERE idresidence = 'C'
ELSE
INSERT INTO [residence] (idresidence,active,description,lt,lu) VALUES ('C','S','Residente in altri paesi dell''UE',null,'Software and more')
GO

IF exists(SELECT * FROM [residence] WHERE idresidence = 'F')
UPDATE [residence] SET active = 'S',description = 'Residente fuori dall''UE',lt = null,lu = 'Software and more' WHERE idresidence = 'F'
ELSE
INSERT INTO [residence] (idresidence,active,description,lt,lu) VALUES ('F','S','Residente fuori dall''UE',null,'Software and more')
GO

IF exists(SELECT * FROM [residence] WHERE idresidence = 'I')
UPDATE [residence] SET active = 'S',description = 'Residente in Italia',lt = null,lu = 'Software and more' WHERE idresidence = 'I'
ELSE
INSERT INTO [residence] (idresidence,active,description,lt,lu) VALUES ('I','S','Residente in Italia',null,'Software and more')
GO

-- FINE GENERAZIONE SCRIPT --



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


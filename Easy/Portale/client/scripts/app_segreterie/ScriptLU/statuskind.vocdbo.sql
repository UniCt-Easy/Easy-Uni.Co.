
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



-- GENERAZIONE DATI PER tabledescr --
IF exists(SELECT * FROM [tabledescr] WHERE tablename = 'statuskind')
UPDATE [tabledescr] SET description = 'VOCABOLARIO degli stati possibili di istanze, pratiche e delibere',idapplication = '2',isdbo = 'S',lt = {ts '2018-07-20 11:20:05.330'},lu = 'assistenza',title = 'Stati possibili di istanze, pratiche e delibere' WHERE tablename = 'statuskind'
ELSE
INSERT INTO [tabledescr] (tablename,description,idapplication,isdbo,lt,lu,title) VALUES ('statuskind','VOCABOLARIO degli stati possibili di istanze, pratiche e delibere','2','S',{ts '2018-07-20 11:20:05.330'},'assistenza','Stati possibili di istanze, pratiche e delibere')
GO

-- FINE GENERAZIONE SCRIPT --



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



-- GENERAZIONE DATI PER exportfunction --
IF exists(SELECT * FROM [exportfunction] WHERE procedurename = 'exp_contrattopassivo_pagato')
UPDATE [exportfunction] SET ct = {ts '2008-05-28 13:26:33.593'},cu = 'SA',description = 'Contratti passivi pagati e parzialmente pagati',fileformat = 'E',lt = {ts '2008-05-30 10:14:42.047'},lu = 'ASSISTENZA',modulename = 'Finanza',timeout = '1000' WHERE procedurename = 'exp_contrattopassivo_pagato'
ELSE
INSERT INTO [exportfunction] (procedurename,ct,cu,description,fileformat,lt,lu,modulename,timeout) VALUES ('exp_contrattopassivo_pagato',{ts '2008-05-28 13:26:33.593'},'SA','Contratti passivi pagati e parzialmente pagati','E',{ts '2008-05-30 10:14:42.047'},'ASSISTENZA','Finanza','1000')
GO

-- FINE GENERAZIONE SCRIPT --

-- GENERAZIONE DATI PER exportfunctionparam --
IF exists(SELECT * FROM [exportfunctionparam] WHERE paramname = 'ayear' AND procedurename = 'exp_contrattopassivo_pagato')
UPDATE [exportfunctionparam] SET ct = {ts '2008-05-28 13:29:05.967'},cu = 'SA',datasource = null,description = 'Esercizio',displaymember = null,filter = null,help = null,hint = null,hintkind = 'ACCOUNTYEAR',iscombobox = 'N',lt = {ts '2008-05-28 13:29:05.967'},lu = 'SA',noselectionforall = 'N',number = '1',selectioncode = null,systype = 'Int32',tag = 'year',valuemember = null WHERE paramname = 'ayear' AND procedurename = 'exp_contrattopassivo_pagato'
ELSE
INSERT INTO [exportfunctionparam] (paramname,procedurename,ct,cu,datasource,description,displaymember,filter,help,hint,hintkind,iscombobox,lt,lu,noselectionforall,number,selectioncode,systype,tag,valuemember) VALUES ('ayear','exp_contrattopassivo_pagato',{ts '2008-05-28 13:29:05.967'},'SA',null,'Esercizio',null,null,null,null,'ACCOUNTYEAR','N',{ts '2008-05-28 13:29:05.967'},'SA','N','1',null,'Int32','year',null)
GO

IF exists(SELECT * FROM [exportfunctionparam] WHERE paramname = 'idmankind' AND procedurename = 'exp_contrattopassivo_pagato')
UPDATE [exportfunctionparam] SET ct = {ts '2008-05-28 13:29:05.997'},cu = 'SA',datasource = 'mandatekind',description = 'Tipo contratto passivo',displaymember = 'description',filter = null,help = null,hint = null,hintkind = 'NOHINT',iscombobox = 'S',lt = {ts '2008-05-28 13:29:05.997'},lu = 'SA',noselectionforall = 'N',number = '2',selectioncode = null,systype = 'String',tag = 'g',valuemember = 'idmankind' WHERE paramname = 'idmankind' AND procedurename = 'exp_contrattopassivo_pagato'
ELSE
INSERT INTO [exportfunctionparam] (paramname,procedurename,ct,cu,datasource,description,displaymember,filter,help,hint,hintkind,iscombobox,lt,lu,noselectionforall,number,selectioncode,systype,tag,valuemember) VALUES ('idmankind','exp_contrattopassivo_pagato',{ts '2008-05-28 13:29:05.997'},'SA','mandatekind','Tipo contratto passivo','description',null,null,null,'NOHINT','S',{ts '2008-05-28 13:29:05.997'},'SA','N','2',null,'String','g','idmankind')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER exportfunction --
IF exists(SELECT * FROM [exportfunction] WHERE procedurename = 'exp_contrattopassivo_non_pagato')
UPDATE [exportfunction] SET ct = {ts '2008-05-28 13:29:48.873'},cu = 'SA',description = 'Contratti passivi non pagati',fileformat = 'E',lt = {ts '2008-05-30 10:14:31.483'},lu = 'ASSISTENZA',modulename = 'Finanza',timeout = '1000' WHERE procedurename = 'exp_contrattopassivo_non_pagato'
ELSE
INSERT INTO [exportfunction] (procedurename,ct,cu,description,fileformat,lt,lu,modulename,timeout) VALUES ('exp_contrattopassivo_non_pagato',{ts '2008-05-28 13:29:48.873'},'SA','Contratti passivi non pagati','E',{ts '2008-05-30 10:14:31.483'},'ASSISTENZA','Finanza','1000')
GO

-- FINE GENERAZIONE SCRIPT --


-- GENERAZIONE DATI PER exportfunctionparam --
IF exists(SELECT * FROM [exportfunctionparam] WHERE paramname = 'ayear' AND procedurename = 'exp_contrattopassivo_non_pagato')
UPDATE [exportfunctionparam] SET ct = {ts '2008-05-28 13:30:07.327'},cu = 'SA',datasource = null,description = 'Esercizio',displaymember = null,filter = null,help = null,hint = null,hintkind = 'ACCOUNTYEAR',iscombobox = 'N',lt = {ts '2008-05-28 13:30:07.327'},lu = 'SA',noselectionforall = 'N',number = '1',selectioncode = null,systype = 'Int32',tag = 'year',valuemember = null WHERE paramname = 'ayear' AND procedurename = 'exp_contrattopassivo_non_pagato'
ELSE
INSERT INTO [exportfunctionparam] (paramname,procedurename,ct,cu,datasource,description,displaymember,filter,help,hint,hintkind,iscombobox,lt,lu,noselectionforall,number,selectioncode,systype,tag,valuemember) VALUES ('ayear','exp_contrattopassivo_non_pagato',{ts '2008-05-28 13:30:07.327'},'SA',null,'Esercizio',null,null,null,null,'ACCOUNTYEAR','N',{ts '2008-05-28 13:30:07.327'},'SA','N','1',null,'Int32','year',null)
GO

IF exists(SELECT * FROM [exportfunctionparam] WHERE paramname = 'idmankind' AND procedurename = 'exp_contrattopassivo_non_pagato')
UPDATE [exportfunctionparam] SET ct = {ts '2008-05-28 13:30:33.450'},cu = 'SA',datasource = 'mandatekind',description = 'Tipo contratto passivo',displaymember = 'description',filter = null,help = null,hint = null,hintkind = 'NOHINT',iscombobox = 'S',lt = {ts '2008-05-28 13:30:33.450'},lu = 'SA',noselectionforall = 'N',number = '2',selectioncode = null,systype = 'String',tag = 'g',valuemember = 'idmankind' WHERE paramname = 'idmankind' AND procedurename = 'exp_contrattopassivo_non_pagato'
ELSE
INSERT INTO [exportfunctionparam] (paramname,procedurename,ct,cu,datasource,description,displaymember,filter,help,hint,hintkind,iscombobox,lt,lu,noselectionforall,number,selectioncode,systype,tag,valuemember) VALUES ('idmankind','exp_contrattopassivo_non_pagato',{ts '2008-05-28 13:30:33.450'},'SA','mandatekind','Tipo contratto passivo','description',null,null,null,'NOHINT','S',{ts '2008-05-28 13:30:33.450'},'SA','N','2',null,'String','g','idmankind')
GO

-- FINE GENERAZIONE SCRIPT --



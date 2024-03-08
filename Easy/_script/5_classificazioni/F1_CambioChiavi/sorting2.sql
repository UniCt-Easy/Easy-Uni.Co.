
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


-- Passo 3. Valorizzazione delle colonne di tutte le tabelle referenziate
IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sorting' and C.name = 'paridsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sorting SET paridsorint = 
	(SELECT idsorint FROM sorting s2 WHERE s2.idsorkind = sorting.idsorkind AND s2.idsor = sorting.paridsor)
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accountsorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE accountsorting SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = accountsorting.idsorkind AND sorting.idsor = accountsorting.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accountvardetail' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE accountvardetail SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = accountvardetail.idsorkind AND sorting.idsor = accountvardetail.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'accountyear' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE accountyear SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = accountyear.idsorkind AND sorting.idsor = accountyear.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_expensesorted' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE admpay_expensesorted SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = admpay_expensesorted.idsorkind AND sorting.idsor = admpay_expensesorted.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'admpay_incomesorted' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE admpay_incomesorted SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = admpay_incomesorted.idsorkind AND sorting.idsor = admpay_incomesorted.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idsor1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetacquire SET idsor1int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind1 = sorting.idsorkind
	WHERE sorting.idsor = assetacquire.idsor1 AND YEAR(assetacquire.adate) = config.ayear
	AND idsor1 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idsor2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetacquire SET idsor2int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind2 = sorting.idsorkind
	WHERE sorting.idsor = assetacquire.idsor1 AND YEAR(assetacquire.adate) = config.ayear
	AND idsor2 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'assetacquire' and C.name = 'idsor3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE assetacquire SET idsor3int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind3 = sorting.idsorkind
	WHERE sorting.idsor = assetacquire.idsor1 AND YEAR(assetacquire.adate) = config.ayear
	AND idsor3 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoexpensesorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE autoexpensesorting SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = autoexpensesorting.idsorkind AND sorting.idsor = autoexpensesorting.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoexpensesorting' and C.name = 'idsorregint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE autoexpensesorting SET idsorregint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = autoexpensesorting.idsorkindreg AND sorting.idsor = autoexpensesorting.idsorreg
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoincomesorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE autoincomesorting SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = autoincomesorting.idsorkind AND sorting.idsor = autoincomesorting.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'autoincomesorting' and C.name = 'idsorregint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE autoincomesorting SET idsorregint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = autoincomesorting.idsorkindreg AND sorting.idsor = autoincomesorting.idsorreg
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'banktransactionsorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE banktransactionsorting SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = banktransactionsorting.idsorkind AND sorting.idsor = banktransactionsorting.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontract' and C.name = 'idsor1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE casualcontract SET idsor1int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind1 = sorting.idsorkind
	WHERE sorting.idsor = casualcontract.idsor1 AND casualcontract.ycon = config.ayear
	AND idsor1 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontract' and C.name = 'idsor2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE casualcontract SET idsor2int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind2 = sorting.idsorkind
	WHERE sorting.idsor = casualcontract.idsor1 AND casualcontract.ycon = config.ayear
	AND idsor2 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontract' and C.name = 'idsor3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE casualcontract SET idsor3int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind3 = sorting.idsorkind
	WHERE sorting.idsor = casualcontract.idsor1 AND casualcontract.ycon = config.ayear
	AND idsor3 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'casualcontractsorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE casualcontractsorting SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = casualcontractsorting.idsorkind AND sorting.idsor = casualcontractsorting.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'clawbacksorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE clawbacksorting SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = clawbacksorting.idsorkind AND sorting.idsor = clawbacksorting.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'divisionsorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE divisionsorting SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = divisionsorting.idsorkind AND sorting.idsor = divisionsorting.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'entrydetail' and C.name = 'idsor1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE entrydetail SET idsor1int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind1 = sorting.idsorkind
	WHERE sorting.idsor = entrydetail.idsor1 AND entrydetail.yentry = config.ayear
	AND idsor1 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'entrydetail' and C.name = 'idsor2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE entrydetail SET idsor2int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind2 = sorting.idsorkind
	WHERE sorting.idsor = entrydetail.idsor1 AND entrydetail.yentry = config.ayear
	AND idsor2 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'entrydetail' and C.name = 'idsor3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE entrydetail SET idsor3int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind3 = sorting.idsorkind
	WHERE sorting.idsor = entrydetail.idsor1 AND entrydetail.yentry = config.ayear
	AND idsor3 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'epexpsorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE epexpsorting SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = epexpsorting.idsorkind AND sorting.idsor = epexpsorting.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatedetail' and C.name = 'idsor1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE estimatedetail SET idsor1int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind1 = sorting.idsorkind
	WHERE sorting.idsor = estimatedetail.idsor1 AND estimatedetail.yestim = config.ayear
	AND idsor1 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatedetail' and C.name = 'idsor2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE estimatedetail SET idsor2int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind2 = sorting.idsorkind
	WHERE sorting.idsor = estimatedetail.idsor1 AND estimatedetail.yestim = config.ayear
	AND idsor2 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatedetail' and C.name = 'idsor3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE estimatedetail SET idsor3int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind3 = sorting.idsorkind
	WHERE sorting.idsor = estimatedetail.idsor1 AND estimatedetail.yestim = config.ayear
	AND idsor3 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'estimatesorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE estimatesorting SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = estimatesorting.idsorkind AND sorting.idsor = estimatesorting.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesorted' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensesorted SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = expensesorted.idsorkind AND sorting.idsor = expensesorted.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'expensesorted' and C.name = 'paridsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE expensesorted SET paridsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = expensesorted.paridsorkind AND sorting.idsor = expensesorted.paridsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'finsorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE finsorting SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = finsorting.idsorkind AND sorting.idsor = finsorting.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'flowchartsorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE flowchartsorting SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = flowchartsorting.idsorkind AND sorting.idsor = flowchartsorting.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesorted' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomesorted SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = incomesorted.idsorkind AND sorting.idsor = incomesorted.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'incomesorted' and C.name = 'paridsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE incomesorted SET paridsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = incomesorted.paridsorkind AND sorting.idsor = incomesorted.paridsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'inventorytreesorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE inventorytreesorting SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = inventorytreesorting.idsorkind AND sorting.idsor = inventorytreesorting.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idsor1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicedetail SET idsor1int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind1 = sorting.idsorkind
	WHERE sorting.idsor = invoicedetail.idsor1 AND invoicedetail.yinv = config.ayear
	AND idsor1 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idsor2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicedetail SET idsor2int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind2 = sorting.idsorkind
	WHERE sorting.idsor = invoicedetail.idsor1 AND invoicedetail.yinv = config.ayear
	AND idsor2 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicedetail' and C.name = 'idsor3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicedetail SET idsor3int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind3 = sorting.idsorkind
	WHERE sorting.idsor = invoicedetail.idsor1 AND invoicedetail.yinv = config.ayear
	AND idsor3 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'invoicesorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE invoicesorting SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = invoicesorting.idsorkind AND sorting.idsor = invoicesorting.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idsor1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itineration SET idsor1int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind1 = sorting.idsorkind
	WHERE sorting.idsor = itineration.idsor1 AND itineration.yitineration = config.ayear
	AND idsor1 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idsor2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itineration SET idsor2int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind2 = sorting.idsorkind
	WHERE sorting.idsor = itineration.idsor1 AND itineration.yitineration = config.ayear
	AND idsor2 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itineration' and C.name = 'idsor3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itineration SET idsor3int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind3 = sorting.idsorkind
	WHERE sorting.idsor = itineration.idsor1 AND itineration.yitineration = config.ayear
	AND idsor3 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'itinerationsorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE itinerationsorting SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = itinerationsorting.idsorkind AND sorting.idsor = itinerationsorting.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'locationsorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE locationsorting SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = locationsorting.idsorkind AND sorting.idsor = locationsorting.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'managersorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE managersorting SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = managersorting.idsorkind AND sorting.idsor = managersorting.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatedetail' and C.name = 'idsor1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE mandatedetail SET idsor1int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind1 = sorting.idsorkind
	WHERE sorting.idsor = mandatedetail.idsor1 AND mandatedetail.yman = config.ayear
	AND idsor1 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatedetail' and C.name = 'idsor2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE mandatedetail SET idsor2int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind2 = sorting.idsorkind
	WHERE sorting.idsor = mandatedetail.idsor1 AND mandatedetail.yman = config.ayear
	AND idsor2 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatedetail' and C.name = 'idsor3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE mandatedetail SET idsor3int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind3 = sorting.idsorkind
	WHERE sorting.idsor = mandatedetail.idsor1 AND mandatedetail.yman = config.ayear
	AND idsor3 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'mandatesorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE mandatesorting SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = mandatesorting.idsorkind AND sorting.idsor = mandatesorting.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'parasubcontract' and C.name = 'idsor1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE parasubcontract SET idsor1int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind1 = sorting.idsorkind
	WHERE sorting.idsor = parasubcontract.idsor1 AND parasubcontract.ycon = config.ayear
	AND idsor1 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'parasubcontract' and C.name = 'idsor2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE parasubcontract SET idsor2int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind2 = sorting.idsorkind
	WHERE sorting.idsor = parasubcontract.idsor1 AND parasubcontract.ycon = config.ayear
	AND idsor2 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'parasubcontract' and C.name = 'idsor3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE parasubcontract SET idsor3int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind3 = sorting.idsorkind
	WHERE sorting.idsor = parasubcontract.idsor1 AND parasubcontract.ycon = config.ayear
	AND idsor3 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'parasubcontractsorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE parasubcontractsorting SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = parasubcontractsorting.idsorkind AND sorting.idsor = parasubcontractsorting.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'idsor1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperation SET idsor1int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind1 = sorting.idsorkind
	WHERE sorting.idsor = pettycashoperation.idsor1 AND pettycashoperation.yoperation = config.ayear
	AND idsor1 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'idsor2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperation SET idsor2int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind2 = sorting.idsorkind
	WHERE sorting.idsor = pettycashoperation.idsor1 AND pettycashoperation.yoperation = config.ayear
	AND idsor2 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperation' and C.name = 'idsor3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperation SET idsor3int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind3 = sorting.idsorkind
	WHERE sorting.idsor = pettycashoperation.idsor1 AND pettycashoperation.yoperation = config.ayear
	AND idsor3 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'pettycashoperationsorted' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE pettycashoperationsorted SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = pettycashoperationsorted.idsorkind AND sorting.idsor = pettycashoperationsorted.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservice' and C.name = 'idsor1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE profservice SET idsor1int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind1 = sorting.idsorkind
	WHERE sorting.idsor = profservice.idsor1 AND profservice.ycon = config.ayear
	AND idsor1 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservice' and C.name = 'idsor2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE profservice SET idsor2int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind2 = sorting.idsorkind
	WHERE sorting.idsor = profservice.idsor1 AND profservice.ycon = config.ayear
	AND idsor2 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservice' and C.name = 'idsor3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE profservice SET idsor3int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind3 = sorting.idsorkind
	WHERE sorting.idsor = profservice.idsor1 AND profservice.ycon = config.ayear
	AND idsor3 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'profservicesorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE profservicesorting SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = profservicesorting.idsorkind AND sorting.idsor = profservicesorting.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'registrysorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE registrysorting SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = registrysorting.idsorkind AND sorting.idsor = registrysorting.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'servicesorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE servicesorting SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = servicesorting.idsorkind AND sorting.idsor = servicesorting.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortedmovementtotal' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortedmovementtotal SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = sortedmovementtotal.idsorkind AND sorting.idsor = sortedmovementtotal.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingexpensefilter' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingexpensefilter SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = sortingexpensefilter.idsorkind AND sorting.idsor = sortingexpensefilter.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingexpensefilter' and C.name = 'idsorregint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingexpensefilter SET idsorregint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = sortingexpensefilter.idsorkindreg AND sorting.idsor = sortingexpensefilter.idsorreg
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingincomefilter' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingincomefilter SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = sortingincomefilter.idsorkind AND sorting.idsor = sortingincomefilter.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingincomefilter' and C.name = 'idsorregint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingincomefilter SET idsorregint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = sortingincomefilter.idsorkindreg AND sorting.idsor = sortingincomefilter.idsorreg
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingprev' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingprev SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = sortingprev.idsorkind AND sorting.idsor = sortingprev.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingprevexpensevar' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingprevexpensevar SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = sortingprevexpensevar.idsorkind AND sorting.idsor = sortingprevexpensevar.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingprevincomevar' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingprevincomevar SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = sortingprevincomevar.idsorkind AND sorting.idsor = sortingprevincomevar.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingtotal' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingtotal SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = sortingtotal.idsorkind AND sorting.idsor = sortingtotal.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingtranslation' and C.name = 'idsortingchildint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingtranslation SET idsortingchildint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = sortingtranslation.sortingkindchild AND sorting.idsor = sortingtranslation.idsortingchild
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'sortingtranslation' and C.name = 'idsortingmasterint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE sortingtranslation SET idsortingmasterint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = sortingtranslation.sortingkindmaster AND sorting.idsor = sortingtranslation.idsortingmaster
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxsorting SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = taxsorting.idsorkind AND sorting.idsor = taxsorting.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsortingsetup' and C.name = 'idsor_adminpayint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxsortingsetup SET idsor_adminpayint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = taxsortingsetup.idsorkind AND sorting.idsor = taxsortingsetup.idsor_adminpay
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsortingsetup' and C.name = 'idsor_adminprocint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxsortingsetup SET idsor_adminprocint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = taxsortingsetup.idsorkind AND sorting.idsor = taxsortingsetup.idsor_adminproc
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsortingsetup' and C.name = 'idsor_employprocint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxsortingsetup SET idsor_employprocint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = taxsortingsetup.idsorkind AND sorting.idsor = taxsortingsetup.idsor_employproc
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'taxsortingsetup' and C.name = 'idsor_taxpayint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE taxsortingsetup SET idsor_taxpayint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = taxsortingsetup.idsorkind AND sorting.idsor = taxsortingsetup.idsor_taxpay
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'upbsorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE upbsorting SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = upbsorting.idsorkind AND sorting.idsor = upbsorting.idsor
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageaddition' and C.name = 'idsor1int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageaddition SET idsor1int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind1 = sorting.idsorkind
	WHERE sorting.idsor = wageaddition.idsor1 AND wageaddition.ycon = config.ayear
	AND idsor1 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageaddition' and C.name = 'idsor2int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageaddition SET idsor2int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind2 = sorting.idsorkind
	WHERE sorting.idsor = wageaddition.idsor1 AND wageaddition.ycon = config.ayear
	AND idsor2 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageaddition' and C.name = 'idsor3int' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageaddition SET idsor3int = sorting.idsorint
	FROM sorting
	JOIN config
	ON config.idsortingkind3 = sorting.idsorkind
	WHERE sorting.idsor = wageaddition.idsor1 AND wageaddition.ycon = config.ayear
	AND idsor3 IS NOT NULL
END
GO

IF EXISTS(select * from [sysobjects] as T inner join syscolumns C on T.ID = C.ID where t.name = 'wageadditionsorting' and C.name = 'idsorint' AND (T.uid = USER_ID( ) OR T.uid = USER_ID('dbo')))
BEGIN
	UPDATE wageadditionsorting SET idsorint = sorting.idsorint
	FROM sorting
	WHERE sorting.idsorkind = wageadditionsorting.idsorkind AND sorting.idsor = wageadditionsorting.idsor
END
GO

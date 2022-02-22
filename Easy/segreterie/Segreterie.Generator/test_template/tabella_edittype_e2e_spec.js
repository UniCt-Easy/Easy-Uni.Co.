'use strict';

describe('app_applicaz - tabella_tipoedit_E2E', function () {
	var timeout = 3000000;
	var stabilize = appMeta.stabilize;
	var stabilizeToCurrent = appMeta.stabilizeToCurrent;
	var testHelper = appMeta.testHelper;
	var testCase = appMeta.testCase;
	var controlTypeEnum = appMeta.testHelper.controlTypeEnum;

	describe("MetaPage",
		function () {

			beforeEach(function () {
				testHelper.initAppTestProduction('app_applicaz');
			});

			it('1. callPage() table:tabella, editType:tipoedit" should be async and return data. ' + "\n" +
				'2. Press "maininsert" -> new row is created' + "\n" +
				'3. Fills mandatory fields and press "mainsave"' + "\n" +
				'4. Press "mainsetsearch, fields are empty' + "\n" +
				'5. Press "maindosearch, record is found' + "\n" +
				'6. Press "maindelete, deletes the record' + "\n" +
				'7. Press "maindosearch, record is not found' + "\n" +
				'8. Press "mainclose" -> page is closed',
				function (done) {

					var tablename = "tabella";
					var edittype = "tipoedit";

					var arrayInput = [];
					//arrayInput

					//parameterFunction
				
				}, timeout);

									

		});

});
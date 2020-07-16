(function () {
	var controlTypeEnum = appMeta.testHelper.controlTypeEnum;
	var testHelper = appMeta.testHelper;

	function tabella_tipoedit() {
		this.arrayInput = [];
		//arrayInput
	}

	tabella_tipoedit.prototype = {
		constructor: tabella_tipoedit
	};

	appMeta.tabella_tipoedit = new tabella_tipoedit();

}());
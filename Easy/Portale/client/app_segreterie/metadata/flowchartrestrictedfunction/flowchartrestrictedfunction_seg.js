(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_flowchartrestrictedfunction() {
		MetaPage.apply(this, ['flowchartrestrictedfunction', 'seg', true]);
        this.name = 'Variabili di sicurezza';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_flowchartrestrictedfunction.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_flowchartrestrictedfunction,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterClear

			//afterFill

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-flowchartrestrictedfunction_seg");
				$('#flowchartrestrictedfunction_seg_idrestrictedfunction').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#flowchartrestrictedfunction_seg_idrestrictedfunction').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#flowchartrestrictedfunction_seg_idrestrictedfunction').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo ID Operatività (tabella restrictedfunction)');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

			//beforePost

			children: [''],
			haveChildren: function () {
				var self = this;
				return _.some(this.children, function (child) {
					if (child !== '')
						return !!self.getDataTable(child).rows.length;
					else
						return false;
				});
			},

			//buttons
        });

	window.appMeta.addMetaPage('flowchartrestrictedfunction', 'seg', metaPage_flowchartrestrictedfunction);

}());

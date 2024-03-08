(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_salassetdiaryora() {
		MetaPage.apply(this, ['salassetdiaryora', 'default', true]);
        this.name = 'Ore dei diari d\'uso del SAL';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_salassetdiaryora.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_salassetdiaryora,
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
				var def = appMeta.Deferred("afterRowSelect-salassetdiaryora_default");
				$('#salassetdiaryora_default_idassetdiaryora').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idassetdiaryora);
				$('#salassetdiaryora_default_idassetdiaryora').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idassetdiaryora);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#salassetdiaryora_default_idassetdiaryora').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Ore dei diari d\'uso');
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

	window.appMeta.addMetaPage('salassetdiaryora', 'default', metaPage_salassetdiaryora);

}());

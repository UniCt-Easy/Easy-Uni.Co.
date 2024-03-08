(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_salrendicontattivitaprogettoora() {
		MetaPage.apply(this, ['salrendicontattivitaprogettoora', 'default', true]);
        this.name = 'Ore di attività del SAL';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_salrendicontattivitaprogettoora.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_salrendicontattivitaprogettoora,
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
				var def = appMeta.Deferred("afterRowSelect-salrendicontattivitaprogettoora_default");
				$('#salrendicontattivitaprogettoora_default_idrendicontattivitaprogettoora').prop("disabled", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idrendicontattivitaprogettoora);
				$('#salrendicontattivitaprogettoora_default_idrendicontattivitaprogettoora').prop("readonly", (this.state.isEditState() || this.haveChildren()) && this.state.currentRow.idrendicontattivitaprogettoora);
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#salrendicontattivitaprogettoora_default_idrendicontattivitaprogettoora').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Ore di attività');
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

	window.appMeta.addMetaPage('salrendicontattivitaprogettoora', 'default', metaPage_salrendicontattivitaprogettoora);

}());

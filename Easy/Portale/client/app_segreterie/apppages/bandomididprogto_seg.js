(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_bandomididprogto() {
		MetaPage.apply(this, ['bandomididprogto', 'seg', true]);
        this.name = 'Corsi a cui si può iscrivere uno studente incoming';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_bandomididprogto.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_bandomididprogto,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterFill

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-bandomididprogto_seg");
				$('#bandomididprogto_seg_iddidprog').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#bandomididprogto_seg_iddidprog').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#bandomididprogto_seg_iddidprog').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Identificativo');
				}
				//insertClickin
				return this.superClass.insertClick(that, grid);
			},

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

	window.appMeta.addMetaPage('bandomididprogto', 'seg', metaPage_bandomididprogto);

}());

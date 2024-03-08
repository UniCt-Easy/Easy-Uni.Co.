(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_bandomididprogfrom() {
		MetaPage.apply(this, ['bandomididprogfrom', 'seg', true]);
        this.name = 'Corsi  a cui deve essere iscritto uno studente outgoing';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_bandomididprogfrom.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_bandomididprogfrom,
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
				var def = appMeta.Deferred("afterRowSelect-bandomididprogfrom_seg");
				$('#bandomididprogfrom_seg_iddidprog').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#bandomididprogfrom_seg_iddidprog').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#bandomididprogfrom_seg_iddidprog').val() && this.children.includes(grid.dataSourceName)) {
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

	window.appMeta.addMetaPage('bandomididprogfrom', 'seg', metaPage_bandomididprogfrom);

}());

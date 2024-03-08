(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_tipologiastudentestruttura() {
		MetaPage.apply(this, ['tipologiastudentestruttura', 'seg', true]);
        this.name = 'Strutture dei corsi a cui lo studente deve essere iscritto';
		this.defaultListType = 'seg';
		//pageHeaderDeclaration
    }

    metaPage_tipologiastudentestruttura.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_tipologiastudentestruttura,
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
				var def = appMeta.Deferred("afterRowSelect-tipologiastudentestruttura_seg");
				$('#tipologiastudentestruttura_seg_idstruttura').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#tipologiastudentestruttura_seg_idstruttura').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#tipologiastudentestruttura_seg_idstruttura').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Struttura didattica');
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

	window.appMeta.addMetaPage('tipologiastudentestruttura', 'seg', metaPage_tipologiastudentestruttura);

}());

(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_creditoistanza_rimb() {
		MetaPage.apply(this, ['creditoistanza_rimb', 'segistrimb', true]);
        this.name = 'Crediti';
		this.defaultListType = 'segistrimb';
		//pageHeaderDeclaration
    }

    metaPage_creditoistanza_rimb.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_creditoistanza_rimb,
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
				var def = appMeta.Deferred("afterRowSelect-creditoistanza_rimb_segistrimb");
				$('#creditoistanza_rimb_segistrimb_idcredito').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#creditoistanza_rimb_segistrimb_idcredito').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#creditoistanza_rimb_segistrimb_iddebito').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#creditoistanza_rimb_segistrimb_iddebito').prop("readonly", this.state.isEditState() || this.haveChildren());
				$('#creditoistanza_rimb_segistrimb_idpagamento').prop("disabled", this.state.isEditState() || this.haveChildren());
				$('#creditoistanza_rimb_segistrimb_idpagamento').prop("readonly", this.state.isEditState() || this.haveChildren());
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			insertClick: function (that, grid) {
				if (!$('#creditoistanza_rimb_segistrimb_idcredito').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Credito');
				}
				if (!$('#creditoistanza_rimb_segistrimb_iddebito').val() && this.children.includes(grid.dataSourceName)) {
					return this.showMessageOk('Prima devi selezionare un valore per il campo Identificativo');
				}
				if (!$('#creditoistanza_rimb_segistrimb_idpagamento').val() && this.children.includes(grid.dataSourceName)) {
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

	window.appMeta.addMetaPage('creditoistanza_rimb', 'segistrimb', metaPage_creditoistanza_rimb);

}());

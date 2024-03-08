(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_convalidato() {
		MetaPage.apply(this, ['convalidato', 'segistpass', true]);
        this.name = 'Convalidati';
		this.defaultListType = 'segistpass';
		//pageHeaderDeclaration
    }

    metaPage_convalidato.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_convalidato,
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
				var def = appMeta.Deferred("afterRowSelect-convalidato_segistpass");
				if (t.name === "didprog" && r !== null) {
					this.state.DS.tables.attivformdefaultview.staticFilter(window.jsDataQuery.eq("iddidprog", r.iddidprog));
					if (this.state.DS.tables.attivformdefaultview.rows.length)
						if (this.state.DS.tables.attivformdefaultview.rows[0].iddidprog !== r.iddidprog) {
							this.state.DS.tables.attivformdefaultview.clear();
							$('#convalidato_segistpass_idattivform').val('');
						}
				}
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			//buttons
        });

	window.appMeta.addMetaPage('convalidato', 'segistpass', metaPage_convalidato);

}());

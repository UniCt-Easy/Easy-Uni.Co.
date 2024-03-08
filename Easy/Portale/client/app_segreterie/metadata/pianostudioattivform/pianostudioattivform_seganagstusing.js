(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_pianostudioattivform() {
		MetaPage.apply(this, ['pianostudioattivform', 'seganagstusing', true]);
        this.name = 'Attività formative pianificate';
		this.defaultListType = 'seganagstusing';
		//pageHeaderDeclaration
    }

    metaPage_pianostudioattivform.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_pianostudioattivform,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			afterGetFormData: function () {
				//parte sincrona
				var self = this;
				var parentRow = self.state.currentRow;
				
				//afterGetFormDataFilter
				
				//parte asincrona
				var def = appMeta.Deferred("afterGetFormData-pianostudioattivform_seganagstusing");
				var arraydef = [];
				
				arraydef.push(this.managepianostudioattivform__seganagstusing_idcorsostudio());
				//afterGetFormDataInside
				
				$.when.apply($, arraydef)
					.then(function () {
						return def.resolve();
					});
				return def.promise();
			},
			
			//beforeFill

			//afterClear

			afterFill: function () {
				this.enableControl($('#pianostudioattivform_seganagstusing_idsostenimento'), false);
				//afterFillin
				return this.superClass.afterFill.call(this);
			},

			//afterLink

			afterRowSelect: function (t, r) {
				var def = appMeta.Deferred("afterRowSelect-pianostudioattivform_seganagstusing");
				if (t.name === "didprogdefaultview" && r !== null) {
					this.state.DS.tables.attivformdefaultview.staticFilter(window.jsDataQuery.eq("iddidprog", r.iddidprog));
					if (this.state.DS.tables.attivformdefaultview.rows.length)
						if (this.state.DS.tables.attivformdefaultview.rows[0].iddidprog !== r.iddidprog) {
							this.state.DS.tables.attivformdefaultview.clear();
							$('#pianostudioattivform_seganagstusing_idattivform').val('');
						}
				}
				//afterRowSelectin
				return def.resolve();
			},

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			managepianostudioattivform__seganagstusing_idcorsostudio: function () {
				var def = appMeta.Deferred("beforeFill-managepianostudioattivform__seganagstusing_idcorsostudio");
				var self = this;
				var masterRow = _.find(this.state.DS.tables.didprogdefaultview.rows, function (row) {
					if (self.state.currentRow.iddidprog)
						return row.iddidprog === self.state.currentRow.iddidprog;
					else
						return null;
				});
				if (masterRow)
					this.state.currentRow.idcorsostudio = masterRow.idcorsostudio;
				return def.resolve();
			},

			//buttons
        });

	window.appMeta.addMetaPage('pianostudioattivform', 'seganagstusing', metaPage_pianostudioattivform);

}());

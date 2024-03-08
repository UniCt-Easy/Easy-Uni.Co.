(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_insegn() {
		MetaPage.apply(this, ['insegn', 'default', false]);
        this.name = 'Insegnamenti';
		this.defaultListType = 'default';
		//pageHeaderDeclaration
    }

    metaPage_insegn.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_insegn,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterClear

			//afterFill

			afterLink: function () {
				var self = this;
				var grid_insegninteg_defaultChildsTables = [
					{ tablename: 'insegnintegcaratteristica', edittype: 'default', columnlookup: 'cf', columncalc: '!insegnintegcaratteristica'},
				];
				$('#grid_insegninteg_default').data('childtables', grid_insegninteg_defaultChildsTables);
				//fireAfterLink
				return this.superClass.afterLink.call(this).then(function () {
					var arraydef = [];
					//fireAfterLinkAsinc
					return $.when.apply($, arraydef);
				});
			},

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			//buttons
        });

	window.appMeta.addMetaPage('insegn', 'default', metaPage_insegn);

}());

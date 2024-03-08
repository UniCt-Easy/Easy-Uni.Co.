(function() {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_sostenimento() {
		MetaPage.apply(this, ['sostenimento', 'seganagstupiano', true]);
        this.name = 'Sostenimenti';
		this.defaultListType = 'seganagstupiano';
		//pageHeaderDeclaration
    }

    metaPage_sostenimento.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_sostenimento,
            superClass: MetaPage.prototype,

            getName:function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			beforeFill:function () {
				var self = this;
				var parentRow = self.state.currentRow;
				
				if(!parentRow.data)
					parentRow.data =  new Date();
				//beforeFillFilter
				
				return self.superClass.beforeFill.call(self);
			},

			//afterFill

			//afterLink

			//afterRowSelect

			//rowSelected

			//buttonClickEnd

			//buttons
        });

	window.appMeta.addMetaPage('sostenimento', 'seganagstupiano', metaPage_sostenimento);

}());

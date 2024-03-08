(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_ratadefdefaultview() {
        MetaData.apply(this, ["ratadefdefaultview"]);
        this.name = 'meta_ratadefdefaultview';
    }

    meta_ratadefdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_ratadefdefaultview,
			superClass: MetaData.prototype,

			describeColumns: function (table, listType) {
				var nPos=1;
				var self = this;
				_.forEach(table.columns, function (c) {
					self.describeAColumn(table, c.name, '', null, -1, null);
				});
				switch (listType) {
					default:
						return this.superClass.describeColumns(table, listType);
					case 'default':
						this.describeAColumn(table, 'idratakind', 'Tipologia', null, 10, 50);
						this.describeAColumn(table, 'ratadef_decorrenza', 'Decorrenza', 'g', 20, null);
						this.describeAColumn(table, 'ratadef_scadenza', 'Scadenza', 'g', 60, null);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idratadef", "idfasciaiseedef", "idcostoscontodef"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('ratadefdefaultview', new meta_ratadefdefaultview('ratadefdefaultview'));

	}());

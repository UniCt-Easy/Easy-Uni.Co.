(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_iscrizionebmiattachsegview() {
        MetaData.apply(this, ["iscrizionebmiattachsegview"]);
        this.name = 'meta_iscrizionebmiattachsegview';
    }

    meta_iscrizionebmiattachsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_iscrizionebmiattachsegview,
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
					case 'seg':
						this.describeAColumn(table, 'allegatirichiesti_title', 'Idallegatirichiesti', null, 10, -1);
						this.describeAColumn(table, 'iscrizionebmi_idreg', 'Identificativo Identificativo', null, 40, null);
						this.describeAColumn(table, 'iscrizionebmi_idbandomi', 'Bando di mobilità internazionale Identificativo', null, 40, null);
						this.describeAColumn(table, 'iscrizionebmi_idiscrizionebmi', 'Identificativo Identificativo', null, 40, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idreg", "idattach", "idbandomi", "idiscrizionebmi"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

        });

    window.appMeta.addMeta('iscrizionebmiattachsegview', new meta_iscrizionebmiattachsegview('iscrizionebmiattachsegview'));

	}());

(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_protocollodockindsegview() {
        MetaData.apply(this, ["protocollodockindsegview"]);
        this.name = 'meta_protocollodockindsegview';
    }

    meta_protocollodockindsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_protocollodockindsegview,
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
						this.describeAColumn(table, 'title', 'Titolo', null, 2000, 50);
						this.describeAColumn(table, 'protocollodockind_description', 'Descrizione', null, 3000, 256);
						this.describeAColumn(table, 'protocollodockind_active', 'Attivo', null, 4000, null);
						this.describeAColumn(table, 'protocollodockind_kind', 'Tipo', null, 5000, 50);
						this.describeAColumn(table, 'protocollodockind_sortcode', 'Ordinamento', null, 6000, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idprotocollodockind"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "title desc";
					}
					case "seg": {
						return "title desc, protocollodockind_sortcode desc";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('protocollodockindsegview', new meta_protocollodockindsegview('protocollodockindsegview'));

	}());

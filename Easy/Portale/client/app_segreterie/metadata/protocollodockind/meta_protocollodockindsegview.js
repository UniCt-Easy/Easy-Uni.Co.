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
						this.describeAColumn(table, 'title', 'Tipologia', null, 20, 50);
						this.describeAColumn(table, 'protocollodockind_description', 'Descrizione', null, 30, 256);
						this.describeAColumn(table, 'protocollodockind_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'protocollodockind_kind', 'Kind', null, 50, 50);
						this.describeAColumn(table, 'protocollodockind_sortcode', 'Sortcode', null, 60, null);
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
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('protocollodockindsegview', new meta_protocollodockindsegview('protocollodockindsegview'));

	}());

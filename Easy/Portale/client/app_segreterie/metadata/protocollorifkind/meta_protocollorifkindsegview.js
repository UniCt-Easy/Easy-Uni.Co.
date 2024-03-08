(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_protocollorifkindsegview() {
        MetaData.apply(this, ["protocollorifkindsegview"]);
        this.name = 'meta_protocollorifkindsegview';
    }

    meta_protocollorifkindsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_protocollorifkindsegview,
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
						this.describeAColumn(table, 'protocollorifkind_description', 'Descrizione', null, 30, 256);
						this.describeAColumn(table, 'protocollorifkind_active', 'Attivo', null, 40, null);
						this.describeAColumn(table, 'protocollorifkind_sortcode', 'Sortcode', null, 50, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idprotocollorifkind"];
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

    window.appMeta.addMeta('protocollorifkindsegview', new meta_protocollorifkindsegview('protocollorifkindsegview'));

	}());

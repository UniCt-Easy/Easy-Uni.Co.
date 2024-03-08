(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_flowchartsegview() {
        MetaData.apply(this, ["flowchartsegview"]);
        this.name = 'meta_flowchartsegview';
    }

    meta_flowchartsegview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_flowchartsegview,
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
						this.describeAColumn(table, 'codeflowchart', 'Codice', null, 10, 50);
						this.describeAColumn(table, 'flowchart_title', 'Denominazione', null, 20, 150);
						this.describeAColumn(table, 'flowchart_nlevel', 'N. livello', null, 30, null);
//$objCalcFieldConfig_seg$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["idflowchart"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			getSorting: function (listType) {
				switch (listType) {
					case "seg": {
						return "codeflowchart asc , flowchart_title desc";
					}
					case "seg": {
						return "codeflowchart asc , flowchart_title asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('flowchartsegview', new meta_flowchartsegview('flowchartsegview'));

	}());

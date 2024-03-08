(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_flowchartsegammview() {
        MetaData.apply(this, ["flowchartsegammview"]);
        this.name = 'meta_flowchartsegammview';
    }

    meta_flowchartsegammview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_flowchartsegammview,
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
					case 'segamm':
						this.describeAColumn(table, 'idflowchart', 'Identificativo', null, 10, 34);
						this.describeAColumn(table, 'flowchart_ayear', 'Anno esercizio', null, 20, null);
						this.describeAColumn(table, 'title', 'Titolo', null, 30, 150);
						this.describeAColumn(table, 'flowchart_codeflowchart', 'Codice', null, 40, 50);
						this.describeAColumn(table, 'flowchartparent_codeflowchart', 'Codice Nodo padre', null, 50, 50);
						this.describeAColumn(table, 'flowchartparent_title', 'Denominazione Nodo padre', null, 50, 150);
//$objCalcFieldConfig_segamm$
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
					case "segamm": {
						return "idflowchart asc , flowchart_title desc";
					}
					case "segamm": {
						return "idflowchart asc , title desc";
					}
					case "segamm": {
						return "idflowchart asc , title desc, flowchart_codeflowchart asc ";
					}
					//$getSortingin$
				}
				return this.superClass.getSorting(listType);
			}

        });

    window.appMeta.addMeta('flowchartsegammview', new meta_flowchartsegammview('flowchartsegammview'));

	}());

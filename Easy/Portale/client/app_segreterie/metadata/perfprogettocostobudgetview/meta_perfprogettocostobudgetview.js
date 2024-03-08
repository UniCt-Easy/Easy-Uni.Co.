(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfprogettocostobudgetview() {
        MetaData.apply(this, ["perfprogettocostobudgetview"]);
        this.name = 'meta_perfprogettocostobudgetview';
    }

    meta_perfprogettocostobudgetview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettocostobudgetview,
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
						this.describeAColumn(table, 'rownum', 'Numero Riga', null, 10, null);
						this.describeAColumn(table, 'nvar', 'Numero Variazione', null, 20, null);
						this.describeAColumn(table, 'description', 'Descrizione', null, 30, 150);
						this.describeAColumn(table, 'amount', 'Importo variazione anno corrente', 'fixed.2', 40, null);
						this.describeAColumn(table, 'amount2', 'Importo variazione anno   corrente + 1', 'fixed.2', 50, null);
						this.describeAColumn(table, 'amount3', 'Importo variazione anno  corrente + 2', 'fixed.2', 60, null);
						this.describeAColumn(table, 'amount4', 'Importo variazione anno corrente + 3', 'fixed.2', 70, null);
						this.describeAColumn(table, 'amount5', 'Importo variazione anno corrente + 4', 'fixed.2', 80, null);
						this.describeAColumn(table, 'annotation', 'Annotazioni', null, 90, 400);
						this.describeAColumn(table, 'underwritingkind_desc', 'Fonte di finanziamento', null, 250, 69);
//$objCalcFieldConfig_default$
						break;
//$objCalcFieldConfig$
				}
				return appMeta.Deferred("describeColumns").resolve();
			},


			//$setCaptions$

			primaryKey: function () {
				return ["nvar", "yvar", "rownum"];
			},


			//$isValidFunction$

			//$getStaticFilter$

			//$getSorting$

			//$describeTree$
        });

    window.appMeta.addMeta('perfprogettocostobudgetview', new meta_perfprogettocostobudgetview('perfprogettocostobudgetview'));

	}());

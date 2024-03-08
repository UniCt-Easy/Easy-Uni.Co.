(function() {

    var MetaData = window.appMeta.MetaSegreterieData;

    function meta_perfprogettocostobudgetviewdefaultview() {
        MetaData.apply(this, ["perfprogettocostobudgetviewdefaultview"]);
        this.name = 'meta_perfprogettocostobudgetviewdefaultview';
    }

    meta_perfprogettocostobudgetviewdefaultview.prototype = _.extend(
        new MetaData(),
        {
            constructor: meta_perfprogettocostobudgetviewdefaultview,
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
						this.describeAColumn(table, 'perfprogettocostobudgetview_amount', 'Importo variazione anno corrente', 'fixed.2', 40, null);
						this.describeAColumn(table, 'perfprogettocostobudgetview_amount2', 'Importo variazione anno   corrente + 1', 'fixed.2', 50, null);
						this.describeAColumn(table, 'perfprogettocostobudgetview_amount3', 'Importo variazione anno  corrente + 2', 'fixed.2', 60, null);
						this.describeAColumn(table, 'perfprogettocostobudgetview_amount4', 'Importo variazione anno corrente + 3', 'fixed.2', 70, null);
						this.describeAColumn(table, 'perfprogettocostobudgetview_amount5', 'Importo variazione anno corrente + 4', 'fixed.2', 80, null);
						this.describeAColumn(table, 'perfprogettocostobudgetview_annotation', 'Annotazioni', null, 90, 400);
						this.describeAColumn(table, 'perfprogettocostobudgetview_underwritingkind_desc', 'Fonte di finanziamento', null, 250, 69);
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

    window.appMeta.addMeta('perfprogettocostobudgetviewdefaultview', new meta_perfprogettocostobudgetviewdefaultview('perfprogettocostobudgetviewdefaultview'));

	}());

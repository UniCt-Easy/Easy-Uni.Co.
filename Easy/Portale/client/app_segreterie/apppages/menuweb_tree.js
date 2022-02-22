
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


(function () {
	
    var MetaPage = window.appMeta.MetaSegreteriePage;

    function metaPage_menuweb() {
		MetaPage.apply(this, ['menuweb', 'tree', false]);
        this.name = 'Menù';
		this.defaultListType = 'tree';
		this.isList = true;
		this.isTree = true;
		//pageHeaderDeclaration
    }

    metaPage_menuweb.prototype = _.extend(
        new MetaPage(),
        {
            constructor: metaPage_menuweb,
            superClass: MetaPage.prototype,

            getName: function () {
               return this.name;
			},

			//isValidFunction

			//afterGetFormData
			
			//beforeFill

			//afterClear

			//afterFill

			//afterLink

			//afterRowSelect

			//afterActivation

			//rowSelected

			//buttonClickEnd

			//insertClick

			//beforePost

			beforeSelectTreeManager: function () {
				var def = appMeta.Deferred('beforeSelectTreeManager');
				return def.resolve(true);
			},

			afterPost: function () {
            var self = this;
            if (self.state.currentRow) {
               if (self.state.formState === "insert") {
                return  appMeta.getData.launchCustomServerMethod("callSP", {
                     spname: "menuweb_addentry",
                     prm1: self.state.currentRow.idmenuwebparent,
                     prm2: self.state.currentRow.idmenuweb,
                     prm3: self.state.currentRow.tableName,
                     prm4: self.state.currentRow.editType,
                     prm5: self.state.currentRow.label
                  });
               } else if (!self.state.currentRow.getRow) { //se non ha getRow cancello perchè in caso di cancellazione formState risulta ancora in edit
                 return appMeta.getData.launchCustomServerMethod("callSP", {
                     spname: "EraseSecureVariable",
                     prm1: "mr_" + self.state.currentRow.idmenuweb

                  }).then(function (res) {
                     var msg = "";
                     if (res.err) {
                          return  res;
                     } else {
                       return appMeta.getData.launchCustomServerMethod("callSP", {
                           spname: "EraseSecureVariable",
                           prm1: "mw_" + self.state.currentRow.idmenuweb

                        });
                     }
                  }).then(function (resErase) {
                     var msg = "OK. La voce è stata cancellata";
                     if (resErase.err) {
                        msg = "KO " + resErase.err;
                     }
                     return self.showMessageOk(msg);

                  });


               }
            }
            return true;
         },

			//buttons
        });

	window.appMeta.addMetaPage('menuweb', 'tree', metaPage_menuweb);

}());

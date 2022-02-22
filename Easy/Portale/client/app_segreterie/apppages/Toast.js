
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


/**
 * @module Toast
 * @description
 * Contains the common methods of Toast
 */
(function () {

    /**
     * @constructor Toast
     * @description
     * Utilities for to show a notification on web app developed wth MDLW
     */
    function Toast() {
    }

    Toast.prototype = {
        constructor: Toast,

        /**
         * @method showControl
         * @public
         * @description SYNC
         * Sets the message and shows the modal control
         * @param {string} msg
         */
        showNotification:function (msg) {
            $.toast({
                text: msg, // Text that is to be shown in the toast
                //heading: 'Note', // Optional heading to be shown on the toast
                icon: 'info', // Type of toast icon
                showHideTransition: 'fade', // fade, slide or plain
                allowToastClose: true, // Boolean value true or false
                hideAfter: 5000, // false to make it sticky or number representing the miliseconds as time after which toast needs to be hidden
                stack: 5, // false if there should be only one toast at a time or a number representing the maximum number of toasts to be shown at a time
                position: 'bottom-right', // bottom-left or bottom-right or bottom-center or top-left or top-right or top-center or mid-center or an object representing the left, right, top, bottom values
                textAlign: 'left',  // Text alignment i.e. left, right or center
                loader: false,  // Whether to show loader or not. True by default
                loaderBg: '#ebf5f3'  // Background color of the toast loader
            });
        }

    };

    appMeta.Toast = new Toast();
}());

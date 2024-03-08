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

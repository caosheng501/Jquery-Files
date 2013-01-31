$(document).ready(function() {

    jQuery.validator.addMethod("password", function(value, element) {
        var result = this.optional(element) || value.length >= 6 && /\d/.test(value) && /[a-z]/i.test(value);
        if (!result) {
            element.value = "";
            var validator = this;
            setTimeout(function() {
                validator.blockFocusCleanup = true;
                element.focus();
                validator.blockFocusCleanup = false;
            }, 1);
        }
        return result;
    }, "Your password must be at least 6 characters long and contain at least one number and one character.");

    // a custom method making the default value for companyurl ("http://") invalid, without displaying the "invalid url" message
    jQuery.validator.addMethod("defaultInvalid", function(value, element) {
        return value != element.defaultValue;
    }, "");

    jQuery.validator.addMethod("ValidationRequired", function(value, element) {
        if ($("#bill_to_co").is(":checked"))
            return $(element).parents(".subTable").length;
        return !this.optional(element);
    }, "");

    jQuery.validator.messages.required = "";
    $("form").validate({
        onkeyup: false,
//        submitHandler: function() {
//            alert("submit! use link below to go to the other step");
//            return true;
//        },
        messages: {
            password2: {
                required: " ",
                equalTo: "Please enter the same password as above"
            },
            email: {
                required: " ",
                email: "Please enter a valid email address, example: you@yourdomain.com",
                remote: jQuery.validator.format("{0} is already taken, please enter a different address.")
            }
        }
        //debug: true
    });

    $(".resize").vjustify();
    $("div.buttonSubmit").hoverClass("buttonSubmitHover");

    if ($.browser.safari) {
        $("body").addClass("safari");
    }

    $("input.phone").mask("(999) 999-9999");
    $("input.zipcode").mask("999999");
    var creditcard = $("#creditcard").mask("9999 9999 9999 9999");

    $("#cc_type").change(
    function() {
        switch ($(this).val()) {
            case 'amex':
                creditcard.unmask().mask("9999 999999 99999");
                break;
            default:
                creditcard.unmask().mask("9999 9999 9999 9999");
                break;
        }
    }
  );

});

$.fn.vjustify = function() {
    var maxHeight=0;
    $(".resize").css("height","auto");
    this.each(function(){
        if (this.offsetHeight > maxHeight) {
          maxHeight = this.offsetHeight;
        }
    });
    this.each(function(){
        $(this).height(maxHeight);
        if (this.offsetHeight > maxHeight) {
            $(this).height((maxHeight-(this.offsetHeight-maxHeight)));
        }
    });
};

$.fn.hoverClass = function(classname) {
	return this.hover(function() {
		$(this).addClass(classname);
	}, function() {
		$(this).removeClass(classname);
	});
};
$(document).ready(function () {
		$('#ExistingDepartment').select2({
				placeholder: "---New Department---",
				allowClear: true
		});

		$('#ExistingDepartment').on("change", function (e) { switchInputs(e.val); });
		//$("#Password").valid();
		
		//$("#register-wizard").formwizard({
		//validationEnabled: true,
		//focusFirstInput : true,
		//disableUIStyles: true,
		//validationOptions : {
		//	rules: {
		//			FullName: "required",
		//			UserName: "required",
		//			Password: "required",
		//			ConfirmPassword: {
		//					equalTo: "#Password"
		//		},
		//		Email: { required: true, email: true }
		//	},
		//	messages: {
		//			FullName: "Enter your First and Last name",
		//			UserName: "Enter your desired Username",
		//			Password: "You must enter a password",
		//			ConfirmPassword: { equalTo: "Passwords don't match" },
		//		Email: { required: "Supply your email address", Email: "Correct email format is name@domain.com" }
		//	},
		//	errorLabelContainer: "#errors",
		//	wrapper: "li",
		//	highlight:function(element, errorClass, validClass) {
		//			$(element).parents('.input-group').addClass('has-error');
		//	},
		//	unhighlight: function(element, errorClass, validClass) {
		//			$(element).parents('.input-group').removeClass('has-error');
		//	}
		//}
		//});
		
		function switchInputs(value) {
				if (value) {
						if (value === "---New Department---") {
								$('#newDepartment').show();
								$('#existingDepartment').hide();
						} else {
								$('#newDepartment').hide();
								$('#existingDepartment').show();
						}
				}
		}
});

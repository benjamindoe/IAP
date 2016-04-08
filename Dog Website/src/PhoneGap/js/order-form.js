$(document).ready(function(){
	$.get("breeds.xml", function(data) {
		$breeds = $(data).find("breed");
		$($breeds).each(function(){
			$name = $(this).find("name").html();
			$("#dogName").append("<option value=" + $name.replace(/\s+/g, '_') + ">"+ $name +"</option>");
		});
		$('#dogName').on("change", function(){
			$("#dogColor").empty();
			$selected = $("#dogName").find(":selected").html();
			$colors = $($breeds).find("name:contains(" + $selected + ")").parent().find("color");
			$("#dogColor").append("<option value='' disabled selected>Pick a colour</option>");
			$($colors).each(function(){
				$("#dogColor").append("<option value="+$(this).html().replace(/\s+/g, '_')+">"+$(this).html()+"</option>");
			});
		});
	});
	$("form").on("submit", function(){
		$append = $(" \
			<div class='overlay'> \
				<h1>Order Confirmation</h1> \
				<div class='overlay__content'></div> \
			</div> \
			<div class='overlay--backdrop'></div> \
		");
		$append.find(".overlay__content").append(" \
			<table> \
				<tr><td>Name</td><td>" + $("#firstName").val() + " " + $("#surname").val() +"</td></tr> \
				<tr><td>Email</td><td><a href='mailto:" + $("#email").val() +"'>" + $("#email").val() + "</a></td></tr> \
				<tr><td>Breed</td><td>" + $("#dogColor").find(":selected").text() + " " + $("#dogName").find(":selected").text() +"</td></tr> \
			</table> \
			<button> Confirm </button> \
		");
		$append.hide().fadeIn(300);
		$("body").append($append);
		$(".overlay button").click(function() {
			$(".overlay").remove();
			$(".overlay--backdrop").remove();
		});

		return false;
	});
});
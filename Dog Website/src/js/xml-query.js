$(document).ready(function() {
	$.get("breeds.xml", function(data) {
		$result = $(data).xpath("//breed");
		if($result.length) {
			$result.each(function(i, value) {
				$(".query_output").append($(value).text() + "<br>");
			});
		} else {
			$(".query_output").append("No Results Found.")
		}

	});
});
<!DOCTYPE html>
<html>
	<?php
		$title = "XML Query";
		$headTag = [
			"<script src='js/jquery.xpath.js'></script>",
			"<script src='js/xml-query.js'></script>"
		];
		include "head.php";
	?>
<body>
	<div class="wrapper">
		<?php include "header.php" ?>
		<div class="body">
			<div class="body__content">
				<form id="XML_query_form" action="">
					<label for="q_name">Name</label><input id="q_name" type="text">
					<label for="q_color">Colour</label><input id="q_color" type="text">
					<button>Submit</button>
				</form>
				<div class="query_output">
				</div>
			</div>
			<div class="body__sidebar">
				<div class="ad ad1">
				</div>
				<div class="ad ad2">
				</div>
			</div>
		</div>
	</div>
</body>
</html>
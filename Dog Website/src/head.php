<head>
	<link rel="stylesheet" type="text/css" href="stylesheet.css">
	<title>Buy-a-Dog | <?= $title ?></title>
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<link rel="icon" href="images/favicon.png" type="image/png">
	<script src='js/jquery-1.11.3.min.js'></script>
	<base href="https://udon.ads.ntu.ac.uk/web/soft20181/N0561281/">
	<?php
		if (!isset($headTag)) $headTag = array();
		foreach ($headTag as $tag) {
			echo $tag;
		}
	?>
</head>
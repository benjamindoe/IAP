<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output omit-xml-declaration="yes" method="html"/>
<xsl:template match="/">
	<html>
	<head>
		<base href="https://udon.ads.ntu.ac.uk/web/soft20181/N0561281/"/>
		<link rel="stylesheet" type="text/css" href="stylesheet.css"/>
		<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>
		<style>
			h4 {
				background-color:lightblue;
				margin-bottom:5px;
			}
			.dog {
				padding: 5px;
				border: 1px solid darkblue;
				margin-bottom: 10px;
			}
		</style>
	</head>
	<body>
		<div class="wrapper">
			<header>
				<div class="logo--wrapper">
					<div class="logo">
						<img class="logo__img" src="images/logo.png"/>
						<h1 class="logo__title">Buy-a-Dog</h1>
					</div>
				</div>
				<nav class="header__nav">
					<a href="">Home</a>
					<a href="breeds.xml">Dog Breeds</a>
					<a href="order-page.php">Order Form</a>
					<a href="slideshow.php">Slide Show</a>
					<a href="">Mobile App</a>
					<a href="">Report</a>
				</nav>
			</header>
			<script src="js/header.js"></script>
			<div class="body">
				<div class="body__content">
					<h1>Dog Breeds</h1>
					<xsl:for-each select="dogs/breed">
						<div class="dog">
							<h4>Name</h4>
								<b><xsl:value-of select="name"/></b>
							<h4>Size</h4>
								<xsl:value-of select="size"/>
							<h4>Colours</h4>
									<ul>
										<xsl:for-each select="colors/color">
											<li><xsl:value-of select="."/></li>
										</xsl:for-each>
									</ul>
						</div>
					</xsl:for-each>
				</div>
				<div class="body__sidebar">
					<div class="ad ad1">
					</div>
					<div class="ad ad2">
					</div>
				</div>
			</div>
			<footer>&#169; Benjamin Doe 2015</footer>
		</div>
	</body>
	</html>
</xsl:template>

</xsl:stylesheet>
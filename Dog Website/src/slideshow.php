<!DOCTYPE html>
<html>
	<?php

		$title = "Slideshow";
		$headTag = [
		"<script src='js/realslides.js'></script>"
		];
		include "head.php";
	?>
	<body>
		<div class="wrapper">
			<?php include "header.php"; ?>
			<div class="body">
				<div class="body__content">
					<div class="slideshow">
						<div class="slideshow__inner">
							<div class="next-slide btn-slide btn">Next</div>
							<div class="prev-slide btn-slide btn">Previous</div>
							<div class="slideshow__window">
								<div class="slides">
									<figure class="slide">
										<img src="images/chocLab-puppy.jpg" id="ChocLab" class=" slide__img puppy active">
										<figcaption>Chocolate Lab</figcaption>
									</figure>
									<figure class="slide">
										<img src="images/goldLab-puppy.jpg" id="GoldLab"  class=" slide__img puppy">
										<figcaption>Golden Lab</figcaption>
									</figure>
									<figure class="slide">
										<img src="images/westie-puppy.jpg" id="Westie" class=" slide__img puppy">
										<figcaption>West Highland Terrier</figcaption>
									</figure>
									<figure class="slide">
										<img src="images/beagle-puppy.jpg" id="Beagle" class=" slide__img puppy">
										<figcaption>Beagle</figcaption>
									</figure>
									<figure class="slide">
										<img src="images/pug-puppy.jpg" id="Pug" class=" slide__img puppy">
										<figcaption>Pug</figcaption>
									</figure>
								</div>
							</div>
						</div>
						<div class="slideshow__footer">
							<div class="grow btn">Grow</div>
							<div class="thumbnail--window">
								<div class="thumbnail--slider"></div>
							</div>
						</div>
					</div>
				</div>
				<div class="body__sidebar">
					<div class="ad ad1">
					</div>
					<div class="ad ad2">
					</div>
				</div>
			</div>
			<?php include "footer.php" ?>
		</div>
	</body>
</html>
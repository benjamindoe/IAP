<!DOCTYPE html>
<html>
	<?php

		$title = "Order Form";
		$headTag = [
			"<script src='js/order-form.js'></script>"
		];
		include "head.php";
	?>
	<body>
		<div class="wrapper">
			<?php include "header.php"; ?>
			<div class="body">
				<div class="body__content">
					<form>
						<fieldset>
							<legend>Order a Dog</legend>
							<input type="text" name="firstName" id="firstName" placeholder="First Name" required>
							<input type="text" name="surname" id="surname" placeholder="Surname" required>
							<input type="email" name="email" id="email" placeholder="example@email.com" required>
							<select name="dogname" id="dogName" required>
								<option disabled selected value="">Select a breed</option>
							</select>
							<select name="dogcolor" id="dogColor" required>
								<option disabled selected value="">Select a color</option>
							</select>
							<input type="submit" value="Order">
						</fieldset>
					</form>
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

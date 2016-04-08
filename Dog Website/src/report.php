<!DOCTYPE html>
<html>
	<?php 
		$title = "Report";
		$headTag = [
		];
		include "head.php";
	?>
	<body>
		<div class="wrapper">
			<?php include "header.php"; ?>
			<div class="body">
				<div class="body__content">
I declare that the website I have constructed is of my own work and design. Where I have used external libraries and code from other sources, sources have been acknowledged. The mobile app is based on the original desktop site, which is also responsive, with a few pages omitted that either doesn’t function correctly or it doesn’t apply to the mobile application, such as the XML page.
<br><br>
I began by creating an empty HTML5 skeleton. From the frame I created a simple PHP template where I separated the head tag from the main body into its own file. To include extra head tags, I added a PHP array that the head tag can include and echoes any tag in the array into the head tag. I also added a variable called title that sets the title tag.
To create a web page using my simple template, start by creating an empty PHP file, such as index.php. Next, add the html tag. Include the head.php file. I have also created a PHP file called header.php. This includes the HTML and JavaScript that displays the header and makes the navigation menu stick to the top of the browser window when the window scrolls.
<br><br>
In the order form page, I have incorporated the XML page by selecting the breed names and their respective colours. The results are put into two select boxes. When the breed is picked, the second select box is populated by JavaScript using the selected option to get the colour options from the XML file. HTML5 has in-built validation, for example, an attribute can be set on the input tag. The type attribute can be set to email and it is automatically validated. HTML5 checks for the input tag being empty and that the input string contains an &#64; symbol. The order page also contains a reCaptcha from Google that sends a true/false data to the backend telling the server whether the captcha failed or not. I have previously used a captcha successfully in a past project. The reCaptcha is included using a key so that Google can verify the client that is requesting to use the plug-in. There is also a method that has a nojavascript fallback that Google has developed that uses checking an image rather than ticking an &ldquo;I am not a robot&rdquo; checkbox that requires JavaScript.
<br><br>
The XML page is styled using XSLT as well as CSS since XSLT converts XML to HTML the same CSS used by the rest of the site can be also used for the XML page. I also added the HTML for the header from the template to the XSLT so that it fits in with the style of the rest of the website. The header.js file is also added into the XSLT document and keeps the navigation bar sticky when the window scrolls.
<br><br>
The website is styled using one CSS file. There are two ways to approach styling a website and including the files. Either split the CSS into multiple files to keep the code separated and clean. The other way is to have all of the code in one file. The multiple files approach is far better while developing the site however for a release version the CSS is better in one file to reduce HTTP requests so that the page loads faster for the client. This is also why having a sprite image for the slideshow icons. Usually the browser automatically caches images that are loaded to a page. So then rather than loading multiple images for each icon, all there is to do is reposition it with CSS.
<br><br>
The navigation menu had to be resdesigned for the mobile view. I collapsed it behind the before pseudoelement for the nav tag which has a hamburger menu icon on it. There is some JavaSript that triggers when the user clicks on the hamburger and adds a class to the nav tag so that styling applies to the nav so that it displays the navigation menu in a horizontal list.
<br><br>
I had some trouble converting the standard site into the PhoneGap phone application because of the jQuery Mobile's AJAX request didn't work if any extra script tags were in the header tag. The problem was that the AJAX was loading only the body tag so wouldn't update the head. Also, the jQuery Mobile CSS ruined the text a little bit because it added texxt shadows and other extra stylings that ruined the website design. I had to add extra CSS to the main CSS file that styles the website. 
<br><br>
The slideshow has the caption on the image because of the way I originally designed it. When I designed the slideshow I hadn't included a space for a caption so when I wanted to adapt it to add a caption I made a small black box and had the caption in there which still gives the slideshow a professional and stylish feel. The app version of the slideshow utilises the swipe that jQuery mobile offers so the user can swipe the image to change the image.
<br><br>
The sidebar is meant to show some advertisments about subjects related to the website such as an animal rescue shelter or the RSPCA. I have used example adverts that Google have provided from their AdSense program. The sidebar contains two advertisements that are on top of each other and are the standard 250x250px size. The sidebar moves beneath the content as the screen gets too small for the sidebar to stay on the side and keep the site usable. When on the mobile site and the sidebar is below the content, they are resized to 150x15px so that they can be displayed side by side. This might mean that the space is insuffciant for the Terms and Conditions from advertisement companies such as AdSense.
<br><br>
On the UDON server, I was unable to link the APK file using an a tag. I assume this is because that the website has some sort of hotlink disabling for certain filetypes.
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
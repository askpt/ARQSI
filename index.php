<!-- includes -->
<?php 
	include("PHP/DAL.php");
?>

<!DOCTYPE html>
<html>
<head>
	<script type="text/javascript" src="JAVASCRIPT/library.js"></script>
	<script type="text/javascript" src="JAVASCRIPT/ListCategories.js"></script>
	<script type="text/javascript" src="JAVASCRIPT/ListBooksByCategory.js"></script>
	<script type="text/javascript" src="JAVASCRIPT/ListNBooks.js"></script>
</head>

<?php

	include("PHP/Authentication.php");
	echo "<br><br>Welcome ".$_SESSION['susername'];

	include("PHP/Navigation.php");
?>


<body onload="ListCategories();">
	<h1>It works!</h1>
	<p>This is the default web page for this server.</p>
	<p>The web server software is running but no content has been added, yet.</p>
	<div>
		<select id="scategories" onchange="ListBooksByCategory();">
			<!-- local where categories will be loaded -->
		</select>
		<input id="tnumberbooks" size="3" type="number"/>
		<table id="tbooks">
			<!-- local where books will be loaded -->
		</table>
		<form method="get" action="" onsubmit="return GetNBooks();">
			<select id="seditors">
				<option>Editora 1</option>
				<option>Editora 2</option>
			</select>
			<input id="tnumber" size="3" type="number"/>			

			<input value="Send" type="submit"/>
			<div id="dbooks">	
				<!-- local where books will be loaded -->
			</div>
		</form>
	</div>
</body>
</html>

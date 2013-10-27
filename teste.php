<!-- includes -->
<?php 
	include("PHP/DAL.php");
?>


<?php

	include("PHP/Authentication.php");


	echo "HOMEPAGE";
	echo "<br><br>User: ".$_SESSION['susername'];

	include("PHP/Navigation.php");


?>
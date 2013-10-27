<?php 
	session_start(); 
	session_destroy(); 

	echo "User ".$_SESSION['susername']." is logging out...";

	// replace URL for index.php later on
	echo "<br><br> You're now being redirected to Login page. <META HTTP-EQUIV=\"refresh\" content=\"2; URL=../index.php\"> "; 
?> 
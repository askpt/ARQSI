<?php // necessary include to work with database
	include ("DAL.php");
?>

<?php
	// data necessary to updload into DB
	// username
	$userName = $_SESSION['susername'];
	
	// current date
	$dateTime = new DateTime();
	$dateTimeFormatted = $dateTime->format('Y-m-d H:i:s');

	// requested url
	$url = $_SERVER["REQUEST_URI"];

	// saving request in DB
	$dal = new DAL();
	$conn = $dal->connect();
	$dal->selectDB($conn);

	// getting user id
	$stat = "select id from users where name='".$userName."';";
	$result = $dal->executeQuery($stat);
	$userId = mysql_result($result, 0, "id");
	mysql_free_result($result);

	// inserting info into table requests
	$stat = "insert into requests(iduser,time,url) VALUES ('".$userId."','".$dateTimeFormatted."','".$url."');";
	$result = $dal->executeQuery($stat);
	mysql_free_result($result);

	// getting id of this new record
	$stat = "select * from requests ORDER BY id DESC LIMIT 1;";
	$result = $dal->executeQuery($stat);
	$requestId = mysql_fetch_row($result);
	mysql_free_result($result);

	// feedback to user
	echo "<br><br>Your request was saved with the ID of <b>".$requestId[0]."</b> and date of <b>".$requestId[2]."</b>.";

	$dal->close();

	// test
	/*
	echo "<br><br>Username ".$userName;
	echo "<br><br>URL: ".$url;
	echo "<br><br>Date: ".$dateTimeFormatted;
	echo "<br><br>Statement: ".$stat;
	echo "<br><br>Statement: ".$stat2;
	echo "<br><br>UserID: ".$userId;
	echo "<br><br>Request ID: ".$requestId[0];
	*/
?>
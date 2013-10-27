<?php
	session_start();

	// test only!
	/*
	$_SESSION['susername'] = "admin";
	$_SESSION['spassword'] = "admin";
	*/

	if($_POST)
	{
		$_SESSION['susername'] = $_POST['tusername'];
		$_SESSION['spassword'] = $_POST['tpassword'];
	}

	if($_GET)
	{
		$_SESSION['susername'] = "user";
		$_SESSION['spassword'] = "pass";
	}

	// connecting to BD
	$dal = new DAL();
	$conn = $dal->connect();
	$dal->selectDB($conn);

	// querying DB
	$stat = "select * from users where name='".$_SESSION['susername']."' and password='".$_SESSION['spassword']."';";
	//echo("$stat");
	$result = $dal->executeQuery($stat); 
	$num = $dal->totalRowCount($result);
	//echo("<br>$num");
	// if results < 1 then we don't have a user-pass match
	if($num < 1)
	{
		//echo("user does not exist");

// closing php tag to start HTML code
?>
	<form method="POST" action="index.php">
		Username: <input type="text" name="tusername">
		<br>
		Password: <input type="password" name="tpassword">
		<br><br>
		<input type="submit" value="LOGIN!">
		<input type="reset" value="Clear">
	</form>

<?php // opening php tag to resume PHP code

		// exit to avoid showing the rest of index.php when user is not logged in
		exit;
	}

	$dal->close();
?>
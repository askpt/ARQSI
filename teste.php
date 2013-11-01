<?php
	
	/*
	* a debug file to test Editora3.php adapter
	*/
	

	include("PHP/Editora2.php");
	include("PHP/Editora3.php");

	$editor2 = new Editora2();
	$editor3 = new Editora3();

/*
	echo "<br>antes<br>";

	$temp = $editor2->GetCategories();

	var_dump($temp);

	echo "<br>depois<br>";


	echo "<br>Editora3<br>";

	$temp2 = $editor3->GetCategories();

	var_dump($temp2);

	echo "<br>depois<br>";
*/

/*
	echo "<br>antes<br>";

	$temp = $editor2->GetBooksByCategory("Romance");

	var_dump($temp);

	echo "<br>depois<br>";


	echo "<br>Editora3<br>";

	$temp2 = $editor3->GetBooksByCategory("Romance");

	var_dump($temp2);

	echo "<br>depois<br>";
*/

/*
	echo "<br>antes<br>";

	$temp = $editor2->GetNBooks(3);

	var_dump($temp);

	echo "<br>depois<br>";


	echo "<br>Editora3<br>";

	$temp2 = $editor3->GetNBooks(3);

	var_dump($temp2);

	echo "<br>depois<br>";
*/

	echo "<br>antes<br>";

	$temp = $editor2->GetBook("Os Maias");

	var_dump($temp);

	echo "<br>depois<br>";


	echo "<br>Editora3<br>";

	$temp2 = $editor3->GetBook("Os Maias");

	var_dump($temp2);

	echo "<br>depois<br>";

?>
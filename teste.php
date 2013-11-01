<?php
	include("PHP/Editora2.php");
	include("PHP/Editora3.php");

	$editor2 = new Editora2();
	$editor3 = new Editora3();

	echo "<br>antes<br>";

	$temp = $editor2->GetCategories();

	var_dump($temp);

	echo "<br>depois<br>";


	echo "<br>Editora3<br>";

	$temp2 = $editor3->GetCategories();

	var_dump($temp2);

	echo "<br>depois<br>";



?>
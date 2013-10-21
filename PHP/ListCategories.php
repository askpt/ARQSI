<?php 
	$editor = $_GET['editor'];

	$response_xml = file_get_contents("http://phpdev2.dei.isep.ipp.pt/~arqsi/trabalho1/".$editor.".php?categoria=todas ");

	echo "$response_xml";

 ?>
<?php

	header('Content-type: text/xml; charset=utf-8');
	echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
	$editor = $_GET['editor'];
	echo "<editoras>";
	$response_xml .= file_get_contents("http://phpdev2.dei.isep.ipp.pt/~arqsi/trabalho1/editora1.php?categoria=todas ");

	$response_xml .= file_get_contents("http://phpdev2.dei.isep.ipp.pt/~arqsi/trabalho1/editora2.php?categoria=todas ");

	echo $response_xml;
	echo "</editoras>"

 ?>
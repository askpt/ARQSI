<?php

	header('Content-type: text/xml; charset=utf-8');
	echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
	$editor = $_GET['editor'];

	$response_xml .= file_get_contents("http://phpdev2.dei.isep.ipp.pt/~arqsi/trabalho1/".$editor.".php?categoria=todas ");

	echo $response_xml;

 ?>
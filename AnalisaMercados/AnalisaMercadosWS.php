<?php
	require_once('nusoap.php');

	$server = new soap_server();

	$server->configureWSDL('AnalisaMercadosWS', 'urn:AnalisaMercadosWS');
	$server->soap_defencoding = 'UTF-8';

	$in = array('price' => 'xsd:float');

	$out = array('return' => 'xsd:float');

	$server->register('AnalisaMercados', 
		$in, 
		$out, 
		'urn:AnalisaMercadosWS', 
		'urn:AnalisaMercadosWS/AnalisaMercados',
		'rpc',
		'encoded'
	);

	function AnalisaMercados($price)
	{
		$flag = rand(0,1);
		if ($flag == 1) 
		{
			return $price * 0.99;		
		}
		else
		{
			return $price;
		}
	}

	$HTTP_RAW_POST_DATA = isset($HTTP_RAW_POST_DATA) ? $HTTP_RAW_POST_DATA : '';
	$server->service($HTTP_RAW_POST_DATA);


 ?>
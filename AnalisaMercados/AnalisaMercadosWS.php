<?php
	require_once('nusoap.php');

	$server = new soap_server();

	$server->configureWSDL('AnalisaMercadosWS', 'urn:AnalisaMercadosWS');
	$server->soap_defencoding = 'UTF-8';

	$in = array('ISBN' => 'xsd:int',
				'price' => 'xsd:float'
				);

	$out = array('return' => 'xsd:float');

	$server->register('AnalisaMercados', 
		$in, 
		$out, 
		'urn:AnalisaMercadosWS', 
		'urn:AnalisaMercadosWS/AnalisaMercados',
		'rpc',
		'encoded'
	);

	function ModifiedPrice($price)
	{
		$discounts = array('0' => 0.95, 
						   '1' => 0.90,
						   '2' => 0.85,
						   '3' => 0.80,
						   '4' => 0.75);
		$dis_ind = rand(0,4);
		return $price * $discounts[$dis_ind];
	}

	function AnalisaMercados($ISBN, $price)
	{
		$flag = rand(0,1);
		if ($flag == 1) 
		{
			return ModifiedPrice($price);
		}
		else
		{
			return $price;
		}
	}

	$HTTP_RAW_POST_DATA = isset($HTTP_RAW_POST_DATA) ? $HTTP_RAW_POST_DATA : '';
	$server->service($HTTP_RAW_POST_DATA);


 ?>
<?php
	require_once('nusoap.php');

	$server = new soap_server();

	$server->configureWSDL('ShippingAllWS', 'urn:ShippingAllWS');
	$server->soap_defencoding = 'UTF-8';

	$in = array('quantity' => 'xsd:int', 
				'type' => 'xsd:string');

	$out = array('price' => 'xsd:float');

	$server->register('GetShippingCosts', 
		$in, 
		$out, 
		'urn:ShippingAllWS', 
		'urn:ShippingAllWS/GetShippingCosts',
		'rpc',
		'encoded'
	);

	function GetShippingCosts($quantity, $type)
	{
		if ($quantity < 0) {
			return -1;
		}

		if ($type == 'National') {
			return $quantity * 0.5;
		}
		if ($type == 'National Urgent') {
			return $quantity * 0.75;
		}
		if ($type == 'International') {
			return $quantity * 1.5;
		}
		if ($type == 'International Urgent') {
			return $quantity * 5.0;
		}

		return -1;
	}

	$HTTP_RAW_POST_DATA = isset($HTTP_RAW_POST_DATA) ? $HTTP_RAW_POST_DATA : '';
	$server->service($HTTP_RAW_POST_DATA);


 ?>
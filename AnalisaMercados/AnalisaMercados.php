<?php
require_once('nusoap.php');

$server = new soap_server();
$server->soap_defencoding = 'UTF-8';

$server->configureWSDL('MarketAnalyzesWS', 'urn:MarketAnalyzesWS');

$in = array('idBook' => 'xsd:int', 
			'title' => 'xsd:string',
			'price' => 'xsd:float');

$out = array('return' => 'xsd:float');

$server->register('MarketAnalyzesWS',
	$in,
	$out,
	'urn:MarketAnalyzesWS', 
	'urn:MarketAnalyzesWS/MarketAnalyzes',
	'rpc', 
	'encoded'
);



function MarketAnalyzes($id, $name, $price) {
	$flag = mt_rand(0, 1); //flag serve para saber se há ou nao alteraçoes no preço dos livros
	if ($flag == 1) {	//Actualiza
			$finalPrice = $price *0.99;
		}else{
			$finalPrice = -1;
		}

return $finalPrice;
}

$HTTP_RAW_POST_DATA = isset($HTTP_RAW_POST_DATA) ? $HTTP_RAW_POST_DATA : '';
$server->service($HTTP_RAW_POST_DATA);

?>
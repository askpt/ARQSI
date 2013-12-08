<?php 

require_once ('nusoap.php');

$ns="urn:AnalisaMercadosWS";

$client = new soapclient('http://uvm061.dei.isep.ipp.pt/~askpt/ARQSI/AnalisaMercados/AnalisaMercadosWS.php?wsdl');

$result = $client->AnalisaMercados(2);

echo "$result";

 ?>
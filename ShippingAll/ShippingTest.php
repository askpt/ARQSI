<?php 

require_once ('nusoap.php');

$ns="urn:ShippingAllWS";

$client = new soapclient('http://uvm061.dei.isep.ipp.pt/~askpt/ARQSI/ShippingAll/ShippingAllService.php?wsdl');

$result = $client->GetShippingCosts(2, "National");

echo "$result";

 ?>
<!DOCTYPE hmtl>
<html>
<head>
	<title>Book</title>
	<meta http-equiv="Content-Type" content="text/html;charset=utf-16" >
</head>
<body>
<?php 

session_start();

include("Navigation2.php");

function SendRequest( $url, $method = 'GET', $data = array(), $headers = array('Content-type: application/x-www-form-urlencoded') )
{
	$context = stream_context_create(array
	(
		'http' => array(
			'method' => $method,
			'header' => $headers,
			'content' => http_build_query( $data )
		)
	));
 
	return file_get_contents($url, false, $context);
}

$title = $_REQUEST['title'];
$editor = $_REQUEST['editor'];

$response_xml = SendRequest("http://uvm061.dei.isep.ipp.pt/~joao/ARQSI/PHP/EditorAPI.php", 'POST', array('type' => 'GetBook', 'title' => $title, 'editor' => $editor));

$array = array();
$xmlparser = xml_parser_create();
$isbn;

xml_parse_into_struct($xmlparser, $response_xml, $values);

for ($i=0; $i < count($values); $i++) { 
	if ($values[$i]["tag"] == "TITLE") {
		echo "<p>title " . $values[$i]["value"];
	}
	if ($values[$i]["tag"] == "AUTHOR") {
		echo "<p>author " . $values[$i]["value"];
	}
	if ($values[$i]["tag"] == "CATEGORY") {
		echo "<p>CATEGORY " . $values[$i]["value"];
	}
	if ($values[$i]["tag"] == "ISBN") {
		echo "<p>ISBN " . $values[$i]["value"];
		$isbn = $values[$i]["value"];
	}
	if ($values[$i]["tag"] == "PUBLICACAO") {
		echo "<p>PUBLICACAO " . $values[$i]["value"];
	}
}

$title = str_replace(" ", "+", $_GET["title"]);
   
$response_json = file_get_contents("https://www.googleapis.com/books/v1/volumes?q=isbn:" . $isbn);
$object = json_decode($response_json,true);

echo "<p>Descri&ccedil;&atilde;o: " . $object["items"][0]["volumeInfo"]["description"];
    echo "<p>Imagem: <img src=\"" . $object["items"][0]["volumeInfo"]["imageLinks"]["thumbnail"] . "\"></img>";

// this include will load the script responsible to save user request to database
include("SaveRequest.php");

 ?>
</body>
</html>
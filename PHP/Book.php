<!DOCTYPE hmtl>
<html>
<head>
	<title>Book</title>
</head>
<body>
<?php 

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

$response_xml = SendRequest("http://uvm061.dei.isep.ipp.pt/~askpt/ARQSI/PHP/EditorAPI.php", 'POST', array('type' => 'GetBook', 'title' => $title, 'editor' => $editor));

echo $response_xml;


 ?>
</body>
</html>
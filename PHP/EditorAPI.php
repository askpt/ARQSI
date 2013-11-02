<?php

include 'DBLayer.php';
include 'Editora1.php';
include 'Editora2.php';
include 'Editora3.php';

$editors = array('Editora 1' => new Editora1(), 'Editora 2' => new Editora2(), 'Editora 3' => new Editora3());

function GetCategories()
{
	global $editors;

	$categories = array();

	foreach ($editors as $key => $value) {
		$categories = array_merge($categories, $value->GetCategories());
	}

	$categories	= array_unique($categories);

	header('Content-type: text/xml; charset=ISO-8859-1');
	echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
	echo "<categorias>";
	foreach ($categories as $key => $value) {
		echo "<categoria>$value</categoria>";
	}
	
	echo "</categorias>";

}

function GetBooksByCategory($category)
{
	global $editors;

	header('Content-type: text/xml; charset=ISO-8859-1');
	echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
	echo "<books>";	
	foreach ($editors as $key => $value) {
		echo "<editor>";
		echo $key;
		echo $value->GetBooksByCategory($category);
		echo "</editor>";
	}
	echo "</books>";
}

function GetNBooks($editor, $number)
{
	global $editors;

	header('Content-type: text/xml; charset=ISO-8859-1');
	echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
	echo "<books>";
	echo $editors[$editor]->GetNBooks($number);
	echo "</books>";
}

function GetBook($book, $editor)
{
	global $editors;

	header('Content-type: text/xml; charset=ISO-8859-1');
	echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
	echo "<books>";
	echo $editors[$editor]->GetBook($book);
	echo "</books>";
}

function GetEditors()
{
	global $editors;

	header('Content-type: text/xml; charset=ISO-8859-1');
	echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
	echo "<editors>";
	foreach ($editors as $key => $value) {
		echo "<editor>" . $key . "</editor>";
	}
	echo "</editors>";
}

function Error()
{
	echo "Request Failed";
}


function saveCategoryRequest($category)
{
	// current date
	$dateTime = new DateTime();
	$dateTimeFormatted = $dateTime->format('Y-m-d H:i:s');

	// saving request in DB
	$dal = new DBLayer();
	$conn = $dal->connect();
	$dal->selectDB($conn);

	// inserting info into table requests
	$stat = "insert into CATEGORY_REQUEST(timeStamp, category) VALUES ('".$dateTimeFormatted."','".$category."');";
	$result = $dal->executeQuery($stat);
	mysql_free_result($result);

	$dal->close();
}


function saveBookRequest($book, $editor)
{
	// current date
	$dateTime = new DateTime();
	$dateTimeFormatted = $dateTime->format('Y-m-d H:i:s');

	// saving request in DB
	$dal = new DBLayer();
	$conn = $dal->connect();
	$dal->selectDB($conn);

	// inserting info into table requests
	$stat = "insert into BOOK_REQUEST(timeStamp, bookTitle, editorName) VALUES ('".$dateTimeFormatted."','".$book."','".$editor."');";
	$result = $dal->executeQuery($stat);
	mysql_free_result($result);

	$dal->close();
}


function saveEditorRequest($editor, $number)
{
	// current date
	$dateTime = new DateTime();
	$dateTimeFormatted = $dateTime->format('Y-m-d H:i:s');

	// saving request in DB
	$dal = new DBLayer();
	$conn = $dal->connect();
	$dal->selectDB($conn);

	// inserting info into table requests
	$stat = "insert into EDITOR_REQUEST(timeStamp, editorName, requestedBooks) VALUES ('".$dateTimeFormatted."','".$editor."','".$number."');";
	$result = $dal->executeQuery($stat);
	mysql_free_result($result);

	$dal->close();
}

$type = $_REQUEST['type'];

switch ($type) {
	case 'GetAllCategories':
	GetCategories();
	break;

	case 'GetBooksByCategory':
	$category = $_REQUEST['category'];
	//saving to DB
	saveCategoryRequest($category);
	GetBooksByCategory($category);
	break;

	case 'GetNBooks':
	$editor = $_REQUEST['editor'];
	$number = $_REQUEST['number'];
	// saving to DB
	saveEditorRequest($editor, $number);
	GetNBooks($editor, $number);
	break;

	case 'GetBook':
	$book = $_REQUEST['title'];
	$editor = $_REQUEST['editor'];
	// saving to DB
	saveBookRequest($book, $editor);
	GetBook($book, $editor);
	break;

	case 'GetEditors':
	GetEditors();
	break;

	default:
	Error();
	break;
}

?>
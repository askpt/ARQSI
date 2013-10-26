<?php

include 'Editora1.php';
include 'Editora2.php';

$editors = array('Editora 1' => new Editora1(), 'Editora 2' => new Editora2());

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
	for ($i=0; $i < count($categories); $i++) { 
		echo "<categoria>$categories[$i]</categoria>";
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
		echo $categories, $value->GetBooksByCategory($category);
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

function Error()
{
	echo "Request Failed";
}

$type = $_REQUEST['type'];

switch ($type) {
	case 'GetAllCategories':
	GetCategories();
	break;

	case 'GetBooksByCategory':
	$category = $_REQUEST['category'];
	GetBooksByCategory($category);
	break;

	case 'GetNBooks':
	$editor = $_REQUEST['editor'];
	$number = $_REQUEST['number'];
	GetNBooks($editor, $number);
	break;

	case 'GetBook':
	$book = $_REQUEST['title'];
	$editor = $_REQUEST['editor'];
	GetBook($book, $editor);
	break;

	default:
	Error();
	break;
}

?>
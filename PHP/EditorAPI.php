<?php

include 'Editora1.php';
include 'Editora2.php';

$editor1 = new Editora1();
$editor2 = new Editora2();

function GetCategories()
{
	global $editor1;
	global $editor2;

	$categories = array();

	$categories = array_merge($categories, $editor1->GetCategories());
	$categories = array_merge($categories, $editor2->GetCategories());

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
	global $editor1;
	global $editor2;

	header('Content-type: text/xml; charset=ISO-8859-1');
	echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
	echo "<books>";	
	echo $editor1->GetBooksByCategory($category);
	echo $editor2->GetBooksByCategory($category);
	echo "</books>";
}

function GetNBooks($editor, $number)
{
	global $editor1;
	global $editor2;

	header('Content-type: text/xml; charset=ISO-8859-1');
	echo "<?xml version='1.0' encoding='ISO-8859-1'?>";
	echo "<books>";
	switch ($editor) {
		case 'Editora1':
		echo $editor1->GetNBooks($number);
		break;
		case 'Editora2':
		echo $editor2->GetNBooks($number);
		break;

		default:
		echo "editor not found";
		break;
	}	
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

	default:
	Error();
	break;
}

?>
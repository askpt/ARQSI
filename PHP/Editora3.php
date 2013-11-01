<?php

/**
 * Editora3
 *	this class deals with Editora3 webservice, receiving JSON data from there and in turn responding 
 * 	with xml
 */

class Editora3
{
	private static $name = "Editora3";
	private static $allCategoriesUrl = "http://uvm061.dei.isep.ipp.pt/~joao/ARQSI/EDITORA3/Editora3.php?categoria=todas";
	private static $booksByCategoryUrl = "http://uvm061.dei.isep.ipp.pt/~joao/ARQSI/EDITORA3/Editora3.php?categoria=";
	private static $firstNBooksUrl = "http://uvm061.dei.isep.ipp.pt/~joao/ARQSI/EDITORA3/Editora3.php?numero=";
	private static $specificBookUrl = "http://uvm061.dei.isep.ipp.pt/~joao/ARQSI/EDITORA3/Editora3.php?titulo=";

	public function GetCategories()
	{
  		$requestJson = file_get_contents(self::$allCategoriesUrl);
		$returnArray = json_decode($requestJson,true);
  		return $returnArray;
	}

	
}


?>
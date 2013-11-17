<?php

/**
 * Editora3
 *	this class deals with Editora3 webservice, receiving JSON data from there and in turn responding 
 * 	with xml
 */

class Editora3
{
	private $name = "Editora3";
	private static $allCategoriesUrl = "http://uvm061.dei.isep.ipp.pt/EDITORA3/Editora3.php?categoria=todas";
	private static $booksByCategoryUrl = "http://uvm061.dei.isep.ipp.pt/EDITORA3/Editora3.php?categoria=";
	private $firstNBooksUrl = "http://uvm061.dei.isep.ipp.pt/EDITORA3/Editora3.php?numero=";
	private $specificBookUrl = "http://uvm061.dei.isep.ipp.pt/EDITORA3/Editora3.php?titulo=";


	public function GetCategories()
	{
  		$requestJson = file_get_contents(self::$allCategoriesUrl);
		$returnArray = json_decode($requestJson,true);
  		return $returnArray;
	}


	public function GetBooksByCategory($category)
	{
		$requestJson = file_get_contents(self::$booksByCategoryUrl.$category);
		$jsonDecoded = json_decode($requestJson,true);
		$responseXml = "";
		
		foreach ($jsonDecoded as $key => $value) 
		{
			$responseXml .= "<book>";
			if(is_array($jsonDecoded))
			{
				foreach ($value as $key2 => $value2) 
				{
					$responseXml .= "<".$key2.">".$value2."</".$key2.">";
				}
			}
			$responseXml .= "</book>";
		}

		return $responseXml;
	}


	public function GetNBooks($number)
	{
		$requestJson = file_get_contents($this->firstNBooksUrl.$number);
		$jsonDecoded = json_decode($requestJson,true);
		$responseXml = "";
		
		foreach ($jsonDecoded as $key => $value) 
		{
			$responseXml .= "<book>";
			if(is_array($jsonDecoded))
			{
				foreach ($value as $key2 => $value2) 
				{
					$responseXml .= "<".$key2.">".$value2."</".$key2.">";
				}
			}
			$responseXml .= "</book>";
		}

		return $responseXml;
	}


	public function GetBook($title)
	{
		$url = $this->specificBookUrl.$title;
		$url = str_replace(' ', '%20', $url);
		$requestJson = file_get_contents($url);
		$jsonDecoded = json_decode($requestJson,true);
		$responseXml = "";
		
		foreach ($jsonDecoded as $key => $value) 
		{
			$responseXml .= "<book>";
			if(is_array($jsonDecoded))
			{
				foreach ($value as $key2 => $value2) 
				{
					$responseXml .= "<".$key2.">".$value2."</".$key2.">";
				}
			}
			$responseXml .= "</book>";
		}

		return $responseXml;
	}


	public function getterNBooks()
	{
		return $this->firstNBooksUrl;
	}

	public function getterBook()
	{
		return $this->specificBookUrl;
	}
}

?>
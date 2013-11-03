<?php

/**
 * Editora3
 *	this class deals with Editora3 webservice, receiving JSON data from there and in turn responding 
 * 	with xml
 */

class Editora3 implements Persistence
{
	private $name = "Editora3";
	private static $allCategoriesUrl = "http://uvm061.dei.isep.ipp.pt/~joao/ARQSI/EDITORA3/Editora3.php?categoria=todas";
	private static $booksByCategoryUrl = "http://uvm061.dei.isep.ipp.pt/~joao/ARQSI/EDITORA3/Editora3.php?categoria=";
	private $firstNBooksUrl = "http://uvm061.dei.isep.ipp.pt/~joao/ARQSI/EDITORA3/Editora3.php?numero=";
	private $specificBookUrl = "http://uvm061.dei.isep.ipp.pt/~joao/ARQSI/EDITORA3/Editora3.php?titulo=";


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


	// implementing interface methods

	public function saveBookRequest($book)
	{
		// current date
		$dateTime = new DateTime();
		$dateTimeFormatted = $dateTime->format('Y-m-d H:i:s');

		// saving request in DB
		$dal = new DBLayer();
		$conn = $dal->connect();
		$dal->selectDB($conn);

		$editor = $this->name;
		$url = $this->specificBookUrl.$book;

		// inserting info into table requests
		$stat = "insert into BOOK_REQUEST(timeStamp, bookTitle, editorName, urlPath) VALUES ('".$dateTimeFormatted."','".$book."','".$editor."','".$url."');";
		$result = $dal->executeQuery($stat);
		mysql_free_result($result);

		$dal->close();
	}

	public function saveEditorRequest($number)
	{
		// current date
		$dateTime = new DateTime();
		$dateTimeFormatted = $dateTime->format('Y-m-d H:i:s');

		// saving request in DB
		$dal = new DBLayer();
		$conn = $dal->connect();
		$dal->selectDB($conn);

		$editor = $this->name;
		$url = $this->firstNBooksUrl.$number;

		// inserting info into table requests
		$stat = "insert into EDITOR_REQUEST(timeStamp, editorName, requestedBooks, urlPath) VALUES ('".$dateTimeFormatted."','".$editor."','".$number."','".$url."');";
		$result = $dal->executeQuery($stat);
		mysql_free_result($result);

		$dal->close();
	}
}

?>
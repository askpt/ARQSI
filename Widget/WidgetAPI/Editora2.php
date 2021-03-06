<?php 

/**
* 
*/
class Editora2
{
	private $name = "Editora2";
	private static $all_categories = "http://phpdev2.dei.isep.ipp.pt/~arqsi/trabalho1/editora2.php?categoria=todas";
	private static $books_by_category = "http://phpdev2.dei.isep.ipp.pt/~arqsi/trabalho1/editora2.php?categoria=";
	private $n_books = "http://phpdev2.dei.isep.ipp.pt/~arqsi/trabalho1/editora2.php?numero=";
	private $book = "http://phpdev2.dei.isep.ipp.pt/~arqsi/trabalho1/editora2.php?titulo=";


	public function GetCategories()
	{
		$return_array = array();

		$xmlparser = xml_parser_create();

		$response_xml = file_get_contents(self::$all_categories);
		xml_parse_into_struct($xmlparser,$response_xml,$values);

		for ($i=0; $i < count($values); $i++) { 
			if ($values[$i]["tag"] == "CATEGORIA") {
				array_push($return_array, $values[$i]["value"]);
			}
		}

		return $return_array;
	}


	public function GetBooksByCategory($category)
	{

		$url = self::$books_by_category. $category;


		$response_xml = file_get_contents($url);
		
		return $response_xml;
	}

	public function GetNBooks($number)
	{
		$url = $this->n_books . $number;

		$response_xml = file_get_contents($url);

		return $response_xml;
	}

	public function GetBook($title)
	{
		$url = $this->book . $title;

		$url = str_replace(' ', '%20', $url);

		$response_xml = file_get_contents($url);

		return $response_xml;
	}

	public function getterNBooks()
	{
		return $this->n_books;
	}

	public function getterBook()
	{
		return $this->book;
	}

}


?>
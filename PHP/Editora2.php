<?php 

/**
* 
*/
class Editora2 implements Persistence
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
		$url = $this->book.$book;

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
		$url = $this->n_books.$number;

		// inserting info into table requests
		$stat = "insert into EDITOR_REQUEST(timeStamp, editorName, requestedBooks, urlPath) VALUES ('".$dateTimeFormatted."','".$editor."','".$number."','".$url."');";
		$result = $dal->executeQuery($stat);
		mysql_free_result($result);

		$dal->close();
	}

}


?>
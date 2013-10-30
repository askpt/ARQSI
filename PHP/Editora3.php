<?php

/**
 * Editora3
 */

class Editora3
{
	private static $name = "Editora3";
	public $urlToFile = "http://uvm061.dei.isep.ipp.pt/~joao/ARQSI/EDITORA3/Editora3.json";

	/**
	 * prints all books on the screen
	 */
	public function showAllBooks()
	{
		$json = json_decode(file_get_contents($this->urlToFile), true);
	
		foreach($json as $key => $value)
		{
			echo "<br><br>Livro: ";
			if(is_array($value))
			{
				foreach($value as $key2 => $value2)
				{
					echo "<br>$key2: ".$value2;
				}
			}
		}
	}

}


?>
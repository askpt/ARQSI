<?php

	/**
	 * Editora3 webservice
	 * this webservice provides JSON response, based on the data available in Editora3.json
	 * 
	 * Currently available requests:
	 * 1) a book with a given title
	 * 2) the first n books 
	 * 3) all books marked with 'yes' or 'no' for news
	 * 4) all books of a given category
	 * 5) all available categories
	 */

	// url for original JSON data file
	$jsonDataFile = "Editora3.json";
	
	// decoding data file
	$jsonDecoded = json_decode(file_get_contents($jsonDataFile), true);
	
	// array to respond with JSON
	$jsonResponse = array();


	function respondWithJson()
	{
		global $jsonResponse;

		header('Content-type: application/json');
		if(empty($jsonResponse))
		{
			echo json_encode(array('pesquisa'=>'vazio'));
		}
		else
		{
			echo json_encode($jsonResponse);
		}
	}

	// looking for a book with a given title
	if(isset($_GET["titulo"]))
	{
		if(strcmp($_GET["titulo"]), "")
		{
			header('Content-type: application/json');
			echo json_encode(array('comando'=>'invalido'));
		}
		else
		{
			foreach ($jsonDecoded["book"] as $key => $value) 
			{
				if(strcmp($_GET["titulo"], $value["title"]) == 0)
				{
					$jsonResponse[] = $value;	
				}
			}
			respondWithJson();
		}
	}

	// looking for the first n books
	else if(isset($_GET["numero"]))
	{
		if(strcmp($_GET["numero"]), "")
		{
			header('Content-type: application/json');
			echo json_encode(array('comando'=>'invalido'));
		}
		else
		{
			// counter
			$cont = 0;
			foreach ($jsonDecoded["book"] as $key => $value) 
			{
				$cont++;
				$jsonResponse[] = $value;

				// stops adding books to response array when desired number is reached
				if($cont == intval($_GET["numero"]))
				{
					break;
				}		
			}
			respondWithJson();
		}
	}

	// looking for all news and non-news
	else if(isset($_GET["news"]))
	{
		if(strcmp($_GET["news"]), "")
		{
			header('Content-type: application/json');
			echo json_encode(array('comando'=>'invalido'));
		}

		else
		{
			foreach ($jsonDecoded["book"] as $key => $value) 
			{
				if(strcmp($_GET["news"], $value["news"]) == 0)
				{
					$jsonResponse[] = $value;
				}
			}
			respondWithJson();
		}
	}

	// looking for books by category
	else if(isset($_GET["categoria"]))
	{
		if(strcmp($_GET["categoria"]), "")
		{
			header('Content-type: application/json');
			echo json_encode(array('comando'=>'invalido'));
		}

		// it request is "todas" then responds with json of all categories (avoiding duplicates)
		else if(strcmp($_GET["categoria"], "todas") == 0)
		{
			foreach ($jsonDecoded["book"] as $key => $value) 
			{
				if(!in_array($value["category"], $jsonResponse))
				{
					$jsonResponse[] = $value["category"];
				}
			}
			respondWithJson();		
		}
		// else it's a request looking for a specific category
		else
		{
			foreach ($jsonDecoded["book"] as $key => $value) 
			{
				if(strcmp($_GET["categoria"], $value["category"]) == 0)
				{
					$jsonResponse[] = $value;
				}
			}
			respondWithJson();
		}
	}

	// none of the above means the request is not valid
	else
	{
		header('Content-type: application/json');
		echo json_encode(array('comando'=>'invalido'));
	}
?>
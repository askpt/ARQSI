<?php

	/**
	 * Editora3 webservice
	 * this webservice provides JSON response, based on the data available in Editora3.json
	 */

	// url for original JSON data file
	$jsonDataFile = "http://uvm061.dei.isep.ipp.pt/~joao/ARQSI/EDITORA3/Editora3.json";
	
	// decoding data file
	$jsonDecoded = json_decode(file_get_contents($jsonDataFile), true);
	
	// array to respond JSON
	$jsonResponse = array();

	// looking for a book with a given title
	if(isset($_GET["titulo"]))
	{
		foreach ($jsonDecoded["book"] as $key => $value) 
		{
			if(strcmp($_GET["titulo"], $value["title"]) == 0)
			{
				$jsonResponse[] = $value;	
			}
			
		}
		
		// returning no results
		if(empty($jsonResponse))
		{
			header('Content-type: application/json');
			echo json_encode(array('pesquisa'=>'vazio'));
		}
	}
	else
	{
		header('Content-type: application/json');
		echo json_encode(array('comando'=>'invalido'));
	}
?>
<?php

$urlToFile = "Editora3.json";
$json = json_decode(file_get_contents($urlToFile), true);


foreach($json as $key => $value)
{
	echo "<br><br>Livro: ";
	//echo "<br>value: ".$value;
	if(is_array($value))
	{
		//echo "ist object";
		foreach($value as $key2 => $value2)
		{
			echo "<br>$key2: ".$value2;
		}
	}
}

?>
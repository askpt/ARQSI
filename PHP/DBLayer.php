<?php
	
class DBLayer
{
	private $hostname = 'localhost';
	private $mysqlLogin = 'root';
	private $mysqlPassword = 'mysql';
	private $dbName = 'ARQSI'; 

	/**
	 * connects to a MYSQL server
	 * returns connection 
	 */
	public function connect()
	{
		$conn = mysql_connect($this->hostname, $this->mysqlLogin, $this->mysqlPassword);
		if(!$conn)
		{
			echo("Could not connect to MySQL server");
		}
		/*
		else
		{
			echo "connected<br>";
		}
		*/
		return $conn;
	}


	/**
	 * selects a dabase within the MYSQL server
	 * param: $conn 	connection
	 */
	public function selectDB($conn)
	{
		if(!mysql_select_db($this->dbName, $conn))
		{
			echo("Database does not exit");
		}
		/*
		else
		{
			echo("Selected $this->dbName");
		}
		*/
	}


	/**
	 * executes a SQL query
	 * param: query in SQL language
	 * returns query result
	 */
	public function executeQuery($query)
	{
		$result = mysql_db_query($this->dbName, $query);
		if(!$result)
		{
			echo("Error executing query: $query");
		}
		return $result;
	}


	/**
	 * counts number of fields in a database table
	 * param: result of a SQL query
	 */
	public function totalFieldCount($result)
	{
		return mysql_num_fields($result);
	}

	
	/**
	 * counts number of entries in a database table
	 * param: result of SQL query
	 */
	public function totalRowCount($result)
	{
		return mysql_num_rows($result);
	}


	/**
	 * closes MYSQL connection
	 */
	public function closeConnection()
	{
		mysql_close();
	}

	/**
	 * test function
	 */
	public function hello() 
  	{  
    	echo "DAL.php <br>";
  	} 


  	public function saveCategory($category)
	{
		// current date
		$dateTime = new DateTime();
		$dateTimeFormatted = $dateTime->format('Y-m-d H:i:s');

		$conn = $this->connect();
		$this->selectDB($conn);

		// inserting info into table requests
		$stat = "insert into CATEGORY_REQUEST(timeStamp, category) VALUES ('".$dateTimeFormatted."','".$category."');";
		$result = $this->executeQuery($stat);
		mysql_free_result($result);

		$this->closeConnection();
	}


	public function saveBook($book, $editor, $url)
	{
		// current date
		$dateTime = new DateTime();
		$dateTimeFormatted = $dateTime->format('Y-m-d H:i:s');

		// saving request in DB
		$conn = $this->connect();
		$this->selectDB($conn);

		// inserting info into table requests
		$stat = "insert into BOOK_REQUEST(timeStamp, bookTitle, editorName, urlPath) VALUES ('".$dateTimeFormatted."','".$book."','".$editor."','".$url."');";
		$result = $this->executeQuery($stat);
	
		mysql_free_result($result);

		$this->closeConnection();
	}


	public function saveEditor($number, $editor, $url)
	{
		// current date
		$dateTime = new DateTime();
		$dateTimeFormatted = $dateTime->format('Y-m-d H:i:s');

		// saving request in DB
		$conn = $this->connect();
		$this->selectDB($conn);

		// inserting info into table requests
		$stat = "insert into EDITOR_REQUEST(timeStamp, editorName, requestedBooks, urlPath) VALUES ('".$dateTimeFormatted."','".$editor."','".$number."','".$url."');";
		$result = $this->executeQuery($stat);
		mysql_free_result($result);

		$this->closeConnection();
	}



}

?>
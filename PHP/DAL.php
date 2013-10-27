<?php   

/**
 * Database access layer (DAL)
 * (contains all methods to handle a MYSQL database)
 */
class DAL
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
	 * test function
	 */
	public function hello() 
  	{  
    	echo "DAL.php <br>";
  	}  
}  
  
?> 
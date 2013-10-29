<?php
	class Livro
	{

		public $title;
		public $author;
		public $category;
		public $isbn;
		public $publicacao;
		public $news;

		public function __construct($title, $author, $category, $isbn, $publicacao, $news)
		{	
			$this->title = $title;
			$this->author = $author;
			$this->category = $category;
			$this->isbn = $isbn;
			$this->publicacao = $publicacao;
			$this->news = $news;
			
			/*
			// test only
			echo $title;
			echo $author;
			echo $category;
			echo $isbn;
			echo $publicacao;
			echo $news;
			//echo "construtor";
			*/			
		}
	}
?>

<?php
	
	$book1 = new Livro('The Da Vinci Code','Dan Brown','Fiction',784735,2005,'');
	$book2 = new Livro('Angels and Demons','Dan Brown','Fiction',34545,2003,'best book ever');
	$book3 = new Livro('A Song of Ice And Fire','George Martin','Fiction',890346,1996,'tv series');
	$book4 = new Livro('Programacao em PHP 5.3','Carlos Serrao','IT',46378,2013,'');
	$book5 = new Livro('SQL - Structured Query Language','Luis Damas','IT',58437,2012,'');
	$book6 = new Livro('Programacao em C','Luis Damas','IT',45455841,2011,'');
	$book7 = new Livro('The Physiology and Biochemisty of Prokaryotes','Roger White','Biology',46378,2013,'');
	$book8 = new Livro('An Introduction to Genetic Analysis','Griffith','Biology',7834,2003,'');
	$book9 = new Livro('Genes VII','Lewin','Biology',7237861,2002,'');

	$library = array($book1, $book2, $book3, $book4, $book5, $book6, $book7, $book8, $book9);

/*
	echo json_encode($book);
	echo json_encode($book2);
	echo json_encode($book3);
*/

	echo json_encode($library);
	

?>
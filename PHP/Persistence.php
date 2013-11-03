<?php

interface Persistence
{
	public function saveBookRequest($book);

	public function saveEditorRequest($number);
}

?>
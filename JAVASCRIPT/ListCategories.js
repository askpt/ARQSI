var xmlHttpObj;

/**
  * Create new state handler for the HTTP call where we work the information received
 */
function stateHandler()
{ 
    if ( xmlHttpObj.readyState == 4 && xmlHttpObj.status == 200) 
    {
      var categoriesList = new Array();

    	var docxml = xmlHttpObj.responseXML;
    	var nodelist = docxml.getElementsByTagName("categoria");

    	for (var i = 0; i < nodelist.length; i++) {
    		var value = nodelist[i].textContent;

    		if (!checkIfExists(categoriesList, value)) 
    		{
    			categoriesList.push(value);
    		};
    	};

    	document.getElementById("scategories").innerHTML += CreateSelectHTML(categoriesList);		
    }
}

/**
  * The main function for the list categories
 */
function ListCategories () 
{
	MakeXMLHTTPCall("GET", "PHP/ListCategories.php");
}
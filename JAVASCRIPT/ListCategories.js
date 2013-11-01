var xmlHttpObj;

/**
  * Create new state handler for the HTTP call where we work the information received
 */
function stateHandlerListCategories()
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
      ListBooksByCategory();
    }
}

/**
  * Create new HTTP Call to the service indicated by the argument
  * @param method the method that will specify the request type
  * @param url    the url service where the calls will be made
  */
  function MakeXMLHTTPCallListCategories(method, url)
  {     
    xmlHttpObj = CreateXmlHttpRequestObject();

    if (xmlHttpObj)
    {

      xmlHttpObj.open(method, url, true);

      xmlHttpObj.onreadystatechange = stateHandlerListCategories;
      xmlHttpObj.send(null);
    }

  }

/**
  * The main function for the list categories
 */
function ListCategories () 
{
	MakeXMLHTTPCallListCategories("GET", "PHP/EditorAPI.php?type=GetAllCategories");
}
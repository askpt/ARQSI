var xmlHttpObj;

/**
  * Create new state handler for the HTTP call where we work the information received
 */
function stateHandlerListBooksByCategory()
{ 
    if ( xmlHttpObj.readyState == 4 && xmlHttpObj.status == 200) 
    {
      document.getElementById("tbooks").innerHTML = "";

    	var docxml = xmlHttpObj.responseXML;
    	var nodelist = docxml.getElementsByTagName("title");

    	for (var i = 0; i < nodelist.length; i++) {
    		var value = nodelist[i].textContent;

    		document.getElementById("tbooks").innerHTML += "<tr><td>" + value + "</td></tr>";
    	};

    			
    }
}

/**
  * Create new HTTP Call to the service indicated by the argument
  * @param method the method that will specify the request type
  * @param url    the url service where the calls will be made
  */
  function MakeXMLHTTPCallListBooksByCategory(method, url)
  {     
    xmlHttpObj = CreateXmlHttpRequestObject();

    if (xmlHttpObj)
    {

      xmlHttpObj.open(method, url, true);

      xmlHttpObj.onreadystatechange = stateHandlerListBooksByCategory;
      xmlHttpObj.send(null);
    }

  }

/**
  * The main function for the list books by categories
 */
function ListBooksByCategory () 
{
    var index = document.getElementById("scategories").selectedIndex;
    var category = document.getElementById("scategories").options[index].text;
	 MakeXMLHTTPCallListBooksByCategory("GET", "PHP/EditorAPI.php?type=GetBooksByCategory&category=" + category);
}
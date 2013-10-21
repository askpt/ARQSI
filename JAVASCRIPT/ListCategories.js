var xmlHttpObj;
var categoriesList = null;
var editorList = ["editora1", "editora2"];

/**
  * Create new HTTP Call to the service indicated by the argument
  * @param url		the url service where the calls will be made
 */
function MakeXMLHTTPCall(url)
{     
  	xmlHttpObj = CreateXmlHttpRequestObject();

   	if (xmlHttpObj)
   	{

	xmlHttpObj.open("GET", url, true);

	xmlHttpObj.onreadystatechange = stateHandler;
	xmlHttpObj.send(null);
	}

}

/**
  * Create new state handler for the HTTP call where we work the information received
 */
function stateHandler()
{ 

    if ( xmlHttpObj.readyState == 4 && xmlHttpObj.status == 200) // resposta do servidor completa
    {

    	var docxml = xmlHttpObj.responseXML;

    	var nodelist = docxml.getElementsByTagName("categoria");

    	for (var i = 0; i < nodelist.length; i++) {
    		var value = nodelist[i].nodeValue;

    		if (!categoriesList[value]) 
    		{
    			categoriesList.push(value);
    		};
    	};	
    }
}

/**
  * The function that will create the options for the select HTML tag
  * @returns the HTML code with the categories
 */
function CreateSelectHTML () {
	// body...
}

/**
  * The main function for the list categories
 */
function ListCategories () 
{
	
	document.getElementById("scategories").innerHTML = CreateSelectHTML();
}
var xmlObj;

/**
  * Create new state handler for the HTTP call where we work the information received
 */
function stateHandlerListEditors()
{ 
    if ( xmlObj.readyState == 4 && xmlObj.status == 200) 
    {
      var editorsList = new Array();

    	var docxml = xmlObj.responseXML;
    	var nodelist = docxml.getElementsByTagName("editor");

    	for (var i = 0; i < nodelist.length; i++) {
    		var value = nodelist[i].textContent;
    		
    		editorsList.push(value);
    	};

    	document.getElementById("seditors").innerHTML += CreateSelectHTML(editorsList);
    }
}

/**
  * Create new HTTP Call to the service indicated by the argument
  * @param method the method that will specify the request type
  * @param url    the url service where the calls will be made
  */
  function MakeXMLHTTPCallListEditors(method, url)
  {     
    xmlObj = CreateXmlHttpRequestObject();

    if (xmlObj)
    {

      xmlObj.open(method, url, false);

      xmlObj.onreadystatechange = stateHandlerListEditors;
      xmlObj.send(null);
    }

  }

/**
  * The main function for the list categories
 */
function ListEditors () 
{
	MakeXMLHTTPCallListEditors("GET", "PHP/EditorAPI.php?type=GetEditors");
}
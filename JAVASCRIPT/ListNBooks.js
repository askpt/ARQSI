var xmlHttpObj;

/**
  * Create new state handler for the HTTP call where we work the information received
 */
function stateHandlerGetNBooks()
{ 
    if ( xmlHttpObj.readyState == 4 && xmlHttpObj.status == 200) 
    {
      document.getElementById("dbooks").innerHTML = "";

    	var docxml = xmlHttpObj.responseXML;
    	var nodelist = docxml.getElementsByTagName("title");

    	for (var i = 0; i < nodelist.length; i++) {
    		var value = nodelist[i].textContent;

    		document.getElementById("dbooks").innerHTML += "<p>" + value + "</p>";
    	};

    			
    }
}

/**
  * Create new HTTP Call to the service indicated by the argument
  * @param method the method that will specify the request type
  * @param url    the url service where the calls will be made
  */
  function MakeXMLHTTPCallGetNBooks(method, url)
  {     
    xmlHttpObj = CreateXmlHttpRequestObject();

    if (xmlHttpObj)
    {

      xmlHttpObj.open(method, url, true);

      xmlHttpObj.onreadystatechange = stateHandlerGetNBooks;
      xmlHttpObj.send(null);
    }

  }

/**
  * The main function for the list of N books
 */
function GetNBooks() 
{
  var index = document.getElementById("seditors").selectedIndex;
  var editor = document.getElementById("seditors").options[index].text;
  var number = document.getElementById('tnumber').value;
	MakeXMLHTTPCallGetNBooks("GET", "PHP/EditorAPI.php?type=GetNBooks&editor=" + editor + "&number=" + number);
  return false;
}
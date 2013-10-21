var xmlHttpObj;
var categoriesList = null;
var editorList = ["editora1", "editora2"];


/**
  * checks the compatibility of the user browser engine
  * @return a xmlHttpObject for the specific browser
 */
function CreateXmlHttpRequestObject( )
{ 
    xmlHttpObj=null;
    if (window.XMLHttpRequest) // IE 7 e Firefox
    {
        xmlHttpObj=new XMLHttpRequest()

    }
    else if (window.ActiveXObject) // IE 5 e 6
    {
        xmlHttpObj=new ActiveXObject("Microsoft.XMLHTTP")
    }
    return xmlHttpObj;
}

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

	xmlHttpObj.onreadystatechange = stateHandler();
	xmlHttpObj.send(null);
	}

}

/**
  * Create new state handler for the HTTP call where we work the information received
 */
function stateHandler()
{ 

    if ( xmlHttpObj.readyState == 4 && xmlHttpObj.status == 200) 
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
function CreateSelectHTML () 
{
	var temp = "";

	for (var i = 0; i < categoriesList.length; i++) 
	{
		temp += "<option>" + categoriesList[i] + "</option>";
	};

	return temp;
}

/**
  * The main function for the list categories
 */
function ListCategories () 
{
	for (var i = 0; i < editorList.length; i++) 
	{
		url = "../PHP/ListCategories.php?editor=" + editorList[i];
		MakeXMLHTTPCall(url);
	};
	document.getElementById("scategories").innerHTML = CreateSelectHTML();
}
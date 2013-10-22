var xmlHttpObj;
var categoriesList = [];
var editorList = ["editora1", "editora2"];

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
    		var value = nodelist[i].textContent;

    		if (!categoriesList[value]) 
    		{
    			categoriesList.push(value);
    		};
    	};

    	document.getElementById("scategories").innerHTML += CreateSelectHTML();		
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
		url = "PHP/ListCategories.php?editor=" + editorList[i];
		MakeXMLHTTPCall("GET", url);
	};
}
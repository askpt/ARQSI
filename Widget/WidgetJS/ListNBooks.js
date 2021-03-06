var xmlHttpObj;

// global variables used in pagination
var tempNode;
var editor;

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

      document.getElementById("dbooks").innerHTML += "<h4>With Pagination</h4>";
      tempNode = nodelist;
      enablePagination(1);

      // below we have code used before paging
      /*
      document.getElementById("dbooks").innerHTML += "<h4>Without Pagination</h4>";
    	for (var i = 0; i < nodelist.length; i++) {
    		var value = nodelist[i].textContent;
    		document.getElementById("dbooks").innerHTML += "<p>" + value + "</p>";
    	};
      */		
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
  editor = document.getElementById("seditors").options[index].text;
  var number = document.getElementById('tnumber').value;
	MakeXMLHTTPCallGetNBooks("GET", "http://uvm061.dei.isep.ipp.pt/ARQSI/Widget/WidgetAPI/EditorAPI.php?type=GetNBooks&editor=" + editor + "&number=" + number);
  return false;
}


/**
 * enables pagination
 * @param page (initial page to be displayed)
 */
function enablePagination(page)
{

  //alert(page);
  var node = tempNode;

  // if we have results in node we apply pagination
  if(node.length)
  {
    // results per page (hard-coded)
    var resultsPerPage = 3;

    // determining current, previous and next pages
    var previousPage = page - 1;
    var nextPage = page + 1;
    var currentPage = (resultsPerPage * page) - resultsPerPage;

    // total items to display
    var totalItems = node.length;

    // feedback to user
    var feedback = "<b>Total books matching your request: " + totalItems + ".</b>"
    document.getElementById("dbooks").innerHTML = feedback;

    // calculating the total number of pages
    if(totalItems <= resultsPerPage)
    {
      var totalPages = 1;
    }
    else if(totalItems % resultsPerPage == 0)
    {
      var totalPages = totalItems / resultsPerPage;
    }
    else
    {
      var totalPages = totalItems / resultsPerPage + 1;
    }

    // printing items for current page only
    for(var i = currentPage; i < currentPage + resultsPerPage; i++)
    {
      // we need this condition to make sure this function doesn't crash when looking for a node[i] that does not exist
      if(i < totalItems)
      {
        var value = node[i].textContent;
 
        var link = "<p><a onclick=\"Click('"+ editor + "', '" +  value + "');\">" +  value + "</a>"
        document.getElementById("dbooks").innerHTML += link;
        //document.getElementById("dbooks").innerHTML += "<p>" + value + "</p>";
      }
    }

    // showing page navigation
    for(var i = 1; i <= totalPages; i++)
    {
      if(i != page)
      {
        var temp = "<a href=\"#\" onclick=\"enablePagination(" + i + ");\">" + i + "</a>" + " | ";
        //alert(temp);
        document.getElementById("dbooks").innerHTML += temp;
      }
      else
      {
        document.getElementById("dbooks").innerHTML += i + " | ";
      }
    }

    // enhancing pagination with PREVIOUS, NEXT and PAGE NUMBER
    document.getElementById("dbooks").innerHTML += "<p>"
    // adding PREVIOUS link (only if we have a previous page)
    if(previousPage && page > 1)
    {
      var temp = "<a href=\"#\" onclick=\"enablePagination(" + (page - 1) + ");\">PREV</a>";
      document.getElementById("dbooks").innerHTML += temp;
    }

    var currentPageString = "<b>- Page " + page + " -</b>";
    document.getElementById("dbooks").innerHTML += currentPageString;

    // adding NEXT link (only if we have a next page)
    if((page + 1) <= totalPages)
    {
      var temp = "<a href=\"#\" onclick=\"enablePagination(" + (page + 1) + ");\">NEXT</a>";
      document.getElementById("dbooks").innerHTML += temp;
    }
  }
  else
  {
    document.getElementById("dbooks").innerHTML = "No books to display";
  }
}
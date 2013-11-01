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
      var editors = docxml.getElementsByTagName("editor");

      var allBooks = docxml.getElementsByTagName("title").length;
      var size = document.getElementById("tnumberbooks").value;

      if (!(!isNaN(parseFloat(size)) && isFinite(size)) && size != "") {
        alert("Inserted Value Isn't a Correct Number!");
        size = "";
      };

      size = ((size != "") ? size : allBooks);

      for (var i = 0; i < editors.length; i++) {
        var nodelist = editors[i].getElementsByTagName("title");
        var editor = editors[i].firstChild.nodeValue;
        var sizeEditor = editors[i].getElementsByTagName("title").length;

        for (var y = 0; size > 0 && y < sizeEditor; y++) {
          var value = nodelist[y].textContent;
          
          var link = "<p><a onclick=\"Click('"+ editor + "', '" +  value + "');\">" +  value +  " <b>(" + editor
            + ")</b>" + "</a>"
          document.getElementById("tbooks").innerHTML += link;
          size--;
        };
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
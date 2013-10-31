var xmlHttpObj;

function stateHandlerListCategories()
{ 
  if ( xmlHttpObj.readyState == 4 && xmlHttpObj.status == 200) 
  {
   var docxml = xmlHttpObj.responseXML;

   var title = docxml.getElementsByTagName("title")[0].textContent;
   var author = docxml.getElementsByTagName("author")[0].textContent;
   var category = docxml.getElementsByTagName("category")[0].textContent;
   var isbn = docxml.getElementsByTagName("isbn")[0].textContent;
   var edition = docxml.getElementsByTagName("publicacao")[0].textContent;

   document.getElementById("dialog").innerHTML = "<p>" + title;
   document.getElementById("dialog").innerHTML += "<p>" + author;
   document.getElementById("dialog").innerHTML += "<p>" + category;
   document.getElementById("dialog").innerHTML += "<p>" + isbn;
   document.getElementById("dialog").innerHTML += "<p>" + edition;

 }
}

function MakeXMLHTTPCallBookInfo(method, url)
{     
  xmlHttpObj = CreateXmlHttpRequestObject();

  if (xmlHttpObj)
  {

    xmlHttpObj.open(method, url, true);

    xmlHttpObj.onreadystatechange = stateHandlerListCategories;
    xmlHttpObj.send(null);
  }

}



function BookInfo (editor, book) 
{
  var url = "PHP/EditorAPI.php?type=GetBook&editor=" + editor + "&title=" + book;
  MakeXMLHTTPCallBookInfo("GET", url);
}

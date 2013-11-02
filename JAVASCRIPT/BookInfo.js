var xmlHttpObj;
var jsonHttpObjG;
var editor;

function stateHandlerBookInfo()
{ 
  if ( xmlHttpObj.readyState == 4 && xmlHttpObj.status == 200) 
  {
   var docxml = xmlHttpObj.responseXML;

   var title = docxml.getElementsByTagName("title")[0].textContent;
   var author = docxml.getElementsByTagName("author")[0].textContent;
   var category = docxml.getElementsByTagName("category")[0].textContent;
   var isbn = docxml.getElementsByTagName("isbn")[0].textContent;
   var edition = docxml.getElementsByTagName("publicacao")[0].textContent;

   document.getElementById("test").innerHTML = "<span typeof='ed:book' resource='#book1.1'>";
   document.getElementById("test").innerHTML += "<p><b>Title: </b><span property='ed:title'>" + title + "</span>";
   document.getElementById("test").innerHTML += "<p><b>Author: </b><span property='ed:author'>" + author + "</span>";
   document.getElementById("test").innerHTML += "<p><b>Category: </b><span property='ed:category'>" + category + "</span>";
   document.getElementById("test").innerHTML += "<p><b>ISBN: </b><span property='ed:isbn'>" + isbn + "</span>";
   document.getElementById("test").innerHTML += "<p><b>Edition: </b><span property='ed:edition'>" + edition + "</span>";
   document.getElementById("test").innerHTML += "</span>";

   GetGoogleBookInfo(isbn);
 }
}

function MakeXMLHTTPCallBookInfo(method, url)
{     
  xmlHttpObj = CreateXmlHttpRequestObject();

  if (xmlHttpObj)
  {

    xmlHttpObj.open(method, url, true);

    xmlHttpObj.onreadystatechange = stateHandlerBookInfo;
    xmlHttpObj.send(null);
  }

}



function BookInfo (ed, book) 
{
  editor = ed;
  var url = "PHP/EditorAPI.php?type=GetBook&editor=" + editor + "&title=" + book;
  MakeXMLHTTPCallBookInfo("GET", url);
}


function GetGoogleBookInfo (isbn) {
  var url = "https://www.googleapis.com/books/v1/volumes?q=isbn:" + isbn;

  jsonHttpObjG = CreateXmlHttpRequestObject();

  if (jsonHttpObjG)
  {

    jsonHttpObjG.open("GET", url, true);

    jsonHttpObjG.onreadystatechange = stateHandlerGoogleInfo;
    jsonHttpObjG.send(null);
  }

}

function stateHandlerGoogleInfo () {
  if ( jsonHttpObjG.readyState == 4 && jsonHttpObjG.status == 200) 
  {
   var docJSON = jsonHttpObjG.responseText;

   var json = eval('(' + docJSON + ')');

   if (json.totalItems === 0) {

   }else{
    document.getElementById("test").innerHTML += "<p><b>Description: </b>" + json.items[0].volumeInfo.description;
    document.getElementById("test").innerHTML += "<center><p><img src=\"" + json.items[0].volumeInfo.imageLinks.thumbnail + "\"></img></center>";
  }

}
}
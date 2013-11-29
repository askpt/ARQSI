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

   document.getElementById("dbookinfo").innerHTML = "<span typeof='ed:book' resource='#book1.1'>";
   document.getElementById("dbookinfo").innerHTML += "<p><b>Title: </b><span property='ed:title'>" + title + "</span>";
   document.getElementById("dbookinfo").innerHTML += "<p><b>Author: </b><span property='ed:author'>" + author + "</span>";
   document.getElementById("dbookinfo").innerHTML += "<p><b>Category: </b><span property='ed:category'>" + category + "</span>";
   document.getElementById("dbookinfo").innerHTML += "<p><b>ISBN: </b><span property='ed:isbn'>" + isbn + "</span>";
   document.getElementById("dbookinfo").innerHTML += "<p><b>Edition: </b><span property='ed:edition'>" + edition + "</span>";
   document.getElementById("dbookinfo").innerHTML += "</span>";

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
  var url = "http://uvm061.dei.isep.ipp.pt/ARQSI/Widget/WidgetAPI/EditorAPI.php?type=GetBook&editor=" + editor + "&title=" + book;
  MakeXMLHTTPCallBookInfo("GET", url);
}


function GetGoogleBookInfo (isbn) {
  var url = "https://www.googleapis.com/books/v1/volumes?q=isbn:" + isbn + "&key=AIzaSyBhVQraXKFaqSgMX30dXVmXRPI4TujhKU4";

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
    var description = json.items[0].volumeInfo.description;
    var image = json.items[0].volumeInfo.imageLinks.thumbnail;
    if (description != undefined) {
     document.getElementById("dbookinfo").innerHTML += "<p><b>Description: </b>" + description;
   };
   if (image != undefined) {
     document.getElementById("dbookinfo").innerHTML += "<center><p><img src=\"" + image + "\"></img></center>";
   };
   
 }

}
}
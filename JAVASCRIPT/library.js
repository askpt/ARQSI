/**
  * checks the compatibility of the user browser engine
  * @return a xmlHttpObject for the specific browser
 */
function CreateXmlHttpRequestObject( )
{ 
       // e sem tratamento de excepções
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
  * checks if the field value string contains only non-digits
  * @param elem      element to be tested
  * @return          true is it's a valid name, false if it has at least one digit
 */
function hasNoDigits(elem)
 
    // saves string 
    var str = elem.value;

    // regular expression for any string with no digits
    regExp = /^\D+$/;

    return regExp.test(str);
}

/** 
 * checks if the entry is a positive or negative number
 * @param elem      element to be tested
 * @return true is it's a valid number, false if it's not 
 */ 
function isNumber(elem)
{
  // saves entry text
  var str = elem.value;

  // initially set to false
  var decimalDetected = false;

  // variable used for character comparison
  var oneCharacter = 0; 

  // casting to string to compare with ASCII table
  str = str.toString();

  // cycles trougth all input text
  for(var i = 0; i < str.length; i++)
  {
    // getting the first char unicode
    var oneCharacter = str.charAt(i).charCod
    // allowing first char to be a minus sign
    if(oneCharacter == 45) 
    {
        if(i == 0)
        {
            continue;
        }
        else
        {
            //alert("minus sign must be the first character");
            return false;
        }
    }
                
    // allowing one decimal point only (can be either ',' or '.')
    if(oneCharacter == 46 || oneCharacter == 44)
    {
        // if we still didn't have any decimal character we accept it
        if(!decimalDetected)
        {
            decimalDetected = true;
            continue;
        }
        else
        {
          //alert("only one decimal placeholder is allowed");
          return false;
        }
    }

    // allowing 0-9 range only
    if(oneCharacter < 48 || oneCharacter > 57)
    {
      //alert("insert numbers only!");
      return false;
    }
  }
  return true;
}

/**
  * verifies if a given number is in the desired range
  * @param elem      element to be tested
  * @param min       bottom of the range
  * @oaram max       top of the range
  * @return          true if number belongs to range
  */
function numberIsInRange(elem, min, max)
{
    var str = elem.value;
            
    // checks if it's a number
    if(!isNumber(elem))
    {
        return false;
    }

    if(str >= min && str <= max)
    {
        return true;
    }
     else
    {
        return false;
    }
}

/**
  * verifies if a given element is text-empty
  * @param elem      element to be tested 
  * @return          true if element is empty
  */
function isEmpty(elem)
{
  /* getting the text */
  var str = elem.value;

  /* defining a regular expression for non-empty string */
  var regExp = /.+/;
  return !regExp.test(str);
}

/**
  * verifies if it's a valid email address
  * @param elem      element to be tested
  * @return          true if is a valid email
  */
  function isValidEmail(elem)
  {
    var str = elem.value;
    var regExp = /^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$/;
    return regExp.test(str);
  }

/**
  * verifies if a field doesn't exceed a given maximum length
  * @param elem      element to be tested
  * @param len       maximum length
  * @return          true if doesn't exceed maximum length
  */
function hasDesiredMaxLength(elem, len)
{
  var str = elem.value;
  if(str.length > len)
  {
    return false;
  }
  return true;
}

/**
  * verifies if a field has at least a given length
  * @param elem      element to be tested
  * @param len       minimum length
  * @return          true if doesn't exceed maximum length
  */
  function hasDesiredMinLength(elem, len) 
  {
    var str = elem.value;
    if(str.length < len)
    {
      return false;
    }
  return true;
}

/**
 * creates a text node inside a given div element
 * @elem text       text to be added
 * @elem divId      div id attribute
 * @elemt withBreak   true to break from the previous line, false to write in the same line
 */
function createTextInDivId(text, divId, withBreak)
{
  var element = document.getElementById(divId);
  var textNode = document.createTextNode(text);
      
  if(withBreak)
  {
    var addedBreak = document.createElement("br");
    element.appendChild(addedBreak);
  }

  element.appendChild(textNode);
}

/**
 * counts all tags in a given node
 * @elem node   node where count starts
 * @return    number tags
 */
function tagCountInNode(node)
{
  var sum = 0;
      
  if(node.nodeType == 1)
  {
    sum ++;
  }
      
  var allChildrenNodes = node.childNodes;
  for(var i = 0; i < allChildrenNodes.length; i++)
  {
    sum += tagCountInNode(allChildrenNodes[i]);
  }

  return sum;
}

/**
 * replaces all element's content with text element
 * @param text  replacement text
 * @param id  element id
 */
function replaceWithTextInElementId(text, id)
{
  var node = document.getElementById(id);
  while(node.firstChild)
  {
    node.removeChild(node.firstChild);
  }
  node.appendChild(document.createTextNode(text));
}

/**
 * adds a new option element to a select element
 * @param text    text to be displayed in the option element
 * @param selectId  select element id 
 */
function addNewOptionToDropdownWithId(text, selectId)
{
    // getting the select element
    var element = document.getElementById(selectId);

    // creating a new option element
    var newOption = document.createElement('option');

    // setting newOption properties
    newOption.value = text;
    newOption.innerHTML = text;

    // appending
    element.appendChild(newOption);
}

/**
 * creates one or more option elements into a select element
 * @param array   array of strings with text to be displayed in the option elements
 * @param selectId  select element id 
 */
function createNewOptionFromArrayWithId(array, selectId)
{
  //sayHello();
  for(var i = 0; i < array.length; i++)
  {
    addNewOptionToDropdownWithId(array[i], selectId);
  }
}

/**
 * clears all elements in current node
 */
function clearCurrentNode(node)
{
   while(node.firstChild)
     {
        node.removeChild(node.firstChild);
     }
}
      
/*
The following functions were made to be used in the dynamic sort of HTML tables;
they are NOT generic, so their use implies proper adaptation 
*/

function populateTable(tbodyId) 
{
  var tr, td;

  tbody = document.getElementById(tbodyId);
    
  // looping through data source
  for (var i = 0; i < sales.length; i++) 
  {
    // getting row number
    // tr = reference to the newly generated row object
    // tbody.rows.length = position of the new row within the table
    tr = tbody.insertRow(tbody.rows.length);

    // setting up and populating YEAR column
    // invoking insertCell based on the row object
    // tr.cells.length = position of the new cell within the row
    td = tr.insertCell(tr.cells.length);     
    td.setAttribute("align", "center");
    td.innerHTML = sales[i].year;

    // setting up and populating PERIOD column
    td = tr.insertCell(tr.cells.length);
    td.setAttribute("align", "center");
    td.innerHTML = sales[i].period;

    // setting up and populating REGION team column
    td = tr.insertCell(tr.cells.length);
    td.setAttribute("align", "center");
    td.innerHTML = sales[i].region;

    // setting up and populating TOTAL TEAM column
    td = tr.insertCell(tr.cells.length);
    td.setAttribute("align", "center");
    td.innerHTML = sales[i].total;
  }
}

function sortTable(link)
{
  // deciding sorting method
  switch(link.getAttributeNode("title").nodeValue)
  {
    case "Sort by Year Asc":
      sales.sort(compareYearAsc);
      break;

    case "Sort by Year Desc":
      sales.sort(compareYearDesc);
      break;

    case "Sort by Period Asc":
      sales.sort(comparePeriodAsc);
      break;

    case "Sort by Period Desc":
      sales.sort(comparePeriodDesc);
      break;

    case "Sort by Region Asc":
      sales.sort(compareRegionAsc);
      break;

    case "Sort by Region Desc":
      sales.sort(compareRegionDesc);
      break;

    case "Sort by Total Sales Asc":
      sales.sort(compareTotalsAsc);
      break;

    case "Sort by Total Sales Desc":
      sales.sort(compareTotalsDes);
      break;
  }

  // clearing existing table
  clearTable(document.getElementById("tabelaDinamica"));

  // add sorted data
  populateTable("tabelaDinamica");

  return false;
}

function clearTable(tbody)
{
  while(tbody.rows.length > 0)
  {
    tbody.deleteRow(0);
  }
}

function compareTotalsAsc(a, b)
{
  return a.total - b.total;
}

function compareTotalsDes(a, b)
{
  return b.total - a.total;
}

function compareYearAsc(a, b)
{
  return a.year - b.year;
}

function compareYearDesc(a, b)
{
  return b.year - a.year;
}

function comparePeriodAsc(a, b)
{
  var nameA = a.period;
  var nameB = b.period;
  if(nameA < nameB)
  {
    return -1;
  }
  if(nameA > nameB)
  {
    return 1;
  }
    return 0;
  }

function comparePeriodDesc(a, b)
{
  var nameA = a.period;
  var nameB = b.period;
  if(nameA > nameB)
  {
    return -1;
  }
  if(nameA < nameB)
  {
    return 1;
  }
  return 0;
}

function compareRegionAsc(a, b)
{
  var nameA = a.region;
  var nameB = b.region;
  if(nameA < nameB)
  {
    return -1;
  }
  if(nameA > nameB)
  {
    return 1;
  }
  return 0;
}

function compareRegionDesc(a, b)
{
  var nameA = a.region;
  var nameB = b.region;
  if(nameA > nameB)
  {
    return -1;
  }
  if(nameA < nameB)
  {
    return 1;
  }
  return 0;
}
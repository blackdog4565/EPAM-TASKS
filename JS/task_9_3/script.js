var firstTable = [
  "Option 1",
  "Option 2",
  "Option 3",
  "Option 2",
  "Option 2",
  "Option 2",
  "Option 2",
  "Option 2",
  "Option 2",
  "Option 2",
  "Option 2"
]

var secondTable = []

var firstTableDiv = document.getElementById('first-table');
var secondTableDiv = document.getElementById('second-table');

insertFromFirstTable(firstTable);

function insertFromFirstTable() {
  
  clear(firstTableDiv);
  for (var i = 0; i < firstTable.length; i++) {
    firstTableDiv.innerHTML += '<label class="label"><input type="radio" class="text-in-div"  onClick="check()">' + firstTable[i] + '</label>';
  };
};

function clear(table) {
  while (table.firstChild) {
    table.firstChild.remove();
  };
}

function insertFromSecondTable() {
  
  clear(secondTableDiv);
  for (var i = 0; i < secondTable.length; i++) {
    secondTableDiv.innerHTML += '<label class="label"><input type="radio" class="text-in-div" onClick="check()">' + secondTable[i] + '</label>';
  };
};

function firstButton() {
  var label = [];
  var ch = 0;
  
  for (var i = 0; i < firstTableDiv.childNodes.length; i++) {
    label.push(firstTableDiv.childNodes[i].firstChild);
  }
  
  for (var i = 0; i < label.length; i++) {
    if (label[i].checked) {
      label[i].checked = false;
      secondTable.push(firstTable[i]);
      firstTable.splice(i, 1);

      ch++;
    }
    
  }
  if (ch == 0) {
    alert("Не выбрано")
  };
  insertFromFirstTable();
  insertFromSecondTable();

  console.log(secondTable);
  console.log(firstTable);
};

function secondButton() {
  var label = [];
  
  for (var i = 0; i < firstTableDiv.childNodes.length; i++) {
    label.push(firstTableDiv.childNodes[i].firstChild);
  }
  
  for (var i = 0; i < label.length; i++) {
    label[i].checked = false;
    secondTable.push(firstTable[i]);
  };
  for (var i = 0; i < label.length; i++) {
    firstTable.pop();
  }
  
  insertFromFirstTable();
  insertFromSecondTable();
};

function fourthButton() {
  var label = [];
  
  for (var i = 0; i < secondTableDiv.childNodes.length; i++) {
    label.push(secondTableDiv.childNodes[i].firstChild);
  }
  
  for (var i = 0; i < label.length; i++) {
    label[i].checked = false;
    firstTable.push(secondTable[i]);
  };
  for (var i = 0; i < label.length; i++) {
    secondTable.pop();
  }
  
  insertFromFirstTable();
  insertFromSecondTable();
};

function thirdButton() {
  var label = [];
  var ch = 0;
  
  for (var i = 0; i < secondTableDiv.childNodes.length; i++) {
    label.push(secondTableDiv.childNodes[i].firstChild);
  }

  for (var i = 0; i < label.length; i++) {
    if (label[i].checked) {
      label[i].checked = false;
      firstTable.push(secondTable[i]);
      secondTable.splice(i, 1);

      ch++;
    };
  }
  if (ch == 0) {
    alert("Не выбрано")
  };
  insertFromSecondTable();
  insertFromFirstTable();

  console.log(secondTable);
  console.log(firstTable);  
}

function check() {
  var label = document.getElementsByTagName('input')
  for (var i = 0; i < label.length; i++) {
    if (label[i].checked) {
      label[i].parentElement.style.backgroundColor = "lightgrey";
      console.log(i);
    }
    else {
      label[i].parentElement.style.backgroundColor = "white";
    };
  }
}




var message = "У попа, была собака"; // входная строка
var separators = " \t?!:;,."; // разделители

var mas = []; // массив для разделенных слов

var startWord = 0; // индекс начала слова

for (var i = 0; i < message.length; i++) { // цикл разделения строки на слова
  if (separators.includes(message[i])) { // если встретился разделитель
    mas.push(message.substring(startWord, i).replace(message[i], ''));
    startWord = i;
  };

  if (i == message.length - 1) { // если конец строки
    mas.push(message.substring(startWord + 1, i + 1));
    startWord = i;
  };
};

for (var i = 0; i < mas.length; i++) { // поиск вхождений символов в слове
  for (var j = 0; j < mas[i].length; j++) {
    var countLetter = mas[i].split(mas[i][j]).length; // если буква встретилась несколько раз, 
                                                      // то и слово разделится ни на два слова, а на три и больше

    if (countLetter > 2) {
      message = message.replace(mas[i][j], '');
    };
  };
};

console.log(message);


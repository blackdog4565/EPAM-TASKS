var message = "3.5 +4 *10-5.3 /5 ="; // входная строка
var znaki = "+-/*"; // разделители
var numbers = []



console.log(message);

var result = 0;

if (message.indexOf('=') != -1) {
  while (message.indexOf(' ') != -1) {
    message = message.replace(' ', '').replace('=', '');
  };
  numbers = message.split(/[+\-/*]/);
}
else {
  console.log("Нет знака \"равно\"");
};

console.log(numbers);

var j = 0;

for (var i = 0; i < message.length; i++) {
  if (message[i] == '+') {
    numbers[j+1] = parseFloat(numbers[j]) + parseFloat(numbers[j+1]);
    j++;
  };
  if (message[i] == '-') {
    numbers[j+1] = parseFloat(numbers[j]) - parseFloat(numbers[j+1]);
    j++;
  };
  if (message[i] == '*') {
    numbers[j+1] = parseFloat(numbers[j]) * parseFloat(numbers[j+1]);
    j++;
  };
  if (message[i] == '/') {
    numbers[j+1] = parseFloat(numbers[j]) / parseFloat(numbers[j+1]);
    j++;
  };
};

result = numbers[numbers.length - 1].toFixed(2);

console.log(result);

var totaleTime = 0;
var eyeCount = 0;
var countArray = new Array();
var totaleCount;
var average;
var intervalCount = 1;

function hogemoge() {
  //totaleTime += 60;
  //console.log("--------------------現在のトータル時間は" + totaleTime + "です.--------------------");
  console.log("1分経過");
  console.log("-----------------1分間に目を" + eyeCount + "回瞑りました。-----------------");

  var value = localStorage.getItem('average');
  console.log("差分 = " + (value　- eyeCount));
  
  //データの蓄積
  countArray.push(eyeCount);

  //配列内データの合計値算出(配列内のデータ全ての合計)
  totaleCount = countArray.reduce(function (sum, element) {
    return sum + element;
  }, 0);

  //平均算出
  average = totaleCount / intervalCount;
  console.log("--------------------------現在の1分間における平均瞬き回数は" + average + "回目です.--------------------------");

  //localStorageに保存
  localStorage.setItem('totale', totaleCount);
  localStorage.setItem('average', average);

  //localStorageからデータ呼び出し
  // var value = localStorage.getItem('totale');
  // console.log(value);

  //console.log("---------------------10秒前のデータは" + beforeCount + "です.---------------------");
  intervalCount += 1;
  eyeCount = 0;
}

// setInterval(hogemoge(),3000);

//1分毎にhogemoge関数を呼び出す
setInterval("hogemoge()", 300000);

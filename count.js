var totaleTime = 0;
var beforeCount = 0;
var countArray = new Array();
var totale;

function hogemoge() {
  totaleTime += 10;
  //console.log("--------------------現在のトータル時間は" + totaleTime + "です.--------------------");
  console.log("10秒経過");
  timerFlg = false;

  countArray.push(beforeCount);

  if (totaleTime == 50) {
    //console.log(countArray.length);
    totale = countArray.reduce(function (sum, element) {
      return sum + element;
    }, 0);

    console.log("--------------------------50秒間で10秒間に平均" + (totale / 5) + "回目を瞑りました.--------------------------");
  }
  //console.log("---------------------10秒前のデータは" + beforeCount + "です.---------------------");
}

// setInterval(hogemoge(),3000);
setInterval("hogemoge()", 10000);

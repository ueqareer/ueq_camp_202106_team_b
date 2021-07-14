var video = document.getElementById("video");           // video 要素を取得
var canvas = document.getElementById("canvas");         // canvas 要素の取得
var context = canvas.getContext("2d");                  // canvas の context の取得
var len = 0;
var position_37_x = 0;
var position_37_y = 0;
var f = 0;
var eyeCount = 0;
let timerFlg = true;


// getUserMedia によるカメラ映像の取得
var media = navigator.mediaDevices.getUserMedia({       // メディアデバイスを取得
  video: { facingMode: "user" },                          // カメラの映像を使う（スマホならインカメラ）
  audio: false                                          // マイクの音声は使わない
});
media.then((stream) => {                                // メディアデバイスが取得できたら
  video.srcObject = stream;                             // video 要素にストリームを渡す
});


// clmtrackr の開始
var tracker = new clm.tracker();  // tracker オブジェクトを作成
tracker.init(pModel);             // tracker を所定のフェイスモデル（※）で初期化
tracker.start(video);             // video 要素内でフェイストラッキング開始


// 描画ループ
function drawLoop() {
  requestAnimationFrame(drawLoop);                      // drawLoop 関数を繰り返し実行
  var positions = tracker.getCurrentPosition();         // 顔部品の現在位置の取得
  showData(positions);                                  // データの表示
  context.clearRect(0, 0, canvas.width, canvas.height); // canvas をクリア
  // console.log(positions[27]);
  // パスをリセット
  context.beginPath();
  context.moveTo(positions[27][0], positions[27][1]);
  context.lineTo(positions[32][0], positions[32][1])
  context.strokeStyle = "red";
  context.stroke();
  context.beginPath();
  context.moveTo(positions[27][0], positions[27][1]);
  context.lineTo(positions[37][0], positions[37][1])
  context.strokeStyle = "red";
  context.stroke();
  context.beginPath();
  context.moveTo(positions[32][0], positions[32][1]);
  context.lineTo(positions[37][0], positions[37][1])
  context.strokeStyle = "red";
  context.stroke();
  // tracker.draw(canvas);                                 // canvas にトラッキング結果を描画
}


// drawLoop 関数をトリガー
drawLoop();

//平均値を保存
// var averageCount = function (average) {
//   console.log("10秒間の平均値 = " + average);
// }


// 顔部品（特徴点）の位置データを表示する showData 関数
function showData(pos) {
  var str = "";                                   // データの文字列を入れる変数
  str += "特徴点" + 27 + ": ("
    + Math.round(pos[27][0]) + ", "                  // X座標（四捨五入して整数に）
    + Math.round(pos[27][1]) + ")<br>";             // Y座標（四捨五入して整数に）
  str += "特徴点" + 32 + ": ("
    + Math.round(pos[32][0]) + ", "                 // X座標（四捨五入して整数に）
    + Math.round(pos[32][1]) + ")<br>";            // Y座標（四捨五入して整数に）

  // console.log(Math.abs(len - Math.sqrt((pos[32][0]-pos[27][0])**2 + (pos[32][1]-pos[27][1])**2)));
  str += "距離" + amountOfChange + "<br>";
  // 目の距離の変化量
  var amountOfChange = Math.abs(len - Math.sqrt((pos[32][0] - pos[27][0]) ** 2 + (pos[32][1] - pos[27][1]) ** 2));
  str += "距離の変化量" + Math.abs(len - Math.sqrt((pos[32][0] - pos[27][0]) ** 2 + (pos[32][1] - pos[27][1]) ** 2)) + "<br>";
  // 1フレーム前の目の距離の変化量
  len = Math.sqrt((pos[32][0] - pos[27][0]) ** 2 + (pos[32][1] - pos[27][1]) ** 2)


  str += "特徴点" + 37 + ": ("
    + Math.round(pos[37][0]) + ", "                 // X座標（四捨五入して整数に）
    + Math.round(pos[37][1]) + ")<br>";             // Y座標（四捨五入して整数に）

  var bool_x = amountOfChange - Math.abs(position_37_x - pos[37][0]);
  var bool_y = amountOfChange - Math.abs(position_37_y - pos[37][1]);
  if (bool_x > 0.5 && bool_y > 0.5 && f >= 30) {
    //瞬き回数判定
    if(timerFlg){
      eyeCount++;
    }else{
      console.log("-----------------10秒間に目を" + eyeCount + "回瞑りました。-----------------");
      eyeCount = 0;
      timerFlg = true;
    }
    // console.log("目を瞑りました" + eyeCount);
    f = 0;
  } else {
    // console.log("目を瞑ってません");
  }

  position_37_x = Math.round(pos[37][0]);
  position_37_y = Math.round(pos[37][1]);

  var dat = document.getElementById("dat");             // データ表示用div要素の取得
  dat.innerHTML = str;                                  // データ文字列の表示
  f += 1;
  // console.log(f);
  
}


// setInterval("averageCount", 10000, eyeCount);




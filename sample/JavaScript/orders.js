var url = new URL('http://localhost:18080/kabusapi/orders');
url.searchParams.append('product', 0);                    // product - 0:すべて、1:現物、2:信用、3:先物、4:OP
// url.searchParams.append('id', '20201207A02N04830518'); // id='xxxxxxxxxxxxxxxxxxxx'
// url.searchParams.append('updtime', 20201101123456);    // updtime=yyyyMMddHHmmss
// url.searchParams.append('details', 'false');           // details='true'/'false'
// url.searchParams.append('symbol', '9433');             // symbol='xxxx'
// url.searchParams.append('state', 5);                   // state - 1:待機（発注待機）、2:処理中（発注送信中）、3:処理済（発注済・訂正済）、4:訂正取消送信中、5:終了（発注エラー・取消済・全約定・失効・期限切れ）
// url.searchParams.append('side', '2');                  // side - '1':売、'2':買
// url.searchParams.append('cashmargin', 3);              // cashmargin - 2:新規、3:返済
var apikey = '37b96984a496419ebc2abcffa29728d4';

fetch(url, {
  method: 'GET',
  headers: {
    'Content-Type': 'application/json',
    'X-API-KEY': apikey,
  }
})
  .then(response => {
    if (response.ok) {
      console.log(response.status, response.statusText);
      for (var pair of response.headers.entries()) {
         console.log(pair[0] + ': ' + pair[1]);
      }
      response.json().then(data => {console.log(data)});
    } else {
      console.log(response.status, response.statusText);
      response.json().then(data => {console.log(data)});
    }
  })
  .catch(e => {
    console.log(e.message);
  });

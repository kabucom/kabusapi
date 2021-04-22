var url = 'http://localhost:18080/kabusapi/symbol/5401@1';
url.searchParams.append('addinfo', 'true');  // true:追加情報を出力する、false:追加情報を出力しない
// 追加情報は、「時価総額」、「発行済み株式数」、「決算期日」、「清算値」を意味します
var apikey = 'a68e2d55951b4756a3131f7942974eeb';

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

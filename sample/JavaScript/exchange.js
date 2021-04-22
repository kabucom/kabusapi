var url = 'http://localhost:18080/kabusapi/exchange/usdjpy';
// #いずれの通貨ペアを指定してください：usdjpy、eurjpy、gbpjpy、audjpy、chfjpy、cadjpy、nzdjpy、zarjpy、eurusd、gbpusd、audusd
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

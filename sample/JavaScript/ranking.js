var url = new URL('http://localhost:18080/kabusapi/ranking'); // ?type=1&ExchangeDivision=ALL
url.searchParams.append('type', 1);                    // type - 1:値上がり率（デフォルト）2:値下がり率 3:売買高上位 4:売買代金 5:TICK回数 6:売買高急増 7:売買代金急増 8:信用売残増 9:信用売残減 10:信用買残増 11:信用買残減 12:信用高倍率 13:信用低倍率 14:業種別値上がり率 15:業種別値下がり率
url.searchParams.append('ExchangeDivision', 'ALL'); // ExchangeDivision - ALL:全市場（デフォルト）T:東証全体 TP:東証プライム TS:東証スタンダード TG:東証グロース M:名証 FK:福証 S:札証
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

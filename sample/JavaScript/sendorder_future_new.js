var data = {
 'Password': '123456',
 'Symbol': '165120018',
 'Exchange': 23,
 'TradeType': 1,
 'TimeInForce': 1,
 'Side': '1',
 'Qty': 3,
 'FrontOrderType': 20,
 'Price': 22000,
 'ExpireDay': 0,
 'ReverseLimitOrder': {
                       'TriggerPrice': 26010,
                       'UnderOver': 2,
                       'AfterHitOrderType': 1,
                       'AfterHitPrice': 0
                      }
}
var url = 'http://localhost:18080/kabusapi/sendorder/future';
var apikey = '8a8b00d5bcbd4efe9f24d064a94c55bc';

fetch(url, {
  method: 'POST',
  headers: {
    'Content-Type': 'application/json',
    'X-API-KEY': apikey,
  },
  body: JSON.stringify(data)
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

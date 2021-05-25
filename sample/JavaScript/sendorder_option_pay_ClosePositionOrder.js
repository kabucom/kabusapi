var data = {
 'Password': '123456',
 'Symbol': '145123218',
 'Exchange': 23,
 'TradeType': 2,
 'TimeInForce': 2,
 'Side': '2',
 'Qty': 1,
 'ClosePositionOrder': 1,
 'FrontOrderType': 120,
 'Price': 0,
 'ExpireDay': 0,
 'ReverseLimitOrder': {
                       'TriggerPrice': 1150,
                       'UnderOver': 1,
                       'AfterHitOrderType': 1,
                       'AfterHitPrice': 0
                      }
}
var url = 'http://localhost:18080/kabusapi/sendorder/option';
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

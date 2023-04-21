var data = {
 'Password': '123456',
 'Symbol': '9433',
 'Exchange': 1,
 'SecurityType': 1,
 'Side': '1',
 'CashMargin': 1,
 'DelivType': 0,
 'FundType': '  ',
 'AccountType': 2,
 'Qty': 100,
 'FrontOrderType': 20,
 'Price': 2762.5,
 'ExpireDay': 0,
 'ReverseLimitOrder': {
                       'TriggerSec': 1,
                       'TriggerPrice': 2600,
                       'UnderOver': 1,
                       'AfterHitOrderType': 1,
                       'AfterHitPrice': 0
                      }
}
var url = 'http://localhost:18080/kabusapi/sendorder';
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

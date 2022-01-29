var data = {
    'Password': '12345',
    'Symbol': '5104',
    'Exchange': 1,
    'SecurityType': 1,
    'Side': '1',
    'CashMargin': 2,
    'MarginTradeType': 3,
    'MarginPremiumUnit': 400,
    'DelivType': 0,
    'AccountType': 2,
    'Qty': 100,
    'FrontOrderType': 20,
    'Price': 425,
    'ExpireDay': 0
   }
   var url = 'http://localhost:18080/kabusapi/sendorder';
   var apikey = 'eeb43dcceb8945bd91c72715e9dcc201';
   
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
   
   
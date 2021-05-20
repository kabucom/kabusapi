import urllib.request
import json
import pprint

obj = { 'Password': '123456',
        'Symbol': '165120018',
        'Exchange': 23,
        'TradeType': 2,
        'TimeInForce': 1,
        'Side': '2',
        'Qty': 3,
        'ClosePositions': [
                           {'HoldID':'E20200924*****','Qty':2},
                           {'HoldID':'E20200924*****','Qty':1}
                          ],
        'FrontOrderType': 20,
        'Price': 22000,
        'ExpireDay': 0,
        'ReverseLimitOrder': {
                               'TriggerPrice': 26010,
                               'UnderOver': 2, #1.以下 2.以上
                               'AfterHitOrderType': 1, #1.成行 2.指値
                               'AfterHitPrice': 0
                             }
         }
json_data = json.dumps(obj).encode('utf-8')

url = 'http://localhost:18080/kabusapi/sendorder/future'
req = urllib.request.Request(url, json_data, method='POST')
req.add_header('Content-Type', 'application/json')
req.add_header('X-API-KEY', 'ed94b0d34f9441c3931621e55230e402')

try:
    with urllib.request.urlopen(req) as res:
        print(res.status, res.reason)
        for header in res.getheaders():
            print(header)
        print()
        content = json.loads(res.read())
        pprint.pprint(content)
except urllib.error.HTTPError as e:
    print(e)
    content = json.loads(e.read())
    pprint.pprint(content)
except Exception as e:
    print(e)

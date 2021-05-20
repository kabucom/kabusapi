import urllib.request
import json
import pprint

obj = { 'Password': '123456',
        'Symbol': '145123218',
        'Exchange': 23,
        'TradeType': 2,
        'TimeInForce': 2,
        'Side': '2',
        'Qty': 1,
        'ClosePositionOrder': 1,
        'FrontOrderType': 30,
        'Price': 0,
        'ExpireDay': 0,
        'ReverseLimitOrder': {
                               'TriggerPrice': 1150,
                               'UnderOver': 1, #1.以下 2.以上
                               'AfterHitOrderType': 1, #1.成行 2.指値
                               'AfterHitPrice': 0
                             }
      }
json_data = json.dumps(obj).encode('utf-8')

url = 'http://localhost:18080/kabusapi/sendorder/option'
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

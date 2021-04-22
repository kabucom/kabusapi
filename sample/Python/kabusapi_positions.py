import urllib.request
import json
import pprint

url = 'http://localhost:18080/kabusapi/positions'
params = { 'product': 0 }   	# product - 0:すべて、1:現物、2:信用、3:先物、4:OP
params['symbol'] = '9433'  		# symbol='xxxx'
params['side'] = '1' 				# 1:売、2:買
params['addinfo'] = 'false' 	# true:追加情報を出力する、false:追加情報を出力しない　※追加情報は、「現在値」、「評価金額」、「評価損益額」、「評価損益率」を意味します
req = urllib.request.Request('{}?{}'.format(url, urllib.parse.urlencode(params)), method='GET')
req.add_header('Content-Type', 'application/json')
req.add_header('X-API-KEY', '43e7cc3611fd476db35e93c36a3f77ef')

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

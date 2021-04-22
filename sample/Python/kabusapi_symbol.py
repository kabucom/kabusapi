import urllib.request
import json
import pprint

url = 'http://localhost:18080/kabusapi/symbol/5401@1'
params = { 'addinfo': 'false' } # true:追加情報を出力する、false:追加情報を出力しない　※追加情報は、「時価総額」、「発行済み株式数」、「決算期日」、「清算値」を意味します
req = urllib.request.Request('{}?{}'.format(url, urllib.parse.urlencode(params)), method='GET')
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

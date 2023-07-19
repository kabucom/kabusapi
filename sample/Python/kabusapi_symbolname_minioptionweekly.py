import urllib.request
import json
import pprint

url = 'http://localhost:18080/kabusapi/symbolname/minioptionweekly'
params = { 'DerivMonth': 202306, 'DerivWeekly': 1, 'PutOrCall': 'C', 'StrikePrice': 27250 }

req = urllib.request.Request('{}?{}'.format(url, urllib.parse.urlencode(params)), method='GET')
req.add_header('Content-Type', 'application/json')
req.add_header('X-API-KEY', '4e6652bf433a4a799f86d26988c306c3')

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

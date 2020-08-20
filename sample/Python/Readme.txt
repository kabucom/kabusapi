【前提】
・PCにpython3がインストールされていること。
・PUSH配信(websocket)をするには、python3のインストール後にコマンドプロンプトにて以下のコマンドを実行する。
コマンド：py -m pip install websocket-client

【注意】
「token.py」ファイル名は、pythonで予約とされているため使用できません。

【kabuステAPI実行方法】
コマンドプロンプトから、各コマンドを実行する。

１．トークン発行
コマンド：python kabusapi_token.py
※１で発行したトークンを２以降の各ファイル内の「X-API-KEY」に指定する

２．注文発注
コマンド：python kabusapi_sendorder.py

３．注文取消
コマンド：python kabusapi_cancelorder.py

４．取引余力（現物）
コマンド：python kabusapi_cash.py

５．取引余力（信用）
コマンド：python kabusapi_margin.py

６．時価情報・板情報
コマンド：python kabusapi_board.py

７．銘柄情報
コマンド：python kabusapi_symbol.py

８．注文約定照会
コマンド：python kabusapi_orders.py

９．残高照会
コマンド：python kabusapi_positions.py

10．PUSH配信開始
コマンド：python kabusapi_websocket.py

11．銘柄登録
コマンド：python kabusapi_register.py

12．銘柄登録解除
コマンド：python kabusapi_unregister.py

13．銘柄登録全解除
コマンド：python kabusapi_unregisterall.py


// ライセンスについて
Copyright (c) 2020 au Kabucom Securities Co., Ltd.
Released under the MIT license
https://opensource.org/licenses/mit-license.php

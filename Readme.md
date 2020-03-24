# MySQL Connectorのダウンロード
http://dev.mysql.com/downloads/connector/net/
こちらよりMono用のMySQL Connectorをダウンロードします.

Select Platform: で .NET & Mono を選択

# ConnectorをUnityにインポート
ダウンロードして得られたファイルの中で、
mysql-connector-net-x.x.x-noinstall > v2.0 > mysql.data.dll
をUnityAsset内の Plugins フォルダに入れる.

# Api Compatibility Level を変更
Player Settings > Optimization > Api Compatibility Level を
.NET 2.0 に変更
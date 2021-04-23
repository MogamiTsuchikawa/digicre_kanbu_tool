# クソセル結合名簿コンバーター
学生課のセル結合された名簿を自動的に書き込むツールです。

## 動作環境
Python3系統が動作する環境  
Windows,Linux,Mac問わず動作するはず  

## 使い方
`pip3 install -r requirements.txt`で必要なライブラリをインストールします。  
`python3 convert.py 読み込みするExcelファイルのパス.xlsx 出力するExcelファイルのパス.xlsx`を実行  
名簿のベースとなる`meibo_base.xlsx`以外、Gitの無視リストに追加してあるので、そのままこのフォルダにExcelファイルを置いても安全です。  
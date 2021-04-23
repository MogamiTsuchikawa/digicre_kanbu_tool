#!/usr/bin/env python3

import openpyxl
import sys

if len(sys.argv) < 3:
    print("最低限の引数が指定されていません。")
    exit()

from_file_path = sys.argv[1]
to_file_path = sys.argv[2]

from_xl = openpyxl.load_workbook(from_file_path)
to_xl = openpyxl.load_workbook("meibo_base.xlsx")
from_sheet = from_xl.worksheets[0]
to_sheet = to_xl.worksheets[0]

from_row = 2
to_row = 8
ids=[]
while True:
    if from_sheet.cell(from_row,1).value == None:
        break
    #処理
    if from_sheet.cell(from_row,3).value == "いいえ":
        from_row+=1
        continue
    if from_sheet.cell(from_row,2).value.split('@')[0] in ids:
        from_row+=1
        continue
    #学籍番号
    to_sheet.cell(to_row,4).value = from_sheet.cell(from_row,2).value.split('@')[0]
    ids.append(to_sheet.cell(to_row,4).value)
    #学年
    gakunen_str = from_sheet.cell(from_row,4).value
    if 'B' in gakunen_str:
        gakunen_str = gakunen_str.replace('B','')
    to_sheet.cell(to_row,5).value = gakunen_str
    #性別
    to_sheet.cell(to_row,6).value = from_sheet.cell(from_row,5).value
    #氏名
    to_sheet.cell(to_row,7).value = from_sheet.cell(from_row,6).value
    #本人携帯電話番号
    to_sheet.cell(to_row,8).value = from_sheet.cell(from_row,7).value.replace(' ','').replace('-','')
    #本人住所
    to_sheet.cell(to_row,9).value = from_sheet.cell(from_row,8).value.replace('\n','')
    #緊急連絡先氏名
    to_sheet.cell(to_row,10).value = from_sheet.cell(from_row,9).value
    #緊急連作先携帯電話番号
    to_sheet.cell(to_row,12).value = from_sheet.cell(from_row,10).value.replace(' ','').replace('-','')
    #緊急連絡先自宅電話番号
    to_sheet.cell(to_row+1,12).value = from_sheet.cell(from_row,11).value.replace(' ','').replace('-','')
    #緊急連絡先住所
    to_sheet.cell(to_row,13).value = from_sheet.cell(from_row,12).value.replace('\n','')
    from_row += 1
    to_row += 2

to_xl.save(to_file_path)

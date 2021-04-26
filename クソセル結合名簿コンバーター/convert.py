#!/usr/bin/env python3

import openpyxl
import sys

if len(sys.argv) < 3:
    print("最低限の引数が指定されていません。")
    exit()

from_file_path = sys.argv[1]
to_file_path = sys.argv[2]

from_xl = openpyxl.load




import pyodbc
import pickle

SERVER = "DESKTOP-28KA6OU\\SQLEXPRESS"
DATABASE = "THERMOCHEM"

cnxn = pyodbc.connect("DRIVER={ODBC Driver 17 for SQL Server};SERVER=" + SERVER + ";DATABASE=" + DATABASE + ";Trusted_Connection=yes;")

cursor = cnxn.cursor()

insert_query = '''INSERT A6_TABLE_SUPERHEATED_WATER(Pressure, Temperature, Specific_Volume
      ,Internal_Energy
      ,Enthalpy
      ,Entropy)
      VALUES (?, ?, ?, ?, ?, ?);'''

valuestore = ""
qmark = 0
emark = 0
store1 = []
store2 = []
store3 = []
matrixrow1 = []
matrixrow2 = []
matrixrow3 = []
Pressureval = []
matrix = []
file = open("Table6.txt", "r")
for line in file.readlines():
    store1 = []
    store2 = []
    store3 = []
    for char in line:
        if char == "?":
            if qmark == 4:
                qmark = 0
                Pressureval = []
            if qmark != 0:
                Pressureval.append(float(valuestore))
            qmark += 1
            valuestore = ""
        if char == "!":
            emark += 1
        if (char == " " or char == "\n" or char == "*") and valuestore != '':
            if emark == 0:
                temp = valuestore
            if emark == 1:
                if store1 == []:
                    store1.append(Pressureval[0])
                store1.append(float(valuestore))
            if emark == 2:
                if store2 == []:
                    store2.append(Pressureval[1])
                store2.append(float(valuestore))
            if emark == 3 or emark == 4 and char != "*":
                if store3 == []:
                    store3.append(Pressureval[2])
                store3.append(float(valuestore))
            valuestore = ""
        if emark == 4 and char == "\n":
            emark = 0
        if char != "\n" and char != "," and char != "?" and char != "!" and char != "*":
            valuestore += char
    if store1 != []:
        store1.insert(1, float(temp))
        matrixrow1.append(store1)
    if store2 != []:
        store2.insert(1, float(temp))
        matrixrow2.append(store2)
    if store3 != []:
        store3.insert(1, float(temp))
        matrixrow3.append(store3)
    





    
file.close()


for row in matrixrow3:

    values = (row[0], row[1], row[2], row[3], row[4], row[5])

    cursor.execute(insert_query, values)

cnxn.commit()

cursor.execute("SELECT * FROM A6_TABLE_SUPERHEATED_WATER")

for row in cursor:
    print(row)

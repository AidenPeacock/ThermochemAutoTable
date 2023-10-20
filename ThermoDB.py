import pyodbc
import pickle

SERVER = "DESKTOP-28KA6OU\\SQLEXPRESS"
DATABASE = "THERMOCHEM"

cnxn = pyodbc.connect("DRIVER={ODBC Driver 17 for SQL Server};SERVER=" + SERVER + ";DATABASE=" + DATABASE + ";Trusted_Connection=yes;")

cursor = cnxn.cursor()

insert_query = '''INSERT A5_PRESS_TABLE_SAT_WATER(Pressure, Temperature, Specific_Volume_Liquid, Specific_Volume_Gas, 
      Internal_Energy_Liquid
      ,Internal_Energy_Difference
      ,Internal_Energy_Gas
      ,Enthalpy_Liquid
      ,Enthalpy_Difference
      ,Enthalpy_Gas
      ,Entropy_Liquid
      ,Entropy_Difference
      ,Entropy_Gas)
      VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);'''

valuestore = ""
matrix = []
matrixrow = []
file = open("Table5.txt", "r")
for line in file.readlines():
    matrixrow = []
    for char in line:
        if (char == " " or char == "\n") and valuestore != '':
            matrixrow.append(float(valuestore))
            valuestore = ""
        if char != "\n" and char != ",":
            valuestore += char


    matrix.append(matrixrow)

matrix.remove([])


matrix[72].append(4.4070)
print(matrix)
file.close()


for row in matrix:

    values = (row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[9], row[10], row[11], row[12])

    cursor.execute(insert_query, values)

cnxn.commit()

cursor.execute("SELECT * FROM A5_PRESS_TABLE_SAT_WATER")

for row in cursor:
    print(row)

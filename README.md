# ThermochemAutoTable
When doing thermochemistry calculations, one often has to do table lookups to find values needed to solve a particular problem,
as the equations that govern the relationships between the variables of a system of water are too complicated to calculate explicitly.
This program does that table lookup for you, given the values are on the tables somewhere, removing the need to constantly have to check table values
This data was loaded into sql tables and queried from a c# windows forms GUI to give the correct numbers. 
The data is origionally from a Thermochemistry textbook PDF, and so I wrote a python program to take in a text file that was basically the PDF copy and pasted
into the text file, with additions of my own to make the data parseable and able to be put neatly into the sql table (Will upload scripts)

![Screenshot (127)](https://github.com/AidenPeacock/ThermochemAutoTable/assets/112777530/eb50a2d7-cde5-414b-9593-89dea1645763)

This turned out to be much harder than origionally anticipated, as the usage of the thermochemistry tables requires some intuition for humans to
use, and so writing out all the possible cases for a set of variables was an interesting challenge.

If you want to clone this on your computer, follow the steps in the python files to load the data from the txt files into an sql database with tables named
A4_TEMP_TABLE_SAT_WATER
A5_PRESS_TABLE_SAT_WATER
A6_TABLE_SUPERHEATED_WATER
You need sql and preferrably ssms set up already to connect with pyodbc

TODO: LINEAR INTERPOLATION :(
Pressure Table support

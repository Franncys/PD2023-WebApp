import pyodbc
import mysql.connector
from mysql.connector import Error
import pandas as pd

class DBManager(object):
    def __init__(self, host_name, user_name, user_password):
        self.host_name = host_name
        self.user_name = user_name
        self.user_password = user_password
        self.connection = None

    def create_server_connection(self):
        self.connection = None
        try:
            self.connection = mysql.connector.connect(
                host="localhost",
                user="root",
                password="@dm1n@dm1n",
                database="NarutoDB")
            
            #connection = \
            #    pyodbc.connect(
            #        'DRIVER={ODBC Driver 17 for SQL Server}; \
            #        Server=localhost; \
            #        Port=1433; \
            #        UID=sa; \
            #        Database=NarutoDB; \
            #        PWD=@dm1n@dm1n;')
            # \
            
            print(self.connection)
            print("MySQL Database connection successful")
        except Error as err:
            print(f"Error: '{err}'")

        return self.connection
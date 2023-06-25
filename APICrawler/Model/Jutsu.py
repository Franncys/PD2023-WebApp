from DBManager import DBManager
from mysql.connector import Error

class Jutsu(object):
    def __init__(self):
        self.id = None
        self.name = None
        self.TableName = "Jutsu"
        self.TableCharName = "Character_Jutsu"

    def exists(self, db_manager):
        try:
            print("Checking if Jutsu exists: ", self.name)

            query = "SELECT id FROM Jutsu WHERE jutsu_name LIKE %s"
            values = (self.name,)

            print("Search Jutsu Query: ", query)
            print("Values to search: ", values)

            print("Before Cursor")
            cursor = db_manager.connection.cursor(buffered=True)

            print("Before Execute")
            cursor.execute(query, values)

            print("After Execute")
            # Check if the ID exists
            exists = False

            resultId = cursor.fetchone()

            print("ResultID Jutsu: ", resultId)
            
            if(resultId is not None):
                exists = resultId is not None
                self.id = resultId[0]

            cursor.close()

            return exists
        except Error as err:
            print(f"Error: '{err}'")
            exists = False
        

    def addJutsu(self, db_manager):
        try:
            exists = self.exists(db_manager)

            if(exists is False):
                print("Inserting Jutsu: ", self.name)
                query = "INSERT INTO Jutsu (jutsu_name) VALUES (%s)"
                values = (self.name,)
                cursor = db_manager.connection.cursor(buffered=True)
                cursor.execute(query, values)
                db_manager.connection.commit()
                cursor.close()
                self.exists(db_manager)

        except Error as err:
            print(f"Error: '{err}'")
        pass

    def linkWithCharacter(self, id_char, db_manager):
        try:
            query = "INSERT INTO Character_Jutsu (id_character, id_jutsu) VALUES (%s, %s)"
            values = (id_char, self.id)

            print("Insert Query: ", query)
            print("Values to be Inserted: ", values)

            print("Jutsu ID: ", self.id)

            cursor = db_manager.connection.cursor(buffered=True)
            execute = cursor.execute(query, values)
            commit = db_manager.connection.commit()

            print("Execute Details", execute)
            print("Commit Details", commit)

            cursor.close()

        except Error as err:
            print(f"Error: '{err}'")
        pass
from DBManager import DBManager
from mysql.connector import Error
import json

class Character(object):
    def __init__(self, id, name):
        self.id = id
        self.name = name
        self.url = ""
        self.debut = ""
        self.image_url = None
        self.personal_detail = ""
        self.sex = ""
        self.TableName = "Characters"

    def set_url(self, url):
        self.url = url
    
    def set_debut(self, debut):
        self.debut = debut

    def exists(self, db_manager):
        try:
            print("Checking if character exists: ", self.name)
            query = "SELECT id FROM Characters WHERE char_name LIKE %s"
            values = (self.name,)
            cursor = db_manager.connection.cursor(buffered=True)
            cursor.execute(query, values)
            
            # Check if the ID exists
            exists = False

            resultId = cursor.fetchone()

            print("Result: ", resultId)
            
            if(resultId is not None):
                exists = resultId is not None
                self.id = resultId

            cursor.close()

            return exists
        except Error as err:
            print(f"Error: '{err}'")
            exists = False


    def addCharacter(self, db_manager):
        try:
            exist = self.exists(db_manager)

            if(exist is False):
                print("Going to Insert")
                print("Inserting character: ", self.name)
                query = "INSERT INTO Characters(id, char_name, image_url, debut, personal_detail) VALUES (%s, %s, %s, %s, %s)"

                debutJson = json.dumps(self.debut)
                personalDetailsJson = json.dumps(self.personal_detail)

                values = (self.id, self.name, self.image_url, debutJson, personalDetailsJson)

                print("Insert Query: ", query)
                print("Values to be Inserted: ", values)

                cursor = db_manager.connection.cursor(buffered=True)
                execute = cursor.execute(query, values)
                commit = db_manager.connection.commit()

                print("Execute Details", execute)
                print("Commit Details", commit)

                cursor.close()
                self.exists(db_manager)

        except Error as err:
            print(f"Error: '{err}'")
        pass


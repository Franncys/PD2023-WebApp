from DBManager import DBManager
from mysql.connector import Error

class VoiceActor(object):
    def __init__(self):
        self.id = None
        self.name = None
        self.language = None
        self.TableName = 'VoiceActor'
        self.TableCharName = 'Character_VoiceActor'

    def exists(self, db_manager):
        try:
            exists = False
            query = "SELECT id FROM VoiceActor WHERE actor_name = %s"
            values = (self.name,)
            cursor = db_manager.connection.cursor(buffered=True)
            cursor.execute(query, values)

            # Check if the ID exists
            resultId = cursor.fetchone()

            if(resultId is not None):
                exists = resultId is not None
                self.id = resultId[0]

            cursor.close()

            return exists
        except Error as err:
            print(f"Error: '{err}'")
        

    def addActor(self, db_manager):
        try:
            exists = self.exists(db_manager)

            if(exists is False):
                query = "INSERT INTO VoiceActor(actor_name, language_version) VALUES (%s, %s)"
                values = (self.name, self.language)
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
            query = "INSERT INTO Character_VoiceActor(id_character, id_actor) VALUES (%s, %s)"
            values = (id_char, self.id)
            
            print("Link User and Actor Query: ", query)
            print("Values to be Inserted: ", values)

            print("Actor ID: ", self.id)

            cursor = db_manager.connection.cursor(buffered=True)
            execute = cursor.execute(query, values)
            commit = db_manager.connection.commit()

            print("Execute Details", execute)
            print("Commit Details", commit)

            cursor.close()

        except Error as err:
            print(f"Error: '{err}'")
        pass

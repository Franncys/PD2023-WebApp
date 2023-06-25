from DBManager import DBManager
from mysql.connector import Error

class Item(object):
    def __init__(self):
        self.id = None
        self.name = None
        self.TableName = 'Item'
        self.TableCharName = 'Character_Item'

    def exists(self, db_manager):
        try:
            query = "SELECT id FROM Item WHERE item_name LIKE %s"
            values = (self.name,)
            cursor = db_manager.connection.cursor(buffered=True)
            cursor.execute(query, values)

            # Check if the ID exists
            exists = False

            resultId = cursor.fetchone()
            
            if(resultId is not None):
                exists = resultId is not None
                self.id = resultId

            cursor.close()

            return exists
        except Error as err:
            print(f"Error: '{err}'")

    def addActor(self, db_manager):
        try:
            exist = self.exists(db_manager)

            if(exist is False):
                query = "INSERT INTO Item (item_name) VALUES (%s)"
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
            query = "INSERT INTO Character_Item (id_character, id_item) VALUES (%s, %s)"
            values = (id_char, self.id)
            cursor = db_manager.connection.cursor(buffered=True)
            cursor.execute(query, values)
            db_manager.connection.commit()
            cursor.close()

        except Error as err:
            print(f"Error: '{err}'")
        pass

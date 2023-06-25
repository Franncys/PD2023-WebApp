from DBManager import DBManager
from mysql.connector import Error

class Team(object):
    def __init__(self):
        self.id = None
        self.name = None
        self.TableName = 'Team'
        self.TableCharName = 'Character_Team'

    def exists(self, db_manager):
        try:
            exists = False
            query = "SELECT id FROM Team WHERE team_name LIKE %s"
            values = (self.name,)
            cursor = db_manager.connection.cursor(buffered=True)
            cursor.execute(query, values)

            # Check if the ID exists
            exists = False

            resultId = cursor.fetchone()
            
            if(resultId is not None):
                exists = resultId is not None
                self.id = resultId[0]

            cursor.close()

            return exists
        except Error as err:
            print(f"Error: '{err}'")
            exists = False

    def addTeam(self, db_manager):
        try:
            exist = self.exists(db_manager)

            if(exist is False):
                query = "INSERT INTO Team (team_name) VALUES (%s)"
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
            query = "INSERT INTO Character_Team (id_character, id_team) VALUES (%s, %s)"
            values = (id_char, self.id)
            cursor = db_manager.connection.cursor(buffered=True)
            cursor.execute(query, values)
            db_manager.connection.commit()
            cursor.close()

        except Error as err:
            print(f"Error: '{err}'")
        pass
import requests
import ApiCrawlerHelper 
from Model.Character import Character
from DBManager import DBManager


def crawl_narutodb_api():
    # Specify the API endpoint you want to crawl
    endpoint = 'https://api.narutodb.xyz/character'

    # Send a GET request to the API endpoint
    response = requests.get(endpoint)

    # Check if the request was successful (status code 200)
    if response.status_code == 200:
        # Extract the response data in JSON format
        data = response.json()

        numberOfCharacters = data['totalCharacters']

        # Process the data as needed
        for characters in data['characters']:
            character = ApiCrawlerHelper.processCharacter(characters)
            character.addCharacter(db_manager)
            ApiCrawlerHelper.processAssociatedInfo(characters['id'], characters, db_manager)
            
    else:
        print('Error:', response.status_code)

# Call the function to crawl the Narutodb API
db_manager = DBManager('localhost','sa','@dm1n@dm1n')
db_manager.create_server_connection()
crawl_narutodb_api()
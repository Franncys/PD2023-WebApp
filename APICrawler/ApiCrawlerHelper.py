from Model.Character import Character
from Model.Clan import Clan
from Model.Item import Item
from Model.Jutsu import Jutsu
from Model.Team import Team
from Model.VoiceActor import VoiceActor

from DBManager import DBManager

def is_one_dimensional(dictionary):
    for value in dictionary.values():
        if isinstance(value, dict):
            return False
    return True

def parse_CharacterDebut(debut):
    return debut

def parse_PersonalDetails(personal):
    personal_details = {}
    #personal
    # sex, age[], height[], wheight[], team[], affiliation[], clan, bloodType, 
    return personal

def parse_VoiceActors(voiceActors):
    dic_voiceActors = {}
    
    if voiceActors.get('japanese') is not None:
        dic_voiceActors['japanese'] = voiceActors['japanese']

    if voiceActors.get('english') is not None:
        dic_voiceActors['english'] = voiceActors['english']
    
    return dic_voiceActors

def getOrCreateFamily(family):

    return

def processAssociatedInfo(idChar, characters, db_manager):
    # Team, Jutsu, Clan, Voice Actor; 
    #if characters.get('personal') is not None:
    
    if characters.get('jutsu') is not None:
        for jutsus in characters['jutsu']:
            jutsuToAdd = Jutsu()
            jutsuToAdd.name = jutsus
            jutsuToAdd.addJutsu(db_manager)
            jutsuToAdd.linkWithCharacter(idChar, db_manager)

    if characters.get('voiceActors') is not None:
        dic_voiceActors = parse_VoiceActors(characters['voiceActors'])
        
        if dic_voiceActors.get('japanese') is not None:
            if(isinstance(dic_voiceActors['japanese'], str)):
                voiceActor = VoiceActor()
                voiceActor.language = 'Japanese'
                voiceActor.name = dic_voiceActors['japanese']
                voiceActor.addActor(db_manager)
                voiceActor.linkWithCharacter(idChar, db_manager)

        if dic_voiceActors.get('english') is not None:
            if(isinstance(dic_voiceActors['english'], str)):
                voiceActor = VoiceActor()
                voiceActor.language = 'English'
                voiceActor.name = dic_voiceActors['english']
                voiceActor.addActor(db_manager)
                voiceActor.linkWithCharacter(idChar, db_manager)

    return 

def processCharacter(characters):
    character_id            = characters['id']
    character_name          = characters['name']

    character = Character(character_id, character_name)
    
    if characters.get('images') is not None:
        character_imageUrl      = characters['images']
        character.set_url(character_imageUrl)

    if characters.get('debut') is not None:
        character_debut         = parse_CharacterDebut(characters['debut'])
        character.set_debut(character_debut)
    
    if characters.get('personal') is not None:
        character_personal      = parse_PersonalDetails(characters['personal'])
        character.personal_detail = character_personal

    return character
import json
import pandas as pd
from deeppavlov import configs, build_model
from classifier import  classify, lemm
import os
os.environ['TF_CPP_MIN_LOG_LEVEL'] = '3'

from elasticsearch import Elasticsearch
es = Elasticsearch()

models = {
    "squad" : build_model(configs.squad.squad_ru_bert, download=False),
    "ner" : build_model(configs.ner.ner_rus_bert, download=False),
    "search" : es
}

class SearchEngine():
    pass


if __name__ == "__main__":
    dfq = pd.read_csv("questions.csv", sep=';')
    qlist = list(dfq["question"])
    # dfq["lemmatization"] = dfq["question"].apply(lemm)
    with open("road_map.json", 'r', encoding="utf-8") as file:
        road_map = json.load(file)

    text = lemm(qlist[0])
    tokens, ners = models['ner']([text])
    print(tokens, ners)

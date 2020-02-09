from pymorphy2 import MorphAnalyzer
import pandas as pd
import re
import string
import json
from collections import Counter

def lemm(text):
    # lowercase
    text = ' '.join(word.lower() for word in text.split())
    # убираем переносы строки и тд
    text = re.sub("\-\s\r\n\s{1,}|\-\s\r\n|\r\n", '', text)
    # все спецсимволы меняем на пробел
    for chr in string.punctuation:
        text = text.replace(chr, ' ')
    # слово к нормлаьному виду
    text = ' '.join(MorphAnalyzer().parse(word)[0].normal_form for word in text.split())
    return text


def classify(question, routes):
    lemmedq = lemm(question)
    k_cntr = Counter()

    for rt in routes:
        for kwrd in routes[rt]["keywords"]:
            if kwrd in lemmedq:
                k_cntr[rt] += 1
    return k_cntr.most_common(1)[0][1]


if __name__ == "__main__":
    dfq = pd.read_csv("questions.csv", sep=';')
    qlist = list(dfq["question"])
    # dfq["lemmatization"] = dfq["question"].apply(lemm)
    with open("road_map.json", 'r', encoding="utf-8") as file:
        road_map = json.load(file)

    print(classify(qlist[0], road_map))






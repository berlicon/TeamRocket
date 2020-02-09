from pymorphy2 import MorphAnalyzer
import pandas as pd
import re
import string


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


if __name__ == "__main__":
    dfq = pd.read_csv("data/questions.csv", sep=';')
    dfq["lemmatization"] = dfq["question"].apply(lemm)

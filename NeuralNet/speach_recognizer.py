import os
import json
import requests
from pydub import AudioSegment


def convert(root_voice: str, format_str: str) -> str:
    for vfn in os.listdir(root_voice):
        vfnp = vfn.split('.')
        if vfnp[-1] == format_str:
            vm4a = AudioSegment.from_file(root_voice + vfn, format_str)
            with open(f"{vfnp[0]}.ogg", "wb") as voggf:
                vm4a.export(voggf, format="ogg")


def read_secret(f_path: str) -> str:
    with open(f_path, "r") as f:
        secret = f.read().replace('\n', '')
    return secret


def get_iam_token() -> str:
    oauth_token = read_secret("token_oauth.txt")
    url = "https://iam.api.cloud.yandex.net/iam/v1/tokens"
    data = {"yandexPassportOauthToken": oauth_token}
    answer = requests.post(url, json=data)
    return answer.json()['iamToken']


def recognize(vocie_file) -> str:
    folder_id = read_secret("folder_id.txt")
    url = f"https://stt.api.cloud.yandex.net/speech/v1/stt:recognize?folderId={folder_id}"
    answer = requests.post(url, headers={"Authorization": f"Bearer {get_iam_token()}"}, data=vocie_file)

    if answer.status_code != 200:
        return "Ошибка распознавания речи. Попробуйте ввести запрос на клавиатуре."
    else:
        return answer.json()["result"]


def get_files(root_voice: str, format_str: str):
    varr = []
    for vfn in os.listdir(root_voice):
        vfnp = vfn.split('.')
        if vfnp[-1] == format_str:
            with open(root_voice + vfn, "rb") as vf:
                varr.append(vf.read())
    return varr


if __name__ == "__main__":
    # convert("test_voice/", "m4a")

    for vfile in get_files("test_voice/", "ogg"):
        print(recognize(vfile))

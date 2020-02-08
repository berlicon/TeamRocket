import os
from pydub import AudioSegment


def convert(root_voice : str, format_str : str) -> str:
    for vfn in os.listdir(root_voice):
        vfnp = vfn.split('.')
        if vfnp[-1] == format_str:
            vm4a = AudioSegment.from_file(root_voice + vfn, format_str)
            with open(f"{vfnp[0]}.ogg", "wb") as voggf:
                vm4a.export(voggf, format="ogg")


def read_token(f_path: str) -> str:
    with open(f_path, "r") as f:
        token = f.read().replace('\n', '')
    return token


if __name__ == "__main__":
    # convert("test_voice/", "m4a")
    print(read_token("token.txt"))
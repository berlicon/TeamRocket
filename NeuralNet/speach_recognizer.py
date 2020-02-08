import os
from pydub import AudioSegment


def convert(root_voice, format_str):
    for vfn in os.listdir(root_voice):
        vfnp = vfn.split('.')
        if vfnp[-1] == format_str:
            vm4a = AudioSegment.from_file(root_voice + vfn, format_str)
            with open(f"{vfnp[0]}.ogg", "wb") as voggf:
                vm4a.export(voggf, format="ogg")


if __name__ == "__main__":
    convert("test_voice/", "m4a")


oauth_token = "AgAAAAAOOjGmAATuwRo8IAGkZE6Qj85CimQnKY4"

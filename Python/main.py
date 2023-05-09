from os import path, listdir, mkdir
from libxmp.utils import file_to_dict as ftd
import shutil
from time import sleep

# List variables for each bandName (RGB, Red, Green, Blue, RedEdge, NIR)

rgb = []

red=[]

blue = []

rededge = []

green = []

blue = []

nir = []

# Create list of all files in current directory

all_files = listdir(".")

# Create new list of strings found in all_files ending in .TIF, .TIFF, .JPG, .JPEG and .PNG

print("Looking for .TIF, .JPG or .PNG files in the current directory...")

sleep(2)

img_files = []

for img in all_files:

    if img.endswith(".TIF") or img.endswith(".TIFF"):

        img_files.append(img)

        print(img_files)

        print(f"{img} was found...")

    elif img.endswith(".JPG") or img.endswith(".JPEG") or img.endswith(".PNG"):

        rgb.append(img)

        print(rgb)

        print(f"{img} was found with not camera band metadata, presumed to be RGB...")

#Sorting NIR, Rededge, Red, Green and Blue files and storing their path in the respective lists (red, green, blue, rededge, nir)

for img in img_files:

    xmp = ftd(img)

    pix4d = xmp["http://pix4d.com/camera/1.0"]
    dji = xmp["http://www.dji.com/drone-dji/1.0/"]

    for metadata in dji:
        if "Red" in metadata:
            red.append(img)
        elif "Green" in metadata:
            green.append(img)
        elif "Blue" in metadata:
            blue.append(img)
        elif "RedEdge" in metadata:
            rededge.append(img)
        elif "NIR" in metadata:
            nir.append(img)

# print(rededge)
# print(red)
# print(green)
# print(blue)
# print(rgb)

# Code creating folders for each BandName (Pre-determined)

print("Creating imagery bands directories...")

sleep(2)

# Check for existing "rgb" directory and create one if it doesn't exist

if not path.exists("rgb"):
    mkdir("rgb")
    print("Directory 'rgb' created")
else:    
    print("Directory 'rgb' already exists")


# Check for existing "red" directory and create one if it doesn't exist

if not path.exists("red"):
    mkdir("red")
    print("Directory 'red' created")
else:    
    print("Directory 'red' already exists")


# Check for existing "green" directory and create one if it doesn't exist

if not path.exists("green"):
    mkdir("green")
    print("Directory 'green' created")
else:    
    print("Directory 'green' already exists")


# Check for existing "blue" directory and create one if it doesn't exist
  
if not path.exists("blue"):
    mkdir("blue")
    print("Directory 'blue' created")
else:    
    print("Directory 'blue' already exists")


# Check for existing "rededge" directory and create one if it doesn't exist

if not path.exists("rededge"):
    mkdir("rededge")
    print("Directory 'rededge' created")
else:    
    print("Directory 'rededge' already exists")


# Check for existing "nir" directory and create one if it doesn't exist

if not path.exists("nir"):
    mkdir("nir")
    print("Directory 'nir' created")
else:    
    print("Directory 'nir' already exists")


# Moving each files found in each list to their appropriate newly created directory

# Move the RGB band files

for img in rgb:
    shutil.move(img, "rgb")

# Move the Red band files

for img in red:
    shutil.move(img, "red")

# Move the Green band files

for img in green:
    shutil.move(img, "green")

# Move the Blue band files

for img in blue:
    shutil.move(img, "blue")

# Move the RedEdge band files

for img in rededge:
    shutil.move(img, "rededge")

# Move the NIR band files

for img in nir:
    shutil.move(img, "nir")



exit()
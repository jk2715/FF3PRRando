# FF3PRRando
Randomizer for Final Fantasy III Pixel Remaster. Currently still in Alpha, so expect to find some bugs. More features are planned for the future!

# Features:

## Shop Randomization
Shuffle all shop inventory. Each shop will still sell the kind of inventory it is expected to, i.e. weapons shops will only sell weapons, magic shops will sell magic etc. Enabling this option will cause the Gnomish Bread shop in Tozus to always 
sell Antidotes to ensure runs are always completable. 

## Treasure Randomization
Shuffle all chest contents. This also includes items obtained from pots and the like. 
Items gifted by NPCs, Key Items and other items obtained through the story are not included.

## Background Music Randomization
Shuffles background music. Certain fanfares such as those that play when obtaining an important item
or when a guest joins the party are not shuffled, as doing so causes a softlock when said events happen. 

## Job Randomization (Experimental)
Shuffles all 21 obtainable jobs. Enabling this option will cause mallets to be given out at various points in the game and will disable the Toad status requirement for various dungeons to ensure all runs are completable.

EXPERIMENTAL: Enabling this feature leads to a bug where certain jobs may take on the 3rd and 4th command of a different job. The game is still playable and jobs function normally otherwise

# Installation and Use
Requires the following to be installed:

UnityPlayer CRC Check Bypass:
https://www.nexusmods.com/finalfantasy5pixelremaster/mods/58

BepInEx:
https://github.com/BepInEx/BepInEx/releases/download/v6.0.0-pre.2/BepInEx-Unity.IL2CPP-win-x64-6.0.0-pre.2.zip

Magicite:
https://github.com/Silvris/Magicite/releases/download/v2.2.0/Magicite-2-2-0.zip

Microsoft .NET 8 Runtime

Once the installation is complete, you must export the game files using magicite. When running the randomizer, the resulting
magicite export directory is required. The randomized files will save to the specified output folder, this folder should be 
copied to the game directory at FINAL FANTASY III_Data\StreamingAssets\Magicite. A spoiler log is also generated in the randomizer directory.

# Disclaimer
The randomizer currently only runs on Windows, a Linux/Mac port may be considered in the future.

# Compiling
Compilation requires Microsoft .NET 8 be installed, and the FF3PR.Data project should be added as a reference.

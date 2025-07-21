# EUPToUB & WardrobeINIConverter
⚠️ Disclaimer:
I am not responsible for any issues or damage to your game files. Use at your own risk.

[![wakatime](https://wakatime.com/badge/github/AstroBurgers/EUPtoUB.svg)](https://wakatime.com/badge/github/AstroBurgers/EUPtoUB)

## Overview

**EUPToUB** is a lightweight RagePluginHook (RPH) plugin that converts your player’s current outfit into the *UltimateBackup* XML format in-game, and saves each entry to a file.

**WardrobeINIConverter** is a standalone tool (CLI executable) designed to convert the contents of your `wardrobe.ini` from EUP format into UltimateBackup-compatible Ped Entries.

---

## Features

- **EUPToUB**
  - Real-time conversion of player outfits inside GTA V.
  - One-by-one outfit conversion, perfect for small scale edits.

- **WardrobeINIConverter**
  - Efficiently parses large wardrobe.ini files.
  - Converts EUP wardrobe data into the UltimateBackup XML Ped Entry format.
  - Supports multi-threaded parsing for performance.

---

## Performance

Tested on a synthetic `wardrobe.ini` with **13 million lines** on a Ryzen 5600 6-core OC @ 4.4 GHz:

| Run  | Time (ms) |
|-------|-----------|
| 1     | 6341      |
| 2     | 9022      |
| 3     | 7492      |
| 4     | 7073      |
| 5     | 5861      |
| 6     | 6679      |
| 7     | 5916      |
| 8     | 6226      |
| 9     | 6206      |
| 10    | 6228      |
| **Median** | **6284.5**  |
---
*What does this mean in layman's terms?*</br>
**On a regular Wardrobe.ini file it runs *literally* faster than you can blink**
## Installation & Usage

### EUPToUB Plugin

1. Load the plugin in RagePluginHook
2. Equip your desired outfit in the EUP menu.
3. Open the F4 console and type: `PrintCurrentOutfit`
4. This saves your outfit data to ConvertedLines.txt.
5. Copy the output lines into your UltimateBackup XML ped configurations — remember to adjust the Chance value as needed.

### WardrobeINIConverter

1. Download the rar from the releases.
2. Extract the contents of the rar somewhere safe
3. Drag and Drop the files into your GTA5 root folder (where your GTA5.exe is)
4. Run the executable
5. Fetch your freshly converted Ped Entries from `Grand Theft Auto V\WardrobeINIConverter\ConvertedLines.txt`

@echo off
fastboot -i 0x1EBF flash recovery C:\adb\recovery-twrp-mm.img
fastboot -i 0x1EBF flash boot C:\adb\boot.img
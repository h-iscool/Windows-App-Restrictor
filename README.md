THIS PROJECT IS BEING REMADE:
[NEW VERSION](https://github.com/h-iscool/Windows-App-Manager/tree/main)

# Windows-App-Restrictor

A simple application for restricting apps on a windows pc.

## How to Use:

### Setup:

1.) Open the app by right clicking and running as administrator OR by running with command line arguments "gui" and "enableAll"
2.) Click on the "Open File Manager" button
3.) Select either "whitelist" or "blacklist" for the restriction type
4.) Open all of the apps to add to the list and click refresh
5.) Select all of the apps wanted to be added to the list
6.) Select the other checkboxes near the save file button IF they apply
7.) Click "Save file" and save the file to the directory with the EXE
8.) Run the file normaly to start restriction process

OPTIONAL:

 - If wanted, custom processes can be added by typing "System.Diagnostics.Process (PROCESS NAME);" and replaceing "PROCESS NAME" with the name of the process
 - If wanted, the app can be placed in the startup folder ("C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Startup" for all users and "C:\Users\<USER>\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup" for a single user [replaceing <USER> with the user's folder] )
 - Can be done across multiple computers easier by making one file then just putting the file and exe on all computers
 - If .NET 8 is installed, the app can be much smaller (by ~100x) because it doesn't need to have all of the .NET dependencies compilled with the exe (decompiled exe is found in "\bin\Debug\net8.0-windows10.0.17763.0\")

*Currently it is a bit wierd to use, but it will be made more simple soon (probably)

## About:

The features are currently limited yet soon will get better. This is mainly a side project i am doing on the side, so updates and such are not going to be very consistent.
This is a simple restriction tool for people who want to restrict something on a windows PC. It is my first Winform/C# Application and was made in ~4 days.

Created in visual studio 2022

Development started on 4/4/2025 at 1:01 in the morning ;w;

If there are any major problems, you can contact me (or fix it yourself and recompile):
hbushnell1515@gmail.com


why does this md feel so formal?? its wierd

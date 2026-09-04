Modding Kitten Space Agency
===========================

Great info at https://modding.kittenspaceagency.wiki/

To run a modded KSA, use StarMap: cd ../StarMap; dotnet StarMap.dll

To install this mod, symlink this directory into KSA's Content/ as RosuavKSAMod


Possible plans:

* Connect to Mustard Mine via websocket
* Report on certain types of event
  - Example: "Crash"
  - Example: "Orbit achieved"
  - This could allow the bot to run a prediction, inviting people to guess which
    event will take place first. In this case, it could be described as "Will he
    get to orbit safely?", with a crash resulting in a "No" result, and orbit in
    a "Yes".
  - Other possibilities include change of SOI, running out of fuel, landing.
* Have interactions from chat that cause stuff to happen in game
  - Channel point redemption to mess with things in some way

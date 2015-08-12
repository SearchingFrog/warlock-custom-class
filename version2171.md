# Details #
[Version 2.17.1](http://warlock-custom-class.googlecode.com/files/Piclock%202_17_1a.zip)
## Overall Update: ##
> This update is for fixes and tests to a few tweaked systems and has only been tested in PVE. I have not tested in a pvp condition in any fashion.  So use at your own risk when it comes to those or atleast use and let us know what went wrong. This beta includes a reworked distance mounting functionality read the notes below.

## Casting Additions: ##
  1. Randomizer for spell casting option has been added to the options configuration under casting and is live.

## Issues Fixed: ##
  1. Issue where a Pet would be resummoned when a target was found while mounted, then dismounting had occurred has been fixed.  This is done by automatically attacking with the first spell (randomized or  not) and then the pet will enter combat. ( you may well see two  sending in pet when this happens).
> > A. Issues with not sending in the pet were fixed due to update part 2.
  1. Fix for Mount key naming convention ( aka Piclock.Mount -> PL.Mount )           A. You MUST change Piclock.Mount -> PL.Mount in Keys.xml
  1. DrainLife function shouldn't cause an exception that will stop gliding now.

## Additions: ##
  1. Use Bloodfury option has been added to options
> > A. Orcs rejoice :P
  1. Profile Targets and Distance Mounting.
> > There has been a change to the Distance Mounting.  The same core logic is still around from prior set of code, but there is a check run against mobs listed in your profile and the distance you would like to mount. Basically this checks if a faction of your profile is at least within range set in the Distance mount option. **NOTE: this needs testing with different profiles and results bugged/issued on the project page**
> > > A. If you use Distance Mount, YOU MUST set this to be the range from your character to check for ProfileTargets before mounting.
> > > > EX. When you have selected "Distance Mount" , Setting "Delay In (s) OR Distance In (yds) for BTM" in the options to 100 will check for any target within 100units that is specified in your profile options. I would suggest 45 or higher for very large areas where your targets are spread out , but you will have to play with this as your profile needs.
  1. Fix for multiple pet attacks being sent with recent additions.
  1. Random other small fixes that went along with this and removal of some debug logging.


Keys: I used a keyset such as ooberwarlock personally, b/c i tend to like playability layout. So the Keys.xml included is based off/copied from Ooberlock's layout.
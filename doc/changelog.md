<a href="../README.md"><kbd>Red Alert Mission Editor</kbd></a> :: <kbd><kbd>Changelog</kbd></kbd><br>
<h2 align="center">Red Alert Mission Editor Changelog</h2>

-------
2025-01-03

- Implement support to handle up to 32 houses. Work on handling them properly in game is still in progress in the sister patching project
- Fix terrian objects BOXES01-BOXES09. They were mistakenly named BOX01-BOX09 prior.
- Infantry with SHP sizes other than 50x40 will be centered correctly now
- Add SHP file editor wityh basic image import/export functions to the 'Other Editors' controls
- Update TMP file editor, and SHP palette converters
- Add some sanity internal checks

-------
2024-12-01

- Implement VQ movie lists in [Basic] editor
- Include overlapping buildings check on the 'Verify Map' function
- Fix drawing of CLEAR1-based tileset previews on the map
- Allow Customization of button images, loaded from 'Assets/buttons/button_xxx.png' files
- Suppress menu shortcut keys on TextBox, ComboBox and NumericUpDown controls, restoring their own shortcut handling (such as Ctrl-C / Ctrl-V)

-------
2024-11-23

- Update project to .NET Framework 4.5
- Missing directories are created instead of causing the app to crash
- Implement [BuildingType] > HasTurret for drawing turret rotations
- Handle smudge levels
- Add TeamType verification to 'Verify Map' function
- Tag checks are now non case-sensitive in 'Verify Map' function
- Fix some malformed undo/redo actions
- Special (CLEAR1-based) tilesets are rendered in 3x2 or 4xn grids
- Allow scrolling of SHP and TMP images that exceed their container dimensions

-------
2024-05-21

- Fix Tmp file viewer for handling of special template files

-------
2024-05-19

- Implement Undo/Redo
- Implement basic map verification checks
- SoundType and SpeechType parameter fixes
- Teamtype script - 'Move to Cell' are now visualized on the map
- Handle [BuildingType] > Bib= in rules
- Editor now loads map-files that are dragged into the map area
- Implement shortcut keys
- Object tags (triggers) now have a dark background
- Implement Tmp file viewer / converter

-------
2023-11-22

- Crash fix for out-of-bound cell checks
- Enhance display names to include ID
- Internal: rename 'Structures' to 'Buildings', 'Ships' to 'Vessels' to match internal type names
- Display render time information in the status bar (time to render the map)

-------
2023-10-30

- Allow unknown objects to be removed with Ctrl-click
- Fix occupancy list for Iron Curtain, Airfield, Adv. Power Plant
- Handle new lovalmidas modded exe rules, such as:
-- [BuildingType] > CustomFoundationList
-- [VesselType] > TurretOffset
-- [VesselType] > TurretAdjustY
-- [VesselType] > HasSecondTurret
- Implement panning of the map with middle-mouse 
- Preplace Building/Base preview now shows whether the tile is blocked from placing buildings (as though constructed from ConYard)
- Implement tiletype colorization for template tiles
- Improve SHP converter performance by performing conversion between full-color and indexed colors in a separate thread, and caching same colors
- Add palette choice support for SHP converter
- Vessel order are fixed (PT, MSUB, LST)

-------
2023-06-16

- TechnoType IDs are now case-insensitive, transforming to uppercase when reference
- SoundTypes, SpeechTypes, Themes, Superweapons and MissionTypes are now listed and selectable in Trigger editor
- Translucent shading for Base buildings
- Preview objects (before placement) now blinks with highlight every second.
- Some stray controls are removed
- INI reading improvements
- [House] > Color and SecondaryColorScheme can support text-based colors e.g. "Red"
- Team Scripttype now accepts RTTIType + ID entry for 'Attack Tarcom'
- Reference viewer (to view use cases for Waypoints, Teams) is implemented
- Non-map Editor modes ('Other Editor'), with SHP Converter and Language File Editor. Saving SHP file is implemented
- Documentation update
- Several other updates

-------
2023-05-21

- Several updates

-------
2022-11-29

- Initial release

<a href="#red-alert-mission-editor-changelog"><kbd>Top</kbd></a><br>
-------
<a href="../README.md"><kbd>Red Alert Mission Editor</kbd></a> :: <kbd><kbd>Changelog</kbd></kbd><br>




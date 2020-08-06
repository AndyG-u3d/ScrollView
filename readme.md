## ScrollView example
### Usage Instructions

- Open the ScrollView scene
- On the left of this scene is a regular scroll view - its items will stack towards the bottom.
- On the right is a reversed scroll view that stacks items towards the top.

### To repro the issue as described
- Run the scene 
- Untick the 'use RectTransform' toggle - this will set ScrollView position according to verticalNormalizedPosition
- Scroll the views to some arbitrary position
- Click 'Insert Item At Top' - this will add a new item at index 0 of both scroll views.

Result: the items in the scroll areas appear to jump around depending on where the scroll position is set to


### Fixed version
- Stop the scene & re-run it. (to avoid layout bugs due to the Use RectTransform toggle)
- Verify that 'use RectTransform' is ticked
- Scroll the views to some arbitrary position
- Click 'Insert Item At Top'

Result: the scroll views function as expected with no positional glitches

## Miscellaneous stuff

### Insert Item at End
Will add a new item at the end of both scroll views.

### Animations
The three buttons at the bottom (Large item, Regular item, Small item) are hooked up to play animations on a specific item in the static list.
This is here simply to verify that stacking works as expected.
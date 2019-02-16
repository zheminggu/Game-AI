## Description

The central purpose of my AI is to mimic human. So it has been split into Determine, Conscious, Behavior and Event.

## Structure

### Folders:

Determine: Like the human, determine is our brain to handle decisions

Events: Some events happened in the game environment. Designers can create their own Event by inheriting the DecideEvents templates.

InsideConsicious:  To generate and to control instinct behaviors

InstinctBehavior： The Basic behavior such move.

LearnedBehavior: The behavior combined different basic moves such as patrolling

SurfaceConsicious: To produce and to handle learned behaviors

Memory: To restore the data of the NPCs. 

### Scripts:

AISettings: Some settings of AI, to set up the AI character's brain. The designers who use this plugin can change AI Settings to set their NPCs.

TestMove: Debug the move of the NPC


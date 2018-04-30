# 'Robot Wars' - OpenTable UK Engineering code test

## Few words from author
1. I manged to complete the exercise so the whole logic is there but it's not perfect - I could use extra hour to improve few parts
2. If I had more time I would:
   - add some tests against CommandValidator - it contains few regular expressions and it's worth testing,
   - update few other tests since the logic evolved a bit since the beginning but still decided to leave all tests anyway since they are testing what needs to be tested,
   - add some integrations tests - unit tests are great and they really helped with the whole implementation when using TDD at the beginning but would be great to run some e2e tests as well,
   - replace some hardcoded values (like directions, commands etc.) to use constants since it can became messy when one of the command is changed
3. App is docerized so the easiest way to run it is just to build the image and run it in interactive mode
4. I made a mistake when creating the project so instead of RobotWars everything is called RoboWars - I didn't have time to rename all parts

## Requirements
A fleet of hand built robots are due to engage in battle for the annual “Robot Wars” competition. Each robot will
be placed within a rectangular battle arena and will navigate their way around the arena using a built in
computer system.

A robot’s location and heading is represented by a combination of x and y co-ordinates and a letter
representing one of the four cardinal compass points. The arena is divided up into a grid to simplify navigation.
An example position might be 0, 0, N which means the robot is in the bottom left corner and facing North.

In order to control a robot, the competition organisers have provided a console for sending a simple string of
letters to the on-board navigation system. The possible letters are ‘L’, ‘R’ and ‘M’. ‘L’ and ‘R’ make the robot spin
90 degrees to the left or right respectively without moving from its current spot while ‘M’ means move forward
one grid point and maintain the same heading. Assume that the square directly North from (x, y) is (x, y+1).

## Input
The first line of input is the upper-right coordinates of the arena, the lower-left coordinates are assumed to be
(0, 0).
The rest of the input is information pertaining to the robots that have been deployed. Each robot has two lines
of input - the first gives the robot’s position and the second is a series of instructions telling the robot how to
move within the arena.
The position is made up of two integers and a letter separated by spaces, corresponding to the x and y
coordinates and the robot’s orientation. Each robot will finish moving sequentially, which means that the
second robot won’t start to move until the first one has finished moving.

## Output
The output for each robot should be its final coordinates and heading.

## Acceptance criteria
In order to confirm your program is working correctly, we have provided some test input and output for your
use. Implement these details however you consider most appropriate.

**Test input:**   
5 5  
1 2 N  
LMLMLMLMM  
3 3 E  
MMRMMRMRRM  

**Expected output:**  
1 3 N  
5 1 E  

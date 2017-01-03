SLMM - The coding exercise for server side applicants
=====================================================

You are encouraged to take no more than 5 hours to implement this, but you are free to take less or more if you want to. Please do not overengineer this exercise, but you are welcome to demonstrate knowledge in a field that can influence this project.

Step 1 – all server-side positions
----------------------------------
Assume we are interested in creating a smart lawn mowing machine called SLMM (smart lawn mowing machine). Your task is to create the software that will run in the SLMM itself and will be responsible for doing the following actions:

1. Turn the SLMM 90o left or right -> This should take 15 seconds to do
2. Move forward by one position -> This takes 30 seconds to do
3. Mow the lawn at the current position -> This takes 120 seconds to do

Please just sleep the thread for the specified duration above to represent\simulate work being done.

The application you will create should be able to accept the above commands and execute them. Since you do not have access to the actual hardware, for now the only thing required is to accept input from console and write the status at the end of the action in the console (write the completed action along with the position of the SLMM as per the acceptance tests below). During application startup, the SLMM is given a set of dimensions (passed in as command line parameters) that represent the width and length of the garden that the SLMM is in.

### Commands accepted
1. TL -> Turn Left
2. TR -> Turn Right
3. MF -> Move Forward
4. ML -> Mow Lawn. This mows the lawn at the current location only and does not turn on mowing indefinitely. After 120 seconds (which is the time needed for this as specified above), just assume that the mower automatically stops

### Deliverable
One console application that represents the application as described. You should provide access to an online repository, based on this one that contains all source code for this application, along with complete instructions on how to build your application locally. If any tests or libraries were written, please provide code for all and full instructions on how to run the build and tests.

### Acceptance criteria
1. The SLMM never goes outside of the dimensions of the garden as supplied during startup
2. The output of the SLMM after it finished each action must be in the format: “{Time} – {Action taken place} – {current location of SLMM}”. This should only be written after the action has finished taking place.

Step 2 – senior & lead server-side positions
-------------------------------------
Please complete the above first. After you finished the above, you are to enhance it with the following:
1. The application should now be changed to accept input via Http. You are advised to use ASP.Net Web API, but you are free to use any web framework of your choice. The output should still be in the console.
2. Since now this is an ASP.Net Web API, the size of the lawn should be passed in through an action method specifically for this purpose.
3. All commands should be done asynchronously and all POST or PUT action methods should just return a correlation id.
4. The commands should be done on a FIFO manner.
5. There should be two applications, one that runs in SLMM and one that represents the client and will be used by administrator(s) to control the SLMM. See below for accepted commands and exposed action methods.

It is expected that the work done will still require a thread to sleep for the duration mentioned in Step 1.

### Commands accepted by SLMM client
1. TL -> Turn Left
2. TR -> Turn Right
3. MF -> Move Forward
4. ML -> Mow Lawn. This mows the lawn at the current location only and does not turn on mowing indefinitely. After 120 seconds (which is the time needed for this as specified above), just assume that the mower automatically stops

### Action methods exposed by SLMM
1. /lawn Method: POST. Payload: {"StartX": int, "StartY": int, "SizeX": int, "SizeY": int}
2. /lawn Method: GET. Payload: {"SizeX": int, "SizeY": int}
3. /location Method: PUT. Payload: {"Units": int} -> the units are the distance to move in the currently facing direction.
4. /location Method: GET. Reply: {"X": int, "Y": int} -> returns the current location of the SLMM
5. /rotation Method: PUT. Payload: {"Direction": string} -> directions accepted are North, East, South, West
6. /rotation Method: GET. Reply: {"Direction": string} -> returns the current directions of the SLMM and is one of North, East, South, West
7. /mower Method: PUT Payload {"On": boolean} if on is set to false, this does nothing and is ignored.
8. /mower Method: GET Payload {"On": boolean} returns true or false depending if the mower is currently mowing lawn.

### Deliverables
First provide the deliverables for Step 1 independently. Then, as a separate branch provide one console application that represents the application that is run in the SLMM and one console application that accepts command input from console and communicates it to the SLMM application via Http along with all supporting libraries. Again, you should provide access to an online repository that hosts all code for all applications, libraries and test projects. The readme should have all necessary information on how to build, run and test the solution.

As a senior engineer, you are expected to provide meaningful input to the design of our solutions. As such it is expected that you will also provide a short document which explains any decisions made. You are also encouraged to comment on anything you found interesting or important.

### Acceptance criteria
1. The SLMM never goes outside of the dimensions of the garden as supplied during startup
2. In the SLMM application, it is expected that action methods will log when they are called, start of operations and end of operations should be logged as well.
3. The output of the SLMM application for each action must be in the format: “{Time} – {Action to take\has taken place} – {current location of SLMM}”. 
  For example: "12:05:12 - Start Turn Left - (5,2)" and after the action finished "12:05:27 - End Turn Left - (5,2)"
 

Assessment criteria
===================
We do not want to disclose exactly how we evaluate, but decisions will be made based on the following:

1. Structure of program
2. Testing and testing strategy
3. Maintainability
4. Following standards & practices
5. For senior engineers, the documement with comments provided will be taken into heavy consideration

If the program does not build with the instructions provided, or it does not run successfully, the application will be rejected immediately.
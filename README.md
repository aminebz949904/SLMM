SLMM - The coding exercise for server side applicants
=====================================================

You are encouraged to take no more than 5 hours to implement this, but you are free to take less or more if you want to. Please do not overengineer this exercise, but you are welcome to demonstrate knowledge in a field that can influence this project.

1 - Exercise for junior and mid-level positions
----------------------------------
Assume we are interested in creating a smart lawn mowing machine called SLMM (smart lawn mowing machine). Your task is to create the software that will run in the SLMM itself and will be responsible for doing the following actions:

1. Turn the SLMM 90o left or right -> This should take 15 seconds to do
2. Move forward by one position -> This takes 30 seconds to do
3. Mow the lawn at the current position -> This takes 120 seconds to do

To emulate work being done, please use a thread. The thread should sleep for the specified duration above.

The application you will create should be able to accept the above commands and execute them. Since you do not have access to the actual hardware, for now the only thing required is to accept input from console and write the status at the end of the action in the console (write the completed action along with the position of the SLMM as per the acceptance tests below). During application startup, the SLMM is given a set of dimensions (passed in as command line parameters) that represent the width and length of the garden that the SLMM is in.

### Commands accepted
1. TL -> Turn Left
2. TR -> Turn Right
3. MF -> Move Forward
4. ML -> Mow Lawn. This mows the lawn at the current location only and does not turn on mowing indefinitely. After 120 seconds (which is the time needed for this as specified above), just assume that the mower automatically stops

### Deliverable
One console application that represents the application as described. You should provide access to an online repository, based on this one that contains all source code for this application, along with complete instructions on how to build your application locally. If any tests or libraries were written, please provide code for all and full instructions on how to run the build and tests.

You are encouraged to provide a short document describing any assumptions and decisions you made during the development of this exercise. You can also do this in code comments if you prefer.

### Acceptance criteria
1. The SLMM never goes outside of the dimensions of the garden as supplied during startup
2. The output of the SLMM after it finished each action must be in the format: “{Time} – {Action taken place} – {current location of SLMM}”. This should only be written after the action has finished taking place.

2 – Exercise for senior & lead server-side positions
-------------------------------------
Please read the exercise for juniors first for some background context, but please do not implement it. After you have read the above, consider the below changes to the above requirements:

1. The application needs to be split to a server and a client.
1. The server should be changed to accept input via Http. You are advised to use ASP.Net Web API, but you are free to use any web framework of your choice. The output should still be in the console.
1. In a server setup, we want the size of the lawn to be passed in through an action method specifically for this purpose.
1. All commands should be executed (and work emulated) asynchronously and all POST or PUT action methods should return a correlation id (which is not used in this exercise but it is a requirement for it to exist).
1. The commands should be executed on a FIFO manner.
1. There should be two applications, one that runs in SLMM (server) and one that represents the client. The client one will be used by administrator(s) to control the SLMM. See below for accepted commands and exposed action methods.

It is expected that the work done will still require a thread to sleep for the duration mentioned in Step 1 to emulate work being done.

### Commands accepted by SLMM client
1. TL -> Turn Left
2. TR -> Turn Right
3. MF -> Move Forward
4. ML -> Mow Lawn. This mows the lawn at the current location only and does not turn on mowing indefinitely. After 120 seconds (which is the time needed for this as specified above), just assume that the mower automatically stops

### Action methods exposed by SLMM
1. /lawn Method: POST. Payload: {"StartX": int, "StartY": int, "SizeX": int, "SizeY": int}
2. /lawn Method: GET. Payload: {"SizeX": int, "SizeY": int}
3. /location Method: PUT. Payload: {"MoveBy": int} -> MoveBy represents the distance to move in the currently facing direction.
4. /location Method: GET. Reply: {"X": int, "Y": int} -> returns the current location of the SLMM
5. /rotation Method: PUT. Payload: {"Direction": string} -> directions accepted are North, East, South, West
6. /rotation Method: GET. Reply: {"Direction": string} -> returns the current directions of the SLMM and is one of North, East, South, West
7. /mower Method: PUT Payload {"On": boolean} if on is set to false, this does nothing and is ignored.
8. /mower Method: GET Payload {"On": boolean} returns true or false depending if the mower is currently mowing lawn.

### Deliverables
Provide one console application that represents the server application which emulates the work of SLMM and one console application that accepts command input from console and communicates it to the SLMM server application via Http. You should provide access to an online repository that hosts all code for all applications, libraries and test projects. The readme should have all necessary information on how to build, run and test the solution. We should be able to follow 

As a senior engineer, you are expected to provide meaningful input to the design of our solutions. As such it is required that you will also provide a short document which explains any assumptions and\or decisions made. You are also highly encouraged to comment on anything you found interesting or important. **Please attach this in email and do not include it in the PR**

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
5. For senior engineers, the documement with comments provided will be taken into _heavy_ consideration

If the program does not build with the instructions provided, or it does not run successfully, the application will be rejected immediately.

If there is anything unclear or if you have any queries, please create an issue on this repository for the team to address.

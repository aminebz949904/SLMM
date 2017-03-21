SLMM - The coding exercise for server side applicants
=====================================================

You are encouraged to take no more than 5 hours to implement this, but you are free to take less or more if you want to. Please do not overengineer this exercise, but you are welcome to demonstrate knowledge in a field that can influence this project.

1 - Exercise for junior and mid-level positions
----------------------------------
Assume we are interested in creating a smart lawn mowing machine called SLMM (smart lawn mowing machine). Your task is to create the software that will run in the SLMM itself and will be responsible for doing the following actions:

1. Turn the SLMM 90o left or right -> This should take 10 seconds to do
1. Move forward by one position -> This takes 15 seconds to do
1. Mow the lawn at the current position -> This takes 120 seconds to do

To emulate work being done, please use a thread. The thread should sleep for the specified duration above.

The application you will create should be able to accept the above commands and execute them. Since you do not have access to the actual hardware, for now the only thing required is to accept input from console and write the status at the end of the action in the console (write the completed action along with the position of the SLMM as per the acceptance tests below). During application startup, the SLMM is given a set of dimensions (passed in as command line parameters) that represent the width and length of the garden that the SLMM is in.

### Commands accepted
1. TL -> Turn Left
1. TR -> Turn Right
1. MF -> Move Forward
1. ML -> Mow Lawn. This mows the lawn at the current location only and does not turn on mowing indefinitely. After 120 seconds (which is the time needed for this as specified above), just assume that the mower automatically stops

### Deliverable
One console application that represents the application as described. You should provide access to an online repository, based on this one that contains all source code for this application, along with complete instructions on how to build your application locally. If any tests or libraries were written, please provide code for all and full instructions on how to run the build and tests.

You are encouraged to provide a short document describing any assumptions and decisions you made during the development of this exercise. You can also do this in code comments if you prefer.

### Acceptance criteria
1. The SLMM never goes outside of the dimensions of the garden as supplied during startup
1. The output of the SLMM after it finished each action must be in the format: “{Time} – {Action taken place} – {current location of SLMM}”. This should only be written after the action has finished taking place.

2 – Exercise for senior server-side positions
-------------------------------------
Assume we are interested in creating a smart lawn mowing machine called SLMM (smart lawn mowing machine). Your task is to create the software that will run inside the SLMM itself as a server and a client that will be used by human operators to mow the lawn. This version of SLMM starts mowing immediately when deployed, and never stops. You also don't need to rotate it at all, and it only supports the following commands:

1. Move one position up
1. Move one positions down
1. Move one position to the left
1. Move one position to the right
1. Set start location and lawn size (width and height)

All move actions take one second to perform. Please emulate this using Thread.Sleep or Task.Wait in your code.

### Deliverables

1. One application that represents the server application exposed through a Restfull API (you are free to use any web framework of your choice) which emulates the work of SLMM. This should contain any and all logic encompassing the operation (and validations) of the SLMM. This would allow multiple clients to control the SLMM in parallel.
1. One console application that accepts command input from console and communicates it to the SLMM server application. 
1. Documentation about how to build, run and test the solution.
1. Any and all automated testing code that you wrote
1. As a senior engineer, you are expected to provide meaningful input to the design of our solutions. As such it is required that you will also provide a short document which explains any assumptions and\or decisions made. You are also highly encouraged to comment on anything you found interesting or important. **Please attach this in email and do not include it in the PR**

You should provide access to an online repository that hosts all code for all applications, libraries and test projects. The readme should have all necessary information on how to build, run and test the solution.

### Acceptance criteria
1. The SLMM logic resides in the server application
1. The SLMM never goes outside of the dimensions of the garden as supplied during startup
1. The SLMM behaves consistently
1. The SLMM should write some messages for debugging purposes for any and all input. This can be either console, a file (through logging for example or manually if this is easier for you) or Debug window in VS. Any one will do. 
1. The format of the debugging messages required on above point should be: “{Time} – {Action to take\has taken place} – {current location of SLMM}”. 
  For example: "12:05:12 - Start Move Left - (5,2)" and after the action finished "12:05:22 - End Move Left - (5,2)". You are free to deviate from this format, but explain your reasons.
 
Assessment criteria
===================
We do not want to disclose exactly how we evaluate, but decisions will be made based on the following:

1. Following the acceptance criteria
1. Structure of program
1. Testing and testing strategy
1. Maintainability
1. Following standards & practices
1. The documement with comments provided will be taken into _heavy_ consideration

**Please note**: If the program does not build with the instructions provided, or it does not run successfully, the application will be rejected immediately.

If there is anything unclear or if you have any queries, please create an issue on this repository for the team to address.

3 – The "full-blown" exercise (optional)
-------------------------------------

**Note**: This exercise allows you to be considered for our senior server-side position regardless of what is in your CV (we will ignore years of employment, degree, amount or relevance of previous stack\experience, or lack thereof). This is a larger exercise that the previous ones, but allows you to demonstrate knowledge in a broader area that the previous ones. Our rules of evaluating this exercise are equally strict as the senior exercise, but due to larger scope, this exercise is more difficult.

Please read the [exercise for juniors and mid-leve positions first](https://github.com/ParcelVision/SLMM#1---exercise-for-junior-and-mid-level-positions) for some background context, but please do not implement it. After you have read the above, consider the below changes to the above requirements:

1. The application needs to be split to a server and a client.
1. The server should be changed to accept input via Http. You are advised to use ASP.Net Web API, but you are free to use any web framework of your choice. The output should still be in the console.
1. In a server setup, we want the size of the lawn to be passed in through an action method specifically for this purpose.
1. All commands should be executed (and work emulated) asynchronously and all POST or PUT action methods should return a correlation id (which is not used in this exercise but it is a requirement for it to exist).
1. The commands should be executed on a FIFO manner.
1. There should be two applications, one that runs in SLMM (server) and one that represents the client. The client one will be used by administrator(s) to control the SLMM. See below for accepted commands and exposed action methods.
1. Emulate work being done using Thread.Sleep or Task.Wait and use times from below.

It is expected that the work done will still require a thread to sleep for the duration mentioned in Step 1 to emulate work being done.

### Commands accepted by SLMM client
1. TL -> Turn Left. This takes 10 seconds
1. TR -> Turn Right. This takes 10 seconds
1. MF -> Move Forward. This takes 15 seconds
1. ML -> Mow Lawn. This mows the lawn at the current location only and does not turn on mowing indefinitely. After 120 seconds just assume that the mower automatically stops. SLMM cannot move outside of its location while this is happening.

### Action methods exposed by SLMM
1. /lawn Method: POST. Payload: {"StartX": int, "StartY": int, "SizeX": int, "SizeY": int}
1. /lawn Method: GET. Payload: {"SizeX": int, "SizeY": int}
1. /location Method: PUT. Payload: {"MoveBy": int} -> MoveBy represents the distance to move in the currently facing direction.
1. /location Method: GET. Reply: {"X": int, "Y": int} -> returns the current location of the SLMM
1. /rotation Method: PUT. Payload: {"Direction": string} -> directions accepted are North, East, South, West
1. /rotation Method: GET. Reply: {"Direction": string} -> returns the current directions of the SLMM and is one of North, East, South, West
1. /mower Method: PUT Payload {"On": boolean} if on is set to false, this does nothing and is ignored.
1. /mower Method: GET Payload {"On": boolean} returns true or false depending if the mower is currently mowing lawn.

### Deliverables
Provide one console application that represents the server application exposed through a Restfull API (you are free to use any web framework of your choice) which emulates the work of SLMM and one console application that accepts command input from console and communicates it to the SLMM server application via Http. You should provide access to an online repository that hosts all code for all applications, libraries and test projects. The readme should have all necessary information on how to build, run and test the solution.

As a senior engineer, you are expected to provide meaningful input to the design of our solutions. As such it is required that you will also provide a short document which explains any assumptions and\or decisions made. You are also highly encouraged to comment on anything you found interesting or important. **Please attach this in email and do not include it in the PR**

### Acceptance criteria
1. The SLMM never goes outside of the dimensions of the garden as supplied during startup
1. The SLMM behaves consistently.
1. In the SLMM application, it is expected that action methods will log when they are called, start of operations and end of operations should be logged as well.
1. The output of the SLMM application for each action must be in the format: “{Time} – {Action to take\has taken place} – {current location of SLMM}”. 
  For example: "12:05:12 - Start Turn Left - (5,2)" and after the action finished "12:05:27 - End Turn Left - (5,2)"
 

Assessment criteria
===================
We do not want to disclose exactly how we evaluate, but decisions will be made based on the following:

1. Structure of program
1. Testing and testing strategy
1. Maintainability
1. Following standards & practices
1. The documement with comments provided will be taken into _heavy_ consideration

If the program does not build with the instructions provided, or it does not run successfully, the application will be rejected immediately.

If there is anything unclear or if you have any queries, please create an issue on this repository for the team to address.

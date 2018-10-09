SLMM - The coding exercise for server side applicants
=====================================================

You are encouraged to take no more than 5 hours to implement this, but you are free to take less or more if you want to. Please do not overengineer this exercise, but you are welcome to demonstrate knowledge in a field that can influence this project.

### Short description
Assume we are interested in creating a smart lawn mowing machine called SLMM (smart lawn mowing machine). Your task is to create the software that will run in the SLMM itself and will be responsible for doing the following actions:

1. Turn the SLMM 90o left or right -> This should take 2 seconds to do
1. Move forward by one position -> This takes 5 seconds to do

To emulate work being done, please use Sleep.

You are expected to write a short web application that will accept the above commands, and execute them. During application startup, the SLMM is given a set of dimensions (passed in through config) that represent the width and length of the garden that the SLMM is in.

Please try to not take more than 3-4 hours total on this exercise.

### Actions to support
1. Turn Left
1. Turn Right
1. Move Forward
1. Get current position

### Deliverable
A web application implemented in C# using any web framework of your choice. Automated tests must be included in the delivery.

Please include a short documentation explaining how to build, run and use the solution you authored. Please add a section about any decisions you made during the implementation.

### Acceptance criteria

The provided solutions needs to build with no errors. Feel free to use any 3rd party libraries you chose, but aside from web framework and DI libraries, please explain clearly your choices.

1. The SLMM never goes outside of the dimensions of the garden as supplied during startup.
1. The SLMM server application remains responsive (get current position returns a value) regardless if the SLMM is busy rotating or moving forward.
1. When queried the SLMM should return the current position until it finished moving.

### Assessment

Your solution will be assessed based on:
1. Use of the language
1. Readability and maintainability of code
1. Adhering to coding standards
1. Allocating responsibilities to classes
1. Testing approach and methodology
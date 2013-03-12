brainteaser-train
=================

Assumptions

1. graph may not necessarily have to be acyclic, except for problem sets 8 and 9 where we're doing a shortest path. This is also evident by the fact that problem set 10 has cyclic routes in the sample.
2. graph weights on the edges are single digit. This may be a bad assumption but if it is I can modify the parsing to include more than single digits.
3. I'm not sure how reliable the graph input can be, but for the purposes of this excercise I'll assume that the graph input is always "correct", meaning the pattern matches the sample provided. If that's not the case then I could modify the graph piece to handle bad inputs accordingly.

How to Run

There are two ways to run this thing:

1. You can build the main project and just run the program exe that's built. 
	The only extra work involved there is if you want to try out various graph inputs you need to add them to the graph inputs string array that's declared at the top of Program.cs. 
	I didn't go the route of consuming a text file because I did most of my work with test cases (unit testing), but if that's something that needs to be done there's no problem with me adding that functionality.
	
2. You can open up the test project and run the unit tests I constructed.
	The unit tests cover the full gambit of output cases that were described in the problem, but they also include different graph inputs. 
	The downside to running the test project is that it won't output the results as described in the problem set.

Product: Basic Calculator
-------------------------

Technology used - .Net 5 <br/>
Client Type - Console App <br/>
Input file - Part of Client project <br/>
File path - Configured in appsettings.json (located in the bin folder after compilation)
--------------------------------------------------------------------------------------------------

Components
----------
Calculator.Lib - Implementation of core calculator functionality; gives flexibility for testing and can be used with any client type; can be converted in service if required
Calculator.Cient - Client for client lib
Calculator.Lib.Test - Unit test project for Calculator.Lib

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	 

Program Flow -
Client (Console app) 
	- Reads the content from given file
	- Iterates the content line by line, and adds the data on the queue until receive apply command
	- Once it receives the Apply command, it invokes the actual calculator methods to get the final result
	- Final result is displayed on the screen along with all the operations given in the file
	- You do changes in the file in bin folder and re-execute program simply by pressing enter

Logic used -
I have used command pattern, some may think it was unnecessary but my thoughts were
	- to avoid tight coupling between client and receiver
	- every operation is exposed as command
	- if there will be more operations supported by receiver then only commands needs to be added client doesn't have to do much

I have entrusted the responsibility of reading and adding commands in queue on client program, because
	- calculator client only deals with doing math on two operands
	- client program has flexibility of implemnting that concern the way it feels appropriate

Testing -
Added few test cases for calculator client only...


 ------
|THANKS| 
 ------
	
	



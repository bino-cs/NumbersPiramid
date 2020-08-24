# NumbersPyramid
the maximum sum of the numbers per the given rules below:


1. You will start from the top and move downwards to an adjacent number as in below.
2. You are only allowed to walk downwards and diagonally.
3. You should walk over the numbers as evens and odds subsequently. Suppose that you are on an even
number the next number you walk must be odd, or if you are stepping over an odd number the next
number must be even. In other words, the final path would be like



1. form a binary tree considering the input

Eg 
1
8 9
1 5 9
4 5 2 3 

Create a  binary tree which would be only having the node that satisfied the  mentioned condition.
after running  the first step to create the tree the node  should looks like below.


				1
			8		-
		1		5 
	4	     - -   2  -

	Here find the possible  node to create the branches are below
	1. 1,8,1,4
	2. 1,8,5
	3. 1,8,5,2
	
	Find the maximum value
		- Here the maximum value- is 16

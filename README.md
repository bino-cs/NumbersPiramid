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

should create a binary tree like below

				1
			8		n
		1		5 
	4	     n n   2  n
	
	n is nothing but a null node


# QuickDataStructure

Build 2 different data structures, both should have pop and push functionalities, but each data structure should perform the functionalities with different complexities.

## Important Notes

- Google and web resources are allowed (no AI please).
- The code should be written in C#.
- It is not allowed to use any of the data structures that are built-in in C#.

## Requirements

1. A class “QuickPopDataStructure” with 2 operations:
- Push – should be performed in O(n)
- Pop - should be performed in O(1)
2. A class “QuickPushDataStructure” with 2 operations:
- Push - should be performed in O(1)
- Pop – should be performed in O(n)
3. For both structures, a Pop operation should always return the maximum value in the data structure. For example, if the following elements were inserted: 3,6,7,2,4 then consecutive pop operations should return 7,6,4,3,2.
4. Both classes should be able to contain any type of objects. For example, it can contain integers, or it can contain complex objects – i.e. Person object. NOTE that a specific instance of one of the 2 classes should be able to contain objects of a single type only. For example, an instance of “QuickPopDataStructure” can not contain integers and objects of type “Person”. Only integers or objects of type Person.
5. Both classes should work in a multi-threaded environment as different threads may try to perform Pop and Push operations simultaneously.
6. You are required to write a test application that tests all of the requirements listed above.

## Expected Deliverables

- High-level software design diagram of the data structures.
- The code implementation project, including test files. The project could be sent as a zip file via email or as a link to a Github project (make sure it’s public).

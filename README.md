## Interrupt

This is a simple project to test interrups in C#, this project does the following

* Create 2 additional Threads in main
* Display “Message from thread {ThreadName}” every second
* OnKeyPress: Interrupt and Kill Thread 1 and Display "Thread 1 interrupted, terminating..."
* Upon a second KeyPress: Perform a similar action for thread 2
* Upon 3rd KeyPress: Display "All processes terminated"
* At this stage if you press a key it is displayed, if that key is escape, end process 

## To Run
```
# from root dir
dotnet run --project src/

# from src/ dir
dotnet run
```

## To Test
```
# root dir
dotner run test/

# from test/ dir
dotnet test
```
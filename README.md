# Longest increasing subsequence

## Notes

- This was developed in VSCode on MAC
- The solution creates a class with two methods. FindSequenceInArray finds the longest sequence in an array of numbers. FindSequenceInString finds the longest sequence in a string. The latter calls the former, but prepares the data before hand.
- See below for detailed analysis of how the sequence finder class works, including assumptions and constraints.

## Running the program from CLI

cd to the `app` folder;
run `dotnet run "1 2 3"`

## Testing

run `dotnet test` in the root directory

## Detailed Analysis

Develop a function that takes one string input of any number of integers separated by single whitespace. The function then outputs the longest increasing subsequence (increased by any number) present in that sequence. If more than 1 sequence exists with the longest length, output the earliest one. You may develop supporting functions as many as you find reasonable.

## Assumptions

- Positive integers
- String may be empty
- Identify a subsequence of consecutive numbers

## Constraints

- If more than one sequence exists output the earliest one
- Input is a space delimited string

## Analysis

```pseudocode
//SequenceFinder
nums: [N₁]                             //array of numbers
l: N                                   //length of subsequence
seq: [N₁]                              //empty array

//state
l == 0
seq == []

//FindSequence Method
▵SequenceFinder                       //Sequence finder state change
nums?: [N₁]                           //The nums array
i?: N                                 //The index to start searching

//pre conditions
i = 0

//post conditions
seq`: [N]
#seq ≤ #nums                          //seq length is less or equal to nums length
l`: N ◯ l == #seq ∧ l ≤ #nums         //the length of seq
seq ⊆ nums                            //seq is a subset of nums
∀i : 0 ≤ i < l  ◯ seq[i] < seq[i+1]   //numbers in output are always increasing

// max increasing subsequence
∃i|i..i-l ◯ nums[i-1] < nums[i] ∧     //increasing subset, described from ending number in the sequence
∄j,k|k > j ◯ nums[k] > nums[k-1]
∧ #nums[j..k] > l                     //there is no longer subset in nums
seq`[0...l] === nums[i-l..i]          //seq contains the increasing subset
```

Examples:

```pseudocode
nums: [1, 1, 3, 4, 5, 1]
seq: [1,3,4,5]
l: 4

nums: []
seq: []
l: 0

nums: [1]
seq: [1]
l: 1

nums: [1,2,3,1,1,2,3,4,5]
seq: [1,2,3,4,5]
l: 5

nums: [1,2,3,4,5,1,1,2,3,4,6]
seq: [1,2,3,4,5]
l: 5
```

## Steps:

```pseudocode
1. Get input and split array of strings => nums[]
2. Initialize seq to []
3. Initialize l to 0
3. Start at the end of the array
4. For each index i..0 : i = i - Max(1, #tseq)
   - var tseq = []
   - tseq = subSequence(nums, i) {
       - if i-1 < 0 return nums[i]
       - if nums[i-1] < nums[i] return subSequence(nums, i-1) ⁀ nums[i]
       - else return nums[i]
   }
   - if #tseq >= l --> l` = #tseq ^ seq` = tseq
5. Output seq`
```

## Walkthrough 1

```pseudocode
nums=[1, 1, 3, 4, 5, 1]
l=0
seq=0
i=nums.length - 1 // = 5

//iteration 1
i = 5
tseq = [1]
seq = [1]

//iteration 2
i = 4
tseq = [1,3,4,5]
seq = [1,3,4,5]
i` = 0
l = 4

//iteration 3
i = 0
tseq = [1]
seq = [1,3,4,5]
l = 4

// output
[1,3,4,5]
```

## Walkthrough 2

```pseudocode
nums: [1,2,3,4,5,1,1,2,3,4,6]
l = 0
seq = []
i = nums.length - 1 // => 10

//iteration 1
i = 10
tseq=[1,2,3,4,6]
seq=[1,2,3,4,6]
i`=5
l=5

//iteration 2
i = 5
tseq = [1]
seq=[1,2,3,4,6]
i` = 4
l = 5

//iteration 3
i = 4
tseq = [1,2,3,4,5]
seq = [1,2,3,4,5]
i` = -1

//output
[1,2,3,4,5]
```

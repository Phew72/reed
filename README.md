# Candidate Tech Test Instructions

Candidate names are been given in the format of "surname, firstname". Candidate name lists are available on `Sources\UserRepository.cs` file within this project

## Project Setup

- .Net core Class library project been setup along with its test project.
- Following nuget packages been already added to the test project:
	- `xUnit`, 
	- `xUnit.runner.visualstudio`
	- `fluentAssertions`
- Please feel free to add / remove nuget package libraries if you prefer so.

# Challenges

Please solve below problems with proper test case coverage for each scenarios.

## Task 1

1. Combine all applicants
    - Combine `DeveloperJobApplicant` & `TesterJobApplicant` into one list
    - Names must be unique:  no duplicate names in the combined list of applicants.

2. Clean the list of applicants.  
   - Remove invalid entries. 
   - Format should be *surname, forename*
   - **Valid** format examples: 
        - "Antonio, Mchaney"
        - "Mollie, Rabinowitz"
   - **Invalid** format examples: 
        - "Rebecca"
        - "Long ,,Pigford"
        - "Marceline ,Polley"
        - "Gudrun&nbsp;&nbsp;  ,Caughman"


## Task 2

1. How many times do first-name initials appear in the list of all applicants?

2. Output the result
    - Using project of your choice. Eg: API/MVC/Console

3. Example output:
```
Matthews, Mark
Smith, Sally
Ali, Sonia

M - 1
S - 2
```
# TestRail-Diploma-Project

QA Сhecklist for TestRail website testing: 


**UI Tests
**Positive scenarios:     

1. TestCases Page    |  Check the boundary values for the Case Title characters
2. TestCases Page    |  Check the Bug/Story Pop-up after the cursor navigation on it
3. Milestones Page   |  Check that the new Mileston is created
4. TestCases Page    |  Check that the created test case can be deleted
5. TestCases Page    |  Check that the dialogue window "Add Subsection" is opened
6. AddTestCase Page  |  Check that it is possible to load the attachment to the test case

**Negative scenarios: 

1. Login Page        |  Check that the user can not log in with invalid credentials
2. Dashboard Page    |  Check that the error message is appeared after entering >250 symbols into the search field
3. TestCases Page    |  Check that the "Defect Push" window is displayed (But the 'Add Subject" window should be displayed

   
**API Tests:

GET api/v2/get_user/{user_id} Get valid UserName 
GET api/v2/get_suite/{suite_id} Get the Test Suite with invalid Id 
POST api/v2/add_suite/{project_id} Adding the new Test Suite to the specific Project
POST api/v2/add_milestone/{project_id} Adding the new Milestone
GET api/v2/get_milestone/{milestone_id} Get the Milestone with invalid Id 


Feature: Job Search on LabCorp Careers Page

Scenario: Search and validate a specific job listing
	Given I navigate to the LabCorp homepage
	When I click on the "Careers" link
	And I search and select the job titled "Senior Automation and Robotics Software Engineer"
	Then I should see the job details as:
		| Deatils  | Expected Value                                    |
		| Title    | Senior Automation and Robotics Software Engineer  |
		| Location | Bloomfield, Connecticut, United States of America |
		| ID       | 2512136                                           |
	
	And the job description should contain:
		| Deatils | job-descrption                                        |
		| Skill1  | Experience leading a technical team is a strong plus. |
		| Skill2  | Experience with OpenJDK 11 or later a plus.           |
		| Skill3  | Experience with production metrics/big data a plus.   |

	When I click on "Apply Now"
	And I switch to the newly opened application window
	Then the application page should display the job title as "Senior QA Automation Engineer"
	And I switch back to the original window
	When I click on "Return to Job Search"
	Then I should be redirected to the job search page
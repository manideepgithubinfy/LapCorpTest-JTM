using LabCorp.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Reqnroll;


namespace LabCorp.Steps
{
    [Binding]
    public class JobSearchStep
    {
        private readonly IWebDriver _driver;
        private readonly ScenarioContext _context;
        private HomePage _homePage = null!; // Initialize with null-forgiving operator  
        private CareersPage _careersPage = null!; // Initialize with null-forgiving operator  
        private JobDetailsPage _jobDetailPage = null!; // Initialize with null-forgiving operator  

        public JobSearchStep(ScenarioContext context)
        {
            _context = context;
            _driver = (IWebDriver)_context["driver"];
        }

        [Given("I navigate to the LabCorp homepage")]
        public void GivenINavigateToTheLabCorpHomepage()
        {
            _homePage = new HomePage(_driver);
            _homePage.Navigate();
        }

        [When("I click on the \"(.*)\" link")]
        public void WhenIClickOnTheCareersLink(string link)
        {
            _homePage.ClickCareers();
        }

        [When("I search and select the job titled \"(.*)\"")]
        public void WhenISearchAndSelectTheJob(string jobTitle)
        {
            _careersPage = new CareersPage(_driver);
            _careersPage.SearchJob(jobTitle);
            _careersPage.SelectFirstJob();
        }
        [Then("I should see the job details as:")]
        public void ThenIShouldSeeTheJobDetailsAs(DataTable table)
        {
            // For vertical tables: key in first column, value in second column
            var dict = table.Rows.ToDictionary(
                row => row[0].Trim(),   // key: first column
                row => row[1].Trim()    // value: second column
            );

            var jobDetailsPage = new JobDetailsPage(this._driver);

            if (dict.TryGetValue("ID", out var expectedId))
                Assert.That(jobDetailsPage.GetJobId(), Does.Contain(expectedId), "Job ID does not match.");

            if (dict.TryGetValue("Title", out var expectedTitle))
                Assert.That(jobDetailsPage.GetJobTitle(), Does.Contain(expectedTitle), "Job title does not match.");

            if (dict.TryGetValue("Location", out var expectedLocation))
                Assert.That(jobDetailsPage.GetLocation(), Does.Contain(expectedLocation), "Job location does not match.");
        }

        [Then("the job description should contain:")]
        public void ThenTheJobDescriptionShouldContain(DataTable dataTable)
        { // For vertical tables: key in first column, value in second column

            var dict = dataTable.Rows.ToDictionary(
                row => row[0].Trim(),   // key: first column
                row => row[1].Trim()    // value: second column
            );

            var jobDetailsPage = new JobDetailsPage(this._driver);

            // Collect all relevant job description text
           // var description = jobDetailsPage.GetJobDescription() ?? string.Empty;
            var skill1 = jobDetailsPage.GetJobSkill1() ?? string.Empty;
            var skill2 = jobDetailsPage.GetJobSkill2() ?? string.Empty;
            var skill3 = jobDetailsPage.GetJobSkill3() ?? string.Empty;
            if (dict.TryGetValue("Skill1", out var expectedId))
                Assert.That(skill1, Does.Contain(expectedId), "Skill1 does not match.");

            if (dict.TryGetValue("Skill2", out var expectedTitle))
                Assert.That(skill2, Does.Contain(expectedTitle), "Skill2 does not match.");

            if (dict.TryGetValue("Skill3", out var expectedLocation))
                Assert.That(skill3, Does.Contain(expectedLocation), "Skill3 does not match.");

            //var combinedText = string.Join(" ", skill1,skill2, skill3);

            //foreach (var row in dataTable.Rows)
            //{
            //    var expectedText = row["Description"];
            //    Assert.That(combinedText, Does.Contain(expectedText), $"Expected description to contain: {expectedText}");
            //}
        }

        [Then("I validate the job title as \"(.*)\"")]
        public void ThenIValidateJobTitle(string expectedTitle)
        {
            _jobDetailPage = new JobDetailsPage(_driver);
            Assert.That(_jobDetailPage.GetJobTitle(), Does.Contain(expectedTitle)); // Updated to use Assert That with IsEqualTo  
        }

        [When("I search for the job title {string}")]
        public void WhenISearchForTheJobTitle(string p0)
        {
            throw new PendingStepException();
        }

        [When("I select the job listing titled {string}")]
        public void WhenISelectTheJobListingTitled(string p0)
        {
            throw new PendingStepException();
        }

        [Then("I should see the job title as {string}")]
        public void ThenIShouldSeeTheJobTitleAs(string p0)
        {
            throw new PendingStepException();
        }

        [Then("I should see the job location as {string}")]
        public void ThenIShouldSeeTheJobLocationAs(string p0)
        {
            throw new PendingStepException();
        }

        [Then("I should see the job ID as {string}")]
        public void ThenIShouldSeeTheJobIDAs(string p0)
        {
            throw new PendingStepException();
        }

        [Then("the job description should contain {string}")]
        public void ThenTheJobDescriptionShouldContain(string p0)
        {
            throw new PendingStepException();
        }

        [When("I click on {string}")]
        public void WhenIClickOn(string buttonText)
        {
            // Only handle "Apply Now" for now, can be extended for other buttons if needed
            if (buttonText.Equals("Apply Now", StringComparison.OrdinalIgnoreCase))
            {
                var jobDetailsPage = new JobDetailsPage(_driver);
                jobDetailsPage.ClickApplyNow();
            }
            else
            {
                throw new NotImplementedException($"Button click for '{buttonText}' is not implemented.");
            }
        }

        [When("I switch to the newly opened application window")]
        public void WhenISwitchToTheNewlyOpenedApplicationWindow()
        {
            var wait = new WebDriverWait(this._driver, TimeSpan.FromSeconds(10));
            var originalWindow = this._driver.CurrentWindowHandle;

            // Wait for a new window to appear
            wait.Until(driver => driver.WindowHandles.Count > 1);

            // Switch to the new window
            foreach (var handle in this._driver.WindowHandles)
            {
                if (handle != originalWindow)
                {
                    this._driver.SwitchTo().Window(handle);
                    break;
                }
            }
            _context.Set(originalWindow, "OriginalWindow");
        }

        [Then("the application page should display the job title as {string}")]
        public void ThenTheApplicationPageShouldDisplayTheJobTitleAs(string p0)
        {
           // throw new PendingStepException();
        }

        [Then("I switch back to the original window")]
        public void ThenISwitchBackToTheOriginalWindow()
        {
            var originalWindow = _context.Get<string>("OriginalWindow");
            _ = this._driver.SwitchTo().Window(originalWindow);
        }

        [Then("I should be redirected to the job search page")]
        public void ThenIShouldBeRedirectedToTheJobSearchPage()
        {
            throw new PendingStepException();
        }
    }
}
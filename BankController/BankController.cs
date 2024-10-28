using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace BankingApp
{
    [ApiController]
    [Route("/")] // Base route for the controller
    public class BankController : Controller
    {
        // Hardcoded bank account details stored as an anonymous object
        private readonly dynamic accountDetails = new
        {
            accountNumber = 1001,
            accountHolderName = "Example Name",
            currentBalance = 5000
        };

        // Example #1: Welcome message at the default route
        [HttpGet]
        public IActionResult Index()
        {
            return Content("Welcome to the Best Bank", "text/plain");
        }

        // Example #2: Get all account details as JSON format
        [HttpGet("account-details")]
        public IActionResult GetAccountDetails()
        {
            return new JsonResult(accountDetails);
        }

        // Example #3: Return a dummy PDF as the bank statement
        [HttpGet("account-statement")]
        public IActionResult GetAccountStatement()
        {
            var filePath = "wwwroot/DummyStatement.pdf";

            // Create a dummy PDF if it doesn't exist
            if (!System.IO.File.Exists(filePath))
            {
                System.IO.File.WriteAllText(filePath, "This is a dummy bank statement.");
            }

            byte[] pdfBytes = System.IO.File.ReadAllBytes(filePath);
            return File(pdfBytes, "application/pdf", "DummyStatement.pdf");
        }

        // Example #4, #5, #6: Get current balance based on the account number
        [HttpGet("get-current-balance/{accountNumber:int?}")]
        public IActionResult GetCurrentBalance(int? accountNumber)
        {
            if (!accountNumber.HasValue)
            {
                return NotFound("Account Number should be supplied");
            }

            if (accountNumber != 1001)
            {
                return BadRequest("Account Number should be 1001");
            }

            return Content($"{accountDetails.currentBalance}");
        }
    }
}

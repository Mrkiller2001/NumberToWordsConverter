// Controllers/ConversionController.cs
using Microsoft.AspNetCore.Mvc;
using NumberToWordsConverter.Services;
using System.Text.RegularExpressions;

namespace NumberToWordsConverter.Controllers
{
    public class ConversionController : Controller
    {
        private readonly NumberToWordsService _numberToWordsService;

        public ConversionController()
        {
            _numberToWordsService = new NumberToWordsService();
        }

        [HttpPost]
        public IActionResult ConvertNumber([FromBody] InputModel input)
        {
            try
            {
                // Regular expression for matching valid numbers with up to two decimal places
                var regex = new Regex(@"^\d+(\.\d{1,2})?$");

                if (input == null || string.IsNullOrWhiteSpace(input.InputNumber))
                {
                    return Json(new { success = false, result = "Input cannot be empty." });
                }

                if (!regex.IsMatch(input.InputNumber))
                {
                    return Json(new { success = false, result = "Invalid format. Please enter a valid number (e.g., 123.45)." });
                }

                // Parse the validated string input to decimal
                if (!decimal.TryParse(input.InputNumber, out decimal number) || number < 0)
                {
                    return Json(new { success = false, result = "Invalid input. Only positive numbers are allowed." });
                }

                var result = _numberToWordsService.ConvertNumberToWords(number);
                return Json(new { success = true, result });
            }
            catch (Exception ex)
            {
                // Log the error as needed (e.g., using logging frameworks)
                return Json(new { success = false, result = "An unexpected error occurred. Please try again." });
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }

    public class InputModel
    {
        public string InputNumber { get; set; }
    }
}

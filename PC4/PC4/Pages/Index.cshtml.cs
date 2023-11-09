using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.ML;
using Microsoft.ML.Data;
using PC4;

namespace PC4.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MLModel _mLModel;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _mLModel = new MLModel();
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost(string palabra)
        {
            if (!string.IsNullOrEmpty(palabra))
            {
                var input = new MLModel.ModelInput
                {
                    Col0 = palabra
                };
                var prediction = MLModel.Predict(input);

                string resultado = prediction.PredictedLabel == 1 ? "Positive" : "Negative";

                ViewData["Resultado"] = $"The word '{palabra}' is: {resultado}";

                return Page();
            }

            return Page();
        }
    }
}
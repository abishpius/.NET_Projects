using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.ML;
using Sentiment_AnalysisML.Model;

namespace Sentiment_Analysis.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PredictionEnginePool<ModelInput, ModelOutput> _predictionEnginePool;

        public IndexModel(PredictionEnginePool<ModelInput, ModelOutput> predictionEnginePool)
        {
            _predictionEnginePool = predictionEnginePool;
        }
       
        public IActionResult OnGetAnalyzeSentiment([FromQuery] string text)
        {
            if (String.IsNullOrEmpty(text)) return Content("Neutral");
            var input = new ModelInput { SentimentText = text };
            var prediction = _predictionEnginePool.Predict(input);
            var sentiment = Convert.ToBoolean(prediction.Prediction) ? "Toxic" : "Not Toxic";
            return Content(sentiment);

        }
        public void OnGet()
        {

        }
    }
}

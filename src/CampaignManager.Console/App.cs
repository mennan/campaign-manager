using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CampaignManager.Console.Helpers;
using CampaignManager.Service;
using static System.Console;

namespace CampaignManager.Console
{
    public class App
    {
        private readonly IProductService _productService;
        private readonly ICampaignService _campaignService;
        private readonly IOrderService _orderService;
        private readonly ITimeService _timeService;
        private readonly Index StartIndex = 1;
        private PriceCalculatorModel priceCalculatorModel;

        public App(IProductService productService, ICampaignService campaignService, IOrderService orderService,
            ITimeService timeService)
        {
            _productService = productService;
            _campaignService = campaignService;
            _orderService = orderService;
            _timeService = timeService;

            priceCalculatorModel = new PriceCalculatorModel
            {
                ProductService = _productService,
                CampaignService = _campaignService,
                OrderService = _orderService
            };
            
            var productPriceCalculator =
                new ProductPriceCalculator(priceCalculatorModel);

            _productService.OnProductCreated += s => priceCalculatorModel.ProductCode = s;
            _campaignService.OnCampaignCreated += s => priceCalculatorModel.CampaignCode = s;
            _timeService.OnTimeIncreased += productPriceCalculator.Calculate;
        }

        public void Run()
        {
            var files = ReadScenarioFilesInDirectory();
            var commandHelper = new CommandHelper(_productService, _campaignService, _orderService, _timeService);

            ExecuteCommands(files, StartIndex, commandHelper);
        }

        private void ExecuteCommands(List<string> files, Index startIndex, CommandHelper commandHelper)
        {
            foreach (var file in files)
            {
                _timeService.ResetTime();

                var fileLines = FileHelper.ReadFileAsLine(file);

                foreach (var line in fileLines)
                {
                    var lineData = line.Split(' ');
                    var command = lineData[0];
                    Index endIndex = lineData.Length;
                    var parameters = lineData[startIndex..endIndex];
                    var commandResult = commandHelper.GetCommandResult(command, parameters);

                    WriteLine(commandResult);
                }

                System.Console.WriteLine();
            }
        }

        private List<string> ReadScenarioFilesInDirectory() =>
            Directory.GetFiles("Scenarios", "*.txt").OrderBy(x => x).ToList();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CampaignManager.Service
{
    public class CommandHelper
    {
        private readonly IProductService _productService;
        private readonly ICampaignService _campaignService;
        private readonly IOrderService _orderService;
        private readonly ITimeService _timeService;
        private readonly Dictionary<string, object> _types;

        public CommandHelper(IProductService productService, ICampaignService campaignService,
            IOrderService orderService, ITimeService timeService)
        {
            _productService = productService;
            _campaignService = campaignService;
            _orderService = orderService;
            _timeService = timeService;

            _types = new Dictionary<string, object>
            {
                {typeof(IProductService).FullName, _productService},
                {typeof(ICampaignService).FullName, _campaignService},
                {typeof(IOrderService).FullName, _orderService},
                {typeof(ITimeService).FullName, _timeService},
            };
        }

        public string GetCommandResult(string commandName, params object[] args)
        {
            ICommand instance = null;
            var result = string.Empty;
            var types = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(ICommand).IsAssignableFrom(t) && t != typeof(ICommand))
                .ToList();

            foreach (var type in types)
            {
                var commandAttribute = type.GetCustomAttribute<CommandAttribute>();

                if (commandAttribute == null || commandAttribute.Name != commandName) continue;

                var parameters = GetConstructorParameters(type).ToArray();

                if (parameters.Length == 0)
                    instance = (ICommand) Activator.CreateInstance(type);
                else
                    instance = (ICommand) Activator.CreateInstance(type, parameters);

                break;
            }

            if (instance != null)
            {
                result = instance.Execute(args);
            }

            return result;
        }

        private List<object> GetConstructorParameters(Type t)
        {
            var constructorParameters = new List<object>();
            var constructors = t.GetConstructors();

            if (constructors.Length > 0)
            {
                var constructor = constructors[0];
                var parameters = constructor.GetParameters();

                foreach (var parameter in parameters)
                {
                    var instance = GetParameterValues(parameter.ParameterType);

                    if (instance != null) constructorParameters.Add(instance);
                }
            }

            return constructorParameters;
        }

        private object GetParameterValues(Type t)
        {
            var typeName = t.FullName;
            return _types.TryGetValue(typeName, out var instance) ? instance : null;
        }
    }
}
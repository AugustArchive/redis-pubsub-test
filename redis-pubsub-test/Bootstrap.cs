using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace redis_pubsub_test
{
    class Bootstrap
    {
        private readonly Process process = Process.GetCurrentProcess();
        private IServiceProvider _provider;
        private IConfigurationRoot root;

        public Bootstrap()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddYamlFile("config.yml");

            root = builder.Build();
        }

        public async Task StartAsync()
        {
            ConfigureProcessEvents();
            var services = new ServiceCollection();
            ConfigureAllServices(services);

            var provider = services.BuildServiceProvider();
            _provider = provider;

            await Task.Delay(-1);
        }

        private void Process_OnExited(object sender, EventArgs args)
        {
            // TODO: this
        }

        private void ConfigureProcessEvents()
        {
            process.Exited += Process_OnExited;
        }

        private void ConfigureAllServices(IServiceCollection services)
        {
            // TODO: this
        }
    }
}

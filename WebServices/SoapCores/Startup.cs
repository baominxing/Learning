using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SoapCore;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace SoapCores
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.TryAddSingleton<ISampleService, SampleService>();
			services.AddSoapCore();
		}

		public void Configure(IApplicationBuilder app)
		{
            // Create Soap 1.1 Bindingchuf
            var binding = new BasicHttpBinding();

            // Create Soap 1.2 Binding
            //var textBindingElement = new TextMessageEncodingBindingElement(MessageVersion.Soap12WSAddressingAugust2004, Encoding.UTF8);
            //var httpBindingElement = new HttpTransportBindingElement();
            //var binding = new CustomBinding(textBindingElement, httpBindingElement);

            //app.UseSoapEndpoint<ISampleService>("/Service.asmx", binding, SoapSerializer.XmlSerializer);
			app.UseSoapEndpoint<ISampleService>("/Service.asmx", binding, SoapSerializer.DataContractSerializer);
		}
	}
}
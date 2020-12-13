using HelloWorldService;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace HelloWorldClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // 서비스의 종점 정보를 나타내는 코드
            var uri = new Uri("http://localhost/wcf/helloworldservice");
            var endpoint = new ServiceEndpoint(
                    ContractDescription.GetContract(typeof(IHelloWorld)),
                    new BasicHttpBinding(),
                    new EndpointAddress(uri)
                );

            // WCF의 채널 팩토리 생성
            // WCF의 내부 구조는 다양한 XML 웹 서비스 통신에 사용할 수 잇는 다양한 채널들이
            // 메시지를 순차적으로 처리해 나가도록 구성되어 있다.
            var factory = new ChannelFactory<IHelloWorld>(endpoint);
            IHelloWorld proxy = factory.CreateChannel();


            //SOAP 프로토콜로 정보를 받게 된다.
            string result = proxy.SayHello();
            (proxy as IDisposable).Dispose();

            Console.WriteLine(result);
        }
    }
}

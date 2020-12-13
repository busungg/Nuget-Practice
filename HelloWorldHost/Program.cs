using HelloWorldService;
using System;
using System.ServiceModel;

namespace HelloWorldHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // ServiceHost의 인스턴스를 생성
            // 호스팅 하고자 하는 서비스 타입과 서비스의 베이스 주소를 생성자의
            // 매개변수로 전달
            ServiceHost host = new ServiceHost(
                typeof(HelloWorldWCFService), 
                new Uri("http://localhost/wcf")
            );

            // 서비스의 종점을 서비스 호스트에 추가
            // 서비스의 종점은 주소, 바인딩, 계약으로 구성되므로
            // 계약: IHelloWorld, 바인딩: Http 프로토콜을 사용하는 바인딩, 주소: helloworldservice
            // 를 설정했다.
            host.AddServiceEndpoint(
                typeof(IHelloWorld), 
                new BasicHttpBinding(), 
                "helloworldservice"
            );

            host.Open();
            Console.WriteLine("Press Any key to stop the service");
            Console.ReadKey(true);
            host.Close();
        }
    }
}

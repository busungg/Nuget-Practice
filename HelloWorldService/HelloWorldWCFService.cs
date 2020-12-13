using System.ServiceModel;

namespace HelloWorldService
{
    // 서비스가 외부 세계에 노출할 서비스의 계약인 IHelloWorld 인터페이스 정의

    // WCF에서 서비스 계약을 위한 인터페이스 선언은 반드시 System.ServiceModel 
    // 네임스페이스의 ServiceContract 특성을(attribute) 인터페이스에 명시해야 한다.
    [ServiceContract]
    public interface IHelloWorld
    {
        // 인터페이스 내에 서비스에서 사용될 메서드 역시 명시적으로
        // OperationContract 특성을 명시해야만 한다.
        // 해당 특성이 없는 메서드는 WCF의 계약의 일부로 간주하지 않는다.
        [OperationContract]
        string SayHello();
    }

    // 서비스 타입 구현
    // 해당 클래스와 같이 WCF의 계약 인터페이스를 구현하는 클래스를 서비스 타입이라 부르며
    // 서비스 타입은 계약 인터페이스를 구현하기만 하면 된다.
    public class HelloWorldWCFService : IHelloWorld
    {
        public string SayHello()
        {
            return "Hello WCF World!";
        }
    }
}

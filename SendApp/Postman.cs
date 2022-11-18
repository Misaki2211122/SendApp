using Application.Abstractions;

namespace SendApp;

public class Postman
{
    /// <summary>
    /// Список, куда следует поместить все сообщения, которые не удалось доставить
    /// </summary>
    internal readonly List<IMessage> _failedMessages;

    internal readonly ISender _sender;

    internal readonly IUserRepository _userRepository;
    
    public Postman(ISender sender, IUserRepository userRepository)
    {
        _failedMessages = new List<IMessage>();
        _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository)); 
    }
    
    /// <summary>
    /// Отправляет сообщения из списка messages пользователям
    /// Сообщение отправляется методом, указанным в записи пользователя
    /// по адресу, указанным в записи пользователя
    /// В случае, если сообщение не удалось доставить, помещает его в  FailedMessages
    /// </summary>
    /// <param name="messages"> коллекция сообщений </param>
    public void Send(List<IMessage> messages)
    {
        ParallelLoopResult result = Parallel.ForEach(messages, message =>
        {
            var user = _userRepository.Get(message.UserId);
            var res = _sender.Send(message.MessageText, user.Address);
            if (!res)
                _failedMessages.Add(message);
            Thread.Sleep(20000);
        });
        // Необходимо написать код метода, 
        // при необходимости создать другие методы, свойства, интерфейсы или классы
        // Отправка должна выполняться параллельно во множество потоков 
        // Предусмотреть общее ограничение количества потоков и 
        // ограничение количества потоков для каждого из методов доставки
    }
}

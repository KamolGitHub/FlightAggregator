Данный проект был реализован на базе **Clean Architecture** с целью отделения бизнес-логики от инфраструктуры, что улучшает тестируемость и обеспечивает гибкость при разработке и поддержке приложения. 
Основная бизнес-логика содержится в слое **Application**, где определен класс **FlightAggregator**. Этот класс принимает список источников (**IFlightDataSource**), каждый из которых должен реализовать метод **GetFlights**, возвращающий список перелетов. 
Мы можем добавлять сколько угодно источников данных, и **FlightAggregator** будет агрегировать данные из них и возвращать их в унифицированном формате.

Для реализации механизма, при котором ответы возвращаются клиенту по мере получения от каждого источника, был использован **SignalR**, который обеспечивает передачу данных в реальном времени. 
Однако в этом случае также можно было использовать механизм опроса (**polling**) HTTP запросами для получения всех ответов вместо SignalR. Этот подход мог бы быть проще в реализации и использовании. 
То есть, при первом запросе вызывается FlightAggregator, который возвращает некий RequestId. Этот RequestId используется в последующих запросах для опроса состояния ответа от источников до получения всех ответов.

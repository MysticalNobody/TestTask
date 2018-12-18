# TestTask
Тестовое задания для устройства на работу. WebApi на .net core 2.0 для рассылки пуш-уведомлений при помощи сервиса pushover

[Клиент](https://github.com/MysticalNobody/TestTask/tree/master/TestTask/Client):
Предназначен для взаимодействия с сервером для отправки пуш уведомлений. 
[Сервер](https://github.com/MysticalNobody/TestTask/tree/master/TestTask):
Предназначен для перенаправления запросов с клента на сервис отправки уведомлений.
Реализован 1 метод: sendMessage
Подробнее можно ознакомиться, запустив сервер и перейдя по ссылке %server_url%/swagger
К примеру: [http://localhost:62374/swagger/index.html](http://localhost:62374/swagger/index.html)

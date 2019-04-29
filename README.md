# RabbitMqPubSub
* 基礎環境建置
```
docker run -d --hostname rabbit1 --name myrabbit1 -p 15672:15672 -p 5672:5672 rabbitmq:3.7-management
```